namespace Fahrenheit.Mods.NewDawn;


[FhLoad(FhGameId.FFX2)]
public partial class FormulasModule : FhModule
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_61B930(uint chr_id1, uint chr_id2, int cmd_base_addr, int cmd_dmg_formula, int power, int sc_gil,
            int param_7, int user_hp_remain, int user_hp_max, int param_10, int param_11, int tgt_hp_remain,
            int tgt_hp_max, uint user_str, int user_str_mod, uint user_mag, int user_mag_mod, uint user_level,
            int tgt_def, int tgt_def_mod, int tgt_magdef, int tgt_magdef_mod);
    public static FhMethodHandle<d_FUN_61B930> FUN_61B930 
        => new(new FhMethodLocation("FFX-2.exe", 0x21B930));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate PlySave* d_MsGetSavePlayerPtr(uint chr_id);
    public static FhMethodHandle<d_MsGetSavePlayerPtr> MsGetSavePlayerPtr
        => new(new FhMethodLocation("FFX-2.exe", 0x20CC40));

    public FormulasModule() { }

    /*
    public uint h_MsGetRamChrMonster(uint chr_id)
    {
        return FFX2.FhCall.MsGetRamChrMonster.chain_from(h_MsGetRamChrMonster).fnptr!(chr_id);
    }

    public unsafe PlySave* h_MsGetSavePlayerPtr(uint chr_id)
    {
        return MsGetSavePlayerPtr.chain_from(h_MsGetSavePlayerPtr).fnptr!(chr_id);
    }*/

    public unsafe int h_FUN_61B930(uint user_chr_id, uint tgt_chr_id, int cmd_base_addr, int cmd_dmg_formula, int power, int sc_gil,
            int param_7, int user_hp_remain, int user_hp_max, int param_10, int param_11, int tgt_hp_remain,
            int tgt_hp_max, uint user_str, int user_str_mod, uint user_mag, int user_mag_mod, uint user_level,
            int tgt_def, int tgt_def_mod, int tgt_magdef, int tgt_magdef_mod)
    {

        const int stat_mod_const = 25;

        uint is_enemy;
        PlySave* user_ply_save_ptr;
        int iVar2;
        PlySave* tgt_ply_save_ptr;
        int iVar4;
        int final_damage;

        final_damage = 0;

        //some weird/complicated way that I believe is used for the damage randomisation step
        //checks if is an enemy - 1 if enemy
        is_enemy = FFX2.FhCall.MsGetRamChrMonster.fnptr!(user_chr_id);
        //20, 21 or 22 for YRP
        iVar4 = (int)user_chr_id + 0x14;
        if (is_enemy != 0)
        {
            //33, 34, 35
            iVar4 = (int)user_chr_id + 0xd;
        }
        if (param_7 == 0)
        {
            iVar2 = FhCall.brnd.fnptr!(iVar4);
            iVar4 = (int)((iVar2 & 0x1f) + 0xf0);
        }
        else
        {
            //?Fix randomisation numerator to 256? Midway between 240 and 271
            iVar4 = 256;//0x100
        }

        //gets a base address of the character's party data - used later to get Escape count, # of enemies killed
        user_ply_save_ptr = MsGetSavePlayerPtr.fnptr!(user_chr_id);
        //this does soemthing for Damage Formula 13 (case 0xd:) - is some base address
        tgt_ply_save_ptr = MsGetSavePlayerPtr.fnptr!(tgt_chr_id);

        PlySave user_ply_save = *(PlySave*)user_ply_save_ptr;
        PlySave tgt_ply_save = *(PlySave*)tgt_ply_save_ptr;

        //start of command damage formula evaluation
        switch (cmd_dmg_formula)
        {
            //Normal physical formula
            case 0:
            case 0x15:
            case 0x16:
            case 0x17:
                user_level = (user_str + user_level) * user_str * user_level;
                final_damage = (int)((((((((int)((user_level >> 0x1f & 0x3ffU) + user_level) >> 10) + user_str) *
                           (0x10e - tgt_def)) / 0xff) * (user_str_mod + stat_mod_const)) / stat_mod_const) * (stat_mod_const - tgt_def_mod));
                final_damage = final_damage / 6 + (final_damage >> 0x1f);
                goto LAB_PHYS_AND_SPECIAL_MAGIC;
            //Ignore Defense
            case 1:
                user_level = (user_str + user_level) * user_str * user_level;
                power = (int)((((((((((int)((user_level >> 0x1f & 0x3ffU) + user_level) >> 10) + user_str) * 0x10e) /
                            0xff) * (user_str_mod + stat_mod_const)) / stat_mod_const) * (stat_mod_const - tgt_def_mod)) / stat_mod_const) * power);
                final_damage = (int)(power + (power >> 0x1f & 0xfU)) >> 4;
                goto LAB_IGNORE_DEF_MDEF;
            //Magic formula
            case 2:
                power = (int)((user_mag + user_level * 2) * power * power);
                final_damage = (int)(((((int)((power >> 0x1f & 0x3fU) + power) >> 6) * (0x10e - tgt_magdef)) *
                              0x80808081) >> 0x20);
                goto LAB_0061bae9;
            //Ignore Magic Defense
            case 3:
                power = (int)((user_mag + user_level * 2) * power * power);
                final_damage = (int)(((((int)((power >> 0x1f & 0x3fU) + power) >> 6) * 0x10e) * 0x80808081)
                             >> 0x20);
            LAB_0061bae9:
                final_damage = (((((final_damage >> 7) - (final_damage >> 0x1f)) * (user_mag_mod + stat_mod_const)) / stat_mod_const) *
                        (stat_mod_const - tgt_magdef_mod)) / stat_mod_const;
                goto LAB_IGNORE_DEF_MDEF;
            //Fraction of remaining HP formula
            case 4:
                final_damage = (int)((power * tgt_hp_remain >> 0x1f & 0xfU) + power * tgt_hp_remain) >> 4;
                break;
            //Multiple of 50
            case 5:
                final_damage = power * 0x32;
                break;
            //Recovery Magic
            case 6:
                power = (int)((user_mag + user_level * 2) * power * power);
                final_damage = (((int)((power >> 0x1f & 0x7fU) + power) >> 7) * (user_mag_mod + stat_mod_const)) / stat_mod_const;
            LAB_IGNORE_DEF_MDEF:
                final_damage = (int)((final_damage * iVar4 >> 0x1f & 0xffU) + final_damage * iVar4) >> 8;
                break;
            //Fraction of Max HP formula
            case 7:
                final_damage = (int)((power * tgt_hp_max >> 0x1f & 0xfU) + power * tgt_hp_max) >> 4;
                break;
            //Item formula 1
            case 8:
                iVar4 = iVar4 * power * 0x32;
                final_damage = (int)((iVar4 >> 0x1f & 0xffU) + iVar4) >> 8;
                break;
            //special magic formula
            case 9:
                user_level = (user_mag + user_level) * user_mag * user_level;
                final_damage = (int)((((((((int)((user_level >> 0x1f & 0x3ffU) + user_level) >> 10) + user_mag) *
                           (0x10e - tgt_magdef)) / 0xff) * (user_mag_mod + stat_mod_const)) / stat_mod_const) * (stat_mod_const - tgt_magdef_mod));
                final_damage = final_damage / 6 + (final_damage >> 0x1f);
                goto LAB_PHYS_AND_SPECIAL_MAGIC;
            //damage is target's remaining HP - 1
            case 10:
                if (0 < tgt_hp_remain)
                {
                    final_damage = tgt_hp_remain + -1;
                }
                break;
            //Charon / Self-destruct formula
            case 0xb:
                final_damage = (int)((power * user_hp_max >> 0x1f & 0xfU) + power * user_hp_max) >> 4;
                break;
            //Spare Change formula
            case 0xc:
                if (sc_gil < 1)
                {
                    final_damage = 0;
                }
                else
                {
                    //_CIsqrt();
                    //final_damage = FUN_0087e0d0();
                    final_damage = (int)((22 * sc_gil) / (Math.Sqrt(sc_gil) + 20));
                }
                break;
            //no command uses this?
            case 0xd:
                if (tgt_ply_save_ptr != null)
                {
                    //final_damage = *(int*)(tgt_ply_save + 0x44) * power;
                    final_damage = (int)(tgt_ply_save.enemies_defeated * power);
                }
                break;
            //Multiple of 9999
            case 0xe:
                final_damage = power * 9999;
                break;
            //damage is the same as the command's damage constant
            case 0xf:
                final_damage = power;
                break;
            //Item formula 2 - Budget Grenade uses this
            case 0x10:
                final_damage = (int)((iVar4 * power >> 0x1f & 0xffU) + iVar4 * power) >> 8;
                break;
            //Mirror of Equity formula - deal higher damage the lower the user's HP is
            case 0x11:
                power = (user_hp_max - user_hp_remain) * power;
                final_damage = (int)((power >> 0x1f & 0xfU) + power) >> 4;
                break;
            //level based formula
            case 0x12:
                final_damage = (int)(power * user_level);
                break;
            //Berserker's Hurt Damage formula
            case 0x13:
                final_damage = (int)((power * user_hp_remain >> 0x1f & 0xfU) + power * user_hp_remain) >> 4;
                break;
            //Table-Turner formula - deal mmore damage to enemies with higher defence
            case 0x14:
                user_level = (user_str + user_level) * user_str * user_level;
                final_damage = (int)((((((((int)((user_level >> 0x1f & 0x3ffU) + user_level) >> 10) + user_str) *
                           (tgt_def + 0xf)) / 0xff) * (user_str_mod + stat_mod_const)) / stat_mod_const) * (tgt_def_mod + stat_mod_const));
                final_damage = final_damage / 6 + (final_damage >> 0x1f);
            LAB_PHYS_AND_SPECIAL_MAGIC:
                power = ((final_damage >> 1) - (final_damage >> 0x1f)) * power;
                iVar4 = ((int)(power + (power >> 0x1f & 0xfU)) >> 4) * iVar4;
                final_damage = (int)((iVar4 >> 0x1f & 0xffU) + iVar4) >> 8;
                break;
            case 0x18:
                //reset damage var
                final_damage = 0;
                //if command has weak delay flag set
                if ((*(uint*)(cmd_base_addr + 0x14) & 0x1000) != 0)
                {
                    //final_damage = DAT_00df8ea0;
                    final_damage = FhUtil.get_at<int>(0x9F8EA0);
                }
                //if command has strong delay flag set
                if ((*(uint*)(cmd_base_addr + 0x14) & 0x2000) != 0)
                {

                    //final_damage = final_damage + _DAT_00df8ea4;
                    final_damage = final_damage + FhUtil.get_at<int>(0x9F8EA4);
                }
                break;
        }//what is this one? param_11 and param_10 are only used here. No item, monmagic or command uses this
        if (cmd_dmg_formula == 0x15)
        {
            final_damage = ((param_11 - param_10) * final_damage * 4) / param_11;
        }//if using Momentum damage formula
        else if (cmd_dmg_formula == 0x16)
        {
            if (user_ply_save_ptr != null)
            {
                //final_damage = final_damage + *(int*)(user_ply_save + 0x44);

                final_damage = (int)(final_damage + user_ply_save.enemies_defeated);
            }
        }//if using Finale damage formula
        else if (((cmd_dmg_formula == 0x17) && (user_ply_save_ptr != null)) &&  user_ply_save.escape_count == 0)
        {
            final_damage = final_damage + 99999;
        }
        //if command dmg_data has com_dmg_recover flag set - If command should heal
        if ((cmd_base_addr != 0) && ((*(byte*)(cmd_base_addr + 0x1c) & 0x10) != 0))
        {
            final_damage = -final_damage;
        }

        if (user_ply_save_ptr != null)
        {
            if (user_ply_save.equipped_accessory[0] == 0x907B || user_ply_save.equipped_accessory[1] == 0x907B) {

                /*
                int chr_base = (int)FFX2.FhCall.MsGetChr.fnptr!(user_chr_id);
                uint chr_status_bitfield = *(uint*)(chr_base + 0x434);

                if ((chr_status_bitfield & 0x80) != 0)
                {
                    final_damage = (final_damage * 11) / 10;
                }*/
                final_damage = (final_damage * (2 * user_hp_max - user_hp_remain)) / user_hp_max;

            }
        }

        return final_damage;

    }

    


    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return FUN_61B930.hook(this, h_FUN_61B930);
            //&& FFX2.FhCall.MsGetRamChrMonster.hook(this, h_MsGetRamChrMonster)
            //&& MsGetSavePlayerPtr.hook(this, h_MsGetSavePlayerPtr);
    }

}


