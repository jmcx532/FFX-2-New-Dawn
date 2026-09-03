namespace Fahrenheit.Mods.X2DSUnlimit;

/// <summary>
/// Each dressphere has motion data present in system_01.bin, however, there is none present for Freelancer and Leblanc Goon.
/// This data originally can be found in system_01.bin at 0x3EB6C. It consist of block of 56 bytes representing ChrRamMotionData
/// 
/// Here you can set motion data for Freelancer and Leblanc Goon as required, see bottom of file.
/// See jppc/battle/btl/system_01/mot_system_01.txt for vanilla examples.
/// 
/// </summary>

// this is as the data is laid out in system_01.bin - not in game memory!
// for ram layout, see jppc/battle/btl/system_01/mot_system_01.txt
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MotionChrData {
    public byte chr_id;
    public byte job_num;

    public short mot_bin_num;
    public short round_frame;
    public short attack_frame;

    public byte attack_inc_speed;
    public byte attack_dec_speed;
    public byte idle2_prob;
    public byte steal_frame;

    public int motion_type;

    public int attack_start_dist;
    public int attack_offset_dist;
    public int attack_height;

    public int run_speed;
    public int run_return_dist;
    public int run_speed_v0;
    public int run_speed_acc;
    public int run_ang_v_max;
    public int run_ang_acc;

    public int weight;
}

public partial class X2DSUnlimitModule : FhModule {

    // write correct RamMotionChrData for Freelancer/LG - not in system_01.bin for these 2 dresspheres
    public unsafe void h_MsSetRamMotionChrData(uint chr_id, uint job_id) {
        //int job_number = h_MsGetJobNumBasic(job_id);

        // handle Freelancer and Leblanc Goon
        if (job_id > 0x501c) {
            _logger.Info("Running for FL/LG");

            MotionChrData motion_data = default_motion;

            if (job_id == 0x501D)
            {
                motion_data = y_festivalist_motion;
            }

            if (job_id == 0x501E)
            {
                motion_data = r_festivalist_motion;
            }

            if (job_id == 0x501F)
            {
                motion_data = p_festivalist_motion;
            }

            if (job_id == 0x5020) {

                uint chr_addr = (uint)h_MsGetChr((uint)chr_id);

                switch (chr_id) {
                    case 0:
                        motion_data = y_freelancer_motion;
                        break;
                    case 1:
                        motion_data = r_freelancer_motion;
                        break;
                    case 2:
                        motion_data = p_freelancer_motion;
                        break;
                }

            }
            if (job_id == 0x5021) {
                switch (chr_id) {
                    case 0:
                        motion_data = y_leblancgoon_motion;
                        break;
                    case 1:
                        motion_data = r_leblancgoon_motion;
                        break;
                    case 2:
                        motion_data = p_leblancgoon_motion;
                        break;
                }
            }

            Chr* chr = h_MsGetChr((uint)chr_id);
            int chr_base = (int)chr;

            *(byte*)(chr_base + 0x75f) = (byte)motion_data.mot_bin_num; //0; //(byte)psVar3[1];
            *(short*)(chr_base + 0x796) = motion_data.round_frame; //(short)freelancer_motion_data[2];//psVar3[2];
            *(short*)(chr_base + 0x78e) = motion_data.attack_frame; //(short)freelancer_motion_data[3];//psVar3[3];
            *(short*)(chr_base + 0x790) = motion_data.steal_frame; //0x12; //(short)*(char*)((int)psVar3 + 0xb);
            *(byte*)(chr_base + 0x794) = motion_data.attack_inc_speed; //0x20; //(char)psVar3[4];
            *(byte*)(chr_base + 0x795) = motion_data.attack_dec_speed; //0x20; //*(undefined1*)((int)psVar3 + 9);
            *(byte*)(chr_base + 0x75e) = motion_data.idle2_prob; //0x04; //(char)psVar3[5];
            *(int*)(chr_base + 0x758) = motion_data.motion_type; ; //*(undefined4*)(psVar3 + 6); // attack distance related, weird attack bug by default in FL/LG with melee
            *(float*)(chr_base + 0x760) = motion_data.attack_start_dist / 10000.0f; //17; //(float)*(int*)(psVar3 + 8) / 10000.0; // hex: 0x41880000
            *(float*)(chr_base + 0x764) = motion_data.attack_offset_dist / 10000.0f; //6.999700069f;//(float)*(int*)(psVar3 + 10) / 10000.0;
            *(float*)(chr_base + 0x768) = motion_data.attack_height / 10000.0f; //(float)*(int*)(psVar3 + 0xc) / 10000.0;
            *(float*)(chr_base + 0x770) = motion_data.run_speed / 10000.0f; //42;//(float)*(int*)(psVar3 + 0xe) / 10000.0;
            *(float*)(chr_base + 0x76c) = motion_data.run_return_dist / 10000.0f; //20;//(float)*(int*)(psVar3 + 0x10) / 10000.0;
            *(float*)(chr_base + 0x774) = motion_data.run_speed_v0 / 10000.0f; ; //(float)*(int*)(psVar3 + 0x12) / 10000.0;
            *(float*)(chr_base + 0x778) = motion_data.run_speed_acc / 10000.0f;  //8;//(float)*(int*)(psVar3 + 0x14) / 10000.0;
            *(float*)(chr_base + 0x77c) =  motion_data.run_ang_v_max / 1000000.0f; //0.2114380002f;//(float)*(int*)(psVar3 + 0x16) / 1e+06;
            *(float*)(chr_base + 0x780) = motion_data.run_ang_acc / 1000000.0f; //0.03510500118f;//(float)*(int*)(psVar3 + 0x18) / 1e+06;
            *(float*)(chr_base + 0x788) = motion_data.weight / 10000.0f; //50;//(float)*(int*)(psVar3 + 0x1a) / 10000.0;
        }
        else {
            FFX2.FhCall.MsSetRamMotionChrData.chain_from(h_MsSetRamMotionChrData).fnptr!(chr_id, job_id);
        }
    }


