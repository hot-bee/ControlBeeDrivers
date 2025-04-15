using ControlBeeAbstract.Devices;
using ControlBeeAbstract.Exceptions;
using WMX3ApiCLR;

namespace MovensysDriver;

public class MovensysDevice : Device, IMotionDevice, IDigitalIoDevice, IAnalogIoDevice
{
    private readonly WMX3Api _api;
    private readonly CoreMotion _coreMotion;
    private readonly Io _io;

    public MovensysDevice()
    {
        _api = new WMX3Api();
        _coreMotion = new CoreMotion(_api);
        _io = new Io(_api);
    }

    public void SetAnalogOutputByte(int channel, byte value)
    {
        _io.SetOutAnalogDataUCharEx(channel, value);
    }

    public void SetAnalogOutputSignedByte(int channel, sbyte value)
    {
        _io.SetOutAnalogDataCharEx(channel, value);
    }

    public void SetAnalogOutputWord(int channel, ushort value)
    {
        _io.SetOutAnalogDataUShortEx(channel, value);
    }

    public void SetAnalogOutputSignedWord(int channel, short value)
    {
        _io.SetOutAnalogDataShortEx(channel, value);
    }

    public void SetAnalogOutputDWord(int channel, uint value)
    {
        _io.SetOutAnalogDataUIntEx(channel, value);
    }

    public void SetAnalogOutputSignedDWord(int channel, int value)
    {
        _io.SetOutAnalogDataIntEx(channel, value);
    }

    public byte GetAnalogOutputByte(int channel)
    {
        byte value = 0;
        _io.GetInAnalogDataUCharEx(channel, ref value);
        return value;
    }

    public sbyte GetAnalogOutputSignedByte(int channel)
    {
        sbyte value = 0;
        _io.GetInAnalogDataCharEx(channel, ref value);
        return value;
    }

    public ushort GetAnalogOutputWord(int channel)
    {
        ushort value = 0;
        _io.GetInAnalogDataUShortEx(channel, ref value);
        return value;
    }

    public short GetAnalogOutputSignedWord(int channel)
    {
        short value = 0;
        _io.GetInAnalogDataShortEx(channel, ref value);
        return value;
    }

    public uint GetAnalogOutputDWord(int channel)
    {
        uint value = 0;
        _io.GetInAnalogDataUIntEx(channel, ref value);
        return value;
    }

    public int GetAnalogOutputSignedDWord(int channel)
    {
        // ReSharper disable once SuggestVarOrType_BuiltInTypes
        int value = 0;
        _io.GetInAnalogDataIntEx(channel, ref value);
        return value;
    }

    public bool GetDigitalInputBit(int channel)
    {
        byte value = 0;
        var (address, offset) = FromChannel(channel);
        _io.GetInBitEx(address, offset, ref value);
        return value != 0;
    }

    public void SetDigitalOutputBit(int channel, bool value)
    {
        var (address, offset) = FromChannel(channel);
        var byteValue = (byte)(value ? 1 : 0);
        _io.SetOutBit(address, offset, byteValue);
    }

    public bool GetDigitalOutputBit(int channel)
    {
        byte value = 0;
        var (address, offset) = FromChannel(channel);
        _io.GetOutBit(address, offset, ref value);
        return value != 0;
    }

    public void Enable(int channel, bool value)
    {
        var err = 0;
        err = _coreMotion.AxisControl.SetServoOn(channel, value ? 1 : 0);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public bool IsEnabled(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].ServoOn;
    }

