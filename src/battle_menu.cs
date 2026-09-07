namespace Fahrenheit.Mods.NewDawn;

[StructLayout(LayoutKind.Sequential, Size = 4)]
public struct SomeEntry
{
    public byte id;
    public byte opcode;
    public ushort pad;
}

[StructLayout(LayoutKind.Sequential, Size = 0x1c)]
public struct ComInfo
{
    public int com_id;
    public int e1;
    public int e2;
    public int flow_system;
    public int e4;
    public int e5;
    public int e6;
}

[FhLoad(FhGameId.FFX2)]
public partial class BattleMenuModule : FhModule
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint arg1, byte** arg2);
    private static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225160));

    // Re-review
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOBtlDrawComSet2(int param_1, int param_2, uint chr_id, uint param_4, uint cmd_id, uint param_6);
    public static FhMethodHandle<d_TOBtlDrawComSet2> TOBtlDrawComSet2
        => new(new FhMethodLocation("FFX-2.exe", 0x356BC0));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate uint d_TOBtlGetComInfo(uint chr_id, uint com_id, ComInfo* com_info);
    public static FhMethodHandle<d_TOBtlGetComInfo> TOBtlGetComInfo
        => new(new FhMethodLocation("FFX-2.exe", 0x359EA0));

    // Re-review
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOMkpValueRightPackRGBA(uint number, int ftol2_result, int ftol2_result2, uint rgba);
    public static FhMethodHandle<d_TOMkpValueRightPackRGBA> TOMkpValueRightPackRGBA
        => new(new FhMethodLocation("FFX-2.exe", 0x3B1F10));

    // Re-review
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_TOMkpEasyMesFontLClutChrName(byte* ptr_text, float param_2, float param_3, uint param_4);
    public static FhMethodHandle<d_TOMkpEasyMesFontLClutChrName> TOMkpEasyMesFontLClutChrName
        => new(new FhMethodLocation("FFX-2.exe", 0x3AEC40));

    // Re-review
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int d_TOAdpMesFontLXYZClutTypeRGBAChangeFontType(uint ppkt, int param_2, byte* ptr_text, float param_4, float param_5, uint param_6, int param_7, int param_8, byte r, byte g, byte b,
          byte a, byte param_13);
    public static FhMethodHandle<d_TOAdpMesFontLXYZClutTypeRGBAChangeFontType> TOAdpMesFontLXYZClutTypeRGBAChangeFontType
        => new(new FhMethodLocation("FFX-2.exe", 0x3a7600));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_MsGetRamChrHP(uint chr_id);
    public static FhMethodHandle<d_MsGetRamChrHP> MsGetRamChrHP
        => new(new FhMethodLocation("FFX-2.exe", 0x225B10));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_MsGetRamChrMP(uint chr_id);
    public static FhMethodHandle<d_MsGetRamChrMP> MsGetRamChrMP
        => new(new FhMethodLocation("FFX-2.exe", 0x225B70));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_MsGetCommandMP(uint chr_id, uint cmd_id);
    public static FhMethodHandle<d_MsGetCommandMP> MsGetCommandMP
        => new(new FhMethodLocation("FFX-2.exe", 0x21acf0));

    // Re-review
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOMkpComIconRGBA(uint com_id, int param_2, int param_3, byte r, byte g, byte b, byte a);
    public static FhMethodHandle<d_TOMkpComIconRGBA> TOMkpComIconRGBA 
        => new(new FhMethodLocation("FFX-2.exe", 0x3aea20));

    // Re-review
    // param_8 (alpha?) -> 0x751951, SAR EAX, 0xc
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOMkpComIconNameClutRGBA(uint param_1, int param_2, int param_3, uint param_4, byte red, byte green, byte blue, int alpha);
    public static FhMethodHandle<d_TOMkpComIconNameClutRGBA> TOMkpComIconNameClutRGBA
        => new(new FhMethodLocation("FFX-2.exe", 0x3ae9f0));

    public BattleMenuModule() { }


    /// <summary>
    /// Draws icons and Command names in the Main battle Window, and the Escape Menu (NOT sub-menus)
    /// </summary>
    /// <param name="cmd_id"></param>
    /// <param name="param_2"></param>
    /// <param name="param_3"></param>
    /// <param name="param_4"></param>
    /// <param name="red"></param>
    /// <param name="green"></param>
    /// <param name="blue"></param>
    /// <param name="alpha"></param>
    public unsafe void h_TOMkpComIconNameClutRGBA(uint cmd_id, int param_2, int param_3, uint param_4, byte red, byte green, byte blue, int alpha)
    {

        uint btl_menu_chr_id = FhUtil.get_at<uint>(0xdb747c);
        Chr* chr_pointer = FFX2.FhCall.MsGetChr.fnptr!(btl_menu_chr_id);

        uint chr_addr = (uint)chr_pointer;

        ushort menu_to_reduce_wait1 = *(ushort*)(chr_addr + 0x5b0);
        ushort menu_to_reduce_wait2 = *(ushort*)(chr_addr + 0x5b2);
        ushort menu_to_reduce_wait3 = *(ushort*)(chr_addr + 0x5b4);
        ushort menu_to_reduce_wait4 = *(ushort*)(chr_addr + 0x5b6);


        // If a command style (e.g Black Magic has it's charge time (Vanilla) / recovery time (Turn-based mod) reduced, draw it's name in blue.
        if (cmd_id == menu_to_reduce_wait1 || cmd_id == menu_to_reduce_wait2 || cmd_id == menu_to_reduce_wait3 || cmd_id == menu_to_reduce_wait4)
        {
            TOMkpComIconNameClutRGBA.chain_from(h_TOMkpComIconNameClutRGBA).fnptr!(cmd_id, param_2, param_3, param_4, 30, 144, 255, alpha);
        }
        else
        {
            TOMkpComIconNameClutRGBA.chain_from(h_TOMkpComIconNameClutRGBA).fnptr!(cmd_id, param_2, param_3, param_4, red, green, blue, alpha);

        }

    }

    /// <summary>
    ///     Draws command icons, names and MP/item quantity in battle sub-menu.
    /// </summary>
    /// <param name="param_1"></param>
    /// <param name="param_2"></param>
    /// <param name="chr_id"></param>
    /// <param name="param_4"></param>
    /// <param name="cmd_id"></param>
    /// <param name="param_6"></param>
    public unsafe void h_TOBtlDrawComSet2(int param_1, int param_2, uint chr_id, uint param_4, uint cmd_id, uint param_6)
    {
        ushort uVar1;
        int pCVar3; //pCom
        uint num_to_draw;
        int iVar4;
        int iVar5;
        int iVar6;
        ComInfo com_info;
        int local_40;
        int local_3c;
        uint com_id;
        uint rgba_color;
        int local_30; // pCom
        //double local_2c;
        //byte local_21;
        byte local_21;
        //undefined8 concat_local_20;
        //double local_20;


        //some_entry local_18[3];
        SomeEntry[] seArray = new SomeEntry[3];

        com_id = cmd_id;
        if (cmd_id == 0xff)
        {
            return;
        }

        /*
        concat_local_20 = (double)CONCAT44((float)param_1, (undefined4)concat_local_20);
        local_40 = FUN_0087e0d0();
        concat_local_20 = (double)CONCAT44((float)param_2, (undefined4)concat_local_20);
        local_3c = FUN_0087e0d0();
        */

        //local_40 = (int)   ;
        //local_3c = (int)   ;

        //local_40 = (int)(3.0f * (float)0x97 + (float)param_1);
        local_40 = (int)(((float)param_6 * FhUtil.get_at<float>(0x962878)) + (float)param_1);
        local_3c = (int)(0.8f * 3.5f + (float)param_2);

        TOBtlGetComInfo.fnptr!(chr_id, cmd_id, &com_info);
        //local_21 = local_68.e5 != 0;
        local_21 = (byte)com_info.e5;
        if (local_21 != 0)
        {
            rgba_color = 0x804b4b4b;
        }
        else
        {
            rgba_color = 0x80808080;
        }

        switch (com_info.flow_system)
        {
            case 1:
            case 2:
            case 3:
            case 6:
            case 7:
            case 8:
            case 9:
            case 10:
            case 0xb:
            case 0xc:
            case 0xd:
                seArray[2].id = 2;
                seArray[2].opcode = 4;
                seArray[2].pad = 0;
                iVar4 = 3;
                break;
            case 4:
            case 5:
                seArray[2].id = 2;
                seArray[2].opcode = 2;
                seArray[2].pad = 0;
                iVar4 = 3;
                break;
            default:
                iVar4 = 2;
                break;
        }
        seArray[0].id = 0;
        seArray[0].opcode = 1;
        seArray[0].pad = 0;

        seArray[1].id = 0;
        seArray[1].opcode = 0x10;
        seArray[1].pad = 0;
        pCVar3 = _MsGetComData.fnptr!(cmd_id, (byte**)0);

        uint com_exp_data = *(uint*)(pCVar3 + 0x14);
        bool com_dark = (com_exp_data & 0x10000000) != 0;

        iVar6 = 0;
        iVar5 = param_1;
        local_30 = pCVar3;
        if (iVar4 != 0)
        {
            do
            {
                /*uVar1._0_1_ = local_18[iVar6].id ?;
                uVar1._1_1_ = local_18[iVar6].opcode ?;
                concat_local_20 = (double)(ulonglong)(CONCAT24(uVar1, (undefined4)concat_local_20) & 0xffffffffff);
                */
                switch (seArray[iVar6].opcode)
                {
                    case 1:
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x96287c), FhUtil.get_at<int>(0x962880));
                        TOMkpComIconRGBA.fnptr!(com_id, iVar5, param_2, 0x80, 0x80, 0x80, 0x80);
                        FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();

                        //concat_local_20 = (double)param_1;
                        //iVar5 = FUN_0087e0d0();
                        iVar5 = (int)((FhUtil.get_at<float>(0x96287c) * FhUtil.get_at<double>(0x84aeb0) + (float)param_1));
                        pCVar3 = local_30;
                        param_1 = iVar5;
                        break;
                    case 2:
                        num_to_draw = FhCall.MsGetSaveItemNum.fnptr!(com_id);

                        //local_2c = (double)param_1;
                        //iVar5 = FUN_0087e0d0();
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x962894), FhUtil.get_at<int>(0x962898));
                        //h_FFX2_Set_UI_Scale(_DAT_00d62894, _DAT_00d62898);
                        TOMkpValueRightPackRGBA.fnptr!(num_to_draw, local_40, local_3c, rgba_color);
                        FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();

                        //concat_local_20 = (double)CONCAT44((float)((short)((ulonglong)concat_local_20 >> 0x20) * 0xb), (undefined4)concat_local_20);
                        //local_2c = (double)iVar5;
                        //iVar5 = FUN_0087e0d0();

                        num_to_draw = num_to_draw & 0xff;
                        iVar5 = (int)((float)(num_to_draw * 0xb) * FhUtil.get_at<float>(0x962884) + iVar5);
                        pCVar3 = local_30;
                        param_1 = iVar5;
                        break;
                    case 4:
                        if (*(byte*)(pCVar3 + 0x26) != 0)
                        {
                            num_to_draw = MsGetCommandMP.fnptr!(chr_id, com_id);

                            //local_2c = (double)param_1;
                            //iVar5 = FUN_0087e0d0();
                            iVar5 = (int)(FhUtil.get_at<float>(0x96288c) * FhUtil.get_at<double>(0x82c0e0) + (double)param_1);
                            param_1 = iVar5;


                            //h_FFX2_Set_UI_Scale(_DAT_00d62894, _DAT_00d62898);
                            FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x962894), (int)FhUtil.get_at<int>(0x962898));

                            if (!com_dark)
                            {
                                TOMkpValueRightPackRGBA.fnptr!(num_to_draw, local_40, local_3c, rgba_color);
                            }

                            FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();

                            //concat_local_20 = (double)CONCAT44((float)((short)((ulonglong)concat_local_20 >> 0x20) * 0xb), (undefined4)concat_local_20);
                            //local_2c = (double)iVar5;
                            //iVar5 = FUN_0087e0d0();
                            //iVar5 = (float)((short)(local_20 >> 0x20) * 0xb) * FhUtil.get_at<float>(0x962884) + (double)iVar5;
                            num_to_draw = num_to_draw & 0xff;
                            
                            iVar5 = (int)((float)(num_to_draw*0xb) * FhUtil.get_at<float>(0x962884) + iVar5);

                            pCVar3 = local_30;
                            param_1 = iVar5;
                        }
                        break;
                    case 5:
                        num_to_draw = (uint)MsGetRamChrHP.fnptr!((byte)chr_id);
                        //h_FFX2_Set_UI_Scale(_DAT_00d62894, _DAT_00d62898);
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x962894), FhUtil.get_at<int>(0x962898));
                        TOMkpValueRightPackRGBA.fnptr!(num_to_draw, local_40, local_3c, rgba_color);
                        FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();

                        //concat_local_20 = (double)CONCAT44((float)((short)((ulonglong)concat_local_20 >> 0x20) * 0xb), (undefined4)concat_local_20);
                        //local_2c = (double)param_1;
                        //iVar5 = FUN_0087e0d0();
                        num_to_draw = num_to_draw & 0xff;
                        iVar5 = (int)((float)(num_to_draw * 0xb) * FhUtil.get_at<float>(0x962884) + iVar5);
                        
                        pCVar3 = local_30;
                        param_1 = iVar5;
                        break;
                    case 6:
                        num_to_draw = (uint)MsGetRamChrMP.fnptr!((byte)chr_id);
                        //FFX2_Set_UI_Scale(_DAT_00d62894, _DAT_00d62898);
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x962894), FhUtil.get_at<int>(0x962898));
                        TOMkpValueRightPackRGBA.fnptr!(num_to_draw, local_40, local_3c, rgba_color);
                        FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();
                        
                        //concat_local_20 = (double)CONCAT44((float)((short)((ulonglong)concat_local_20 >> 0x20) * 0xb), (undefined4)concat_local_20);
                        //local_2c = (double)param_1;
                        //iVar5 = FUN_0087e0d0();
                        num_to_draw = num_to_draw & 0xff;
                        iVar5 = (int)((float)(num_to_draw * 0xb) * FhUtil.get_at<float>(0x962884) + iVar5);
                        pCVar3 = local_30;

                        param_1 = iVar5;
                        break;
                    case 0x10:

                        /*         puVar3 = (ushort *)FUN_00625160(local_38,(byte *)&local_44);
                                    iVar5 = (uint)*puVar3 + local_44;
                         * 
                         */


                        byte* out_data_end_case0x10;

                        pCVar3 = _MsGetComData.fnptr!(com_id, &out_data_end_case0x10);
                        ushort* string_pointer = (ushort*)_MsGetComData.fnptr!(com_id, &out_data_end_case0x10);
                        byte* text_addr = (uint)*string_pointer + out_data_end_case0x10;


                        //FFX2_Set_UI_Scale(_DAT_00d62884, _DAT_00d62888);
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(FhUtil.get_at<int>(0x962884), FhUtil.get_at<int>(0x962888));

                        // local_20 = (double)CONCAT44((float)param_1,(undefined4)local_20)
                        uint* ppkt = FhUtil.ptr_at<uint>(0x18cfb04);
                        uint ppkt_val = *(uint*)(ppkt);

                        // Draw command names of those that consume HP in red
                        if (com_dark){
                            TOAdpMesFontLXYZClutTypeRGBAChangeFontType.fnptr!(ppkt_val, -1, text_addr, (float)param_1, (float)(param_2 + -1), 0x10, local_21, 0, 0xff, 0x40, 0x40, 0x80, 1);
                        }
                        else
                        {
                            TOMkpEasyMesFontLClutChrName.fnptr!(text_addr, (float)param_1, (float)(param_2 + -1), local_21);
                        }

                        

                        //h_TOMkpEasyMesFontLClutChrName(iVar5, (float)param_1, (float)(param_2 + -1), local_21);

                        //local_2c = (double)param_1;


                        //iVar5 = FUN_0087e0d0();
                        FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();
                        pCVar3 = local_30;
                        //param_1 = iVar5;
                        break;
                }
                iVar6 = iVar6 + 1;
            } while (iVar6 < iVar4);
        }
        return;

    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {
        return TOBtlDrawComSet2.hook(this, h_TOBtlDrawComSet2)
            && TOMkpComIconNameClutRGBA.hook(this, h_TOMkpComIconNameClutRGBA);
    }

}


