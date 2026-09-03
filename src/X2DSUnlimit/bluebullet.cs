namespace Fahrenheit.Mods.X2DSUnlimit;

/// <summary>
/// As part of this mod, the data that drives the Abilites menu has been moved to Native allocation.
/// A side effect of this is that the Blue Bullet menu no longer shows up.
///
/// These hooks fix this issue.
/// </summary>
public partial class X2DSUnlimitModule : FhModule {

    public unsafe DSAbilityListDataAbilityArray* h_FUN_00778680() {

        ushort current_dressphere = FhUtil.get_at<ushort>(0x12c0266);
        return &ability_list_data_ptr[current_dressphere].Abilities;

    }

}

