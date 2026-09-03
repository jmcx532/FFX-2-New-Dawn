namespace Fahrenheit.Mods.X2DSUnlimit;

/// <summary>
/// Customise dressphere data here!
/// 
/// This file implements: 
/// Overwrite Festivalist/Freelancer/Leblanc Goon job.bin entries in memory instead of needing to EFL them.
/// *Still need EFL at present for custom strings.*
/// 
/// Job data definitions for Freelancer and Leblanc Goon - one per character instead of the lone one in job.bin.
/// </summary>

public partial class X2DSUnlimitModule : FhModule {


    /// <summary>
    /// Usage: Overwrites Job entries in memory after job.bin has been loaded.
    /// </summary>
    bool FUN_6083B0_runOnce = false;
    //param_1 is a custom excel bin number, 8 is Job.bin
    public int h_FUN_6083B0(uint param_1) {
        int original_result = FFX2.FhCall.FUN_006083B0.chain_from(h_FUN_6083B0).fnptr!(param_1);

        if (param_1 == 8 && !FUN_6083B0_runOnce) {
            FUN_6083B0_runOnce = true;

            InitYunaFestivalist();
            InitRikkuFestivalist();
            InitPaineFestivalist();

            
        }
        return original_result;
    }

    // Initialise Rikku and Paine's own Freelancer and Leblanc Goon NativeAlloc job data
    public void InitNewJobs() {
        InitYunaFreelancer();
        InitYunaLeblancGoon();
        InitRikkuFreelancer();
        InitRikkuLeblancGoon();
        InitPaineFreelancer();
        InitPaineLeblancGoon();
    }

    /// <summary>
    /// Job data definitions
    /// 
    /// Note 1: Only Yuna's Freelance/Leblanc Goon data needs to be written back to job.bin in memory, Rikku/Paine's data is in NativeAlloc
    /// </summary>
    /// 
    public unsafe void InitYunaFestivalist()
    {
        // read and get copy of Job struct
        Job y_festivalist = *(Job*)h_MsGetRomJob(0, 0x501d, null);

        y_festivalist.name_offset.text_offset = 2345;
        y_festivalist.help_offset.text_offset = 2357;
        y_festivalist.user = 0;
        y_festivalist.dressphere_menu_ordering = 15;
        y_festivalist.icon = 90;
        y_festivalist.berserk_action = 0x302D;

        // stat growth
        y_festivalist.growth_hp.linear_mult = 42;
        y_festivalist.growth_hp.quadratic_div = 183;
        y_festivalist.growth_hp.base_amount = 78;

        y_festivalist.growth_mp.linear_mult = 26;
        y_festivalist.growth_mp.quadratic_div = 180;
        y_festivalist.growth_mp.base_amount = 18;

        y_festivalist.growth_strength.linear_mult = 20;
        y_festivalist.growth_strength.linear_div = 67;
        y_festivalist.growth_strength.base_amount = 17;
        y_festivalist.growth_strength.quadratic_div_a = 10;
        y_festivalist.growth_strength.quadratic_div_b = 1;

        y_festivalist.growth_magic.linear_mult = 12;
        y_festivalist.growth_magic.linear_div = 2;
        y_festivalist.growth_magic.base_amount = 16;
        y_festivalist.growth_magic.quadratic_div_a = 11;
        y_festivalist.growth_magic.quadratic_div_b = 1;

        y_festivalist.growth_defense.linear_mult = 3;
        y_festivalist.growth_defense.linear_div = 200;
        y_festivalist.growth_defense.base_amount = 32;
        y_festivalist.growth_defense.quadratic_div_a = 200;
        y_festivalist.growth_defense.quadratic_div_b = 2;

        y_festivalist.growth_magic.linear_mult = 6;
        y_festivalist.growth_magic.linear_div = 4;
        y_festivalist.growth_magic.base_amount = 18;
        y_festivalist.growth_magic.quadratic_div_a = 200;
        y_festivalist.growth_magic.quadratic_div_b = 2;

        y_festivalist.growth_magic_defense.linear_mult = 3;
        y_festivalist.growth_magic_defense.linear_div = 16;
        y_festivalist.growth_magic_defense.base_amount = 38;
        y_festivalist.growth_magic_defense.quadratic_div_a = 200;
        y_festivalist.growth_magic_defense.quadratic_div_b = 2;

        y_festivalist.growth_agility.linear_mult = 5;
        y_festivalist.growth_agility.linear_div = 17;
        y_festivalist.growth_agility.base_amount = 54;
        y_festivalist.growth_agility.quadratic_div_a = 200;
        y_festivalist.growth_agility.quadratic_div_b = 4;

        y_festivalist.growth_evasion.linear_mult = 0;
        y_festivalist.growth_evasion.linear_div = 20;
        y_festivalist.growth_evasion.base_amount = 10;
        y_festivalist.growth_evasion.quadratic_div_a = 200;
        y_festivalist.growth_evasion.quadratic_div_b = 4;

        y_festivalist.growth_accuracy.linear_mult = 0;
        y_festivalist.growth_accuracy.linear_div = 17;
        y_festivalist.growth_accuracy.base_amount = 120;
        y_festivalist.growth_accuracy.quadratic_div_a = 200;
        y_festivalist.growth_accuracy.quadratic_div_b = 4;

        y_festivalist.growth_luck.linear_mult = 0;
        y_festivalist.growth_luck.linear_div = 22;
        y_festivalist.growth_luck.base_amount = 13;
        y_festivalist.growth_luck.quadratic_div_a = 200;
        y_festivalist.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        y_festivalist.yuna_weapon_data[0].weapon_model = 4410;
        y_festivalist.yuna_weapon_data[0].weapon_position = 14;
        y_festivalist.yuna_weapon_data[1].weapon_model = 0;
        y_festivalist.yuna_weapon_data[1].weapon_position = 0;
        y_festivalist.yuna_weapon_data[2].weapon_model = 0;
        y_festivalist.yuna_weapon_data[2].weapon_position = 0;
        y_festivalist.yuna_weapon_data[3].weapon_model = 0;
        y_festivalist.yuna_weapon_data[3].weapon_position = 0;



        // abilities
        y_festivalist.dressphere_abilities[0].requirement = 0;
        y_festivalist.dressphere_abilities[0].ability = 0x302D; // Attack

        y_festivalist.dressphere_abilities[1].requirement = 1;
        y_festivalist.dressphere_abilities[1].ability = 0x31FA; // Matra Magic

        y_festivalist.dressphere_abilities[2].requirement = 0;
        y_festivalist.dressphere_abilities[2].ability = 0x31F4; // Jump

        y_festivalist.dressphere_abilities[3].requirement = 0x31F4;
        y_festivalist.dressphere_abilities[3].ability = 0x3200; // High Jump

        y_festivalist.dressphere_abilities[4].requirement = 0x31FA;
        y_festivalist.dressphere_abilities[4].ability = 0x31F7; // Electro Burst

        y_festivalist.dressphere_abilities[5].requirement = 0x31F7;
        y_festivalist.dressphere_abilities[5].ability = 0x31FD; // Aqualung

        y_festivalist.dressphere_abilities[6].requirement = 0x31FD;
        y_festivalist.dressphere_abilities[6].ability = 0x3201; // Avalanche

        y_festivalist.dressphere_abilities[7].requirement = 1;
        y_festivalist.dressphere_abilities[7].ability = 0x3202; // Enrage

        y_festivalist.dressphere_abilities[8].requirement = 0;
        y_festivalist.dressphere_abilities[8].ability = 0x3203; // Lancet

        y_festivalist.dressphere_abilities[9].requirement = 0x3202;
        y_festivalist.dressphere_abilities[9].ability = 0x3204; // Nova Strike

        y_festivalist.dressphere_abilities[10].requirement = 0x3204;
        y_festivalist.dressphere_abilities[10].ability = 0x3205; //  Supernova

        y_festivalist.dressphere_abilities[11].requirement = 1;
        y_festivalist.dressphere_abilities[11].ability = 0x3212; // White Wind

        y_festivalist.dressphere_abilities[12].requirement = 0x3212;
        y_festivalist.dressphere_abilities[12].ability = 0x3213; // Mighty Guard

        y_festivalist.dressphere_abilities[13].requirement = 1;
        y_festivalist.dressphere_abilities[13].ability = 0x805C; // Pointlessproof

        y_festivalist.dressphere_abilities[14].requirement = 0x805c;
        y_festivalist.dressphere_abilities[14].ability = 0x801A; // Sage Lv.2

        y_festivalist.dressphere_abilities[15].requirement = 0x801A;
        y_festivalist.dressphere_abilities[15].ability = 0x801B; // Sage Lv.3

        // Write the changes to memory
        *(Job*)h_MsGetRomJob(0, 0x501d, null) = y_festivalist;
    }

