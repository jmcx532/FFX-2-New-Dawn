
namespace Fahrenheit.Mods.X2DSUnlimit;

[FhLoad(FhGameId.FFX2)]
public partial class X2DSUnlimitModule : FhModule {

    // extra Job definitions
    private unsafe Job* yuna_freelancer_ptr;
    private unsafe Job* yuna_leblancgoon_ptr;


    private unsafe Job* rikku_freelancer_ptr;
    private unsafe Job* rikku_leblancgoon_ptr;

    private unsafe Job* paine_freelancer_ptr;
    private unsafe Job* paine_leblancgoon_ptr;

    // Move ability list data into Native alloc - adding new Dresspheres can overwrite data (Blue Bullet)
    private unsafe DSAbilityListData* ability_list_data_ptr;
    private const int ability_list_count = 255;

    #region LocalState
    // Local state / save state
    public static sbyte  freelancer_quantity = 0;
    public static sbyte  leblanc_goon_quantity = 0;
    public static ushort y_freelancer_ability_learning = 0;
    public static ushort y_leblancgoon_ability_learning = 0;
    public static ushort r_freelancer_ability_learning = 0;
    public static ushort r_leblancgoon_ability_learning = 0;
    public static ushort p_freelancer_ability_learning = 0;
    public static ushort p_leblancgoon_ability_learning = 0;

    private class X2DSUnlimitState
    {
        public sbyte   freelancer_quantity          { get; set; }
        public sbyte   leblanc_goon_quantity        { get; set; }

        public ushort y_freelancer_ability_learning  { get; set; }
        public ushort y_leblancgoon_ability_learning { get; set; }
        public ushort r_freelancer_ability_learning { get; set; }
        public ushort r_leblancgoon_ability_learning { get; set; }
        public ushort p_freelancer_ability_learning { get; set; }
        public ushort p_leblancgoon_ability_learning { get; set; }

        public X2DSUnlimitState()
        {
            this.freelancer_quantity = X2DSUnlimitModule.freelancer_quantity;
            this.leblanc_goon_quantity = X2DSUnlimitModule.leblanc_goon_quantity;

            this.y_freelancer_ability_learning = X2DSUnlimitModule.y_freelancer_ability_learning;
            this.r_freelancer_ability_learning = X2DSUnlimitModule.r_freelancer_ability_learning;
            this.p_freelancer_ability_learning = X2DSUnlimitModule.p_freelancer_ability_learning;

            this.y_leblancgoon_ability_learning = X2DSUnlimitModule.y_leblancgoon_ability_learning;
            this.r_leblancgoon_ability_learning = X2DSUnlimitModule.r_leblancgoon_ability_learning;
            this.p_leblancgoon_ability_learning = X2DSUnlimitModule.p_leblancgoon_ability_learning;
        }
    }
    #endregion LocalState

    /// <summary>
    /// Table replacements
    /// Freelancer/Leblanc Goon ID's appended to mod copt of DAT_00D63e78 table (ffx-2.exe + 0x963e78)
    /// TOMsJobAbilityWindow+ and other functions (many)
    /// </summary>
    ///
    /* Superseded, reworked, using native allocation, simplified, skipping table lookup step
    private static readonly ushort[] CustomTOMenuStartJobAbilityWindow_DS_Table =
{
    0x5000, 0x5001, 0x5002, 0x5003, 0x5004,
    0x5005, 0x5006, 0x5007, 0x5008, 0x5009,
    0x500A, 0x500B, 0x500C, 0x500D, 0x500E,
    0x5018, 0x5019, 0x501a, 0x501b, 0x501d,
    0x501e, 0x501f, 0x501c, 0x500f, 0x5010,
    0x5011, 0x5012, 0x5013, 0x5014, 0x5015,
    0x5016, 0x5017, 0x5020, 0x5021
};*/

