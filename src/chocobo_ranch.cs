/// <remarks>
///     Makes it easier to access the Ruin Depths section of the Chocobo Ranch.
///     
///     Sets the appropriate save flags at the beginning of the Yojimbo fight in
///     the Cavern of the Stolen Fayth.
/// </remarks>

namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class ChocoboRanchModule : FhModule
{

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsBattleExe(uint arg1, uint arg2, uint arg3, uint arg4);
    public static FhMethodHandle<d_MsBattleExe> MsBattleExe =>
        new(new FhMethodLocation("FFX-2.exe", 0x2076F0));

    public ChocoboRanchModule() { }

    public unsafe void h_MsBattleExe(uint arg1, uint arg2, uint arg3, uint arg4)
    {
        MsBattleExe.chain_from(h_MsBattleExe).fnptr!(arg1, arg2, arg3, arg4);

        // current encounter is ffx-2.exe+9f9216
        byte* current_encounter_string = FhUtil.ptr_at<byte>(0x9f9216);

        Span<byte> buf = stackalloc byte[40];
        // read ability bytes into buffer
        int len = 0;
        for (int i = 0; i < 11; i++)
        {
            byte b = current_encounter_string[i];
            if (b == 0) break;
            buf[len++] = b;
        }

        //Decoding isn;t necessary, is ASCII already
        string encounter_string = Encoding.ASCII.GetString(buf.Slice(0, len));

        if (encounter_string == "nagi05_229")
        {
            // Set owned chocobo quantity to 5
            FhUtil.set_at<byte>(0x9fa1f7, 5);

            for (int i = 0; i < 5; i++)
            {
                // Set chocobo Current levels
                FhUtil.set_at<byte>(0x9fa1f8 + i, 5);

                // Set chocobo Max levels
                FhUtil.set_at<byte>(0x9fa206 + i, 5);

                // Set chocobo Natures
                FhUtil.set_at<byte>(0x9fa21c + i, 1);

                // Set chocobo Heart Values
                FhUtil.set_at<byte>(0x9fa22a + i, 100);

                // Set successful dispatches at each level
                FhUtil.set_at<byte>(0x9f9997 + i, 5);

            }

        }

    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return MsBattleExe.hook(this, h_MsBattleExe);

    }

}


