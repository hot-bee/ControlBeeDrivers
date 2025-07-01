using System.Diagnostics;
using ControlBeeAbstract.Devices;
using ControlBeeAbstract.Exceptions;
using log4net;
using static ComiLib.CMM.SafeNativeMethods;

namespace ComizoaDriver;

public class ComizoaDevice : Device, IMotionDevice, IDigitalIoDevice
{
    private static readonly ILog Logger = LogManager.GetLogger("ComizoaDevice");

    public bool GetDigitalInputBit(int channel)
    {
        var data = 0;
        var err = cmmDiGetOne(channel, ref data);
        if (err != 0) throw new DeviceError();
        return data == 1;
    }

    public void SetDigitalOutputBit(int channel, bool value)
    {
        var err = cmmDoPutOne(channel, value ? 1 : 0);
        if (err != 0) throw new DeviceError();
    }

    public bool GetDigitalOutputBit(int channel)
    {
        var data = 0;
        var err = cmmDoGetOne(channel, ref data);
        if (err != 0) throw new DeviceError();
        return data == 1;
    }

    public override void Init(Dictionary<string, object?> config)
    {
        var numAxes = 0;
        if (cmmGnDeviceLoad(0, ref numAxes) != 0) throw new DeviceError("Failed to init.");

        var initFile = config.GetValueOrDefault("InitFile") as string;
        if (string.IsNullOrEmpty(initFile))
            Logger.Warn("InitFile is empty.");
        else
        {
            if(cmmGnInitFromFile(initFile) != 0) throw new DeviceError();
        }
    }

    public override void Dispose()
    {
        if (cmmGnDeviceUnload() != 0) throw new DeviceError("Failed to dispose.");
    }

    public void Enable(int channel, bool value)
    {
        var err = cmmGnSetServoOn(channel, value ? 1 : 0);
        if (err != 0) throw new DeviceError("Failed to enable servo.");
    }

    public bool IsEnabled(int channel)
    {
        var data = 0;
        var err = cmmGnGetServoOn(channel, ref data);
        if (err != 0) throw new DeviceError();
        return data == 1;
    }

    public bool IsAlarmed(int channel)
    {
        var data = 0;
        var err = cmmStReadMioStatuses(channel, ref data);
        if (err != 0) throw new DeviceError("Failed to get status.");
        return (data & (1 << (int)_TCmMioState.ALM)) != 0;
    }

    public void ClearAlarm(int channel)
    {
        var err = cmmGnSetAlarmRes(channel, 1);
        if (err != 0) throw new DeviceError();
        Thread.Sleep(100);
        err = cmmGnSetAlarmRes(channel, 0);
        if (err != 0) throw new DeviceError();
    }

    public void SetTorque(int channel, double torque)
    {
        throw new NotImplementedException();
    }

    public void TrapezoidalMove(int channel, double position, double velocity, double acceleration, double deceleration)
    {
        var err = 0;
        err = cmmCfgSetSpeedPattern(channel, (int)SPDMODE.MODE_TRPZDL, velocity, acceleration, deceleration);
        if (err != 0) throw new DeviceError();
        err = cmmSxSetSpeedRatio(channel, (int)SPDMODE.MODE_TRPZDL, 100, 100, 100);
        if (err != 0) throw new DeviceError();
        err = cmmSxMoveToStart(channel, position);
        if (err != 0 && err != cmERR_STOP_BY_ELP && err != cmERR_STOP_BY_ELN) throw new DeviceError();
    }

    public void JerkRatioSCurveMove(int channel, double position, double velocity, double acceleration,
        double deceleration,
        double accelJerkRatio, double decelJerkRatio)
    {
        TrapezoidalMove(channel, position, velocity, acceleration, deceleration);
    }

    public void Wait(int channel)
    {
        Wait(channel, 0);
    }

    public void Wait(int channel, int timeout)
    {
        var sw = new Stopwatch();
        sw.Restart();
        while (IsMoving(channel))
        {
            if (0 != timeout && sw.ElapsedMilliseconds > timeout) throw new TimeoutError();
            Thread.Sleep(1);
        }
    }

    public bool IsMoving(int channel)
    {
        var data = 0;
        var err = cmmSxIsDone(channel, ref data);
        if (err != 0 && err != cmERR_STOP_BY_ELP && err != cmERR_STOP_BY_ELN) throw new DeviceError();
        return data != 1;
    }

