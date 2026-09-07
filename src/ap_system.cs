namespace Fahrenheit.Mods.FFX2NewDawn;

[StructLayout(LayoutKind.Explicit, Size = 0x80)]
public struct DamageBufferStatus
{

    [FieldOffset(0x30)] public byte chain_count;
    [FieldOffset(0x34)] public uint chr_inflicted_statuses;

    [FieldOffset(0x50)] public uint chr_unknown1_statuses;

    [FieldOffset(0x74)] public int damage_hp;
    [FieldOffset(0x78)] public int damage_mp;
    [FieldOffset(0x7C)] public int damage_atb;
}

[FhLoad(FhGameId.FFX2)]
public partial class APSystemModule : FhModule {

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate int MsGetComData(uint arg1, byte* arg2);
    private static FhMethodHandle<MsGetComData> _MsGetComData =>
        new(new FhMethodLocation("FFX-2.exe", 0x225160));

    /* 7100228500 - Called by MsCalcHitSignal - one way the game uses this is to increase a Chr's 0xEC2 flag - increases on hits
     * Not chain count, that's a different field.
     */
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate void d_FUN_6420C0(byte chr_id, Chr* chr, int chr_id2, Chr* chr2, uint cmd_id, uint cmd_addr, int param_7, DamageBufferStatus* dmg_info, uint param_9, int param_10, uint param_11);
    public static FhMethodHandle<d_FUN_6420C0> FUN_6420C0
        => new(new FhMethodLocation("FFX-2.exe", 0x2420C0));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte d_TOBtlOpenFukidashiWinStealItem(uint user_id, byte param_2, uint item, uint steal_result_code);
    public static FhMethodHandle<d_TOBtlOpenFukidashiWinStealItem> TOBtlOpenFukidashiWinStealItem
        => new(new FhMethodLocation("FFX-2.exe", 0x35C100));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate byte d_TOBtlOpenFukidashiWinStealGil(uint user_id, byte param_2, uint gil_stolen);
    public static FhMethodHandle<d_TOBtlOpenFukidashiWinStealGil> TOBtlOpenFukidashiWinStealGil
        => new(new FhMethodLocation("FFX-2.exe", 0x35C050));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void d_MsUseChrMP(uint chr_id, uint cmd_id, int amount);
    public static FhMethodHandle<d_MsUseChrMP> MsUseChrMP
        => new(new FhMethodLocation("FFx-2.exe", 0x21b8c0));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public unsafe delegate PlySave* d_MsGetSavePlayerPtr(uint chr_id);
    public static FhMethodHandle<d_MsGetSavePlayerPtr> MsGetSavePlayerPtr
        => new(new FhMethodLocation("FFX-2.exe", 0x20CC40));

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate uint d_MsGetCommandMP(uint chr_id, uint cmd_id);
    public static FhMethodHandle<d_MsGetCommandMP> MsGetCommandMP
        => new(new FhMethodLocation("FFX-2.exe", 0x21acf0));

    public APSystemModule() { }

    /// <summary>
    ///     Main helper MP restoration function.
    /// </summary>
    /// <param name="chr_id"></param>
    /// <param name="amount"></param>
    public unsafe void APRestoreMP(uint chr_id, int amount)
    {

        // Restore 1 MP on turn start
        DamageBuffer buffer = new();
        DamageBuffer* dBuffer = &buffer;

        //FFX2.FhCall.MsStructClear.fnptr!(dBuffer, 0x14); -- LOL, why did I ever think this was necessary?

        buffer.com_id = 0xff;
        buffer.target_stat = 0x02;
        buffer.chr_id = (byte)chr_id;
        buffer.damage_mp = amount;

        // Ragnarok doubles MP gain
        PlySave chr_ply_save = *(PlySave*)MsGetSavePlayerPtr.fnptr!(chr_id);
        if (chr_ply_save.equipped_accessory[0] == 0x907D || chr_ply_save.equipped_accessory[1] == 0x907D)
        {
            buffer.damage_mp = amount - 1;
        }

        FFX2.FhCall.MsDamageBufferExe.fnptr!(chr_id, chr_id, dBuffer);//6422d0
    }

