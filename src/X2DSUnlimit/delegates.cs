
namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule
{
    /*
    //from main.cs
    
    //delegates - main hooks
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte MsGetSaveDressUpCount(int param_1, uint param_2);
    private static FhMethodHandle<MsGetSaveDressUpCount> _MsGetSaveDressUpCount =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20C730) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsAddSaveDreSphere(uint ds_id, int param_2);
    private static FhMethodHandle<MsAddSaveDreSphere> _MsAddSaveDreSphere =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20b260) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsGetSaveDreSphere(uint ds_id);
    private static FhMethodHandle<MsGetSaveDreSphere> _MsGetSaveDreSphere =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20c710) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TODVDFileReadNonBlock(int param_1, int param_2, int param_3);
    private static FhMethodHandle<TODVDFileReadNonBlock> _TODVDFileReadNonBlock =>
        new ( new FhMethodLocation("FFX-2.exe", 0x391610) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int kyGetResultPlateNum();
    private static FhMethodHandle<kyGetResultPlateNum> _kyGetResultPlateNum =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1eb2e0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int kyGetUsedPoint();
    private static FhMethodHandle<kyGetUsedPoint> _kyGetUsedPoint =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1eb480) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int kySetDefJobWindow(ushort param_1, ushort param_2, int param_3, int param_4, int param_5, int param_6);
    private static FhMethodHandle<kySetDefJobWindow> _kySetDefJobWindow =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1e5470) );

    // these 3 kyGetJobNum are used in Menus (at least)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint kyGetJobNum();
    private static FhMethodHandle<kyGetJobNum> _kyGetJobNum =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1ea7b0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint kyGetJobNum2();
    private static FhMethodHandle<kyGetJobNum2> _kyGetJobNum2 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1ea810) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint kyGetJobNum3();
    private static FhMethodHandle<kyGetJobNum3> _kyGetJobNum3 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1ea8b0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte kyGetCursorPoint(int param_1, int param_2);
    private static FhMethodHandle<kyGetCursorPoint> _kyGetCursorPoint =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1ea770) );

    // delegates for utility and sub-functions
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsCheckRange(int number, int lower_bound, int upper_bound);
    private static FhMethodHandle<MsCheckRange> _MsCheckRange =>
        new ( new FhMethodLocation("FFX-2.exe", 0x224CD0) );

    // these functions were hooked for debug/RE purposes - 08.06.26
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetSavePlate(uint param_1);
    private static FhMethodHandle<MsGetSavePlate> _MsGetSavePlate =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20cc00) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetSaveConfigChangeEffect();
    private static FhMethodHandle<MsGetSaveConfigChangeEffect> _MsGetSaveConfigChangeEffect =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20c650) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetRamConfigChangeEffect();
    private static FhMethodHandle<MsGetRamConfigChangeEffect> _MsGetRamConfigChangeEffect =>
        new ( new FhMethodLocation("FFX-2.exe", 0x225c90) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void kyEquipStart(int param_1);
    private static FhMethodHandle<kyEquipStart> _kyEquipStart =>
        new ( new FhMethodLocation("FFX-2.exe", 0x75B900) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int kySetDefPlateWindow(short param_1, short param_2, int param_3, int param_4, int param_5);
    private static FhMethodHandle<kySetDefPlateWindow> _kySetDefPlateWindow =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1e5550) );


    // delegates
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint kyIsUsedPoint(uint param_1, uint param_2);
    private static FhMethodHandle<kyIsUsedPoint> _kyIsUsedPoint =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1EB9E0) );// 5eb9e0

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuMakeJobList(int param_1);
    private static FhMethodHandle<TOMenuMakeJobList> _TOMenuMakeJobList =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378B00) ); //778b00

    // Main delegate 2
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuMakeJobAbilityList(uint param_1, uint param_2);
    private static FhMethodHandle<TOMenuMakeJobAbilityList> _TOMenuMakeJobAbilityList =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3788d0) );

    // GG Icon fix for LG/Freelancer
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void kyAddPoint3D(int param_1, int param_2, int icon, uint param_4);
    private static FhMethodHandle<kyAddPoint3D> _kyAddPoint3D =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1E7580) ); //5e7580

    // from abilities_menu.cs
    // Main delegate 1
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetJobAbilityList(int chr_id, int job_id, int* param_3, int param_4);
    private static FhMethodHandle<MsGetJobAbilityList> _MsGetJobAbilityList =>
        new ( new FhMethodLocation("FFX-2.exe", 0x229af0) );

    //sub-function delegates
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetChrNum(uint param_1); //60c1a0
    private static FhMethodHandle<MsGetChrNum> _MsGetChrNum =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20C1A0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsCalcChrLevel(byte p1);//617140
    private static FhMethodHandle<MsCalcChrLevel> _MsCalcChrLevel =>
        new ( new FhMethodLocation("FFX-2.exe", 0x217140) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate Job* MsGetRomJob(uint chr_id, uint job_id, byte* out_data_end);//61deb0
    private static FhMethodHandle<MsGetRomJob> _MsGetRomJob =>
        new ( new FhMethodLocation("FFX-2.exe", 0x21DEB0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool MsBtlMonsterSaveNumCheck(uint p1); //610440
    private static FhMethodHandle<MsBtlMonsterSaveNumCheck> _MsBtlMonsterSaveNumCheck =>
        new ( new FhMethodLocation("FFX-2.exe", 0x210440) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsCheckAbility(uint p1, int p2, int p3); //629280
    private static FhMethodHandle<MsCheckAbility> _MsCheckAbility =>
        new ( new FhMethodLocation("FFX-2.exe", 0x229280) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint FUN_6294f0(uint p1, int p2, int p3); //6294f0
    private static FhMethodHandle<FUN_6294f0> _FUN_6294f0 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x2294f0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte MsCheckLearnCommand(byte p1, int p2); //635790
    private static FhMethodHandle<MsCheckLearnCommand> _MsCheckLearnCommand =>
        new ( new FhMethodLocation("FFX-2.exe", 0x235790) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetSaveCommand(uint p1, uint p2); //60c500
    private static FhMethodHandle<MsGetSaveCommand> _MsGetSaveCommand =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20c500) );

    //sub-function delegates
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort MsGetSaveAp(uint p1, uint p2);//60c2e0
    private static FhMethodHandle<MsGetSaveAp> _MsGetSaveAp =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20C2E0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort MsGetSaveNeedAp(byte p1, uint p2);//60cb20
    private static FhMethodHandle<MsGetSaveNeedAp> _MsGetSaveNeedAp =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20CB20) );

    // also used in custom ability menus
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort MsGetSaveLearn(uint param_1, uint param_2); // 60ca70
    private static FhMethodHandle<MsGetSaveLearn> _MsGetSaveLearn =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20CA70) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsSetSaveLearn(uint param_1, uint param_2, ushort param_3); // 60e270
    private static FhMethodHandle<MsSetSaveLearn> _MsSetSaveLearn =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20E270) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate ushort MsGetJobNumBasic(uint param_1);//61de30;
    private static FhMethodHandle<MsGetJobNumBasic> _MsGetJobNumBasic =>
        new ( new FhMethodLocation("FFX-2.exe", 0x21DE30) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsBtlPlayerSaveNumCheck(byte param_1);//610460
    private static FhMethodHandle<MsBtlPlayerSaveNumCheck> _MsBtlPlayerSaveNumCheck =>
        new ( new FhMethodLocation("FFX-2.exe", 0x210460) );

    //Main Delegate 3
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuStartJobAbilityWindow(uint param_1, uint param_2);
    private static FhMethodHandle<TOMenuStartJobAbilityWindow> _TOMenuStartJobAbilityWindow =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378f70) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOGetSaveJobName(uint param_1);
    private static FhMethodHandle<TOGetSaveJobName> _TOGetSaveJobName =>
        new ( new FhMethodLocation("FFX-2.exe", 0x394600) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetSaveJob(uint chr_id);
    private static FhMethodHandle<MsGetSaveJob> _MsGetSaveJob =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20C950) );

    // AltChr delegates
    //main function
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint MsGetChrID(uint chr_id);
    private static FhMethodHandle<MsGetChrID> _MsGetChrID =>
        new ( new FhMethodLocation("FFX-2.exe", 0x224f90) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsSetRamMotionChrData(int chr_id, uint job_id);//627a20
    private static FhMethodHandle<MsSetRamMotionChrData> _MsSetRamMotionChrData =>
        new ( new FhMethodLocation("FFX-2.exe", 0x227A20) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    //62ab30 -  FUN_710026cc90? - btlSoundStreamNormal? -- using this to force alts's hurt SFX to play
    public unsafe delegate uint FUN_62AB30(uint chr_id, uint sound_id);
    private static FhMethodHandle<FUN_62AB30> _FUN_62AB30 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x22AB30) );

    [UnmanagedFunctionPointer(CallingConvention.ThisCall)]
    //534a70 - this function accessed the VoiceIDMapper.txt integer/string pointer for Yuna's hurt sound. Might use this to silence it?
    public unsafe delegate void FUN_534A70(int* param_1, int param_2, int param_3, int param_4, int param_5, int param_6, int* param_7, int* param_8, int* param_9);
    private static FhMethodHandle<FUN_534A70> _FUN_534A70 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x134A70) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int MsGetChr(uint chr_id);
    private static FhMethodHandle<MsGetChr> _MsGetChr =>
        new ( new FhMethodLocation("FFX-2.exe", 0x211450) );


    // added C# job name string implementation
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate byte* MsGetSaveChrName(int chr_id);
    private static FhMethodHandle<MsGetSaveChrName> _MsGetSaveChrName =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20c4a0) );

    // C# defined job help string crash prevention
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void kySetHelpJob2(uint job_id);
    private static FhMethodHandle<kySetHelpJob2> _kySetHelpJob2 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x1E59B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuSetHelpMes(int addr_of_txt_bytes);
    private static FhMethodHandle<TOMenuSetHelpMes> _TOMenuSetHelpMes =>
        new ( new FhMethodLocation("FFX-2.exe", 0x363970) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int FUN_6083B0(uint param_1);
    private static FhMethodHandle<FUN_6083B0> _FUN_6083B0 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x2083B0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOGetFaceIndex2(int param_1, uint param_2);
    private static FhMethodHandle<TOGetFaceIndex2> _TOGetFaceIndex2 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x393190) );

    // hooked to get VoiceIDMapper pointer -> AltChrs -> sound.cs
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MsBtlChrGetMem();
    private static FhMethodHandle<MsBtlChrGetMem> _MsBtlChrGetMem =>
        new ( new FhMethodLocation("FFX-2.exe", 0x20FE10) );

    // overwrite voiceline integers on spherechange
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOCtrlATBChr();
    private static FhMethodHandle<TOCtrlATBChr> _TOCtrlATBChr =>
        new ( new FhMethodLocation("FFX-2.exe", 0x35E2C0) );

    // Menu functionality - handle Ability Menu case  0x77762f - so correct ability name is displayed.
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_777270(uint param_1);
    private static FhMethodHandle<FUN_777270> _FUN_777270 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x377270) );

    // Used in Abilities 16x list, return if command is visible/available to be clicked on. for displaying already le arned or will learn message.
    // I'm interested in it's call from FFX-2.exe + 3773CE (FUN_00777270_7100424240)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate bool FUN_776EC0(uint param_1, int ability_slot);
    private static FhMethodHandle<FUN_776EC0> _FUN_776EC0 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x376EC0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuSetSaveLearn(byte param_1, uint param_2, int param_3);
    private static FhMethodHandle<TOMenuSetSaveLearn> _TOMenuSetSaveLearn =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378f40) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuSetMacroCommandType(int param_1, int param_2, byte param_3);
    private static FhMethodHandle<TOMenuSetMacroCommandType> _TOMenuSetMacroCommandType =>
        new ( new FhMethodLocation("FFX-2.exe", 0x396330) ); //796330

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOBtlGetComName(uint param_1);
    private static FhMethodHandle<TOBtlGetComName> _TOBtlGetComName =>
        new ( new FhMethodLocation("FFX-2.exe", 0x359FD0) ); //759fd0

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuSetMacroCommandValue(int param_1, int param_2, uint param_3);
    private static FhMethodHandle<TOMenuSetMacroCommandValue> _TOMenuSetMacroCommandValue =>
        new ( new FhMethodLocation("FFX-2.exe", 0x396360) ); //796360

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOGetMenuText(uint param_1);
    private static FhMethodHandle<TOGetMenuText> _TOGetMenuText =>
        new ( new FhMethodLocation("FFX-2.exe", 0x379250) ); //779250

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint SndSepPlaySimple(uint param_1);
    private static FhMethodHandle<SndSepPlaySimple> _SndSepPlaySimple =>
        new ( new FhMethodLocation("FFX-2.exe", 0x344760) ); //744760

    // Abilities menu 16x ability list rendering function
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_778160(int param_1, int param_2, int param_3, int param_4);
    private static FhMethodHandle<FUN_778160> _FUN_778160 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378160) );

    // ABilities - Job List percentage rendering
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOMenuGetJobLearnedRate(uint param_1, uint job_id);
    private static FhMethodHandle<TOMenuGetJobLearnedRate> _TOMenuGetJobLearnedRate =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3786b0) );

    // Abilities menu - misc 1, returns a dressphere ID - TOMenuNextJobList or TOMenuPrevJobList
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOMenuNextJobList();
    private static FhMethodHandle<TOMenuNextJobList> _TOMenuNextJobList =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378CD0) );

    // Abilities menu - misc 2, returns a dressphere ID - TOMenuNextJobList or TOMenuPrevJobList
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOMenuPrevJobList();
    private static FhMethodHandle<TOMenuPrevJobList> _TOMenuPrevJobList =>
        new ( new FhMethodLocation("FFX-2.exe", 0x378E80) );

    //  // Abilities menu - misc 3
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_777C60(int param_1);
    private static FhMethodHandle<FUN_777C60> _FUN_777C60 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x377C60) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOGetRomHelp(uint param_1);
    private static FhMethodHandle<TOGetRomHelp> _TOGetRomHelp =>
        new ( new FhMethodLocation("FFX-2.exe", 0x394500) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TkMenuSetHelpMessage(int param_1);
    private static FhMethodHandle<TkMenuSetHelpMessage> _TkMenuSetHelpMessage =>
        new ( new FhMethodLocation("FFX-2.exe", 0x365B20) );

    // thunk at 87d984
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int sprintf(byte* _Dest, byte* _Format);
    private static FhMethodHandle<sprintf> _sprintf =>
        new ( new FhMethodLocation("FFX-2.exe", 0x47d984) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOGetRtcValue(int param_1);
    private static FhMethodHandle<TOGetRtcValue> _TOGetRtcValue =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3730e0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOGetRtcRatio(int param_1);
    private static FhMethodHandle<TOGetRtcRatio> _TOGetRtcRatio =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3730c0) );

    //params need types verifying perhaps (were undefined4)
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int TOMenuDrawRotPlate(int param_1, int param_2, int param_3, int param_4, int param_5, int param_6, int param_7);
    private static FhMethodHandle<TOMenuDrawRotPlate> _TOMenuDrawRotPlate =>
        new ( new FhMethodLocation("FFX-2.exe", 0x379dc0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuOpenPkt();
    private static FhMethodHandle<TOMenuOpenPkt> _TOMenuOpenPkt =>
        new ( new FhMethodLocation("FFX-2.exe", 0x376910) );

    // Render Abilities Menu: Ability selected highlight
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_007B0F50(int param_1, int param_2, int param_3, int param_4, int colour);
    private static FhMethodHandle<FUN_007B0F50> _FUN_007B0F50 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3B0F50) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMkpShape2dMenu(int param_1, int param_2, int param_3, int param_4);
    private static FhMethodHandle<TOMkpShape2dMenu> _TOMkpShape2dMenu =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3B1250) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void FUN_007AE430(byte* param_1, int param_2, int param_3, int param_4, int param_5, int param_6, int param_7);
    private static FhMethodHandle<FUN_007AE430> _FUN_007AE430 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3AE430) );

    //was float10 return type
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double offsetAdjust_Y(int param_1);//7764e0
    private static FhMethodHandle<offsetAdjust_Y> _offsetAdjust_Y =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3764e0) );

    //was float10 return type
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate double offsetAdjust_X(int param_1);//7764c0
    private static FhMethodHandle<offsetAdjust_X> _offsetAdjust_X =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3764c0) );

    //function just returns
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOKickPacket();// 7add10
    private static FhMethodHandle<TOKickPacket> _TOKickPacket =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3add10) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMenuChangeFrameAccPlate(int param_1);
    private static FhMethodHandle<TOMenuChangeFrameAccPlate> _TOMenuChangeFrameAccPlate =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3ae7e0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FFX2_Set_UI_Scale(int param_1, int param_2);// 7a0060
    private static FhMethodHandle<FFX2_Set_UI_Scale> _FFX2_Set_UI_Scale =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3a0060) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint TOGetFFXLang();// 793010
    private static FhMethodHandle<TOGetFFXLang> _TOGetFFXLang =>
        new ( new FhMethodLocation("FFX-2.exe", 0x393010) );

    // param count mismatch, it's supposed to have 4 parameters. Called in 778160 with 3 args
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMkpComIconNameClut(uint param_1, int param_2, int param_3, int param_4);// 7ae9b0
    private static FhMethodHandle<TOMkpComIconNameClut> _TOMkpComIconNameClut =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3ae9b0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FFX2_Reset_UI_Scale();// 7a0030
    private static FhMethodHandle<FFX2_Reset_UI_Scale> _FFX2_Reset_UI_Scale =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3a0030) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte TkMenuGetTimer();// 764680
    private static FhMethodHandle<TkMenuGetTimer> _TkMenuGetTimer =>
        new ( new FhMethodLocation("FFX-2.exe", 0x364680) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FUN_007aeda0(int param_1, int param_2, int param_3);// 7aeda0
    private static FhMethodHandle<FUN_007aeda0> _FUN_007aeda0 =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3aeda0) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMkpResetFrameAcc();// 7b0a60
    private static FhMethodHandle<TOMkpResetFrameAcc> _TOMkpResetFrameAcc =>
        new ( new FhMethodLocation("FFX-2.exe", 0x3b0a60) );

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void TOMkpExPlateParam(int param_1, int param_2, int param_3, int param_4, int param_5);// 77aa20
    private static FhMethodHandle<TOMkpExPlateParam> _TOMkpExPlateParam =>
        new ( new FhMethodLocation("FFX-2.exe", 0x37aa20) );

    */


    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint id, byte* out_data_end);// 625160
    private static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225160));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate DSAbilityListDataAbilityArray* FUN_00778680();
    private static FhMethodHandle<FUN_00778680> _FUN_00778680 =>
        new(new FhMethodLocation("FFX-2.exe", 0x378680)); //778680
}
