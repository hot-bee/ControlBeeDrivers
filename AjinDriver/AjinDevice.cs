﻿using System.Diagnostics;
using System.Threading.Channels;
using ControlBeeAbstract.Devices;
using ControlBeeAbstract.Exceptions;

namespace AjinDriver;

public class AjinDevice : Device, IMotionDevice
{
    public override void Init(Dictionary<string, object?> config)
    {
        if (CAXL.AxlOpen(0) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError("Couldn't open AjinDevice.");

        uint status = 0;
        if (CAXM.AxmInfoIsMotionModule(ref status) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError("Couldn't find MotionModule.");
        if (status != (uint)AXT_EXISTENCE.STATUS_EXIST)
            throw new DeviceError("Couldn't find MotionModule.");

        var parameterFile = config.GetValueOrDefault("ParameterFile") as string;
        if (!string.IsNullOrEmpty(parameterFile))
        {
            if (CAXM.AxmMotLoadParaAll(parameterFile) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
                throw new DeviceError();
        }
    }

    public override void Dispose()
    {
        if (CAXL.AxlClose() != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError("Couldn't open AjinDevice.");
    }

    public void Enable(int channel, bool value)
    {
        if (CAXM.AxmSignalServoOn(channel, (uint)(value ? 1 : 0)) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public bool IsEnabled(int channel)
    {
        uint status = 0;
        if (CAXM.AxmSignalIsServoOn(channel, ref status) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return status == 1;
    }

    public void TrapezoidalMove(int channel, double position, double velocity, double acceleration, double deceleration)
    {
        throw new NotImplementedException();
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
        uint status = 0;
        if (CAXM.AxmStatusReadInMotion(channel, ref status) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return status == 1;
    }

    public void SetCommandAndActualPosition(int channel, double position)
    {
        if (CAXM.AxmStatusSetPosMatch(channel, position) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public void SetCommandPosition(int channel, double position)
    {
        if (CAXM.AxmStatusSetCmdPos(channel, position) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public void SetActualPosition(int channel, double position)
    {
        if (CAXM.AxmStatusSetActPos(channel, position) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public double GetCommandPosition(int channel)
    {
        double pos = 0;
        if (CAXM.AxmStatusGetCmdPos(channel, ref pos) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return pos;
    }

    public double GetActualPosition(int channel)
    {
        double pos = 0;
        if (CAXM.AxmStatusGetActPos(channel, ref pos) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return pos;
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
        uint status = 0;
        if (CAXM.AxmHomeReadSignal(channel, ref status) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return status == 1;
    }

    public bool GetNegativeLimitSensor(int channel)
    {
        uint positive = 0;
        uint negative = 0;
        if (CAXM.AxmSignalReadLimit(channel, ref positive, ref negative) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return negative == 1;
    }

    public bool GetPositiveLimitSensor(int channel)
    {
        uint positive = 0;
        uint negative = 0;
        if (CAXM.AxmSignalReadLimit(channel, ref positive, ref negative) != (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        return positive == 1;
    }

    public void JerkRatioSCurveMove(int channel, double position, double velocity, double acceleration,
        double deceleration, double accelJerkRatio, double decelJerkRatio)
    {
        if (CAXM.AxmMotSetAbsRelMode(channel, (uint)AXT_MOTION_ABSREL.POS_ABS_MODE) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMotSetProfileMode(channel, (uint)AXT_MOTION_PROFILE_MODE.ASYM_S_CURVE_MODE) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMotSetAccelJerk(channel, accelJerkRatio * 100.0) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMotSetDecelJerk(channel, decelJerkRatio * 100.0) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMoveStartPos(channel, position, velocity, acceleration, deceleration) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public void VelocityMove(int channel, double velocity, double acceleration,
        double deceleration, double accelJerkRatio, double decelJerkRatio)
    {
        if (CAXM.AxmMotSetProfileMode(channel, (uint)AXT_MOTION_PROFILE_MODE.ASYM_S_CURVE_MODE) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMotSetAccelJerk(channel, accelJerkRatio * 100.0) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMotSetDecelJerk(channel, decelJerkRatio * 100.0) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
        if (CAXM.AxmMoveVel(channel, velocity, acceleration, deceleration) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public void Stop(int channel)
    {
        if (CAXM.AxmMoveSStop(channel) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }

    public void EStop(int channel)
    {
        if (CAXM.AxmMoveEStop(channel) !=
            (uint)AXT_FUNC_RESULT.AXT_RT_SUCCESS)
            throw new DeviceError();
    }
}