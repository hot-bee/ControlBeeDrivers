using ACS.SPiiPlusNET;
using ControlBeeAbstract.Devices;
using log4net;

namespace AcsDriver;

public class AcsDevice : Device, IMotionDevice, IDigitalIoDevice, IBufferDevice
{
    private const int BitsPerSlot = 16; // TODO: Parameterize this since this could be 8 for some use.
    private static readonly ILog Logger = LogManager.GetLogger(nameof(AcsDevice));
    private readonly Api _api = new();

    public bool GetDigitalInputBit(int channel)
    {
        var slot = channel / BitsPerSlot;
        var bit = channel % BitsPerSlot;
        var vector = (int[])_api.ReadVariableAsVector("Din0", ProgramBuffer.ACSC_NONE, slot, slot);
        var value = (vector[0] & (1 << bit)) != 0;
        return value;
    }

    public void SetDigitalOutputBit(int channel, bool value)
    {
        var slot = channel / BitsPerSlot;
        var bit = channel % BitsPerSlot;
        var vector = (int[])_api.ReadVariableAsVector("Dout0", ProgramBuffer.ACSC_NONE, slot, slot);
        vector[0] = (vector[0] & ~(1 << bit)) | ((value ? 1 : 0) << bit);
        _api.WriteVariable(vector, "Dout0", ProgramBuffer.ACSC_NONE, slot, slot);
    }

    public bool GetDigitalOutputBit(int channel)
    {
        var slot = channel / BitsPerSlot;
        var bit = channel % BitsPerSlot;
        var vector = (int[])_api.ReadVariableAsVector("Dout0", ProgramBuffer.ACSC_NONE, slot, slot);
        var value = (vector[0] & (1 << bit)) != 0;
        return value;
    }

    public override void Init(Dictionary<string, object?> config)
    {
        _api.OpenCommSimulator();

        var hostIp = config.GetValueOrDefault("HostIP") as string;
        var hostPort = config.GetValueOrDefault("HostPort") as string;
    }

    public override void Dispose()
    {
        _api.CloseComm();
    }

    public void Enable(int channel, bool value)
    {
        if (value)
        {
            _api.Enable((Axis)channel);
            _api.EnableFault((Axis)channel, SafetyControlMasks.ACSC_ALL);
        }
        else
        {
            _api.Disable((Axis)channel);
        }
    }

    public bool IsEnabled(int channel)
    {
        var state = _api.GetMotorState(Axis.ACSC_AXIS_0);
        return (state & MotorStates.ACSC_MST_ENABLE) != 0;
    }

    public bool IsAlarmed(int channel)
    {
        var fault = _api.GetFault(Axis.ACSC_AXIS_0);
        fault &= ~SafetyControlMasks.ACSC_SAFETY_RL;
        fault &= ~SafetyControlMasks.ACSC_SAFETY_LL;
        return fault != 0;
    }

    public void ClearAlarm(int channel)
    {
        _api.FaultClear((Axis)channel);
        _api.EnableFault((Axis)channel, SafetyControlMasks.ACSC_ALL);
    }

    public void SetTorque(int channel, double torque)
    {
        throw new NotImplementedException();
    }

    public void TrapezoidalMove(int channel, double position, double velocity, double acceleration, double deceleration)
    {
        throw new NotImplementedException();
    }

    public void JerkRatioSCurveMove(int channel, double position, double velocity, double acceleration,
        double deceleration,
        double accelJerkRatio, double decelJerkRatio)
    {
        var accelTime = velocity / acceleration;
        var jerk = velocity / accelJerkRatio / (accelTime * accelTime);
        _api.SetVelocity((Axis)channel, velocity);
        _api.SetAcceleration((Axis)channel, acceleration);
        _api.SetDeceleration((Axis)channel, acceleration);
        _api.SetJerk((Axis)channel, jerk);
        _api.ToPoint(MotionFlags.ACSC_NONE, (Axis)channel, position);
    }

