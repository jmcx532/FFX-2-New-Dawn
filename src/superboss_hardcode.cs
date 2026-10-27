/// <remarks>
///     Implements buff stealing behaviour for Judgment.
/// </remarks>
namespace Fahrenheit.Mods.NewDawn;


[FhLoad(FhGameId.FFX2)]
public partial class SuperbossModule : FhModule
{

    private MonPrivVarsModule? _MonPrivVars;

    public SuperbossModule() { }

    public unsafe uint h_MsCommandComplete(uint chr_id, int param_2, int param_3)
    {
        uint result = FFX2.FhCall.MsCommandComplete.chain_from(h_MsCommandComplete).fnptr!(chr_id, param_2, param_3);

        int user_addr = (int)FFX2.FhCall.MsGetChr.fnptr!(chr_id);
        ushort last_used_command = *(ushort*)(user_addr + 0x870);
        ushort user_mon_id = *(ushort*)(user_addr + 0xe);
        byte mon_oversouled = *(byte*)(user_addr + 0x3a9);

        if (last_used_command == 0x4038 && user_mon_id == 0x1098)
        {
            uint paragon_target_addr;

            if (mon_oversouled == 1)
            {
                paragon_target_addr = (uint)_MonPrivVars!.GenericPrivVarGetter(0, 2, 0);
            }
            else
            {
                paragon_target_addr = (uint)_MonPrivVars!.GenericPrivVarGetter(0, 1, 0) + 144;
            }


            uint paragon_target = *(uint*)(paragon_target_addr);

            int tgt_addr = (int)FFX2.FhCall.MsGetChr.fnptr!(paragon_target);

            for (int i = 0; i < 14; i++)
            {

                if (*(sbyte*)(tgt_addr + 0x438 + i) > 0)
                {
                    *(sbyte*)(user_addr + 0x438 + i) = 5;
                    *(sbyte*)(user_addr + 0x4b4 + i) = 5;

                }

            }

        }

        return result;
    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return FFX2.FhCall.MsCommandComplete.hook(this, h_MsCommandComplete)
            && new FhModuleHandle<MonPrivVarsModule>(this).try_get_module(out _MonPrivVars);

    }

}
