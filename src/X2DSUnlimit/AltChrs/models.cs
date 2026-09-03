namespace Fahrenheit.Mods.X2DSUnlimit;

/// <summary>
/// This file contains the function that swaps dressphere models when loading into battle.
/// Freelancer and Leblanc Goon use YRP's default model by default, what they're changed to can be set here.
/// </summary>

public partial class X2DSUnlimitModule : FhModule {

    //624f90 - used to overwrite the character model to be loaded in battle
    public unsafe uint h_MsGetChrID(uint chr_id) {
        //invoke as normal
        uint original_result = FFX2.FhCall.MsGetChrID.chain_from(h_MsGetChrID).fnptr!(chr_id);

        //get character battle info address, record original model
        Chr* chr = h_MsGetChr(chr_id);
        int chr_base_addr = (int)chr;
        int original_model = *(int*)(chr_base_addr + 4);
        ushort* party_ds_record_base = FhUtil.ptr_at<ushort>(0xa016f6);


        // Chr + is character model, Chr + 8 is character motion
        switch (original_model) {
            case 974:
                *(int*)(chr_base_addr + 4) = 0x1139;
                *(int*)(chr_base_addr + 8) = 0x1139;
                return chr_id;
            case 975:
                *(int*)(chr_base_addr + 4) = 0x113D;
                *(int*)(chr_base_addr + 8) = 0x113D;
                return chr_id;
            case 976:
                *(int*)(chr_base_addr + 4) = 0x113F;
                *(int*)(chr_base_addr + 8) = 0x113F;
                return chr_id;
            //Yuna Gunner model
            case 1:
                ushort y_ds_record = *(ushort*)(party_ds_record_base);
                // Freelancer replacement
                if ((y_ds_record) == 0x5020) {
                    *(int*)(chr_base_addr + 4) = 0x1083;
                    *(int*)(chr_base_addr + 8) = 0x1083;
                    return chr_id;
                }
                // Leblanc Goon Replacement
                if ((y_ds_record) == 0x5021) {
                    *(int*)(chr_base_addr + 4) = 0x1139;
                    *(int*)(chr_base_addr + 8) = 0x1139;
                    return chr_id;
                }
                return chr_id;
            // Rikku Thief model
            case 26:
                ushort r_ds_record = *(ushort*)(party_ds_record_base + (1 * 0x40));
                // Freelancer replacement
                if (r_ds_record == 0x5020) {
                    *(int*)(chr_base_addr + 4) = 0x1082;
                    *(int*)(chr_base_addr + 8) = 0x1082;
                    return chr_id;
                }
                // Leblanc Goon Replacement
                if (r_ds_record == 0x5021) {
                    *(int*)(chr_base_addr + 4) = 0x113D;
                    *(int*)(chr_base_addr + 8) = 0x113D;
                    return chr_id;
                }
                return chr_id;
            case 51:
                ushort p_ds_record = *(ushort*)(party_ds_record_base + (2 * 0x40));
                // Freelancer replacement
                if (p_ds_record == 0x5020) {
                    *(int*)(chr_base_addr + 4) = 0x1081;
                    *(int*)(chr_base_addr + 8) = 0x1081;
                    return chr_id;
                }
                // Leblanc Goon Replacement
                if (p_ds_record == 0x5021) {
                    *(int*)(chr_base_addr + 4) = 0x113F;
                    *(int*)(chr_base_addr + 8) = 0x113F;
                    return chr_id;
                }
                return chr_id;
            
            default:
                return original_result;
        }
    }

}
