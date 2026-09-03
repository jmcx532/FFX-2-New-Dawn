/* These functions originally used __aullshr.fnptr!() and Garment Grid data.
 * Adding Freelancer and Leblanc Goon adds non-vanilla values onto Garment Grid data.
 * The result of __aullshr.fnptr!() is often used for memory reads, and is on the stack.
 * These functions have been re-implemented to prevent crashes.
 */

namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule
{
    public uint h_MsGetSavePlate(uint param_1)
    {
        return FFX2.FhCall.MsGetSavePlate.chain_from(h_MsGetSavePlate).fnptr!(param_1);
    }

    /// <summary>
    /// Reads Garment Grid data, builds a list of unique dressphere IDs that are on the grid,.
    ///  Safety hook, this function originally used aullshr() with Garment Grid Data, adding FL/LG (ids: 32, 33) caused crashes
    /// </summary>
    /// <returns>Number of Unique dressphere IDs on current Garment Grid</returns>
    public unsafe uint h_kyGetUsedPoint()
    {

        int plate_data_base = FhUtil.get_at<int>(0x9f5fc0);
        byte current_plate_id = FhUtil.get_at<byte>(0x9f6d78);

        int current_plate_base = plate_data_base + (current_plate_id * 32);

        byte[] dses_on_grid = new byte[0x7f]; //

        // cycle over grid data slots, construct array of ds_ids on grid
        for (int i = 0; i < 32; i++)
        {
            byte ds_id = *(byte*)(current_plate_base + i);
            if (ds_id != 0)
            {
                //set array index of ds_id to ds_id, preserves ordering, handles duplicates
                dses_on_grid[ds_id] = ds_id;
            }
        }

        byte* unique_ds_on_grid_list = FhUtil.ptr_at<byte>(0x9f5fc4);
        byte count = 0;
        // Write list to memory
        for (int i = 0; i < dses_on_grid.Length; i++)
        {
            if (dses_on_grid[i] != 0)
            {
                unique_ds_on_grid_list[count] = dses_on_grid[i];
                count++;
            }

        }

        return count;
    }

    /// <summary>
    /// Safety hook, this function originally used aullshr() with Garment Grid Data, adding FL/LG (ids: 32, 33) caused crashes
    /// </summary>
    /// <param name="plate_id"></param>
    /// <param name="gg_slot"></param>
    /// <returns>Dressphere ID - in slot?</returns>
    public uint h_kyIsUsedPoint(uint plate_id, uint gg_slot)
    {
        return FFX2.FhCall.kyIsUsedPoint.chain_from(h_kyIsUsedPoint).fnptr!(plate_id, gg_slot);
    }

    /// <summary>
    /// Safety hook, this function reads game memory, messing with dressphere IDs (Freelancer/LG) in Garment Grid data can produce bad reads and crash the game
    /// </summary>
    /// <param name="chr_id"></param>
    /// <param name="plate_id"></param>
    /// <returns>Slot ID containing the character's current equipped/highlighted Dressphere</returns>
    public byte h_kyGetCursorPoint(uint chr_id, uint plate_id)
    {
        // should prevent crashes with GG slot in memory set to 32 (Freelancer)
        if (chr_id == 0x01000000) {
            return FFX2.FhCall.kyGetCursorPoint.chain_from(h_kyGetCursorPoint).fnptr!(0, plate_id);
        }

        byte slot = FFX2.FhCall.kyGetCursorPoint.chain_from(h_kyGetCursorPoint).fnptr!(chr_id, plate_id);
        return slot;
    }

    /// <summary>
    /// safety hook, this function in the original calls _aullshr.fnptr!() which takes in Garment Grid data manipulates it and the game can use this for memory reads. With new dressphere IDs, this causes issues.
    ///
    /// Populates the GG Inventory list, keeps a record of plates with spheres on them etc.
    /// </summary>
    /// <returns> Number of Garment Grids owned. </returns>
    public unsafe int h_kyGetResultPlateNum()
    {
        const int GARMENT_GRID_COUNT = 64;
        const int GRID_DATA_SIZE = 32;             // bytes of data per grid
        int plate_data_base = FhUtil.get_at<int>(0x9f5fc0); // base of Garment Grid Data
        byte* gg_obtain_list = FhUtil.ptr_at<byte>(0x9f5fd8); // DAT_00DF5fd8 is a list of which Garment Grids have been obtained. (Menu oriented, which ones to display in the list.

        int plate_id = 0;
        int num_plates_with_spheres = 0;
        int num_plates_owned = 0;
        do {

            int plateOwned = (int)h_MsGetSavePlate((uint)plate_id);
            if (0 < plateOwned) {

                for (int i = 0; i < GRID_DATA_SIZE; i++) {
                    // If Garment Grid has a dressphere set, increment counter and break from loop
                    if (*(byte*)(plate_data_base + (plate_id * 32) + i) != 0) {
                        num_plates_with_spheres++;
                        break;
                    }
                }

                *(byte*)(gg_obtain_list + num_plates_owned) = (byte)plate_id;
                num_plates_owned++;
            }

            plate_id = plate_id + 1;
        } while (plate_id < GARMENT_GRID_COUNT);

        FhUtil.set_at<int>(0x9f6d88, num_plates_with_spheres);
        return num_plates_owned;
    }

}