    public unsafe void InitYunaFreelancer() {
        // read and get copy of Job struct
        ref Job y_freelancer = ref *yuna_freelancer_ptr;

        y_freelancer.name_offset.text_offset = 2480;
        y_freelancer.help_offset.text_offset = 2357;
        y_freelancer.user = 0;
        y_freelancer.dressphere_menu_ordering = 15;
        y_freelancer.icon = 90;
        y_freelancer.berserk_action = 0x302D;

        // stat growth
        y_freelancer.growth_hp.linear_mult = 42;
        y_freelancer.growth_hp.quadratic_div = 183;
        y_freelancer.growth_hp.base_amount = 78;

        y_freelancer.growth_mp.linear_mult = 26;
        y_freelancer.growth_mp.quadratic_div = 180;
        y_freelancer.growth_mp.base_amount = 18;

        y_freelancer.growth_strength.linear_mult = 13;
        y_freelancer.growth_strength.linear_div = 75;
        y_freelancer.growth_strength.base_amount = 10;
        y_freelancer.growth_strength.quadratic_div_a = 43;
        y_freelancer.growth_strength.quadratic_div_b = 1;

        y_freelancer.growth_defense.linear_mult = 0;
        y_freelancer.growth_defense.linear_div = 27;
        y_freelancer.growth_defense.base_amount = 25;
        y_freelancer.growth_defense.quadratic_div_a = 200;
        y_freelancer.growth_defense.quadratic_div_b = 100;

        y_freelancer.growth_magic.linear_mult = 15;
        y_freelancer.growth_magic.linear_div = 4;
        y_freelancer.growth_magic.base_amount = 28;
        y_freelancer.growth_magic.quadratic_div_a = 12;
        y_freelancer.growth_magic.quadratic_div_b = 1;

        y_freelancer.growth_magic_defense.linear_mult = 7;
        y_freelancer.growth_magic_defense.linear_div = 19;
        y_freelancer.growth_magic_defense.base_amount = 88;
        y_freelancer.growth_magic_defense.quadratic_div_a = 200;
        y_freelancer.growth_magic_defense.quadratic_div_b = 1;

        y_freelancer.growth_agility.linear_mult = 6;
        y_freelancer.growth_agility.linear_div = 80;
        y_freelancer.growth_agility.base_amount = 55;
        y_freelancer.growth_agility.quadratic_div_a = 200;
        y_freelancer.growth_agility.quadratic_div_b = 4;

        y_freelancer.growth_evasion.linear_mult = 0;
        y_freelancer.growth_evasion.linear_div = 8;
        y_freelancer.growth_evasion.base_amount = 17;
        y_freelancer.growth_evasion.quadratic_div_a = 200;
        y_freelancer.growth_evasion.quadratic_div_b = 4;

        y_freelancer.growth_accuracy.linear_mult = 1;
        y_freelancer.growth_accuracy.linear_div = 7;
        y_freelancer.growth_accuracy.base_amount = 134;
        y_freelancer.growth_accuracy.quadratic_div_a = 200;
        y_freelancer.growth_accuracy.quadratic_div_b = 4;

        y_freelancer.growth_luck.linear_mult = 2;
        y_freelancer.growth_luck.linear_div = 20;
        y_freelancer.growth_luck.base_amount = 18;
        y_freelancer.growth_luck.quadratic_div_a = 200;
        y_freelancer.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        y_freelancer.yuna_weapon_data[0].weapon_model = 0x108B;
        y_freelancer.yuna_weapon_data[0].weapon_position = 0xE;
        y_freelancer.yuna_weapon_data[1].weapon_model = 0;
        y_freelancer.yuna_weapon_data[1].weapon_position = 0;
        y_freelancer.yuna_weapon_data[2].weapon_model = 0;
        y_freelancer.yuna_weapon_data[2].weapon_position = 0;
        y_freelancer.yuna_weapon_data[3].weapon_model = 0;
        y_freelancer.yuna_weapon_data[3].weapon_position = 0;



        // abilities
        y_freelancer.dressphere_abilities[0].requirement = 0;
        y_freelancer.dressphere_abilities[0].ability = 0x312f; // Attack

        y_freelancer.dressphere_abilities[1].requirement = 0;
        y_freelancer.dressphere_abilities[1].ability = 0x3023; // Black Magic

        y_freelancer.dressphere_abilities[2].requirement = 0;
        y_freelancer.dressphere_abilities[2].ability = 0x31f8; // Sonic Fan

        y_freelancer.dressphere_abilities[3].requirement = 1;
        y_freelancer.dressphere_abilities[3].ability = 0x3214; // Mach Fan

        y_freelancer.dressphere_abilities[4].requirement = 0;
        y_freelancer.dressphere_abilities[4].ability = 0x3216; // Love Tap

        y_freelancer.dressphere_abilities[5].requirement = 1;
        y_freelancer.dressphere_abilities[5].ability = 0x3215; // Ecstasy

        y_freelancer.dressphere_abilities[6].requirement = 1;
        y_freelancer.dressphere_abilities[6].ability = 0x3174; // Mug

        y_freelancer.dressphere_abilities[7].requirement = 0x3174;
        y_freelancer.dressphere_abilities[7].ability = 0x3175; // Nab Gil

        y_freelancer.dressphere_abilities[8].requirement = 1;
        y_freelancer.dressphere_abilities[8].ability = 0x3219; // White Wind

        y_freelancer.dressphere_abilities[9].requirement = 0x3219;
        y_freelancer.dressphere_abilities[9].ability = 0x321A; // Mighty Guard

        y_freelancer.dressphere_abilities[10].requirement = 0;
        y_freelancer.dressphere_abilities[10].ability = 0x3217; //  Luck

        y_freelancer.dressphere_abilities[11].requirement = 1;
        y_freelancer.dressphere_abilities[11].ability = 0x3218; // Felicity

        y_freelancer.dressphere_abilities[12].requirement = 1;
        y_freelancer.dressphere_abilities[12].ability = 0x8010; //Double Items

        y_freelancer.dressphere_abilities[13].requirement = 0x8010;
        y_freelancer.dressphere_abilities[13].ability = 0x800f; // Gillionaire

        y_freelancer.dressphere_abilities[14].requirement = 1;
        y_freelancer.dressphere_abilities[14].ability = 0x8070; // Critical

        y_freelancer.dressphere_abilities[15].requirement = 0x8070;
        y_freelancer.dressphere_abilities[15].ability = 0x8079; // SOS Spellspring
    }