    public void SetCommandAndActualPosition(int channel, double position)
    {
        SetCommandPosition(channel, position);
        SetActualPosition(channel, position);
    }

    public void SetCommandPosition(int channel, double position)
    {
        var err = cmmStSetPosition(channel, (int)_TCmCntr.cmCNT_COMM, position);
        if (err != 0) throw new DeviceError();
    }

    public void SetActualPosition(int channel, double position)
    {
        var err = cmmStSetPosition(channel, (int)_TCmCntr.cmCNT_FEED, position);
        if (err != 0) throw new DeviceError();
    }

    public double GetCommandPosition(int channel)
    {
        double data = 0;
        var err = cmmStGetPosition(channel, (int)_TCmCntr.cmCNT_COMM, ref data);
        if (err != 0) throw new DeviceError();
        return data;
    }

    public double GetActualPosition(int channel)
    {
        double data = 0;
        var err = cmmStGetPosition(channel, (int)_TCmCntr.cmCNT_FEED, ref data);
        if (err != 0) throw new DeviceError();
        return data;
    }

    public double GetCommandVelocity(int channel)
    {
        throw new NotImplementedException();
    }

    public double GetActualVelocity(int channel)
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

    public bool GetHomeSensor(int channel)
    {
        var data = 0;
        var err = cmmStReadMioStatuses(channel, ref data);
        if (err != 0) throw new DeviceError("Failed to get status.");
        return (data & (1 << (int)_TCmMioState.ORG)) != 0;
    }

    public bool GetNegativeLimitSensor(int channel)
    {
        var data = 0;
        var err = cmmStReadMioStatuses(channel, ref data);
        if (err != 0) throw new DeviceError("Failed to get status.");
        return (data & (1 << (int)_TCmMioState.ELN)) != 0;
    }

    public bool GetPositiveLimitSensor(int channel)
    {
        var data = 0;
        var err = cmmStReadMioStatuses(channel, ref data);
        if (err != 0) throw new DeviceError("Failed to get status.");
        return (data & (1 << (int)_TCmMioState.ELP)) != 0;
    }

    public void VelocityMove(int channel, double velocity, double acceleration, double deceleration,
        double accelJerkRatio,
        double decelJerkRatio)
    {
        var err = 0;
        err = cmmCfgSetSpeedPattern(channel, (int)SPDMODE.MODE_TRPZDL, Math.Abs(velocity), acceleration, deceleration);
        if (err != 0) throw new DeviceError();
        err = cmmSxSetSpeedRatio(channel, (int)SPDMODE.MODE_TRPZDL, 100, 100, 100);
        if (err != 0) throw new DeviceError();
        err = cmmSxVMoveStart(channel, velocity >= 0 ? (int)Direction.DIR_P : (int)Direction.DIR_N);
        if (err != 0 && err != cmERR_STOP_BY_ELP && err != cmERR_STOP_BY_ELN) throw new DeviceError();
    }

    public void Stop(int channel)
    {
        var err = 0;
        err = cmmSxStop(channel, 0, 0);
        if (err != 0) throw new DeviceError();
    }

    public void EStop(int channel)
    {
        var err = 0;
        err = cmmSxStopEmg(channel);
        if (err != 0) throw new DeviceError();
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

    public void JerkRatioSCurveMove((int channel, double position)[] channelAndPositions, double velocity, double acceleration, double deceleration, double accelJerkRatio, double decelJerkRatio)
    {
        var mapMask1 = 0;
        foreach (var (channel, position) in channelAndPositions)
        {
            switch(channel)
            {
                case 0:
                    mapMask1 += (int)_TCmAxisMask.cmX1_MASK;
                    break;
                case 1:
                    mapMask1 += (int)_TCmAxisMask.cmY1_MASK;
                    break;
                case 2:
                    mapMask1 += (int)_TCmAxisMask.cmZ1_MASK;
                    break;
                case 3:
                    mapMask1 += (int)_TCmAxisMask.cmU1_MASK;
                    break;
            }
        }
        cmmIxMapAxes(0, mapMask1, 0);
        cmmIxSetSpeedPattern(0, 1, (int)SPDMODE.MODE_TRPZDL, velocity, acceleration, deceleration);
        var positions = channelAndPositions.Select(x => x.position).ToArray();
        cmmIxLineToStart(0, positions);
    }
}