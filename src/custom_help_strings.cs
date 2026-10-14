namespace Fahrenheit.Mods.NewDawn;

[FhLoad(FhGameId.FFX2)]
public partial class CustomHelpStringsModule : FhModule
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TOGetRomDataPkt
    {
        public nint name_loc;
        public nint help_loc;
        public uint icon;
        public uint mp_cost;
        public uint unk1; // always 0?
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint id, byte* arg2);
    public static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225130));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_TOGetRomData(int id, TOGetRomDataPkt* arg2);
    public static FhMethodHandle<d_TOGetRomData> TOGetRomData =>
        new(new FhMethodLocation("FFX-2.exe", 0x39b2a0));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_FUN_0035D100(uint id);
    public static FhMethodHandle<d_FUN_0035D100> FUN_0035D100 =>
        new(new FhMethodLocation("FFX-2.exe", 0x35d100));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_TOGetEasyMesWH(byte* param_1, float* param_2, float* param_3);
    public static FhMethodHandle<d_TOGetEasyMesWH> TOGetEasyMesWH =>
        new(new FhMethodLocation("FFX-2.exe", 0x392ca0));


    private static nint[] command_help_strings = new nint[7];
    private static string[] _command_help_strings = [
        "Attack one enemy, piercing certain kinds of armor.", // P. Attack
        "Press {BTN:33} repeatedly during allotted time for multiple hits. Hits have a chance to restore MP.", // Trigger Happy
        "Strike quickly with reduced recovery time.", // Quick Shot
        "Restore MP and raise the user's Strength and Accuracy.", // Nonpareil
        "Boost offenses at the cost of defense.", // Eclipse
        "Restore MP and raise the user's Magic.", // Focus
        "Restore MP and raise the user's Strength.", // Hone Edge
    ];

    public unsafe CustomHelpStringsModule() {
        
        // TODO: Remove the IMPLICIT_CJK_EXTENSION flag once names are fully translated
        for (int i = 0; i < command_help_strings.Length; i++)
        {
            ReadOnlySpan<byte> com_help_utf8 = Encoding.UTF8.GetBytes(_command_help_strings[i]);
            int com_help_len = FhEncoding.compute_encode_buffer_size(com_help_utf8, flags: FhEncodingFlags.IMPLICIT_CJK_EXTENSION);
            void* help_ptr = NativeMemory.AllocZeroed((nuint)com_help_len + 1);
            _ = FhEncoding.encode(com_help_utf8, new(help_ptr, com_help_len), flags: FhEncodingFlags.IMPLICIT_CJK_EXTENSION);
            command_help_strings[i] = (nint)help_ptr;
        }
    }

    public unsafe int h_MsGetComData(uint id, byte* arg2) {
        return _MsGetComData.chain_from(h_MsGetComData).fnptr!(id, arg2);
    }
        
    public unsafe void h_TOGetEasyMesWH(byte* param_1, float* param_2, float* param_3)
    {
        TOGetEasyMesWH.chain_from(h_TOGetEasyMesWH).fnptr!(param_1, param_2, param_3);
    }

    /// <summary>
    ///    Enables custom help strings in battle.
    /// </summary>
    /// <param name="id"></param>
    public unsafe void h_FUN_0035D100(uint id)
    {
        byte* ptr_help = null;
        uint out_data_base = 0;

        float* DAT_011b7cf0 = FhUtil.ptr_at<float>(0xdb7cf0);
        float* DAT_011b7cf4 = FhUtil.ptr_at<float>(0xdb7cf4);
        
        byte* DAT_011b7d00 = FhUtil.ptr_at<byte>(0xdb7d00);

        // buffer clear
        Span<byte> destination = new(DAT_011b7d00, 0x100);
        destination.Clear();

        // get original help string
        int iVar2 = h_MsGetComData(id, (byte*)&out_data_base);
        ptr_help = (byte*)((uint)*(ushort*)(iVar2 + 4) + out_data_base);

        // string alterations
        switch (id){
            case 0x302d:
            case 0x302f:
            case 0x30c3:
                ptr_help = (byte*)command_help_strings[0];
                break;
            case 0x3032:
                ptr_help = (byte*)command_help_strings[1];
                break;
            case 0x306D:
            case 0x31F5:
                ptr_help = (byte*)command_help_strings[2];
                break;
            case 0x3079:
                ptr_help = (byte*)command_help_strings[3];
                break;
            case 0x308B:
                ptr_help = (byte*)command_help_strings[4];
                break;
            case 0x30A3:
                ptr_help = (byte*)command_help_strings[5];
                break;
            case 0x3043:
                ptr_help = (byte*)command_help_strings[6];
                break;

        }

        //fn call
        TOGetEasyMesWH.chain_from(h_TOGetEasyMesWH).fnptr!(ptr_help, DAT_011b7cf0, DAT_011b7cf4);

        // buffer fill
        int length = 0;
        while (length < destination.Length && ptr_help[length] != 0)
            length++;

        if (length < destination.Length)
        {
            new ReadOnlySpan<byte>(ptr_help, length + 1).CopyTo(destination);
        }

        //
        int DAT_011b7ce0 = FhUtil.get_at<int>(0xdb7ce0);
        if (DAT_011b7ce0 != 1)
        {
            FhUtil.set_at<int>(0xdb7ce0, 1);
            FhUtil.set_at<int>(0xdb7ce8, 0);
        }
            
    }

    /// <summary>
    /// Enables custom help strings in Abilities menu.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="pkt"></param>
    public unsafe void h_TOGetRomData(int id, TOGetRomDataPkt* pkt)
    {
        uint out_data_base = 0;
        ushort* puVar4;


        if((id >> 0xc & 0xfff) == 3)
        {
            puVar4 = (ushort*)h_MsGetComData((uint)id, (byte*)&out_data_base);
            int com_addr = (int)puVar4;
            pkt->name_loc = (nint)(*puVar4 + out_data_base);
            pkt->help_loc = (nint)(puVar4[2] + out_data_base);
            pkt->icon = *(byte*)(com_addr + 0x77);
            pkt->mp_cost = *(byte*)((int)puVar4 + 0x26);
            pkt->unk1 = 0;

            // string alterations
            switch (id)
            {
                case 0x302d:
                case 0x302f:
                case 0x30c3:
                    pkt->help_loc = command_help_strings[0];
                    break;
                case 0x3032:
                    pkt->help_loc = command_help_strings[1];
                    break;
                case 0x306D:
                case 0x31F5:
                    pkt->help_loc = command_help_strings[2];
                    break;
                case 0x3079:
                    pkt->help_loc = command_help_strings[3];
                    break;
                case 0x308B:
                    pkt->help_loc = command_help_strings[4];
                    break;
                case 0x30A3:
                    pkt->help_loc = command_help_strings[5];
                    break;
                case 0x3043:
                    pkt->help_loc = command_help_strings[6];
                    break;

            }

            return;
        }
        else
        {
            TOGetRomData.chain_from(h_TOGetRomData).fnptr!(id, pkt);
        }
           
    }

    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {
        return _MsGetComData.hook(this, h_MsGetComData)
            && FUN_0035D100.hook(this, h_FUN_0035D100)
            && TOGetEasyMesWH.hook(this, h_TOGetEasyMesWH)
            && TOGetRomData.hook(this, h_TOGetRomData);
    }

}


