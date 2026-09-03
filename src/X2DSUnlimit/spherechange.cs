namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule
{

    /// <summary>
    /// This function is hooked to try and prevent crashes when switching to Freelancer in battle. (not just a lack of animation issue)
    /// Leblanc Goon is fine.
    /// See param_1 info for details on this functions 2 callers.
    /// </summary>
    /// <param name="param_1"></param> -  is 0x25 on spherechange (790c90), 0x12 on Tri/Y/V Menu open (71003fc90_761300)
    /// <param name="param_2"></param> - is a TOFaceIndexResult (790c90) - 
    /// <param name="param_3"></param> - P3 is a large number, possibly memory address
    public void h_TODVDFileReadNonBlock(int param_1, int param_2, int param_3)
    {

        if (param_1 == 0x25) // on spherechange
        {
            if (param_2 == 34)
            {
                //_logger.Info("Y enters Freelancer, Overriding param_2");
                FFX2.FhCall.TODVDFileReadNonBlock.chain_from(h_TODVDFileReadNonBlock).fnptr!(param_1, 17, param_3);
                return;
            }

            if (param_2 == 56)
            {
                //_logger.Info("R enters Freelancer, Overriding param_2");
                FFX2.FhCall.TODVDFileReadNonBlock.chain_from(h_TODVDFileReadNonBlock).fnptr!(param_1, 49, param_3);
                return;
            }

            if (param_2 == 78)
            {
                //_logger.Info("P enters Freelancer, Overriding param_2");
                FFX2.FhCall.TODVDFileReadNonBlock.chain_from(h_TODVDFileReadNonBlock).fnptr!(param_1, 64, param_3);
                return;
            }

        }

        FFX2.FhCall.TODVDFileReadNonBlock.chain_from(h_TODVDFileReadNonBlock).fnptr!(param_1, param_2, param_3);
        return;
    }

    // this function is hooked so the dressphere entered/exited magic animations are registered as having been seen already.
    public uint h_MsGetSaveDressUpCount(uint param_1, uint param_2)
    {

        return 77;
        /*
        //_logger.Info("Param_1 is: " + param_1.ToString());
        //_logger.Info("Param_2 is: " + param_2.ToString());
        byte original_result = FFX2.FhCall.MsGetSaveDressUpCount.chain_from(h_MsGetSaveDressUpCount).fnptr!(param_1, param_2);
        //_logger.Info("Return result is: " + original_result.ToString());

        if (original_result < 2)
        {
            //_logger.Info("Overiding return");
            return 77;
        }
        else
        {
            return original_result;
        }
        */
    }

    // read config dressphere animations setting
    public uint h_MsGetSaveConfigChangeEffect()
    {
        uint original_result = FFX2.FhCall.MsGetSaveConfigChangeEffect.chain_from(h_MsGetSaveConfigChangeEffect).fnptr!();
        //_logger.Info("Return result is: " + original_result.ToString());
        return original_result;
    }
    // read config dressphere animations setting
    public int h_MsGetRamConfigChangeEffect()
    {
        int original_result = FFX2.FhCall.MsGetRamConfigChangeEffect.chain_from(h_MsGetRamConfigChangeEffect).fnptr!();
        //_logger.Info("Return result is: " + original_result.ToString());
        return original_result;
    }

}