    public unsafe void InitYunaLeblancGoon() {
        ref Job y_leblancgoon = ref *yuna_leblancgoon_ptr;

        y_leblancgoon.name_offset.text_offset = 2492;
        y_leblancgoon.help_offset.text_offset = 2357;
        y_leblancgoon.user = 1;
        y_leblancgoon.dressphere_menu_ordering = 17;
        y_leblancgoon.icon = 84;
        y_leblancgoon.berserk_action = 0x302d;

        // stat growth
        y_leblancgoon.growth_hp.linear_mult = 38;
        y_leblancgoon.growth_hp.quadratic_div = 133;
        y_leblancgoon.growth_hp.base_amount = 78;

        y_leblancgoon.growth_mp.linear_mult = 26;
        y_leblancgoon.growth_mp.quadratic_div = 180;
        y_leblancgoon.growth_mp.base_amount = 18;

        y_leblancgoon.growth_strength.linear_mult = 20;
        y_leblancgoon.growth_strength.linear_div = 10;
        y_leblancgoon.growth_strength.base_amount = 15;
        y_leblancgoon.growth_strength.quadratic_div_a = 12;
        y_leblancgoon.growth_strength.quadratic_div_b = 1;

        y_leblancgoon.growth_defense.linear_mult = 3;
        y_leblancgoon.growth_defense.linear_div = 200;
        y_leblancgoon.growth_defense.base_amount = 32;
        y_leblancgoon.growth_defense.quadratic_div_a = 200;
        y_leblancgoon.growth_defense.quadratic_div_b = 2;

        y_leblancgoon.growth_magic.linear_mult = 6;
        y_leblancgoon.growth_magic.linear_div = 4;
        y_leblancgoon.growth_magic.base_amount = 18;
        y_leblancgoon.growth_magic.quadratic_div_a = 200;
        y_leblancgoon.growth_magic.quadratic_div_b = 2;

        y_leblancgoon.growth_magic_defense.linear_mult = 3;
        y_leblancgoon.growth_magic_defense.linear_div = 16;
        y_leblancgoon.growth_magic_defense.base_amount = 38;
        y_leblancgoon.growth_magic_defense.quadratic_div_a = 200;
        y_leblancgoon.growth_magic_defense.quadratic_div_b = 2;

        y_leblancgoon.growth_agility.linear_mult = 0;
        y_leblancgoon.growth_agility.linear_div = 17;
        y_leblancgoon.growth_agility.base_amount = 74;
        y_leblancgoon.growth_agility.quadratic_div_a = 200;
        y_leblancgoon.growth_agility.quadratic_div_b = 4;

        y_leblancgoon.growth_evasion.linear_mult = 0;
        y_leblancgoon.growth_evasion.linear_div = 20;
        y_leblancgoon.growth_evasion.base_amount = 10;
        y_leblancgoon.growth_evasion.quadratic_div_a = 200;
        y_leblancgoon.growth_evasion.quadratic_div_b = 4;

        y_leblancgoon.growth_accuracy.linear_mult = 0;
        y_leblancgoon.growth_accuracy.linear_div = 17;
        y_leblancgoon.growth_accuracy.base_amount = 120;
        y_leblancgoon.growth_accuracy.quadratic_div_a = 200;
        y_leblancgoon.growth_accuracy.quadratic_div_b = 4;

        y_leblancgoon.growth_luck.linear_mult = 0;
        y_leblancgoon.growth_luck.linear_div = 22;
        y_leblancgoon.growth_luck.base_amount = 13;
        y_leblancgoon.growth_luck.quadratic_div_a = 200;
        y_leblancgoon.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        y_leblancgoon.yuna_weapon_data[0].weapon_model = 0x113E;
        y_leblancgoon.yuna_weapon_data[0].weapon_position = 5;
        y_leblancgoon.yuna_weapon_data[1].weapon_model = 0;
        y_leblancgoon.yuna_weapon_data[1].weapon_position = 0;
        y_leblancgoon.yuna_weapon_data[2].weapon_model = 0;
        y_leblancgoon.yuna_weapon_data[2].weapon_position = 0;
        y_leblancgoon.yuna_weapon_data[3].weapon_model = 0;
        y_leblancgoon.yuna_weapon_data[3].weapon_position = 0;


        // abilities
        y_leblancgoon.dressphere_abilities[0].requirement = 0;
        y_leblancgoon.dressphere_abilities[0].ability = 0x302D; // Attack
        y_leblancgoon.dressphere_abilities[1].requirement = 0;
        y_leblancgoon.dressphere_abilities[1].ability = 0;
        y_leblancgoon.dressphere_abilities[2].requirement = 0;
        y_leblancgoon.dressphere_abilities[2].ability = 0;
        y_leblancgoon.dressphere_abilities[3].requirement = 0;
        y_leblancgoon.dressphere_abilities[3].ability = 0;
        y_leblancgoon.dressphere_abilities[4].requirement = 0;
        y_leblancgoon.dressphere_abilities[4].ability = 0;
        y_leblancgoon.dressphere_abilities[5].requirement = 0;
        y_leblancgoon.dressphere_abilities[5].ability = 0;
        y_leblancgoon.dressphere_abilities[6].requirement = 0;
        y_leblancgoon.dressphere_abilities[6].ability = 0;
        y_leblancgoon.dressphere_abilities[7].requirement = 0;
        y_leblancgoon.dressphere_abilities[7].ability = 0;
        y_leblancgoon.dressphere_abilities[8].requirement = 0;
        y_leblancgoon.dressphere_abilities[8].ability = 0;
        y_leblancgoon.dressphere_abilities[9].requirement = 0;
        y_leblancgoon.dressphere_abilities[9].ability = 0;
        y_leblancgoon.dressphere_abilities[10].requirement = 0;
        y_leblancgoon.dressphere_abilities[10].ability = 0;
        y_leblancgoon.dressphere_abilities[11].requirement = 0;
        y_leblancgoon.dressphere_abilities[11].ability = 0;
        y_leblancgoon.dressphere_abilities[12].requirement = 0;
        y_leblancgoon.dressphere_abilities[12].ability = 0;
        y_leblancgoon.dressphere_abilities[13].requirement = 0;
        y_leblancgoon.dressphere_abilities[13].ability = 0;
        y_leblancgoon.dressphere_abilities[14].requirement = 0;
        y_leblancgoon.dressphere_abilities[14].ability = 0;
        y_leblancgoon.dressphere_abilities[15].requirement = 0;
        y_leblancgoon.dressphere_abilities[15].ability = 0;

    }

