
namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule
{
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint id, byte* out_data_end);// 625160
    private static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225130));

    // used in bluebullet.cs
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate DSAbilityListDataAbilityArray* FUN_007785A0();
    private static FhMethodHandle<FUN_007785A0> _FUN_007785A0 =>
        new(new FhMethodLocation("FFX-2.exe", 0x3785a0));
}
