namespace Fahrenheit.Mods.X2DSUnlimit;

public partial class X2DSUnlimitModule : FhModule {

    //used for Ability menu rendering - Populated by TOMenuMakeJobAbilityList
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x10)]
    public struct DSAbilityListDataAbility
    {
        [FieldOffset(0x00)] public byte is_visible;
        [FieldOffset(0x01)] public byte b2;
        [FieldOffset(0x02)] public byte is_mastered;
        [FieldOffset(0x03)] public byte is_selected;
        [FieldOffset(0x04)] public int ability_id;
        [FieldOffset(0x08)] public uint ap_current;
        [FieldOffset(0x0C)] public uint ap_needed;
    }

    [InlineArray(16)]
    public struct DSAbilityListDataAbilityArray
    {
        public DSAbilityListDataAbility _element0;
    }

    // Populated by TOMenuMakeJobAbilityList, 0x110 per dressphere
    // Originally at: FFX-2.exe + DBB200 + (DS_ID * 0x110), replaced with NativeAlloc, main.cs: private unsafe DSAbilityListData* ability_list_data_ptr;
    [StructLayout(LayoutKind.Explicit, Pack = 4, Size = 0x110)]
    public struct DSAbilityListData
    {
        [FieldOffset(0x00)] public int is_valid;
        [FieldOffset(0x04)] public int ds_id;
        [FieldOffset(0x08)] public int percentage;
        [FieldOffset(0x0C)] public int i1;
        [FieldOffset(0x10)] public DSAbilityListDataAbilityArray Abilities;
    }

    /// <summary>
    /// Used for Abilities Menu, necessary for Freelancer and Leblanc Goon to show up in job list
    /// </summary>
    /// <returns> Number of dresspheres to list </returns>
    public unsafe ushort h_kyGetJobNum3() {
        byte bVar1;
        int is_owned;
        int special_ds_owned;
        ushort ds_count;

        byte* unique_ds_on_grid_list = FhUtil.ptr_at<byte>(0x9f5fc4);// list of dressphere IDs (byte), unique ones on current grid,
        byte* ds_amount = FhUtil.ptr_at<byte>(0x9f6018); //this is speculative

        ds_count = 0;
        for (int i = 0; i < CustomDsLookupTable.Length; i++) {

            is_owned = h_MsGetSaveDreSphere(CustomDsLookupTable[i]);
            if (0 < is_owned) {
                unique_ds_on_grid_list[ds_count] = (byte)CustomDsLookupTable[i];
                ds_count++;
            }

            ds_amount[i] = (byte)is_owned;
        }

        //ints with special dressphere ids, + chr_id menu character, 8 4
        //iVar3 = MsGetSaveDreSphere(*(undefined4*)(&DAT_00d48a90 + DAT_00df6d80 * 4));
        int* special_ds_id_records = FhUtil.ptr_at<int>(0x948A90);
        byte menu_chr_id = FhUtil.get_at<byte>(0x9f6d80); // in certain Tri/Y/V Menus, is the chr_id of the character who's being looked at.
        int tgt_special_ds_id = special_ds_id_records[menu_chr_id];

        special_ds_owned = h_MsGetSaveDreSphere((uint)tgt_special_ds_id);
        if (0 < special_ds_owned) {
            FhUtil.set_at<ushort>(0x9f6028, 0x101);

            bVar1 = (byte)special_ds_id_records[menu_chr_id];
            unique_ds_on_grid_list[ds_count] = bVar1;
            FhUtil.set_at<byte>(0x9f602a, 1);
            unique_ds_on_grid_list[ds_count + 1] = (byte)(bVar1 + 1);
            unique_ds_on_grid_list[ds_count + 2] = (byte)(bVar1 + 2);
            ds_count = (ushort)(ds_count + 3);
        }


        FhUtil.set_at<byte>(0x9f602c, (byte)ds_count);
        //_logger.Info("Return result: " + number_of_elements.ToString());
        return ds_count;

    }

    /// <summary>
    /// Uused for Abilities menu job list rendering.
    /// </summary>
    /// <param name="param_1"></param>
    /// <param name="job_id"></param>
    /// <returns>Dressphere ability learned percentage</returns>
    public unsafe uint h_TOMenuGetJobLearnedRate(uint param_1, uint job_id) {
        return (uint)ability_list_data_ptr[job_id & 0xff].percentage;
    }

    // Abilities menu, set ability to learn
    public unsafe void h_TOMenuSetSaveLearn(uint chr_id, uint job_id, uint slot) {
        DSAbilityListData* abi_list_table = ability_list_data_ptr;
        uint job_num = job_id & 0xff;

        int abilityId = abi_list_table[job_num].Abilities[(int)slot].ability_id;

        h_MsSetSaveLearn(chr_id, job_id, (ushort)abilityId); // call the underlying save-write function directly with the resolved id
    }


    //adds Freelancer/Leblanc Goon to abilities menu job list
    public unsafe void h_TOMenuMakeJobList(uint chr_id)
    {
        uint job_num_to_check;
        uint job_id;

        //DSAbilityListData* job_table = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
        DSAbilityListData* job_table = ability_list_data_ptr;

        // zero Ability List Data
        for (int i = 0; i < ability_list_count; i++) {
            ref DSAbilityListData job = ref job_table[i];
            job.is_valid = 0;
            job.ds_id = 0xff;
            job.percentage = 0;
            job.i1 = 0;

            Span<DSAbilityListDataAbility> abilities = job.Abilities;
            abilities.Clear();
        }
        FhUtil.set_at<byte>(0x12c0265, 0);
        FhUtil.set_at<byte>(0x12c0266, 0);// abilities menu: dressphere id viewing/last viewed


        // Invoke Ability list data population
        job_num_to_check = 0;
        for (int entry = 0; entry < ability_list_count; entry++)
        {
            job_id = job_num_to_check | 0x5000;
            bool validJob = false;
            switch (job_id)
            {
                case 0x5001:
                case 0x5002:
                case 0x5003:
                case 0x5004:
                case 0x5005:
                case 0x5006:
                case 0x5007:
                case 0x5008:
                case 0x5009:
                case 0x500A:
                case 0x500B:
                case 0x500C:
                case 0x500D:
                case 0x500E:
                case 0x501C:
                case 0x501D:
                case 0x5020: // Freelancer
                case 0x5021: // Leblanc Goon

                    if (h_MsGetSaveDreSphere(job_id) != 0)// if dressphere has been obtained/in inventory
                    {
                        validJob = true;
                        h_TOMenuMakeJobAbilityList((uint)chr_id, job_id);
                    }
                    break;

                case 0x500F: // Floral Fallal
                case 0x5010:
                case 0x5011:

                    if (chr_id == 0 &&
                        h_MsGetSaveDreSphere(0x500F) != 0)
                    {
                        validJob = true;
                        h_TOMenuMakeJobAbilityList(0, job_id);
                    }
                    break;

                case 0x5012: // Machina Maw
                case 0x5013:
                case 0x5014:

                    if (chr_id == 1 &&
                        h_MsGetSaveDreSphere(0x5012) != 0)
                    {
                        validJob = true;
                        h_TOMenuMakeJobAbilityList(1, job_id);
                    }
                    break;

                case 0x5015: // Full Throttle
                case 0x5016:
                case 0x5017:

                    if (chr_id == 2 &&
                        h_MsGetSaveDreSphere(0x5015) != 0)
                    {
                        validJob = true;
                        h_TOMenuMakeJobAbilityList(2, job_id);
                    }
                    break;
            }

            // Write 'Dressphere' related data to Ability menu, Data list
            ref DSAbilityListData job_entry = ref job_table[entry];
            if (validJob) {
                job_entry.is_valid = 1;
                job_entry.ds_id = (int)job_id;

                byte count = FhUtil.get_at<byte>(0x12c0265);
                FhUtil.set_at<byte>(0x12c0265, (byte)(count + 1));
            }
            else {
                job_entry.is_valid = 0;
                job_entry.ds_id = 0xff;
                job_entry.percentage = 0;
                job_entry.i1 = 0;
            }

            job_num_to_check++;
        }

    }

    /// <summary>
    /// Entered 16x ability view function
    /// </summary>
    /// <param name="menu_chr_id"></param>
    /// <param name="menu_job_id"></param>
    public unsafe void h_TOMenuStartJobAbilityWindow(uint menu_chr_id, uint menu_job_id) {
        FhUtil.set_at<uint>(0x12c0270, menu_chr_id);
        FhUtil.set_at<uint>(0x12c0274, menu_job_id | 0x5000);

        //DSAbilityListData* abi_list_data = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
        DSAbilityListData* abi_list_data = ability_list_data_ptr;

        for (int i = 0; i < ability_list_count; i++) {
            if ((menu_job_id | 0x5000) == abi_list_data[i].ds_id) {
                FhUtil.set_at<byte>(0x12c0266, (byte)i);
            }
        }

        FhUtil.set_at<uint>(0x963ed4, 7); // used for menu progression: tells game it's now entered the DS ability list with 16 moves showing, AP, mastery, etc.
    }

    // Writes Abilities menu: 16x dressphere ability list data
    public unsafe void h_TOMenuMakeJobAbilityList(uint chr_id, uint job_id) {

        Job* job_data;
        uint* local_c = null;

        // Special Dressphere support unit handling
        switch (job_id) {
            case 0x5010: chr_id = 3; break;
            case 0x5011: chr_id = 4; break;
            case 0x5013: chr_id = 5; break;
            case 0x5014: chr_id = 6; break;
            case 0x5016: chr_id = 7; break;
            case 0x5017: chr_id = 8; break;
            default: break;
        }


        DSAbilityListData* abi_list_table = ability_list_data_ptr;
        uint job_num = job_id & 0xff;

        byte* local_1c = stackalloc byte[64];
        job_data = h_MsGetRomJob(chr_id, job_id, local_1c);

        // Loop 1 - add ability IDs, set AP
        for (int i = 0; i < 16; i++) {
            ref DSAbilityListDataAbility ability = ref abi_list_table[job_num].Abilities[i]; // NativeAlloc Ability data list
            int ability_id = job_data->dressphere_abilities[i].ability; //job.bin style Job

            ability.is_visible = 0;
            ability.is_mastered = 0;
            ability.is_selected = 0;
            ability.ability_id = ability_id; // read from Job, put in Ability List data

            uint current_ap = FFX2.FhCall.MsGetSaveAp.fnptr!(chr_id, (uint)ability_id);
            uint needed_ap = FFX2.FhCall.MsGetSaveNeedAp.fnptr!((byte)chr_id, (uint)ability_id);

            ability.ap_current = current_ap;
            ability.ap_needed = needed_ap;

            if (needed_ap < current_ap) {
                ability.ap_current = needed_ap; // cap current AP to Max Required AP
            }
        }

        // Loop 2 - ability visibility and current learn selected flag
        ushort* learnable_list = h_MsGetJobAbilityList(chr_id, job_id, local_c, 0);
        for (int i = 0; i < 16; i++) {
            ref DSAbilityListDataAbility ability = ref abi_list_table[job_num].Abilities[i];

            for (int j = 0; j < 16; j++) {
                ushort candidate = *(ushort*)((int)learnable_list + j * 2);
                if (candidate == 0x00FF) continue;

                // If match, Set ability visibility flag
                if (ability.ability_id == candidate) {
                    ability.is_visible = 1;

                    // Mark ability currently being learned for highlight
                    uint current_learn_target = h_MsGetSaveLearn(chr_id, job_id);
                    if (current_learn_target == ability.ability_id) {
                        ability.is_selected = 1;
                    }
                    break;
                }
            }
        }

        // Loop 3 - Ability Mastered flag
        ushort* mastered_list = h_MsGetJobAbilityList(chr_id, job_id, local_c, 1);
        for (int i = 0; i < 16; i++) {
            ref DSAbilityListDataAbility ability = ref abi_list_table[job_num].Abilities[i];

            //if (0 < local_c) {
                for (int j = 0; j < 16; j++) {
                    ushort candidate = *(ushort*)((int)mastered_list + j * 2);
                    if (candidate == 0x00FF) continue;

                    if (ability.ability_id == candidate) {
                        ability.is_visible = 1;
                        ability.is_mastered = 1;
                        ability.is_selected = 0;
                        break;
                    }
                }
            //}
        }

        // Final: sum AP, compute completion percentage
        int total_needed_ap = 0;
        int total_mastered_ap = 0;

        for (int k = 0; k < 16; k++) {
            ref DSAbilityListDataAbility _ability = ref abi_list_table[job_num].Abilities[k];
            total_needed_ap += (int)_ability.ap_needed;
            if (_ability.is_mastered == 1) {
                total_mastered_ap += (int)_ability.ap_current;
            }
        }

        // 0% shortcut
        if (total_mastered_ap == 0 || total_needed_ap == 0) {
            abi_list_table[job_num].percentage = 0;
        }
        else if (job_id == 0x5002) {
            // Gun Mage specific handling
            abi_list_table[job_num].percentage = (total_mastered_ap * 84) / total_needed_ap;

            DSAbilityListDataAbilityArray* blue_bullet_ptr = FhUtil.ptr_at<DSAbilityListDataAbilityArray>(0xdbd400);
            DSAbilityListDataAbilityArray blue_bullet_abi = *blue_bullet_ptr;

            // Each learned Blue Bullet adds 1%
            for (int i = 0; i < 0x10; i++) {
                if (blue_bullet_abi[i].is_visible == 1) { abi_list_table[job_num].percentage++; }
            }
        }
        else {
            // All other Dressphere percentage handling
            abi_list_table[job_num].percentage = (total_mastered_ap * 100) / total_needed_ap;
        }

    }


    // In Abilities Menu, job list - handles command window preview and auto abilities?
    // Also 16 x ability list
    public unsafe ushort* h_MsGetJobAbilityList(uint chr_id, uint job_id, uint* param_3, int param_4)
    {
        ushort ability;
        ushort requirement;

        uint chr_num;
        uint chr_level;

        int job_addr;
        int abilities_addr;

        uint is_monster;
        int num_abilities_to_check;
        // conditions
        int iVar8;
        int iVar9;
        uint uVar10;
        int iVar11;




        ushort* DAT_00df9258 = FhUtil.ptr_at<ushort>(0x9f9258); // is the mastered ability list
        nint DAT_00df9258_addr = (nint)(DAT_00df9258);
        int abilities_checked = 0;

        chr_num = FFX2.FhCall.MsGetChrNum.fnptr!((uint)chr_id);
        chr_level = (uint)FFX2.FhCall.MsCalcChrLevel.fnptr!((byte)chr_num);

        job_addr = (int)h_MsGetRomJob(chr_num, (uint)job_id, null);
        if (job_addr != 0) // if Job address is returned
        {

            // Select:  Number of abilities to check differs between YRP and Creatures
            is_monster = FFX2.FhCall.MsBtlMonsterSaveNumCheck.fnptr!(chr_num); // Check if Player character or Creature
            if (is_monster == 0)
            {
                num_abilities_to_check = 0x10;
                abilities_addr = job_addr + 0x3c;// job.bin ds abilities table
            }
            else
            {
                // check the 2 abilities in Creature Data of job.bin Job
                num_abilities_to_check = 2;
                abilities_addr = job_addr + 0xb0; // Job, creature data, 2 abiilities
            }


            if (abilities_addr != 0) //
            {
                for (int j = 0; j < num_abilities_to_check; j++)
                {
                    requirement = *(ushort*)(abilities_addr + j * 4);
                    ability = *(ushort*)(abilities_addr + 2 + j * 4);

                    if (ability != 0)
                    {
                        // Checks
                        iVar8 = (int)FFX2.FhCall.MsCheckAbility.fnptr!(chr_num, requirement, (int)chr_level); // does the character have the prereq
                        iVar9 = (int)FFX2.FhCall.FUN_006294f0.fnptr!((uint)ability, (int)DAT_00df9258_addr, abilities_checked);// Excel/MsGetRomAbility related, not in Switch ver
                        uVar10 = FFX2.FhCall.MsCheckLearnCommand.fnptr!((byte)chr_num, ability);
                        iVar11 = (int)FFX2.FhCall.MsGetSaveCommand.fnptr!(chr_num, (uint)ability);

                        bool left_condition = is_monster != 0 || param_4 == 0 || requirement == 0 || iVar11 != 0;
                        bool right_condition = (iVar8 != 0 && iVar9 != 0) && (uVar10 != 0 && (abilities_checked < 0x10));

                        // If conditions are met
                        if (left_condition && right_condition)
                        {
                            //*(short*)((int)&DAT_00df9258 + iVar13 * 2) = sVar1;
                            DAT_00df9258[abilities_checked] = ability; // Add ability to DF9258 list
                            abilities_checked++;
                        }
                    }
                }

                // if reached maximum abilities return
                if (abilities_checked > 0xF)
                {
                    goto LAB_00629c2d;
                }
            }
        }

        // null, mark invalid the last abilities?
        for (int i = abilities_checked; i < 16; i++)
        {
            DAT_00df9258[i] = 0x00FF;
        }

    LAB_00629c2d:
        if (param_3 != null)
        {
            *param_3 = 0x10;
        }
        return DAT_00df9258; // Returns mem location of added command/abilities From Accessories?

    }

    /// <summary>
    /// Drives the functionality of the abilities menu. Some switch cases made use of the FFX-2.exe + 0xdbb200
    /// ability list data region. As this is now moved to NativeAlloc, some of the cases withing
    /// this function needed updating.
    /// </summary>
    /// <param name="param_1"></param>
    public unsafe void h_FUN_777270(uint param_1) {

        uint case_id = *(uint*)(param_1 + 0x28); // switch case selection

        // if valid case ID
        if (case_id < 0x14) {
            uint* switch_data_777864 = FhUtil.ptr_at<uint>(0x377864); // pointer to switch data

            // Intercept switch case -> user selects command to learn ( not mastered )
            if ((switch_data_777864[case_id] & 0xFFFF) == 0x762F) {

                byte job_num = FhUtil.get_at<byte>(0x12c0266);
                uint menu_chr_id = FhUtil.get_at<uint>(0x12c0270);
                uint menu_job_id = FhUtil.get_at<uint>(0x12c0274);
                uint slot = (uint)(*(int*)(param_1 + 0x5c) + *(short*)(param_1 + 0x4c) * 2);

                h_TOMenuSetSaveLearn((byte)menu_chr_id, menu_job_id, slot);
                h_TOMenuMakeJobAbilityList(menu_chr_id, menu_job_id);
                FFX2.FhCall.TOMenuSetMacroCommandType.fnptr!(0, 1, 0);

                //DSAbilityListData* abi_list_data = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
                DSAbilityListData* abi_list_data = ability_list_data_ptr;
                int ability_id = abi_list_data[job_num].Abilities[(int)slot].ability_id;

                byte* com_name_string_addr = FFX2.FhCall.TOBtlGetComName.fnptr!((uint)ability_id);

                FFX2.FhCall.TOMenuSetMacroCommandValue.fnptr!(0, 1, com_name_string_addr);
                com_name_string_addr = FFX2.FhCall.TOGetMenuText.fnptr!(0x107a);
                *(byte**)(param_1 + 0x24) = com_name_string_addr;
                *(uint*)(param_1 + 0x28) = 9; // Menu progression state record
                return;
            }

            // Intercept switch case -> user selects command to learn (already learned)
            if ((switch_data_777864[case_id] & 0xFFFF) == 0x7587) {

                int slot = *(int*)(param_1 + 0x5c) + *(short*)(param_1 + 0x4c) * 2;
                byte job_num = FhUtil.get_at<byte>(0x12c0266);
                //byte job_num = (byte)CustomTOMenuStartJobAbilityWindow_DS_Table[ds];

                //DSAbilityListData* abi_list_data = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
                DSAbilityListData* abi_list_data = ability_list_data_ptr;
                ref DSAbilityListDataAbility ability = ref abi_list_data[job_num].Abilities[slot];

                // Blue Bullet selected, handling
                if (ability.ability_id == 0x300a) {
                    FFX2.FhCall.SndSepPlaySimple.fnptr!(0x80000001);
                    *(ushort*)(param_1 + 0x2c) = *(ushort*)(param_1 + 0x4c);
                    *(byte*)(param_1 + 0x48) = (byte)(*(byte*)(param_1 + 0x48) + 1);
                    *(uint*)(param_1 + 0x28) = 0xd;
                    return;
                }

                // Ability not mastered handling
                if (ability.is_mastered == 0) {
                    FFX2.FhCall.SndSepPlaySimple.fnptr!(0x8000000a);
                    *(uint*)(param_1 + 0x80) = 1;
                    *(uint*)(param_1 + 0x28) = 7;
                    return;
                }

                FFX2.FhCall.SndSepPlaySimple.fnptr!(0x80000003);
                *(uint*)(param_1 + 0x80) = 0;
                *(uint*)(param_1 + 0x28) = 8;
                return;
            }

            // Unmodded cases use vanilla behaviour
            FFX2.FhCall.FUN_777270.chain_from(h_FUN_777270).fnptr!(param_1);

        }
    }


    /// <summary>
    /// Returns if an ability has been marked to be visible in the Abilities menu.
    /// This function is hooked to replace:
    /// FFX-2.exe + 0xdbb200 reference with NativeAlloc AbilityListData
    /// FFX-2.exe + DAT_00d63e78 AbilityListData lookup table as it's not required because of the previous point.
    /// </summary>
    /// <param name="param_1"></param>
    /// <param name="ability_slot"></param>
    /// <returns> Boolean: is the ability marked as visible </returns>
    public unsafe int h_FUN_776EC0(uint param_1, uint ability_slot) {
        //DSAbilityListData* abi_list_data = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
        DSAbilityListData* abi_list_data = ability_list_data_ptr;

        //byte job_index = (byte)CustomTOMenuStartJobAbilityWindow_DS_Table[ds & 0xff];
        byte ds = FhUtil.get_at<byte>(0x12c0266);

        DSAbilityListData* job = &abi_list_data[ds];

        return job->Abilities[(int)ability_slot].is_visible;
    }


    /// <summary>
    /// Renders the dressphere ability list in the Abilities menu -> 16 dressphere abilities, icons, names, master icon and AP
    /// </summary>
    public unsafe void h_FUN_778160(int param_1, int param_2, int param_3, int param_4)
    {
        //_logger.Info("Param_1 is: " + param_1.ToString("X"));
        //_logger.Info("Param_2 is: " + param_2.ToString("X"));
        //_logger.Info("Param_3 is: " + param_3.ToString("X"));
        //_logger.Info("Param_4 is: " + param_4.ToString("X"));

        uint puVar1;
        uint uVar2;
        uint uVar3;
        int iVar4;
        int iVar5;
        double fVar7;
        float[] local_28 = new float[4];
        byte[] local_18 = new byte[16];
        local_28[0] = 0.0f;
        local_28[1] = 0.0f;
        local_28[2] = 0.0f;
        local_28[3] = 0.0f;


        int local_30 = param_3;   // 00778199: initial copy
        uVar2 = (uint)(param_4 + *(short*)(param_1 + 0x32) * 2);

        if (uVar2 < 0x10)
        {
#region Unknown1
            uVar3 = uVar2 & 0x8000000f;
            if ((int)uVar3 < 0)
            {
                uVar3 = (uVar3 - 1 | 0xfffffff0) + 1;
            }

            byte* DAT_016c0278 = FhUtil.ptr_at<byte>(0x12c0278);
            puVar1 = (uint)((int)(DAT_016c0278) + uVar3 * 0x10);

            iVar4 = FFX2.FhCall.TOGetRtcValue.fnptr!(puVar1);
            iVar5 = FFX2.FhCall.TOGetRtcRatio.fnptr!(puVar1);
            if (iVar5 / 2 + 0x800 < 0x800)
            {
                iVar5 = FFX2.FhCall.TOGetRtcRatio.fnptr!(puVar1);
                local_28[0] = (float)((float)(iVar5 / 2) * 3.1415927);
            }
            else
            {
                iVar5 = FFX2.FhCall.TOGetRtcRatio.fnptr!(puVar1);
                local_28[0] = (float)((float)(0x800 - iVar5 / 2) * -3.1415927);
            }

            local_28[0] = (float)(local_28[0] * 0.00048828125);
            if (*(byte*)(param_1 + 0x42) == 0)
            {
                param_3 = iVar4;
                local_30 = iVar4;      // Kept in sync
            }
            #endregion Unknown1

#region ListItemBG
            // Draw background rectangles under abilities
            iVar4 = FFX2.FhCall.TOGetRtcRatio.fnptr!(puVar1);
            int barValue = ((int)uVar2 / 2) * 0x199;
            if (iVar4 != 0)
            {
                fixed (float* pAlpha = &local_28[0]) {
                    // Render backplates under Ability Icon, name, AP
                    FFX2.FhCall.TOMenuDrawRotPlate.fnptr!(param_2, param_3, (int)pAlpha, 6, 0, barValue, 0);
                }
            }
#endregion ListItemBG


#region Selected Ability to Learn

            byte ds = FhUtil.get_at<byte>(0x12c0266); // menu: current dressphere ID
            //byte job_index = (byte)(CustomTOMenuStartJobAbilityWindow_DS_Table[ds] & 0xFF); // updated to not need to refence this table
            int job_offset = (int)ds * 0x110;
            int ability_index = (int)uVar2;

            //DSAbilityListData* abi_list_data = FhUtil.ptr_at<DSAbilityListData>(0xdbb200);
            DSAbilityListData* abi_list_data = ability_list_data_ptr;
            DSAbilityListData* job = &abi_list_data[ds];
            DSAbilityListDataAbility* ability = &job->Abilities[ability_index];

            // Selected ability to learn highlight handler:
            if ((ability->is_visible == 1) && (-1.5707964 < local_28[0]) && (local_28[0] < 1.5707964))
            {
                iVar4 = FFX2.FhCall.TOGetRtcRatio.fnptr!(puVar1);
                if ((ability->is_selected == 1) && (iVar4 == 0x1000))
                {
                    FFX2.FhCall.TOMenuOpenPkt.fnptr!();

                    double DAT_00c32010_value = FhUtil.get_at<double>(0x832010);
                    double valA = FFX2.FhCall.offsetAdjust_Y.fnptr!(0x3b) - DAT_00c32010_value;
                    int fixedA = (int)valA;

                    // W = offsetAdjust_X(0x2d8)
                    double valB = FFX2.FhCall.offsetAdjust_X.fnptr!(0x2d8);
                    int fixedB = (int)valB;

                    // Y = offsetAdjust_Y(7) + local_30 (savedCount / param_3)
                    double valC = FFX2.FhCall.offsetAdjust_Y.fnptr!(7) + local_30;
                    int fixedC = (int)valC;

                    // X = offsetAdjust_X(9) + param_2
                    double valD = FFX2.FhCall.offsetAdjust_X.fnptr!(9) + param_2;
                    int fixedD = (int)valD;

                    // Render Ability selection highlight, last parameter is colour
                    FFX2.FhCall.TOMkpScrollWaveXYWH.fnptr!(fixedD, fixedC, fixedB, fixedA, 0x3); //TOMkpScrollWaveXYWH?

                    FFX2.FhCall.TOKickPacket.fnptr!();
                }
#endregion Selected Ability to Learn
                #region Ability Name and Icon Rendering

                FFX2.FhCall.TOMenuOpenPkt.fnptr!();
                FFX2.FhCall.TOMenuChangeFrameAccPlate.fnptr!(6);
                FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(0x3f55f15f, 0x3f313b14);
                FFX2.FhCall.TOGetFFXLang.fnptr!();

                double DAT_00cad868 = FhUtil.get_at<double>(0x8ad868);
                double test_double = FFX2.FhCall.offsetAdjust_Y.fnptr!(0xf) + local_30 - DAT_00cad868;
                int test_double_as_int = (int)(test_double);

                // Render Ability icon and Name
                //_TOMkpComIconNameClut(*(uint*)(DAT_011bb214_addr + ability_index * 0x10 + job_offset), param_2 + 6, test_double_as_int, 0);
                FFX2.FhCall.TOMkpComIconNameClut.fnptr!((uint)ability_list_data_ptr[ds].Abilities[ability_index].ability_id, param_2 + 6, test_double_as_int, 0);
                FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();

#endregion Ability Name and Icon Rendering
#region AP / Needed AP and Master Icons

                // Handle AP / Needed AP vs Master icons

                //byte* DAT_011bb212 = FhUtil.ptr_at<byte>(0xdbb212);
                //if ((DAT_011bb212)[ability_index * 0x10 + job_offset] == 1)
                if (ability->is_mastered == 1)
                {
                    
                    float x = FhUtil.get_at<float>(0x84b340);
                    float y = FhUtil.get_at<float>(0x83a620);

                    //FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(0x3f092492, 0x3f333333);
                    FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(x, y);


                    FhUtil.set_at<byte>(0x12f0ac0, 1);

                    int timer_val = FFX2.FhCall.TkMenuGetTimer.fnptr!();

                    double DAT_00cad890 = FhUtil.get_at<double>(0x8ad890);
                    double val = FFX2.FhCall.offsetAdjust_Y.fnptr!(0x14) + local_30 - DAT_00cad890;
                    int fixedVal = (int)val;

                    // Render Ability Mastered icons
                    FFX2.FhCall.TOMkpShape2dMenu.fnptr!(param_2 + 0xa2, fixedVal, 8, timer_val);
                    

                    //h_TOMkpShape2dMenu(100, 100, 8, timer_val);
                    FhUtil.set_at<byte>(0x12f0ac0, 0);
                }
                else
                {
                    // AP / Needed AP Handling
                    //_sprintf((byte*)local_18, "%3d/%3d", *(uint*)(DAT_011bb218_addr + ability_index * 0x10 + job_offset), *(uint*)(DAT_011bb21c_addr + ability_index * 0x10 + job_offset));

                    uint current_ap = ability->ap_current;
                    uint required_ap = ability->ap_needed;

                    // prepare string
                    string s = $"{current_ap,3}/{required_ap,3}";
                    byte[] bytes = Encoding.ASCII.GetBytes(s);
                    int len = Math.Min(bytes.Length, local_18.Length - 1);
                    Array.Copy(bytes, local_18, len); // copy into buffer
                    local_18[len] = 0; // null terminate

                    iVar4 = (int)FFX2.FhCall.TOGetFFXLang.fnptr!();
                    if (iVar4 == 0) {
                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(0x3eec4ec5, 0x3f19999a);

                        double DAT_00cad890 = FhUtil.get_at<double>(0x8ad890);
                        double val = FFX2.FhCall.offsetAdjust_Y.fnptr!(0x16) + local_30 - DAT_00cad890;
                        int trunc_val = (int)val;

                        // Render AP / Needed AP
                        fixed (byte* pText = local_18) {
                            FFX2.FhCall.FUN_007AE430.fnptr!(pText, param_2 + 0xc3, trunc_val, 0x80, 0x80, 0x80, 0x80); // TOMkpEasyMesFontLRight?
                        }
                    }
                    else
                    {
                        // Non-Western text handling?

                        if (local_18[0] != 0)
                        {
                            int i = 0;
                            do {
                                if (local_18[i] == 0x20) {
                                    local_18[i] = 0x3A; // ':'
                                }
                                else if (local_18[i] == 0x2F) {
                                    local_18[i] = 0x49; // 'I'
                                }
                                i++;
                            } while (local_18[i] != 0);
                        }

                        

                        FFX2.FhCall.FFX2_Set_UI_Scale.fnptr!(0x3f55f15f, 0x3f313b14);
                        

                        fVar7 = (double)FFX2.FhCall.offsetAdjust_Y.fnptr!(10);
                        fixed (byte* pText = local_18) {
                            // TOAdpMesFontLXYZClutTypeRGBAChangeFontType caller (PC) / TOMkpAscStrRightRGBA (Switch ver.)
                            FFX2.FhCall.FUN_007AEDA0.fnptr!(pText, (param_2 + 0xc3), (int)(fVar7 + param_3));
                        }
                    }
                }
                #endregion AP / Needed AP and Master Icons


                FFX2.FhCall.FFX2_Reset_UI_Scale.fnptr!();
                FFX2.FhCall.TOMkpResetFrameAcc.fnptr!();
                fixed (float* pAlpha = &local_28[0]) {
                    FFX2.FhCall.TOMkpExPlateParam.fnptr!(param_2, param_3, (int)pAlpha, 6, 0);
                }
                FFX2.FhCall.TOKickPacket.fnptr!();
                return;
            }
        }
        return;

    }

    /// <summary>
    /// When viewing a Dressphere's ability list, pressing a button moves you to the next
    /// dressphere's list. This function has been changed so it works with Freelancer, Leblanc Goon
    /// and theoretically more dresspheres.
    /// </summary>
    /// <returns> Dressphere ID - of Dressphere to switch to?</returns>
    public unsafe int h_TOMenuNextJobList() {
        int attempts = 0;
        byte current = 0;

        while (true) {

            //get current dressphere id, increment and set
            current = FhUtil.get_at<byte>(0x12c0266);
            current = (byte)(current + 1);
            FhUtil.set_at<byte>(0x12c0266, current);

            uint slot = (uint)current % ability_list_count;

            // if valid Dressphere/Ability data , break out of loop
            if (ability_list_data_ptr[slot].is_valid == 1)
                break;

            attempts++;
            // fallback
            if (attempts > ability_list_count) {
                uint fallback_slot = (uint)current % ability_list_count;
                FhUtil.set_at<byte>(0x12c0266, (byte)fallback_slot);
                return (int)ability_list_data_ptr[fallback_slot].ds_id;
            }
        }

        // if valid ability data, set and return
        uint final_slot = (uint)current % ability_list_count;
        FhUtil.set_at<byte>(0x12c0266, (byte)final_slot);
        return (int)ability_list_data_ptr[final_slot].ds_id;
    }


    /// <summary>
    /// When viewing a Dressphere's ability list, pressing a button moves you to the previous
    /// dressphere's list. This function has been changed so it works with Freelancer, Leblanc Goon
    /// and theoretically more dresspheres.
    /// </summary>
    /// <returns> Dressphere ID - of Dressphere to switch to?</returns>
    public unsafe int h_TOMenuPrevJobList() {
        int attempts = 0;
        byte current = 0;

        while (true) {

            //get current dressphere id, deccrement and set
            current = FhUtil.get_at<byte>(0x12c0266);
            current = (byte)(current - 1);
            FhUtil.set_at<byte>(0x12c0266, current);

            uint slot = (uint)current % ability_list_count;

            // if valid Dressphere/Ability data , break out of loop
            if (ability_list_data_ptr[slot].is_valid == 1)
                break;

            attempts++;
            // fallback
            if (attempts > ability_list_count) {
                uint fallbackSlot = (uint)current % ability_list_count;
                FhUtil.set_at<byte>(0x12c0266, (byte)fallbackSlot);
                return (int)ability_list_data_ptr[fallbackSlot].ds_id;
            }
        }

        // if valid ability data, set and return
        uint finalSlot = (uint)current % ability_list_count;
        FhUtil.set_at<byte>(0x12c0266, (byte)finalSlot);
        return (int)ability_list_data_ptr[finalSlot].ds_id;
    }


    public unsafe byte* h_TOGetRomHelp(int param_1) {
        return FFX2.FhCall.TOGetRomHelp.chain_from(h_TOGetRomHelp).fnptr!(param_1);
    }


    public unsafe void h_TkMenuSetHelpMessage(byte* param_1) {
        FFX2.FhCall.TkMenuSetHelpMessage.chain_from(h_TkMenuSetHelpMessage).fnptr!(param_1);
    }

    /// <summary>
    /// Something to do with ability Help message display.
    /// This function has been altered to use the NativeAlloc DSAbilityList Data so it works
    /// correctly.
    /// </summary>
    /// <param name="param_1"></param>
    public unsafe void h_FUN_777C60(uint param_1) {
        sbyte rawIndex = *(sbyte*)(param_1 + 0x48);
        uint uVar2 = (uint)Math.Max((int)rawIndex, 0);

        byte limit = *(byte*)(param_1 + 0x45);
        if (limit <= uVar2) {
            uVar2 = (uint)(limit - 1);
        }

        byte* helpResult = null;

        if (*(int*)(param_1 + 0x98) != 0) {
            byte ds_num = FhUtil.get_at<byte>(0x12c0266);
            DSAbilityListData* abi_list_data = ability_list_data_ptr;


            int rowOffset = *(int*)(param_1 + 0x5c + uVar2 * 4);
            short cursorOffset = *(short*)(param_1 + 0x4c);
            int slot = rowOffset + cursorOffset * 2;

            ref DSAbilityListDataAbility ability = ref abi_list_data[ds_num].Abilities[slot];

            // if ability is visible, get ability help message
            if (ability.is_visible == 1) {
                helpResult = h_TOGetRomHelp(ability.ability_id);
            }

        }

        if (*(sbyte*)(param_1 + 0x48) < 0) {
            return;
        }

        /*
        if (helpResult != null)
        {
            h_TkMenuSetHelpMessage(helpResult);
        }*/

        h_TkMenuSetHelpMessage(helpResult);
    }

}


