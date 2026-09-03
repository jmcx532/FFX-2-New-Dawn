namespace Fahrenheit.Mods.X2DSUnlimit;
public partial class X2DSUnlimitModule : FhModule {

    public int h_TOGetFaceIndex2(uint chr_id, uint job_id) {

        /* // for logging purposes
        int original_result = FFX2.FhCall.TOGetFaceIndex2.chain_from(h_TOGetFaceIndex2).fnptr!(chr_id, job_id);
        _logger.Info("Param_1 is: " + chr_id.ToString());
        _logger.Info("Param_2 is: " + job_id.ToString());
        _logger.Info("Return result: " + original_result.ToString());
        return original_result;
        */

        // Freelancer Replacements
        if (chr_id == 0 && job_id == 0x501d)
        {
            return 261; // Kimahri
        }

        if (chr_id == 1 && job_id == 0x501e)
        {
            return 263; // Tidus
        }

        if (chr_id == 2 && job_id == 0x501f)
        {
            return 264; // Seymour
        }

        // Freelancer Replacements
        if (chr_id == 0 && job_id == 0x5020) {
            return 257; // Leblanc
        }

        if (chr_id == 1 && job_id == 0x5020) {
            return 256; // Logos
        }

        if (chr_id == 2 && job_id == 0x5020) {
            return 255; // Ormi
        }

        // Leblanc Goon Replacements
        if (chr_id == 0 && job_id == 0x5021) {
            return 261; // Kimahri
        }

        if (chr_id == 1 && job_id == 0x5021) {
            return 263; // Tidus
        }

        if (chr_id == 2 && job_id == 0x5021) {
            return 264; // Seymour
        }

        return FFX2.FhCall.TOGetFaceIndex2.chain_from(h_TOGetFaceIndex2).fnptr!(chr_id, job_id); // forces return of 0x52 which removes all portrait images
    }
}