    /// <summary>
    ///     When Dressphere growth alogrithms are read, force max MP to be 10.
    /// </summary>
    /// <param name="chr_id"></param>
    /// <param name="chr_level"></param>
    /// <param name="job_id"></param>
    /// <param name="param_4"></param>
    /// <param name="ptr_stats"></param>
    /// <returns></returns>
    public unsafe uint h_CalculateStats(uint chr_id, int chr_level, uint job_id, PlySave* param_4, int* ptr_stats) {
        uint original_result = FFX2.FhCall.CalculateStats.chain_from(h_CalculateStats).fnptr!(chr_id, chr_level, job_id, param_4, ptr_stats);
        ptr_stats[1] = 10; // force Max Base MP to be 10.
        return original_result;
    }

    /// <summary>
    ///     On battle start, force character's current MP to be 3. (Only works for player characters)
    /// </summary>
    /// <param name="chr_id"></param>
    public unsafe void h_MsSetRamChrParam(uint chr_id) {

        FFX2.FhCall.MsSetRamChrParam.chain_from(h_MsSetRamChrParam).fnptr!(chr_id);

        Chr* chr_base = FFX2.FhCall.MsGetChr.fnptr!(chr_id);
        int chr_base_int = (int)chr_base;

        PlySave* ptr_ply_save = MsGetSavePlayerPtr.fnptr!(chr_id);

        if (ptr_ply_save != null)
        {
            PlySave ply_save = *(PlySave*)(ptr_ply_save);

            if (ply_save.equipped_accessory[0] == 0x907B || ply_save.equipped_accessory[1] == 0x907B)
            {
                *(uint*)(chr_base_int + 0x3b8) = 5; // Starting MP is 5 for character's with Cat Nip
            }
            else
            {
                //*(uint*)(chr_base_int + 0x3b8) = *(uint*)(chr_base_int + 0x390) / 3; // Starting MP is 1/3 Max MP.
                *(uint*)(chr_base_int + 0x3b8) = 3; // Starting MP is 3
            }

        }
    }


    // Restore 1 MP on turn start.
    public unsafe void h_TOBtlSetATBChr(byte chr_id)
    {
        FFX2.FhCall.TOBtlSetATBChr.chain_from(h_TOBtlSetATBChr).fnptr!(chr_id);

        uint y_addr = (uint)FFX2.FhCall.MsGetChr.fnptr!(0);
        uint r_addr = (uint)FFX2.FhCall.MsGetChr.fnptr!(1);
        uint p_addr = (uint)FFX2.FhCall.MsGetChr.fnptr!(2);
        bool y_dancing = *(byte*)(y_addr + 0x669) == 1;
        bool r_dancing = *(byte*)(r_addr + 0x669) == 1;
        bool p_dancing = *(byte*)(p_addr + 0x669) == 1;

        uint chr_addr = (uint)FFX2.FhCall.MsGetChr.fnptr!(chr_id);

        // Restore MP to character on turn start - Yuna Freelancer (Leblanc gets 2 MP)
        ushort current_dressphere = *(ushort*)(chr_addr + 0x86a);
        if (chr_id == 0 && current_dressphere == 0x5020)
        {
            APRestoreMP(chr_id, -2);
        }
        else
        {
            APRestoreMP(chr_id, -1);
        }
        

        // If character is dancing when a player character has turn / can accept input - restore 1 MP
        if (y_dancing) { APRestoreMP(0, -1); }
        if (r_dancing) { APRestoreMP(1, -1); }
        if (p_dancing) { APRestoreMP(2, -1); }
    }

    // If an Item is stolen successfully, restore 1 MP
    public byte h_TOBtlOpenFukidashiWinStealItem(uint user_id, byte param_2, uint item, uint steal_result_code)
    {
        byte original_result = TOBtlOpenFukidashiWinStealItem.chain_from(h_TOBtlOpenFukidashiWinStealItem).fnptr!(user_id, param_2, item, steal_result_code);

        // if steal is successful
        if (steal_result_code == 1)
        {
            APRestoreMP(user_id, -1);
        }

        return original_result;
    }