    //replaces lookup table at: ffx-2.exe + cc36cc, used by the kyGetJobNum series of functions and kyGetUsedPoint ONLY?.
    private static readonly ushort[] CustomDsLookupTable =
{
    0x0001, 0x0002, 0x0003, 0x0004, 0x0005,
    0x0006, 0x0007, 0x0008, 0x0009, 0x000A,
    0x000B, 0x000C, 0x000D, 0x000E, 0x001c,
    0x001d, 0x001f, 0x0020, 0x0021, 0x0022
};


    public unsafe X2DSUnlimitModule() {
        // malloc for C# defined jobs and initialisation
        yuna_freelancer_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        yuna_leblancgoon_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        rikku_freelancer_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        rikku_leblancgoon_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        paine_freelancer_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        paine_leblancgoon_ptr = (Job*)NativeMemory.AllocZeroed((nuint)sizeof(Job));
        InitNewJobs();

        // malloc region for Ability List data - 16x abilites window
        ability_list_data_ptr = (DSAbilityListData*)NativeMemory.AllocZeroed((nuint)(sizeof(DSAbilityListData) * ability_list_count));
    }

    public unsafe Chr* h_MsGetChr(uint chr_id) {
        return FFX2.FhCall.MsGetChr.chain_from(h_MsGetChr).fnptr!(chr_id);
    }

    public uint h_MsGetSaveJob(uint chr_id) {
        return FFX2.FhCall.MsGetSaveJob.chain_from(h_MsGetSaveJob).fnptr!(chr_id);
    }
    public uint h_MsBtlPlayerSaveNumCheck(uint chr_id)
    {
        return FFX2.FhCall.MsBtlPlayerSaveNumCheck.chain_from(h_MsBtlPlayerSaveNumCheck).fnptr!(chr_id);
    }

    // table this references has entries for 0x5020 and 0x5021 for FL/LG - would need to expand for more dresspheres
    public uint h_MsGetJobNumBasic(uint p1)
    {
        return FFX2.FhCall.MsGetJobNumBasic.chain_from(h_MsGetJobNumBasic).fnptr!(p1);
    }

    public uint h_MsGetSaveAp(uint chr_id, uint ability_id)
    {
        return FFX2.FhCall.MsGetSaveAp.chain_from(h_MsGetSaveAp).fnptr!(chr_id, ability_id);
    }

    public uint h_MsGetSaveNeedAp(uint chr_id, uint ability_id)
    {
        return FFX2.FhCall.MsGetSaveNeedAp.chain_from(h_MsGetSaveNeedAp).fnptr!(chr_id, ability_id);
    }

    public uint h_MsGetSaveCommand(uint p1, uint p2) {
        return FFX2.FhCall.MsGetSaveCommand.chain_from(h_MsGetSaveCommand).fnptr!(p1, p2);
    }

    public uint h_MsCheckLearnCommand(uint chr_id, int ability_id) {
        return FFX2.FhCall.MsCheckLearnCommand.chain_from(h_MsCheckLearnCommand).fnptr!(chr_id, ability_id);
    }

    public uint h_FUN_6294f0(uint p1, int p2, int p3) {
        return FFX2.FhCall.FUN_006294f0.chain_from(h_FUN_6294f0).fnptr!(p1, p2, p3);
    }

    public uint h_MsCheckAbility(uint p1, int p2, int p3) {
        return FFX2.FhCall.MsCheckAbility.chain_from(h_MsCheckAbility).fnptr!(p1, p2, p3);
    }

    public uint h_MsBtlMonsterSaveNumCheck(uint param_1) {
        return FFX2.FhCall.MsBtlMonsterSaveNumCheck.chain_from(h_MsBtlMonsterSaveNumCheck).fnptr!(param_1);
    }

    public unsafe  int h_MsGetComData(uint id, byte* out_data_end) {
        return _MsGetComData.chain_from(h_MsGetComData).fnptr!(id, out_data_end);
    }

    public uint h_MsCalcChrLevel(uint chr_id) {
        return FFX2.FhCall.MsCalcChrLevel.chain_from(h_MsCalcChrLevel).fnptr!(chr_id);
    }

