/// <remarks>
///     Add more variance to damge number positions.
/// </remarks>

namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class DamageNumbersModule : FhModule
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_MsGetChrDamagePos(uint chr_id, int* ptr_pos_x, int* ptr_pos_y);
    public static FhMethodHandle<d_MsGetChrDamagePos> MsGetChrDamagePos
        => new(new FhMethodLocation("FFX-2.exe", 0x212660));

    public DamageNumbersModule() { }

    //static readonly Random rng = new Random();
    //static int GetOffset(int range) => rng.Next(-range, range + 1);

    const int NUMBER_SPACING = 30;

    static int slot;
    //static readonly int[] xSlots = { 0, -15, 15, -7, 7 };
    static readonly int[] ySlots = { 48, 40, 32, 24, 16, 8, 0 };

    public unsafe void h_MsGetChrDamagePos(uint chr_id, int* ptr_pos_x, int* ptr_pos_y)
    {

        // original function call
        MsGetChrDamagePos.chain_from(h_MsGetChrDamagePos).fnptr!(chr_id, ptr_pos_x, ptr_pos_y);

        // overwrite damage number position
        Chr* puVar1;
        chr_id = chr_id & 0xff;
        if (chr_id < 0x1f)
        {

            puVar1 = FFX2.FhCall.MsGetChr.fnptr!(chr_id);
            int chr_addr = (int)(puVar1);
            
            
            if (ptr_pos_x != (int*)0x0)
            {
                //*ptr_pos_x = *(int*)(chr_addr + 0x17ac) + GetOffset(50);
                *ptr_pos_x = *(int*)(chr_addr + 0x17ac);// + xSlots[slot++ % xSlots.Length];
            }
            if (ptr_pos_y != (int*)0x0)
            {
                //*ptr_pos_y = *(int*)(chr_addr + 0x17b0) + GetOffset(20);
                *ptr_pos_y = *(int*)(chr_addr + 0x17b0) + ySlots[slot++ % ySlots.Length];
                //*ptr_pos_y = *(int*)(chr_addr + 0x17b0) + y_offset;
            }
        }
        return;

    }

    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return MsGetChrDamagePos.hook(this, h_MsGetChrDamagePos);

    }

}


