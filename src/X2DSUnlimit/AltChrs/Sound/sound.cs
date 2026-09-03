namespace Fahrenheit.Mods.X2DSUnlimit;

public struct MemoryWrite {
    public int Offset;
    public uint Value;
}

public partial class X2DSUnlimitModule : FhModule {

    nint system_01_addr;

    /// <summary>
    /// Retrieves the address of system_01.bin in memory.
    /// Will be used then to overwrite character voicelines
    /// </summary>
    public void h_MsBtlChrGetMem() {

        FFX2.FhCall.MsBtlChrGetMem.chain_from(h_MsBtlChrGetMem).fnptr!();
        system_01_addr = FhUtil.get_at<nint>(0x9F882C); 

    }

    public unsafe void WriteInt(nint address, uint value) {
        *(uint*)(address) = value;
    }

    // Usage: Overwrite voiceline integers is system_01.bin
    public void WriteVoicelines(uint chr_id, uint job_id) {

        MemoryWrite[] to_write;

        if (job_id == 0x5020) {
            switch (chr_id) {
                case 0:
                    to_write = FreelancerVoicelines.FreelancerWrites_yn;
                    break;
                case 1:
                    to_write = FreelancerVoicelines.FreelancerWrites_rk;
                    break;
                case 2:
                    to_write = FreelancerVoicelines.FreelancerWrites_pn;
                    break;
                default:
                    return;

            }
        }else if (job_id == 0x5021) {
            switch (chr_id) {
                case 0:
                    to_write = LeblancGoonVoicelines.LeblancGoonVL_yn;
                    break;
                case 1:
                    to_write = LeblancGoonVoicelines.LeblancGoonVL_rk;
                    break;
                case 2:
                    to_write = LeblancGoonVoicelines.LeblancGoonVL_pn;
                    break;
                default:
                    return;

            }
        }
        else {
            // to_write is null - return
            return;
        }

            foreach (var write in to_write)
            WriteInt(system_01_addr + write.Offset, System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(write.Value));
    }

    // Usage: Overwrite voiceline integers is system_01.bin - subset of voicelines (Not dressphere entry lines...)
    public unsafe void h_TOCtrlATBChr() {

        FFX2.FhCall.TOCtrlATBChr.chain_from(h_TOCtrlATBChr).fnptr!();

        byte chr_window_open = FhUtil.get_at<byte>(0xdb747c);
        Chr* chr = h_MsGetChr(chr_window_open);
        int chr_base = (int)chr;

        ushort dressphere = *(ushort*)(chr_base + 0x86e);

        WriteVoicelines(chr_window_open, dressphere);
    }


    //62ab30, 710026cc90 - btsSoundStreamNormal?
    // Usage: Play relevant character's SFX instead of YRP's
    public unsafe uint h_FUN_62AB30(uint chr_id, uint sound_id) {
        uint original_result = FFX2.FhCall.FUN_0062AB30.chain_from(h_FUN_62AB30).fnptr!(chr_id, sound_id);
        Chr* chr = h_MsGetChr(chr_id);
        int chr_base_addr = (int)chr;
        int chr_model = *(int*)(chr_base_addr + 4);

        //if player character model has been replaced and requested sfx is 11 (takes damage) (is sfx_num,not a VL integer), play hurt sound (Requires his bank 1313 to be loaded - by changing wep/w___.bin) (create w0019 and w0020.bin for Fl/LG, can copy and rename an existing one)
        if ( chr_id < 3 && sound_id == 11) {
            // Kimahri
            if (chr_model == 0x1139) {
                return 22313;
            }
            // Tidus
            if (chr_model == 0x113D) {
                return 22317;
            }
            // Seymour
            if (chr_model == 0x113F) {
                return 22319;
            }
        }

        return original_result;
    }




    /// <summary>
    /// 
    /// 534a70 - plays character IOP sound
    /// Usage: Mute YRPs SFX (hurt etc.)
    /// 
    /// </summary>
    /// <param name="param_1"></param> //Pointer to a pointer, to a pointer to fmodex.dll
    /// <param name="voice_integer"></param>
    /// <param name="param_3"></param>
    /// <param name="param_4"></param>
    /// <param name="param_5"></param> //Pointer to a pointer to fmodex.dll stuff
    /// <param name="param_6"></param>
    /// <param name="param_7"></param>
    /// <param name="param_8"></param>
    /// <param name="param_9"></param> //pointer to start of VoiceIDMapper.txt
    public unsafe void h_FUN_534A70(int* param_1, int voice_integer, int param_3, int param_4,/*FMODCHANNELINDEX*/ int param_5, int param_6, int* param_7, int* param_8, int* param_9) {
        
        Chr* y_chr = h_MsGetChr(0);
        Chr* r_chr = h_MsGetChr(1);
        Chr* p_chr = h_MsGetChr(2);

        int y_base_addr = (int)y_chr;
        int r_base_addr = (int)r_chr;
        int p_base_addr = (int)p_chr;

        bool y_in_vanilla_ds = *(short*)(y_base_addr + 0x86a) != 0x501D && *(short*)(y_base_addr + 0x86a) != 0x5020 && *(short*)(y_base_addr + 0x86a) != 0x5021;
        bool r_in_vanilla_ds = *(short*)(r_base_addr + 0x86a) != 0x501E && *(short*)(r_base_addr + 0x86a) != 0x5020 && *(short*)(r_base_addr + 0x86a) != 0x5021;
        bool p_in_vanilla_ds = *(short*)(p_base_addr + 0x86a) != 0x501F && *(short*)(p_base_addr + 0x86a) != 0x5020 && *(short*)(p_base_addr + 0x86a) != 0x5021;

        //switch statement to stop battle_iop lines playing when character model has been swapped - hurt sound, attack hya
        switch (voice_integer) {
            
            //Yuna's IOP lines
            case < 11: //0A 00 00 00 is Yuna's last IOP voiceline integer
                //if Yuna is in Freelancer /Leblanc Goon, break, return early to mute her IOP Sounds
                if (y_in_vanilla_ds){
                    break;
                }
                else {
                    return;
                }

            case < 21:
                if (r_in_vanilla_ds) {
                    break;
                }
                else {
                    return;
                }

            case < 32:
                if (p_in_vanilla_ds) {
                    break;
                }
                else {
                    return;
                }
            case 0x21: 
            case 0x24:
                    if (y_in_vanilla_ds) {
                    break;
                }
                else {
                    return;
                }
            case 0x22:
            case 0x25:
                if (r_in_vanilla_ds) {
                    break;
                }
                else {
                    return;
                }
            case 0x23:
            case 0x26:
                if (p_in_vanilla_ds) {
                    break;
                }
                else {
                    return;
                }
            default:
                _logger.Info("Voice integer is: " + voice_integer.ToString("X"));
                break;

        }

        FFX2.FhCall.FUN_00534A70.chain_from(h_FUN_534A70).fnptr!(param_1, voice_integer, param_3, param_4,/*FMODCHANNELINDEX*/ param_5, param_6, param_7, param_8, param_9);
    }

}
