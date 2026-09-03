// SPDX-License-Identifier: MIT

namespace Fahrenheit.Mods.X2DSUnlimit;

public static class VanillaVoicelines {

    // Auto-generated from FFX-2 Battle Voicelines CSV
    // Character codes: yn = Yuna, rk = Rikku, pn = Paine

    public static readonly MemoryWrite[] VanillaVL_yn = // Yuna
[
    // Battle start
    new() { Offset = 0x2240, Value = 0x4e56521d }, // 120101 - "Let's do it!"
    new() { Offset = 0x2248, Value = 0x4e66521d }, // 120102 - "No problem!"
    new() { Offset = 0x2250, Value = 0x4e76521d }, // 120103 - "Gullwings at your service!"
    new() { Offset = 0x2258, Value = 0x4e86521d }, // 120104 - "Hi there"
    // Battle start (low health?) (LM?)
    new() { Offset = 0x2370, Value = 0x4ed6901d }, // 121101 - "Everyone stay close"
    new() { Offset = 0x2378, Value = 0x4ee6901d }, // 121102 - "We can do it"
    new() { Offset = 0x2380, Value = 0x4ef6901d }, // 121103 - "Don't worrry we can win this"
    new() { Offset = 0x2388, Value = 0x4e06911d }, // 121104 - "Uhhh, no sweat"
    // Battle start
    new() { Offset = 0x22B8, Value = 0x4e26c91d }, // 122002 - "Let's go Gullwings! Yeah, let's do it!"
    new() { Offset = 0x22D8, Value = 0x4e66c91d }, // 122006 - "This'll only take... two rounds! / Give me one!"
    new() { Offset = 0x2310, Value = 0x4e96d51d }, // 122201 - "Piece of cake? Where's the fun in that?"
    new() { Offset = 0x2320, Value = 0x4eb6d51d }, // 122203 - "You're going down! / That's the spirit!"
    new() { Offset = 0x2328, Value = 0x4ec6d51d }, // 122204 - "Don't get careless! / Who, me?"
    new() { Offset = 0x2350, Value = 0x4e36e21d }, // 122403 - "Bring it! / She's sure getting into this! / She's trying"
    new() { Offset = 0x2368, Value = 0x4e66e21d }, // 122406 - "Gimme a Y! / Gimme an R! / Gimme a break"
    // LM In trouble?
    new() { Offset = 0x2470, Value = 0x4e76e81d }, // 122503
    new() { Offset = 0x2478, Value = 0x4e86e81d }, // 122504
    // (no purpose listed)
    new() { Offset = 0x212C, Value = 0x4e06f51d }, // 122704 - "Where's the imposter!?! (Luca)"
    new() { Offset = 0x2130, Value = 0x4e16f51d }, // 122705 - "A trial..."
    new() { Offset = 0x2144, Value = 0x4e66f51d }, // 122710 - "This is getting old..."
    new() { Offset = 0x214C, Value = 0x4e86f51d }, // 122712 - "Time to clobber the robber!"
    new() { Offset = 0x2150, Value = 0x4e96f51d }, // 122713 - "What are you doing! (Baralai fight?)"
    new() { Offset = 0x2158, Value = 0x4eb6f51d }, // 122715 - "I'm sorry. (Aeon fight)"
    new() { Offset = 0x2168, Value = 0x4ef6f51d }, // 122719 - "Sigh (Bahamut fight?)"
    new() { Offset = 0x216C, Value = 0x4e06f61d }, // 122720 - "Not you too..."
    new() { Offset = 0x2170, Value = 0x4e16f61d }, // 122721 - "Forgive me."
    new() { Offset = 0x2174, Value = 0x4e26f61d }, // 122722 - "It's been a while"
    new() { Offset = 0x2178, Value = 0x4e16fb1d }, // 122801 - "Ready? Let's kick some tail! (Vegnagun)"
    new() { Offset = 0x2180, Value = 0x4e36fb1d }, // 122803 - "It's so big! (Vegnagun fight)"
    // Final boss start
    new() { Offset = 0x2184, Value = 0x4e46fb1d }, // 122804 - "Shuyin!"
    // LM?
    new() { Offset = 0x23D0, Value = 0x4e56011e }, // 122901
    new() { Offset = 0x23D8, Value = 0x4e66011e }, // 122902
    new() { Offset = 0x23E0, Value = 0x4e76011e }, // 122903
    new() { Offset = 0x2448, Value = 0x4ec6071e }, // 123004
    new() { Offset = 0x2450, Value = 0x4ed6071e }, // 123005
    new() { Offset = 0x2458, Value = 0x4ee6071e }, // 123006
    // Into Gunner
    new() { Offset = 0xFB8, Value = 0x4e96c91f }, // 130201 - "I've got you in my sights!"
    new() { Offset = 0xFC0, Value = 0x4ea6c91f }, // 130202 - "You can't run or hide so why bother?"
    new() { Offset = 0xFC8, Value = 0x4eb6c91f }, // 130203 - "Resistance is futile!"
    // Into Gun Mage
    new() { Offset = 0xF38, Value = 0x4ed6cf1f }, // 130301 - "Prepare for a phantasmagoric panoply of magical power! Your abilities will be mine!"
    new() { Offset = 0xFD0, Value = 0x4ee6cf1f }, // 130302 - "One enchanted bullet just for you!"
    new() { Offset = 0xFD8, Value = 0x4ef6cf1f }, // 130303 - "Time to let the magic fly!"
    new() { Offset = 0xFE0, Value = 0x4e06d01f }, // 130304 - "My gun cries out for you!"
    // Into Alchemist
    new() { Offset = 0xF40, Value = 0x4e16d61f }, // 130401 - "Need some items tossed around? I'm your girl!"
    new() { Offset = 0xFE8, Value = 0x4e26d61f }, // 130402 - "Time to raid the secret stash!"
    new() { Offset = 0xFF0, Value = 0x4e36d61f }, // 130403 - "I've been saving these just for you"
    new() { Offset = 0xFF8, Value = 0x4e46d61f }, // 130404 - "Better make this count"
    // Into Thief
    new() { Offset = 0xF48, Value = 0x4e56dc1f }, // 130501
    new() { Offset = 0x1000, Value = 0x4e66dc1f }, // 130502
    new() { Offset = 0x1008, Value = 0x4e76dc1f }, // 130503
    new() { Offset = 0x1010, Value = 0x4e86dc1f }, // 130504
    // Into Trainer
    new() { Offset = 0xF50, Value = 0x4e96e21f }, // 130601
    new() { Offset = 0x1018, Value = 0x4ea6e21f }, // 130602
    new() { Offset = 0x1020, Value = 0x4eb6e21f }, // 130603
    new() { Offset = 0x1028, Value = 0x4ec6e21f }, // 130604
    // Into Warrior
    new() { Offset = 0xF60, Value = 0x4ed6e81f }, // 130701 - "Stand in my way and I'll cut you down!"
    new() { Offset = 0x1048, Value = 0x4ee6e81f }, // 130702 - "I will clear a path!"
    new() { Offset = 0x1050, Value = 0x4ef6e81f }, // 130703 - "Strength isn't my only weapon!"
    new() { Offset = 0x1058, Value = 0x4e06e91f }, // 130704 - "Believe in the sword!"
    // Into Samurai
    new() { Offset = 0xF68, Value = 0x4e16ef1f }, // 130801
    new() { Offset = 0x1060, Value = 0x4e26ef1f }, // 130802
    new() { Offset = 0x1068, Value = 0x4e36ef1f }, // 130803
    new() { Offset = 0x1070, Value = 0x4e46ef1f }, // 130804
    // Into Dark Knight
    new() { Offset = 0xF70, Value = 0x4e56f51f }, // 130901
    new() { Offset = 0x1078, Value = 0x4e66f51f }, // 130902
    new() { Offset = 0x1080, Value = 0x4e76f51f }, // 130903
    new() { Offset = 0x1088, Value = 0x4e86f51f }, // 130904
    // Into Berserker
    new() { Offset = 0xF78, Value = 0x4e96fb1f }, // 131001
    new() { Offset = 0x1090, Value = 0x4ea6fb1f }, // 131002
    new() { Offset = 0x1098, Value = 0x4eb6fb1f }, // 131003
    new() { Offset = 0x10A0, Value = 0x4ec6fb1f }, // 131004
    // Into Songstress
    new() { Offset = 0xF80, Value = 0x4ed60120 }, // 131101
    new() { Offset = 0x10A8, Value = 0x4ee60120 }, // 131102
    new() { Offset = 0x10B0, Value = 0x4ef60120 }, // 131103
    new() { Offset = 0x10B8, Value = 0x4e060220 }, // 131104
    // Into Black Mage
    new() { Offset = 0xF88, Value = 0x4e160820 }, // 131201
    new() { Offset = 0x10C0, Value = 0x4e260820 }, // 131202
    new() { Offset = 0x10C8, Value = 0x4e360820 }, // 131203
    new() { Offset = 0x10D0, Value = 0x4e460820 }, // 131204
    // Into White Mage
    new() { Offset = 0xF90, Value = 0x4e560e20 }, // 131301
    new() { Offset = 0x10D8, Value = 0x4e660e20 }, // 131302
    new() { Offset = 0x10E0, Value = 0x4e760e20 }, // 131303
    new() { Offset = 0x10E8, Value = 0x4e860e20 }, // 131304
    // Into Lady Luck
    new() { Offset = 0xF98, Value = 0x4e961420 }, // 131401
    new() { Offset = 0x10F0, Value = 0x4ea61420 }, // 131402
    new() { Offset = 0x10F8, Value = 0x4eb61420 }, // 131403
    new() { Offset = 0x1100, Value = 0x4ec61420 }, // 131404
    // Into Mascot
    new() { Offset = 0xF58, Value = 0x4ed61a20 }, // 131501
    new() { Offset = 0x1030, Value = 0x4ee61a20 }, // 131502
    new() { Offset = 0x1038, Value = 0x4ef61a20 }, // 131503 - "As deadly as I am cute"
    new() { Offset = 0x1040, Value = 0x4e061b20 }, // 131504
    // Into Special dressphere?
    new() { Offset = 0xFA0, Value = 0x4e162120 }, // 131601 - "A power to great to be bridled can only be set free"
    new() { Offset = 0x1108, Value = 0x4e262120 }, // 131602 - "I've got this one covered"
    new() { Offset = 0x1110, Value = 0x4e362120 }, // 131603 - "I'll fight you to my last breath!"
    new() { Offset = 0x1118, Value = 0x4e462120 }, // 131604 - "It's too late for regrets"
    // Restorative ability?
    new() { Offset = 0x1190, Value = 0x4e562720 }, // 131701 - "This'll help"
    new() { Offset = 0x12C8, Value = 0x4e662720 }, // 131702 - "Hang in there"
    new() { Offset = 0x11A0, Value = 0x4e762720 }, // 131703 - "You OK?"
    new() { Offset = 0x11A8, Value = 0x4e862720 }, // 131704 - "Be strong!"
    new() { Offset = 0x11B0, Value = 0x4e962720 }, // 131705 - "I've got you!"
    // Buff ability? e.g Haste?
    new() { Offset = 0x11B8, Value = 0x4e962d20 }, // 131801 - "Come on!"
    new() { Offset = 0x11C0, Value = 0x4ea62d20 }, // 131802 - "Any better?"
    new() { Offset = 0x11C8, Value = 0x4eb62d20 }, // 131803 - "Let's play it safe."
    // (no purpose listed)
    new() { Offset = 0x11D0, Value = 0x4ed63320 }, // 131901 - "Sorry! (cheeky)"
    new() { Offset = 0x11D8, Value = 0x4ee63320 }, // 131902 - "Try this on for size!"
    new() { Offset = 0x11E0, Value = 0x4ef63320 }, // 131903 - "Behave yourself"
    // General ability use?
    new() { Offset = 0x11E8, Value = 0x4e163a20 }, // 132001 - "You're mine!"
    new() { Offset = 0x11F0, Value = 0x4e263a20 }, // 132002 - "Time to act"
    new() { Offset = 0x11F8, Value = 0x4e363a20 }, // 132003 - "This'll do it!"
    new() { Offset = 0x1200, Value = 0x4e463a20 }, // 132004 - "Here goes"
    new() { Offset = 0x1208, Value = 0x4e563a20 }, // 132005 - "I've got it"
    new() { Offset = 0x1210, Value = 0x4e663a20 }, // 132006 - "That's enough from you!"
    // Eject
    new() { Offset = 0x1228, Value = 0x4e564020 }, // 132101 - "Hope you like to travel!"
    new() { Offset = 0x1230, Value = 0x4e664020 }, // 132102 - "You're outta here!"
    new() { Offset = 0x1238, Value = 0x4e764020 }, // 132103 - "This is goodbye!"
    // Scan
    new() { Offset = 0x1240, Value = 0x4e964620 }, // 132201 - "Let's take a look"
    new() { Offset = 0x1248, Value = 0x4ea64620 }, // 132202 - "So what's your weakness?"
    new() { Offset = 0x1250, Value = 0x4eb64620 }, // 132203 - "Just how tough are you?"
    // Fire magic
    new() { Offset = 0x1258, Value = 0x4ed64c20 }, // 132301 - "Dance, flames!"
    new() { Offset = 0x1260, Value = 0x4ee64c20 }, // 132302 - "The flame consumes all"
    new() { Offset = 0x1268, Value = 0x4ef64c20 }, // 132303 - "Where there's smoke"
    // Ice magic
    new() { Offset = 0x1270, Value = 0x4e165320 }, // 132401 - "Cold spell coming"
    new() { Offset = 0x1278, Value = 0x4e265320 }, // 132402 - "Cool off"
    new() { Offset = 0x1280, Value = 0x4e365320 }, // 132403 - "Freeze"
    // Water magic
    new() { Offset = 0x1288, Value = 0x4e565920 }, // 132501 - "Get wet!"
    new() { Offset = 0x1290, Value = 0x4e665920 }, // 132502 - "Rinse, repeat"
    new() { Offset = 0x1298, Value = 0x4e765920 }, // 132503 - "Never turn your back to the sea!"
    // Thunder magic
    new() { Offset = 0x12A0, Value = 0x4e965f20 }, // 132601 - "One, one thousand"
    new() { Offset = 0x12A8, Value = 0x4ea65f20 }, // 132602 - "Nature's wrath, strike my foe"
    new() { Offset = 0x12B0, Value = 0x4eb65f20 }, // 132603 - "Do I hear, Thunder?"
    // Restorative magic?
    new() { Offset = 0x12B8, Value = 0x4ed66520 }, // 132701 - "All shall be restored"
    new() { Offset = 0x12C0, Value = 0x4ee66520 }, // 132702 - "It's not over"
    new() { Offset = 0x1198, Value = 0x4ef66520 }, // 132703 - "Everyone, stay strong"
    // Steal / Flimflam
    new() { Offset = 0x1150, Value = 0x4e166c20 }, // 132801 - "Whatcha hiding?"
    new() { Offset = 0x1158, Value = 0x4e266c20 }, // 132802 - "I'll take that"
    new() { Offset = 0x1160, Value = 0x4e366c20 }, // 132803 - "No junk, please"
    new() { Offset = 0x1168, Value = 0x4e567220 }, // 132901 - "Got anything I need?"
    new() { Offset = 0x1170, Value = 0x4e667220 }, // 132902 - "Hope you don't mind"
    new() { Offset = 0x1178, Value = 0x4e767220 }, // 132903 - "You're an easy target"
    // Mix
    new() { Offset = 0x14F0, Value = 0x4e967820 }, // 133001 - "I hope this works"
    new() { Offset = 0x14F8, Value = 0x4ea67820 }, // 133002 - "Hmm, if that goes here, then..."
    new() { Offset = 0x1500, Value = 0x4eb67820 }, // 133003 - "Trust me, I know what I'm doing"
    // Stash
    new() { Offset = 0x12D0, Value = 0x4ed67e20 }, // 133101 - "Now's a good a time as any"
    new() { Offset = 0x12D8, Value = 0x4ee67e20 }, // 133102 - "I knew this would come in handy"
    new() { Offset = 0x12E0, Value = 0x4ef67e20 }, // 133103 - "Good thing I saved this"
    // Blue Bullet
    new() { Offset = 0x12E8, Value = 0x4e168520 }, // 133201 - "Feel the power of fiends unleashed!"
    new() { Offset = 0x12F0, Value = 0x4e268520 }, // 133202 - "This is no ordinary bullet!"
    new() { Offset = 0x12F8, Value = 0x4e368520 }, // 133203 - "Anything goes for Gun Mage Yuna!"
    // Fiend Hunter
    new() { Offset = 0x1300, Value = 0x4e568b20 }, // 133301 - "This one's just for you!"
    new() { Offset = 0x1308, Value = 0x4e668b20 }, // 133302 - "This should do the trick"
    new() { Offset = 0x1310, Value = 0x4e768b20 }, // 133303 - "Here's your silver bullet"
    // Berserk
    new() { Offset = 0x1318, Value = 0x4e969120 }, // 133401 - "No holding back!"
    new() { Offset = 0x1320, Value = 0x4ea69120 }, // 133402 - "Time to let off some steam!"
    new() { Offset = 0x1328, Value = 0x4eb69120 }, // 133403 - "Yuna gone wild!"
    // Darkness
    new() { Offset = 0x1330, Value = 0x4ed69720 }, // 133501 - "My suffering mirrors yours"
    new() { Offset = 0x1338, Value = 0x4ee69720 }, // 133502 - "May pain be my blade"
    new() { Offset = 0x1340, Value = 0x4ef69720 }, // 133503 - "This had better be worth it"
    // Zantetsu
    new() { Offset = 0x1348, Value = 0x4e169e20 }, // 133601 - "Zantetsuken!"
    new() { Offset = 0x1350, Value = 0x4e269e20 }, // 133602 - "My turn!"
    new() { Offset = 0x1358, Value = 0x4e369e20 }, // 133603 - "One cut, one kill"
    // Spare Change
    new() { Offset = 0x1360, Value = 0x4e56a420 }, // 133701 - "Whatever works I guess"
    new() { Offset = 0x1368, Value = 0x4e66a420 }, // 133702 - "Guess we can earn it back later"
    new() { Offset = 0x1370, Value = 0x4e76a420 }, // 133703 - "Spending spree!"
    // Gamble
    new() { Offset = 0x1378, Value = 0x4e96aa20 }, // 133801 - "It's all or nothing!"
    new() { Offset = 0x1380, Value = 0x4ea6aa20 }, // 133802 - "Take a chance!"
    new() { Offset = 0x1388, Value = 0x4eb6aa20 }, // 133803 - "I can hardly look!"
    // Tantalize?
    new() { Offset = 0x1398, Value = 0x4ed6b020 }, // 133901 - "Fall under my spell"
    new() { Offset = 0x13A0, Value = 0x4ee6b020 }, // 133902 - "Hope this works"
    new() { Offset = 0x13A8, Value = 0x4ef6b020 }, // 133903 - "Oh, please, please, please!"
    // Pre-Sing
    new() { Offset = 0x13B0, Value = 0x4e16b720 }, // 134001 - "Listen up!"
    new() { Offset = 0x13B8, Value = 0x4e26b720 }, // 134002 - "Wanna sing along?"
    new() { Offset = 0x13C0, Value = 0x4e36b720 }, // 134003 - "May as well let loose"
    // Sing
    new() { Offset = 0x1180, Value = 0x4ed6b720 }, // 134013
    new() { Offset = 0x1188, Value = 0x4ee6b720 }, // 134014
    // Dance
    new() { Offset = 0x13C8, Value = 0x4e56bd20 }, // 134101 - "Hey! Eyes on me!"
    new() { Offset = 0x13D0, Value = 0x4e66bd20 }, // 134102 - "Let's get moving!"
    new() { Offset = 0x13D8, Value = 0x4e76bd20 }, // 134103 - "This is a little embarassing"
    // Kogoro
    new() { Offset = 0x13E0, Value = 0x4e96c320 }, // 134201 - "Time for something meatier"
    new() { Offset = 0x13E8, Value = 0x4ea6c320 }, // 134202 - "Wanna bite?"
    new() { Offset = 0x13F0, Value = 0x4eb6c320 }, // 134203 - "It's a dog eat you world"
    // Kogoro?
    new() { Offset = 0x13F8, Value = 0x4ee6c920 }, // 134302 - "Fetch!"
    // Pound!
    new() { Offset = 0x1400, Value = 0x4e16d020 }, // 134401 - "The more the merrier!"
    new() { Offset = 0x1408, Value = 0x4e26d020 }, // 134402 - "Release the hounds!"
    new() { Offset = 0x1410, Value = 0x4e36d020 }, // 134403 - "Pound away!"
    // Great Whirl
    new() { Offset = 0x1418, Value = 0x4e56d620 }, // 134501 - "She loves you not!"
    new() { Offset = 0x1420, Value = 0x4e66d620 }, // 134502 - "Flower power!"
    new() { Offset = 0x1428, Value = 0x4e76d620 }, // 134503 - "My pistils are loaded!"
    // Auto-Life?
    new() { Offset = 0x1430, Value = 0x4e96dc20 }, // 134601 - "A salvation promised!"
    new() { Offset = 0x1438, Value = 0x4ea6dc20 }, // 134602 - "Better safe than sorry!"
    new() { Offset = 0x1440, Value = 0x4eb6dc20 }, // 134603 - "Can't be too carefule"
    // Flare
    new() { Offset = 0x1448, Value = 0x4ed6e220 }, // 134701 - "Hope you're ready for a heat wave!"
    new() { Offset = 0x1450, Value = 0x4ee6e220 }, // 134702 - "There's no escape!"
    new() { Offset = 0x1458, Value = 0x4ef6e220 }, // 134703 - "Magical meltdown!"
    // Holy
    new() { Offset = 0x1460, Value = 0x4e16e920 }, // 134801 - "Light our way!"
    new() { Offset = 0x1468, Value = 0x4e26e920 }, // 134802 - "My prayers are our strength!"
    new() { Offset = 0x1470, Value = 0x4e36e920 }, // 134803 - "Vanquish the darkness!"
    // Ultima
    new() { Offset = 0x1478, Value = 0x4e56ef20 }, // 134901 - "Do you know why they call it Ultima?"
    new() { Offset = 0x1480, Value = 0x4e66ef20 }, // 134902 - "Enough!"
    new() { Offset = 0x1488, Value = 0x4e76ef20 }, // 134903 - "Storm of darkness, vanquish all!"
    // Into Psychic
    new() { Offset = 0xFA8, Value = 0x4ed6fb20 }, // 135101 - "Pure energy! A power beyond all human knowledge"
    new() { Offset = 0x1120, Value = 0x4ee6fb20 }, // 135102 - "Feel the power of the mind!"
    new() { Offset = 0x1128, Value = 0x4ef6fb20 }, // 135103 - "I can sense my powers growing"
    new() { Offset = 0x1130, Value = 0x4e06fc20 }, // 135104 - "I can't hold it back any longer!"
    // Time Trip
    new() { Offset = 0x1490, Value = 0x4e160221 }, // 135201 - "Flow of time, heed my call!"
    new() { Offset = 0x1498, Value = 0x4e260221 }, // 135202 - "Nobody move!"
    new() { Offset = 0x14A0, Value = 0x4e360221 }, // 135203 - "Hang on just a sec!"
    // Psychic
    new() { Offset = 0x14A8, Value = 0x4e560821 }, // 135301 - "My body withers that my mind may prevail!"
    new() { Offset = 0x14B0, Value = 0x4e660821 }, // 135302 - "Let's settle this, my way!"
    new() { Offset = 0x14B8, Value = 0x4e760821 }, // 135303 - "I am power!"
    // Into Festivalist
    new() { Offset = 0xFB0, Value = 0x4e960e21 }, // 135401 - "Let's leave our worries behind and have us some fun!"
    new() { Offset = 0x1138, Value = 0x4ea60e21 }, // 135402 - "Smells like party time to me!"
    new() { Offset = 0x1140, Value = 0x4eb60e21 }, // 135403 - "No reason we can't have fun along the way!"
    new() { Offset = 0x1148, Value = 0x4ec60e21 }, // 135404 - "This hardly feels like fighting at all!"
    // Festivities (Not Twinkler)
    new() { Offset = 0x14E0, Value = 0x4ed61421 }, // 135501 - "Here I go!"
    new() { Offset = 0x14E8, Value = 0x4ee61421 }, // 135502 - "Let's party!"
    new() { Offset = 0x2238, Value = 0x4ef61421 }, // 135503 - "It's party time, anything goes!"
    new() { Offset = 0x14C0, Value = 0x4e161b21 }, // 135601 - "This is fun!"
    new() { Offset = 0x14C8, Value = 0x4e261b21 }, // 135602 - "Here comes a big one!"
    new() { Offset = 0x14D0, Value = 0x4e361b21 }, // 135603 - "This one's for you!"
    new() { Offset = 0x14D8, Value = 0x4e461b21 }, // 135604 - "Don't want to miss this one!"
    // Dice
    new() { Offset = 0x1390, Value = 0x4e762121 }, // 135703 - "So what've we got this time?"
    // Japanese line
    new() { Offset = 0x2268, Value = 0x4ee62121 }, // 135710
    new() { Offset = 0x2260, Value = 0x4ef62121 }, // 135711
    new() { Offset = 0x1218, Value = 0x4e062221 }, // 135712
    new() { Offset = 0x1220, Value = 0x4e162221 }, // 135713
    // Battle over
    new() { Offset = 0x26F4, Value = 0x4e563422 }, // 140101 - "Take that!"
    new() { Offset = 0x26FC, Value = 0x4e663422 }, // 140102 - "I'm ready for more"
    new() { Offset = 0x2704, Value = 0x4e763422 }, // 140103 - "I could get used to this!"
    new() { Offset = 0x270C, Value = 0x4e863422 }, // 140104 - "Nice work!"
    // Battle over (low health)
    new() { Offset = 0x2754, Value = 0x4e164722 }, // 140401 - "That was a close call!"
    new() { Offset = 0x275C, Value = 0x4e264722 }, // 140402 - "I thought we were goners!"
    new() { Offset = 0x2764, Value = 0x4e364722 }, // 140403 - "Phew!"
    new() { Offset = 0x276C, Value = 0x4e464722 }, // 140404 - "That was close!"
    // Battle over (Rikku low)
    new() { Offset = 0x27D4, Value = 0x4e065a22 }, // 140704 - "Rikku, you don't look so good! / Yeah, break time!"
    new() { Offset = 0x27DC, Value = 0x4e165a22 }, // 140705 - "Uh close call! / Hey, at least we won"
    new() { Offset = 0x27E4, Value = 0x4e265a22 }, // 140706 - "That got pretty ugly! Tell me something I don't know"
    // Battle over (Yuna low/Paine high?)
    new() { Offset = 0x283C, Value = 0x4e966622 }, // 140905 - "Hm / don't let your guard down"
    new() { Offset = 0x2844, Value = 0x4ea66622 }, // 140906 - "We's be lost without you Paine / Why thank you"
    // Game over
    new() { Offset = 0x24C0, Value = 0x4e966c22 }, // 141001 - "N, no"
    new() { Offset = 0x24C8, Value = 0x4ea66c22 }, // 141002 - "Why..."
    new() { Offset = 0x24D0, Value = 0x4eb66c22 }, // 141003 - "This is all wrong"
    new() { Offset = 0x24D8, Value = 0x4ec66c22 }, // 141004 - "Somebody, anybody?"
    // Battle win
    new() { Offset = 0x26DC, Value = 0x4e569822 }, // 141701 - "We won! / An empty win"
    new() { Offset = 0x26E4, Value = 0x4e669822 }, // 141702 - "Duck soup! / Duck what?"
    new() { Offset = 0x2624, Value = 0x4ea69e22 }, // 141802 - "All right!"
    new() { Offset = 0x2628, Value = 0x4ec69e22 }, // 141804 - "Signed and sealed!"
    new() { Offset = 0x2614, Value = 0x4ed69e22 }, // 141805 - "No problem!"
    new() { Offset = 0x2618, Value = 0x4ee69e22 }, // 141806 - "Too easy!"
    new() { Offset = 0x261C, Value = 0x4ef69e22 }, // 141807 - "That's it?"
    new() { Offset = 0x2620, Value = 0x4e069f22 }, // 141808 - "So, what's next?"
    // Trainer win
    new() { Offset = 0x262C, Value = 0x4e16dd22 }, // 142801 - "Have a biscuit boy"
    new() { Offset = 0x2630, Value = 0x4e26dd22 }, // 142802 - "Good boy!"
    new() { Offset = 0x2634, Value = 0x4e36dd22 }, // 142803 - "Good doggy!"
    // Battle win
    new() { Offset = 0x2638, Value = 0x4ed6ef22 }, // 143101 - "Never underestimate Yuna"
    new() { Offset = 0x263C, Value = 0x4ee6ef22 }, // 143102 - "Stronger than you thought, huh?"
    new() { Offset = 0x2640, Value = 0x4ef6ef22 }, // 143103 - "Well?"
    // Battle over (Lady Luck)
    new() { Offset = 0x2644, Value = 0x4e16f622 }, // 143201 - "I guess it was the luck of the draw"
    new() { Offset = 0x2648, Value = 0x4e26f622 }, // 143202 - "Game over man! Game over!"
    new() { Offset = 0x264C, Value = 0x4e36f622 }, // 143203 - "Thanks for playing!"
    // Battle start
    new() { Offset = 0x223C, Value = 0x4e56bc35 }, // 220101
    new() { Offset = 0x2244, Value = 0x4e66bc35 }, // 220102
    new() { Offset = 0x224C, Value = 0x4e76bc35 }, // 220103
    new() { Offset = 0x2254, Value = 0x4e86bc35 }, // 220104
    // Battle start (Low health)
    new() { Offset = 0x236C, Value = 0x4ed6fa35 }, // 221101
    new() { Offset = 0x2374, Value = 0x4ee6fa35 }, // 221102
    new() { Offset = 0x237C, Value = 0x4ef6fa35 }, // 221103
    new() { Offset = 0x2384, Value = 0x4e06fb35 }, // 221104
    // Battle start
    new() { Offset = 0x22B4, Value = 0x4e263336 }, // 222002
    new() { Offset = 0x22D4, Value = 0x4e663336 }, // 222006
    new() { Offset = 0x230C, Value = 0x4e963f36 }, // 222201
    new() { Offset = 0x231C, Value = 0x4eb63f36 }, // 222203
    new() { Offset = 0x2324, Value = 0x4ec63f36 }, // 222204
    new() { Offset = 0x234C, Value = 0x4e364c36 }, // 222403
    new() { Offset = 0x2364, Value = 0x4e664c36 }, // 222406
    // Trouble (LM?)
    new() { Offset = 0x246C, Value = 0x4e765236 }, // 222503
    new() { Offset = 0x2474, Value = 0x4e865236 }, // 222504
    // LM?
    new() { Offset = 0x23CC, Value = 0x4e566b36 }, // 222901
    new() { Offset = 0x23D4, Value = 0x4e666b36 }, // 222902
    new() { Offset = 0x23DC, Value = 0x4e766b36 }, // 222903
    new() { Offset = 0x2444, Value = 0x4ec67136 }, // 223004
    new() { Offset = 0x244C, Value = 0x4ed67136 }, // 223005
    new() { Offset = 0x2454, Value = 0x4ee67136 }, // 223006
    // Into Gunner
    new() { Offset = 0xFB4, Value = 0x4e963338 }, // 230201
    new() { Offset = 0xFBC, Value = 0x4ea63338 }, // 230202
    new() { Offset = 0xFC4, Value = 0x4eb63338 }, // 230203
    // Into Gun Mage
    new() { Offset = 0xF34, Value = 0x4ed63938 }, // 230301
    new() { Offset = 0xFCC, Value = 0x4ee63938 }, // 230302
    new() { Offset = 0xFD4, Value = 0x4ef63938 }, // 230303
    new() { Offset = 0xFDC, Value = 0x4e063a38 }, // 230304
    // Into Alchemist
    new() { Offset = 0xF3C, Value = 0x4e164038 }, // 230401
    new() { Offset = 0xFE4, Value = 0x4e264038 }, // 230402
    new() { Offset = 0xFEC, Value = 0x4e364038 }, // 230403
    new() { Offset = 0xFF4, Value = 0x4e464038 }, // 230404
    // Into Thief
    new() { Offset = 0xF44, Value = 0x4e564638 }, // 230501
    new() { Offset = 0xFFC, Value = 0x4e664638 }, // 230502
    new() { Offset = 0x1004, Value = 0x4e764638 }, // 230503
    new() { Offset = 0x100C, Value = 0x4e864638 }, // 230504
    // Into Trainer
    new() { Offset = 0xF4C, Value = 0x4e964c38 }, // 230601
    new() { Offset = 0x1014, Value = 0x4ea64c38 }, // 230602
    new() { Offset = 0x101C, Value = 0x4eb64c38 }, // 230603
    new() { Offset = 0x1024, Value = 0x4ec64c38 }, // 230604
    // Into Warrior
    new() { Offset = 0xF5C, Value = 0x4ed65238 }, // 230701
    new() { Offset = 0x1044, Value = 0x4ee65238 }, // 230702
    new() { Offset = 0x104C, Value = 0x4ef65238 }, // 230703
    new() { Offset = 0x1054, Value = 0x4e065338 }, // 230704
    // Into Samurai
    new() { Offset = 0xF64, Value = 0x4e165938 }, // 230801
    new() { Offset = 0x105C, Value = 0x4e265938 }, // 230802
    new() { Offset = 0x1064, Value = 0x4e365938 }, // 230803
    new() { Offset = 0x106C, Value = 0x4e465938 }, // 230804
    // Into Dark Knight
    new() { Offset = 0xF6C, Value = 0x4e565f38 }, // 230901
    new() { Offset = 0x1074, Value = 0x4e665f38 }, // 230902
    new() { Offset = 0x107C, Value = 0x4e765f38 }, // 230903
    new() { Offset = 0x1084, Value = 0x4e865f38 }, // 230904
    // Into Berserker
    new() { Offset = 0xF74, Value = 0x4e966538 }, // 231001
    new() { Offset = 0x108C, Value = 0x4ea66538 }, // 231002
    new() { Offset = 0x1094, Value = 0x4eb66538 }, // 231003
    new() { Offset = 0x109C, Value = 0x4ec66538 }, // 231004
    // Into Songstress
    new() { Offset = 0xF7C, Value = 0x4ed66b38 }, // 231101
    new() { Offset = 0x10A4, Value = 0x4ee66b38 }, // 231102
    new() { Offset = 0x10AC, Value = 0x4ef66b38 }, // 231103
    new() { Offset = 0x10B4, Value = 0x4e066c38 }, // 231104
    // Into Black Mage
    new() { Offset = 0xF84, Value = 0x4e167238 }, // 231201
    new() { Offset = 0x10BC, Value = 0x4e267238 }, // 231202
    new() { Offset = 0x10C4, Value = 0x4e367238 }, // 231203
    new() { Offset = 0x10CC, Value = 0x4e467238 }, // 231204
    // Into White Mage
    new() { Offset = 0xF8C, Value = 0x4e567838 }, // 231301
    new() { Offset = 0x10D4, Value = 0x4e667838 }, // 231302
    new() { Offset = 0x10DC, Value = 0x4e767838 }, // 231303
    new() { Offset = 0x10E4, Value = 0x4e867838 }, // 231304
    // Into Lady Luck
    new() { Offset = 0xF94, Value = 0x4e967e38 }, // 231401
    new() { Offset = 0x10EC, Value = 0x4ea67e38 }, // 231402
    new() { Offset = 0x10F4, Value = 0x4eb67e38 }, // 231403
    new() { Offset = 0x10FC, Value = 0x4ec67e38 }, // 231404
    // Into Mascot
    new() { Offset = 0xF54, Value = 0x4ed68438 }, // 231501
    new() { Offset = 0x102C, Value = 0x4ee68438 }, // 231502
    new() { Offset = 0x1034, Value = 0x4ef68438 }, // 231503
    new() { Offset = 0x103C, Value = 0x4e068538 }, // 231504
    // (no purpose listed)
    new() { Offset = 0xF9C, Value = 0x4e168b38 }, // 231601 - "A power too great to be bridled can only be set free"
    new() { Offset = 0x1104, Value = 0x4e268b38 }, // 231602
    new() { Offset = 0x110C, Value = 0x4e368b38 }, // 231603
    new() { Offset = 0x1114, Value = 0x4e468b38 }, // 231604 - "It's too late for regrets"
    new() { Offset = 0x118C, Value = 0x4e569138 }, // 231701 - "This'll help"
    new() { Offset = 0x12C4, Value = 0x4e669138 }, // 231702 - "Hang in there"
    new() { Offset = 0x119C, Value = 0x4e769138 }, // 231703 - "You OK?"
    new() { Offset = 0x11A4, Value = 0x4e869138 }, // 231704 - "Be strong!"
    new() { Offset = 0x11AC, Value = 0x4e969138 }, // 231705 - "I've got you!"
    new() { Offset = 0x11B4, Value = 0x4e969738 }, // 231801 - "Come on!"
    new() { Offset = 0x11BC, Value = 0x4ea69738 }, // 231802 - "Any better?"
    new() { Offset = 0x11C4, Value = 0x4eb69738 }, // 231803 - "Let's play it safe."
    new() { Offset = 0x11CC, Value = 0x4ed69d38 }, // 231901 - "Sorry!"
    new() { Offset = 0x11D4, Value = 0x4ee69d38 }, // 231902 - "Try this on for size!"
    new() { Offset = 0x11DC, Value = 0x4ef69d38 }, // 231903 - "Behave yourself"
    new() { Offset = 0x11E4, Value = 0x4e16a438 }, // 232001 - "You're mine!"
    new() { Offset = 0x11EC, Value = 0x4e26a438 }, // 232002 - "Time to act"
    new() { Offset = 0x11F4, Value = 0x4e36a438 }, // 232003 - "This'll do it!"
    new() { Offset = 0x11FC, Value = 0x4e46a438 }, // 232004 - "Here goes"
    new() { Offset = 0x1204, Value = 0x4e56a438 }, // 232005 - "I've got it"
    new() { Offset = 0x120C, Value = 0x4e66a438 }, // 232006 - "That's enough from you!"
    // Eject
    new() { Offset = 0x1224, Value = 0x4e56aa38 }, // 232101
    new() { Offset = 0x122C, Value = 0x4e66aa38 }, // 232102
    new() { Offset = 0x1234, Value = 0x4e76aa38 }, // 232103
    // Scan
    new() { Offset = 0x123C, Value = 0x4e96b038 }, // 232201
    new() { Offset = 0x1244, Value = 0x4ea6b038 }, // 232202
    new() { Offset = 0x124C, Value = 0x4eb6b038 }, // 232203
    // Fire magic
    new() { Offset = 0x1254, Value = 0x4ed6b638 }, // 232301
    new() { Offset = 0x125C, Value = 0x4ee6b638 }, // 232302
    new() { Offset = 0x1264, Value = 0x4ef6b638 }, // 232303
    // Ice magic
    new() { Offset = 0x126C, Value = 0x4e16bd38 }, // 232401
    new() { Offset = 0x1274, Value = 0x4e26bd38 }, // 232402
    new() { Offset = 0x127C, Value = 0x4e36bd38 }, // 232403
    // Water magic
    new() { Offset = 0x1284, Value = 0x4e56c338 }, // 232501
    new() { Offset = 0x128C, Value = 0x4e66c338 }, // 232502
    new() { Offset = 0x1294, Value = 0x4e76c338 }, // 232503
    // Thunder magic
    new() { Offset = 0x129C, Value = 0x4e96c938 }, // 232601
    new() { Offset = 0x12A4, Value = 0x4ea6c938 }, // 232602
    new() { Offset = 0x12AC, Value = 0x4eb6c938 }, // 232603
    // (no purpose listed)
    new() { Offset = 0x12B4, Value = 0x4ed6cf38 }, // 232701 - "All shall be restored"
    new() { Offset = 0x12BC, Value = 0x4ee6cf38 }, // 232702 - "It's not over"
    new() { Offset = 0x1194, Value = 0x4ef6cf38 }, // 232703 - "Everyone, stay strong"
    // Steal
    new() { Offset = 0x114C, Value = 0x4e16d638 }, // 232801
    new() { Offset = 0x1154, Value = 0x4e26d638 }, // 232802
    new() { Offset = 0x115C, Value = 0x4e36d638 }, // 232803
    // (no purpose listed)
    new() { Offset = 0x1164, Value = 0x4e56dc38 }, // 232901 - "Got anything I need?"
    new() { Offset = 0x116C, Value = 0x4e66dc38 }, // 232902 - "Hope you don't mind"
    new() { Offset = 0x1174, Value = 0x4e76dc38 }, // 232903 - "You're an easy target"
    // Mix
    new() { Offset = 0x14EC, Value = 0x4e96e238 }, // 233001
    new() { Offset = 0x14F4, Value = 0x4ea6e238 }, // 233002
    new() { Offset = 0x14FC, Value = 0x4eb6e238 }, // 233003
    // Stash
    new() { Offset = 0x12CC, Value = 0x4ed6e838 }, // 233101
    new() { Offset = 0x12D4, Value = 0x4ee6e838 }, // 233102
    new() { Offset = 0x12DC, Value = 0x4ef6e838 }, // 233103
    // Blue Bullet
    new() { Offset = 0x12E4, Value = 0x4e16ef38 }, // 233201
    new() { Offset = 0x12EC, Value = 0x4e26ef38 }, // 233202
    new() { Offset = 0x12F4, Value = 0x4e36ef38 }, // 233203
    // Fiend Hunter
    new() { Offset = 0x12FC, Value = 0x4e56f538 }, // 233301
    new() { Offset = 0x1304, Value = 0x4e66f538 }, // 233302
    new() { Offset = 0x130C, Value = 0x4e76f538 }, // 233303
    // Berserk
    new() { Offset = 0x1314, Value = 0x4e96fb38 }, // 233401
    new() { Offset = 0x131C, Value = 0x4ea6fb38 }, // 233402
    new() { Offset = 0x1324, Value = 0x4eb6fb38 }, // 233403
    // Darkness
    new() { Offset = 0x132C, Value = 0x4ed60139 }, // 233501
    new() { Offset = 0x1334, Value = 0x4ee60139 }, // 233502
    new() { Offset = 0x133C, Value = 0x4ef60139 }, // 233503
    // Zantetsu
    new() { Offset = 0x1344, Value = 0x4e160839 }, // 233601
    new() { Offset = 0x134C, Value = 0x4e260839 }, // 233602
    new() { Offset = 0x1354, Value = 0x4e360839 }, // 233603
    // Spare Change
    new() { Offset = 0x135C, Value = 0x4e560e39 }, // 233701
    new() { Offset = 0x1364, Value = 0x4e660e39 }, // 233702
    new() { Offset = 0x136C, Value = 0x4e760e39 }, // 233703
    // Gamble
    new() { Offset = 0x1374, Value = 0x4e961439 }, // 233801
    new() { Offset = 0x137C, Value = 0x4ea61439 }, // 233802
    new() { Offset = 0x1384, Value = 0x4eb61439 }, // 233803
    // Tantalize?
    new() { Offset = 0x1394, Value = 0x4ed61a39 }, // 233901
    new() { Offset = 0x139C, Value = 0x4ee61a39 }, // 233902
    new() { Offset = 0x13A4, Value = 0x4ef61a39 }, // 233903
    // Pre-Sing
    new() { Offset = 0x13AC, Value = 0x4e162139 }, // 234001
    new() { Offset = 0x13B4, Value = 0x4e262139 }, // 234002
    new() { Offset = 0x13BC, Value = 0x4e362139 }, // 234003
    // Sing
    new() { Offset = 0x117C, Value = 0x4ed62139 }, // 234013
    new() { Offset = 0x1184, Value = 0x4ee62139 }, // 234014
    // Dance
    new() { Offset = 0x13C4, Value = 0x4e562739 }, // 234101
    new() { Offset = 0x13CC, Value = 0x4e662739 }, // 234102
    new() { Offset = 0x13D4, Value = 0x4e762739 }, // 234103
    // (no purpose listed)
    new() { Offset = 0x13DC, Value = 0x4e962d39 }, // 234201 - "Time for something meatier"
    new() { Offset = 0x13E4, Value = 0x4ea62d39 }, // 234202 - "Wanna bite?"
    new() { Offset = 0x13EC, Value = 0x4eb62d39 }, // 234203 - "It's a dog eat you world"
    new() { Offset = 0x13F4, Value = 0x4ee63339 }, // 234302 - "Fetch!"
    // Pound!
    new() { Offset = 0x13FC, Value = 0x4e163a39 }, // 234401
    new() { Offset = 0x1404, Value = 0x4e263a39 }, // 234402
    new() { Offset = 0x140C, Value = 0x4e363a39 }, // 234403
    // Great Whirl
    new() { Offset = 0x1414, Value = 0x4e564039 }, // 234501
    new() { Offset = 0x141C, Value = 0x4e664039 }, // 234502
    new() { Offset = 0x1424, Value = 0x4e764039 }, // 234503
    // Auto-Life?
    new() { Offset = 0x142C, Value = 0x4e964639 }, // 234601
    new() { Offset = 0x1434, Value = 0x4ea64639 }, // 234602
    new() { Offset = 0x143C, Value = 0x4eb64639 }, // 234603
    // Flare
    new() { Offset = 0x1444, Value = 0x4ed64c39 }, // 234701
    new() { Offset = 0x144C, Value = 0x4ee64c39 }, // 234702
    new() { Offset = 0x1454, Value = 0x4ef64c39 }, // 234703
    // Holy
    new() { Offset = 0x145C, Value = 0x4e165339 }, // 234801
    new() { Offset = 0x1464, Value = 0x4e265339 }, // 234802
    new() { Offset = 0x146C, Value = 0x4e365339 }, // 234803
    // Ultima
    new() { Offset = 0x1474, Value = 0x4e565939 }, // 234901
    new() { Offset = 0x147C, Value = 0x4e665939 }, // 234902
    new() { Offset = 0x1484, Value = 0x4e765939 }, // 234903
    // Into Psychic
    new() { Offset = 0xFA4, Value = 0x4ed66539 }, // 235101
    new() { Offset = 0x111C, Value = 0x4ee66539 }, // 235102
    new() { Offset = 0x1124, Value = 0x4ef66539 }, // 235103
    new() { Offset = 0x112C, Value = 0x4e066639 }, // 235104
    // Time-trip?
    new() { Offset = 0x148C, Value = 0x4e166c39 }, // 235201
    new() { Offset = 0x1494, Value = 0x4e266c39 }, // 235202
    new() { Offset = 0x149C, Value = 0x4e366c39 }, // 235203
    // Psionics?
    new() { Offset = 0x14A4, Value = 0x4e567239 }, // 235301
    new() { Offset = 0x14AC, Value = 0x4e667239 }, // 235302
    new() { Offset = 0x14B4, Value = 0x4e767239 }, // 235303
    // Into Festivalist
    new() { Offset = 0xFAC, Value = 0x4e967839 }, // 235401 - "Let's leave our worries behind and have us some fun!"
    new() { Offset = 0x1134, Value = 0x4ea67839 }, // 235402 - "Smells like party time to me!"
    new() { Offset = 0x113C, Value = 0x4eb67839 }, // 235403 - "No reason we can't have fun along the way!"
    new() { Offset = 0x1144, Value = 0x4ec67839 }, // 235404 - "This hardly feels like fighting at all!"
    // Festivities (Not Twinkler)
    new() { Offset = 0x14DC, Value = 0x4ed67e39 }, // 235501 - "Here I go!"
    new() { Offset = 0x14E4, Value = 0x4ee67e39 }, // 235502 - "Let's party!"
    new() { Offset = 0x2234, Value = 0x4ef67e39 }, // 235503 - "It's party time, anything goes!"
    new() { Offset = 0x14BC, Value = 0x4e168539 }, // 235601 - "This is fun!"
    new() { Offset = 0x14C4, Value = 0x4e268539 }, // 235602 - "Here comes a big one!"
    new() { Offset = 0x14CC, Value = 0x4e368539 }, // 235603 - "This one's for you!"
    new() { Offset = 0x14D4, Value = 0x4e468539 }, // 235604 - "Don't want to miss this one!"
    // Dice
    new() { Offset = 0x138C, Value = 0x4e768b39 }, // 235703 - "So, what have we got this time?"
    // Japanese line
    new() { Offset = 0x2264, Value = 0x4ee68b39 }, // 235710
    new() { Offset = 0x225C, Value = 0x4ef68b39 }, // 235711
    new() { Offset = 0x1214, Value = 0x4e068c39 }, // 235712
    new() { Offset = 0x121C, Value = 0x4e168c39 }, // 235713
    // Battle over
    new() { Offset = 0x26F0, Value = 0x4e569e3a }, // 240101
    new() { Offset = 0x26F8, Value = 0x4e669e3a }, // 240102
    new() { Offset = 0x2700, Value = 0x4e769e3a }, // 240103
    new() { Offset = 0x2708, Value = 0x4e869e3a }, // 240104
    // Battle over (Low health)
    new() { Offset = 0x2750, Value = 0x4e16b13a }, // 240401
    new() { Offset = 0x2758, Value = 0x4e26b13a }, // 240402
    new() { Offset = 0x2760, Value = 0x4e36b13a }, // 240403
    new() { Offset = 0x2768, Value = 0x4e46b13a }, // 240404
    // Battle over (Rikku low)
    new() { Offset = 0x27D0, Value = 0x4e06c43a }, // 240704
    new() { Offset = 0x27D8, Value = 0x4e16c43a }, // 240705
    new() { Offset = 0x27E0, Value = 0x4e26c43a }, // 240706
    // Battle over (Yuna low, Paine high?)
    new() { Offset = 0x2838, Value = 0x4e96d03a }, // 240905
    new() { Offset = 0x2840, Value = 0x4ea6d03a }, // 240906
    // Game over
    new() { Offset = 0x24BC, Value = 0x4e96d63a }, // 241001
    new() { Offset = 0x24C4, Value = 0x4ea6d63a }, // 241002
    new() { Offset = 0x24CC, Value = 0x4eb6d63a }, // 241003
    new() { Offset = 0x24D4, Value = 0x4ec6d63a }, // 241004
    // Battle over
    new() { Offset = 0x26D8, Value = 0x4e56023b }, // 241701
    // Battle over (Duck soup)
    new() { Offset = 0x26E0, Value = 0x4e66023b }, // 241702
];