    public uint h_MsGetChrNum(uint param_1) {
        return FFX2.FhCall.MsGetChrNum.chain_from(h_MsGetChrNum).fnptr!(param_1);
    }

    // handle FL/LG getting ability to be learned
    public unsafe uint h_MsGetSaveLearn(uint chr_id, uint job_id)
    {

        uint chr_num;
        int is_plyChr;

        chr_num = h_MsGetChrNum(chr_id);
        is_plyChr = (int)h_MsBtlPlayerSaveNumCheck((byte)chr_num);
        if (is_plyChr != 0)
        {
            uint job_num = h_MsGetJobNumBasic(job_id);
            if (job_num < 0x1e) // Vanilla
            {
                ushort* DAT_00e05de0 = FhUtil.ptr_at<ushort>(0xa05de0);

                return *(ushort*)((int)(DAT_00e05de0) + (job_num + chr_num * 0x1e) * 2);
            }
            else // FL/LG
            {
                if (job_num == 0x20)
                {
                    switch (chr_id) {
                        case 0:
                            return y_freelancer_ability_learning;
                        case 1:
                            return r_freelancer_ability_learning;
                        case 2:
                            return p_freelancer_ability_learning;
                    }

                }

                if (job_num == 0x21)
                {
                    switch (chr_id) {
                        case 0:
                            return y_leblancgoon_ability_learning;
                        case 1:
                            return r_leblancgoon_ability_learning;
                        case 2:
                            return p_leblancgoon_ability_learning;
                    }
                }
            }
        }
        return 0;
    }
       
    // handle FL/LG setting ability to be learned
    public unsafe int h_MsSetSaveLearn(uint chr_id, uint job_id, ushort ability_id)
    {
        uint chr_num;
        int is_plyChr;

        chr_num = h_MsGetChrNum(chr_id);
        is_plyChr = (int)h_MsBtlPlayerSaveNumCheck((byte)chr_num);
        if (is_plyChr != 0)
        {
            uint job_num = h_MsGetJobNumBasic(job_id);
            if (job_num< 0x1e) // vanilla
            {
                ushort* DAT_00e05de0 = FhUtil.ptr_at<ushort>(0xa05de0);
                *(ushort*)((int)(DAT_00e05de0) + (job_num + chr_num * 0x1e) * 2) = ability_id;
                return -1;
            }
            else // FL/LG
            {
                if (job_num == 0x20)
                {
                    switch (chr_id) {
                        case 0:
                            y_freelancer_ability_learning = ability_id;
                            return -1;
                        case 1:
                            r_freelancer_ability_learning = ability_id;
                            return -1;
                        case 2:
                            p_freelancer_ability_learning = ability_id;
                            return -1;
                    }
                }

                if (job_num == 0x21)
                {
                    switch (chr_id) {
                        case 0:
                            y_leblancgoon_ability_learning = ability_id;
                            return -1;
                        case 1:
                            r_leblancgoon_ability_learning = ability_id;
                            return -1;
                        case 2:
                            p_leblancgoon_ability_learning = ability_id;
                            return -1;
                    }
                }
            }
        }
        return 0;
    }

    public int h_MsCheckRange(int number, int lower_bound, int upper_bound)
    {
        return FhCall.MsCheckRange.chain_from(h_MsCheckRange).fnptr!(number, lower_bound, upper_bound);
    }