    // If Gil is stolen successfully, restore 1 MP.
    public byte h_TOBtlOpenFukidashiWinStealGil(uint user_id, byte param_2, uint gil_stolen)
    {
        byte original_result = TOBtlOpenFukidashiWinStealGil.chain_from(h_TOBtlOpenFukidashiWinStealGil).fnptr!(user_id, param_2, gil_stolen);

        if (gil_stolen > 0)
        {
            APRestoreMP(user_id, -1);
        }

        return original_result;
    }

    /// <summary>
    ///     Changes Magic Booster, Half/One MP Cost and Spellspring behaviour.
    /// </summary>
    /// <param name="chr_id"></param>
    /// <param name="cmd_id"></param>
    /// <returns> The MP amount the command will use, after considering modifications. </returns>
    public unsafe uint h_MsGetCommandMP(uint chr_id, uint cmd_id)
    {

        int cmd_addr;
        PlySave* ply_save_ptr;
        uint chr_addr;
        
        AutoAbilityEffectsMap aabimap;
        uint status_map;
        uint mp_cost;
        bool bVar8;

        uint base_amount;
        uint multiplier;
        //uint divisor;

        int alteration_half;
        int alteration_one;
        int alteration_boost;

        cmd_addr = _MsGetComData.fnptr!(cmd_id, (byte*)0);

        int chr_top = FhUtil.get_at<int>(0xa0fbac); // MsGetChrTop - start of Chr structs
        if (chr_top == 0)
        {
            ply_save_ptr = MsGetSavePlayerPtr.fnptr!(chr_id);
            PlySave ply_save = *(PlySave*)ply_save_ptr;
            status_map = ply_save.status;
            aabimap = ply_save.auto_ability_effects;

        }
        else
        {
            chr_addr = (uint)FFX2.FhCall.MsGetChr.fnptr!(chr_id);
            status_map = *(uint*)(chr_addr + 0x434);
            aabimap =  *(AutoAbilityEffectsMap*)(chr_addr + 0x650);
        }

        //mp_cost = 0;
        mp_cost = 1; // Spellspring now has 1 MP Cost

        alteration_boost = 0;
        alteration_half = 0;
        alteration_one = 0;

        if (cmd_addr != 0)
        {
            // spellspring check A - stat_use_mp0
            if ((status_map & 0x2000) == 0)
            {
                mp_cost = *(byte*)(cmd_addr + 0x26);
            }
            else
            {
                // Spellspring and SOS Spellspring
                return 0;
            }

            // Initial values (Was used for Spellspring before change above)
            multiplier = 1;
            base_amount = 0;
            //divisor = 1;

            // com_dark check
            if ((*(uint*)(cmd_addr + 0x14) & 0x10000000) == 0)
            {
                // Half MP Cost
                bVar8 = aabimap.has_half_mp_cost;
                //bVar8 = (*(ushort*)(aabimap_addr + 4) & 4) != 0;
                multiplier = 1;
                if (bVar8)
                {
                    //divisor = 2;
                    alteration_half = -1;
                }
                //base_amount = 1;
                base_amount = 0;

                // One MP Cost
                if ( aabimap.has_one_mp_cost && (mp_cost != 0))
                //if (((*(ushort*)(aabimap_addr + 4) & 8) != 0) && (mp_cost != 0))
                {
                    //mp_cost = 1;
                    //divisor = 1;
                    base_amount = 0;

                    alteration_one = -2;
                }

                // If character has Magic Booster, and command is Black or White Magic
                if (((aabimap.has_magic_booster && ((*(byte*)(cmd_addr + 0xe) == 1 || *(byte*)(cmd_addr + 0xe) == 2)))))
                {
                    //multiplier = 2;
                    //base_amount = 0;

                    multiplier = 1;
                    //base_amount = 2;

                    alteration_boost = 1;
                }
            }

            //return (base_amount + multiplier * mp_cost) / divisor;
            int base_calc_mp = (int)(base_amount + multiplier * mp_cost);
            int modified_mp = base_calc_mp + alteration_boost + alteration_half + alteration_one;
            uint final_mp_cost;

            if (base_calc_mp > 0)
            {
                if (modified_mp < 1)
                {
                    final_mp_cost = 1;
                    return final_mp_cost;
                }

                return (uint)modified_mp;
            }

        }

        return 0;
        
    }

