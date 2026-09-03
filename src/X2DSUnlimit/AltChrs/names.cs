namespace Fahrenheit.Mods.X2DSUnlimit;
public partial class X2DSUnlimitModule : FhModule {
    public enum CharName {
        Yuna = 0,
        Rikku = 1,
        Paine = 2,
        Kimahri = 3,
        Tidus = 4,
        Seymour = 5,
        Leblanc = 6,
        Logos = 7,
        Ormi = 8

    }

    // Write Chr Name to party and btl_chr name buffers
    public unsafe void WriteChrName(CharName character_name, uint chr_id) {
        byte* party_name_area = FhUtil.ptr_at<byte>(0xa05ffc);
        byte* party_name_base = party_name_area + (chr_id * 40);


        Span<byte> party_name_buffer = new Span<byte>(party_name_base, 40);

        ReadOnlySpan<byte> name = character_name switch
            {
                CharName.Yuna    => "Yuna"u8,
                CharName.Rikku => "Rikku"u8,
                CharName.Paine => "Paine"u8,
                CharName.Kimahri => "Kimahri"u8,
                CharName.Tidus => "Tidus"u8,
                CharName.Seymour => "Seymour"u8,
                CharName.Leblanc => "Leblanc"u8,
                CharName.Logos => "Logos"u8,
                CharName.Ormi => "Ormi"u8,
                _                => "Yuna"u8
            };

        party_name_buffer.Clear();
        FhEncoding.encode(name, party_name_buffer);

        // in battle overwrite Chr string
        int btl_chr_ptr = FhUtil.get_at<int>(0xa0fbac);
        if (btl_chr_ptr != 0) {
            Chr* chr = h_MsGetChr(chr_id);
            int chr_base_addr = (int)chr;
            byte* name_area = (byte*)chr_base_addr + 0x358;

            Span<byte> name_buffer = new Span<byte>(name_area, 40);
            name_buffer.Clear();
            FhEncoding.encode(name, name_buffer);
        }
    }

    private void HandleCustomCharacterName(uint chr_id, uint job_id) {
        switch (chr_id) {
            case 0:
                if (job_id == 0x5020) {
                    WriteChrName(CharName.Leblanc, 0);
                }
                else if (job_id == 0x5021) {
                    WriteChrName(CharName.Kimahri, 0);
                }
                else if (job_id == 0x501D)
                {
                    WriteChrName(CharName.Kimahri, 0);
                }
                else {
                    WriteChrName(CharName.Yuna, 0);
                }
                break;

            case 1:
                if (job_id == 0x5020) {
                    WriteChrName(CharName.Logos, 1);
                }
                else if (job_id == 0x5021) {
                    WriteChrName(CharName.Tidus, 1);
                }
                else if (job_id == 0x501E)
                {
                    WriteChrName(CharName.Tidus, 1);
                }
                else {
                    WriteChrName(CharName.Rikku, 1);
                }
                break;

            case 2:
                 if (job_id == 0x5020) {
                    WriteChrName(CharName.Ormi, 2);
                }
                else if (job_id == 0x5021) {
                    WriteChrName(CharName.Seymour, 2);
                }
                else if (job_id == 0x501F)
                {
                    WriteChrName(CharName.Seymour, 2);
                }
                else {
                    WriteChrName(CharName.Paine, 2);
                }
                break;
        }
    }

    public unsafe byte* h_MsGetSaveChrName(uint chr_id) {
        return FFX2.FhCall.MsGetSaveChrName.chain_from(h_MsGetSaveChrName).fnptr!(chr_id);
    }

    

    // reimplementation so job name string is read correctly from job.bin for C# defined jobs
    // Returns a memory address at which a null-terminated string is located.
    public unsafe byte* h_TOGetSaveJobName(uint chr_id) {

        uint job_id;

        int job_bin_base = FhUtil.get_at<int>(0x9f9188); // memory address of job.bin
        int string_start = *(int*)(job_bin_base + 0x18); // read from excel header
        int string_table_base = job_bin_base + 0x20 + string_start; //base, skip header, jump to start of string table


        job_id = h_MsGetSaveJob(chr_id);
        byte* local_8 = null;
        ushort name_string_pointer = *(ushort*)(h_MsGetRomJob(chr_id, job_id, local_8));

        //custom name handling
        HandleCustomCharacterName(chr_id, job_id);

        return (byte*)(string_table_base + name_string_pointer); // memory address, start of null terminated byte string
    }


    /// <summary>
    /// Reimplementations so job help string is read correctly from job.bin for C# defined jobs
    /// TOMenuSetHelpMes is run by kySetHelpJob2 and it takes a memory address of a null terminated byte string as a parameter.
    /// </summary>
    public unsafe void h_TOMenuSetHelpMes(byte* addr_of_txt_bytes) {
        FFX2.FhCall.TOMenuSetHelpMes.chain_from(h_TOMenuSetHelpMes).fnptr!(addr_of_txt_bytes);
    }

    public unsafe void h_kySetHelpJob2(uint job_id) {
        if (0x5020 <= job_id) {

            int job_bin_base = FhUtil.get_at<int>(0x9f9188); // memory address of job.bin
            int string_start = *(int*)(job_bin_base + 0x18); // read from excel header
            int string_table_base = job_bin_base + 0x20 + string_start; //base, skip header, jump to start of string table

            int chr_id = FhUtil.get_at<int>(0x9f6d80);
            byte* out_data_end = null;

            Job considered_job = *(Job*)h_MsGetRomJob((uint)chr_id, job_id, out_data_end);

            ushort help_string_offset = considered_job.help_offset.text_offset;
            ushort cre_help_string_offset = considered_job.creature_data.help_text.text_offset;

            //ushort help_string_offset = *(ushort*)(h_MsGetRomJob((uint)chr_id, job_id, out_data_end) + 0x4); // use this to get help string offset
            //ushort cre_help_string_offset = *(ushort*)(h_MsGetRomJob((uint)chr_id, job_id, out_data_end) + 0xAC);

            // cre help
            if (chr_id > 2) {
                h_TOMenuSetHelpMes((byte*)(string_table_base + cre_help_string_offset));
            }
            h_TOMenuSetHelpMes((byte*)(string_table_base + help_string_offset));
        }
        else {
            FFX2.FhCall.kySetHelpJob2.chain_from(h_kySetHelpJob2).fnptr!(job_id);
        }
    }

}

