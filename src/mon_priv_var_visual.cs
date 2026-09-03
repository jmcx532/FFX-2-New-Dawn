using Fahrenheit.Atel;

namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class MonPrivVarsModule : FhModule
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_0072e730(int param_1, int param_2);
    public static FhMethodHandle<d_FUN_0072e730> FUN_0072e730 =>
        new(new FhMethodLocation("FFX-2.exe", 0x32e730));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOMkpATBGauge(int param_1, int param_2, int param_3, float param_4, float param_5, uint param_6);
    public static FhMethodHandle<d_TOMkpATBGauge> TOMkpATBGauge =>
        new(new FhMethodLocation("FFX-2.exe", 0x3ae210));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int* d_TOAdpATBGauge(int* _ppkt, int param_1, int param_2, int param_3, float param_4, float param_5, uint param_6);
    public static FhMethodHandle<d_TOAdpATBGauge> TOAdpATBGauge =>
        new(new FhMethodLocation("FFX-2.exe", 0x3a0e30));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_TOMkpStdWindowXYWH(int param_1, int param_2, int param_3, int param_4, int param_5);
    public static FhMethodHandle<d_TOMkpStdWindowXYWH> TOMkpStdWindowXYWH =>
        new(new FhMethodLocation("FFX-2.exe", 0x3b1a00));

    

    public MonPrivVarsModule() { }


    // p1 being a basic worker address is uncertain. 
    // for X-2's Magus sister fight, with 0, 4, 0 get's Mindy's counter. Sandy's is 32 bytes after, and Cindy's is 32 bytes after that.
    // For single characters, just use 0, the correct var_num and 0. some_idx doesn't seem to change the result.
    public unsafe int GenericPrivVarGetter(int basic_worker_addr, int var_num, int some_idx)
    {
        int p1_final = 0;
        if (basic_worker_addr == 0)
        {
            p1_final = FhUtil.get_at<int>(0xa115a0);
        }
        else
        {
            p1_final = basic_worker_addr;
        }

        if (p1_final != 0)
        {

            int* param_1 = (int*)p1_final;
            int iVar3 = *(int*)(*param_1 + 0x14) + param_1[1];
            uint uVar1 = *(uint*)(iVar3 + var_num * 8);

            int p2_unmasked = (int)uVar1;

            int target_address = h_FUN_0072e730(p1_final, p2_unmasked & 0xffffff);

            uint uVar4 = *(ushort*)(iVar3 + 4 + var_num * 8);
            // some_idx = ((int)some_idx < 0) - 1 & some_idx;
            some_idx = (((some_idx < 0) ? 1 : 0) - 1) & some_idx;
            if ((int)uVar4 <= (int)some_idx)
            {
                some_idx = (int)uVar4 - 1;
            }

            int iVar2 = 0;
            switch (uVar1 >> 0x1c)
            {
                case 0:
                case 1:
                case 7:
                    iVar2 = 1;
                    break;
                case 2:
                case 3:
                    return some_idx * 2 + target_address;
                case 4:
                case 5:
                case 6:
                    return some_idx * 4 + target_address;
            }
            return iVar2 * some_idx + target_address;
        }
        else
        {
            return 0;
        }

    }

    public unsafe Chr* h_MsGetChr(uint chr_id)
    {
        return FFX2.FhCall.MsGetChr.chain_from(h_MsGetChr).fnptr!(chr_id);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="work"></param>
    /// <param name="priv_var_number"></param>
    /// <param name="param_3"></param>
    /// <returns>Address where the priv var is stored. </returns>
    public unsafe int h_FUN_0072e730(int param_1, int param_2)
    {
        return FUN_0072e730.chain_from(h_FUN_0072e730).fnptr!(param_1, param_2);
    }

    public void h_TOMkpStdWindowXYWH(int param_1, int param_2, int param_3, int param_4, int param_5)
    {

        //_logger.Info("Param_1 is: " + param_1.ToString()); // x position
        //_logger.Info("Param_2 is: " + param_2.ToString()); // y position
        //_logger.Info("Param_3 is: " + param_3.ToString()); // 
        //_logger.Info("Param_4 is: " + param_4.ToString()); // 
        //_logger.Info("Param_5 is: " + param_5.ToString()); // 

        TOMkpStdWindowXYWH.chain_from(h_TOMkpStdWindowXYWH).fnptr!(param_1, param_2, param_3, param_4, param_5);
    }

    public unsafe int* h_TOAdpATBGauge(int* _ppkt, int param_1, int param_2, int param_3, float param_4, float param_5, uint param_6)
    {
        return TOAdpATBGauge.chain_from(h_TOAdpATBGauge).fnptr!(_ppkt, param_1, param_2, param_3, param_4, param_5, param_6);
    }

    public unsafe void h_TOMkpATBGauge(int chr_id, int x, int y, float fill, float length, uint status)
    {
        //_logger.Info("Param_1 is: " + param_1.ToString()); // chr_id
        //_logger.Info("Param_2 is: " + param_2.ToString()); // seems to be position
        //_logger.Info("Param_3 is: " + param_3.ToString()); // seems to be position
        //_logger.Info("Param_4 is: " + param_4.ToString()); // fill
        //_logger.Info("Param_5 is: " + param_5.ToString()); // length
        //_logger.Info("Param_6 is: " + param_6.ToString()); // status: 5 fill, 256 full, 258 full+haste

        /*
        if (chr_id < 0xf)
        {
            return;
        }*/

        // current encounter is ffx-2.exe+9f9216
        byte* current_encounter_string = FhUtil.ptr_at<byte>(0x9f9216);

        Span<byte> buf = stackalloc byte[40];
        // read ability bytes into buffer
        int len = 0;
        for (int i = 0; i < 11; i++)
        {
            byte b = current_encounter_string[i];
            if (b == 0) break;
            buf[len++] = b;
        }

        //Decoding isn;t necessary, is ASCII already
        string encounter_string = Encoding.ASCII.GetString(buf.Slice(0, len));

        int btl_chr_pointer = FhUtil.get_at<int>(0xa0fbac);

        if (btl_chr_pointer != 0)
        {

            int enemy1_chr_base = (int)h_MsGetChr(0xf);
            int enemy1_title_x = *(int*)(enemy1_chr_base + 0x17b4);
            int enemy1_title_x_offset = 0;
            int enemy1_title_y = *(int*)(enemy1_chr_base + 0x17b8);
            int enemy1_title_y_offset = 0;
            int enemy1_count = 0;

            uint gauge_status = 3;

            bool draw_od_gauge = false;

            switch (encounter_string)
            {
                case "ikai09_227":
                    int anima_oblivion_counter_address = GenericPrivVarGetter(0, 2, 0);
                    //priv000c
                    enemy1_count = *(int*)anima_oblivion_counter_address;
                    enemy1_title_x_offset = -35;
                    draw_od_gauge = true;
                    break;

                case "klyt11_229":
                    int ifrit_counter_address = GenericPrivVarGetter(0, 2, 0);
                    //priv000c
                    enemy1_count = *(int*)ifrit_counter_address;
                    enemy1_title_x_offset = -30;
                    draw_od_gauge = true;
                    break;
                case "bsyt05_229":
                    int valefor_counter_address = GenericPrivVarGetter(0, 2, 0);
                    //priv000c
                    enemy1_count = *(int*)valefor_counter_address;
                    enemy1_title_x_offset = -25;
                    enemy1_title_y_offset = 150;
                    draw_od_gauge = true;
                    break;
                case "nagi05_229":
                    int yojimbo_counter_address = GenericPrivVarGetter(0, 3, 0);
                    //priv000c
                    enemy1_count = *(int*)yojimbo_counter_address;
                    enemy1_title_x_offset = -50;
                    draw_od_gauge = true;
                    break;
            }

            if (enemy1_count >= 100)
            {
                enemy1_count = 100;
                gauge_status = gauge_status + 256;
            }

            if (draw_od_gauge)
            {
                TOMkpATBGauge.chain_from(h_TOMkpATBGauge).fnptr!(0xf, enemy1_title_x + enemy1_title_x_offset, enemy1_title_y + enemy1_title_y_offset, (float)enemy1_count, 100.0f, gauge_status);
            }
            
        }

    }
        

        

    private string addr_string = "Address Here";
    private bool get_addr = false;

    private uint wkr_address = 0xDEADBEEF;
    private uint var_num = 0;
    private uint some_idx = 0;

    public unsafe override void render_imgui()
    {
        int btl_chr_pointer = FhUtil.get_at<int>(0xa0fbac);

        if (btl_chr_pointer != 0) {

            ImGui.Begin("726cd0 Tester");

            //string oblivion_count = "0";
            int* p1_as_ptr = FhUtil.ptr_at<int>((0xa115a0));
            int p1_as_int = FhUtil.get_at<int>(0xa115a0);



            unsafe
            {
                // address input
                fixed (uint* valuePtr = &wkr_address)
                fixed (byte* label = "Worker Address"u8)
                fixed (byte* format = "0x%08X"u8)
                {
                    ImGui.InputScalar(
                        label,
                        ImGuiDataType.U32,
                        valuePtr,
                        null,
                        null,
                        format,
                        ImGuiInputTextFlags.CharsHexadecimal);
                }

                // var num input
                fixed (uint* valuePtr = &var_num)
                fixed (byte* label = "Variable number"u8)
                fixed (byte* format = "0x%08X"u8)
                {
                    ImGui.InputScalar(
                        label,
                        ImGuiDataType.U32,
                        valuePtr,
                        null,
                        null,
                        format,
                        ImGuiInputTextFlags.CharsHexadecimal);
                }

                // index num input
                fixed (uint* valuePtr = &some_idx)
                fixed (byte* label = "Index"u8)
                fixed (byte* format = "0x%08X"u8)
                {
                    ImGui.InputScalar(
                        label,
                        ImGuiDataType.U32,
                        valuePtr,
                        null,
                        null,
                        format,
                        ImGuiInputTextFlags.CharsHexadecimal);
                }


                if (ImGui.Button("CustomVarGetterTest"))
                {
                    addr_string = GenericPrivVarGetter((int)wkr_address, (int)var_num, (int)some_idx).ToString("X");
                }

            }

            

            ImGui.Text(addr_string);
            ImGui.End();

        }
            
    }


    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return FUN_0072e730.hook(this, h_FUN_0072e730)
            && FFX2.FhCall.MsGetChr.hook(this, h_MsGetChr)
            && TOMkpATBGauge.hook(this, h_TOMkpATBGauge)
            && TOMkpStdWindowXYWH.hook(this, h_TOMkpStdWindowXYWH);
            
    }

}