    public unsafe void InitRikkuFestivalist()
    {
        // read and get copy of Job struct
        Job r_festivalist = *(Job*)h_MsGetRomJob(1, 0x501E, null);

        r_festivalist.name_offset.text_offset = 2345;
        r_festivalist.help_offset.text_offset = 2357;
        r_festivalist.user = 1;
        r_festivalist.dressphere_menu_ordering = 15;
        r_festivalist.icon = 99;
        r_festivalist.berserk_action = 0x302D;

        // stat growth
        r_festivalist.growth_hp.linear_mult = 44;
        r_festivalist.growth_hp.quadratic_div = 73;
        r_festivalist.growth_hp.base_amount = 70;

        r_festivalist.growth_mp.linear_mult = 22;
        r_festivalist.growth_mp.quadratic_div = 122;
        r_festivalist.growth_mp.base_amount = 44;

        r_festivalist.growth_strength.linear_mult = 20;
        r_festivalist.growth_strength.linear_div = 4;
        r_festivalist.growth_strength.base_amount = 14;
        r_festivalist.growth_strength.quadratic_div_a = 9;
        r_festivalist.growth_strength.quadratic_div_b = 1;

        r_festivalist.growth_defense.linear_mult = 5;
        r_festivalist.growth_defense.linear_div = 7;
        r_festivalist.growth_defense.base_amount = 8;
        r_festivalist.growth_defense.quadratic_div_a = 120;
        r_festivalist.growth_defense.quadratic_div_b = 1;

        r_festivalist.growth_magic.linear_mult = 11;
        r_festivalist.growth_magic.linear_div = 12;
        r_festivalist.growth_magic.base_amount = 10;
        r_festivalist.growth_magic.quadratic_div_a = 20;
        r_festivalist.growth_magic.quadratic_div_b = 1;

        r_festivalist.growth_magic_defense.linear_mult = 5;
        r_festivalist.growth_magic_defense.linear_div = 8;
        r_festivalist.growth_magic_defense.base_amount = 36;
        r_festivalist.growth_magic_defense.quadratic_div_a = 200;
        r_festivalist.growth_magic_defense.quadratic_div_b = 2;

        r_festivalist.growth_agility.linear_mult = 6;
        r_festivalist.growth_agility.linear_div = 80;
        r_festivalist.growth_agility.base_amount = 57;
        r_festivalist.growth_agility.quadratic_div_a = 200;
        r_festivalist.growth_agility.quadratic_div_b = 4;

        r_festivalist.growth_evasion.linear_mult = 0;
        r_festivalist.growth_evasion.linear_div = 8;
        r_festivalist.growth_evasion.base_amount = 13;
        r_festivalist.growth_evasion.quadratic_div_a = 200;
        r_festivalist.growth_evasion.quadratic_div_b = 4;

        r_festivalist.growth_accuracy.linear_mult = 1;
        r_festivalist.growth_accuracy.linear_div = 7;
        r_festivalist.growth_accuracy.base_amount = 144;
        r_festivalist.growth_accuracy.quadratic_div_a = 200;
        r_festivalist.growth_accuracy.quadratic_div_b = 4;

        r_festivalist.growth_luck.linear_mult = 0;
        r_festivalist.growth_luck.linear_div = 7;
        r_festivalist.growth_luck.base_amount = 23;
        r_festivalist.growth_luck.quadratic_div_a = 200;
        r_festivalist.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        r_festivalist.rikku_weapon_data[0].weapon_model = 0x113e;
        r_festivalist.rikku_weapon_data[0].weapon_position = 5;
        r_festivalist.rikku_weapon_data[1].weapon_model = 0;
        r_festivalist.rikku_weapon_data[1].weapon_position = 0;
        r_festivalist.rikku_weapon_data[2].weapon_model = 0;
        r_festivalist.rikku_weapon_data[2].weapon_position = 0;
        r_festivalist.rikku_weapon_data[3].weapon_model = 0;
        r_festivalist.rikku_weapon_data[3].weapon_position = 0;


        // abilities
        r_festivalist.dressphere_abilities[0].requirement = 0;
        r_festivalist.dressphere_abilities[0].ability = 0x312F; // Attack

        r_festivalist.dressphere_abilities[1].requirement = 1;
        r_festivalist.dressphere_abilities[1].ability = 0x31FB; // Cheer

        r_festivalist.dressphere_abilities[2].requirement = 1;
        r_festivalist.dressphere_abilities[2].ability = 0x306F; // Delay Attack

        r_festivalist.dressphere_abilities[3].requirement = 0x306F;
        r_festivalist.dressphere_abilities[3].ability = 0x3070; // Delay Buster

        r_festivalist.dressphere_abilities[4].requirement = 1;
        r_festivalist.dressphere_abilities[4].ability = 0x3176; // Haste

        r_festivalist.dressphere_abilities[5].requirement = 0x3176;
        r_festivalist.dressphere_abilities[5].ability = 0x3177; // Hastega

        r_festivalist.dressphere_abilities[6].requirement = 1;
        r_festivalist.dressphere_abilities[6].ability = 0x30C7; // Slow

        r_festivalist.dressphere_abilities[7].requirement = 0x3070;
        r_festivalist.dressphere_abilities[7].ability = 0x31F5; // Quick Hit

        r_festivalist.dressphere_abilities[8].requirement = 0;
        r_festivalist.dressphere_abilities[8].ability = 0x3206; // Spiral Cut

        r_festivalist.dressphere_abilities[9].requirement = 0x3176;
        r_festivalist.dressphere_abilities[9].ability = 0x3207; // Slice and Dice

        r_festivalist.dressphere_abilities[10].requirement = 0x3177;
        r_festivalist.dressphere_abilities[10].ability = 0x3208; // Energy Rain

        r_festivalist.dressphere_abilities[11].requirement = 0x3208;
        r_festivalist.dressphere_abilities[11].ability = 0x3209; // Blitz Ace

        r_festivalist.dressphere_abilities[12].requirement = 1;
        r_festivalist.dressphere_abilities[12].ability = 0x8027; // Ghiki L3 -> T. Swordplay+

        r_festivalist.dressphere_abilities[13].requirement = 0x3207;
        r_festivalist.dressphere_abilities[13].ability = 0x8003; // Evade and Counter

        r_festivalist.dressphere_abilities[14].requirement = 1;
        r_festivalist.dressphere_abilities[14].ability = 0x805F; // Slowproof

        r_festivalist.dressphere_abilities[15].requirement = 0x805F;
        r_festivalist.dressphere_abilities[15].ability = 0x8061; // Stopproof

        // Write the changes to memory
        *(Job*)h_MsGetRomJob(1, 0x501E, null) = r_festivalist;
    }