    /// <summary>
    /// Adds functionality with extra Job data for Rikku/Paine to allow for different stats/abilities
    /// TOGetSaveJobName also uses this to get the Jobs string table pointer
    /// </summary>
    /// <param name="chr_id"></param>
    /// <param name="job_id"></param> - 0x50xx
    /// <param name="out_data_end"></param>
    /// <returns></returns>
    public unsafe Job* h_MsGetRomJob(uint chr_id, uint job_id, byte* out_data_end)
    {
        if(job_id == 0x5020) {
            if (chr_id == 0)
            {
                return yuna_freelancer_ptr;
            }
            if (chr_id == 1) {
                return rikku_freelancer_ptr;
            }
            if (chr_id == 2) {
                return paine_freelancer_ptr;
            }
        }

        if (job_id == 0x5021) {
            if (chr_id == 0)
            {
                return yuna_leblancgoon_ptr;
            }
            if (chr_id == 1) {
                return rikku_leblancgoon_ptr;
            }
            if (chr_id == 2) {
                return paine_leblancgoon_ptr;
            }
        }

        //if not Freelance/Leblanc Goon
        return FFX2.FhCall.MsGetRomJob.chain_from(h_MsGetRomJob).fnptr!(chr_id, job_id, out_data_end);
    }

    // Used in Garment Grid Menu, necessary for Freelancer/Leblanc Goon to show up in Dressphere List
    public unsafe ushort h_kyGetJobNum()
    {
        int isOwned;
        ushort ds_count;
        byte* unique_ds_on_grid_list = FhUtil.ptr_at<byte>(0x9f5fc4);

        ds_count = 0;
        for (int i = 0; i < CustomDsLookupTable.Length; i++)
        {
            isOwned = h_MsGetSaveDreSphere(CustomDsLookupTable[i]);
            if (0 < isOwned)
            {
                unique_ds_on_grid_list[ds_count] = (byte)CustomDsLookupTable[i];
                ds_count++;
            }
        }

        FhUtil.set_at<uint>(0x9f602c, ds_count);
        //_logger.Info("Return result: " + number_of_elements.ToString());
        return ds_count;
    }



    //returns the owned quantity of a given dressphere
    public unsafe int h_MsGetSaveDreSphere(uint ds_id)
    {
        if ((ds_id & 0xfff) > 0x1e) //Freelancer, Leblanc Goon handling
        {
            switch(ds_id & 0xfff)
            {
                case 0x20:
                    return freelancer_quantity;
                case 0x21:
                    return leblanc_goon_quantity;
                default:
                    return 0;
            }
        }

        if ((ds_id & 0xfff) < 0x1e) // Vanilla dresspheres
        {
            byte* DAT_00E00D1C = FhUtil.ptr_at<byte>(0xa00d1c);
            return *(sbyte*)(DAT_00E00D1C + (ds_id & 0xfff));
        }

        return 0;
    }

    // makes obtaining LG/Freelancer implement dressphere quantity.
    public unsafe int h_MsAddSaveDreSphere(uint ds_id, int param_2)
    {
        int quantity;

        byte* DAT_00E00D1C = FhUtil.ptr_at<byte>(0xa00d1c); // dressphere quantities memory region
        ds_id = ds_id & 0xfff;

        
        if (ds_id > 0x1e) // Freelancer, Leblanc Goon handling
        {
            switch (ds_id)
            {
                case 0x20:
                    freelancer_quantity = (sbyte)Math.Min(freelancer_quantity + 1, 99);
                    return freelancer_quantity;
                case 0x21:
                    leblanc_goon_quantity = (sbyte)Math.Min(leblanc_goon_quantity + 1, 99);
                    return leblanc_goon_quantity;
            }
        }

        if (ds_id < 0x1e) // Vanilla behaviour
        {
            quantity = h_MsCheckRange(*(byte*)(DAT_00E00D1C + ds_id) + param_2, 0, 99);
            *(byte*)(DAT_00E00D1C + ds_id) = (byte)quantity;
            return quantity;
        }

        return 0;
    }