    public static readonly MemoryWrite[] VanillaVL_rk = // Rikku
[
    // Battle start
    new() { Offset = 0x2270, Value = 0x8b94581d }, // 120201
    new() { Offset = 0x2278, Value = 0x8ba4581d }, // 120202
    new() { Offset = 0x2280, Value = 0x8bb4581d }, // 120203
    new() { Offset = 0x2288, Value = 0x8bc4581d }, // 120204
    // Battle start (low health?) (LM?)
    new() { Offset = 0x2390, Value = 0x8b14971d }, // 121201
    new() { Offset = 0x2398, Value = 0x8b24971d }, // 121202
    new() { Offset = 0x23A0, Value = 0x8b34971d }, // 121203
    new() { Offset = 0x23A8, Value = 0x8b44971d }, // 121204
    // Battle start
    new() { Offset = 0x22B0, Value = 0x8b14c91d }, // 122001 - "Time to clean up! / Right behind ya"
    new() { Offset = 0x22C0, Value = 0x8b34c91d }, // 122003
    new() { Offset = 0x22C8, Value = 0x8b44c91d }, // 122004
    new() { Offset = 0x22D0, Value = 0x8b54c91d }, // 122005
    new() { Offset = 0x22E0, Value = 0x8b54cf1d }, // 122101
    new() { Offset = 0x22E8, Value = 0x8b64cf1d }, // 122102
    new() { Offset = 0x22F0, Value = 0x8b74cf1d }, // 122103
    new() { Offset = 0x2300, Value = 0x8b94cf1d }, // 122105
    new() { Offset = 0x2308, Value = 0x8ba4cf1d }, // 122106
    // (no purpose listed)
    new() { Offset = 0x2400, Value = 0x8bd4db1d }, // 122301
    new() { Offset = 0x2408, Value = 0x8be4db1d }, // 122302
    new() { Offset = 0x2410, Value = 0x8bf4db1d }, // 122303
    new() { Offset = 0x2340, Value = 0x8b14e21d }, // 122401
    new() { Offset = 0x2348, Value = 0x8b24e21d }, // 122402
    // LM In trouble?
    new() { Offset = 0x2460, Value = 0x8b54e81d }, // 122501
    new() { Offset = 0x2468, Value = 0x8b64e81d }, // 122502
    // Battle start - Luca Prologue, 1st goon fight
    new() { Offset = 0x2120, Value = 0x8bd4f41d }, // 122701 - "Outta the way!"
    // Battle start - Luca Prologue, goon fight
    new() { Offset = 0x2128, Value = 0x8bf4f41d }, // 122703 - "You, step aside"
    // (no purpose listed)
    new() { Offset = 0x2134, Value = 0x8b24f51d }, // 122706 - "Let's take this one apart!"
    new() { Offset = 0x213C, Value = 0x8b44f51d }, // 122708 - "Snake? Snake!?!"
    new() { Offset = 0x215C, Value = 0x8bc4f51d }, // 122716 - "Why?"
    new() { Offset = 0x2160, Value = 0x8bd4f51d }, // 122717 - "This can't be happening"
    new() { Offset = 0x2188, Value = 0x8b54fb1d }, // 122805 - "You just don't get it do you?"
    // LM?
    new() { Offset = 0x23E8, Value = 0x8b84011e }, // 122904
    new() { Offset = 0x23F0, Value = 0x8b94011e }, // 122905
    new() { Offset = 0x23F8, Value = 0x8ba4011e }, // 122906
    // Into Gunner
    new() { Offset = 0x1508, Value = 0x8bc4c91f }, // 130204
    new() { Offset = 0x1588, Value = 0x8bd4c91f }, // 130205
    new() { Offset = 0x1590, Value = 0x8be4c91f }, // 130206
    new() { Offset = 0x1598, Value = 0x8bf4c91f }, // 130207
    // Into Gun Mage
    new() { Offset = 0x1510, Value = 0x8b14d01f }, // 130305
    new() { Offset = 0x15A0, Value = 0x8b24d01f }, // 130306
    new() { Offset = 0x15A8, Value = 0x8b34d01f }, // 130307
    new() { Offset = 0x15B0, Value = 0x8b44d01f }, // 130308
    // Into Alchemist
    new() { Offset = 0x1518, Value = 0x8b54d61f }, // 130405
    new() { Offset = 0x15B8, Value = 0x8b64d61f }, // 130406
    new() { Offset = 0x15C0, Value = 0x8b74d61f }, // 130407
    new() { Offset = 0x15C8, Value = 0x8b84d61f }, // 130408
    // Into Thief
    new() { Offset = 0x15D0, Value = 0x8b94dc1f }, // 130505
    new() { Offset = 0x15D8, Value = 0x8ba4dc1f }, // 130506
    new() { Offset = 0x15E0, Value = 0x8bb4dc1f }, // 130507
    // Into Trainer
    new() { Offset = 0x1520, Value = 0x8bd4e21f }, // 130605
    new() { Offset = 0x15E8, Value = 0x8be4e21f }, // 130606
    new() { Offset = 0x15F0, Value = 0x8bf4e21f }, // 130607
    new() { Offset = 0x15F8, Value = 0x8b04e31f }, // 130608
    // Into Warrior
    new() { Offset = 0x1530, Value = 0x8b14e91f }, // 130705
    new() { Offset = 0x1618, Value = 0x8b24e91f }, // 130706
    new() { Offset = 0x1620, Value = 0x8b34e91f }, // 130707
    new() { Offset = 0x1628, Value = 0x8b44e91f }, // 130708
    // Into Samurai
    new() { Offset = 0x1538, Value = 0x8b54ef1f }, // 130805
    new() { Offset = 0x1630, Value = 0x8b64ef1f }, // 130806
    new() { Offset = 0x1638, Value = 0x8b74ef1f }, // 130807
    new() { Offset = 0x1640, Value = 0x8b84ef1f }, // 130808
    // Into Dark Knight
    new() { Offset = 0x1540, Value = 0x8b94f51f }, // 130905
    new() { Offset = 0x1648, Value = 0x8ba4f51f }, // 130906
    new() { Offset = 0x1650, Value = 0x8bb4f51f }, // 130907
    new() { Offset = 0x1658, Value = 0x8bc4f51f }, // 130908
    // Into Berserker
    new() { Offset = 0x1548, Value = 0x8bd4fb1f }, // 131005
    new() { Offset = 0x1660, Value = 0x8be4fb1f }, // 131006
    new() { Offset = 0x1668, Value = 0x8bf4fb1f }, // 131007
    new() { Offset = 0x1670, Value = 0x8b04fc1f }, // 131008
    // Into Songstress
    new() { Offset = 0x1550, Value = 0x8b140220 }, // 131105
    new() { Offset = 0x1678, Value = 0x8b240220 }, // 131106
    new() { Offset = 0x1680, Value = 0x8b340220 }, // 131107
    new() { Offset = 0x1688, Value = 0x8b440220 }, // 131108
    // Into Black Mage
    new() { Offset = 0x1558, Value = 0x8b540820 }, // 131205
    new() { Offset = 0x1690, Value = 0x8b640820 }, // 131206
    new() { Offset = 0x1698, Value = 0x8b740820 }, // 131207
    new() { Offset = 0x16A0, Value = 0x8b840820 }, // 131208
    // Into White Mage
    new() { Offset = 0x1560, Value = 0x8b940e20 }, // 131305
    new() { Offset = 0x16A8, Value = 0x8ba40e20 }, // 131306
    new() { Offset = 0x16B0, Value = 0x8bb40e20 }, // 131307
    new() { Offset = 0x16B8, Value = 0x8bc40e20 }, // 131308
    // Into Lady Luck
    new() { Offset = 0x1568, Value = 0x8bd41420 }, // 131405
    new() { Offset = 0x16C0, Value = 0x8be41420 }, // 131406
    new() { Offset = 0x16C8, Value = 0x8bf41420 }, // 131407
    new() { Offset = 0x16D0, Value = 0x8b041520 }, // 131408
    // Into Mascot
    new() { Offset = 0x1528, Value = 0x8b141b20 }, // 131505
    new() { Offset = 0x1600, Value = 0x8b241b20 }, // 131506
    new() { Offset = 0x1608, Value = 0x8b341b20 }, // 131507
    new() { Offset = 0x1610, Value = 0x8b441b20 }, // 131508
    // Into Special dressphere?
    new() { Offset = 0x1570, Value = 0x8b542120 }, // 131605
    new() { Offset = 0x16D8, Value = 0x8b642120 }, // 131606
    new() { Offset = 0x16E0, Value = 0x8b742120 }, // 131607
    new() { Offset = 0x16E8, Value = 0x8b842120 }, // 131608
    // Restorative ability?
    new() { Offset = 0x1760, Value = 0x8ba42720 }, // 131706
    new() { Offset = 0x1898, Value = 0x8bb42720 }, // 131707
    new() { Offset = 0x1770, Value = 0x8bc42720 }, // 131708
    new() { Offset = 0x1778, Value = 0x8bd42720 }, // 131709
    new() { Offset = 0x1780, Value = 0x8be42720 }, // 131710
    // Buff ability? e.g Haste?
    new() { Offset = 0x1788, Value = 0x8bc42d20 }, // 131804
    new() { Offset = 0x1790, Value = 0x8bd42d20 }, // 131805
    new() { Offset = 0x1798, Value = 0x8be42d20 }, // 131806
    // (no purpose listed)
    new() { Offset = 0x17A0, Value = 0x8b043420 }, // 131904
    new() { Offset = 0x17A8, Value = 0x8b143420 }, // 131905
    new() { Offset = 0x17B0, Value = 0x8b243420 }, // 131906
    // General ability use?
    new() { Offset = 0x17B8, Value = 0x8b743a20 }, // 132007
    new() { Offset = 0x17C0, Value = 0x8b843a20 }, // 132008
    new() { Offset = 0x17C8, Value = 0x8b943a20 }, // 132009
    new() { Offset = 0x17D0, Value = 0x8ba43a20 }, // 132010
    new() { Offset = 0x17D8, Value = 0x8bb43a20 }, // 132011
    new() { Offset = 0x17E0, Value = 0x8bc43a20 }, // 132012
    // Eject
    new() { Offset = 0x1808, Value = 0x8b844020 }, // 132104
    new() { Offset = 0x1810, Value = 0x8b944020 }, // 132105
    new() { Offset = 0x1818, Value = 0x8ba44020 }, // 132106
    // Scan
    new() { Offset = 0x1820, Value = 0x8bc44620 }, // 132204
    new() { Offset = 0x1828, Value = 0x8bd44620 }, // 132205
    new() { Offset = 0x1830, Value = 0x8be44620 }, // 132206
    // Fire magic
    new() { Offset = 0x1838, Value = 0x8b044d20 }, // 132304
    new() { Offset = 0x1840, Value = 0x8b144d20 }, // 132305
    new() { Offset = 0x1848, Value = 0x8b244d20 }, // 132306
    // Ice magic
    new() { Offset = 0x1850, Value = 0x8b445320 }, // 132404
    new() { Offset = 0x1858, Value = 0x8b545320 }, // 132405
    new() { Offset = 0x1860, Value = 0x8b645320 }, // 132406
    // Water magic
    new() { Offset = 0x1868, Value = 0x8b845920 }, // 132504
    new() { Offset = 0x1870, Value = 0x8b945920 }, // 132505
    new() { Offset = 0x1878, Value = 0x8ba45920 }, // 132506
    // Thunder magic
    new() { Offset = 0x1880, Value = 0x8bc45f20 }, // 132604
    new() { Offset = 0x1888, Value = 0x8bd45f20 }, // 132605
    new() { Offset = 0x1890, Value = 0x8be45f20 }, // 132606
    // Restorative magic?
    new() { Offset = 0x1768, Value = 0x8b046620 }, // 132704
    new() { Offset = 0x18A0, Value = 0x8b146620 }, // 132705
    new() { Offset = 0x18A8, Value = 0x8b246620 }, // 132706
    // Steal / Flimflam
    new() { Offset = 0x1720, Value = 0x8b446c20 }, // 132804 - "Don't hold out on me!"
    new() { Offset = 0x1728, Value = 0x8b546c20 }, // 132805 - "Takers keepers!"
    new() { Offset = 0x1730, Value = 0x8b646c20 }, // 132806 - "It's all in the wrist!"
    new() { Offset = 0x1738, Value = 0x8b847220 }, // 132904 - "You got it, i'll steal it!"
    new() { Offset = 0x1740, Value = 0x8b947220 }, // 132905 - "There ain't nothing I can't steal!"
    new() { Offset = 0x1748, Value = 0x8ba47220 }, // 132906 - "What do you think I'm after?"
    // Mix
    new() { Offset = 0x1B10, Value = 0x8bc47820 }, // 133004 - "Not knowing is the fun part!"
    new() { Offset = 0x1B18, Value = 0x8bd47820 }, // 133005 - "Who ordered a round of Rikku surprise?"
    new() { Offset = 0x1B20, Value = 0x8be47820 }, // 133006 - "A little of this, a little of that"
    // Stash
    new() { Offset = 0x18B0, Value = 0x8b047f20 }, // 133104
    new() { Offset = 0x18B8, Value = 0x8b147f20 }, // 133105
    new() { Offset = 0x18C0, Value = 0x8b247f20 }, // 133106
    // Blue Bullet
    new() { Offset = 0x18C8, Value = 0x8b448520 }, // 133204
    new() { Offset = 0x18D0, Value = 0x8b548520 }, // 133205
    new() { Offset = 0x18D8, Value = 0x8b648520 }, // 133206
    // Fiend Hunter
    new() { Offset = 0x18E0, Value = 0x8b848b20 }, // 133304
    new() { Offset = 0x18E8, Value = 0x8b948b20 }, // 133305
    new() { Offset = 0x18F0, Value = 0x8ba48b20 }, // 133306
    // Berserk
    new() { Offset = 0x18F8, Value = 0x8bc49120 }, // 133404
    new() { Offset = 0x1900, Value = 0x8bd49120 }, // 133405
    new() { Offset = 0x1908, Value = 0x8be49120 }, // 133406
    // Darkness
    new() { Offset = 0x1910, Value = 0x8b049820 }, // 133504
    new() { Offset = 0x1918, Value = 0x8b149820 }, // 133505
    new() { Offset = 0x1920, Value = 0x8b249820 }, // 133506
    // Zantetsu
    new() { Offset = 0x1928, Value = 0x8b449e20 }, // 133604
    new() { Offset = 0x1930, Value = 0x8b549e20 }, // 133605
    new() { Offset = 0x1938, Value = 0x8b649e20 }, // 133606
    // Spare Change
    new() { Offset = 0x1940, Value = 0x8b84a420 }, // 133704
    new() { Offset = 0x1948, Value = 0x8b94a420 }, // 133705
    new() { Offset = 0x1950, Value = 0x8ba4a420 }, // 133706
    // Gamble
    new() { Offset = 0x1958, Value = 0x8bc4aa20 }, // 133804
    new() { Offset = 0x1960, Value = 0x8bd4aa20 }, // 133805
    new() { Offset = 0x1968, Value = 0x8be4aa20 }, // 133806
    // Tantalize?
    new() { Offset = 0x1970, Value = 0x8b04b120 }, // 133904 - "How do you like me now?"
    new() { Offset = 0x1978, Value = 0x8b14b120 }, // 133905 - "Look into my eyes"
    new() { Offset = 0x1980, Value = 0x8b24b120 }, // 133906 - "Well hello there"
    // Pre-Sing
    new() { Offset = 0x1988, Value = 0x8b54b720 }, // 134005
    new() { Offset = 0x1990, Value = 0x8b64b720 }, // 134006
    new() { Offset = 0x1998, Value = 0x8b74b720 }, // 134007
    // Sing
    new() { Offset = 0x1750, Value = 0x8bf4b720 }, // 134015
    new() { Offset = 0x1758, Value = 0x8b04b820 }, // 134016
    // Dance
    new() { Offset = 0x19A0, Value = 0x8b84bd20 }, // 134104
    new() { Offset = 0x19A8, Value = 0x8b94bd20 }, // 134105
    new() { Offset = 0x19B0, Value = 0x8ba4bd20 }, // 134106
    // Ghiki
    new() { Offset = 0x19B8, Value = 0x8bc4c320 }, // 134204 - "Monkey do, monkey do!"
    new() { Offset = 0x19C0, Value = 0x8bd4c320 }, // 134205 - "Think, banana!"
    new() { Offset = 0x19C8, Value = 0x8be4c320 }, // 134206 - "What is it? Wanna show mommy something?"
    // Ghiki?
    new() { Offset = 0x19D0, Value = 0x8b04ca20 }, // 134304
    new() { Offset = 0x19D8, Value = 0x8b14ca20 }, // 134305
    new() { Offset = 0x19E0, Value = 0x8b24ca20 }, // 134306
    // Swarm! Swarm!
    new() { Offset = 0x19E8, Value = 0x8b44d020 }, // 134404 - "Swarm, swarm!"
    new() { Offset = 0x19F0, Value = 0x8b54d020 }, // 134405 - "One barrel full of fun, coming up!"
    new() { Offset = 0x19F8, Value = 0x8b64d020 }, // 134406 - "Time to monkey around!"
    // Vajra
    new() { Offset = 0x1A00, Value = 0x8b84d620 }, // 134504 - "Kerplowie!"
    new() { Offset = 0x1A08, Value = 0x8b94d620 }, // 134505 - "3, 2, 1, Zero!"
    new() { Offset = 0x1A10, Value = 0x8ba4d620 }, // 134506 - "Where's the brakes on this thing?"
    // Machinations?
    new() { Offset = 0x1A18, Value = 0x8bb4d620 }, // 134507 - "Ready to fire sir!"
    new() { Offset = 0x1A20, Value = 0x8bc4d620 }, // 134508 - "Target locked!"
    new() { Offset = 0x1A28, Value = 0x8bd4d620 }, // 134509 - "Verifying target"
    // (no purpose listed)
    new() { Offset = 0x1A30, Value = 0x8bc4dc20 }, // 134604
    new() { Offset = 0x1A38, Value = 0x8bd4dc20 }, // 134605
    new() { Offset = 0x1A40, Value = 0x8be4dc20 }, // 134606
    // Flare
    new() { Offset = 0x1A48, Value = 0x8b04e320 }, // 134704
    new() { Offset = 0x1A50, Value = 0x8b14e320 }, // 134705
    new() { Offset = 0x1A58, Value = 0x8b24e320 }, // 134706
    // Holy
    new() { Offset = 0x1A60, Value = 0x8b44e920 }, // 134804 - "Holy, moly"
    new() { Offset = 0x1A68, Value = 0x8b54e920 }, // 134805
    new() { Offset = 0x1A70, Value = 0x8b64e920 }, // 134806
    // Ultima
    new() { Offset = 0x1A78, Value = 0x8b84ef20 }, // 134904
    new() { Offset = 0x1A80, Value = 0x8b94ef20 }, // 134905
    new() { Offset = 0x1A88, Value = 0x8ba4ef20 }, // 134906
    // Into Psychic
    new() { Offset = 0x1578, Value = 0x8b14fc20 }, // 135105
    new() { Offset = 0x16F0, Value = 0x8b24fc20 }, // 135106
    new() { Offset = 0x16F8, Value = 0x8b34fc20 }, // 135107
    new() { Offset = 0x1700, Value = 0x8b44fc20 }, // 135108
    // Time Trip
    new() { Offset = 0x1A90, Value = 0x8b440221 }, // 135204 - "Time out!"
    new() { Offset = 0x1A98, Value = 0x8b540221 }, // 135205 - "Might be bending the rules but hey!"
    new() { Offset = 0x1AA0, Value = 0x8b640221 }, // 135206 - "And now for a commercial break!"
    // Psychic
    new() { Offset = 0x1AA8, Value = 0x8b840821 }, // 135304 - "No mercy!"
    new() { Offset = 0x1AB0, Value = 0x8b940821 }, // 135305
    new() { Offset = 0x1AB8, Value = 0x8ba40821 }, // 135306 - "This ought to decide things!"
    // Into Festivalist
    new() { Offset = 0x1580, Value = 0x8bd40e21 }, // 135405
    new() { Offset = 0x1708, Value = 0x8be40e21 }, // 135406
    new() { Offset = 0x1710, Value = 0x8bf40e21 }, // 135407
    new() { Offset = 0x1718, Value = 0x8b040f21 }, // 135408
    // Festivities
    new() { Offset = 0x1B00, Value = 0x8b041521 }, // 135504 - "Let's carnival!"
    // Fish/Festivities
    new() { Offset = 0x1AD0, Value = 0x8b141521 }, // 135505 - "When I say party, you party!"
    new() { Offset = 0x1B08, Value = 0x8b241521 }, // 135506 - "All together now!"
    // Using Spinner/Popper/Fountain?
    new() { Offset = 0x1AE0, Value = 0x8b541b21 }, // 135605 - "Fireworks fun, woohoo!"
    new() { Offset = 0x1AE8, Value = 0x8b641b21 }, // 135606 - "Ooh I love these!"
    new() { Offset = 0x1AF0, Value = 0x8b741b21 }, // 135607 - "Al Bhed brand fireworks!"
    new() { Offset = 0x1AF8, Value = 0x8b841b21 }, // 135608 - "Look at the pretty colors!"
    // Fish
    new() { Offset = 0x1AC0, Value = 0x8b842121 }, // 135704 - "Fly my pretty! Hahahahaa!"
    new() { Offset = 0x1AC8, Value = 0x8b942121 }, // 135705 - "Go, fish!"
    new() { Offset = 0x1AD8, Value = 0x8ba42121 }, // 135706 - "No one expects a goldfish!"
    // Japanese line
    new() { Offset = 0x17E8, Value = 0x8b242221 }, // 135714
    new() { Offset = 0x17F0, Value = 0x8b342221 }, // 135715
    new() { Offset = 0x17F8, Value = 0x8b442221 }, // 135716
    new() { Offset = 0x1800, Value = 0x8b542221 }, // 135717
    // Battle over
    new() { Offset = 0x2714, Value = 0x8b943a22 }, // 140201
    new() { Offset = 0x271C, Value = 0x8ba43a22 }, // 140202
    new() { Offset = 0x2724, Value = 0x8bb43a22 }, // 140203
    new() { Offset = 0x272C, Value = 0x8bc43a22 }, // 140204
    // Battle over (low health)
    new() { Offset = 0x2774, Value = 0x8b544d22 }, // 140501
    new() { Offset = 0x277C, Value = 0x8b644d22 }, // 140502 - "Can we not almost die next time?"
    new() { Offset = 0x2784, Value = 0x8b744d22 }, // 140503
    new() { Offset = 0x278C, Value = 0x8b844d22 }, // 140504
    new() { Offset = 0x27BC, Value = 0x8bd45922 }, // 140701
    new() { Offset = 0x27C4, Value = 0x8be45922 }, // 140702
    new() { Offset = 0x27CC, Value = 0x8bf45922 }, // 140703
    // LM?
    new() { Offset = 0x27FC, Value = 0x8b346022 }, // 140803
    new() { Offset = 0x2804, Value = 0x8b446022 }, // 140804
    new() { Offset = 0x280C, Value = 0x8b546022 }, // 140805
    // Game over
    new() { Offset = 0x24E0, Value = 0x8bd47222 }, // 141101
    new() { Offset = 0x24E8, Value = 0x8be47222 }, // 141102
    new() { Offset = 0x24F0, Value = 0x8bf47222 }, // 141103
    new() { Offset = 0x24F8, Value = 0x8b047322 }, // 141104
    // Vegnagun Tail defeated
    new() { Offset = 0x255C, Value = 0x8b948522 }, // 141401 - "Take that! / We're not done yet"
    // Vegnagun Leg defeated
    new() { Offset = 0x2560, Value = 0x8bc48522 }, // 141404 - "So? Did we get it? / Sure looks that way / Shake a leg"
    // Battle win
    new() { Offset = 0x2650, Value = 0x8bd4a422 }, // 141901
    new() { Offset = 0x2654, Value = 0x8be4a422 }, // 141902
    new() { Offset = 0x2658, Value = 0x8bf4a422 }, // 141903
    new() { Offset = 0x2678, Value = 0x8b04a522 }, // 141904
    new() { Offset = 0x2668, Value = 0x8b14a522 }, // 141905
    new() { Offset = 0x2660, Value = 0x8b24a522 }, // 141906
    new() { Offset = 0x2664, Value = 0x8b34a522 }, // 141907
    new() { Offset = 0x265C, Value = 0x8b44a522 }, // 141908
    // Trainer win
    new() { Offset = 0x266C, Value = 0x8b54e322 }, // 142901
    new() { Offset = 0x2670, Value = 0x8b64e322 }, // 142902
    new() { Offset = 0x2674, Value = 0x8b74e322 }, // 142903
    // (no purpose listed)
    new() { Offset = 0x226C, Value = 0x8b94c235 }, // 220201
    new() { Offset = 0x2274, Value = 0x8ba4c235 }, // 220202
    new() { Offset = 0x227C, Value = 0x8bb4c235 }, // 220203
    new() { Offset = 0x2284, Value = 0x8bc4c235 }, // 220204
    new() { Offset = 0x238C, Value = 0x8b140136 }, // 221201
    new() { Offset = 0x2394, Value = 0x8b240136 }, // 221202
    new() { Offset = 0x239C, Value = 0x8b340136 }, // 221203
    new() { Offset = 0x23A4, Value = 0x8b440136 }, // 221204
    new() { Offset = 0x22AC, Value = 0x8b143336 }, // 222001
    new() { Offset = 0x22BC, Value = 0x8b343336 }, // 222003
    new() { Offset = 0x22C4, Value = 0x8b443336 }, // 222004
    new() { Offset = 0x22CC, Value = 0x8b543336 }, // 222005
    new() { Offset = 0x22DC, Value = 0x8b543936 }, // 222101
    new() { Offset = 0x22E4, Value = 0x8b643936 }, // 222102
    new() { Offset = 0x22EC, Value = 0x8b743936 }, // 222103
    new() { Offset = 0x22FC, Value = 0x8b943936 }, // 222105
    new() { Offset = 0x2304, Value = 0x8ba43936 }, // 222106
    new() { Offset = 0x23FC, Value = 0x8bd44536 }, // 222301
    new() { Offset = 0x2404, Value = 0x8be44536 }, // 222302
    new() { Offset = 0x240C, Value = 0x8bf44536 }, // 222303
    new() { Offset = 0x233C, Value = 0x8b144c36 }, // 222401
    new() { Offset = 0x2344, Value = 0x8b244c36 }, // 222402
    new() { Offset = 0x245C, Value = 0x8b545236 }, // 222501
    new() { Offset = 0x2464, Value = 0x8b645236 }, // 222502
    new() { Offset = 0x23E4, Value = 0x8b846b36 }, // 222904
    new() { Offset = 0x23EC, Value = 0x8b946b36 }, // 222905
    new() { Offset = 0x23F4, Value = 0x8ba46b36 }, // 222906
    new() { Offset = 0x1504, Value = 0x8bc43338 }, // 230204
    new() { Offset = 0x1584, Value = 0x8bd43338 }, // 230205
    new() { Offset = 0x158C, Value = 0x8be43338 }, // 230206
    new() { Offset = 0x1594, Value = 0x8bf43338 }, // 230207
    new() { Offset = 0x150C, Value = 0x8b143a38 }, // 230305
    new() { Offset = 0x159C, Value = 0x8b243a38 }, // 230306
    new() { Offset = 0x15A4, Value = 0x8b343a38 }, // 230307
    new() { Offset = 0x15AC, Value = 0x8b443a38 }, // 230308
    new() { Offset = 0x1514, Value = 0x8b544038 }, // 230405
    new() { Offset = 0x15B4, Value = 0x8b644038 }, // 230406
    new() { Offset = 0x15BC, Value = 0x8b744038 }, // 230407
    new() { Offset = 0x15C4, Value = 0x8b844038 }, // 230408
    new() { Offset = 0x15CC, Value = 0x8b944638 }, // 230505
    new() { Offset = 0x15D4, Value = 0x8ba44638 }, // 230506
    new() { Offset = 0x15DC, Value = 0x8bb44638 }, // 230507
    new() { Offset = 0x151C, Value = 0x8bd44c38 }, // 230605
    new() { Offset = 0x15E4, Value = 0x8be44c38 }, // 230606
    new() { Offset = 0x15EC, Value = 0x8bf44c38 }, // 230607
    new() { Offset = 0x15F4, Value = 0x8b044d38 }, // 230608
    new() { Offset = 0x152C, Value = 0x8b145338 }, // 230705
    new() { Offset = 0x1614, Value = 0x8b245338 }, // 230706
    new() { Offset = 0x161C, Value = 0x8b345338 }, // 230707
    new() { Offset = 0x1624, Value = 0x8b445338 }, // 230708
    new() { Offset = 0x1534, Value = 0x8b545938 }, // 230805
    new() { Offset = 0x162C, Value = 0x8b645938 }, // 230806
    new() { Offset = 0x1634, Value = 0x8b745938 }, // 230807
    new() { Offset = 0x163C, Value = 0x8b845938 }, // 230808
    new() { Offset = 0x153C, Value = 0x8b945f38 }, // 230905
    new() { Offset = 0x1644, Value = 0x8ba45f38 }, // 230906
    new() { Offset = 0x164C, Value = 0x8bb45f38 }, // 230907
    new() { Offset = 0x1654, Value = 0x8bc45f38 }, // 230908
    new() { Offset = 0x1544, Value = 0x8bd46538 }, // 231005
    new() { Offset = 0x165C, Value = 0x8be46538 }, // 231006
    new() { Offset = 0x1664, Value = 0x8bf46538 }, // 231007
    new() { Offset = 0x166C, Value = 0x8b046638 }, // 231008
    new() { Offset = 0x154C, Value = 0x8b146c38 }, // 231105
    new() { Offset = 0x1674, Value = 0x8b246c38 }, // 231106
    new() { Offset = 0x167C, Value = 0x8b346c38 }, // 231107
    new() { Offset = 0x1684, Value = 0x8b446c38 }, // 231108
    new() { Offset = 0x1554, Value = 0x8b547238 }, // 231205
    new() { Offset = 0x168C, Value = 0x8b647238 }, // 231206
    new() { Offset = 0x1694, Value = 0x8b747238 }, // 231207
    new() { Offset = 0x169C, Value = 0x8b847238 }, // 231208
    new() { Offset = 0x155C, Value = 0x8b947838 }, // 231305
    new() { Offset = 0x16A4, Value = 0x8ba47838 }, // 231306
    new() { Offset = 0x16AC, Value = 0x8bb47838 }, // 231307
    new() { Offset = 0x16B4, Value = 0x8bc47838 }, // 231308
    new() { Offset = 0x1564, Value = 0x8bd47e38 }, // 231405
    new() { Offset = 0x16BC, Value = 0x8be47e38 }, // 231406
    new() { Offset = 0x16C4, Value = 0x8bf47e38 }, // 231407
    new() { Offset = 0x16CC, Value = 0x8b047f38 }, // 231408
    new() { Offset = 0x1524, Value = 0x8b148538 }, // 231505
    new() { Offset = 0x15FC, Value = 0x8b248538 }, // 231506
    new() { Offset = 0x1604, Value = 0x8b348538 }, // 231507
    new() { Offset = 0x160C, Value = 0x8b448538 }, // 231508
    new() { Offset = 0x156C, Value = 0x8b548b38 }, // 231605
    new() { Offset = 0x16D4, Value = 0x8b648b38 }, // 231606
    new() { Offset = 0x16DC, Value = 0x8b748b38 }, // 231607
    new() { Offset = 0x16E4, Value = 0x8b848b38 }, // 231608
    new() { Offset = 0x175C, Value = 0x8ba49138 }, // 231706
    new() { Offset = 0x1894, Value = 0x8bb49138 }, // 231707
    new() { Offset = 0x176C, Value = 0x8bc49138 }, // 231708
    new() { Offset = 0x1774, Value = 0x8bd49138 }, // 231709
    new() { Offset = 0x177C, Value = 0x8be49138 }, // 231710
    new() { Offset = 0x1784, Value = 0x8bc49738 }, // 231804
    new() { Offset = 0x178C, Value = 0x8bd49738 }, // 231805
    new() { Offset = 0x1794, Value = 0x8be49738 }, // 231806
    new() { Offset = 0x179C, Value = 0x8b049e38 }, // 231904
    new() { Offset = 0x17A4, Value = 0x8b149e38 }, // 231905
    new() { Offset = 0x17AC, Value = 0x8b249e38 }, // 231906
    new() { Offset = 0x17B4, Value = 0x8b74a438 }, // 232007
    new() { Offset = 0x17BC, Value = 0x8b84a438 }, // 232008
    new() { Offset = 0x17C4, Value = 0x8b94a438 }, // 232009
    new() { Offset = 0x17CC, Value = 0x8ba4a438 }, // 232010
    new() { Offset = 0x17D4, Value = 0x8bb4a438 }, // 232011
    new() { Offset = 0x17DC, Value = 0x8bc4a438 }, // 232012
    new() { Offset = 0x1804, Value = 0x8b84aa38 }, // 232104
    new() { Offset = 0x180C, Value = 0x8b94aa38 }, // 232105
    new() { Offset = 0x1814, Value = 0x8ba4aa38 }, // 232106
    new() { Offset = 0x181C, Value = 0x8bc4b038 }, // 232204
    new() { Offset = 0x1824, Value = 0x8bd4b038 }, // 232205
    new() { Offset = 0x182C, Value = 0x8be4b038 }, // 232206
    new() { Offset = 0x1834, Value = 0x8b04b738 }, // 232304
    new() { Offset = 0x183C, Value = 0x8b14b738 }, // 232305
    new() { Offset = 0x1844, Value = 0x8b24b738 }, // 232306
    new() { Offset = 0x184C, Value = 0x8b44bd38 }, // 232404
    new() { Offset = 0x1854, Value = 0x8b54bd38 }, // 232405
    new() { Offset = 0x185C, Value = 0x8b64bd38 }, // 232406
    new() { Offset = 0x1864, Value = 0x8b84c338 }, // 232504
    new() { Offset = 0x186C, Value = 0x8b94c338 }, // 232505
    new() { Offset = 0x1874, Value = 0x8ba4c338 }, // 232506
    new() { Offset = 0x187C, Value = 0x8bc4c938 }, // 232604
    new() { Offset = 0x1884, Value = 0x8bd4c938 }, // 232605
    new() { Offset = 0x188C, Value = 0x8be4c938 }, // 232606
    new() { Offset = 0x1764, Value = 0x8b04d038 }, // 232704
    new() { Offset = 0x189C, Value = 0x8b14d038 }, // 232705
    new() { Offset = 0x18A4, Value = 0x8b24d038 }, // 232706
    new() { Offset = 0x171C, Value = 0x8b44d638 }, // 232804
    new() { Offset = 0x1724, Value = 0x8b54d638 }, // 232805
    new() { Offset = 0x172C, Value = 0x8b64d638 }, // 232806
    new() { Offset = 0x1734, Value = 0x8b84dc38 }, // 232904
    new() { Offset = 0x173C, Value = 0x8b94dc38 }, // 232905
    new() { Offset = 0x1744, Value = 0x8ba4dc38 }, // 232906
    new() { Offset = 0x1B0C, Value = 0x8bc4e238 }, // 233004
    new() { Offset = 0x1B14, Value = 0x8bd4e238 }, // 233005
    new() { Offset = 0x1B1C, Value = 0x8be4e238 }, // 233006
    new() { Offset = 0x18AC, Value = 0x8b04e938 }, // 233104
    new() { Offset = 0x18B4, Value = 0x8b14e938 }, // 233105
    new() { Offset = 0x18BC, Value = 0x8b24e938 }, // 233106
    new() { Offset = 0x18C4, Value = 0x8b44ef38 }, // 233204
    new() { Offset = 0x18CC, Value = 0x8b54ef38 }, // 233205
    new() { Offset = 0x18D4, Value = 0x8b64ef38 }, // 233206
    new() { Offset = 0x18DC, Value = 0x8b84f538 }, // 233304
    new() { Offset = 0x18E4, Value = 0x8b94f538 }, // 233305
    new() { Offset = 0x18EC, Value = 0x8ba4f538 }, // 233306
    new() { Offset = 0x18F4, Value = 0x8bc4fb38 }, // 233404
    new() { Offset = 0x18FC, Value = 0x8bd4fb38 }, // 233405
    new() { Offset = 0x1904, Value = 0x8be4fb38 }, // 233406
    new() { Offset = 0x190C, Value = 0x8b040239 }, // 233504
    new() { Offset = 0x1914, Value = 0x8b140239 }, // 233505
    new() { Offset = 0x191C, Value = 0x8b240239 }, // 233506
    new() { Offset = 0x1924, Value = 0x8b440839 }, // 233604
    new() { Offset = 0x192C, Value = 0x8b540839 }, // 233605
    new() { Offset = 0x1934, Value = 0x8b640839 }, // 233606
    new() { Offset = 0x193C, Value = 0x8b840e39 }, // 233704
    new() { Offset = 0x1944, Value = 0x8b940e39 }, // 233705
    new() { Offset = 0x194C, Value = 0x8ba40e39 }, // 233706
    new() { Offset = 0x1954, Value = 0x8bc41439 }, // 233804
    new() { Offset = 0x195C, Value = 0x8bd41439 }, // 233805
    new() { Offset = 0x1964, Value = 0x8be41439 }, // 233806
    new() { Offset = 0x196C, Value = 0x8b041b39 }, // 233904
    new() { Offset = 0x1974, Value = 0x8b141b39 }, // 233905
    new() { Offset = 0x197C, Value = 0x8b241b39 }, // 233906
    new() { Offset = 0x1984, Value = 0x8b542139 }, // 234005
    new() { Offset = 0x198C, Value = 0x8b642139 }, // 234006
    new() { Offset = 0x1994, Value = 0x8b742139 }, // 234007
    new() { Offset = 0x174C, Value = 0x8bf42139 }, // 234015
    new() { Offset = 0x1754, Value = 0x8b042239 }, // 234016
    new() { Offset = 0x199C, Value = 0x8b842739 }, // 234104
    new() { Offset = 0x19A4, Value = 0x8b942739 }, // 234105
    new() { Offset = 0x19AC, Value = 0x8ba42739 }, // 234106
    new() { Offset = 0x19B4, Value = 0x8bc42d39 }, // 234204
    new() { Offset = 0x19BC, Value = 0x8bd42d39 }, // 234205
    new() { Offset = 0x19C4, Value = 0x8be42d39 }, // 234206
    new() { Offset = 0x19CC, Value = 0x8b043439 }, // 234304
    new() { Offset = 0x19D4, Value = 0x8b143439 }, // 234305
    new() { Offset = 0x19DC, Value = 0x8b243439 }, // 234306
    new() { Offset = 0x19E4, Value = 0x8b443a39 }, // 234404
    new() { Offset = 0x19EC, Value = 0x8b543a39 }, // 234405
    new() { Offset = 0x19F4, Value = 0x8b643a39 }, // 234406
    new() { Offset = 0x19FC, Value = 0x8b844039 }, // 234504
    new() { Offset = 0x1A04, Value = 0x8b944039 }, // 234505
    new() { Offset = 0x1A0C, Value = 0x8ba44039 }, // 234506
    new() { Offset = 0x1A14, Value = 0x8bb44039 }, // 234507
    new() { Offset = 0x1A1C, Value = 0x8bc44039 }, // 234508
    new() { Offset = 0x1A24, Value = 0x8bd44039 }, // 234509
    new() { Offset = 0x1A2C, Value = 0x8bc44639 }, // 234604
    new() { Offset = 0x1A34, Value = 0x8bd44639 }, // 234605
    new() { Offset = 0x1A3C, Value = 0x8be44639 }, // 234606
    new() { Offset = 0x1A44, Value = 0x8b044d39 }, // 234704
    new() { Offset = 0x1A4C, Value = 0x8b144d39 }, // 234705
    new() { Offset = 0x1A54, Value = 0x8b244d39 }, // 234706
    new() { Offset = 0x1A5C, Value = 0x8b445339 }, // 234804
    new() { Offset = 0x1A64, Value = 0x8b545339 }, // 234805
    new() { Offset = 0x1A6C, Value = 0x8b645339 }, // 234806
    new() { Offset = 0x1A74, Value = 0x8b845939 }, // 234904
    new() { Offset = 0x1A7C, Value = 0x8b945939 }, // 234905
    new() { Offset = 0x1A84, Value = 0x8ba45939 }, // 234906
    new() { Offset = 0x1574, Value = 0x8b146639 }, // 235105
    new() { Offset = 0x16EC, Value = 0x8b246639 }, // 235106
    new() { Offset = 0x16F4, Value = 0x8b346639 }, // 235107
    new() { Offset = 0x16FC, Value = 0x8b446639 }, // 235108
    new() { Offset = 0x1A8C, Value = 0x8b446c39 }, // 235204
    new() { Offset = 0x1A94, Value = 0x8b546c39 }, // 235205
    new() { Offset = 0x1A9C, Value = 0x8b646c39 }, // 235206
    new() { Offset = 0x1AA4, Value = 0x8b847239 }, // 235304
    new() { Offset = 0x1AAC, Value = 0x8b947239 }, // 235305
    new() { Offset = 0x1AB4, Value = 0x8ba47239 }, // 235306
    new() { Offset = 0x157C, Value = 0x8bd47839 }, // 235405
    new() { Offset = 0x1704, Value = 0x8be47839 }, // 235406
    new() { Offset = 0x170C, Value = 0x8bf47839 }, // 235407
    new() { Offset = 0x1714, Value = 0x8b047939 }, // 235408
    new() { Offset = 0x1AFC, Value = 0x8b047f39 }, // 235504
    new() { Offset = 0x1ACC, Value = 0x8b147f39 }, // 235505
    new() { Offset = 0x1B04, Value = 0x8b247f39 }, // 235506
    new() { Offset = 0x1ADC, Value = 0x8b548539 }, // 235605
    new() { Offset = 0x1AE4, Value = 0x8b648539 }, // 235606
    new() { Offset = 0x1AEC, Value = 0x8b748539 }, // 235607
    new() { Offset = 0x1AF4, Value = 0x8b848539 }, // 235608
    new() { Offset = 0x1ABC, Value = 0x8b848b39 }, // 235704
    new() { Offset = 0x1AC4, Value = 0x8b948b39 }, // 235705
    new() { Offset = 0x1AD4, Value = 0x8ba48b39 }, // 235706
    new() { Offset = 0x17E4, Value = 0x8b248c39 }, // 235714
    new() { Offset = 0x17EC, Value = 0x8b348c39 }, // 235715
    new() { Offset = 0x17F4, Value = 0x8b448c39 }, // 235716
    new() { Offset = 0x17FC, Value = 0x8b548c39 }, // 235717
    new() { Offset = 0x2710, Value = 0x8b94a43a }, // 240201
    new() { Offset = 0x2718, Value = 0x8ba4a43a }, // 240202
    new() { Offset = 0x2720, Value = 0x8bb4a43a }, // 240203
    new() { Offset = 0x2728, Value = 0x8bc4a43a }, // 240204
    new() { Offset = 0x2770, Value = 0x8b54b73a }, // 240501
    new() { Offset = 0x2778, Value = 0x8b64b73a }, // 240502
    new() { Offset = 0x2780, Value = 0x8b74b73a }, // 240503
    new() { Offset = 0x2788, Value = 0x8b84b73a }, // 240504
    new() { Offset = 0x27B8, Value = 0x8bd4c33a }, // 240701
    new() { Offset = 0x27C0, Value = 0x8be4c33a }, // 240702
    new() { Offset = 0x27C8, Value = 0x8bf4c33a }, // 240703
    new() { Offset = 0x27F8, Value = 0x8b34ca3a }, // 240803
    new() { Offset = 0x2800, Value = 0x8b44ca3a }, // 240804
    new() { Offset = 0x2808, Value = 0x8b54ca3a }, // 240805
    new() { Offset = 0x24DC, Value = 0x8bd4dc3a }, // 241101
    new() { Offset = 0x24E4, Value = 0x8be4dc3a }, // 241102
    new() { Offset = 0x24EC, Value = 0x8bf4dc3a }, // 241103
    new() { Offset = 0x24F4, Value = 0x8b04dd3a }, // 241104
];

