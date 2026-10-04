

/// <remarks>
///     Alters the behaviour of some magics.
/// </remarks>
namespace Fahrenheit.Mods.NewDawn;

/*
[FhLoad(FhGameId.FFX2)]
public partial class MagicPatchesModule : FhModule
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsSetDamage(uint arg1, uint arg2, uint arg3);
    public static FhMethodHandle<d_MsSetDamage> MsSetDamage =>
        new(new FhMethodLocation("FFX-2.exe", 0x21B150));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsSetDamageMotion(uint arg1, uint arg2, uint arg3);
    public static FhMethodHandle<d_MsSetDamageMotion> MsSetDamageMotion =>
        new(new FhMethodLocation("FFX-2.exe", 0x21B240));

    public MagicPatchesModule() { }

    public unsafe void h_MsSetDamageMotion(uint arg1, uint arg2, uint arg3)
    {
        uint  magic_id = FhUtil.get_at<uint>(0x96E400);
        uint* magic_addr_space_ptr = FhUtil.ptr_at<uint>(0x96E404);

        if (*magic_addr_space_ptr != 0xffffffff)
        {
            switch (magic_id)
            {
                // Moogle Beam (may not work)
                case 600:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x2ba11c), arg2, 0);
                    return;
                // Cactling Gun
                case 612:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x4651f4), arg2, 0);
                    return;
                // Blue Bullet: 1000 Needles
                case 638:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x4c2a8), arg2, 0);
                        return;
                // Hurt
                case 851:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x66fac), *(uint*)(*magic_addr_space_ptr + 0x63b44), 0);
                    return;
                //Pound
                case 979:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x159fd4), *(uint*)(*magic_addr_space_ptr + 0x156b64), 0);
                    return;
                //Swarm Swarm
                case 983:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x15a194), *(uint*)(*magic_addr_space_ptr + 0x156d24), 0);
                    return;
                //Maulwings
                case 991:
                    MsSetDamage.fnptr!(*(uint*)(*magic_addr_space_ptr + 0x164ee4), *(uint*)(*magic_addr_space_ptr + 0x161a74), 0);
                    return;
                default:
                    MsSetDamageMotion.chain_from(h_MsSetDamageMotion).fnptr!(arg1, arg2, arg3);
                    return;

            }
        }
        else
        {
            MsSetDamageMotion.chain_from(h_MsSetDamageMotion).fnptr!(arg1, arg2, arg3);
        }

    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return MsSetDamageMotion.hook(this, h_MsSetDamageMotion);

    }

}

*/
