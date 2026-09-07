
namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule
{
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint id, byte* out_data_end);// 625160
    private static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225160));

    // used in bluebullet.cs
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate DSAbilityListDataAbilityArray* FUN_00778680();
    private static FhMethodHandle<FUN_00778680> _FUN_00778680 =>
        new(new FhMethodLocation("FFX-2.exe", 0x378680)); //778680
}
