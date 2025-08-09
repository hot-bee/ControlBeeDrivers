using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using ControlBeeAbstract.Devices;
using ControlBeeAbstract.Exceptions;
using log4net;
using WatsonTcp;
using Dict = System.Collections.Generic.Dictionary<string, object?>;

namespace TcpVisionDriver;

public class TcpVisionDriver : Device, IVisionDevice
{
    private static readonly ILog Logger = LogManager.GetLogger(nameof(TcpVisionDriver));
    private bool[,] _busyGrab = null!;
    private bool[,] _busyResult = null!;

    private WatsonTcpClient _client = null!;
    private JsonObject[,] _result = null!;

    public void EmbedVisionView(IntPtr parentHandle, int channel)
    {
        Logger.Info("Send a request to embed vision view.");
        var payload = new Dict
        {
            ["Name"] = "EmbedVision",
            ["Parent"] = parentHandle.ToInt64(),
            ["Channel"] = channel
        };
        var message = JsonSerializer.Serialize(payload);
        _client.SendAsync(message);
    }

    public void StartContinuous(int channel)
    {
        Logger.Info("Send a request to start continuous grab.");
        var payload = new Dict
        {
            ["Name"] = "StartContinuous",
            ["Channel"] = channel
        };
        var message = JsonSerializer.Serialize(payload);
        _client.SendAsync(message);
    }

    public void StopContinuous(int channel)
    {
        Logger.Info("Send a request to stop continuous grab.");
        var payload = new Dict
        {
            ["Name"] = "StopContinuous",
            ["Channel"] = channel
        };
        var message = JsonSerializer.Serialize(payload);
        _client.SendAsync(message);
    }

    public void FocusChannel(int channel)
    {
        Logger.Info("Send a request to focus the given channel.");
        var payload = new Dict
        {
            ["Name"] = "FocusChannel",
            ["Channel"] = channel
        };
        var message = JsonSerializer.Serialize(payload);
        _client.SendAsync(message);
    }

    public event EventHandler? VisionConnected;
    public event EventHandler? VisionDisconnected;

    public override void Init(Dict config)
    {
        var ip = config.GetValueOrDefault("RemoteIp") as string ?? "127.0.0.1";
        var port = int.Parse(config.GetValueOrDefault("RemotePort") as string ?? "9000");
        var channelCount = int.Parse(config.GetValueOrDefault("ChannelCount") as string ?? "8");
        var inspectionCount = int.Parse(config.GetValueOrDefault("InspectionCount") as string ?? "16");

        _busyGrab = new bool[channelCount, inspectionCount];
        _busyResult = new bool[channelCount, inspectionCount];
        _result = new JsonObject[channelCount, inspectionCount];

        _client = new WatsonTcpClient(ip, port);

        _client.Events.ServerConnected += EventsOnServerConnected;
        _client.Events.ServerDisconnected += EventsOnServerDisconnected;
        _client.Events.MessageReceived += EventsOnMessageReceived;

        Connect();
    }

    public override void Dispose()
    {
        _client.Dispose();
    }

    public void Connect()
    {
        Logger.Error("Start connecting to the remote.");
        try
        {
            _client.Connect();
        }
        catch (SocketException)
        {
            Logger.Error("Couldn't connect to the remote.");
        }
        catch (TimeoutException)
        {
            Logger.Error("Couldn't connect to the remote.");
        }
    }

    public bool IsConnected()
    {
        return _client.Connected;
    }

    public void Trigger(int channel, int inspectionIndex)
    {
        Logger.Info($"Start trigger ({channel}).");
        if (!IsConnected())
        {
            Logger.Error($"Failed to trigger ({channel}). Vision is not connected.");
            throw new ConnectionError();
        }

        var payload = new Dict
        {
            ["Name"] = "Trigger",
            ["Channel"] = channel,
            ["InspectionIndex"] = inspectionIndex
        };
        var message = JsonSerializer.Serialize(payload);
        _busyGrab[channel, inspectionIndex] = true;
        _busyResult[channel, inspectionIndex] = true;
        _client.SendAsync(message);
        Logger.Info($"Finished trigger {channel}.");
    }

    public void Wait(int channel, int inspectionIndex, int timeout)
    {
        Logger.Info($"Start wait result {channel}.");
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        while (_busyResult[channel, inspectionIndex])
        {
            if (stopwatch.ElapsedMilliseconds > timeout)
                throw new TimeoutError();
            Thread.Sleep(1);
        }

        Logger.Info($"Finished wait result {channel}.");
    }

    public void WaitGrabEnd(int channel, int inspectionIndex, int timeout)
    {
        Logger.Info($"Start wait grab {channel}.");
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        while (_busyGrab[channel, inspectionIndex])
        {
            if (stopwatch.ElapsedMilliseconds > timeout)
                throw new TimeoutError();
            Thread.Sleep(1);
        }

        Logger.Info($"Finished wait grab {channel}.");
    }

    public JsonObject GetResult(int channel, int inspectionIndex)
    {
        return _result[channel, inspectionIndex];
    }

    private void EventsOnMessageReceived(object? sender, MessageReceivedEventArgs e)
    {
        var data = Encoding.UTF8.GetString(e.Data);
        Logger.Info($"Received data. ({data})");
        var dict = JsonSerializer.Deserialize<JsonObject>(data)!;
        var channel = (int)dict["Channel"]!;
        var inspectionIndex = (int)dict["InspectionIndex"]!;
        var type = (string)dict["Type"]!;
        switch (type)
        {
            case "GrabEnd":
                _busyGrab[channel, inspectionIndex] = false;
                break;
            case "Result":
                _result[channel, inspectionIndex] = dict;
                _busyResult[channel, inspectionIndex] = false;
                break;
        }
    }

    private void EventsOnServerDisconnected(object? sender, DisconnectionEventArgs e)
    {
        Logger.Info("Disconnected.");
        OnVisionDisconnected();
    }

    private void EventsOnServerConnected(object? sender, ConnectionEventArgs e)
    {
        Logger.Info("Connected.");
        OnVisionConnected();
    }

    protected virtual void OnVisionConnected()
    {
        VisionConnected?.Invoke(this, EventArgs.Empty);
    }

    protected virtual void OnVisionDisconnected()
    {
        VisionDisconnected?.Invoke(this, EventArgs.Empty);
    }
}