    public unsafe override bool init(FhModContext mod_context, FileStream global_state_file) {

        return FFX2.FhCall.FUN_006083B0.hook(this, h_FUN_6083B0)
            && FFX2.FhCall.MsGetRomJob.hook(this, h_MsGetRomJob)
            && FFX2.FhCall.MsAddSaveDreSphere.hook(this, h_MsAddSaveDreSphere)
            && FhCall.MsCheckRange.hook(this, h_MsCheckRange)
            && FFX2.FhCall.MsGetSaveDreSphere.hook(this, h_MsGetSaveDreSphere)
            && FFX2.FhCall.kyGetCursorPoint.hook(this, h_kyGetCursorPoint)
            && FFX2.FhCall.kyIsUsedPoint.hook(this, h_kyIsUsedPoint)
            && FFX2.FhCall.MsGetSaveConfigChangeEffect.hook(this, h_MsGetSaveConfigChangeEffect)
            && FFX2.FhCall.MsGetRamConfigChangeEffect.hook(this, h_MsGetRamConfigChangeEffect)
            && FFX2.FhCall.MsGetSaveDressUpCount.hook(this, h_MsGetSaveDressUpCount)
            && FFX2.FhCall.kyGetJobNum.hook(this, h_kyGetJobNum)
            && FFX2.FhCall.kyGetJobNum3.hook(this, h_kyGetJobNum3)
            && FFX2.FhCall.TOMenuMakeJobList.hook(this, h_TOMenuMakeJobList)
            && FFX2.FhCall.TODVDFileReadNonBlock.hook(this, h_TODVDFileReadNonBlock)
            && FFX2.FhCall.MsGetSavePlate.hook(this, h_MsGetSavePlate)
            && FFX2.FhCall.kyGetUsedPoint.hook(this, h_kyGetUsedPoint)
            && FFX2.FhCall.kyAddPoint3D.hook(this, h_kyAddPoint3D)
            && FFX2.FhCall.MsGetJobAbilityList.hook(this, h_MsGetJobAbilityList)
            && FFX2.FhCall.TOMenuMakeJobAbilityList.hook(this, h_TOMenuMakeJobAbilityList)
            && FFX2.FhCall.TOMenuStartJobAbilityWindow.hook(this, h_TOMenuStartJobAbilityWindow)
            && FFX2.FhCall.MsGetSaveLearn.hook(this, h_MsGetSaveLearn)
            && FFX2.FhCall.MsSetSaveLearn.hook(this, h_MsSetSaveLearn)

            && FFX2.FhCall.MsGetChrNum.hook(this, h_MsGetChrNum)
            && FFX2.FhCall.MsCalcChrLevel.hook(this, h_MsCalcChrLevel)
            && _MsGetComData.hook(this, h_MsGetComData)
            && FFX2.FhCall.MsBtlMonsterSaveNumCheck.hook(this, h_MsBtlMonsterSaveNumCheck)
            && FFX2.FhCall.MsCheckAbility.hook(this, h_MsCheckAbility)
            && FFX2.FhCall.FUN_006294f0.hook(this, h_FUN_6294f0)
            && FFX2.FhCall.MsCheckLearnCommand.hook(this, h_MsCheckLearnCommand)
            && FFX2.FhCall.MsGetSaveCommand.hook(this, h_MsGetSaveCommand)
            && FFX2.FhCall.MsGetSaveAp.hook(this, h_MsGetSaveAp)
            && FFX2.FhCall.MsGetSaveNeedAp.hook(this, h_MsGetSaveNeedAp)
            && FFX2.FhCall.MsGetJobNumBasic.hook(this, h_MsGetJobNumBasic)
            && FFX2.FhCall.MsBtlPlayerSaveNumCheck.hook(this, h_MsBtlPlayerSaveNumCheck)

            && FFX2.FhCall.TOGetSaveJobName.hook(this, h_TOGetSaveJobName)
            && FFX2.FhCall.MsGetSaveJob.hook(this, h_MsGetSaveJob)
            && FFX2.FhCall.kySetHelpJob2.hook(this, h_kySetHelpJob2)
            && FFX2.FhCall.TOMenuSetHelpMes.hook(this, h_TOMenuSetHelpMes)

            && FFX2.FhCall.MsGetChrID.hook(this, h_MsGetChrID)
            && FFX2.FhCall.MsSetRamMotionChrData.hook(this, h_MsSetRamMotionChrData)
            && FFX2.FhCall.MsGetChr.hook(this, h_MsGetChr)
            && FFX2.FhCall.FUN_0062AB30.hook(this, h_FUN_62AB30)
            && FFX2.FhCall.FUN_00534A70.hook(this, h_FUN_534A70)
            && FFX2.FhCall.MsGetSaveChrName.hook(this, h_MsGetSaveChrName)

            && FFX2.FhCall.TOGetFaceIndex2.hook(this, h_TOGetFaceIndex2)

            && FFX2.FhCall.MsBtlChrGetMem.hook(this, h_MsBtlChrGetMem)
            && FFX2.FhCall.TOCtrlATBChr.hook(this, h_TOCtrlATBChr)

            && FFX2.FhCall.TOMenuGetJobLearnedRate.hook(this, h_TOMenuGetJobLearnedRate)
            && _FUN_00778680.hook(this, h_FUN_00778680)

            && FFX2.FhCall.TOMenuNextJobList.hook(this, h_TOMenuNextJobList)
            && FFX2.FhCall.TOMenuPrevJobList.hook(this, h_TOMenuPrevJobList)

            && FFX2.FhCall.FUN_777C60.hook(this, h_FUN_777C60)
            && FFX2.FhCall.TOGetRomHelp.hook(this, h_TOGetRomHelp)
            && FFX2.FhCall.TkMenuSetHelpMessage.hook(this, h_TkMenuSetHelpMessage)

            && FFX2.FhCall.FUN_778160.hook(this, h_FUN_778160)
            && FFX2.FhCall.FUN_776EC0.hook(this, h_FUN_776EC0)
            && FFX2.FhCall.FUN_777270.hook(this, h_FUN_777270)
            && FFX2.FhCall.TOMenuSetSaveLearn.hook(this, h_TOMenuSetSaveLearn)
            && FFX2.FhCall.TOMenuSetMacroCommandType.hook(this, h_TOMenuSetMacroCommandType)
            && FFX2.FhCall.TOBtlGetComName.hook(this, h_TOBtlGetComName)
            && FFX2.FhCall.TOMenuSetMacroCommandValue.hook(this, h_TOMenuSetMacroCommandValue)
            && FFX2.FhCall.TOGetMenuText.hook(this, h_TOGetMenuText)
            && FFX2.FhCall.SndSepPlaySimple.hook(this, h_SndSepPlaySimple)

            //&& FFX2.FhCall.FFX2_Set_UI_Scale.hook(this, h_FFX2_Set_UI_Scale)
            && FFX2.FhCall.TkMenuGetTimer.hook(this, h_TkMenuGetTimer)
            && FFX2.FhCall.offsetAdjust_Y.hook(this, h_offsetAdjust_Y)
            && FFX2.FhCall.TOMkpShape2dMenu.hook(this ,h_TOMkpShape2dMenu);
    }

    public override void load_local_state(FileStream? local_state_file, FhLocalStateInfo local_state_info)
    {
        
        var loaded_state = JsonSerializer.Deserialize<X2DSUnlimitState>(local_state_file);

        if (loaded_state != null)
        {
            freelancer_quantity = loaded_state.freelancer_quantity;
            leblanc_goon_quantity = loaded_state.leblanc_goon_quantity;

            y_freelancer_ability_learning = loaded_state.y_freelancer_ability_learning;
            r_freelancer_ability_learning = loaded_state.r_freelancer_ability_learning;
            p_freelancer_ability_learning = loaded_state.p_freelancer_ability_learning;

            y_leblancgoon_ability_learning = loaded_state.y_leblancgoon_ability_learning;
            r_leblancgoon_ability_learning = loaded_state.r_leblancgoon_ability_learning;
            p_leblancgoon_ability_learning = loaded_state.p_leblancgoon_ability_learning;
        }
    }
    public override void save_local_state(FileStream  local_state_file)
    {
        X2DSUnlimitState  state = new();
        JsonSerializer.Serialize(local_state_file, state);
        local_state_file.SetLength(local_state_file.Position);
    }
}