    // When a command consumes HP instead of MP, restore 1 MP (mainly for Dark Knight, Seymour and Ormi)
    public unsafe void h_MsUseChrMP(uint chr_id, uint cmd_id, int amount)
    {
        int iVar1;
        int pCVar2;
        uint uVar3;

        Chr* chr = FFX2.FhCall.MsGetChr.fnptr!(chr_id);
        iVar1 = (int)chr;

        pCVar2 = _MsGetComData.fnptr!(cmd_id, (byte*)0x0);
        uint com_exp_data = *(uint*)(pCVar2 + 0x14);
        bool com_dark = (com_exp_data & 0x10000000) != 0;


        if (com_dark)
        {
            uVar3 = (uint)FhCall.MsCheckRange.fnptr!(*(int*)(iVar1 + 0x3b4) - amount, 0, *(int*)(iVar1 + 0x384));
            *(int*)(iVar1 + 0x3b4) = (int)uVar3;
            APRestoreMP(chr_id, -1);
            return;
        }
        uVar3 = (uint)FhCall.MsCheckRange.fnptr!(*(int*)(iVar1 + 0x3b8) - amount, 0, *(int*)(iVar1 + 0x388));
        *(int*)(iVar1 + 0x3b8) = (int)uVar3;
        return;

    }

    // On command finish, for Alchemist, restore 1 MP for each character hit with an item.
    public unsafe uint h_MsCommandComplete(uint chr_id, int param_2, int param_3)
    {

        Chr* chr = FFX2.FhCall.MsGetChr.fnptr!(chr_id);
        int chr_addr = (int)chr;

        byte num_targets_hit = *(byte*)(chr_addr + 0xec2);
        uint com_id = *(uint*)(param_3 + 0xa4);
        uint job_id = FFX2.FhCall.MsGetSaveJob.fnptr!(chr_id);

        if (job_id == 0x5003)
        {
            if ((com_id & 0xF000) == 0x2000)
            {
                APRestoreMP(chr_id, -num_targets_hit);
            }
        }
        
        return FFX2.FhCall.MsCommandComplete.chain_from(h_MsCommandComplete).fnptr!(chr_id, param_2, param_3);
    }


