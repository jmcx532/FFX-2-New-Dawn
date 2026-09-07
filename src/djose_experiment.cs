/// <remarks>
///     Makes it easier to access the Level 5 Experiment fight..
///     
///     Sets the appropriate save flags after the Experiment uses it's death animation command.
/// </remarks>

namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class DjoseExperimentModule : FhModule
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_MsCommandExe(uint chr_id, int arg2, int arg3);
    public static FhMethodHandle<d_MsCommandExe> MsCommandExe
        => new(new FhMethodLocation("FFX-2.exe", 0x2402f0));

    public DjoseExperimentModule() { }

    public unsafe uint h_MsCommandExe(uint chr_id, int arg2, int arg3)
    {
        uint original_result = MsCommandExe.chain_from(h_MsCommandExe).fnptr!(chr_id, arg2, arg3);

        //Post-hook
        uint command_used = (uint)*(ushort*)(arg3 + 0xa4);

        // Experiment death animation command
        if (command_used == 0x4127)
        {
            FhUtil.set_at<ushort>(0x9FA294, 15); // Attack Assembly A quantity
            FhUtil.set_at<ushort>(0x9FA296, 15); // Attack Assembly S quantity
            FhUtil.set_at<ushort>(0x9FA298, 15); // Attack Assembly Z quantity

            FhUtil.set_at<ushort>(0x9FA29A, 15); // Defense Assembly A quantity
            FhUtil.set_at<ushort>(0x9FA29C, 15); // Defense Assembly S quantity
            FhUtil.set_at<ushort>(0x9FA29E, 15); // Defense Assembly Z quantity

            FhUtil.set_at<ushort>(0x9FA2A0, 15); // Defense Assembly A quantity
            FhUtil.set_at<ushort>(0x9FA2A2, 15); // Defense Assembly S quantity
            FhUtil.set_at<ushort>(0x9FA2A4, 15); // Defense Assembly Z quantity

        }

        return original_result;
    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return MsCommandExe.hook(this, h_MsCommandExe);

    }

}