    public unsafe void InitRikkuFreelancer() {
        ref Job rikku_freelancer = ref *rikku_freelancer_ptr;

        // data
        //rikku_freelancer.name_offset = 2345;
        rikku_freelancer.name_offset.text_offset = 2480;
        rikku_freelancer.help_offset.text_offset = 2357;
        rikku_freelancer.user = 1;
        rikku_freelancer.dressphere_menu_ordering = 17;
        rikku_freelancer.icon = 90;
        rikku_freelancer.berserk_action = 0x321B;

        // stat growth
        rikku_freelancer.growth_hp.linear_mult = 35;
        rikku_freelancer.growth_hp.quadratic_div = 77;
        rikku_freelancer.growth_hp.base_amount = 77;

        rikku_freelancer.growth_mp.linear_mult = 26;
        rikku_freelancer.growth_mp.quadratic_div = 180;
        rikku_freelancer.growth_mp.base_amount = 18;

        rikku_freelancer.growth_strength.linear_mult = 17;
        rikku_freelancer.growth_strength.linear_div = 88;
        rikku_freelancer.growth_strength.base_amount = 13;
        rikku_freelancer.growth_strength.quadratic_div_a = 11;
        rikku_freelancer.growth_strength.quadratic_div_b = 1;

        rikku_freelancer.growth_defense.linear_mult = 5;
        rikku_freelancer.growth_defense.linear_div = 7;
        rikku_freelancer.growth_defense.base_amount = 8;
        rikku_freelancer.growth_defense.quadratic_div_a = 120;
        rikku_freelancer.growth_defense.quadratic_div_b = 1;

        rikku_freelancer.growth_magic.linear_mult = 11;
        rikku_freelancer.growth_magic.linear_div = 12;
        rikku_freelancer.growth_magic.base_amount = 10;
        rikku_freelancer.growth_magic.quadratic_div_a = 20;
        rikku_freelancer.growth_magic.quadratic_div_b = 1;

        rikku_freelancer.growth_magic_defense.linear_mult = 5;
        rikku_freelancer.growth_magic_defense.linear_div = 8;
        rikku_freelancer.growth_magic_defense.base_amount = 36;
        rikku_freelancer.growth_magic_defense.quadratic_div_a = 200;
        rikku_freelancer.growth_magic_defense.quadratic_div_b = 2;

        rikku_freelancer.growth_agility.linear_mult = 6;
        rikku_freelancer.growth_agility.linear_div = 80;
        rikku_freelancer.growth_agility.base_amount = 49;
        rikku_freelancer.growth_agility.quadratic_div_a = 200;
        rikku_freelancer.growth_agility.quadratic_div_b = 4;

        rikku_freelancer.growth_evasion.linear_mult = 0;
        rikku_freelancer.growth_evasion.linear_div = 8;
        rikku_freelancer.growth_evasion.base_amount = 17;
        rikku_freelancer.growth_evasion.quadratic_div_a = 200;
        rikku_freelancer.growth_evasion.quadratic_div_b = 4;

        rikku_freelancer.growth_accuracy.linear_mult = 2;
        rikku_freelancer.growth_accuracy.linear_div = 11;
        rikku_freelancer.growth_accuracy.base_amount = 155;
        rikku_freelancer.growth_accuracy.quadratic_div_a = 200;
        rikku_freelancer.growth_accuracy.quadratic_div_b = 4;

        rikku_freelancer.growth_luck.linear_mult = 0;
        rikku_freelancer.growth_luck.linear_div = 27;
        rikku_freelancer.growth_luck.base_amount = 9;
        rikku_freelancer.growth_luck.quadratic_div_a = 200;
        rikku_freelancer.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        rikku_freelancer.rikku_weapon_data[0].weapon_model = 0;
        rikku_freelancer.rikku_weapon_data[0].weapon_position = 0;
        rikku_freelancer.rikku_weapon_data[1].weapon_model = 0;
        rikku_freelancer.rikku_weapon_data[1].weapon_position = 0;
        rikku_freelancer.rikku_weapon_data[2].weapon_model = 0;
        rikku_freelancer.rikku_weapon_data[2].weapon_position = 0;
        rikku_freelancer.rikku_weapon_data[3].weapon_model = 0;
        rikku_freelancer.rikku_weapon_data[3].weapon_position = 0;

        // abilities
        rikku_freelancer.dressphere_abilities[0].requirement = 0;
        rikku_freelancer.dressphere_abilities[0].ability = 0x321B; // Attack
        rikku_freelancer.dressphere_abilities[1].requirement = 1;
        rikku_freelancer.dressphere_abilities[1].ability = 0x3220; // Hail of Bullets
        rikku_freelancer.dressphere_abilities[2].requirement = 0;
        rikku_freelancer.dressphere_abilities[2].ability = 0x321c; // Dark Shot
        rikku_freelancer.dressphere_abilities[3].requirement = 1;
        rikku_freelancer.dressphere_abilities[3].ability = 0x321d; // Sil shot
        rikku_freelancer.dressphere_abilities[4].requirement = 0x321d;
        rikku_freelancer.dressphere_abilities[4].ability = 0x321E; // Poison SHot
        rikku_freelancer.dressphere_abilities[5].requirement = 0x321e;
        rikku_freelancer.dressphere_abilities[5].ability = 0x321F; // Slow Shot
        rikku_freelancer.dressphere_abilities[6].requirement = 0x3220;
        rikku_freelancer.dressphere_abilities[6].ability = 0x303A; // Table-Turner
        rikku_freelancer.dressphere_abilities[7].requirement = 0x303a;
        rikku_freelancer.dressphere_abilities[7].ability = 0x3038; // On the Level
        rikku_freelancer.dressphere_abilities[8].requirement = 1;
        rikku_freelancer.dressphere_abilities[8].ability = 0x306d; // Quick Shot;
        rikku_freelancer.dressphere_abilities[9].requirement = 0x3220;
        rikku_freelancer.dressphere_abilities[9].ability = 0x3221; // Russian Roulette
        rikku_freelancer.dressphere_abilities[10].requirement = 1;
        rikku_freelancer.dressphere_abilities[10].ability = 0x3183; // Pineapple
        rikku_freelancer.dressphere_abilities[11].requirement = 0x3183;
        rikku_freelancer.dressphere_abilities[11].ability = 0x3184; // Potato Masher
        rikku_freelancer.dressphere_abilities[12].requirement = 1;
        rikku_freelancer.dressphere_abilities[12].ability = 0x307c; // Hayate
        rikku_freelancer.dressphere_abilities[13].requirement = 1;
        rikku_freelancer.dressphere_abilities[13].ability = 0x307b; // Clean Slate
        rikku_freelancer.dressphere_abilities[14].requirement = 1;
        rikku_freelancer.dressphere_abilities[14].ability = 0x8062; // Sense Preserver
        rikku_freelancer.dressphere_abilities[15].requirement = 0x807b;
        rikku_freelancer.dressphere_abilities[15].ability = 0x807b; // SOS Critical

        // Job Creature Data
    }

    public unsafe void InitRikkuLeblancGoon() {
        ref Job rikku_leblancgoon = ref *rikku_leblancgoon_ptr;

        // data
        //rikku_leblancgoon.name_offset = 2345;
        rikku_leblancgoon.name_offset.text_offset = 2492;
        rikku_leblancgoon.help_offset.text_offset = 2357;
        rikku_leblancgoon.user = 1;
        rikku_leblancgoon.dressphere_menu_ordering = 17;
        rikku_leblancgoon.icon = 84;
        rikku_leblancgoon.berserk_action = 0x302d;

        // stat growth
        rikku_leblancgoon.growth_hp.linear_mult = 38;
        rikku_leblancgoon.growth_hp.quadratic_div = 133;
        rikku_leblancgoon.growth_hp.base_amount = 78;

        rikku_leblancgoon.growth_mp.linear_mult = 26;
        rikku_leblancgoon.growth_mp.quadratic_div = 180;
        rikku_leblancgoon.growth_mp.base_amount = 18;

        rikku_leblancgoon.growth_strength.linear_mult = 20;
        rikku_leblancgoon.growth_strength.linear_div = 10;
        rikku_leblancgoon.growth_strength.base_amount = 15;
        rikku_leblancgoon.growth_strength.quadratic_div_a = 12;
        rikku_leblancgoon.growth_strength.quadratic_div_b = 1;

        rikku_leblancgoon.growth_defense.linear_mult = 3;
        rikku_leblancgoon.growth_defense.linear_div = 200;
        rikku_leblancgoon.growth_defense.base_amount = 32;
        rikku_leblancgoon.growth_defense.quadratic_div_a = 200;
        rikku_leblancgoon.growth_defense.quadratic_div_b = 2;

        rikku_leblancgoon.growth_magic.linear_mult = 6;
        rikku_leblancgoon.growth_magic.linear_div = 4;
        rikku_leblancgoon.growth_magic.base_amount = 18;
        rikku_leblancgoon.growth_magic.quadratic_div_a = 200;
        rikku_leblancgoon.growth_magic.quadratic_div_b = 2;

        rikku_leblancgoon.growth_magic_defense.linear_mult = 3;
        rikku_leblancgoon.growth_magic_defense.linear_div = 16;
        rikku_leblancgoon.growth_magic_defense.base_amount = 38;
        rikku_leblancgoon.growth_magic_defense.quadratic_div_a = 200;
        rikku_leblancgoon.growth_magic_defense.quadratic_div_b = 2;

        rikku_leblancgoon.growth_agility.linear_mult = 0;
        rikku_leblancgoon.growth_agility.linear_div = 17;
        rikku_leblancgoon.growth_agility.base_amount = 74;
        rikku_leblancgoon.growth_agility.quadratic_div_a = 200;
        rikku_leblancgoon.growth_agility.quadratic_div_b = 4;

        rikku_leblancgoon.growth_evasion.linear_mult = 0;
        rikku_leblancgoon.growth_evasion.linear_div = 20;
        rikku_leblancgoon.growth_evasion.base_amount = 10;
        rikku_leblancgoon.growth_evasion.quadratic_div_a = 200;
        rikku_leblancgoon.growth_evasion.quadratic_div_b = 4;

        rikku_leblancgoon.growth_accuracy.linear_mult = 0;
        rikku_leblancgoon.growth_accuracy.linear_div = 17;
        rikku_leblancgoon.growth_accuracy.base_amount = 120;
        rikku_leblancgoon.growth_accuracy.quadratic_div_a = 200;
        rikku_leblancgoon.growth_accuracy.quadratic_div_b = 4;

        rikku_leblancgoon.growth_luck.linear_mult = 0;
        rikku_leblancgoon.growth_luck.linear_div = 22;
        rikku_leblancgoon.growth_luck.base_amount = 13;
        rikku_leblancgoon.growth_luck.quadratic_div_a = 200;
        rikku_leblancgoon.growth_luck.quadratic_div_b = 4;

        //weapon and armor
        rikku_leblancgoon.rikku_weapon_data[0].weapon_model = 0x113E;
        rikku_leblancgoon.rikku_weapon_data[0].weapon_position = 5;
        rikku_leblancgoon.rikku_weapon_data[1].weapon_model = 0;
        rikku_leblancgoon.rikku_weapon_data[1].weapon_position = 0;
        rikku_leblancgoon.rikku_weapon_data[2].weapon_model = 0;
        rikku_leblancgoon.rikku_weapon_data[2].weapon_position = 0;
        rikku_leblancgoon.rikku_weapon_data[3].weapon_model = 0;
        rikku_leblancgoon.rikku_weapon_data[3].weapon_position = 0;

        // abilities
        rikku_leblancgoon.dressphere_abilities[0].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[0].ability = 0x302D; // Attack
        rikku_leblancgoon.dressphere_abilities[1].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[1].ability = 0;
        rikku_leblancgoon.dressphere_abilities[2].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[2].ability = 0;
        rikku_leblancgoon.dressphere_abilities[3].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[3].ability = 0;
        rikku_leblancgoon.dressphere_abilities[4].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[4].ability = 0;
        rikku_leblancgoon.dressphere_abilities[5].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[5].ability = 0;
        rikku_leblancgoon.dressphere_abilities[6].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[6].ability = 0;
        rikku_leblancgoon.dressphere_abilities[7].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[7].ability = 0;
        rikku_leblancgoon.dressphere_abilities[8].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[8].ability = 0;
        rikku_leblancgoon.dressphere_abilities[9].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[9].ability = 0;
        rikku_leblancgoon.dressphere_abilities[10].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[10].ability = 0;
        rikku_leblancgoon.dressphere_abilities[11].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[11].ability = 0;
        rikku_leblancgoon.dressphere_abilities[12].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[12].ability = 0;
        rikku_leblancgoon.dressphere_abilities[13].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[13].ability = 0;
        rikku_leblancgoon.dressphere_abilities[14].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[14].ability = 0;
        rikku_leblancgoon.dressphere_abilities[15].requirement = 0;
        rikku_leblancgoon.dressphere_abilities[15].ability = 0;

        // Job Creature Data
    }