    public bool IsAlarmed(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].AmpAlarm;
    }

    public void ClearAlarm(int channel)
    {
        var err = 0;
        err = _coreMotion.AxisControl.ClearAmpAlarm(channel);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }


    public void TrapezoidalMove(int channel, double position, double velocity, double acceleration, double deceleration)
    {
        SetCommandMode(channel, AxisCommandMode.Position);
        var err = 0;
        var pos = new Motion.PosCommand
        {
            Axis = channel,
            Profile =
            {
                Type = ProfileType.Trapezoidal,
                Velocity = velocity,
                Acc = acceleration,
                Dec = deceleration
            },
            Target = position
        };
        err = _coreMotion.Motion.StartPos(pos);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public void JerkRatioSCurveMove(int channel, double position, double velocity, double acceleration, double deceleration,
        double accelJerkRatio, double decelJerkRatio)
    {
        SetCommandMode(channel, AxisCommandMode.Position);
        var err = 0;
        var pos = new Motion.PosCommand
        {
            Axis = channel,
            Profile =
            {
                Type = ProfileType.JerkRatio,
                Velocity = velocity,
                Acc = acceleration,
                Dec = deceleration,
                JerkAccRatio = accelJerkRatio,
                JerkDecRatio = decelJerkRatio
            },
            Target = position
        };
        err = _coreMotion.Motion.StartPos(pos);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public void Wait(int channel)
    {
        var err = 0;
        err = _coreMotion.Motion.Wait(channel);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public void Wait(int channel, int timeout)
    {
        var err = 0;
        err = _coreMotion.Motion.Wait(channel, (uint)timeout);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public bool IsMoving(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].OpState != OperationState.Idle;
    }

    public void SetCommandAndActualPosition(int channel, double position)
    {
        SetCommandMode(channel, AxisCommandMode.Position);
        SetCommandPosition(channel, position);
        SetActualPosition(channel, position);
    }

    public void SetCommandPosition(int channel, double position)
    {
        SetCommandMode(channel, AxisCommandMode.Position);
        var err = 0;
        err = _coreMotion.Home.SetCommandPos(channel, position);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public void SetActualPosition(int channel, double position)
    {
        SetCommandMode(channel, AxisCommandMode.Position);
        var err = 0;
         err = _coreMotion.Home.SetFeedbackPos(channel, position);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public double GetCommandPosition(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].PosCmd;
    }

    public double GetActualPosition(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].ActualPos;
    }

    public void StartECam(int tableIndex, int masterChannel, int slaveChannel, double[] masterPositions, double[] slavePositions)
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

    public bool GetHomeSensor(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].HomeSwitch;
    }

    public bool GetNegativeLimitSensor(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].NegativeLS;
    }

    public bool GetPositiveLimitSensor(int channel)
    {
        var err = 0;
        var st = new CoreMotionStatus();
        err = _coreMotion.GetStatus(ref st);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
        return st.AxesStatus[channel].PositiveLS;
    }

    private void SetCommandMode(int channel, AxisCommandMode mode)
    {
        var err = 0;
        if (GetCommandMode(channel) == mode) return;
        err = _coreMotion.AxisControl.SetAxisCommandMode(channel, mode);
        if (err != ErrorCode.None) throw new Exception(CoreMotion.ErrorToString(err));
    }

    private AxisCommandMode GetCommandMode(int channel)
    {
        var err = 0;
        AxisCommandMode mode = AxisCommandMode.Position;
        err = _coreMotion.AxisControl.GetAxisCommandMode(channel, ref mode);
        if (err != ErrorCode.None) throw new Exception(CoreMotion.ErrorToString(err));
        return mode;
    }

    public void VelocityMove(int channel, double velocity, double acceleration, double deceleration, double accelJerkRatio,
        double decelJerkRatio)
    {
        SetCommandMode(channel, AxisCommandMode.Velocity);
        var err = 0;
        var vel = new Velocity.VelCommand
        {
            Axis = channel,
            Profile =
            {
                Type = ProfileType.JerkRatio,
                Velocity = velocity,
                Acc = acceleration,
                Dec = deceleration,
                JerkAccRatio = accelJerkRatio,
                JerkDecRatio = decelJerkRatio
            },
        };
        err = _coreMotion.Velocity.StartVel(vel);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public void Stop(int channel)
    {
        var mode = GetCommandMode(channel);
        switch (mode)
        {
            case AxisCommandMode.Position:
                _coreMotion.Motion.Stop(channel);
                break;
            case AxisCommandMode.Velocity:
                _coreMotion.Velocity.Stop(channel);
                break;
            default:
                throw new ValueError();
        }
    }

    public void EStop(int channel)
    {
        Stop(channel);
        //var mode = GetCommandMode(channel);
        //switch (mode)
        //{
        //    case AxisCommandMode.Position:
        //        _coreMotion.Motion.ExecTimedStop(channel, 0.0);
        //        break;
        //    case AxisCommandMode.Velocity:
        //        _coreMotion.Velocity.ExecTimedStop(channel, 0.0);
        //        break;
        //    default:
        //        throw new ValueError();
        //}
    }

    public void SearchZPhase(int channel, double velocity, double acceleration, double distance)
    {
        throw new NotImplementedException();
    }

    public override void Dispose()
    {
        var err = 0;
        err = _api.StopCommunication();
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));

        err = _api.CloseDevice();
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));

        _api.Dispose();
    }

    public override void Init(Dictionary<string, object?> config)
    {
        var err = 0;
        var wmxDir = config.GetValueOrDefault("WMXDir") as string ?? @"C:\Program Files\SoftServo\WMX3";
        err = _api.CreateDevice(wmxDir, DeviceType.DeviceTypeNormal);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));

        err = _api.SetDeviceName("ControlBee");
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));

        var startCommunicationTimeout = config.GetValueOrDefault("StartCommunicationTimeout") as uint? ?? 5000;
        err = _api.StartCommunication(startCommunicationTimeout);
        if (err != ErrorCode.None) throw new Exception(GetErrorMessage(err));
    }

    public string GetErrorMessage(int errorCode)
    {
        return WMX3Api.ErrorToString(errorCode);
    }

    private (int address, int offset) FromChannel(int channel)
    {
        return (channel / 8, channel % 8);
    }
}