    // some command / damage function - restore 1 MP on Attack, DK has chance to restore MP when damaged etc.
    public unsafe void h_FUN_6420C0(byte user_id, Chr* user, int target_id, Chr* target, uint cmd_id, uint cmd_addr, int user_MsCommandGetTop, DamageBufferStatus* param_8, uint param_9, int param_10, uint param_11) {

        FUN_6420C0.chain_from(h_FUN_6420C0).fnptr!(user_id, user, target_id, target, cmd_id, cmd_addr, user_MsCommandGetTop, param_8, param_9, param_10, param_11);

        DamageBufferStatus dmg_buf_sts = *(DamageBufferStatus*)param_8;
        int damage_hp = dmg_buf_sts.damage_hp;

        uint target_addr = (uint)target;
        uint target_dressphere = *(ushort*)(target_addr + 0x86a);
        if (*(byte*)((target_id + 0x31 + user_MsCommandGetTop)) == 0) {

            // on hit?
            if (param_10 == 0 || param_10 == 9)
            {
                uint user_addr = (uint)user;
                uint user_dressphere = *(ushort*)(user_addr + 0x86a);

                // Attack commands restores 1 MP
                if ((cmd_id >= 0x302C && cmd_id <= 0x3031) || cmd_id == 0x3123 || cmd_id == 0x312E || cmd_id == 0x312F || cmd_id == 0x321b) {

                    // Yuna Trainer restores 2
                    if (user_dressphere == 0x500C)
                    {
                        APRestoreMP(user_id, -2);
                    }
                    else
                    {
                        APRestoreMP(user_id, -1);
                    }
                }

                // For Dark Knight and Paine Festivalist (Seymour), Chance to restore MP when they're damaged.
                if (damage_hp > 0 && (target_dressphere == 0x5006 || target_dressphere == 0x501F))
                {
                    int x = FFX2.FhCall.MsGetRndChr.fnptr!(user_id, 0);
                    int random = FhCall.brnd.fnptr!(x) % 10;
                    if (random < 5)
                    {
                        APRestoreMP((byte)target_id, -1);
                    }
                }

                // Dressphere specific actions
                if (user_dressphere != 0) {

                    switch (user_dressphere)
                    {

                        case 0x5001:
                            // Give Trigger Happy a chance to restore MP with hits
                            if (cmd_id == 0x3032)
                            {
                                int x = FFX2.FhCall.MsGetRndChr.fnptr!(user_id, 0);
                                int random = FhCall.brnd.fnptr!(x) % 10;
                                if (random < 3)
                                {
                                    APRestoreMP(user_id, -1);
                                }
                            }
                            break;
                        case 0x5002:
                            // Blue Bullet commands restore 1 MP on hit
                            if (cmd_id > 0x3047 && cmd_id < 0x3058)
                            {
                                APRestoreMP(user_id, -1);
                            }
                            break;
                        case 0x5004:
                        case 0x5005:
                        case 0x5011:
                        case 0x5012:
                        case 0x5013:
                        case 0x5014:
                        case 0x5015:
                        case 0x5016:
                        case 0x5017:
                        case 0x501D:
                            // Any damage, not from Attack as that already grants AP above and not healing
                            if ( damage_hp > 0 && cmd_id != 0x3032 && cmd_id != 0x3023 && cmd_id != 0x312E && cmd_id != 0x302D )
                            {
                                APRestoreMP(user_id, -1);
                            }
                            break;
                        case 0x500A:
                        case 0x5010:
                            // Restore AP on heal
                            dmg_buf_sts = *(DamageBufferStatus*)param_8;
                            damage_hp = dmg_buf_sts.damage_hp;

                            
                            uint tgt_max_hp = *(uint*)(target_addr + 0x384);
                            uint tgt_hp     = *(uint*)(target_addr + 0x3B4);
                            uint missing_hp = tgt_max_hp - tgt_hp;

                            if (damage_hp < 0 && missing_hp > 0)
                            {
                                APRestoreMP(user_id, -1);
                            }
                            break;
                        case 0x500D:
                            // Lady Luck - Dice commands have a chance to restore MP
                            if (cmd_id == 0x30EB || cmd_id == 0x30EC)
                            {
                                int x = FFX2.FhCall.MsGetRndChr.fnptr!(user_id, 0);
                                int random = FhCall.brnd.fnptr!(x) % 10;
                                if (random < 3)
                                {
                                    APRestoreMP(user_id, -1);
                                }
                            }
                            break;
                        case 0x500F:
                            // Floral Fallal, Whirl spells generate MP
                            if (cmd_id > 0x310e && cmd_id < 0x3113)
                            {
                                APRestoreMP(user_id, -1);
                            }
                            break;
                        case 0x501c:
                            // Psychic - Psychic Bomb generates MP
                            if (cmd_id == 0x31E6)
                            {
                                APRestoreMP(user_id, *(byte*)(user_addr + 0xEC2));
                            }
                            break;
                        default:
                            break;
                    }

                }

            }

        }
    }

    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file)
    {

        return FUN_6420C0.hook(this, h_FUN_6420C0)
            && TOBtlOpenFukidashiWinStealItem.hook(this, h_TOBtlOpenFukidashiWinStealItem)
            && TOBtlOpenFukidashiWinStealGil.hook(this, h_TOBtlOpenFukidashiWinStealGil)
            && FFX2.FhCall.CalculateStats.hook(this, h_CalculateStats)
            && FFX2.FhCall.MsSetRamChrParam.hook(this, h_MsSetRamChrParam)
            && FFX2.FhCall.TOBtlSetATBChr.hook(this, h_TOBtlSetATBChr)
            && FFX2.FhCall.MsCommandComplete.hook(this, h_MsCommandComplete)
            && MsUseChrMP.hook(this, h_MsUseChrMP)
            && MsGetCommandMP.hook(this, h_MsGetCommandMP);
    }

}