    MotionChrData y_festivalist_motion = new()
    {
        chr_id = 0,
        job_num = 0x1d,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };

    MotionChrData y_freelancer_motion = new(){
        chr_id = 0,
        job_num = 0x20,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };


    MotionChrData y_leblancgoon_motion = new(){
        chr_id = 0,
        job_num = 0x21,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };


    MotionChrData r_festivalist_motion = new()
    {
        chr_id = 0,
        job_num = 0x1e,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };

    MotionChrData r_freelancer_motion = new(){
        chr_id = 1,
        job_num = 0x20,

        mot_bin_num = 31,
        round_frame = 16,
        attack_frame = 32,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 150000,
        attack_offset_dist = 50000,
        attack_height = 0,

        run_speed = 400000,
        run_return_dist = 10000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 191983,
        run_ang_acc = 34903,
        weight = 400000,

    };


    MotionChrData r_leblancgoon_motion = new(){
        chr_id = 0,
        job_num = 0x21,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };

    MotionChrData p_festivalist_motion = new()
    {
        chr_id = 2,
        job_num = 0x1f,

        mot_bin_num = 0,
        round_frame = 8, // 8
        attack_frame = 38, // 38

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 0, // 0

        motion_type = 193, // 193
        attack_start_dist = 100000, // 10 (m 10000)
        attack_offset_dist = 650000, // 6.5 (m 10000)
        attack_height = 0, // (m 10000)

        run_speed = 350000, // 35 (m 10000)
        run_return_dist = 200000, //20 (m 10000)
        run_speed_v0 = 0, //(m 10000)
        run_speed_acc = 40000, //4 (m 10000)
        run_ang_v_max = 261700, //0.2617 (m 1000000)
        run_ang_acc = 26170, // 0.02617 (m 1000000)
        weight = 150000, // 150 (m 10000)

    };

    MotionChrData p_freelancer_motion = new(){
        chr_id = 0,
        job_num = 0x20,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };


    MotionChrData p_leblancgoon_motion = new(){
        chr_id = 0,
        job_num = 0x21,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };

    MotionChrData default_motion = new(){
        chr_id = 0,
        job_num = 0x20,

        mot_bin_num = 0,
        round_frame = 16,
        attack_frame = 26,

        attack_inc_speed = 32,
        attack_dec_speed = 32,
        idle2_prob = 4,
        steal_frame = 18,

        motion_type = 17,
        attack_start_dist = 170000,
        attack_offset_dist = 69997,
        attack_height = 0,

        run_speed = 420000,
        run_return_dist = 200000,
        run_speed_v0 = 0,
        run_speed_acc = 80000,
        run_ang_v_max = 211438,
        run_ang_acc = 35105,
        weight = 500000,

    };

}