    public static readonly MemoryWrite[] VanillaVL_pn = // Paine
[
    // Battle start
    new() { Offset = 0x2290, Value = 0x0ed45e1d }, // 120301
    new() { Offset = 0x2298, Value = 0x0ee45e1d }, // 120302
    new() { Offset = 0x22A0, Value = 0x0ef45e1d }, // 120303
    new() { Offset = 0x22A8, Value = 0x0e045f1d }, // 120304
    // Battle start (low health?) (LM?)
    new() { Offset = 0x23B0, Value = 0x0e549d1d }, // 121301
    new() { Offset = 0x23B8, Value = 0x0e649d1d }, // 121302
    new() { Offset = 0x23C0, Value = 0x0e749d1d }, // 121303
    new() { Offset = 0x23C8, Value = 0x0e849d1d }, // 121304
    // Battle start
    new() { Offset = 0x22F8, Value = 0x0e84cf1d }, // 122104
    new() { Offset = 0x2318, Value = 0x0ea4d51d }, // 122202 - "All yours Yuna! / Where are you going?"
    new() { Offset = 0x2330, Value = 0x0ed4d51d }, // 122205
    new() { Offset = 0x2338, Value = 0x0ee4d51d }, // 122206
    // (no purpose listed)
    new() { Offset = 0x2418, Value = 0x0e04dc1d }, // 122304
    new() { Offset = 0x2420, Value = 0x0e14dc1d }, // 122305
    new() { Offset = 0x2428, Value = 0x0e24dc1d }, // 122306
    new() { Offset = 0x2358, Value = 0x0e44e21d }, // 122404
    new() { Offset = 0x2360, Value = 0x0e54e21d }, // 122405
    // LM In trouble?
    new() { Offset = 0x2480, Value = 0x0e94e81d }, // 122505
    new() { Offset = 0x2488, Value = 0x0ea4e81d }, // 122506
    // Battle start - Luca Prologue, goon fight
    new() { Offset = 0x2124, Value = 0x0ee4f41d }, // 122702 - "Move!"
    // (no purpose listed)
    new() { Offset = 0x2138, Value = 0x0e34f51d }, // 122707 - "Them again?"
    new() { Offset = 0x2140, Value = 0x0e54f51d }, // 122709 - "Hi there creepy crawly"
    new() { Offset = 0x2148, Value = 0x0e74f51d }, // 122711 - "You guys deserve a medal"
    new() { Offset = 0x2154, Value = 0x0ea4f51d }, // 122714 - "Fight, you have to!"
    new() { Offset = 0x2164, Value = 0x0ee4f51d }, // 122718 - "Isn't this cute"
    new() { Offset = 0x217C, Value = 0x0e24fb1d }, // 122802 - "Leblanc never stood a chance..."
    // LM?
    new() { Offset = 0x2430, Value = 0x0e94071e }, // 123001
    new() { Offset = 0x2438, Value = 0x0ea4071e }, // 123002
    new() { Offset = 0x2440, Value = 0x0eb4071e }, // 123003
    // Into Gunner
    new() { Offset = 0x1B28, Value = 0x0e04ca1f }, // 130208
    new() { Offset = 0x1BA4, Value = 0x0e14ca1f }, // 130209
    new() { Offset = 0x1BAC, Value = 0x0e24ca1f }, // 130210
    new() { Offset = 0x1BB4, Value = 0x0e34ca1f }, // 130211
    // Into Gun Mage
    new() { Offset = 0x1B30, Value = 0x0e54d01f }, // 130309
    new() { Offset = 0x1BBC, Value = 0x0e64d01f }, // 130310
    new() { Offset = 0x1BC4, Value = 0x0e74d01f }, // 130311
    new() { Offset = 0x1BCC, Value = 0x0e84d01f }, // 130312
    // Into Alchemist
    new() { Offset = 0x1B38, Value = 0x0e94d61f }, // 130409
    new() { Offset = 0x1BD4, Value = 0x0ea4d61f }, // 130410
    new() { Offset = 0x1BDC, Value = 0x0eb4d61f }, // 130411
    new() { Offset = 0x1BE4, Value = 0x0ec4d61f }, // 130412
    // Into Thief
    new() { Offset = 0x1B40, Value = 0x0ec4dc1f }, // 130508
    new() { Offset = 0x1BEC, Value = 0x0ed4dc1f }, // 130509
    new() { Offset = 0x1BF4, Value = 0x0ee4dc1f }, // 130510
    new() { Offset = 0x1BFC, Value = 0x0ef4dc1f }, // 130511
    // Into Trainer
    new() { Offset = 0x1B48, Value = 0x0e14e31f }, // 130609
    new() { Offset = 0x1C04, Value = 0x0e24e31f }, // 130610
    new() { Offset = 0x1C0C, Value = 0x0e34e31f }, // 130611
    new() { Offset = 0x1C14, Value = 0x0e44e31f }, // 130612
    // Into Warrior
    new() { Offset = 0x1C34, Value = 0x0e54e91f }, // 130709
    new() { Offset = 0x1C3C, Value = 0x0e64e91f }, // 130710
    new() { Offset = 0x1C44, Value = 0x0e74e91f }, // 130711
    // Into Samurai
    new() { Offset = 0x1B58, Value = 0x0e94ef1f }, // 130809
    new() { Offset = 0x1C4C, Value = 0x0ea4ef1f }, // 130810
    new() { Offset = 0x1C54, Value = 0x0eb4ef1f }, // 130811
    new() { Offset = 0x1C5C, Value = 0x0ec4ef1f }, // 130812
    // Into Dark Knight
    new() { Offset = 0x1B60, Value = 0x0ed4f51f }, // 130909
    new() { Offset = 0x1C64, Value = 0x0ee4f51f }, // 130910
    new() { Offset = 0x1C6C, Value = 0x0ef4f51f }, // 130911
    new() { Offset = 0x1C74, Value = 0x0e04f61f }, // 130912
    // Into Berserker
    new() { Offset = 0x1B68, Value = 0x0e14fc1f }, // 131009
    new() { Offset = 0x1C7C, Value = 0x0e24fc1f }, // 131010
    new() { Offset = 0x1C84, Value = 0x0e34fc1f }, // 131011
    new() { Offset = 0x1C8C, Value = 0x0e44fc1f }, // 131012
    // Into Songstress
    new() { Offset = 0x1B70, Value = 0x0e540220 }, // 131109
    new() { Offset = 0x1C94, Value = 0x0e640220 }, // 131110
    new() { Offset = 0x1C9C, Value = 0x0e740220 }, // 131111
    new() { Offset = 0x1CA4, Value = 0x0e840220 }, // 131112
    // Into Black Mage
    new() { Offset = 0x1B78, Value = 0x0e940820 }, // 131209
    new() { Offset = 0x1CAC, Value = 0x0ea40820 }, // 131210
    new() { Offset = 0x1CB4, Value = 0x0eb40820 }, // 131211
    new() { Offset = 0x1CBC, Value = 0x0ec40820 }, // 131212
    // Into White Mage
    new() { Offset = 0x1B80, Value = 0x0ed40e20 }, // 131309
    new() { Offset = 0x1CC4, Value = 0x0ee40e20 }, // 131310
    new() { Offset = 0x1CCC, Value = 0x0ef40e20 }, // 131311
    new() { Offset = 0x1CD4, Value = 0x0e040f20 }, // 131312
    // Into Lady Luck
    new() { Offset = 0x1B88, Value = 0x0e141520 }, // 131409
    new() { Offset = 0x1CDC, Value = 0x0e241520 }, // 131410
    new() { Offset = 0x1CE4, Value = 0x0e341520 }, // 131411
    new() { Offset = 0x1CEC, Value = 0x0e441520 }, // 131412
    // Into Mascot
    new() { Offset = 0x1B50, Value = 0x0e541b20 }, // 131509
    new() { Offset = 0x1C1C, Value = 0x0e641b20 }, // 131510
    new() { Offset = 0x1C24, Value = 0x0e741b20 }, // 131511
    new() { Offset = 0x1C2C, Value = 0x0e841b20 }, // 131512
    // Into Special dressphere?
    new() { Offset = 0x1B90, Value = 0x0e942120 }, // 131609
    new() { Offset = 0x1CF4, Value = 0x0ea42120 }, // 131610
    new() { Offset = 0x1CFC, Value = 0x0eb42120 }, // 131611
    new() { Offset = 0x1D04, Value = 0x0ec42120 }, // 131612
    // Restorative ability?
    new() { Offset = 0x1D7C, Value = 0x0ef42720 }, // 131711
    new() { Offset = 0x1D84, Value = 0x0e042820 }, // 131712
    new() { Offset = 0x1D8C, Value = 0x0e142820 }, // 131713
    new() { Offset = 0x1D94, Value = 0x0e242820 }, // 131714
    new() { Offset = 0x1D9C, Value = 0x0e342820 }, // 131715
    // Buff ability? e.g Haste?
    new() { Offset = 0x1DA4, Value = 0x0ef42d20 }, // 131807
    new() { Offset = 0x1DAC, Value = 0x0e042e20 }, // 131808
    new() { Offset = 0x1DB4, Value = 0x0e142e20 }, // 131809
    // (no purpose listed)
    new() { Offset = 0x1DBC, Value = 0x0e343420 }, // 131907
    new() { Offset = 0x1DC4, Value = 0x0e443420 }, // 131908
    new() { Offset = 0x1DCC, Value = 0x0e543420 }, // 131909
    // General ability use?
    new() { Offset = 0x1DD4, Value = 0x0ed43a20 }, // 132013
    new() { Offset = 0x1DDC, Value = 0x0ee43a20 }, // 132014
    new() { Offset = 0x1DE4, Value = 0x0ef43a20 }, // 132015
    new() { Offset = 0x1DEC, Value = 0x0e043b20 }, // 132016
    new() { Offset = 0x1DF4, Value = 0x0e143b20 }, // 132017
    new() { Offset = 0x1DFC, Value = 0x0e243b20 }, // 132018
    // Eject
    new() { Offset = 0x1E24, Value = 0x0eb44020 }, // 132107
    new() { Offset = 0x1E2C, Value = 0x0ec44020 }, // 132108
    new() { Offset = 0x1E34, Value = 0x0ed44020 }, // 132109
    // Scan
    new() { Offset = 0x1E3C, Value = 0x0ef44620 }, // 132207
    new() { Offset = 0x1E44, Value = 0x0e044720 }, // 132208
    new() { Offset = 0x1E4C, Value = 0x0e144720 }, // 132209
    // Fire magic
    new() { Offset = 0x1E54, Value = 0x0e344d20 }, // 132307
    new() { Offset = 0x1E5C, Value = 0x0e444d20 }, // 132308
    new() { Offset = 0x1E64, Value = 0x0e544d20 }, // 132309
    // Ice magic
    new() { Offset = 0x1E6C, Value = 0x0e745320 }, // 132407
    new() { Offset = 0x1E74, Value = 0x0e845320 }, // 132408
    new() { Offset = 0x1E7C, Value = 0x0e945320 }, // 132409
    // Water magic
    new() { Offset = 0x1E84, Value = 0x0eb45920 }, // 132507
    new() { Offset = 0x1E8C, Value = 0x0ec45920 }, // 132508
    new() { Offset = 0x1E94, Value = 0x0ed45920 }, // 132509
    // Thunder magic
    new() { Offset = 0x1E9C, Value = 0x0ef45f20 }, // 132607
    new() { Offset = 0x1EA4, Value = 0x0e046020 }, // 132608
    new() { Offset = 0x1EAC, Value = 0x0e146020 }, // 132609
    // Restorative magic?
    new() { Offset = 0x1EB4, Value = 0x0e346620 }, // 132707
    new() { Offset = 0x1EBC, Value = 0x0e446620 }, // 132708
    new() { Offset = 0x1EC4, Value = 0x0e546620 }, // 132709
    // Steal / Flimflam
    new() { Offset = 0x1D3C, Value = 0x0e746c20 }, // 132807
    new() { Offset = 0x1D44, Value = 0x0e846c20 }, // 132808
    new() { Offset = 0x1D4C, Value = 0x0e946c20 }, // 132809
    new() { Offset = 0x1D54, Value = 0x0eb47220 }, // 132907
    new() { Offset = 0x1D5C, Value = 0x0ec47220 }, // 132908
    new() { Offset = 0x1D64, Value = 0x0ed47220 }, // 132909
    // Mix
    new() { Offset = 0x210C, Value = 0x0ef47820 }, // 133007 - "I'm figuring this out as I go"
    new() { Offset = 0x2114, Value = 0x0e047920 }, // 133008 - "Is there a trick to this?"
    new() { Offset = 0x211C, Value = 0x0e147920 }, // 133009 - "Sorry if I screw this up"
    // Stash
    new() { Offset = 0x1ECC, Value = 0x0e347f20 }, // 133107
    new() { Offset = 0x1ED4, Value = 0x0e447f20 }, // 133108
    new() { Offset = 0x1EDC, Value = 0x0e547f20 }, // 133109
    // Blue Bullet
    new() { Offset = 0x1EE4, Value = 0x0e748520 }, // 133207
    new() { Offset = 0x1EEC, Value = 0x0e848520 }, // 133208
    new() { Offset = 0x1EF4, Value = 0x0e948520 }, // 133209
    // Fiend Hunter
    new() { Offset = 0x1EFC, Value = 0x0eb48b20 }, // 133307
    new() { Offset = 0x1F04, Value = 0x0ec48b20 }, // 133308
    new() { Offset = 0x1F0C, Value = 0x0ed48b20 }, // 133309
    // Berserk
    new() { Offset = 0x1F14, Value = 0x0ef49120 }, // 133407
    new() { Offset = 0x1F1C, Value = 0x0e049220 }, // 133408
    new() { Offset = 0x1F24, Value = 0x0e149220 }, // 133409
    // Darkness
    new() { Offset = 0x1F2C, Value = 0x0e349820 }, // 133507
    new() { Offset = 0x1F34, Value = 0x0e449820 }, // 133508
    new() { Offset = 0x1F3C, Value = 0x0e549820 }, // 133509
    // Zantetsu
    new() { Offset = 0x1F44, Value = 0x0e749e20 }, // 133607
    new() { Offset = 0x1F4C, Value = 0x0e849e20 }, // 133608
    new() { Offset = 0x1F54, Value = 0x0e949e20 }, // 133609
    // Spare Change
    new() { Offset = 0x1F5C, Value = 0x0eb4a420 }, // 133707
    new() { Offset = 0x1F64, Value = 0x0ec4a420 }, // 133708
    new() { Offset = 0x1F6C, Value = 0x0ed4a420 }, // 133709
    // Gamble
    new() { Offset = 0x1F74, Value = 0x0ef4aa20 }, // 133807
    new() { Offset = 0x1F7C, Value = 0x0e04ab20 }, // 133808
    new() { Offset = 0x1F84, Value = 0x0e14ab20 }, // 133809
    // Tantalize?
    new() { Offset = 0x1F8C, Value = 0x0e34b120 }, // 133907 - "It's worth a shot"
    new() { Offset = 0x1F94, Value = 0x0e44b120 }, // 133908 - "Here goes"
    new() { Offset = 0x1F9C, Value = 0x0e54b120 }, // 133909 - "Charmed, I'm sure"
    // Pre-Sing
    new() { Offset = 0x1FA4, Value = 0x0e94b720 }, // 134009
    new() { Offset = 0x1FAC, Value = 0x0ea4b720 }, // 134010
    new() { Offset = 0x1FB4, Value = 0x0eb4b720 }, // 134011
    // Sing
    new() { Offset = 0x1D6C, Value = 0x0e14b820 }, // 134017
    new() { Offset = 0x1D74, Value = 0x0e24b820 }, // 134018
    // Dance
    new() { Offset = 0x1FBC, Value = 0x0eb4bd20 }, // 134107
    new() { Offset = 0x1FC4, Value = 0x0ec4bd20 }, // 134108
    new() { Offset = 0x1FCC, Value = 0x0ed4bd20 }, // 134109
    // Flurry
    new() { Offset = 0x1FD4, Value = 0x0ef4c320 }, // 134207 - "Make your master proud"
    new() { Offset = 0x1FDC, Value = 0x0e04c420 }, // 134208 - "Hurt!"
    new() { Offset = 0x1FE4, Value = 0x0e14c420 }, // 134209 - "Do your worst"
    // Flurry?
    new() { Offset = 0x1FEC, Value = 0x0e34ca20 }, // 134307
    new() { Offset = 0x1FF4, Value = 0x0e44ca20 }, // 134308
    new() { Offset = 0x1FFC, Value = 0x0e54ca20 }, // 134309
    // Maulwings!
    new() { Offset = 0x2004, Value = 0x0e74d020 }, // 134407 - "You have your pecking orders!"
    new() { Offset = 0x200C, Value = 0x0e84d020 }, // 134408 - "Flock together, and hurt!"
    new() { Offset = 0x2014, Value = 0x0e94d020 }, // 134409 - "Leave some for your friends!"
    // Sword Dance
    new() { Offset = 0x201C, Value = 0x0ee4d620 }, // 134510 - "Now you've made me angry!"
    new() { Offset = 0x2024, Value = 0x0ef4d620 }, // 134511 - "Your luck's just ran out!"
    new() { Offset = 0x202C, Value = 0x0e04d720 }, // 134512 - "Meet pain on a whole new level"
    // (no purpose listed)
    new() { Offset = 0x2034, Value = 0x0ef4dc20 }, // 134607
    new() { Offset = 0x203C, Value = 0x0e04dd20 }, // 134608
    new() { Offset = 0x2044, Value = 0x0e14dd20 }, // 134609
    // Flare
    new() { Offset = 0x204C, Value = 0x0e34e320 }, // 134707
    new() { Offset = 0x2054, Value = 0x0e44e320 }, // 134708
    new() { Offset = 0x205C, Value = 0x0e54e320 }, // 134709
    // Holy
    new() { Offset = 0x2064, Value = 0x0e74e920 }, // 134807
    new() { Offset = 0x206C, Value = 0x0e84e920 }, // 134808
    new() { Offset = 0x2074, Value = 0x0e94e920 }, // 134809
    // Ultima
    new() { Offset = 0x207C, Value = 0x0eb4ef20 }, // 134907
    new() { Offset = 0x2084, Value = 0x0ec4ef20 }, // 134908
    new() { Offset = 0x208C, Value = 0x0ed4ef20 }, // 134909
    // Into Psychic
    new() { Offset = 0x1B98, Value = 0x0e54fc20 }, // 135109
    new() { Offset = 0x1D0C, Value = 0x0e64fc20 }, // 135110
    new() { Offset = 0x1D14, Value = 0x0e74fc20 }, // 135111
    new() { Offset = 0x1D1C, Value = 0x0e84fc20 }, // 135112
    // Time Trip
    new() { Offset = 0x2094, Value = 0x0e740221 }, // 135207 - "I'm going to have my way with you!"
    new() { Offset = 0x209C, Value = 0x0e840221 }, // 135208 - "Don't move a muscle!"
    new() { Offset = 0x20A4, Value = 0x0e940221 }, // 135209 - "Hold it right there!"
    // Psychic
    new() { Offset = 0x20AC, Value = 0x0eb40821 }, // 135307 - "I'm drawing the line here..."
    new() { Offset = 0x20B4, Value = 0x0ec40821 }, // 135308 - "This fight ends now"
    new() { Offset = 0x20BC, Value = 0x0ed40821 }, // 135309 - "Congratulations, you earned this!"
    // Into Festivalist
    new() { Offset = 0x1B9C, Value = 0x0e140f21 }, // 135409
    new() { Offset = 0x1D24, Value = 0x0e240f21 }, // 135410
    new() { Offset = 0x1D2C, Value = 0x0e340f21 }, // 135411
    new() { Offset = 0x1D34, Value = 0x0e440f21 }, // 135412
    // Festivities
    new() { Offset = 0x20FC, Value = 0x0e341521 }, // 135507 - "Might as well have some fun!"
    new() { Offset = 0x2104, Value = 0x0e441521 }, // 135508 - "The party's just getting started!"
    new() { Offset = 0x27B4, Value = 0x0e541521 }, // 135509 - "Time to pick up the pace!"
    // Using Spinner/Popper/Fountain?
    new() { Offset = 0x20DC, Value = 0x0e941b21 }, // 135609 - "This is kinda fun"
    new() { Offset = 0x20E4, Value = 0x0ea41b21 }, // 135610 - "You know you want it!"
    new() { Offset = 0x20EC, Value = 0x0eb41b21 }, // 135611 - "This'll be a good one!"
    new() { Offset = 0x20F4, Value = 0x0ec41b21 }, // 135612 - "Like fireworks?"
    // Mask
    new() { Offset = 0x20C4, Value = 0x0eb42121 }, // 135707
    new() { Offset = 0x20CC, Value = 0x0ec42121 }, // 135708
    new() { Offset = 0x20D4, Value = 0x0ed42121 }, // 135709
    // Japanese line
    new() { Offset = 0x1E04, Value = 0x0e642221 }, // 135718
    new() { Offset = 0x1E0C, Value = 0x0e742221 }, // 135719
    new() { Offset = 0x1E14, Value = 0x0e842221 }, // 135720 - "Sayonara!"
    new() { Offset = 0x1E1C, Value = 0x0e942221 }, // 135721
    // Battle over
    new() { Offset = 0x2734, Value = 0x0ed44022 }, // 140301
    new() { Offset = 0x273C, Value = 0x0ee44022 }, // 140302
    new() { Offset = 0x2744, Value = 0x0ef44022 }, // 140303
    new() { Offset = 0x274C, Value = 0x0e044122 }, // 140304
    // Battle over (low health)
    new() { Offset = 0x2794, Value = 0x0e945322 }, // 140601
    new() { Offset = 0x279C, Value = 0x0ea45322 }, // 140602
    new() { Offset = 0x27A4, Value = 0x0eb45322 }, // 140603
    new() { Offset = 0x27AC, Value = 0x0ec45322 }, // 140604
    // LM?
    new() { Offset = 0x27EC, Value = 0x0e146022 }, // 140801
    new() { Offset = 0x27F4, Value = 0x0e246022 }, // 140802
    // (no purpose listed)
    new() { Offset = 0x2814, Value = 0x0e646022 }, // 140806
    new() { Offset = 0x281C, Value = 0x0e546622 }, // 140901
    new() { Offset = 0x2824, Value = 0x0e646622 }, // 140902
    new() { Offset = 0x282C, Value = 0x0e746622 }, // 140903
    new() { Offset = 0x2834, Value = 0x0e846622 }, // 140904
    // Game over
    new() { Offset = 0x2500, Value = 0x0e147922 }, // 141201
    new() { Offset = 0x2508, Value = 0x0e247922 }, // 141202
    new() { Offset = 0x2510, Value = 0x0e347922 }, // 141203
    new() { Offset = 0x2518, Value = 0x0e447922 }, // 141204
    // Final boss defeat
    new() { Offset = 0x2564, Value = 0x0e548622 }, // 141413 - "Hmm / Yunie? / Shuyin"
    // (no purpose listed)
    new() { Offset = 0x26C4, Value = 0x0e149222 }, // 141601
    new() { Offset = 0x26CC, Value = 0x0e249222 }, // 141602
    // Battle win
    new() { Offset = 0x267C, Value = 0x0e14ab22 }, // 142001
    new() { Offset = 0x2680, Value = 0x0e24ab22 }, // 142002
    new() { Offset = 0x2684, Value = 0x0e34ab22 }, // 142003
    new() { Offset = 0x2688, Value = 0x0e44ab22 }, // 142004
    new() { Offset = 0x268C, Value = 0x0e54ab22 }, // 142005
    new() { Offset = 0x2690, Value = 0x0e64ab22 }, // 142006
    new() { Offset = 0x2694, Value = 0x0e74ab22 }, // 142007
    new() { Offset = 0x2698, Value = 0x0e84ab22 }, // 142008
    // Trainer win
    new() { Offset = 0x269C, Value = 0x0e94e922 }, // 143001
    new() { Offset = 0x26A0, Value = 0x0ea4e922 }, // 143002
    new() { Offset = 0x26A4, Value = 0x0eb4e922 }, // 143003
    // (no purpose listed)
    new() { Offset = 0x228C, Value = 0x0ed4c835 }, // 220301
    new() { Offset = 0x2294, Value = 0x0ee4c835 }, // 220302
    new() { Offset = 0x229C, Value = 0x0ef4c835 }, // 220303
    new() { Offset = 0x22A4, Value = 0x0e04c935 }, // 220304
    new() { Offset = 0x23AC, Value = 0x0e540736 }, // 221301
    new() { Offset = 0x23B4, Value = 0x0e640736 }, // 221302
    new() { Offset = 0x23BC, Value = 0x0e740736 }, // 221303
    new() { Offset = 0x23C4, Value = 0x0e840736 }, // 221304
    new() { Offset = 0x22F4, Value = 0x0e843936 }, // 222104
    new() { Offset = 0x2314, Value = 0x0ea43f36 }, // 222202
    new() { Offset = 0x232C, Value = 0x0ed43f36 }, // 222205
    new() { Offset = 0x2334, Value = 0x0ee43f36 }, // 222206
    new() { Offset = 0x2414, Value = 0x0e044636 }, // 222304
    new() { Offset = 0x241C, Value = 0x0e144636 }, // 222305
    new() { Offset = 0x2424, Value = 0x0e244636 }, // 222306
    new() { Offset = 0x2354, Value = 0x0e444c36 }, // 222404
    new() { Offset = 0x235C, Value = 0x0e544c36 }, // 222405
    new() { Offset = 0x247C, Value = 0x0e945236 }, // 222505
    new() { Offset = 0x2484, Value = 0x0ea45236 }, // 222506
    new() { Offset = 0x242C, Value = 0x0e947136 }, // 223001
    new() { Offset = 0x2434, Value = 0x0ea47136 }, // 223002
    new() { Offset = 0x243C, Value = 0x0eb47136 }, // 223003
    new() { Offset = 0x1B24, Value = 0x0e043438 }, // 230208
    new() { Offset = 0x1BA0, Value = 0x0e143438 }, // 230209
    new() { Offset = 0x1BA8, Value = 0x0e243438 }, // 230210
    new() { Offset = 0x1BB0, Value = 0x0e343438 }, // 230211
    new() { Offset = 0x1B2C, Value = 0x0e543a38 }, // 230309
    new() { Offset = 0x1BB8, Value = 0x0e643a38 }, // 230310
    new() { Offset = 0x1BC0, Value = 0x0e743a38 }, // 230311
    new() { Offset = 0x1BC8, Value = 0x0e843a38 }, // 230312
    new() { Offset = 0x1B34, Value = 0x0e944038 }, // 230409
    new() { Offset = 0x1BD0, Value = 0x0ea44038 }, // 230410
    new() { Offset = 0x1BD8, Value = 0x0eb44038 }, // 230411
    new() { Offset = 0x1BE0, Value = 0x0ec44038 }, // 230412
    new() { Offset = 0x1B3C, Value = 0x0ec44638 }, // 230508
    new() { Offset = 0x1BE8, Value = 0x0ed44638 }, // 230509
    new() { Offset = 0x1BF0, Value = 0x0ee44638 }, // 230510
    new() { Offset = 0x1BF8, Value = 0x0ef44638 }, // 230511
    new() { Offset = 0x1B44, Value = 0x0e144d38 }, // 230609
    new() { Offset = 0x1C00, Value = 0x0e244d38 }, // 230610
    new() { Offset = 0x1C08, Value = 0x0e344d38 }, // 230611
    new() { Offset = 0x1C10, Value = 0x0e444d38 }, // 230612
    new() { Offset = 0x1C30, Value = 0x0e545338 }, // 230709
    new() { Offset = 0x1C38, Value = 0x0e645338 }, // 230710
    new() { Offset = 0x1C40, Value = 0x0e745338 }, // 230711
    new() { Offset = 0x1B54, Value = 0x0e945938 }, // 230809
    new() { Offset = 0x1C48, Value = 0x0ea45938 }, // 230810
    new() { Offset = 0x1C50, Value = 0x0eb45938 }, // 230811
    new() { Offset = 0x1C58, Value = 0x0ec45938 }, // 230812
    new() { Offset = 0x1B5C, Value = 0x0ed45f38 }, // 230909
    new() { Offset = 0x1C60, Value = 0x0ee45f38 }, // 230910
    new() { Offset = 0x1C68, Value = 0x0ef45f38 }, // 230911
    new() { Offset = 0x1C70, Value = 0x0e046038 }, // 230912
    new() { Offset = 0x1B64, Value = 0x0e146638 }, // 231009
    new() { Offset = 0x1C78, Value = 0x0e246638 }, // 231010
    new() { Offset = 0x1C80, Value = 0x0e346638 }, // 231011
    new() { Offset = 0x1C88, Value = 0x0e446638 }, // 231012
    new() { Offset = 0x1B6C, Value = 0x0e546c38 }, // 231109
    new() { Offset = 0x1C90, Value = 0x0e646c38 }, // 231110
    new() { Offset = 0x1C98, Value = 0x0e746c38 }, // 231111
    new() { Offset = 0x1CA0, Value = 0x0e846c38 }, // 231112
    new() { Offset = 0x1B74, Value = 0x0e947238 }, // 231209
    new() { Offset = 0x1CA8, Value = 0x0ea47238 }, // 231210
    new() { Offset = 0x1CB0, Value = 0x0eb47238 }, // 231211
    new() { Offset = 0x1CB8, Value = 0x0ec47238 }, // 231212
    new() { Offset = 0x1B7C, Value = 0x0ed47838 }, // 231309
    new() { Offset = 0x1CC0, Value = 0x0ee47838 }, // 231310
    new() { Offset = 0x1CC8, Value = 0x0ef47838 }, // 231311
    new() { Offset = 0x1CD0, Value = 0x0e047938 }, // 231312
    new() { Offset = 0x1B84, Value = 0x0e147f38 }, // 231409
    new() { Offset = 0x1CD8, Value = 0x0e247f38 }, // 231410
    new() { Offset = 0x1CE0, Value = 0x0e347f38 }, // 231411
    new() { Offset = 0x1CE8, Value = 0x0e447f38 }, // 231412
    new() { Offset = 0x1B4C, Value = 0x0e548538 }, // 231509
    new() { Offset = 0x1C18, Value = 0x0e648538 }, // 231510
    new() { Offset = 0x1C20, Value = 0x0e748538 }, // 231511
    new() { Offset = 0x1C28, Value = 0x0e848538 }, // 231512
    new() { Offset = 0x1B8C, Value = 0x0e948b38 }, // 231609
    new() { Offset = 0x1CF0, Value = 0x0ea48b38 }, // 231610
    new() { Offset = 0x1CF8, Value = 0x0eb48b38 }, // 231611
    new() { Offset = 0x1D00, Value = 0x0ec48b38 }, // 231612
    new() { Offset = 0x1D78, Value = 0x0ef49138 }, // 231711
    new() { Offset = 0x1D80, Value = 0x0e049238 }, // 231712
    new() { Offset = 0x1D88, Value = 0x0e149238 }, // 231713
    new() { Offset = 0x1D90, Value = 0x0e249238 }, // 231714
    new() { Offset = 0x1D98, Value = 0x0e349238 }, // 231715
    new() { Offset = 0x1DA0, Value = 0x0ef49738 }, // 231807
    new() { Offset = 0x1DA8, Value = 0x0e049838 }, // 231808
    new() { Offset = 0x1DB0, Value = 0x0e149838 }, // 231809
    new() { Offset = 0x1DB8, Value = 0x0e349e38 }, // 231907
    new() { Offset = 0x1DC0, Value = 0x0e449e38 }, // 231908
    new() { Offset = 0x1DC8, Value = 0x0e549e38 }, // 231909
    new() { Offset = 0x1DD0, Value = 0x0ed4a438 }, // 232013
    new() { Offset = 0x1DD8, Value = 0x0ee4a438 }, // 232014
    new() { Offset = 0x1DE0, Value = 0x0ef4a438 }, // 232015
    new() { Offset = 0x1DE8, Value = 0x0e04a538 }, // 232016
    new() { Offset = 0x1DF0, Value = 0x0e14a538 }, // 232017
    new() { Offset = 0x1DF8, Value = 0x0e24a538 }, // 232018
    new() { Offset = 0x1E20, Value = 0x0eb4aa38 }, // 232107
    new() { Offset = 0x1E28, Value = 0x0ec4aa38 }, // 232108
    new() { Offset = 0x1E30, Value = 0x0ed4aa38 }, // 232109
    new() { Offset = 0x1E38, Value = 0x0ef4b038 }, // 232207
    new() { Offset = 0x1E40, Value = 0x0e04b138 }, // 232208
    new() { Offset = 0x1E48, Value = 0x0e14b138 }, // 232209
    new() { Offset = 0x1E50, Value = 0x0e34b738 }, // 232307
    new() { Offset = 0x1E58, Value = 0x0e44b738 }, // 232308
    new() { Offset = 0x1E60, Value = 0x0e54b738 }, // 232309
    new() { Offset = 0x1E68, Value = 0x0e74bd38 }, // 232407
    new() { Offset = 0x1E70, Value = 0x0e84bd38 }, // 232408
    new() { Offset = 0x1E78, Value = 0x0e94bd38 }, // 232409
    new() { Offset = 0x1E80, Value = 0x0eb4c338 }, // 232507
    new() { Offset = 0x1E88, Value = 0x0ec4c338 }, // 232508
    new() { Offset = 0x1E90, Value = 0x0ed4c338 }, // 232509
    new() { Offset = 0x1E98, Value = 0x0ef4c938 }, // 232607
    new() { Offset = 0x1EA0, Value = 0x0e04ca38 }, // 232608
    new() { Offset = 0x1EA8, Value = 0x0e14ca38 }, // 232609
    new() { Offset = 0x1EB0, Value = 0x0e34d038 }, // 232707
    new() { Offset = 0x1EB8, Value = 0x0e44d038 }, // 232708
    new() { Offset = 0x1EC0, Value = 0x0e54d038 }, // 232709
    new() { Offset = 0x1D38, Value = 0x0e74d638 }, // 232807
    new() { Offset = 0x1D40, Value = 0x0e84d638 }, // 232808
    new() { Offset = 0x1D48, Value = 0x0e94d638 }, // 232809
    new() { Offset = 0x1D50, Value = 0x0eb4dc38 }, // 232907
    new() { Offset = 0x1D58, Value = 0x0ec4dc38 }, // 232908
    new() { Offset = 0x1D60, Value = 0x0ed4dc38 }, // 232909
    new() { Offset = 0x2108, Value = 0x0ef4e238 }, // 233007
    new() { Offset = 0x2110, Value = 0x0e04e338 }, // 233008
    new() { Offset = 0x2118, Value = 0x0e14e338 }, // 233009
    new() { Offset = 0x1EC8, Value = 0x0e34e938 }, // 233107
    new() { Offset = 0x1ED0, Value = 0x0e44e938 }, // 233108
    new() { Offset = 0x1ED8, Value = 0x0e54e938 }, // 233109
    new() { Offset = 0x1EE0, Value = 0x0e74ef38 }, // 233207
    new() { Offset = 0x1EE8, Value = 0x0e84ef38 }, // 233208
    new() { Offset = 0x1EF0, Value = 0x0e94ef38 }, // 233209
    new() { Offset = 0x1EF8, Value = 0x0eb4f538 }, // 233307
    new() { Offset = 0x1F00, Value = 0x0ec4f538 }, // 233308
    new() { Offset = 0x1F08, Value = 0x0ed4f538 }, // 233309
    new() { Offset = 0x1F10, Value = 0x0ef4fb38 }, // 233407
    new() { Offset = 0x1F18, Value = 0x0e04fc38 }, // 233408
    new() { Offset = 0x1F20, Value = 0x0e14fc38 }, // 233409
    new() { Offset = 0x1F28, Value = 0x0e340239 }, // 233507
    new() { Offset = 0x1F30, Value = 0x0e440239 }, // 233508
    new() { Offset = 0x1F38, Value = 0x0e540239 }, // 233509
    new() { Offset = 0x1F40, Value = 0x0e740839 }, // 233607
    new() { Offset = 0x1F48, Value = 0x0e840839 }, // 233608
    new() { Offset = 0x1F50, Value = 0x0e940839 }, // 233609
    new() { Offset = 0x1F58, Value = 0x0eb40e39 }, // 233707
    new() { Offset = 0x1F60, Value = 0x0ec40e39 }, // 233708
    new() { Offset = 0x1F68, Value = 0x0ed40e39 }, // 233709
    new() { Offset = 0x1F70, Value = 0x0ef41439 }, // 233807
    new() { Offset = 0x1F78, Value = 0x0e041539 }, // 233808
    new() { Offset = 0x1F80, Value = 0x0e141539 }, // 233809
    new() { Offset = 0x1F88, Value = 0x0e341b39 }, // 233907
    new() { Offset = 0x1F90, Value = 0x0e441b39 }, // 233908
    new() { Offset = 0x1F98, Value = 0x0e541b39 }, // 233909
    new() { Offset = 0x1FA0, Value = 0x0e942139 }, // 234009
    new() { Offset = 0x1FA8, Value = 0x0ea42139 }, // 234010
    new() { Offset = 0x1FB0, Value = 0x0eb42139 }, // 234011
    new() { Offset = 0x1D68, Value = 0x0e142239 }, // 234017
    new() { Offset = 0x1D70, Value = 0x0e242239 }, // 234018
    new() { Offset = 0x1FB8, Value = 0x0eb42739 }, // 234107
    new() { Offset = 0x1FC0, Value = 0x0ec42739 }, // 234108
    new() { Offset = 0x1FC8, Value = 0x0ed42739 }, // 234109
    new() { Offset = 0x1FD0, Value = 0x0ef42d39 }, // 234207
    new() { Offset = 0x1FD8, Value = 0x0e042e39 }, // 234208
    new() { Offset = 0x1FE0, Value = 0x0e142e39 }, // 234209
    new() { Offset = 0x1FE8, Value = 0x0e343439 }, // 234307
    new() { Offset = 0x1FF0, Value = 0x0e443439 }, // 234308
    new() { Offset = 0x1FF8, Value = 0x0e543439 }, // 234309
    new() { Offset = 0x2000, Value = 0x0e743a39 }, // 234407
    new() { Offset = 0x2008, Value = 0x0e843a39 }, // 234408
    new() { Offset = 0x2010, Value = 0x0e943a39 }, // 234409
    new() { Offset = 0x2018, Value = 0x0ee44039 }, // 234510
    new() { Offset = 0x2020, Value = 0x0ef44039 }, // 234511
    new() { Offset = 0x2028, Value = 0x0e044139 }, // 234512
    new() { Offset = 0x2030, Value = 0x0ef44639 }, // 234607
    new() { Offset = 0x2038, Value = 0x0e044739 }, // 234608
    new() { Offset = 0x2040, Value = 0x0e144739 }, // 234609
    new() { Offset = 0x2048, Value = 0x0e344d39 }, // 234707
    new() { Offset = 0x2050, Value = 0x0e444d39 }, // 234708
    new() { Offset = 0x2058, Value = 0x0e544d39 }, // 234709
    new() { Offset = 0x2060, Value = 0x0e745339 }, // 234807
    new() { Offset = 0x2068, Value = 0x0e845339 }, // 234808
    new() { Offset = 0x2070, Value = 0x0e945339 }, // 234809
    new() { Offset = 0x2078, Value = 0x0eb45939 }, // 234907
    new() { Offset = 0x2080, Value = 0x0ec45939 }, // 234908
    new() { Offset = 0x2088, Value = 0x0ed45939 }, // 234909
    new() { Offset = 0x1B94, Value = 0x0e546639 }, // 235109
    new() { Offset = 0x1D08, Value = 0x0e646639 }, // 235110
    new() { Offset = 0x1D10, Value = 0x0e746639 }, // 235111
    new() { Offset = 0x1D18, Value = 0x0e846639 }, // 235112
    new() { Offset = 0x2090, Value = 0x0e746c39 }, // 235207
    new() { Offset = 0x2098, Value = 0x0e846c39 }, // 235208
    new() { Offset = 0x20A0, Value = 0x0e946c39 }, // 235209
    new() { Offset = 0x20A8, Value = 0x0eb47239 }, // 235307
    new() { Offset = 0x20B0, Value = 0x0ec47239 }, // 235308
    new() { Offset = 0x20B8, Value = 0x0ed47239 }, // 235309
    new() { Offset = 0x1D20, Value = 0x0e247939 }, // 235410
    new() { Offset = 0x1D28, Value = 0x0e347939 }, // 235411
    new() { Offset = 0x1D30, Value = 0x0e447939 }, // 235412
    new() { Offset = 0x20F8, Value = 0x0e347f39 }, // 235507
    new() { Offset = 0x2100, Value = 0x0e447f39 }, // 235508
    new() { Offset = 0x27B0, Value = 0x0e547f39 }, // 235509
    new() { Offset = 0x20D8, Value = 0x0e948539 }, // 235609
    new() { Offset = 0x20E0, Value = 0x0ea48539 }, // 235610
    new() { Offset = 0x20E8, Value = 0x0eb48539 }, // 235611
    new() { Offset = 0x20F0, Value = 0x0ec48539 }, // 235612
    new() { Offset = 0x20C0, Value = 0x0eb48b39 }, // 235707
    new() { Offset = 0x20C8, Value = 0x0ec48b39 }, // 235708
    new() { Offset = 0x20D0, Value = 0x0ed48b39 }, // 235709
    new() { Offset = 0x1E00, Value = 0x0e648c39 }, // 235718
    new() { Offset = 0x1E08, Value = 0x0e748c39 }, // 235719
    new() { Offset = 0x1E10, Value = 0x0e848c39 }, // 235720
    new() { Offset = 0x1E18, Value = 0x0e948c39 }, // 235721
    new() { Offset = 0x2730, Value = 0x0ed4aa3a }, // 240301
    new() { Offset = 0x2738, Value = 0x0ee4aa3a }, // 240302
    new() { Offset = 0x2740, Value = 0x0ef4aa3a }, // 240303
    new() { Offset = 0x2748, Value = 0x0e04ab3a }, // 240304
    new() { Offset = 0x2790, Value = 0x0e94bd3a }, // 240601
    new() { Offset = 0x2798, Value = 0x0ea4bd3a }, // 240602
    new() { Offset = 0x27A0, Value = 0x0eb4bd3a }, // 240603
    new() { Offset = 0x27A8, Value = 0x0ec4bd3a }, // 240604
    new() { Offset = 0x27E8, Value = 0x0e14ca3a }, // 240801
    new() { Offset = 0x27F0, Value = 0x0e24ca3a }, // 240802
    new() { Offset = 0x2810, Value = 0x0e64ca3a }, // 240806
    new() { Offset = 0x2818, Value = 0x0e54d03a }, // 240901
    new() { Offset = 0x2820, Value = 0x0e64d03a }, // 240902
    new() { Offset = 0x2828, Value = 0x0e74d03a }, // 240903
    new() { Offset = 0x2830, Value = 0x0e84d03a }, // 240904
    new() { Offset = 0x24FC, Value = 0x0e14e33a }, // 241201
    new() { Offset = 0x2504, Value = 0x0e24e33a }, // 241202
    new() { Offset = 0x250C, Value = 0x0e34e33a }, // 241203
    new() { Offset = 0x2514, Value = 0x0e44e33a }, // 241204
    new() { Offset = 0x26C0, Value = 0x0e14fc3a }, // 241601
    new() { Offset = 0x26C8, Value = 0x0e24fc3a }, // 241602
];

}
