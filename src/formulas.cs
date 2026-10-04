namespace Fahrenheit.Mods.NewDawn;


[FhLoad(FhGameId.FFX2)]
public partial class FormulasModule : FhModule
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate int d_FUN_61B910(uint chr_id1, uint chr_id2, int cmd_base_addr, int cmd_dmg_formula, int power, int sc_gil,
            int param_7, int user_hp_remain, int user_hp_max, int param_10, int param_11, int tgt_hp_remain,
            int tgt_hp_max, uint user_str, int user_str_mod, uint user_mag, int user_mag_mod, uint user_level,
            int tgt_def, int tgt_def_mod, int tgt_magdef, int tgt_magdef_mod);
    public static FhMethodHandle<d_FUN_61B910> FUN_61B910
        => new(new FhMethodLocation("FFX-2.exe", 0x21B910));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate PlySave* d_MsGetSavePlayerPtr(uint chr_id);
    public static FhMethodHandle<d_MsGetSavePlayerPtr> MsGetSavePlayerPtr
        => new(new FhMethodLocation("FFX-2.exe", 0x20CC10));

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

    public bool use_mod_damage_formulas = true;

    public unsafe int h_FUN_61B910(uint user_chr_id, uint tgt_chr_id, int cmd_base_addr, int cmd_dmg_formula, int power, int sc_gil,
            int param_7, int user_hp_remain, int user_hp_max, int param_10, int param_11, int tgt_hp_remain,
            int tgt_hp_max, uint user_str, int user_str_mod, uint user_mag, int user_mag_mod, uint user_level,
            int tgt_def, int tgt_def_mod, int tgt_magdef, int tgt_magdef_mod)
    {

        if (!use_mod_damage_formulas)
        {
            return FUN_61B910.chain_from(h_FUN_61B910).fnptr!(user_chr_id, tgt_chr_id, cmd_base_addr, cmd_dmg_formula, power, sc_gil,
             param_7, user_hp_remain, user_hp_max, param_10, param_11, tgt_hp_remain,
             tgt_hp_max, user_str, user_str_mod, user_mag, user_mag_mod, user_level,
             tgt_def, tgt_def_mod, tgt_magdef, tgt_magdef_mod);
        }
        else
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
                    user_level = (user_str + user_level) * user_str * user_level / 1024 + user_str;

                    final_damage = (int)user_level * (270 - tgt_def) / 255; //Apply defense
                    //final_damage = (int)((user_level) * (1.0 / (1.0 + Math.Pow(tgt_def / 100.0, 1.5))));

                    final_damage = final_damage * (user_str_mod + stat_mod_const) / stat_mod_const;
                    final_damage = final_damage * (stat_mod_const - tgt_def_mod) / stat_mod_const;
                    goto LAB_PHYS_AND_SPECIAL_MAGIC;
                //Ignore Defense
                case 1:
                    user_level = (user_str + user_level) * user_str * user_level / 1024 + user_str;
                    final_damage = (int)user_level * (user_str_mod + stat_mod_const) / stat_mod_const;
                    final_damage = final_damage * (stat_mod_const - tgt_def_mod) / stat_mod_const;
                    final_damage = final_damage * power / 16;
                    goto LAB_IGNORE_DEF_MDEF;
                //Magic formula
                case 2:
                    final_damage = (int)((user_mag + user_level * 2));
                    final_damage = final_damage * (power * power) / 64;

                    final_damage = final_damage * (270 - tgt_magdef) / 255; //Apply defense
                    //final_damage = (int)(final_damage * (1.0 / (1.0 + Math.Pow(tgt_magdef / 100.0, 1.5))));

                    goto MAGIC_APPLY_STAGE_MODIFIERS;
                //Ignore Magic Defense
                case 3:
                    final_damage = (int)((user_mag + user_level * 2));
                    final_damage = final_damage * (power * power) / 64;
                MAGIC_APPLY_STAGE_MODIFIERS:
                    final_damage = final_damage * (user_mag_mod + stat_mod_const) / stat_mod_const;
                    final_damage = final_damage * (stat_mod_const - tgt_magdef_mod) / stat_mod_const;
                    goto LAB_IGNORE_DEF_MDEF;
                //Fraction of remaining HP formula
                case 4:
                    final_damage = tgt_hp_remain * power / 16;
                    break;
                //Multiple of 50
                case 5:
                    final_damage = power * 0x32;
                    break;
                //Recovery Magic
                case 6:
                    final_damage = (int)((user_mag + user_level * 2));
                    final_damage = final_damage * (power * power) / 128;
                    final_damage = final_damage * (user_mag_mod + stat_mod_const) / stat_mod_const;
                LAB_IGNORE_DEF_MDEF:
                    final_damage = final_damage * iVar4 / 256;
                    break;
                //Fraction of Max HP formula
                case 7:
                    final_damage = tgt_hp_max * power / 16;
                    break;
                //Item formula 1
                case 8:
                    final_damage = power * 0x32;
                    final_damage = final_damage * iVar4 / 256;
                    break;
                //special magic formula
                case 9:
                    user_level = (user_mag + user_level) * user_mag * user_level / 1024 + user_mag;

                    final_damage = (int)user_level * (270 - tgt_magdef) / 255;
                    //final_damage = (int)((user_level) * (1.0 / (1.0 + Math.Pow(tgt_magdef / 100.0, 1.5))));

                    final_damage = final_damage * (user_mag_mod + stat_mod_const) / stat_mod_const;
                    final_damage = final_damage * (stat_mod_const - tgt_magdef_mod) / stat_mod_const;
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
                    final_damage = (power * user_hp_max) / 16;
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
                //no command uses this? Karma?
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
                // Damage = Damage Constant
                case 0xf:
                    final_damage = power;
                    break;
                //Item formula 2 - Budget Grenade uses this
                case 0x10:
                    final_damage = (iVar4 * power) / 256;
                    break;
                //Mirror of Equity formula - deal higher damage the lower the user's HP is
                case 0x11:
                    final_damage = ((user_hp_max - user_hp_remain) * power) / 16;
                    break;
                //level based formula
                case 0x12:
                    final_damage = (int)(power * user_level);
                    break;
                //Berserker's Hurt Damage formula
                case 0x13:
                    final_damage = (power * user_hp_remain) / 16;
                    break;
                //Table-Turner formula - deal mmore damage to enemies with higher defence
                case 0x14:
                    user_level = (user_str + user_level) * user_str * user_level / 1024 + user_str;

                    final_damage = (int)user_level * (15 + tgt_def) / 255; // Apply Defense
                    //final_damage = (int)(user_level * (Math.Pow(tgt_def / 100.0, 1.5) / (1.0 + Math.Pow(tgt_def / 100.0, 1.5))));

                    final_damage = final_damage * (user_str_mod + stat_mod_const) / stat_mod_const;
                    final_damage = final_damage * (stat_mod_const + tgt_def_mod) / stat_mod_const;
                LAB_PHYS_AND_SPECIAL_MAGIC:
                    final_damage = final_damage * power / 16;
                    final_damage = final_damage * iVar4 / 256;
                    break;
                case 0x18:
                    //reset damage var
                    final_damage = 0;
                    //if command has weak delay flag set
                    if ((*(uint*)(cmd_base_addr + 0x14) & 0x1000) != 0)
                    {
                        //final_damage = DAT_00df8ea0;
                        final_damage = FhUtil.get_at<int>(0x9F7EA0);
                    }
                    //if command has strong delay flag set
                    if ((*(uint*)(cmd_base_addr + 0x14) & 0x2000) != 0)
                    {
                        //final_damage = final_damage + _DAT_00df8ea4;
                        final_damage = final_damage + FhUtil.get_at<int>(0x9F7EA4);
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
                    final_damage = (int)(final_damage + user_ply_save.enemies_defeated);
                }
            }//if using Finale damage formula
            else if (((cmd_dmg_formula == 0x17) && (user_ply_save_ptr != null)) && user_ply_save.escape_count == 0)
            {
                final_damage = final_damage + 99999;
            }
            //if command dmg_data has com_dmg_recover flag set - If command should heal
            if ((cmd_base_addr != 0) && ((*(byte*)(cmd_base_addr + 0x1c) & 0x10) != 0))
            {
                final_damage = -final_damage;
            }

            // Cat Nip boosts damage when HP is lower
            if (user_ply_save_ptr != null)
            {
                if (user_ply_save.equipped_accessories[0] == 0x907B || user_ply_save.equipped_accessories[1] == 0x907B)
                {

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

            /*
            Chr* ptr_tgt_chr = FFX2.FhCall.MsGetChr.fnptr!(tgt_chr_id);
            int tgt_chr_addr = (int)ptr_tgt_chr;

            ushort tgt_id = *(ushort*)(tgt_chr_addr + 0xe);
            byte chr_num = *(byte*)(tgt_chr_addr + 0x11);
            uint is_creature = FFX2.FhCall.MsBtlMonsterSaveNumCheck.fnptr!(chr_num);

            if (tgt_id == 0x10E8 && is_creature == 0 && final_damage > 0 && final_damage < 9998)
            {
                final_damage = 1;
            }
            */

            return final_damage;

        }

    }

    public override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return FUN_61B910.hook(this, h_FUN_61B910);
        //&& FFX2.FhCall.MsGetRamChrMonster.hook(this, h_MsGetRamChrMonster)
        //&& MsGetSavePlayerPtr.hook(this, h_MsGetSavePlayerPtr);
    }

    /*
    public override void render_imgui()
    {
        if (ImGui.Begin("Mod Damage Formula toggle"))
        {

            string label1 = use_mod_damage_formulas ? "Modded Formula: ON" : "Modded Formula: OFF";
            if (ImGui.Button(label1))
            {
                use_mod_damage_formulas = !use_mod_damage_formulas;
            }

        }
        ImGui.End();

    }
    */
}


