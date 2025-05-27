using System;
using System.Runtime.InteropServices;

namespace ComiLib.CMM
{
    [System.Security.SuppressUnmanagedCodeSecurity]
    public unsafe class SafeNativeMethods
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct PT_MOTION_TAB
        {
            [MarshalAs(UnmanagedType.ByValArray)]
            public double[] position;

            [MarshalAs(UnmanagedType.ByValArray)]
            public double[] time;

            public double total_time;
            public long pointCnt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOTION_CONFIG
        {
            public int master_ms; // ms_no
            public int groupID;
            public float stop_time;
            public float e_stop_time;
            public int gantry_flag; // moving magnet방식 : -1, no gantry algorithm : 0, semi gantry algorithm : 1, gantry algorithm master : 2, gantry algorithm slave : 3.
            public int master_axis_no; // 실제로 제어할 축의 번호를 설정
            public int axis_cnt; // 제어할 모터의 개수

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public int[] axis_no; // 제어할 축의 번호를 group 으로 지정

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public int[] motion_ms;
        }

        // Device ID definition //
        public const int COMI_SD401 = 0xB401;
        public const int COMI_SD402 = 0xB402;
        public const int COMI_SD403 = 0xB403;
        public const int COMI_SD404 = 0xB404;
        public const int COMI_SD414 = 0xB414;
        public const int COMI_SD424 = 0xB424;
        public const int COMI_LX501 = 0xA501;
        public const int COMI_LX502 = 0xA502;
        public const int COMI_LX504 = 0xA504;
        public const int COMI_LX508 = 0xA508;
        public const int COMI_LX534 = 0xA534;
        public const int COMI_LX544 = 0xA544;
        public const int COMI_LX504A = 0xA544;

        // Definition of maximum number of things //
        public const int CMM_MAX_NUM_MOT_DEV = 16; // Maximum number of Motion Devices in one PC
        public const int CMM_MAX_NUM_DIO_DEV = 16; // Maximum number of Digital I/O Devices in one PC
        public const int CMM_MAX_NUM_AXES = 64; // Maximum number of motion axes
        public const int CMM_MAX_DI_CH = 512; // Maximum number of D/I channels
        public const int CMM_MAX_DO_CH = 512; // Maximum number of D/O channels
        public const int CMM_MAX_STR_LEN_AXIS_TITLE = 30; // Maximum string length of axis title
        public const int CMM_MAX_STR_LEN_DIST_UNIT = 30; // Maximum string length of distance unit
        public const int CMM_MAX_STR_LEN_VEL_UNIT = 30; // Maximum string length of velocity unit
        public const int CMM_MAX_STR_LEN_ERR = 128;  // Maximum error string length: a buffer to receive error string must be larger than this size.

        // Error code definitions by OYS 2006/08/03
        //***********************************************************************************************
        //									ERROR CODE DEFINITIONs										*
        //***********************************************************************************************
        public const int cmERR_NONE = 0;
        public const int cmERR_MEM_ALLOC_FAIL = -290;	// Memory allocation fail
        public const int cmERR_GLOBAL_MEM_FAIL = -292;	// Global memory allocation fail
        public const int cmERR_ISR_CONNEC_FAIL = -310;	// ISR registerration fail
        public const int cmERR_DIVIDE_BY_ZERO = -400;	// Cause divide by zero error 
        public const int cmERR_WORNG_NUM_DATA = -500;	// Number of data is too small or too big
        public const int cmERR_VER_MISMATCH = -600;	// Version(of file or device) mismatch

        public const int cmERR_INVALID_DEVICE_ID = -1010; // Invalid device id => Load Device 또는 SetDeviceId()에서...
        public const int cmERR_INVALID_HANDLE = -1020;
        public const int cmERR_UNSUPORTED_FUNC = -1030;
        public const int cmERR_INVALID_PARAMETER = -1101;
        public const int cmERR_INVALID_CHANNEL = -1105;
        public const int cmERR_INVALID_INPUT_RANGE = -1111; // Invalid range value (AI, AO)
        public const int cmERR_INVALID_FREQ_RANGE = -1121; // Invalid input or output frequency
        public const int cmERR_FILE_CREATE_FAIL = -1501; // File create fail 
        public const int cmERR_FILE_OPEN_FAIL = -1511; // File open fail
        public const int cmERR_EVENT_CREATE_FAIL = -1550; // Event handle creation fail			
        public const int cmERR_INT_INSTANCE_FAIL = -1560; // Interrupt event instance creation fail
        public const int cmERR_DITHREAD_CRE = -1570; // D/I state change monitor thread creation fail
        public const int cmERR_BUFFER_SMALL = -1580; // Buffer size is too small

        public const int cmERR_ON_MOTION = -5001;
        public const int cmERR_STOP_BY_SLP = -5002; // Abnormally stopped by positive soft limit
        public const int cmERR_STOP_BY_SLN = -5003; // Abnormally stopped by negative soft limit
        public const int cmERR_STOP_BY_CMP3 = -5004; // Abnormally stopped by comparator3
        public const int cmERR_STOP_BY_CMP4 = -5005; // Abnormally stopped by comparator4
        public const int cmERR_STOP_BY_CMP5 = -5006; // Abnormally stopped by comparator5
        public const int cmERR_STOP_BY_ELP = -5007; // Abnormally stopped by (+) external limit
        public const int cmERR_STOP_BY_ELN = -5008; // Abnormally stopped by (-) external limit
        public const int cmERR_STOP_BY_ALM = -5009; // Abnormally stopped by alarm input signal
        public const int cmERR_STOP_BY_CSTP = -5010; // Abnormally stopped by CSTP input signal
        public const int cmERR_STOP_BY_CEMG = -5011; // Abnormally stopped by CEMG input signal
        public const int cmERR_STOP_BY_SD = -5012; // Abnormally stopped by SD input signal
        public const int cmERR_STOP_BY_DERROR = -5013; // Abnormally stopped by operation data error
        public const int cmERR_STOP_BY_IP = -5014; // Abnormally stopped by other axis error during interpolation
        public const int cmERR_STOP_BY_PO = -5015; // An overflow occurred in the PA/PB input buffer
        public const int cmERR_STOP_BY_AO = -5016; // Out of range position counter during interpolation
        public const int cmERR_STOP_BY_EE = -5017; // An EA/EB input error occurred (does not stop)
        public const int cmERR_STOP_BY_PE = -5018; // An PA/PB input error occurred (does not stop)
        public const int cmERR_STOP_BY_SLVERR = -5019; // Abnormally stopped because slave axis has been stopped
        public const int cmERR_STOP_BY_SEMG = -5020; // Abnormally stopped by software emergency setting

        public const int cmERR_MOT_MAOMODE = -5110; // Master output mode is not CW/CCW mode // Master/Slave 동작시에 Master output모드가 CW/CCW모드가 아니다.
        public const int cmERR_MOT_SLAVE_SET = -5120; // Slave start fail (Motion state가 "Wait for Pulsar Input"으로 변하지 않는다.
        public const int cmERR_SPEED_RANGE_OVER = -5130;
        public const int cmERR_INVALID_SPEED_SET = -5140; // Speed setting value is not valid
        public const int cmERR_INVALID_IXMAP = -5150; // Invalid interpolation map index
        public const int cmERR_INVALID_LMMAP = -5160; // Invalid List-Motion Map 
        public const int cmERR_MOT_SEQ_SKIPPED = -5170; // Motion command is skipped because the axis is already running.  
        public const int cmERR_CMPIX_INVALID_MAP = -5180; // Interpolated position compare output map is not valid
        public const int cmERR_INVALID_ARC_POS = -5190; // Position data for circular interpolation is invalid
        public const int cmERR_LMX_ADD_ITEM_FAIL = -5200; // failed to add an job item to "extend list motion"
        public const int cmERR_LMX_IS_NOT_ACTIVE = -5300; // Extended ListMotion' is not active.
        public const int cmERR_UNKNOWN = -9999;

        public const int ERR_BUF_SIZE = 100;
        // Motion Chip Main-space Address //
        public enum TMCWAddr { COMW, OTPW, BUF0, BUF1 };
        public enum TMCRAddr { MSTSW, SSTSW };

        // Motion Chip Registers //
        public enum TMCRegister
        {
            PRMV, PRFL, PRFH, PRUR, PRDR, PRMG, PRDP, PRMD, PRIP, PRUS, PRDS, PRCP5, PRCI,
            RMV = 16, RFL, RFH, RUR, RDR, RMG, RDP, RMD, RIP, RUS, RDS, RFA, RENV1, RENV2, RENV3, RENV4, RENV5, RENV6, RENV7,
            RCUN1 = 35, RCUN2, RCUN3, RCUN4, RCMP1, RCMP2, RCMP3, RCMP4, RCMP5, RIRQ, RLTC1, RLTC2, RLTC3, RLTC4,
            RSTS = 49, REST, RIST, RPLS, RSPD, PSDC,
            RCI = 60, RCIC,
            RIPS = 63
        };

        // 0. Common

        public enum PosItem
        {
            CommandPosition,
            FeedbackPosition,
            CommandSpeed,
            FeedbackSpeed,
        }
        public enum MASKBIT { LOWLIMIT = 31, HIGHLIMIT = 63 }; // cmmIxMapAxes 의 MapMask 구분(하위32비트 and 상위 32비트)
        public enum PGTYPE { POSITION, VELOCITY }; // MotionStatus 창에서 Vertical Progress 의 타입.

        //public const int CMD_THREAD_INTERVAL1 = 1;
        public const int CMD_THREAD_INTERVAL0 = 0;
        public const int CMD_THREAD_INTERVAL100 = 100;

        // 1. Single Axis Move 관련
        // Interval 변수
        public const int MIN_INT = 0;
        public const int INIT_INT = 1;

        public const int MIN_CHANNEL = 0;
        public const int INIT_CHANNEL = 0;

        // Distance numeric 변수
        public const int MIN_DIST = -99999999;
        public const int MAX_DIST = 99999999;
        public const int INIT_DIST0 = 0;
        public const int INIT_DIST10000 = 10000;

        public const int MIN_WORKSPD = 0;
        public const int INIT_WORKSPD10000 = 10000;
        public const int MAX_WORKSPD = 99999999;

        // MAP
        public enum MAP { MAP0, MAP1, MAP2, MAP3, MAP4, MAP5, MAP6, MAP7 };

        public enum SPDMODE { MODE_CONST, MODE_TRPZDL, MODE_SCURVE };
        public enum OPMODE { MODE_VEL, MODE_RELPOS, MODE_ABSPOS };
        public enum DIR { MODE_CW, MODE_CCW };
        public enum MOTIONTYPE
        {
            SXMOVE, MXMOVE, IXMOVE, HOMERETURN, MANUALPULSAR, EXTERNALSWITCH,
            POSITIONCOMPARE, LISTEDMOTION, NONE
        };

        public enum SERVO { NOTDEFINED = -100, SERVOFAULT = -1, SERVOOFF, SERVOON };

        // Motion Status
        public enum RESET_AXIS { RESETDONE = -1, FIRSTCH, SECONDCH, THIRDCH, FORTHCH, RESETALL = 99 };

        // Master/Slave
        public enum MP_OPMODE { HOME_MOVE, VEL_MOVE, REL_POS, ABS_POS };
        public enum HOME_TYPE { COMMAND, ORG };
        public enum SLAVE_STATE { ERROR = -1, UNREGISTERED, REGISTERED };

        public enum EXSW_OPMODE { VEL_MOVE, REL_POS };

        // position compare
        public enum CMP_PNTMODE { ONE_PNT, REGULAR_PNT, VOLUNTARY_PNT };

        // 2. Multi Axis Move 관련

        // 3. Operation Form 관련
        public enum OPGROUPBARITEM
        {
            GBISXMOVE, GBIMXMOVE, GBIHOMERETURN, GBIIXMOVE, GBIMANPUL,
            GBIEXTSW, GBILSTMOTION, GBIPOSCOMP
        };

        // 4. Listed Motion
        //public enum LM_OPIDX
        //{
        //    CAT_SX, SX_SETSPEEDPTN, SX_MOVE, SX_MOVETO = 3,
        //    CAT_IX, IX_MAPAXES, IX_SETSPEEDPTN, IX_SETSPEEDPTNV, IX_LINE, IX_LINETO, IX_ARCA, IX_ARCP, IX_ARCATO, IX_ARCPTO = 13,
        //    CAT_ONLY4MACROMODE, DO_PUTONE, DO_PUTALL, DELAY = 17
        //};

        public enum LmFunctionList
        {
            SxSetSpeedPattern = 1,
            SxMove,
            SxMoveTo,
            SxOptSetIniSpeed,

            IxMapAxes = 6,
            IxSetSpeedPattern,
            IxLine,
            IxLineTo,
            IxArcA,
            IxArcATo,
            IxArcP,
            IxArcPTo,
            IxArc3P,
            IxArc3PTo,

            DoPutOne = 17,
        }


        public const int MAX_CMDLIST = 999;


        //----- Definitions for Motion -------------------------------------------//

        public enum Direction 
        { 
            DIR_N, 
            DIR_P 
        }; 

        public enum MioProperty
        {
            ALM_Logic, 
            ALM_Mode, 
            CMP_Logic, 
            DR_Logic,
            EL_Logic,
            EL_Mode, 
            ERC_Logic, 
            ERC_OutAtHome, 
            EZ_Logic,
            INP_Enable,
            INP_Logic, 
            LTC_Logic, 
            LTC_Ltc2Src, 
            ORG_Logic,
            SD_Enable,
            SD_Logic, 
            SD_Latch, 
            SD_Mode, 
            STA_Mode, 
            STA_TrgType,
            STP_Mode, /* End of 1bit values */
            CLR_CntrSel,
            CLR_SigType, 
            CMP_PulseWidth, 
            ERC_OnTime
        };

        public enum MioPropId
        {
            ALM_LOGIC, 
            ALM_MODE, 
            CMP_LOGIC, 
            DR_LOGIC, 
            EL_LOGIC, 
            EL_MODE = 5,
            ERC_LOGIC, 
            ERC_OUT, 
            EZ_LOGIC, 
            INP_EN, 
            INP_LOGIC = 10,
            LTC_LOGIC,
            LTC_LTC2SRC, 
            ORG_LOGIC, 
            SD_EN,
            SD_LOGIC = 15,
            SD_LATCH, 
            SD_MODE, 
            STA_MODE,
            STA_TRG,
            STP_MODE = 20, 
            CLR_CNTR, 
            CLR_SIGTYPE, 
            CMP_PWIDTH, 
            ERC_ONTIME,
            SVON_LOGIC
        };

        public enum _TCmMioPropIdEx
        {
            cmMPID_ALM_LOGIC, cmMPID_ALM_MODE, cmMPID_CMP_LOGIC, cmMPID_DR_LOGIC, cmMPID_EL_LOGIC, cmMPID_EL_MODE,
            cmMPID_ERC_LOGIC, cmMPID_ERC_OUT, cmMPID_EZ_LOGIC, cmMPID_INP_EN, cmMPID_INP_LOGIC, cmMPID_LTC_LOGIC,
            cmMPID_LTC_LTC2SRC, cmMPID_ORG_LOGIC, cmMPID_SD_EN, cmMPID_SD_LOGIC, cmMPID_SD_LATCH, cmMPID_SD_MODE,
            cmMPID_STA_MODE, cmMPID_STA_TRG, cmMPID_STP_MODE, cmMPID_CLR_CNTR, cmMPID_CLR_SIGTYPE, cmMPID_CMP_PWIDTH,
            cmMPID_ERC_ONTIME, cmMPID_SVON_LOGIC, cmMPID_ERC_OUT_EL, cmMPID_CNT_D_SRC, cmMPID_CNT_G_SRC, cmMPID_HOME_ESC_DIS,
            cmMPID_LTC_TRGSRC, cmMPID_EN_ARDP
        };

        public enum _TCmMioState
        {
            RDY, ALM, ELP, ELN, ORG,
            DIR, RSV1, PCS, ERC, EZ,
            CLR, LTC, SD, INP, DRP,
            DRN, STA, STP, RSV2 = 18, RSV3
        };

        public enum _TCmSigLogic { cmLOGIC_A = 0, cmLOGIC_B = 1 };
        public enum _TCmBool { cmFALSE, cmTRUE };
        public enum _TCmAxis { cmX1, cmY1, cmZ1, cmU1, cmX2, cmY2, cmZ2, cmU2 };
        public enum _TCmAxisMask
        {
            cmX1_MASK = 0x1, cmY1_MASK = 0x2, cmZ1_MASK = 0x4, cmU1_MASK = 0x8,
            cmX2_MASK = 0x10, cmY2_MASK = 0x20, cmZ2_MASK = 0x40, cmU2_MASK = 0x80
        };
        public enum _TCmInMode { cmIMODE_AB1X, cmIMODE_AB2X, cmIMODE_AB4X, cmIMODE_CWCCW };
        public enum _TCmOutMode
        {
            cmOMODE_PDIR0, cmOMODE_PDIR1, cmOMODE_PDIR2, cmOMODE_PDIR3,
            cmOMODE_CWCCW0, cmOMODE_CWCCW1
        };
        public enum _TCmSpeedMode { cmSMODE_KEEP = -1/* Keep previous setting*/, cmSMODE_C = 0, cmSMODE_T, cmSMODE_S };
        public enum _TCmDir { cmDIR_N, cmDIR_P };
        public enum _TCmArcDir { cmARC_CW, cmARC_CCW };
        public enum _TCmCntr
        {
            cmCNT_COMM/*Command*/, cmCNT_FEED/*Feedback*/, cmCNT_DEV/*Deviation*/,
            cmCNT_GEN/*General*/, cmCNT_REM/*Remained*/
        };

        public enum _TCmMotionState
        {
            cmMST_STOP, cmMST_WAIT_DR, cmMST_WAIT_STA, cmMST_WAIT_INSYNC,
            cmMST_WAIT_OTHER, cmMST_WAIT_ERC, cmMST_WAIT_DIR, cmMST_RESERVED1, cmMST_WAIT_PLSR,
            cmMST_IN_RVSSPD, cmMST_IN_INISPD, cmMST_IN_ACC, cmMST_IN_WORKSPD, cmMST_IN_DEC,
            cmMST_WAIT_INP, cmMST_SPARE0
        };

        //------------------------------------------------------------------------//
        // Compare Method //
        public enum _TCmCmpMethod
        {
            cmDISABLE,
            cmEQ_BIDIR,
            cmEQ_PDIR,
            cmEQ_NDIR,
            cmLESS/*Cnt<Data*/,
            cmGREATER/*Cnt>Data*/
        };

        // Action when general comparator met the condition //
        public enum _TCmCmpAction
        {
            cmEVNT_ONLY, cmEVNT_IS, cmEVNT_DS, cmEVNT_SPDCHG
        };

        // Backlash/Slip correction mode //
        public enum _TCmCorrMode
        {
            cmCORR_DIS, // Disable correction 
            cmCORR_BACK, // Backlash correction mode 
            cmCORR_SLIP // Slip correction mode
        };

        public enum _TCmExtOptionId
        {
            cmEXOPT_SET_USE_PREREG
        };

        // Interrupt Handler Type //
        public enum _TCmIntHandlerType
        {
            cmIHT_MESSAGE, cmIHT_EVENT, cmIHT_CALLBACK
        };

        // Interrupt Handler Type //
        public enum _TCmStringID
        {
            cmSTR_AXIS_NAME, cmSTR_DIST_UNIT, cmSTR_SPEED_UNIT
        };

        public enum _TComiVarType { VT_SHORT, VT_FLOAT, VT_DOUBLE };

        // Interrupt Handler Type //
        public enum TCmIntHandlerType
        {
            cmIHT_MESSAGE, cmIHT_EVENT, cmIHT_CALLBACK
        };

        // SetFilterAB의 대상 //
        public enum _TCmABFilter { cmAB_ENC, cmAB_PULSAR };

        // TCmLmxStsId: cmmLmxGetSts() 함수를 통해서 읽어올 status ID 값의 정의
        public enum _TCmLmxStsId
        {
            cmLMX_STARTED, // Lmx 기능이 활성화 되었는지를 나타내는 status 
            cmLMX_BUSY, // Lmx가 현재 실제로 이송을 진행 중인지를 나타내는 status
            cmLMX_FREE_SPACE, // Lmx 버퍼의 여유 공간. 반환되는 값은 바이트 단위가 아니라 등록할 수 있는 아이템 수이다.
            cmLMX_RUN_ITEM_NO, // 현재 이송되고 있거나 마지막 이송된 Item의 번호.
            cmLMX_RUN_ITEM_ID, // 현재 이송되고 있거나 마지막 이송된 Item의 아이디값(아이디는 cmmLmxSetNextItemId() 함수를 통해서 설정한다)
            cmLMX_LAST_SET_ITEM_ID, // 마지막으로 예약된 Item의 아이디값.
            //cmLMX_LAST_SET_ITEM_NO  // 마지막으로 예약된 Item의 아이디값[향후에 추가하자].
        };

        ////////////////////////////////////////////////////////////////////////////////////////////
        // TCmLmxSeqMode: 이송명령을 예약하려 하는데 LMX Buffer가 이미 꽉 차있는 경우에 어떻게 처리
        // 할지에 대한 모드의 아이디.
        // -. cmLMX_SEQM_SKIP_RUN: 'cmERR_LMX_ADD_ITEM_FAIL'에러를 발생하고 함수는 바로 반환된다.
        // -. cmLMX_SEQM_WAIT_RUN: LMX 버퍼에 free space가 생길 때까지 대기하고 있다가 free space가
        //    생기면 예약하고 함수가 반환된다.

        [StructLayout(LayoutKind.Sequential)]
        public struct TMotDevInfo
        {
            public ushort deviceID;
            public ushort devInstance;
            public short slot;
            public ushort numAxes;
            public ushort iniAxis;
            public ushort diNum;
            public ushort doNum;
            private readonly IntPtr devClass;
        }

        public struct TMotDevEnum
        {
            public ushort numDevs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CMM_MAX_NUM_MOT_DEV)]
            public TMotDevInfo[] Dev;
        }

        public struct TMotDevMap
        {
            public ushort numDevs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CMM_MAX_NUM_MOT_DEV)]
            public TMotDevInfo[] Dev;
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct TDioDevInfo
        {
            public ushort deviceID;
            public ushort devInstance;
            public short slot;
            public ushort diNum;
            public ushort diIniChan;
            public ushort doNum;
            public ushort doIniChan;
            public bool bMotionDevice;
            private readonly IntPtr handle;
        }

        public struct TDioDevEnum
        {
            public ushort numDevs;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CMM_MAX_NUM_MOT_DEV)]
            public TDioDevInfo[] Dev;
        }

        public struct TDioDevMap
        {
            public ushort numDevs;
            public ushort numAllDiChan;
            public ushort numAllDoChan;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CMM_MAX_NUM_MOT_DEV)]
            public TDioDevInfo[] Dev;
        }

        public delegate void CallbackFunc(IntPtr lParam);
        public const string dll = "Cmmsdk.dll";

        //====================== General FUNCTIONS ====================================================//
        // 1. cmmGnDeviceLoad
        [DllImport(dll, EntryPoint = "cmmGnDeviceLoad")]
        public static extern unsafe int cmmGnDeviceLoad(
            [MarshalAs(UnmanagedType.I4)] int IsResetDevice, 
            [MarshalAs(UnmanagedType.I4)] ref int NumAxes);

        // 2. cmmGnDeviceUnload
        [DllImport(dll, EntryPoint = "cmmGnDeviceUnload")]
        public static extern unsafe int cmmGnDeviceUnload();

        // 3. cmmGnDeviceIsLoaded
        [DllImport(dll, EntryPoint = "cmmGnDeviceIsLoaded")]
        public static extern unsafe int cmmGnDeviceIsLoaded(
            [MarshalAs(UnmanagedType.I4)] ref int IsLoaded);

        //[DllImport(dll, EntryPoint = "cmmUnloadDll")]
        //public static extern unsafe void cmmUnloadDll();


        // 4. cmmGnDeviceReset
        [DllImport(dll, EntryPoint = "cmmGnDeviceReset")]
        public static extern unsafe int cmmGnDeviceReset();

        // 5. cmmGnInitFromFile
        [DllImport(dll, EntryPoint = "cmmGnInitFromFile", CharSet = CharSet.Unicode, BestFitMapping = false)]
        public static extern unsafe int cmmGnInitFromFile(
            [MarshalAs(UnmanagedType.LPStr)] string szCmeFile);

        // 6. cmmGnInitFromFile_MapOnly
        [DllImport(dll, EntryPoint = "cmmGnInitFromFile_MapOnly", CharSet = CharSet.Unicode, BestFitMapping = false)]
        public static extern unsafe int cmmGnInitFromFile_MapOnly(
            [MarshalAs(UnmanagedType.LPStr)] string szCmeFile,
            [MarshalAs(UnmanagedType.I4)] int MapType);

        // 7. cmmGnSetServoOn
        [DllImport(dll, EntryPoint = "cmmGnSetServoOn")]
        public static extern unsafe int cmmGnSetServoOn(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Enable);

        // 8. cmmGnGetServoOn
        [DllImport(dll, EntryPoint = "cmmGnGetServoOn")]
        public static extern unsafe int cmmGnGetServoOn(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int Enable);

        // 9. cmmGnSetAlarmRes
        [DllImport(dll, EntryPoint = "cmmGnSetAlarmRes")]
        public static extern unsafe int cmmGnSetAlarmRes(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsOn);

        // 10. cmmGnGetAlarmRes
        [DllImport(dll, EntryPoint = "cmmGnGetAlarmRes")]
        public static extern unsafe int cmmGnGetAlarmRes(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsOn);

        // 11. cmmGnPulseAlarmRes
        [DllImport(dll, EntryPoint = "cmmGnPulseAlarmRes")]
        public static extern unsafe int cmmGnPulseAlarmRes(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsOnPulse,
            [MarshalAs(UnmanagedType.I4)] int dwDuration,
            [MarshalAs(UnmanagedType.I4)] int IsWaitPulseEnd);

        // 12. cmmGnSetSimulMode
        [DllImport(dll, EntryPoint = "cmmGnSetSimulMode")]
        public static extern unsafe int cmmGnSetSimulMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsSimulMode);

        // 13. cmmGnGetSimulMode
        [DllImport(dll, EntryPoint = "cmmGnGetSimulMode")]
        public static extern unsafe int cmmGnGetSimulMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsSimulMode);

        // 14. cmmGnPutpublicSTA
        [DllImport(dll, EntryPoint = "cmmGnPutpublicSTA")]
        public static extern unsafe int cmmGnPutpublicSTA(
            [MarshalAs(UnmanagedType.I4)] int AxesMask);

        // 15. cmmGnSetEmergency
        [DllImport(dll, EntryPoint = "cmmGnSetEmergency")]
        public static extern unsafe int cmmGnSetEmergency(
            [MarshalAs(UnmanagedType.I4)] int IsEnable, 
            [MarshalAs(UnmanagedType.I4)] int IsDecStop);

        // 16. cmmGnGetEmergency
        [DllImport(dll, EntryPoint = "cmmGnGetEmergency")]
        public static extern unsafe int cmmGnGetEmergency(
            [MarshalAs(UnmanagedType.I4)] ref int IsEnabled);

        // 17. cmmGnBitShift
        [DllImport(dll, EntryPoint = "cmmGnBitShift")]
        public static extern unsafe int cmmGnBitShift(
            [MarshalAs(UnmanagedType.I4)] int Value,
            [MarshalAs(UnmanagedType.I4)] int ShiftOption,
            [MarshalAs(UnmanagedType.I4)] ref int Result);


        //====================== Configuration FUNCTIONS ==============================================//
        // 1. cmmCfgSetMioProperty
        [DllImport(dll, EntryPoint = "cmmCfgSetMioProperty")]
        public static extern unsafe int cmmCfgSetMioProperty(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int PropId, 
            [MarshalAs(UnmanagedType.I4)] int PropVal);

        // 2. cmmCfgGetMioProperty
        [DllImport(dll, EntryPoint = "cmmCfgGetMioProperty")]
        public static extern unsafe int cmmCfgGetMioProperty(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int PropId,
            [MarshalAs(UnmanagedType.I4)] ref int PropVal);

        // 3. cmmCfgSetFilter
        [DllImport(dll, EntryPoint = "cmmCfgSetFilter")]
        public static extern unsafe int cmmCfgSetFilter(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        // 4. cmmCfgGetFilter
        [DllImport(dll, EntryPoint = "cmmCfgGetFilter")]
        public static extern unsafe int cmmCfgGetFilter(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsEnabled);

        // 5. cmmCfgSetFilterAB
        [DllImport(dll, EntryPoint = "cmmCfgSetFilterAB")]
        public static extern unsafe int cmmCfgSetFilterAB(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int Target, 
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        // 6. cmmCfgGetFilterAB
        [DllImport(dll, EntryPoint = "cmmCfgGetFilterAB")]
        public static extern unsafe int cmmCfgGetFilterAB(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Target,
            [MarshalAs(UnmanagedType.I4)] ref int IsEnabled);

        // 7. cmmCfgSetInMode
        [DllImport(dll, EntryPoint = "cmmCfgSetInMode")]
        public static extern unsafe int cmmCfgSetInMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int InputMode,
            [MarshalAs(UnmanagedType.I4)] int IsReverse);

        // 8. cmmCfgGetInMode
        [DllImport(dll, EntryPoint = "cmmCfgGetInMode")]
        public static extern unsafe int cmmCfgGetInMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int InputMode,
            [MarshalAs(UnmanagedType.I4)] ref int IsReverse);

        // 9. cmmCfgSetOutMode
        [DllImport(dll, EntryPoint = "cmmCfgSetOutMode")]
        public static extern unsafe int cmmCfgSetOutMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int OutputMode);

        // 10. cmmCfgGetOutMode
        [DllImport(dll, EntryPoint = "cmmCfgGetOutMode")]
        public static extern unsafe int cmmCfgGetOutMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int OutputMode);

        // 9. cmmCfgSetCtrlMode
        [DllImport(dll, EntryPoint = "cmmCfgSetCtrlMode")]
        public static extern unsafe int cmmCfgSetCtrlMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int CtrlMode);

        // 10. cmmCfgGetCtrlMode
        [DllImport(dll, EntryPoint = "cmmCfgGetCtrlMode")]
        public static extern unsafe int cmmCfgGetCtrlMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int CtrlMode);

        // 11. cmmCfgSetInOutRatio
        [DllImport(dll, EntryPoint = "cmmCfgSetInOutRatio")]
        public static extern unsafe int cmmCfgSetInOutRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Ratio);

        // 12. cmmCfgGetInOutRatio
        [DllImport(dll, EntryPoint = "cmmCfgGetInOutRatio")]
        public static extern unsafe int cmmCfgGetInOutRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double Ratio);

        // 13. cmmCfgSetUnitDist
        [DllImport(dll, EntryPoint = "cmmCfgSetUnitDist")]
        public static extern unsafe int cmmCfgSetUnitDist(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double UnitDist);

        // 14. cmmcfgGetUnitDist
        [DllImport(dll, EntryPoint = "cmmCfgGetUnitDist")]
        public static extern unsafe int cmmCfgGetUnitDist(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double UnitDist);

        // 15. cmmCfgSetUnitSpeed
        [DllImport(dll, EntryPoint = "cmmCfgSetUnitSpeed")]
        public static extern unsafe int cmmCfgSetUnitSpeed(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double UnitSpeed);

        // 16. cmmCfgGetUnitSpeed
        [DllImport(dll, EntryPoint = "cmmCfgGetUnitSpeed")]
        public static extern unsafe int cmmCfgGetUnitSpeed(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double UnitSpeed);

        // 17. cmmCfgSetSpeedRange
        [DllImport(dll, EntryPoint = "cmmCfgSetSpeedRange")]
        public static extern unsafe int cmmCfgSetSpeedRange(
            
            [MarshalAs(UnmanagedType.I4)] int Axis, [MarshalAs(UnmanagedType.R8)] double MaxPPS);

        // 18. cmmCfgGetSpeedRange
        [DllImport(dll, EntryPoint = "cmmCfgGetSpeedRange")]
        public static extern unsafe int cmmCfgGetSpeedRange(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double MinPPS,
            [MarshalAs(UnmanagedType.R8)] ref double MaxPPS);

        // 19. cmmCfgSetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmCfgSetSpeedPattern")]
        public static extern unsafe int cmmCfgSetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double WorkSpeed,
            [MarshalAs(UnmanagedType.R8)] double Accel,
            [MarshalAs(UnmanagedType.R8)] double Decel);

        // 20. cmmCfgGetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmCfgGetSpeedPattern")]
        public static extern unsafe int cmmCfgGetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double WorkSpeed, 
            [MarshalAs(UnmanagedType.R8)] ref double Accel,
            [MarshalAs(UnmanagedType.R8)] ref double Decel);

        // 19. cmmCfgSetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmCfgSetSpeedPattern_T")]
        public static extern unsafe int cmmCfgSetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double WorkSpeed,
            [MarshalAs(UnmanagedType.R8)] double AccelTime,
            [MarshalAs(UnmanagedType.R8)] double DecelTime); // <V5.0.4.0>

        // 20. cmmCfgGetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmCfgGetSpeedPattern_T")]
        public static extern unsafe int cmmCfgGetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double WorkSpeed,
            [MarshalAs(UnmanagedType.R8)] ref double AccelTime,
            [MarshalAs(UnmanagedType.R8)] ref double DecelTime); // <V5.0.4.0>

        // 21. cmmCfgSetVelCorrRatio
        [DllImport(dll, EntryPoint = "cmmCfgSetVelCorrRatio")]
        public static extern unsafe int cmmCfgSetVelCorrRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double CorrRatio);

        // 22. cmmCfgGetVelCorrRatio
        [DllImport(dll, EntryPoint = "cmmCfgGetVelCorrRatio")]
        public static extern unsafe int cmmCfgGetVelCorrRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double CorrRatio);

        // 23. cmmCfgSetMinCorrVel
        [DllImport(dll, EntryPoint = "cmmCfgSetMinCorrVel")]
        public static extern unsafe int cmmCfgSetMinCorrVel(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double MinVel); // <V5.0.4.0>

        // 24. cmmCfgGetMinCorrVel
        [DllImport(dll, EntryPoint = "cmmCfgGetMinCorrVel")]
        public static extern unsafe int cmmCfgGetMinCorrVel(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double MinVel); // <V5.0.4.0>

        // 25. cmmCfgSetMinAccTime
        [DllImport(dll, EntryPoint = "cmmCfgSetMinAccTime")]
        public static extern unsafe int cmmCfgSetMinAccTime(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double MinAccT,
            [MarshalAs(UnmanagedType.R8)] double MinDecT); // <V5.0.4.0>

        // 26. cmmCfgGetMinAccTime
        [DllImport(dll, EntryPoint = "cmmCfgGetMinAccTime")]
        public static extern unsafe int cmmCfgGetMinAccTime(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double MinAccT,
            [MarshalAs(UnmanagedType.R8)] ref double MinDecT); // <V5.0.4.0>

        // 27. cmmCfgSetActSpdCheck
        [DllImport(dll, EntryPoint = "cmmCfgSetActSpdCheck")]
        public static extern unsafe int cmmCfgSetActSpdCheck(
            [MarshalAs(UnmanagedType.I4)] int IsEnable,
            [MarshalAs(UnmanagedType.I4)] int Interval);

        // 28. cmmCfgGetActSpdCheck
        [DllImport(dll, EntryPoint = "cmmCfgGetActSpdCheck")]
        public static extern unsafe int cmmCfgGetActSpdCheck(
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable, [MarshalAs(UnmanagedType.I4)] ref int Interval);

        // 29. cmmCfgSetSoftLimit
        [DllImport(dll, EntryPoint = "cmmCfgSetSoftLimit")]
        public static extern unsafe int cmmCfgSetSoftLimit(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int IsEnable,
            [MarshalAs(UnmanagedType.R8)] double LimitN,
            [MarshalAs(UnmanagedType.R8)] double LimitP);

        // 30. cmmCfgGetSoftLimit
        [DllImport(dll, EntryPoint = "cmmCfgGetSoftLimit")]
        public static extern unsafe int cmmCfgGetSoftLimit(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable,
            [MarshalAs(UnmanagedType.R8)] ref double LimitN, 
            [MarshalAs(UnmanagedType.R8)] ref double LimitP);

        // 31. cmmCfgSetRingCntr
        [DllImport(dll, EntryPoint = "cmmCfgSetRingCntr")]
        public static extern unsafe int cmmCfgSetRingCntr(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int TargCntr,
            [MarshalAs(UnmanagedType.I4)] int IsEnable, 
            [MarshalAs(UnmanagedType.R8)] double CntMax);

        // 32. cmmCfgGetRingCntr
        [DllImport(dll, EntryPoint = "cmmCfgGetRingCntr")]
        public static extern unsafe int cmmCfgGetRingCntr(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int TargCntr,
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable,
            [MarshalAs(UnmanagedType.R8)] ref double CntMax);

        // 33. cmmCfgSetSeqMode
        [DllImport(dll, EntryPoint = "cmmCfgSetSeqMode")]
        public static extern unsafe int cmmCfgSetSeqMode(
            [MarshalAs(UnmanagedType.I4)] int SeqMode);

        // 34. cmmCfgGetSeqMode
        [DllImport(dll, EntryPoint = "cmmCfgGetSeqMode")]
        public static extern unsafe int cmmCfgGetSeqMode(
            [MarshalAs(UnmanagedType.I4)] ref int SeqMode);

        // 35. cmmCfgSetManExtLimit
        [DllImport(dll, EntryPoint = "cmmCfgSetManExtLimit")]
        public static extern unsafe int cmmCfgSetManExtLimit(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsSetELP,
            [MarshalAs(UnmanagedType.I4)] int IsEnable,
            [MarshalAs(UnmanagedType.I4)] int ManState);

        // 36. cmmCfgGetManExtLimit
        [DllImport(dll, EntryPoint = "cmmCfgGetManExtLimit")]
        public static extern unsafe int cmmCfgGetManExtLimit(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsSetELP,
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable,
            [MarshalAs(UnmanagedType.I4)] ref int ManState);

        // CMM_EXTERN long (WINAPI *cmmCfgSetActSpdFilter)	(long Axis, long IsEnable, double fCutOffFreq);
        [DllImport(dll, EntryPoint = "cmmCfgSetActSpdFilter")]
        public static extern unsafe int cmmCfgSetActSpdFilter(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsEnable,
            [MarshalAs(UnmanagedType.R8)] double fCutOffFreq);

        //CMM_EXTERN long (WINAPI *cmmCfgSetLowSpdAlgorithm)	(long Axis, long Enable);
        [DllImport(dll, EntryPoint = "cmmCfgSetLowSpdAlgorithm")]
        public static extern unsafe int cmmCfgSetLowSpdAlgorithm(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        //CMM_EXTERN long (WINAPI *cmmCfgGetLowSpdAlgorithm)	(long Axis, long *Enabled);
        [DllImport(dll, EntryPoint = "cmmCfgGetLowSpdAlgorithm")]
        public static extern unsafe int cmmCfgGetLowSpdAlgorithm(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable);



        //====================== HOME-RETURN FUNCTIONS ================================================//
        // 1. cmmHomeSetConfig
        [DllImport(dll, EntryPoint = "cmmHomeSetConfig")]
        public static extern unsafe int cmmHomeSetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int HomeMode,
            [MarshalAs(UnmanagedType.I4)] int EzCount, 
            [MarshalAs(UnmanagedType.R8)] double EscDist,
            [MarshalAs(UnmanagedType.R8)] double Offset);

        // 2. cmmHomeGetConfig
        [DllImport(dll, EntryPoint = "cmmHomeGetConfig")]
        public static extern unsafe int cmmHomeGetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int HomeMode,
            [MarshalAs(UnmanagedType.I4)] ref int EzCount, 
            [MarshalAs(UnmanagedType.R8)] ref double EscDist, 
            [MarshalAs(UnmanagedType.R8)] ref double Offset);

        // 3. cmmHomeSetPosClrMode
        [DllImport(dll, EntryPoint = "cmmHomeSetPosClrMode")]
        public static extern unsafe int cmmHomeSetPosClrMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int PosClrMode);

        // 4. cmmHomeGetPosClrMode
        [DllImport(dll, EntryPoint = "cmmHomeGetPosClrMode")]
        public static extern unsafe int cmmHomeGetPosClrMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int PosClrMode);

        // 5. cmmHomeSetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmHomeSetSpeedPattern")]
        public static extern unsafe int cmmHomeSetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double Vel, 
            [MarshalAs(UnmanagedType.R8)] double Accel,
            [MarshalAs(UnmanagedType.R8)] double Decel, 
            [MarshalAs(UnmanagedType.R8)] double RevVel);

        // 6. cmmHomeGetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmHomeGetSpeedPattern")]
        public static extern unsafe int cmmHomeGetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double Vel,
            [MarshalAs(UnmanagedType.R8)] ref double Accel,
            [MarshalAs(UnmanagedType.R8)] ref double Decel, 
            [MarshalAs(UnmanagedType.R8)] ref double RevVel);

        // 7. cmmHomeSetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmHomeSetSpeedPattern_T")]
        public static extern unsafe int cmmHomeSetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double Vel,
            [MarshalAs(UnmanagedType.R8)] double AccelTime,
            [MarshalAs(UnmanagedType.R8)] double DecelTime,
            [MarshalAs(UnmanagedType.R8)] double RevVel);

        // 8. cmmHomeGetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmHomeGetSpeedPattern_T")]
        public static extern unsafe int cmmHomeGetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double Vel,
            [MarshalAs(UnmanagedType.R8)] ref double AccelTime,
            [MarshalAs(UnmanagedType.R8)] ref double DecelTime, 
            [MarshalAs(UnmanagedType.R8)] ref double RevVel);

        // 9. cmmHomeMoveStart
        [DllImport(dll, EntryPoint = "cmmHomeMoveStart")]
        public static extern unsafe int cmmHomeMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Direction);

        // 10. cmmHomeMove
        [DllImport(dll, EntryPoint = "cmmHomeMove")]
        public static extern unsafe int cmmHomeMove(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Direction,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 11. cmmHomeMoveAll
        [DllImport(dll, EntryPoint = "cmmHomeMoveAll")]
        public static extern unsafe int cmmHomeMoveAll(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] DirList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);
        //LPArray, ArraySubType = UnmanagedType.R8)] double[] DistList

        // 12. cmmHomeMoveAllStart
        [DllImport(dll, EntryPoint = "cmmHomeMoveAllStart")]
        public static extern unsafe int cmmHomeMoveAllStart(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] DirList);

        // 13. cmmHomeGetSuccess
        [DllImport(dll, EntryPoint = "cmmHomeGetSuccess")]
        public static extern unsafe int cmmHomeGetSuccess(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsSuccess);

        // 14. cmmHomeSetSuccess
        [DllImport(dll, EntryPoint = "cmmHomeSetSuccess")]
        public static extern unsafe int cmmHomeSetSuccess(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int IsSuccess);

        // 15.cmmHomeIsBusy
        [DllImport(dll, EntryPoint = "cmmHomeIsBusy")]
        public static extern unsafe int cmmHomeIsBusy(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsBusy);

        // 16. cmmHomeWaitDone
        [DllImport(dll, EntryPoint = "cmmHomeWaitDone")]
        public static extern unsafe int cmmHomeWaitDone(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);


        //====================== Single Axis Move FUNCTIONS ===========================================//
        // 1. cmmSxSetSpeedRatio
        [DllImport(dll, EntryPoint = "cmmSxSetSpeedRatio")]
        public static extern unsafe int cmmSxSetSpeedRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double VelRatio,
            [MarshalAs(UnmanagedType.R8)] double AccRatio, 
            [MarshalAs(UnmanagedType.R8)] double DecRatio);

        // 2. cmmSxGetSpeedRatio
        [DllImport(dll, EntryPoint = "cmmSxGetSpeedRatio")]
        public static extern unsafe int cmmSxGetSpeedRatio(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double VelRatio, 
            [MarshalAs(UnmanagedType.R8)] ref double AccRatio, 
            [MarshalAs(UnmanagedType.R8)] ref double DecRatio);

        // 3. cmmSxMoveStart
        [DllImport(dll, EntryPoint = "cmmSxMoveStart")]
        public static extern unsafe int cmmSxMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Distance);

        // 4. cmmSxMove
        [DllImport(dll, EntryPoint = "cmmSxMove")]
        public static extern unsafe int cmmSxMove(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Distance,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 5. cmmSxMoveToStart
        [DllImport(dll, EntryPoint = "cmmSxMoveToStart")]
        public static extern unsafe int cmmSxMoveToStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Position);

        // 6. cmmSxMoveTo
        [DllImport(dll, EntryPoint = "cmmSxMoveTo")]
        public static extern unsafe int cmmSxMoveTo(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double Position,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 7. cmmSxVMoveStart
        [DllImport(dll, EntryPoint = "cmmSxVMoveStart")]
        public static extern unsafe int cmmSxVMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Dir);

        // 8. cmmSxStop
        [DllImport(dll, EntryPoint = "cmmSxStop")]
        public static extern unsafe int cmmSxStop(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsWaitComplete,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 9. cmmSxStopEmg
        [DllImport(dll, EntryPoint = "cmmSxStopEmg")]
        public static extern unsafe int cmmSxStopEmg(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 10. cmmSxIsDone
        [DllImport(dll, EntryPoint = "cmmSxIsDone")]
        public static extern unsafe int cmmSxIsDone(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsDone);

        // 11. cmmSxWaitDone
        [DllImport(dll, EntryPoint = "cmmSxWaitDone")]
        public static extern unsafe int cmmSxWaitDone(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 12. cmmSxGetTargetPos
        [DllImport(dll, EntryPoint = "cmmSxGetTargetPos")]
        public static extern unsafe int cmmSxGetTargetPos(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double Position);

        // 13. cmmSxOptSetIniSpeed
        [DllImport(dll, EntryPoint = "cmmSxOptSetIniSpeed")]
        public static extern unsafe int cmmSxOptSetIniSpeed(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double IniSpeed);

        // 14. cmmSxOptGetIniSpeed
        [DllImport(dll, EntryPoint = "cmmSxOptGetIniSpeed")]
        public static extern unsafe int cmmSxOptGetIniSpeed(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double IniSpeed);

        // 15. cmmSxSetCorrection
        [DllImport(dll, EntryPoint = "cmmSxSetCorrection")]
        public static extern unsafe int cmmSxSetCorrection(
            [MarshalAs(UnmanagedType.I4)] int Channel
            , [MarshalAs(UnmanagedType.I4)] int CorrMode,
            [MarshalAs(UnmanagedType.R8)] double CorrAmount,
            [MarshalAs(UnmanagedType.R8)] double CorrVel,
            [MarshalAs(UnmanagedType.I4)] int CntrMask);

        // 16. cmmSxGetCorrection
        [DllImport(dll, EntryPoint = "cmmSxGetCorrection")]
        public static extern unsafe int cmmSxGetCorrection(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int CorrMode,
            [MarshalAs(UnmanagedType.R8)] ref double CorrAmount,
            [MarshalAs(UnmanagedType.R8)] ref double CorrVel, 
            [MarshalAs(UnmanagedType.I4)] ref int CntrMask);

        // 17. cmmSxOptSetSyncMode
        [DllImport(dll, EntryPoint = "cmmSxOptSetSyncMode")]
        public static extern unsafe int cmmSxOptSetSyncMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Mode,
            [MarshalAs(UnmanagedType.I4)] int RefAxis, 
            [MarshalAs(UnmanagedType.I4)] int Condition);

        // 18. cmmSxOptGetSyncMode
        [DllImport(dll, EntryPoint = "cmmSxOptGetSyncMode")]
        public static extern unsafe int cmmSxOptGetSyncMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int Mode,
            [MarshalAs(UnmanagedType.I4)] ref int RefAxis,
            [MarshalAs(UnmanagedType.I4)] ref int Condition);

        // 19. cmmSxOptSetSyncOut
        [DllImport(dll, EntryPoint = "cmmSxOptSetSyncOut")]
        public static extern unsafe int cmmSxOptSetSyncOut(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Mode,
            [MarshalAs(UnmanagedType.I4)] int DoChan_local,
            [MarshalAs(UnmanagedType.I4)] int DoLogic);

        // 20. cmmSxOptGetSyncOut
        [DllImport(dll, EntryPoint = "cmmSxOptGetSyncOut")]
        public static extern unsafe int cmmSxOptGetSyncOut(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int Mode,
            [MarshalAs(UnmanagedType.I4)] ref int DoChan_local, 
            [MarshalAs(UnmanagedType.I4)] ref int DoLogic);

        // 21. cmmSxOptSetRdpOffset
        [DllImport(dll, EntryPoint = "cmmSxOptSetRdpOffset")]
        public static extern unsafe int cmmSxOptSetRdpOffset(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double OffsetDist);

        // 22. cmmSxOptGetRdpOffset
        [DllImport(dll, EntryPoint = "cmmSxOptGetRdpOffset")]
        public static extern unsafe int cmmSxOptGetRdpOffset(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] ref double OffsetDist);


        //====================== Multiple Axes Move FUNCTIONS =========================================//
        // 1. cmmMxMove
        [DllImport(dll, EntryPoint = "cmmMxMove")]
        public static extern unsafe int cmmMxMove(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] DistList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 2. cmmMxVMoveStart
        [DllImport(dll, EntryPoint = "cmmMxVMoveStart")]
        public static extern unsafe int cmmMxVMoveStart(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] DirList);

        // 3. cmmMxMoveStart
        [DllImport(dll, EntryPoint = "cmmMxMoveStart")]
        public static extern unsafe int cmmMxMoveStart(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] DistList);

        // 4. cmmMxMoveTo
        [DllImport(dll, EntryPoint = "cmmMxMoveTo")]
        public static extern unsafe int cmmMxMoveTo(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] PosList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 5. cmmMxMoveToStart
        [DllImport(dll, EntryPoint = "cmmMxMoveToStart")]
        public static extern unsafe int cmmMxMoveToStart(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] PosList);

        // 6. cmmMxStop 
        [DllImport(dll, EntryPoint = "cmmMxStop")]
        public static extern unsafe int cmmMxStop(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.I4)] int IsWaitComplete,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 7. cmmMxStopEmg
        [DllImport(dll, EntryPoint = "cmmMxStopEmg")]
        public static extern unsafe int cmmMxStopEmg(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList);

        // 8. cmmMxIsDone
        [DllImport(dll, EntryPoint = "cmmMxIsDone")]
        public static extern unsafe int cmmMxIsDone(
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.I4)] ref int IsDone);

        // 9. cmmMxWaitDone
        [DllImport(dll, EntryPoint = "cmmMxWaitDone")]
        public static extern unsafe int cmmMxWaitDone(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] int[] AxisList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);


        //====================== Interpolation Move FUNCTIONS =========================================//
        // 1. cmmIxMapAxes
        [DllImport(dll, EntryPoint = "cmmIxMapAxes")]
        public static extern unsafe int cmmIxMapAxes(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.I4)] int MapMask1, 
            [MarshalAs(UnmanagedType.I4)] int MapMask2);

        // 2. cmmIxSetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmIxSetSpeedPattern")]
        public static extern unsafe int cmmIxSetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.I4)] int IsVectorSpeed,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode, 
            [MarshalAs(UnmanagedType.R8)] double Vel,
            [MarshalAs(UnmanagedType.R8)] double Acc,
            [MarshalAs(UnmanagedType.R8)] double Dec);

        // 3. cmmIxGetSpeedPattern
        [DllImport(dll, EntryPoint = "cmmIxGetSpeedPattern")]
        public static extern unsafe int cmmIxGetSpeedPattern(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.I4)] ref int IsVectorSpeed,
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode, 
            [MarshalAs(UnmanagedType.R8)] ref double Vel,
            [MarshalAs(UnmanagedType.R8)] ref double Acc, 
            [MarshalAs(UnmanagedType.R8)] ref double Dec);

        // 4. cmmIxSetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmIxSetSpeedPattern_T")]
        public static extern unsafe int cmmIxSetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode, 
            [MarshalAs(UnmanagedType.R8)] double Vel,
            [MarshalAs(UnmanagedType.R8)] double AccelTime,
            [MarshalAs(UnmanagedType.R8)] double DecelTime); // <V5.0.4.0>

        // 5. cmmIxGetSpeedPattern_T
        [DllImport(dll, EntryPoint = "cmmIxGetSpeedPattern_T")]
        public static extern unsafe int cmmIxGetSpeedPattern_T(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] ref double Vel,
            [MarshalAs(UnmanagedType.R8)] ref double AccelTime, 
            [MarshalAs(UnmanagedType.R8)] ref double DecelTime); // <V5.0.4.0>

        // 6. cmmIxLine
        [DllImport(dll, EntryPoint = "cmmIxLine")]
        public static extern unsafe int cmmIxLine(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.R8)] double[] DistList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 7. cmmIxLineStart
        [DllImport(dll, EntryPoint = "cmmIxLineStart")]
        public static extern unsafe int cmmIxLineStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.R8)] double[] DistList);

        // 8. cmmIxLineTo
        [DllImport(dll, EntryPoint = "cmmIxLineTo")]
        public static extern unsafe int cmmIxLineTo(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] PostList,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 9. cmmIxLineToStart
        [DllImport(dll, EntryPoint = "cmmIxLineToStart")]
        public static extern unsafe int cmmIxLineToStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType=UnmanagedType.R8)] double[] PostList);

        // 10. cmmIxArcA
        [DllImport(dll, EntryPoint = "cmmIxArcA")]
        public static extern unsafe int cmmIxArcA(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double XCentOffset,
            [MarshalAs(UnmanagedType.R8)] double YCentOffset,
            [MarshalAs(UnmanagedType.R8)] double EndAngle,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 11. cmmIxArcAStart
        [DllImport(dll, EntryPoint = "cmmIxArcAStart")]
        public static extern unsafe int cmmIxArcAStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double XCentOffset,
            [MarshalAs(UnmanagedType.R8)] double YCentOffset,
            [MarshalAs(UnmanagedType.R8)] double EndAngle);

        // 12. cmmIxArcATo
        [DllImport(dll, EntryPoint = "cmmIxArcATo")]
        public static extern unsafe int cmmIxArcATo(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double XCent,
            [MarshalAs(UnmanagedType.R8)] double YCent, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 13. cmmIxArcAToStart
        [DllImport(dll, EntryPoint = "cmmIxArcAToStart")]
        public static extern unsafe int cmmIxArcAToStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double XCent,
            [MarshalAs(UnmanagedType.R8)] double YCent, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle);

        // 14. cmmIxArcP
        [DllImport(dll, EntryPoint = "cmmIxArcP")]
        public static extern unsafe int cmmIxArcP(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double XCentOffset,
            [MarshalAs(UnmanagedType.R8)] double YCentOffset,
            [MarshalAs(UnmanagedType.R8)] double XEndPointDist,
            [MarshalAs(UnmanagedType.R8)] double YEndPointDist,
            [MarshalAs(UnmanagedType.I4)] int Direction,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 15. cmmIxArcPStart
        [DllImport(dll, EntryPoint = "cmmIxArcPStart")]
        public static extern unsafe int cmmIxArcPStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double XCentOffset,
            [MarshalAs(UnmanagedType.R8)] double YCentOffset,
            [MarshalAs(UnmanagedType.R8)] double XEndPointDist,
            [MarshalAs(UnmanagedType.R8)] double YEndPointDist, 
            [MarshalAs(UnmanagedType.I4)] int Direction);

        // 16. cmmIxArcPTo
        [DllImport(dll, EntryPoint = "cmmIxArcPTo")]
        public static extern unsafe int cmmIxArcPTo(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double XCent,
            [MarshalAs(UnmanagedType.R8)] double YCent, 
            [MarshalAs(UnmanagedType.R8)] double XEndPos,
            [MarshalAs(UnmanagedType.R8)] double YEndPos, 
            [MarshalAs(UnmanagedType.I4)] int Direction,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 17. cmmIxArcPToStart
        [DllImport(dll, EntryPoint = "cmmIxArcPToStart")]
        public static extern unsafe int cmmIxArcPToStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double XCent,
            [MarshalAs(UnmanagedType.R8)] double YCent, 
            [MarshalAs(UnmanagedType.R8)] double XEndPos,
            [MarshalAs(UnmanagedType.R8)] double YEndPos,
            [MarshalAs(UnmanagedType.I4)] int Direction);

        // 18. cmmIxArc3P
        [DllImport(dll, EntryPoint = "cmmIxArc3P")]
        public static extern unsafe int cmmIxArc3P(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double P2X,
            [MarshalAs(UnmanagedType.R8)] double P2Y,
            [MarshalAs(UnmanagedType.R8)] double P3X,
            [MarshalAs(UnmanagedType.R8)] double P3Y, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 19. cmmIxArc3PStart
        [DllImport(dll, EntryPoint = "cmmIxArc3PStart")]
        public static extern unsafe int cmmIxArc3PStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double P2X,
            [MarshalAs(UnmanagedType.R8)] double P2Y,
            [MarshalAs(UnmanagedType.R8)] double P3X,
            [MarshalAs(UnmanagedType.R8)] double P3Y, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle);

        // 20. cmmIxArc3PTo
        [DllImport(dll, EntryPoint = "cmmIxArc3PTo")]
        public static extern unsafe int cmmIxArc3PTo(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double P2X,
            [MarshalAs(UnmanagedType.R8)] double P2Y,
            [MarshalAs(UnmanagedType.R8)] double P3X,
            [MarshalAs(UnmanagedType.R8)] double P3Y, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 21. cmmIxArc3PToStart
        [DllImport(dll, EntryPoint = "cmmIxArc3PToStart")]
        public static extern unsafe int cmmIxArc3PToStart(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.R8)] double P2X,
            [MarshalAs(UnmanagedType.R8)] double P2Y, 
            [MarshalAs(UnmanagedType.R8)] double P3X,
            [MarshalAs(UnmanagedType.R8)] double P3Y, 
            [MarshalAs(UnmanagedType.R8)] double EndAngle);

        // 22. cmmIxIsDone
        [DllImport(dll, EntryPoint = "cmmIxIsDone")]
        public static extern unsafe int cmmIxIsDone(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.I4)] ref int IsDone);

        // 23. cmmIxWaitDone
        [DllImport(dll, EntryPoint = "cmmIxWaitDone")]
        public static extern unsafe int cmmIxWaitDone(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 24. cmmIxStop
        [DllImport(dll, EntryPoint = "cmmIxStop")]
        public static extern unsafe int cmmIxStop(
            [MarshalAs(UnmanagedType.I4)] int MapIndex, 
            [MarshalAs(UnmanagedType.I4)] int IsWaitComplete,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 25. cmmIxStopEmg
        [DllImport(dll, EntryPoint = "cmmIxStopEmg")]
        public static extern unsafe int cmmIxStopEmg(
            [MarshalAs(UnmanagedType.I4)] int MapIndex);

        // 26. cmmIxxHelOnceSetSpeed
        [DllImport(dll, EntryPoint = "cmmIxxHelOnceSetSpeed")]
        public static extern unsafe int cmmIxxHelOnceSetSpeed(
            [MarshalAs(UnmanagedType.I4)] int HelId, 
            [MarshalAs(UnmanagedType.I4)] int Master,
            [MarshalAs(UnmanagedType.I4)] int SpeedMode,
            [MarshalAs(UnmanagedType.R8)] double WorkSpeed,
            [MarshalAs(UnmanagedType.R8)] double Acc, 
            [MarshalAs(UnmanagedType.R8)] double Dec);

        // 27. cmmIxxHelOnceGetSpeed
        [DllImport(dll, EntryPoint = "cmmIxxHelOnceGetSpeed")]
        public static extern unsafe int cmmIxxHelOnceGetSpeed(
            [MarshalAs(UnmanagedType.I4)] int HelId,
            [MarshalAs(UnmanagedType.I4)] ref int Master,
            [MarshalAs(UnmanagedType.I4)] ref int SpeedMode, 
            [MarshalAs(UnmanagedType.R8)] ref double WorkSpeed,
            [MarshalAs(UnmanagedType.R8)] ref double Acc,
            [MarshalAs(UnmanagedType.R8)] ref double Dec);

        // 28. cmmIxxHelOnce
        [DllImport(dll, EntryPoint = "cmmIxxHelOnce")]
        public static extern unsafe int cmmIxxHelOnce(
            [MarshalAs(UnmanagedType.I4)] int HelId,
            [MarshalAs(UnmanagedType.I4)] int NumAxes,
            [MarshalAs(UnmanagedType.I4)] ref int AxisList, 
            [MarshalAs(UnmanagedType.R8)] ref double CoordList,
            [MarshalAs(UnmanagedType.R8)] double ArcAngle, 
            [MarshalAs(UnmanagedType.R8)] ref double DistU,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 29. cmmIxxHelOnceStart
        [DllImport(dll, EntryPoint = "cmmIxxHelOnceStart")]
        public static extern unsafe int cmmIxxHelOnceStart(
            [MarshalAs(UnmanagedType.I4)] int HelId,
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.I4)] ref int AxisList,
            [MarshalAs(UnmanagedType.R8)] ref double CoordList,
            [MarshalAs(UnmanagedType.R8)] double ArcAngle, 
            [MarshalAs(UnmanagedType.R8)] ref double DistU);
        //public static extern unsafe int cmmIxxHelOnceStart([MarshalAs(UnmanagedType.I4)] int HelId, [MarshalAs(UnmanagedType.I4)] int NumAxes, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I4)] ref int[] AxisList,
        //    [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] ref double[] CoordList, [MarshalAs(UnmanagedType.R8)] double ArcAngle, [MarshalAs(UnmanagedType.R8)] ref double DistU);

        // 30. cmmIxxSplineBuild
        [DllImport(dll, EntryPoint = "cmmIxxSplineBuild")]
        public static extern unsafe int cmmIxxSplineBuild(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] InArray,
            [MarshalAs(UnmanagedType.I4)] int NumInArray,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] OutArray,
            [MarshalAs(UnmanagedType.I4)] int NumOutArray);

        //CMM_EXTERN long (WINAPI *cmmIxSetMasterAxis)	(long nAxis, long bSetValue);
        [DllImport(dll, EntryPoint = "cmmIxSetMasterAxis")]
        public static extern unsafe int cmmIxSetMasterAxis(
            [MarshalAs(UnmanagedType.I4)] int nAxis,
            [MarshalAs(UnmanagedType.I4)] int bSetValue);

        //CMM_EXTERN long (WINAPI *cmmIxGetMasterAxis)	(long nAxis, long *bSetValue);
        [DllImport(dll, EntryPoint = "cmmIxGetMasterAxis")]
        public static extern unsafe int cmmIxGetMasterAxis(
           [MarshalAs(UnmanagedType.I4)] int nAxis,
           [MarshalAs(UnmanagedType.I4)] ref int bSetValue);


        //CMM_EXTERN long (WINAPI *cmmIxGetFxInfo)	(long nMapIndex, long *bIsFx, long *nMaster);
        [DllImport(dll, EntryPoint = "cmmIxGetFxInfo")]
        public static extern unsafe int cmmIxGetFxInfo(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.I4)] ref int bIsFx,
            [MarshalAs(UnmanagedType.I4)] ref int nMaster);

        //CMM_EXTERN long (WINAPI *cmmIxSmartStop)	(long nMapIndex, double decelTimeSec);
        [DllImport(dll, EntryPoint = "cmmIxSmartStop")]
        public static extern unsafe int cmmIxSmartStop(
            [MarshalAs(UnmanagedType.I4)] int MapIndex,
            [MarshalAs(UnmanagedType.R8)] double decelTimeSec);

        //====================== External Switch Move FUNCTIONS =======================================//
        // 1. cmmExVMoveStart
        [DllImport(dll, EntryPoint = "cmmExVMoveStart")]
        public static extern unsafe int cmmExVMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 2. cmmExMoveStart
        [DllImport(dll, EntryPoint = "cmmExMoveStart")]
        public static extern unsafe int cmmExMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Distance);

        // 3. cmmExMoveToStart
        [DllImport(dll, EntryPoint = "cmmExMoveToStart")]
        public static extern unsafe int cmmExMoveToStart(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Position);


        //====================== Manual Pulsar FUNCTIONS ==============================================//
        // 1. cmmPlsrSetInMode
        [DllImport(dll, EntryPoint = "cmmPlsrSetInMode")]
        public static extern unsafe int cmmPlsrSetInMode
            ([MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int InputMode,
            [MarshalAs(UnmanagedType.I4)] int IsInverse);

        // 2. cmmPlsrGetInMode
        [DllImport(dll, EntryPoint = "cmmPlsrGetInMode")]
        public static extern unsafe int cmmPlsrGetInMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int InputMode,
            [MarshalAs(UnmanagedType.I4)] ref int IsInverse);

        // 3. cmmPlsrSetGain
        [DllImport(dll, EntryPoint = "cmmPlsrSetGain")]
        public static extern unsafe int cmmPlsrSetGain(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int GainFactor,
            [MarshalAs(UnmanagedType.I4)] int DivFactor);

        // 4. cmmPlsrGetGain
        [DllImport(dll, EntryPoint = "cmmPlsrGetGain")]
        public static extern unsafe int cmmPlsrGetGain(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int GainFactor,
            [MarshalAs(UnmanagedType.I4)] ref int DivFactor);

        // 5. cmmPlsrHomeMoveStart
        [DllImport(dll, EntryPoint = "cmmPlsrHomeMoveStart")]
        public static extern unsafe int cmmPlsrHomeMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int HomeType);

        // 6. cmmPlsrMoveStart
        [DllImport(dll, EntryPoint = "cmmPlsrMoveStart")]
        public static extern unsafe int cmmPlsrMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double Distance);

        // 7. cmmPlsrMove
        [DllImport(dll, EntryPoint = "cmmPlsrMove")]
        public static extern unsafe int cmmPlsrMove(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Distance,
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 8. cmmPlsrMoveToStart
        [DllImport(dll, EntryPoint = "cmmPlsrMoveToStart")]
        public static extern unsafe int cmmPlsrMoveToStart(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double Position);

        // 9. cmmPlsrMoveTo
        [DllImport(dll, EntryPoint = "cmmPlsrMoveTo")]
        public static extern unsafe int cmmPlsrMoveTo(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double Position, 
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 10. cmmPlsrVMoveStart
        [DllImport(dll, EntryPoint = "cmmPlsrVMoveStart")]
        public static extern unsafe int cmmPlsrVMoveStart(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 11. cmmPlsrIsActive
        [DllImport(dll, EntryPoint = "cmmPlsrIsActive")]
        public static extern unsafe int cmmPlsrIsActive(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int nIsActive);


        //====================== MASTER/SLAVE FUNCTIONS ===============================================//
        // 1. cmmMsregisterSlave
        [DllImport(dll, EntryPoint = "cmmMsRegisterSlave")]
        public static extern unsafe int cmmMsRegisterSlave(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double MaxSpeed, 
            [MarshalAs(UnmanagedType.I4)] int IsInverse);

        // 2. cmmMsUnregisterSlave
        [DllImport(dll, EntryPoint = "cmmMsUnregisterSlave")]
        public static extern unsafe int cmmMsUnregisterSlave(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 3. cmmMsCheckSlaveState
        [DllImport(dll, EntryPoint = "cmmMsCheckSlaveState")]
        public static extern unsafe int cmmMsCheckSlaveState(
            [MarshalAs(UnmanagedType.I4)] int SlaveAxis,
            [MarshalAs(UnmanagedType.I4)] ref int SlaveState);

        // 4. cmmMsGetMasterAxis
        [DllImport(dll, EntryPoint = "cmmMsGetMasterAxis")]
        public static extern unsafe int cmmMsGetMasterAxis(
            [MarshalAs(UnmanagedType.I4)] int SlaveAxis, 
            [MarshalAs(UnmanagedType.I4)] ref int MasterAxis);


        //====================== Overriding FUNCTIONS =================================================//
        // 1. cmmOverrideSpeedSet
        [DllImport(dll, EntryPoint = "cmmOverrideSpeedSet")]
        public static extern unsafe int cmmOverrideSpeedSet(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 2. cmmOverrideSpeedSetAll
        [DllImport(dll, EntryPoint = "cmmOverrideSpeedSetAll")]
        public static extern unsafe int cmmOverrideSpeedSetAll(
            [MarshalAs(UnmanagedType.I4)] int NumAxes, 
            [MarshalAs(UnmanagedType.I4)] ref int AxisList);

        // 3. cmmOverrideMove
        [DllImport(dll, EntryPoint = "cmmOverrideMove")]
        public static extern unsafe int cmmOverrideMove(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double NewDistance,
            [MarshalAs(UnmanagedType.I4)] ref int IsIgnored);

        // 4. cmmOverrideMoveTo
        [DllImport(dll, EntryPoint = "cmmOverrideMoveTo")]
        public static extern unsafe int cmmOverrideMoveTo(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] double NewPosition,
            [MarshalAs(UnmanagedType.I4)] ref int IsIgnored);


        //====================== LIST-MOTION FUNCTIONS ================================================//
        // 1. cmmLmMapAxes
        [DllImport(dll, EntryPoint = "cmmLmMapAxes")]
        public static extern unsafe int cmmLmMapAxes(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int MapMask1,
            [MarshalAs(UnmanagedType.I4)] int MapMask2);

        // 2. cmmLmBeginList
        [DllImport(dll, EntryPoint = "cmmLmBeginList")]
        public static extern unsafe int cmmLmBeginList(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 3. cmmLmEndList
        [DllImport(dll, EntryPoint = "cmmLmEndList")]
        public static extern unsafe int cmmLmEndList(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 4. cmmLmStartMotion
        [DllImport(dll, EntryPoint = "cmmLmStartMotion")]
        public static extern unsafe int cmmLmStartMotion(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 5. cmmLmAbortMotion
        [DllImport(dll, EntryPoint = "cmmLmAbortMotion")]
        public static extern unsafe int cmmLmAbortMotion(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 6. cmmLmAbortMotionEx
        [DllImport(dll, EntryPoint = "cmmLmAbortMotionEx")]
        public static extern unsafe int cmmLmAbortMotionEx(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.R8)] double DecelT_sec);

        // 7. cmmLmIsDone
        [DllImport(dll, EntryPoint = "cmmLmIsDone")]
        public static extern unsafe int cmmLmIsDone(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] ref int IsDone);

        // 8. cmmLmWaitDone
        [DllImport(dll, EntryPoint = "cmmLmWaitDone")]
        public static extern unsafe int cmmLmWaitDone(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int IsBlocking);

        // 9. cmmLmCurSequence
        [DllImport(dll, EntryPoint = "cmmLmCurSequence")]
        public static extern unsafe int cmmLmCurSequence(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] ref int SeqIndex);

        // 10. cmmLmImmediacySet
        [DllImport(dll, EntryPoint = "cmmLmImmediacySet")]
        public static extern unsafe int cmmLmImmediacySet(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 11. cmmLmDoPutOne
        [DllImport(dll, EntryPoint = "cmmLmDoPutOne")]
        public static extern unsafe int cmmLmDoPutOne(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            IntPtr hDoDevice /*HANDLE*/,
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int OutState);

        // 12. cmmLmDoPutMulti
        [DllImport(dll, EntryPoint = "cmmLmDoPutMulti")]
        public static extern unsafe int cmmLmDoPutMulti(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            IntPtr hDoDevice /*HANDLE*/,
            [MarshalAs(UnmanagedType.I4)] int ChannelGroup,
            [MarshalAs(UnmanagedType.I4)] int Mask,
            [MarshalAs(UnmanagedType.I4)] int OutStates);

        // 13. cmmLmDoPulseOne
        [DllImport(dll, EntryPoint = "cmmLmDoPulseOne")]
        public static extern unsafe int cmmLmDoPulseOne(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            IntPtr hDoDevice /*HANDLE*/,
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int OutState,
            [MarshalAs(UnmanagedType.I4)] int Duration);

        // 14. cmmLmDoPulseMulti
        [DllImport(dll, EntryPoint = "cmmLmDoPulseMulti")]
        public static extern unsafe int cmmLmDoPulseMulti(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            IntPtr hDoDevice /*HANDLE*/,
            [MarshalAs(UnmanagedType.I4)] int ChannelGroup,
            [MarshalAs(UnmanagedType.I4)] int Mask,
            [MarshalAs(UnmanagedType.I4)] int OutStates,
            [MarshalAs(UnmanagedType.I4)] int Duration);


        //====================== 상태감시 FUNCTIONS ===================================================//
        // 1. cmmStSetCount
        [DllImport(dll, EntryPoint = "cmmStSetCount")]
        public static extern unsafe int cmmStSetCount(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Target, 
            [MarshalAs(UnmanagedType.I4)] int Count);

        // 2. cmmStGetCount
        [DllImport(dll, EntryPoint = "cmmStGetCount")]
        public static extern unsafe int cmmStGetCount(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Source,
            [MarshalAs(UnmanagedType.I4)] ref int Count);

        // 3. cmmStSetPosition
        [DllImport(dll, EntryPoint = "cmmStSetPosition")]
        public static extern unsafe int cmmStSetPosition(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Target, 
            [MarshalAs(UnmanagedType.R8)] double Position);

        // 4. cmmStGetPosition
        [DllImport(dll, EntryPoint = "cmmStGetPosition")]
        public static extern unsafe int cmmStGetPosition(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int Source, 
            [MarshalAs(UnmanagedType.R8)] ref double Position);

        // 5. cmmStGetSpeed
        [DllImport(dll, EntryPoint = "cmmStGetSpeed")]
        public static extern unsafe int cmmStGetSpeed(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Source,
            [MarshalAs(UnmanagedType.R8)] ref double Speed);

        // 6. cmmStReadMotionState
        [DllImport(dll, EntryPoint = "cmmStReadMotionState")]
        public static extern unsafe int cmmStReadMotionState(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int MotStates);

        // 7. cmmStReadMioStatuses
        [DllImport(dll, EntryPoint = "cmmStReadMioStatuses")]
        public static extern unsafe int cmmStReadMioStatuses(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int MioStates);

        // 8. cmmStGetMstString
        [DllImport(dll, EntryPoint = "cmmStGetMstString")]
        public static extern unsafe int cmmStGetMstString(
            [MarshalAs(UnmanagedType.I4)] int MstCode, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] int[] Buffer,
            [MarshalAs(UnmanagedType.I4)] int BufferLen);

        // 9. cmmMstAll_SetCfg
        [DllImport(dll, EntryPoint = "cmmMstAll_SetCfg")]
        public static extern unsafe int cmmMstAll_SetCfg(
            [MarshalAs(UnmanagedType.I4)] int AxisMask1,
            [MarshalAs(UnmanagedType.I4)] int AxisMask2, 
            [MarshalAs(UnmanagedType.I4)] int DataMask);

        // 10. cmmMstAll_GetCfg
        [DllImport(dll, EntryPoint = "cmmMstAll_GetCfg")]
        public static extern unsafe int cmmMstAll_GetCfg(
            [MarshalAs(UnmanagedType.I4)] ref int AxisMask1, 
            [MarshalAs(UnmanagedType.I4)] ref int AxisMask2, 
            [MarshalAs(UnmanagedType.I4)] ref int DataMask);

        // FIXME: 아래의 11 ~ 17 까지의 상태감시 함수는 추후 정의 하기로 함.
        //		CMM_EXTERN long (WINAPI *cmmMstAll_ManScan)		(TCmMstAll *pBuf);
        // 11. cmmMstAll_ManScan
        //		CMM_EXTERN long (WINAPI *cmmMstAll_AutoStart)	(long TimerInterv);
        // 12. cmmMstAll_AutoStart
        //		CMM_EXTERN long (WINAPI *cmmMstAll_AutoStop)	();
        // 13. cmmMstAll_AutoStop
        //		CMM_EXTERN TCmMstAll* (WINAPI *cmmMstAll_AutoGetBuf) (void);
        // 14. cmmMstAll_AutoGetBuf
        //		CMM_EXTERN long (WINAPI *cmmMstAll_AutoGetData)	(TCmMstAll *pBuf, long IsFrameSync);
        // 15. cmmMstAll_AutoGetData
        //		CMM_EXTERN long (WINAPI *cmmMstAll_AutoGetInfo)	(long *ScanCount, long *ScanInerv, long *ScanConsT);
        // 16. cmmMstAll_AutoGetInfo
        //		CMM_EXTERN long (WINAPI *cmmMstAll_AutoGetInfo2) (long AxisInDev, long *ScanCount, long *ScanInerv, long *ScanConsT);
        // 17. cmmMstAll_AutoGetInfo2


        //====================== INTERRUPT FUNCTIONS ==================================================//
        // 1. cmmIntSetMask
        [DllImport(dll, EntryPoint = "cmmIntSetMask")]
        public static extern unsafe int cmmIntSetMask(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Mask);

        // 2. cmmIntGetMask
        [DllImport(dll, EntryPoint = "cmmIntGetMask")]
        public static extern unsafe int cmmIntGetMask(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int Mask);

        // 3-1. cmmIntHandlerSetup_MSG
        [DllImport(dll, EntryPoint = "cmmIntHandlerSetup")]
        public static extern unsafe int cmmIntHandlerSetup_MSG(
            [MarshalAs(UnmanagedType.I4)] int HandlerType, 
            IntPtr Handler,
            [MarshalAs(UnmanagedType.U4)] uint nMessage, 
            IntPtr lParam);

        // 3-2. cmmIntHandlerSetup_EVT
        [DllImport(dll, EntryPoint = "cmmIntHandlerSetup")]
        public static extern unsafe int cmmIntHandlerSetup_EVT(
            [MarshalAs(UnmanagedType.I4)] int HandlerType, 
            CallbackFunc Handler,
            [MarshalAs(UnmanagedType.U4)] uint nMessage, 
            IntPtr lParam);

        // 3-3. cmmIntHandlerSetup_CLB
        [DllImport(dll, EntryPoint = "cmmIntHandlerSetup")]
        public static extern unsafe int cmmIntHandlerSetup_CLB(
            [MarshalAs(UnmanagedType.I4)] int HandlerType, 
            CallbackFunc Handler,
            [MarshalAs(UnmanagedType.U4)] uint nMessage, 
            IntPtr lParam);

        // 4. cmmIntHandlerEnable
        [DllImport(dll, EntryPoint = "cmmIntHandlerEnable")]
        public static extern unsafe int cmmIntHandlerEnable(
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        // 5. cmmIntReadFlag
        [DllImport(dll, EntryPoint = "cmmIntReadFlag")]
        public static extern unsafe int cmmIntReadFlag(
            [MarshalAs(UnmanagedType.I4)] ref int IntFlag1,
            [MarshalAs(UnmanagedType.I4)] ref int IntFlag2);

        // 6. cmmIntReadErrorStatus
        [DllImport(dll, EntryPoint = "cmmIntReadErrorStatus")]
        public static extern unsafe int cmmIntReadErrorStatus(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int ErrState);

        // 7. cmmIntReadEventStatus
        [DllImport(dll, EntryPoint = "cmmIntReadEventStatus")]
        public static extern unsafe int cmmIntReadEventStatus(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int EventState);

        //====================== LATCH FUNCTIONS =======================================================//
        // 1. cmmLtcIsLatched
        [DllImport(dll, EntryPoint = "cmmLtcIsLatched")]
        public static extern unsafe int cmmLtcIsLatched(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsLatched);

        // 2. cmmLtcReadLatched
        [DllImport(dll, EntryPoint = "cmmLtcReadLatch")]
        public static extern unsafe int cmmLtcReadLatch(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int Counter,            
            [MarshalAs(UnmanagedType.R8)] ref double LatchedPos);

        // 3. cmmLtcQue_SetCfg
        [DllImport(dll, EntryPoint = "cmmLtcQue_SetCfg")]
        public static extern unsafe int cmmLtcQue_SetCfg(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int QueSize,
            [MarshalAs(UnmanagedType.I4)] int LtcTargCntr);

        // 4. cmmLtcQue_GetCfg
        [DllImport(dll, EntryPoint = "cmmLtcQue_GetCfg")]
        public static extern unsafe int cmmLtcQue_GetCfg(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int QueSize,
            [MarshalAs(UnmanagedType.I4)] ref int LtcTargCntr);

        // 5. cmmLtcQue_SetEnable
        [DllImport(dll, EntryPoint = "cmmLtcQue_SetEnable")]
        public static extern unsafe int cmmLtcQue_SetEnable(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsEnabled);

        // 6. cmmLtcQue_GetEnable
        [DllImport(dll, EntryPoint = "cmmLtcQue_GetEnable")]
        public static extern unsafe int cmmLtcQue_GetEnable(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsEnabled);

        // 7. cmmLtcQue_GetItemCount
        [DllImport(dll, EntryPoint = "cmmLtcQue_GetItemCount")]
        public static extern unsafe int cmmLtcQue_GetItemCount(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int LtcItemCount);

        // 8. cmmLtcQue_ResetItemCount
        [DllImport(dll, EntryPoint = "cmmLtcQue_ResetItemCount")]
        public static extern unsafe int cmmLtcQue_ResetItemCount(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 9. cmmLtcQue_Deque
        [DllImport(dll, EntryPoint = "cmmLtcQue_Deque")]
        public static extern unsafe int cmmLtcQue_Deque(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double LtcData);

        // 10. cmmLtcQue_PeekAt
        [DllImport(dll, EntryPoint = "cmmLtcQue_PeekAt")]
        public static extern unsafe int cmmLtcQue_PeekAt(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Index, 
            [MarshalAs(UnmanagedType.R8)] ref double LtcData);


        //====================== Position Compare FUNCTIONS ===========================================//
        // 1. cmmCmpErrSetConfig
        [DllImport(dll, EntryPoint = "cmmCmpErrSetConfig")]
        public static extern unsafe int cmmCmpErrSetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Tolerance,
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        // 2. cmmCmpErrGetConfig
        [DllImport(dll, EntryPoint = "cmmCmpErrGetConfig")]
        public static extern unsafe int cmmCmpErrGetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double Tolerance, 
            [MarshalAs(UnmanagedType.I4)] ref int IsEnabled);

        // 3. cmmCmpGenSetConfig 
        [DllImport(dll, EntryPoint = "cmmCmpGenSetConfig")]
        public static extern unsafe int cmmCmpGenSetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] int CmpMethod,
            [MarshalAs(UnmanagedType.I4)] int CmpAction, 
            [MarshalAs(UnmanagedType.R8)] double CmpData);

        // 4. cmmCmpGenGetConfig
        [DllImport(dll, EntryPoint = "cmmCmpGenGetConfig")]
        public static extern unsafe int cmmCmpGenGetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] ref int CmpMethod, 
            [MarshalAs(UnmanagedType.I4)] ref int CmpAction,
            [MarshalAs(UnmanagedType.I4)] ref int CmpData);

        // 5. cmmCmpTrgSetConfig
        [DllImport(dll, EntryPoint = "cmmCmpTrgSetConfig")]
        public static extern unsafe int cmmCmpTrgSetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] int CmpMethod);

        // 6. cmmCmpTrgGetConfig
        [DllImport(dll, EntryPoint = "cmmCmpTrgGetConfig")]
        public static extern unsafe int cmmCmpTrgGetConfig(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int CmpSrc, 
            [MarshalAs(UnmanagedType.I4)] ref int CmpMethod);

        // 7. cmmCmpTrgSetOneData
        [DllImport(dll, EntryPoint = "cmmCmpTrgSetOneData")]
        public static extern unsafe int cmmCmpTrgSetOneData(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double Data);

        // 8. cmmCmpTrgGetCurData
        [DllImport(dll, EntryPoint = "cmmCmpTrgGetCurData")]
        public static extern unsafe int cmmCmpTrgGetCurData(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double Data);

        // 9. cmmCmpTrgContRegTable
        [DllImport(dll, EntryPoint = "cmmCmpTrgContRegTable")]
        public static extern unsafe int cmmCmpTrgContRegTable(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] Buffer, 
            [MarshalAs(UnmanagedType.I4)] int NumData);

        // 10. cmmCmpTrgContBuildTable
        [DllImport(dll, EntryPoint = "cmmCmpTrgContBuildTable")]
        public static extern unsafe int cmmCmpTrgContBuildTable(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.R8)] double StartData,
            [MarshalAs(UnmanagedType.R8)] double Interval,
            [MarshalAs(UnmanagedType.I4)] int NumData);

        // 11. cmmCmpTrgContStart
        [DllImport(dll, EntryPoint = "cmmCmpTrgContStart")]
        public static extern unsafe int cmmCmpTrgContStart(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 12. cmmCmpTrgContStop
        [DllImport(dll, EntryPoint = "cmmCmpTrgContStop")]
        public static extern unsafe int cmmCmpTrgContStop(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 13. cmmCmpTrgContIsActive
        [DllImport(dll, EntryPoint = "cmmCmpTrgContIsActive")]
        public static extern unsafe int cmmCmpTrgContIsActive(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int IsActive);

        // 14. cmmCmpTrgHigh_WriteData
        [DllImport(dll, EntryPoint = "cmmCmpTrgHigh_WriteData")]
        public static extern unsafe int cmmCmpTrgHigh_WriteData(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int CMPH_No,
            [MarshalAs(UnmanagedType.R8)] double IniPos, 
            [MarshalAs(UnmanagedType.R8)] double Interval);

        // 15. cmmCmpTrgHigh_ReadData
        [DllImport(dll, EntryPoint = "cmmCmpTrgHigh_ReadData")]
        public static extern unsafe int cmmCmpTrgHigh_ReadData(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int CMPH_No,
            [MarshalAs(UnmanagedType.R8)] ref double IniPos, 
            [MarshalAs(UnmanagedType.R8)] ref double Interval);

        // 16. cmmCmpTrgHigh_Start
        [DllImport(dll, EntryPoint = "cmmCmpTrgHigh_Start")]
        public static extern unsafe int cmmCmpTrgHigh_Start(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 17. cmmCmpTrgHigh_Stop
        [DllImport(dll, EntryPoint = "cmmCmpTrgHigh_Stop")]
        public static extern unsafe int cmmCmpTrgHigh_Stop(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 18. cmmCmpTrgHigh_Check
        [DllImport(dll, EntryPoint = "cmmCmpTrgHigh_Check")]
        public static extern unsafe int cmmCmpTrgHigh_Check(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsActive,
            [MarshalAs(UnmanagedType.I4)] ref int OutCount);

        // 19. cmmCmpQue_SetEnable
        [DllImport(dll, EntryPoint = "cmmCmpQue_SetEnable")]
        public static extern unsafe int cmmCmpQue_SetEnable(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int IsEnable);

        // 20. cmmCmpQue_GetEnable
        [DllImport(dll, EntryPoint = "cmmCmpQue_GetEnable")]
        public static extern unsafe int cmmCmpQue_GetEnable(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int IsEnable);

        // 21. cmmCmpQue_SetQueSize
        [DllImport(dll, EntryPoint = "cmmCmpQue_SetQueSize")]
        public static extern unsafe int cmmCmpQue_SetQueSize(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int QueSize);

        // 22. cmmCmpQue_GetQueSize
        [DllImport(dll, EntryPoint = "cmmCmpQue_GetQueSize")]
        public static extern unsafe int cmmCmpQue_GetQueSize(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int QueSize);

        // 23. cmmCmpQue_Enque
        [DllImport(dll, EntryPoint = "cmmCmpQue_Enque")]
        public static extern unsafe int cmmCmpQue_Enque(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] int CmpMethod, 
            [MarshalAs(UnmanagedType.I4)] int CmpData);

        // 24. cmmCmpQue_GetEnqueCnt
        [DllImport(dll, EntryPoint = "cmmCmpQue_GetEnqueCnt")]
        public static extern unsafe int cmmCmpQue_GetEnqueCnt(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] ref int EnqueCnt);

        // 25. cmmCmpQue_GetOutCnt
        [DllImport(dll, EntryPoint = "cmmCmpQue_GetOutCnt")]
        public static extern unsafe int cmmCmpQue_GetOutCnt(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int OutCnt);

        // 26. cmmCmpQue_SetOutCnt
        [DllImport(dll, EntryPoint = "cmmCmpQue_SetOutCnt")]
        public static extern unsafe int cmmCmpQue_SetOutCnt(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int OutCnt);

        // 27. cmmCmpQue_SetLtcLinkMode
        [DllImport(dll, EntryPoint = "cmmCmpQue_SetLtcLinkMode")]
        public static extern unsafe int cmmCmpQue_SetLtcLinkMode(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Enable,
            [MarshalAs(UnmanagedType.I4)] int SrcLtcCnt,
            [MarshalAs(UnmanagedType.I4)] int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] int CmpMethod,
            [MarshalAs(UnmanagedType.I4)] int Offset);

        // 28. cmmCmpQue_GetLtcLinkMode
        [DllImport(dll, EntryPoint = "cmmCmpQue_GetLtcLinkMode")]
        public static extern unsafe int cmmCmpQue_GetLtcLinkMode(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int Enable,
            [MarshalAs(UnmanagedType.I4)] ref int SrcLtcCnt, 
            [MarshalAs(UnmanagedType.I4)] ref int CmpSrc,
            [MarshalAs(UnmanagedType.I4)] ref int CmpMethod, 
            [MarshalAs(UnmanagedType.I4)] ref int Offset);


        //====================== Digital In/Out FUNCTIONS =============================================//
        // 1. cmmDiSetInputLogic
        [DllImport(dll, EntryPoint = "cmmDiSetInputLogic")]
        public static extern unsafe int cmmDiSetInputLogic(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] int InputLogic);

        // 2. cmmDiGetInputLogic
        [DllImport(dll, EntryPoint = "cmmDiGetInputLogic")]
        public static extern unsafe int cmmDiGetInputLogic(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] ref int InputLogic);

        // 3. cmmDiGetOne
        [DllImport(dll, EntryPoint = "cmmDiGetOne")]
        public static extern unsafe int cmmDiGetOne(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] ref int InputState);

        // 4. cmmDiGetMulti
        [DllImport(dll, EntryPoint = "cmmDiGetMulti")]
        public static extern unsafe int cmmDiGetMulti(
            [MarshalAs(UnmanagedType.I4)] int IniChannel, 
            [MarshalAs(UnmanagedType.I4)] int NumChannels,
            [MarshalAs(UnmanagedType.U4)] ref uint InputStates);

        // 5. cmmDiGetOneF
        [DllImport(dll, EntryPoint = "cmmDiGetOneF")]
        public static extern unsafe int cmmDiGetOneF(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] int CutoffTime_us, 
            [MarshalAs(UnmanagedType.I4)] ref int InputState);

        // 6. cmmDiGetMultiF
        [DllImport(dll, EntryPoint = "cmmDiGetMultiF")]
        public static extern unsafe int cmmDiGetMultiF(
            [MarshalAs(UnmanagedType.I4)] int IniChannel, 
            [MarshalAs(UnmanagedType.I4)] int NumChannels,
            [MarshalAs(UnmanagedType.I4)] int CutoffTime_us,
            [MarshalAs(UnmanagedType.I4)] ref int InputStates);

        // 7. cmmDoSetOutputLogic
        [DllImport(dll, EntryPoint = "cmmDoSetOutputLogic")]
        public static extern unsafe int cmmDoSetOutputLogic(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int OutputLogic);

        // 8. cmmDoGetOutputLogic
        [DllImport(dll, EntryPoint = "cmmDoGetOutputLogic")]
        public static extern unsafe int cmmDoGetOutputLogic(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] ref int OutputLogic);

        // 9. cmmDoPutOne
        [DllImport(dll, EntryPoint = "cmmDoPutOne")]
        public static extern unsafe int cmmDoPutOne(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int OutState);

        // 10. cmmDoGetOne
        [DllImport(dll, EntryPoint = "cmmDoGetOne")]
        public static extern unsafe int cmmDoGetOne(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] ref int OutState);

        // 11. cmmDoPulseOne
        [DllImport(dll, EntryPoint = "cmmDoPulseOne")]
        public static extern unsafe int cmmDoPulseOne(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] int IsOnPulse,
            [MarshalAs(UnmanagedType.I4)] int dwDuration, 
            [MarshalAs(UnmanagedType.I4)] int IsWaitPulseEnd);

        // 12. cmmDoPutMulti
        [DllImport(dll, EntryPoint = "cmmDoPutMulti")]
        public static extern unsafe int cmmDoPutMulti(
            [MarshalAs(UnmanagedType.I4)] int IniChannel,
            [MarshalAs(UnmanagedType.I4)] int NumChannels,
            [MarshalAs(UnmanagedType.I4)] int OutStates);

        // 13. cmmDoGetMulti
        [DllImport(dll, EntryPoint = "cmmDoGetMulti")]
        public static extern unsafe int cmmDoGetMulti(
            [MarshalAs(UnmanagedType.I4)] int IniChannel, 
            [MarshalAs(UnmanagedType.I4)] int NumChannels,
            [MarshalAs(UnmanagedType.U4)] ref uint OutStates);

        // 14. cmmDoPulseMulti
        [DllImport(dll, EntryPoint = "cmmDoPulseMulti")]
        public static extern unsafe int cmmDoPulseMulti(
            [MarshalAs(UnmanagedType.I4)] int Channel, 
            [MarshalAs(UnmanagedType.I4)] int NumChannels,
            [MarshalAs(UnmanagedType.I4)] int OutStates,
            [MarshalAs(UnmanagedType.I4)] int dwDuration,
            [MarshalAs(UnmanagedType.I4)] int IsWaitPulseEnd);


        //====================== Advanced FUNCTIONS ===================================================//
        // 1. cmmAdvGetNumAvailAxes
        [DllImport(dll, EntryPoint = "cmmAdvGetNumAvailAxes")]
        public static extern unsafe int cmmAdvGetNumAvailAxes(
            [MarshalAs(UnmanagedType.I4)] ref int NumAxes);

        // 2. cmmAdvGetNumDefinedAxes
        [DllImport(dll, EntryPoint = "cmmAdvGetNumDefinedAxes")]
        public static extern unsafe int cmmAdvGetNumDefinedAxes(
            [MarshalAs(UnmanagedType.I4)] ref int NumAxes);

        // 3. cmmAdvGetNumAvailDioChan
        [DllImport(dll, EntryPoint = "cmmAdvGetNumAvailDioChan")]
        public static extern unsafe int cmmAdvGetNumAvailDioChan(
            [MarshalAs(UnmanagedType.I4)] int IsInputChannel,
            [MarshalAs(UnmanagedType.I4)] ref int NumChannels);

        // 4. cmmAdvGetNumDefinedDioChan
        [DllImport(dll, EntryPoint = "cmmAdvGetNumDefinedDioChan")]
        public static extern unsafe int cmmAdvGetNumDefinedDioChan(
            [MarshalAs(UnmanagedType.I4)] int IsInputChannel,
            [MarshalAs(UnmanagedType.I4)] ref int NumChannels);

        // 5. cmmAdvGetMotDeviceId
        [DllImport(dll, EntryPoint = "cmmAdvGetMotDeviceId")]
        public static extern unsafe int cmmAdvGetMotDeviceId(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] ref int DeviceId);

        // 6. cmmAdvGetMotDevInstance
        [DllImport(dll, EntryPoint = "cmmAdvGetMotDevInstance")]
        public static extern unsafe int cmmAdvGetMotDevInstance(
            [MarshalAs(UnmanagedType.I4)] int Channel,             
            [MarshalAs(UnmanagedType.I4)] ref int DevInstance);

        // 7. cmmAdvGetDioDeviceId
        [DllImport(dll, EntryPoint = "cmmAdvGetDioDeviceId")]
        public static extern unsafe int cmmAdvGetDioDeviceId(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int IsInputChannel,
            [MarshalAs(UnmanagedType.I4)] ref int DeviceId);

        // 8. cmmAdvGetDioDevInstance
        [DllImport(dll, EntryPoint = "cmmAdvGetDioDevInstance")]
        public static extern unsafe int cmmAdvGetDioDevInstance(
            [MarshalAs(UnmanagedType.I4)] int Channel,
            [MarshalAs(UnmanagedType.I4)] int IsInputChannel, 
            [MarshalAs(UnmanagedType.I4)] ref int DevInstance);

        // FIXME: 아래의 9 고급 함수는 추후 정의 하기로 함.
        //		CMM_EXTERN long	(WINAPI *cmmAdvGetDeviceHandle)	(long DeviceId, long DevInstance, HANDLE *DevHandle);
        // 9. cmmAdvGetDeviceHandle

        // 10. cmmAdvWriteMainSpace
        [DllImport(dll, EntryPoint = "cmmAdvWriteMainSpace")]
        public static extern unsafe int cmmAdvWriteMainSpace(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int Addr,
            [MarshalAs(UnmanagedType.I4)] int Value);

        // 11. cmmAdvReadMainSpace
        [DllImport(dll, EntryPoint = "cmmAdvReadMainSpace")]
        public static extern unsafe int cmmAdvReadMainSpace(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Addr,
            [MarshalAs(UnmanagedType.I4)] ref int Value);

        // 12. cmmAdvWriteregister
        [DllImport(dll, EntryPoint = "cmmAdvWriteRegister")]
        public static extern unsafe int cmmAdvWriteRegister(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int registerNo,
            [MarshalAs(UnmanagedType.I4)] int RegVal);

        // 13. cmmAdvReadRegister
        [DllImport(dll, EntryPoint = "cmmAdvReadRegister")]
        public static extern unsafe int cmmAdvReadRegister(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int registerNo,
            [MarshalAs(UnmanagedType.I4)] ref int RegVal);

        // 14. cmmAdvGetMioCfg1Dword
        [DllImport(dll, EntryPoint = "cmmAdvGetMioCfg1Dword")]
        public static extern unsafe int cmmAdvGetMioCfg1Dword(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] ref int Mio1Dword);

        // 15. cmmAdvSetMioCfg1Dword
        [DllImport(dll, EntryPoint = "cmmAdvSetMioCfg1Dword")]
        public static extern unsafe int cmmAdvSetMioCfg1Dword(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int Mio1Dword);

        // 16. cmmAdvSetToolboxMode
        [DllImport(dll, EntryPoint = "cmmAdvSetToolboxMode")]
        public static extern unsafe int cmmAdvSetToolboxMode(
            [MarshalAs(UnmanagedType.I4)] int EnInterrupt);

        // 17. cmmAdvGetString
        [DllImport(dll, EntryPoint = "cmmAdvGetString")]
        public static extern unsafe int cmmAdvGetString(
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int StringID,
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] int[] szBuffer);

        // 18. cmmAdvErcOut
        [DllImport(dll, EntryPoint = "cmmAdvErcOut")]
        public static extern unsafe int cmmAdvErcOut(
            [MarshalAs(UnmanagedType.I4)] int Axis,
            [MarshalAs(UnmanagedType.I4)] int IsWaitOff);

        // 19. cmmAdvErcReset
        [DllImport(dll, EntryPoint = "cmmAdvErcReset")]
        public static extern unsafe int cmmAdvErcReset(
            [MarshalAs(UnmanagedType.I4)] int Axis);

        // 20. cmmAdvSetExtOptions
        [DllImport(dll, EntryPoint = "cmmAdvSetExtOptions")]
        public static extern unsafe int cmmAdvSetExtOptions(
            [MarshalAs(UnmanagedType.I4)] int OptionId, 
            [MarshalAs(UnmanagedType.I4)] int lParam1,
            [MarshalAs(UnmanagedType.I4)] int lParam2,
            [MarshalAs(UnmanagedType.R8)] double fParam1,
            [MarshalAs(UnmanagedType.R8)] double fParam2);

        //		CMM_EXTERN long (WINAPI *cmmAdvEnumMotDevices)	(TMotDevEnum *EnumBuffer);
        // 21. cmmAdvEnumDioDevices
        [DllImport(dll, EntryPoint = "cmmAdvEnumMotDevices")]
        public static extern unsafe int cmmAdvEnumMotDevices(
            ref TMotDevEnum TMotDevEnum);

        //		CMM_EXTERN long (WINAPI *cmmAdvGetMotDevMap)	(TMotDevMap *MapBuffer);
        // 22. cmmAdvGetMotDevMap
        
        [DllImportAttribute("Cmmsdk.dll", EntryPoint = "cmmAdvGetMotDevMap")]//, CallingConvention = CallingConvention.Cdecl)]
        public static extern unsafe int cmmAdvGetMotDevMap(
            ref TMotDevMap TMotDevMap, 
            ref int MapBuffer);



        //		CMM_EXTERN long (WINAPI *cmmAdvEnumDioDevices)	(TDioDevEnum *EnumBuffer);
        // 23. cmmAdvEnumDioDevices
        [DllImport(dll, EntryPoint = "cmmAdvEnumDioDevices")]
        public static extern unsafe int cmmAdvEnumDioDevices(
            ref TDioDevEnum TDioDevEnum);

        //		CMM_EXTERN long (WINAPI *cmmAdvGetDioDevMap)	(TDioDevMap *MapBuffer);
        // 24. cmmAdvGetDioDevMap
        [DllImport(dll, EntryPoint = "cmmAdvGetDioDevMap")]
        public static extern unsafe int cmmAdvGetDioDevMap(
            ref TDioDevMap TDioDevMap, ref int MapBuffer);


        //		CMM_EXTERN long (WINAPI *cmmAdvInitFromCmeBuffer) (TCmeData_V2 *pCmeBuffer);
        // 25. cmmAdvInitFromCmeBuffer

        //      CMM_EXTERN long (WINAPI *cmmAdvInitFromCmeBuffer_MapOnly) (TCmeData_V2 *pCmeBuffer, int nMapType);
        // 26. cmmAdvInitFromCmeBuffer_MapOnly

        // 27. cmmAdvGetLatestCmeFile
        [DllImport(dll, EntryPoint = "cmmAdvGetLatestCmeFile")]
        public static extern unsafe int cmmAdvGetLatestCmeFile(
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.I1)] byte[] szCmeFile);

        // 28. cmmAdvGetAxisCapability
        [DllImport(dll, EntryPoint = "cmmAdvGetAxisCapability")]
        public static extern unsafe int cmmAdvGetAxisCapability
            ([MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.I4)] int CapId,
            [MarshalAs(UnmanagedType.I4)] ref int CapBuffer);


        //====================== DEBUG-LOGGING FUNCTIONS ==============================================//
        // 1. cmmDlogSetup
        [DllImport(dll, EntryPoint = "cmmDlogSetup", CharSet = CharSet.Unicode, BestFitMapping = false)]
        public static extern unsafe int cmmDlogSetup(
            [MarshalAs(UnmanagedType.I4)] int Level,
            [MarshalAs(UnmanagedType.LPStr)] string szLogFile);

        // 2. cmmDlogAddComment
        [DllImport(dll, EntryPoint = "cmmDlogAddComment", CharSet = CharSet.Unicode, BestFitMapping = false)]
        public static extern unsafe int cmmDlogAddComment(
            [MarshalAs(UnmanagedType.LPStr)] int[] szComment);

        // 3. cmmDlogGetCurLevel
        [DllImport(dll, EntryPoint = "cmmDlogGetCurLevel")]
        public static extern unsafe int cmmDlogGetCurLevel(
            [MarshalAs(UnmanagedType.I4)] ref int CurLevel);

        // 4. cmmDlogGetCurFilePath
        [DllImport(dll, EntryPoint = "cmmDlogGetCurFilePath", CharSet = CharSet.Unicode, BestFitMapping = false)]
        public static extern unsafe int cmmDlogGetCurFilePath(
            [MarshalAs(UnmanagedType.LPStr)] int[] szFilePath);

        // 5. cmmDlogEnterManMode
        [DllImport(dll, EntryPoint = "cmmDlogEnterManMode")]
        public static extern unsafe int cmmDlogEnterManMode(
            [MarshalAs(UnmanagedType.I4)] int nMode);

        // 6. cmmDlogExitManMode
        [DllImport(dll, EntryPoint = "cmmDlogExitManMode")]
        public static extern unsafe int cmmDlogExitManMode();


        //====================== ERROR HANDLING FUNCTIONS =============================================//
        // 1. cmmErrGetLastCode
        [DllImport(dll, EntryPoint = "cmmErrGetLastCode")]
        public static extern unsafe int cmmErrGetLastCode(
            [MarshalAs(UnmanagedType.I4)] ref int ErrorCode);

        // 2. cmmErrClearLastCode
        [DllImport(dll, EntryPoint = "cmmErrClearLastCode")]
        public static extern unsafe int cmmErrClearLastCode();

        // 3. cmmErrParseAxis
        [DllImport(dll, EntryPoint = "cmmErrParseAxis")]
        public static extern unsafe short cmmErrParseAxis(
            [MarshalAs(UnmanagedType.I4)] int ErrorCode);

        // 4. cmmErrParseReason
        [DllImport(dll, EntryPoint = "cmmErrParseReason")]
        public static extern unsafe short cmmErrParseReason(
            [MarshalAs(UnmanagedType.I4)] int ErrorCode);

        // 5. cmmErrGetString
        [DllImport(dll, EntryPoint = "cmmErrGetString", CharSet = CharSet.Unicode)]
        public static extern unsafe int cmmErrGetString(
            [MarshalAs(UnmanagedType.I4)] int ErrorCode,
            [MarshalAs(UnmanagedType.LPStr)] ref string Buffer, 
            [MarshalAs(UnmanagedType.I4)] int BufferLen);

        // 6. cmmErrShowLast
        [DllImport(dll, EntryPoint = "cmmErrShowLast")]
        public static extern unsafe int cmmErrShowLast(
            IntPtr ParentWnd/* HWND ParentWnd*/);

        // 7. cmmErrSetSkipShowMessage
        [DllImport(dll, EntryPoint = "cmmErrSetSkipShowMessage")]
        public static extern unsafe int cmmErrSetSkipShowMessage(
            [MarshalAs(UnmanagedType.I4)] int IsSkip);

        // 8. cmmErrGetSkipShowMessage
        [DllImport(dll, EntryPoint = "cmmErrGetSkipShowMessage")]
        public static extern unsafe int cmmErrGetSkipShowMessage(
            [MarshalAs(UnmanagedType.I4)] ref int IsSkip);

        // 9. cmmErrSetEnableAutoMessage
        [DllImport(dll, EntryPoint = "cmmErrSetEnableAutoMessage")]
        public static extern unsafe int cmmErrSetEnableAutoMessage(
            [MarshalAs(UnmanagedType.I4)] int Enable);

        // 10. cmmErrGetEnableAutoMessage
        [DllImport(dll, EntryPoint = "cmmErrGetEnableAutoMessage")]
        public static extern unsafe int cmmErrGetEnableAutoMessage(
            [MarshalAs(UnmanagedType.I4)] ref int Enable);


        //====================== Utility FUNCTIONS ===================================================//
        // 1. cmmUtlProcessWndMsgS
        [DllImport(dll, EntryPoint = "cmmUtlProcessWndMsgS")]
        public static extern unsafe int cmmUtlProcessWndMsgS(
            IntPtr WndHandle,
            [MarshalAs(UnmanagedType.I4)] ref int IsEmpty);

        // 2. cmmUtlProcessWndMsgM
        [DllImport(dll, EntryPoint = "cmmUtlProcessWndMsgM")]
        public static extern unsafe int cmmUtlProcessWndMsgM(
            IntPtr WndHandle,
            [MarshalAs(UnmanagedType.I4)] int Timeout,
            [MarshalAs(UnmanagedType.I4)] ref int IsTimeOuted);

        // FIXME: 아래의 3 ~ 5 까지의 Utility 함수는 추후 정의 하기로 함.
        //		CMM_EXTERN long (WINAPI *cmmUtlReadUserTable)	(long nAddress, long nSize, UCHAR* pBuffer);
        // 3. cmmUtlReadUserTable

        //		CMM_EXTERN long (WINAPI *cmmUtlWriteUserTable)	(long nAddress, long nSize, UCHAR* pBuffer);
        // 4. cmmUtlWriteUserTable

        //		CMM_EXTERN long (WINAPI *cmmUtlDelayMicroSec)	(long Delay_us);
        // 5. cmmUtlDelayMicroSec


        //====================== Extended List Motion FUNCTIONS ===================================================//
        // 1. cmmLmxStart
        [DllImport(dll, EntryPoint = "cmmLmxStart")]
        public static extern unsafe int cmmLmxStart(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int AxisMask1, 
            [MarshalAs(UnmanagedType.I4)] int AxisMask2);

        // 2. cmmLmxPause
        [DllImport(dll, EntryPoint = "cmmLmxPause")]
        public static extern unsafe int cmmLmxPause(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 3. cmmLmxResume
        [DllImport(dll, EntryPoint = "cmmLmxResume")]
        public static extern unsafe int cmmLmxResume(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] int IsClearQue);

        // 4. cmmLmxEnd
        [DllImport(dll, EntryPoint = "cmmLmxEnd")]
        public static extern unsafe int cmmLmxEnd(
            [MarshalAs(UnmanagedType.I4)] int LmIndex);

        // 5. cmmLmxSetSeqMode
        [DllImport(dll, EntryPoint = "cmmLmxSetSeqMode")]
        public static extern unsafe int cmmLmxSetSeqMode(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int SeqMode);

        // 6. cmmLmxGetSeqMode
        [DllImport(dll, EntryPoint = "cmmLmxGetSeqMode")]
        public static extern unsafe int cmmLmxGetSeqMode(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] int SeqMode);

        // 7. cmmLmxSetNextItemId
        [DllImport(dll, EntryPoint = "cmmLmxSetNextItemId")]
        public static extern unsafe int cmmLmxSetNextItemId(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] int SeqId);

        // 8. cmmLmxGetNextItemId
        [DllImport(dll, EntryPoint = "cmmLmxGetNextItemId")]
        public static extern unsafe int cmmLmxGetNextItemId(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] ref int SeqId);

        // 9. cmmLmxSetNextItemParam
        [DllImport(dll, EntryPoint = "cmmLmxSetNextItemParam")]
        public static extern unsafe int cmmLmxSetNextItemParam(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int ParamIdx,
            [MarshalAs(UnmanagedType.I4)] int ParamData);

        // 10. cmmLmxGetNextItemParam
        [DllImport(dll, EntryPoint = "cmmLmxGetNextItemParam")]
        public static extern unsafe int cmmLmxGetNextItemParam(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int ParamIdx, 
            [MarshalAs(UnmanagedType.I4)] ref int ParamData);

        // 11. cmmLmxGetRunItemParam
        [DllImport(dll, EntryPoint = "cmmLmxGetRunItemParam")]
        public static extern unsafe int cmmLmxGetRunItemParam(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] int ParamIdx, 
            [MarshalAs(UnmanagedType.I4)] ref int ParamData);

        // 12. cmmLmxGetRunItemStaPos
        [DllImport(dll, EntryPoint = "cmmLmxGetRunItemStaPos")]
        public static extern unsafe int cmmLmxGetRunItemStaPos(
            [MarshalAs(UnmanagedType.I4)] int LmIndex,
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double Position);

        // 13. cmmLmxGetRunItemTargPos
        [DllImport(dll, EntryPoint = "cmmLmxGetRunItemTargPos")]
        public static extern unsafe int cmmLmxGetRunItemTargPos(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int Axis, 
            [MarshalAs(UnmanagedType.R8)] ref double Position);

        // 14. cmmLmxGetSts
        [DllImport(dll, EntryPoint = "cmmLmxGetSts")]
        public static extern unsafe int cmmLmxGetSts(
            [MarshalAs(UnmanagedType.I4)] int LmIndex, 
            [MarshalAs(UnmanagedType.I4)] int LmxStsId,
            [MarshalAs(UnmanagedType.I4)] ref int LmxStsVal);

        // pt motion
        // 1. cmmPtAddItem
        [DllImport(dll, EntryPoint = "cmmPtAddItem")]
        public static extern unsafe int cmmPtAddItem(
            [MarshalAs(UnmanagedType.I4)] int head_no, 
            PT_MOTION_TAB pt, 
            [MarshalAs(UnmanagedType.I4)] int final_flag);

        // 2. cmmPtAddItem2
        [DllImport(dll, EntryPoint = "cmmPtAddItem2")]
        public static extern unsafe int cmmPtAddItem2(
            [MarshalAs(UnmanagedType.I4)] int head_no, 
            [MarshalAs(UnmanagedType.I4)] int pointCnt, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] PosList, 
            [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.R8)] double[] TimeList,
            [MarshalAs(UnmanagedType.I4)] int final_flag);
        
        // 3. cmmPtIsDone
        [DllImport(dll, EntryPoint = "cmmPtIsDone")]
        public static extern unsafe int cmmPtIsDone(
            [MarshalAs(UnmanagedType.I4)] int groupID,
            [MarshalAs(UnmanagedType.R8)] double in_time);

        // 4. cmmPtSetHold
        [DllImport(dll, EntryPoint = "cmmPtSetHold")]
        public static extern unsafe int cmmPtSetHold(
            [MarshalAs(UnmanagedType.I4)] int groupId,
            [MarshalAs(UnmanagedType.I1)] bool isHold);

        // 5. cmmPtMsConfig
        [DllImport(dll, EntryPoint = "cmmPtMsConfig")]
        public static extern unsafe int cmmPtMsConfig(
            ref MOTION_CONFIG msConfig, 
            [MarshalAs(UnmanagedType.I4)] int ms_count);

        // 6. cmmPtHeadConfig
        [DllImport(dll, EntryPoint = "cmmPtHeadConfig")]
        public static extern unsafe int cmmPtHeadConfig(
            [MarshalAs(UnmanagedType.I4)] ref int headConfig,
            [MarshalAs(UnmanagedType.I4)] int head_count);

        // 7. cmmPtStop
        [DllImport(dll, EntryPoint = "cmmPtStop")]
        public static extern unsafe int cmmPtStop(
            [MarshalAs(UnmanagedType.I4)] int groupId);


        [DllImport(dll, EntryPoint = "cmmPtGetCurSeq")]
        public static extern unsafe int cmmPtGetCurSeq(
            [MarshalAs(UnmanagedType.I4)] int groupId);

        //public static void cmmHomeGetSpeedPattern()
        //{
        //    throw new NotImplementedException();
        //}
    }
}