    public void JerkRatioSCurveMove((int channel, double position)[] channelAndPositions, double velocity,
        double acceleration,
        double deceleration, double accelJerkRatio, double decelJerkRatio)
    {
        throw new NotImplementedException();
    }

    public void Wait(int channel)
    {
        const int threeMinutes = 3 * 60 * 1000;
        Wait(channel, threeMinutes);
    }

    public void Wait(int channel, int timeout)
    {
        _api.WaitMotionEnd((Axis)channel, timeout);
    }

    public bool IsMoving(int channel)
    {
        var state = _api.GetMotorState(Axis.ACSC_AXIS_0);
        return (state & MotorStates.ACSC_MST_MOVE) != 0;
    }

    public void SetCommandAndActualPosition(int channel, double position)
    {
        SetCommandPosition(channel, position);
        SetActualPosition(channel, position);
    }

    public void SetCommandPosition(int channel, double position)
    {
        _api.SetRPosition((Axis)channel, position);
    }

    public void SetActualPosition(int channel, double position)
    {
        _api.SetFPosition((Axis)channel, position);
    }

    public double GetCommandPosition(int channel)
    {
        return _api.GetRPosition((Axis)channel);
    }

    public double GetActualPosition(int channel)
    {
        return _api.GetFPosition((Axis)channel);
    }

    public double GetCommandVelocity(int channel)
    {
        return _api.GetRVelocity((Axis)channel);
    }

    public double GetActualVelocity(int channel)
    {
        return _api.GetFVelocity((Axis)channel);
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

    public bool GetHomeSensor(int channel)
    {
        // TODO: No use case yet.
        return false;
    }

    public bool GetNegativeLimitSensor(int channel)
    {
        // TODO: No use case yet.
        return false;
    }

    public bool GetPositiveLimitSensor(int channel)
    {
        // TODO: No use case yet.
        return false;
    }

    public void VelocityMove(int channel, double velocity, double acceleration, double deceleration,
        double accelJerkRatio,
        double decelJerkRatio)
    {
        var absoluteVelocity = Math.Abs(velocity);
        var accelTime = absoluteVelocity / acceleration;
        var jerk = absoluteVelocity / accelJerkRatio / (accelTime * accelTime);
        _api.SetVelocity((Axis)channel, absoluteVelocity);
        _api.SetAcceleration((Axis)channel, acceleration);
        _api.SetDeceleration((Axis)channel, acceleration);
        _api.SetJerk((Axis)channel, jerk);
        _api.Jog(MotionFlags.ACSC_AMF_VELOCITY, (Axis)channel, velocity);
    }

    public void Stop(int channel)
    {
        _api.Halt((Axis)channel);
    }

    public void EStop(int channel)
    {
        _api.Halt((Axis)channel);
    }

    public void SearchZPhase(int channel, double velocity, double acceleration, double distance)
    {
        throw new NotImplementedException();
    }

    public void SetSyncGearRatio(int masterChannel, int slaveChannel, double gearRatio, double velocity,
        double acceleration,
        double deceleration, double accelJerkRatio, double decelJerkRatio)
    {
        throw new NotImplementedException();
    }

    public void RunBuffer(int bufferIndex, string label)
    {
        _api.RunBuffer((ProgramBuffer)bufferIndex, label);
    }

    public void StopBuffer(int bufferIndex)
    {
        _api.StopBuffer((ProgramBuffer)bufferIndex);
    }

    public object ReadVariable(string variable, int bufferIndex = -1,
        int from1 = -1, int to1 = -1, int from2 = -1, int to2 = -1)
    {
        return _api.ReadVariable(variable, (ProgramBuffer)bufferIndex, from1, to1, from2, to2);
    }

    public void WriteVariable(object value, string variable, int bufferIndex = -1,
        int from1 = -1, int to1 = -1, int from2 = -1, int to2 = -1)
    {
        _api.WriteVariable(value, variable, (ProgramBuffer)bufferIndex, from1, to1, from2, to2);
    }
}