    public unsafe void InitPaineFestivalist()
    {
        // read and get copy of Job struct
        Job p_festivalist = *(Job*)h_MsGetRomJob(2, 0x501F, null);

        p_festivalist.name_offset.text_offset = 2345;
        p_festivalist.help_offset.text_offset = 2357;
        p_festivalist.user = 2;
        p_festivalist.dressphere_menu_ordering = 15;
        p_festivalist.icon = 99;
        p_festivalist.berserk_action = 0x302D;

        // stat growth
        p_festivalist.growth_hp.linear_mult = 38;
        p_festivalist.growth_hp.quadratic_div = 133;
        p_festivalist.growth_hp.base_amount = 78;

        p_festivalist.growth_mp.linear_mult = 26;
        p_festivalist.growth_mp.quadratic_div = 180;
        p_festivalist.growth_mp.base_amount = 18;

        p_festivalist.growth_strength.linear_mult = 20;
        p_festivalist.growth_strength.linear_div = 4;
        p_festivalist.growth_strength.base_amount = 12;
        p_festivalist.growth_strength.quadratic_div_a = 9;
        p_festivalist.growth_strength.quadratic_div_b = 1;

        p_festivalist.growth_defense.linear_mult = 3;
        p_festivalist.growth_defense.linear_div = 200;
        p_festivalist.growth_defense.base_amount = 32;
        p_festivalist.growth_defense.quadratic_div_a = 200;
        p_festivalist.growth_defense.quadratic_div_b = 2;

        p_festivalist.growth_magic.linear_mult = 18;
        p_festivalist.growth_magic.linear_div = 10;
        p_festivalist.growth_magic.base_amount = 28;
        p_festivalist.growth_magic.quadratic_div_a = 10;
        p_festivalist.growth_magic.quadratic_div_b = 1;

        p_festivalist.growth_magic_defense.linear_mult = 3;
        p_festivalist.growth_magic_defense.linear_div = 16;
        p_festivalist.growth_magic_defense.base_amount = 38;
        p_festivalist.growth_magic_defense.quadratic_div_a = 200;
        p_festivalist.growth_magic_defense.quadratic_div_b = 2;

        p_festivalist.growth_agility.linear_mult = 2;
        p_festivalist.growth_agility.linear_div = 17;
        p_festivalist.growth_agility.base_amount = 50;
        p_festivalist.growth_agility.quadratic_div_a = 200;
        p_festivalist.growth_agility.quadratic_div_b = 4;

        p_festivalist.growth_evasion.linear_mult = 0;
        p_festivalist.growth_evasion.linear_div = 20;
        p_festivalist.growth_evasion.base_amount = 10;
        p_festivalist.growth_evasion.quadratic_div_a = 200;
        p_festivalist.growth_evasion.quadratic_div_b = 4;

        p_festivalist.growth_accuracy.linear_mult = 0;
        p_festivalist.growth_accuracy.linear_div = 17;
        p_festivalist.growth_accuracy.base_amount = 120;
        p_festivalist.growth_accuracy.quadratic_div_a = 200;
        p_festivalist.growth_accuracy.quadratic_div_b = 4;

        p_festivalist.growth_luck.linear_mult = 0;
        p_festivalist.growth_luck.linear_div = 22;
        p_festivalist.growth_luck.base_amount = 13;
        p_festivalist.growth_luck.quadratic_div_a = 200;
        p_festivalist.growth_luck.quadratic_div_b = 4;


        //weapon and armor
        p_festivalist.paine_weapon_data[0].weapon_model = 0x1140;
        p_festivalist.paine_weapon_data[0].weapon_position = 5;
        p_festivalist.paine_weapon_data[1].weapon_model = 0;
        p_festivalist.paine_weapon_data[1].weapon_position = 0;
        p_festivalist.paine_weapon_data[2].weapon_model = 0;
        p_festivalist.paine_weapon_data[2].weapon_position = 0;
        p_festivalist.paine_weapon_data[3].weapon_model = 0;
        p_festivalist.paine_weapon_data[3].weapon_position = 0;


        // abilities
        p_festivalist.dressphere_abilities[0].requirement = 0;
        p_festivalist.dressphere_abilities[0].ability = 0x302D; // P. Attack

        p_festivalist.dressphere_abilities[1].requirement = 1;
        p_festivalist.dressphere_abilities[1].ability = 0x31FC; // Multi-Cura

        p_festivalist.dressphere_abilities[2].requirement = 0;
        p_festivalist.dressphere_abilities[2].ability = 0x31F9; // Dark

        p_festivalist.dressphere_abilities[3].requirement = 1;
        p_festivalist.dressphere_abilities[3].ability = 0x31FF; // Darkra

        p_festivalist.dressphere_abilities[4].requirement = 0x31FF;
        p_festivalist.dressphere_abilities[4].ability = 0x31F6; // Requiem

        p_festivalist.dressphere_abilities[5].requirement = 1;
        p_festivalist.dressphere_abilities[5].ability = 0x320D; // Multi-Fira

        p_festivalist.dressphere_abilities[6].requirement = 1;
        p_festivalist.dressphere_abilities[6].ability = 0x320C; // Multi-Blizzara

        p_festivalist.dressphere_abilities[7].requirement = 1;
        p_festivalist.dressphere_abilities[7].ability = 0x320E; // Multi-Thundara

        p_festivalist.dressphere_abilities[8].requirement = 1;
        p_festivalist.dressphere_abilities[8].ability = 0x320F; // Multi-Watera

        p_festivalist.dressphere_abilities[9].requirement = 0x31FC;
        p_festivalist.dressphere_abilities[9].ability = 0x3210; // Syphon

        p_festivalist.dressphere_abilities[10].requirement = 1;
        p_festivalist.dressphere_abilities[10].ability = 0x3211; // Souleater

        p_festivalist.dressphere_abilities[11].requirement = 0x3210;
        p_festivalist.dressphere_abilities[11].ability = 0x320B; // Bubble

        p_festivalist.dressphere_abilities[12].requirement = 0x3211;
        p_festivalist.dressphere_abilities[12].ability = 0x320A; // Balance

        p_festivalist.dressphere_abilities[13].requirement = 1;
        p_festivalist.dressphere_abilities[13].ability = 0x8077; // SOS Regen

        p_festivalist.dressphere_abilities[14].requirement = 1;
        p_festivalist.dressphere_abilities[14].ability = 0x801A; // Sage Lv.2

        p_festivalist.dressphere_abilities[15].requirement = 0x801A;
        p_festivalist.dressphere_abilities[15].ability = 0x801B; // Sage Lv.3

        // Write the changes to memory
        *(Job*)h_MsGetRomJob(2, 0x501F, null) = p_festivalist;
    }

