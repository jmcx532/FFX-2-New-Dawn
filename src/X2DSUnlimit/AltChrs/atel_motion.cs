namespace Fahrenheit.Mods.X2DSUnlimit;

[FhLoad(FhGameId.FFX2)]
public class AtelMotionModule : FhModule {

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate uint d_Ch_GetSysMotionID(Actor* arg1, int arg2, uint atel_motion_num);
    public FhMethodHandle<d_Ch_GetSysMotionID> Ch_GetSysMotionID
        => new(new FhMethodLocation("FFX-2.exe", 0x2d1720));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsSetRamChrData();
    public FhMethodHandle<d_MsSetRamChrData> MsSetRamChrData
        => new(new FhMethodLocation("FFX-2.exe", 0x226f40));

    public unsafe Chr* h_MsGetChr(uint chr_id)
    {
        return FFX2.FhCall.MsGetChr.chain_from(h_MsGetChr).fnptr!(chr_id);
    }

    public unsafe void h_MsSetRamChrData()
    {
        MsSetRamChrData.chain_from(h_MsSetRamChrData).fnptr!();
        // Disable head movement when targeting for new dresspheres
        for (uint i = 0; i < 3; i++)
        {
            uint chr_addr = (uint)h_MsGetChr(i);
            ushort current_dressphere = *(ushort*)(chr_addr + 0x86a);

            if (current_dressphere > 0x501f)
            {
                *(byte*)(chr_addr + 0x2f0) = 0;
            }
        }

    }


    bool MotionLoggingEnabled = false;
    public unsafe uint h_Ch_GetSysMotionID(Actor* arg1, int arg2, uint atel_motion_num)
    {
        uint original_result = Ch_GetSysMotionID.chain_from(h_Ch_GetSysMotionID).fnptr!(arg1, arg2, atel_motion_num);

        // Logging
        if (MotionLoggingEnabled)
        {
            if (original_result != 0xffffffff)
            {
                Actor actor = *(Actor*)arg1;

                uint chr_id = actor.chr_id;

                if (chr_id < 3)
                {
                    _logger.Info("Ch_GetSysMotionID chr_id: " + chr_id.ToString()); //

                    //_logger.Info("Ch_GetSysMotionID arg1: " + arg1.ToString("X")); // Actor*
                    _logger.Info("Ch_GetSysMotionID arg2: " + arg2.ToString()); //
                    _logger.Info("Ch_GetSysMotionID arg3: " + atel_motion_num.ToString()); // MotionNum

                    _logger.Info("Ch_GetSysMotionID return result: " + original_result.ToString("X8"));
                }
                

            }
        }



        // In battle handling
        uint BtlChrPtr = FhUtil.get_at<uint>(0xa0fbac);
        if (BtlChrPtr != 0)
        {

            Actor actor = *(Actor*)arg1;

            ushort chr_enabled = actor.chr_enabled;
            uint chr_id = actor.chr_id;
            if (chr_id < 3 && chr_enabled == 1)
            {
                uint chr_base = (uint)h_MsGetChr(chr_id);
                ushort current_dressphere = *(ushort*)(chr_base + 0x86a);

                if (current_dressphere == 0x5020)
                {
                    switch (atel_motion_num)
                    {
                        // Fix Syndicate Sleep animations
                        case 24:
                            return Ch_GetSysMotionID.fnptr!(arg1, arg2, 160);
                        case 25:
                            return Ch_GetSysMotionID.fnptr!(arg1, arg2, 161);
                        // Fix Leblanc KOed, multi-party revive, magic cast softlock
                        case 74:
                            if (chr_id == 0)
                            {
                                return Ch_GetSysMotionID.fnptr!(arg1, arg2, 161);
                            }
                            break;
                        // Fix Logos Escape animation
                        case 80:
                            if(chr_id == 1)
                            {
                                return 0x10821036;
                            }
                            break;
                        case 81:
                            if (chr_id == 1)
                            {
                                return 0x10821036;
                            }
                            break;
                        
                    }

                }

            }
        }
        return original_result;
        
    }




    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {
        return Ch_GetSysMotionID.hook(this, h_Ch_GetSysMotionID)
            && FFX2.FhCall.MsGetChr.hook(this, h_MsGetChr)
            && MsSetRamChrData.hook(this, h_MsSetRamChrData);
    }

    public override void render_imgui()
    {

        ImGui.Begin("Ch_Motion logging");

        string label1 = MotionLoggingEnabled ? "Dbg Motion Logging: ON" : "Dbg Motion Logging: OFF";
        if (ImGui.Button(label1))
        {
            MotionLoggingEnabled = !MotionLoggingEnabled;
            
        }

        ImGui.End();
    }

    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info)
    {

    }

    public override void save_local_state(FileStream local_state_file)
    {
        
    }

}
