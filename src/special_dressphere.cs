/// <remarks>
///     Special dresspheres now receive a stat bonus to Agility, Accuracy, Evasion and Luck
///     in addition to the other stats which receive stat bonuses based on the number of slots
///     in a Garment Grid.
///     Support units start with x MP as expected by the AP system. YRP's carries over.
///     Ragnarok's MP gain boost sill applies to YRP, as with other Acc
/// </remarks>

namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class SpecialDressphereModule : FhModule
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsSetSaveParam(uint chr_id);
    public static FhMethodHandle<d_MsSetSaveParam> MsSetSaveParam =>
        new(new FhMethodLocation("FFX-2.exe", 0x20E300));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate Plate* d_MsGetRomPlate(uint plate_id, byte* out_data_end);
    public static FhMethodHandle<d_MsGetRomPlate> MsGetRomPlate =>
        new(new FhMethodLocation("FFX-2.exe", 0x21DF80));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate PlySave* d_MsGetSavePlayerPtr(uint chr_id);
    public static FhMethodHandle<d_MsGetSavePlayerPtr> MsGetSavePlayerPtr =>
        new(new FhMethodLocation("FFX-2.exe", 0x20cc40));


    public SpecialDressphereModule() { }

    /// <remarks>
    ///     This does correctly set Special Dressphere stats in battle.
    /// </remarks>
    public unsafe void h_MsSetSaveParam(uint chr_id)
    {
        MsSetSaveParam.chain_from(h_MsSetSaveParam).fnptr!(chr_id);

        uint dressphere_id = FFX2.FhCall.MsGetSaveJob.fnptr!(chr_id);

        if (0x500F <= dressphere_id && dressphere_id <= 0x5017)
        {
            PlySave* ply_save = MsGetSavePlayerPtr.fnptr!(chr_id);
            //PlySave ply_save = *(PlySave*)ply_save_base;

            Plate equipped_gg = *(Plate*)(MsGetRomPlate.fnptr!(ply_save->equipped_plate, (byte*)(0)));

            ply_save->agility = (byte)FhCall.MsCheckRange.fnptr!((((equipped_gg.bonus * 3) + 25) * ply_save->agility / 25 ), 1, 255);
            ply_save->accuracy = (byte)FhCall.MsCheckRange.fnptr!((((equipped_gg.bonus * 3) + 25) * ply_save->accuracy / 25), 1, 255);
            ply_save->evasion = (byte)FhCall.MsCheckRange.fnptr!((((equipped_gg.bonus * 3) + 25) * ply_save->evasion / 25), 1, 255);
            ply_save->luck = (byte)FhCall.MsCheckRange.fnptr!((((equipped_gg.bonus * 3) + 25) * ply_save->luck / 25), 1, 255);

        }
    }


    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return MsSetSaveParam.hook(this, h_MsSetSaveParam);

    }

}