    public unsafe void InitPaineFreelancer() {
        ref Job paine_freelancer = ref *paine_freelancer_ptr;

        // data
        //paine_freelancer.name_offset = 2345;
        paine_freelancer.name_offset.text_offset = 2480;
        paine_freelancer.help_offset.text_offset = 2357;
        paine_freelancer.user = 1;
        paine_freelancer.dressphere_menu_ordering = 17;
        paine_freelancer.icon = 90;
        paine_freelancer.berserk_action = 0x302d;

        // stat growth
        paine_freelancer.growth_hp.linear_mult = 35;
        paine_freelancer.growth_hp.quadratic_div = 77;
        paine_freelancer.growth_hp.base_amount = 77;

        paine_freelancer.growth_mp.linear_mult = 26;
        paine_freelancer.growth_mp.quadratic_div = 180;
        paine_freelancer.growth_mp.base_amount = 18;

        paine_freelancer.growth_strength.linear_mult = 19;
        paine_freelancer.growth_strength.linear_div = 88;
        paine_freelancer.growth_strength.base_amount = 13;
        paine_freelancer.growth_strength.quadratic_div_a = 13;
        paine_freelancer.growth_strength.quadratic_div_b = 1;

        paine_freelancer.growth_defense.linear_mult = 11;
        paine_freelancer.growth_defense.linear_div = 64;
        paine_freelancer.growth_defense.base_amount = 79;
        paine_freelancer.growth_defense.quadratic_div_a = 13;
        paine_freelancer.growth_defense.quadratic_div_b = 1;

        paine_freelancer.growth_magic.linear_mult = 4;
        paine_freelancer.growth_magic.linear_div = 13;
        paine_freelancer.growth_magic.base_amount = 12;
        paine_freelancer.growth_magic.quadratic_div_a = 200;
        paine_freelancer.growth_magic.quadratic_div_b = 2;

        paine_freelancer.growth_magic_defense.linear_mult = 3;
        paine_freelancer.growth_magic_defense.linear_div = 16;
        paine_freelancer.growth_magic_defense.base_amount = 38;
        paine_freelancer.growth_magic_defense.quadratic_div_a = 200;
        paine_freelancer.growth_magic_defense.quadratic_div_b = 2;

        paine_freelancer.growth_agility.linear_mult = 4;
        paine_freelancer.growth_agility.linear_div = 16;
        paine_freelancer.growth_agility.base_amount = 42;
        paine_freelancer.growth_agility.quadratic_div_a = 200;
        paine_freelancer.growth_agility.quadratic_div_b = 4;

        paine_freelancer.growth_evasion.linear_mult = 0;
        paine_freelancer.growth_evasion.linear_div = 20;
        paine_freelancer.growth_evasion.base_amount = 2;
        paine_freelancer.growth_evasion.quadratic_div_a = 200;
        paine_freelancer.growth_evasion.quadratic_div_b = 4;

        paine_freelancer.growth_accuracy.linear_mult = 0;
        paine_freelancer.growth_accuracy.linear_div = 17;
        paine_freelancer.growth_accuracy.base_amount = 100;
        paine_freelancer.growth_accuracy.quadratic_div_a = 200;
        paine_freelancer.growth_accuracy.quadratic_div_b = 4;

        paine_freelancer.growth_luck.linear_mult = 0;
        paine_freelancer.growth_luck.linear_div = 20;
        paine_freelancer.growth_luck.base_amount = 4;
        paine_freelancer.growth_luck.quadratic_div_a = 200;
        paine_freelancer.growth_luck.quadratic_div_b = 4;

        //weapon and armor
        paine_freelancer.paine_weapon_data[0].weapon_model = 0x1109;
        paine_freelancer.paine_weapon_data[0].weapon_position = 14;
        paine_freelancer.paine_weapon_data[1].weapon_model = 0;
        paine_freelancer.paine_weapon_data[1].weapon_position = 0;
        paine_freelancer.paine_weapon_data[2].weapon_model = 0;
        paine_freelancer.paine_weapon_data[2].weapon_position = 0;
        paine_freelancer.paine_weapon_data[3].weapon_model = 0;
        paine_freelancer.paine_weapon_data[3].weapon_position = 0;

        // abilities
        paine_freelancer.dressphere_abilities[0].requirement = 0;
        paine_freelancer.dressphere_abilities[0].ability = 0x312F; // Attack
        paine_freelancer.dressphere_abilities[1].requirement = 0x3224;
        paine_freelancer.dressphere_abilities[1].ability = 0x3222; // Huggles
        paine_freelancer.dressphere_abilities[2].requirement = 0;
        paine_freelancer.dressphere_abilities[2].ability = 0x3223; // Pirouette Pitch
        paine_freelancer.dressphere_abilities[3].requirement = 1;
        paine_freelancer.dressphere_abilities[3].ability = 0x3224; // Supercollider
        paine_freelancer.dressphere_abilities[4].requirement = 1;
        paine_freelancer.dressphere_abilities[4].ability = 0x3226; // Shockwave (Concussive Shock)
        paine_freelancer.dressphere_abilities[5].requirement = 0x3227;
        paine_freelancer.dressphere_abilities[5].ability = 0x3227; // Shockstorm (Concussive Blast)
        paine_freelancer.dressphere_abilities[6].requirement = 0x3224;
        paine_freelancer.dressphere_abilities[6].ability = 0x3225; // Cheer
        paine_freelancer.dressphere_abilities[7].requirement = 1;
        paine_freelancer.dressphere_abilities[7].ability = 0x3064; // Sentinel 
        paine_freelancer.dressphere_abilities[8].requirement = 1;
        paine_freelancer.dressphere_abilities[8].ability = 0x308c; // Mad Rush
        paine_freelancer.dressphere_abilities[9].requirement = 1;
        paine_freelancer.dressphere_abilities[9].ability = 0x308B; // Cripple
        paine_freelancer.dressphere_abilities[10].requirement = 1;
        paine_freelancer.dressphere_abilities[10].ability = 0x8014; // HP Stroll
        paine_freelancer.dressphere_abilities[11].requirement = 0x8014;
        paine_freelancer.dressphere_abilities[11].ability = 0x800e; // Butterfingers
        paine_freelancer.dressphere_abilities[12].requirement = 1;
        paine_freelancer.dressphere_abilities[12].ability = 0x8008; // Physicist
        paine_freelancer.dressphere_abilities[13].requirement = 1;
        paine_freelancer.dressphere_abilities[13].ability = 0x8004; // Magic Counter
        paine_freelancer.dressphere_abilities[14].requirement = 0x800e;
        paine_freelancer.dressphere_abilities[14].ability = 0x806B; // Auto-Protect
        paine_freelancer.dressphere_abilities[15].requirement = 0x800e;
        paine_freelancer.dressphere_abilities[15].ability = 0x8069; // Super Ribbom

        // Job Creature Data
    }

