using ControlBeeAbstract.Devices;

namespace AjinDriver;

public class AjinDevice : Device, IMotionDevice
{
    public override void Init(Dictionary<string, object?> config)
    {
        var ret = CAXL.AxlIsOpened();
        Console.WriteLine(ret);
    }

    public override void Dispose()
    {
        throw new NotImplementedException();
    }

    public void Enable(int channel, bool value)
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(int channel)
    {
        throw new NotImplementedException();
    }

    public void TrapezoidalMove(int channel, int position, int velocity, int acceleration, int deceleration)
    {
        throw new NotImplementedException();
    }

    public void Wait(int channel)
    {
        throw new NotImplementedException();
    }

    public void Wait(int channel, int timeout)
    {
        throw new NotImplementedException();
    }

    public bool IsMoving(int channel)
    {
        throw new NotImplementedException();
    }

    public void SetCommandPosition(double position)
    {
        throw new NotImplementedException();
    }

    public void SetActualPosition(double position)
    {
        throw new NotImplementedException();
    }

    public void StartECam(int tableIndex, int masterChannel, int slaveChannel, double[] masterPositions,
        double[] slavePositions)
    {
        throw new NotImplementedException();
    }

    public void StopECam(int tableIndex)
    {
        throw new NotImplementedException();
    }

    public bool IsECamEnabled(int tableIndex)
    {
        throw new NotImplementedException();
    }
}