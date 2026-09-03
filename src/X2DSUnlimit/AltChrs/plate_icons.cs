namespace Fahrenheit.Mods.X2DSUnlimit;
public partial class X2DSUnlimitModule : FhModule {

    /// <summary>
    /// Fix Freelancer/Leblanc Goon showing no icon on Garment Grids
    /// </summary>
    /// <param name="grid_x"></param> - uses special co-ordinate system, centered on center of Garment Grid
    /// <param name="grid_y"></param> - ditto
    /// <param name="icon"></param> - icon number
    /// <param name="param_4"></param>
    public void h_kyAddPoint3D(int grid_x, int grid_y, int icon, uint param_4) {
        /* Icon map (param_3_
     * 1,2 -> Red/Green Gate
     * 3,4
     * 5,6 -> (5: gate background orb, 6: used as bg for some Dressspheres)
     * 7,14 ->, Gunner/Songstress
     * 8, -> gun mage
     * 21, 22 -> Psychic/Festivalist
     * 23, 24, 25 -> Floral Fallal, Machina Maw, Full Throttle
     * 26, 27 -> Blueflash/pulsing, Yellow flash/pulsing
     * 28,29,30 -> nope
     * 99 -> Full Throttle
     */

        if (icon == 38) // Change invalid Freelancer icon
        {
            FFX2.FhCall.kyAddPoint3D.chain_from(h_kyAddPoint3D).fnptr!(grid_x, grid_y, 6, param_4); // draw base
            FFX2.FhCall.kyAddPoint3D.chain_from(h_kyAddPoint3D).fnptr!(grid_x, grid_y, 26, param_4); // draw blue pulsing
            return;
        }

        if (icon == 39) // Change invalid Leblanc Goon icon
        {
            FFX2.FhCall.kyAddPoint3D.chain_from(h_kyAddPoint3D).fnptr!(grid_x, grid_y, 6, param_4); // draw base
            FFX2.FhCall.kyAddPoint3D.chain_from(h_kyAddPoint3D).fnptr!(grid_x, grid_y, 27, param_4); // draw yellow pulsing
            return;
        }

        FFX2.FhCall.kyAddPoint3D.chain_from(h_kyAddPoint3D).fnptr!(grid_x, grid_y, icon, param_4);
    }

}