    public unsafe void InitPaineLeblancGoon() {
        ref Job paine_leblancgoon = ref *paine_leblancgoon_ptr;

        // data
        //paine_leblancgoon.name_offset = 2345;
        paine_leblancgoon.name_offset.text_offset = 2492;
        paine_leblancgoon.help_offset.text_offset = 2357;
        paine_leblancgoon.user = 1;
        paine_leblancgoon.dressphere_menu_ordering = 17;
        paine_leblancgoon.icon = 84;
        paine_leblancgoon.berserk_action = 0x302d;

        // stat growth
        paine_leblancgoon.growth_hp.linear_mult = 38;
        paine_leblancgoon.growth_hp.quadratic_div = 133;
        paine_leblancgoon.growth_hp.base_amount = 78;

        paine_leblancgoon.growth_mp.linear_mult = 26;
        paine_leblancgoon.growth_mp.quadratic_div = 180;
        paine_leblancgoon.growth_mp.base_amount = 18;

        paine_leblancgoon.growth_strength.linear_mult = 20;
        paine_leblancgoon.growth_strength.linear_div = 10;
        paine_leblancgoon.growth_strength.base_amount = 15;
        paine_leblancgoon.growth_strength.quadratic_div_a = 12;
        paine_leblancgoon.growth_strength.quadratic_div_b = 1;

        paine_leblancgoon.growth_defense.linear_mult = 3;
        paine_leblancgoon.growth_defense.linear_div = 200;
        paine_leblancgoon.growth_defense.base_amount = 32;
        paine_leblancgoon.growth_defense.quadratic_div_a = 200;
        paine_leblancgoon.growth_defense.quadratic_div_b = 2;

        paine_leblancgoon.growth_magic.linear_mult = 6;
        paine_leblancgoon.growth_magic.linear_div = 4;
        paine_leblancgoon.growth_magic.base_amount = 18;
        paine_leblancgoon.growth_magic.quadratic_div_a = 200;
        paine_leblancgoon.growth_magic.quadratic_div_b = 2;

        paine_leblancgoon.growth_magic_defense.linear_mult = 3;
        paine_leblancgoon.growth_magic_defense.linear_div = 16;
        paine_leblancgoon.growth_magic_defense.base_amount = 38;
        paine_leblancgoon.growth_magic_defense.quadratic_div_a = 200;
        paine_leblancgoon.growth_magic_defense.quadratic_div_b = 2;

        paine_leblancgoon.growth_agility.linear_mult = 0;
        paine_leblancgoon.growth_agility.linear_div = 17;
        paine_leblancgoon.growth_agility.base_amount = 74;
        paine_leblancgoon.growth_agility.quadratic_div_a = 200;
        paine_leblancgoon.growth_agility.quadratic_div_b = 4;

        paine_leblancgoon.growth_evasion.linear_mult = 0;
        paine_leblancgoon.growth_evasion.linear_div = 20;
        paine_leblancgoon.growth_evasion.base_amount = 10;
        paine_leblancgoon.growth_evasion.quadratic_div_a = 200;
        paine_leblancgoon.growth_evasion.quadratic_div_b = 4;

        paine_leblancgoon.growth_accuracy.linear_mult = 0;
        paine_leblancgoon.growth_accuracy.linear_div = 17;
        paine_leblancgoon.growth_accuracy.base_amount = 120;
        paine_leblancgoon.growth_accuracy.quadratic_div_a = 200;
        paine_leblancgoon.growth_accuracy.quadratic_div_b = 4;

        paine_leblancgoon.growth_luck.linear_mult = 0;
        paine_leblancgoon.growth_luck.linear_div = 22;
        paine_leblancgoon.growth_luck.base_amount = 13;
        paine_leblancgoon.growth_luck.quadratic_div_a = 200;
        paine_leblancgoon.growth_luck.quadratic_div_b = 4;

        //weapon and armor
        paine_leblancgoon.paine_weapon_data[0].weapon_model = 0x1140;
        paine_leblancgoon.paine_weapon_data[0].weapon_position = 5;
        paine_leblancgoon.paine_weapon_data[1].weapon_model = 0;
        paine_leblancgoon.paine_weapon_data[1].weapon_position = 0;
        paine_leblancgoon.paine_weapon_data[2].weapon_model = 0;
        paine_leblancgoon.paine_weapon_data[2].weapon_position = 0;
        paine_leblancgoon.paine_weapon_data[3].weapon_model = 0;
        paine_leblancgoon.paine_weapon_data[3].weapon_position = 0;

        // abilities
        paine_leblancgoon.dressphere_abilities[0].requirement = 0;
        paine_leblancgoon.dressphere_abilities[0].ability = 0x302D; // Attack
        paine_leblancgoon.dressphere_abilities[1].requirement = 0;
        paine_leblancgoon.dressphere_abilities[1].ability = 0;
        paine_leblancgoon.dressphere_abilities[2].requirement = 0;
        paine_leblancgoon.dressphere_abilities[2].ability = 0;
        paine_leblancgoon.dressphere_abilities[3].requirement = 0;
        paine_leblancgoon.dressphere_abilities[3].ability = 0;
        paine_leblancgoon.dressphere_abilities[4].requirement = 0;
        paine_leblancgoon.dressphere_abilities[4].ability = 0;
        paine_leblancgoon.dressphere_abilities[5].requirement = 0;
        paine_leblancgoon.dressphere_abilities[5].ability = 0;
        paine_leblancgoon.dressphere_abilities[6].requirement = 0;
        paine_leblancgoon.dressphere_abilities[6].ability = 0;
        paine_leblancgoon.dressphere_abilities[7].requirement = 0;
        paine_leblancgoon.dressphere_abilities[7].ability = 0;
        paine_leblancgoon.dressphere_abilities[8].requirement = 0;
        paine_leblancgoon.dressphere_abilities[8].ability = 0;
        paine_leblancgoon.dressphere_abilities[9].requirement = 0;
        paine_leblancgoon.dressphere_abilities[9].ability = 0;
        paine_leblancgoon.dressphere_abilities[10].requirement = 0;
        paine_leblancgoon.dressphere_abilities[10].ability = 0;
        paine_leblancgoon.dressphere_abilities[11].requirement = 0;
        paine_leblancgoon.dressphere_abilities[11].ability = 0;
        paine_leblancgoon.dressphere_abilities[12].requirement = 0;
        paine_leblancgoon.dressphere_abilities[12].ability = 0;
        paine_leblancgoon.dressphere_abilities[13].requirement = 0;
        paine_leblancgoon.dressphere_abilities[13].ability = 0;
        paine_leblancgoon.dressphere_abilities[14].requirement = 0;
        paine_leblancgoon.dressphere_abilities[14].ability = 0;
        paine_leblancgoon.dressphere_abilities[15].requirement = 0;
        paine_leblancgoon.dressphere_abilities[15].ability = 0;
        // Job - Creature Data
    }

}
