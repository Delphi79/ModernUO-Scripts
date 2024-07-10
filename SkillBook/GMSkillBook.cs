/****************************************
 * Author: Unkown                       *
 * Revised for MUO: Delphi              *
 * For use with ModernUO                *
 * Client Tested with: 7.0.102.3        *
 * Revision Date: 06/07/2024            *
 **************************************/

using System;
using Server.Items;
using Server.Network;
using Server.Gumps;
using System.Collections.Generic;

namespace Server
{
    public class SkillPickGump : Gump
    {


        public const int NumberOfSkills = 3 ;       // Number of skills you want the player to add
        private const int SkillCapValue = 700;      // Players Skill cap value
        private int m_SelectionsMade;
        private List<SkillName> m_SelectedSkills;

        private void AddSkillItems(Mobile m, SkillData skillData)
        {
            Container pack = m.Backpack;

            if (pack == null)
                return;

            foreach (Item item in skillData.Items)
            {
                pack.DropItem(item);
            }
        }

        private SkillBook  m_SkillBook;

        public SkillPickGump(SkillBook book, int selectionsMade, List<SkillName> selectedSkills) : base(0, 0)
        {
            m_SelectedSkills = [..selectedSkills]; // Deep copy the list to avoid modifying the original list
            m_SelectedSkills = selectedSkills;

            this.Closable=true;
            this.Disposable=true;
            this.Draggable=true;
            this.Resizable=true;

            m_SkillBook = book;
            m_SelectionsMade = selectionsMade;

            AddPage(0);
            AddBackground(39, 33, 563, 470, 2620);
            AddLabel(67, 41, 1153, $"Select {m_SkillBook.RemainingSkills} starting skills for your character.");
            AddLabel(55, 472, 1153, $"| {NumberOfSkills}X GM SKILLBOOK | UO : SHARD NAME HERE |");
            AddButton(460, 470, 2119, 2120, (int)Buttons.Close);
            AddBackground(52, 60, 539, 407, 9350);
            AddImage(488, 338, 9000);
            AddPage(1);
            AddButton(530, 470, 2128, 2129, (int)Buttons.FinishButton);

            //********************************************************
            AddLabel(80, 65, 0, @"Alchemy");              //1
            AddCheck(55, 65, 210, 211, false, 1);         //Alchemy
            AddLabel(80, 90, 0, @"Anatomy");              //2
            AddCheck(55, 90, 210, 211, false, 2);         //Anatomy
            AddLabel(80, 115, 0, @"Animal Lore");         //3
            AddCheck(55, 115, 210, 211, false, 3);        //Animal Lore
            AddLabel(80, 140, 0, @"Animal Taming");       //4
            AddCheck(55, 140, 210, 211, false, 4);        //Animal Taming
            AddLabel(80, 165, 0, @"Archery");             //5
            AddCheck(55, 165, 210, 211, false, 5);        //Archery
            AddLabel(80, 190, 0, @"Arms Lore");           //6
            AddCheck(55, 190, 210, 211, false, 6);        //Arms Lore
            AddLabel(80, 215, 0, @"Begging");             //7
            AddCheck(55, 215, 210, 211, false, 7);        //Begging
            AddLabel(80, 240, 0, @"Blacksmithing");       //8
            AddCheck(55, 240, 210, 211, false, 8);        //Blacksmithing
            AddLabel(80, 265, 0, @"Camping");             //9
            AddCheck(55, 265, 210, 211, false, 9);        //Camping
            AddLabel(80, 290, 0, @"Carpentry");           //10
            AddCheck(55, 290, 210, 211, false, 10);       //Carpentry
            AddLabel(80, 315, 0, @"Cartography");         //11
            AddCheck(55, 315, 210, 211, false, 11);       //Cartography
            AddLabel(80, 340, 0, @"Cooking");             //12
            AddCheck(55, 340, 210, 211, false, 12);       //Cooking
            AddLabel(80, 365, 0, @"Detecting Hidden");    //13
            AddCheck(55, 365, 210, 211, false, 13);       //Detecting Hidden
            AddLabel(80, 390, 0, @"Discordance");         //14
            AddCheck(55, 390, 210, 211, false, 14);       //Discordance
            AddLabel(80, 415, 0, @"Evaluating Int");      //15
            AddCheck(55, 415, 210, 211, false, 15);       //Evaluating Int
            AddLabel(80, 440, 0, @"Fencing");             //16
            AddCheck(55, 440, 210, 211, false, 16);       //Fencing
            AddLabel(225, 65, 0, @"Fishing");             //17
            AddCheck(200, 65, 210, 211, false, 17);       //Fishing
            AddLabel(225, 90, 0, @"Fletching");           //18
            AddCheck(200, 90, 210, 211, false, 18);       //Fletching
            AddLabel(225, 115, 0, @"Foresic Evaluation"); //19
            AddCheck(200, 115, 210, 211, false, 19);      //Foresic Evaluation
            AddLabel(225, 140, 0, @"Healing");            //20
            AddCheck(200, 140, 210, 211, false, 20);      //Healing
            AddLabel(225, 165, 0, @"Herding");            //21
            AddCheck(200, 165, 210, 211, false, 21);      //Herding
            AddLabel(225, 190, 0, @"Hiding");             //22
            AddCheck(200, 190, 210, 211, false, 22);      //Hiding
            AddLabel(225, 215, 0, @"Inscription");        //23
            AddCheck(200, 215, 210, 211, false, 23);      //Inscription
            AddLabel(225, 240, 0, @"Item Ident");         //24
            AddCheck(200, 240, 210, 211, false, 24);      //Item Ident
            AddLabel(225, 265, 0, @"Lockpicking");        //25
            AddCheck(200, 265, 210, 211, false, 25);      //Lockpicking
            AddLabel(225, 290, 0, @"Lumberjacking");      //26
            AddCheck(200, 290, 210, 211, false, 26);      //Lumberjacking
            AddLabel(225, 315, 0, @"Macefighting");       //27
            AddCheck(200, 315, 210, 211, false, 27);      //Macefighting
            AddLabel(225, 340, 0, @"Magery");             //28
            AddCheck(200, 340, 210, 211, false, 28);      //Magery
            AddLabel(225, 365, 0, @"Mining");             //29
            AddCheck(200, 365, 210, 211, false, 29);      //Mining
            AddLabel(225, 390, 0, @"Musicianship");       //30
            AddCheck(200, 390, 210, 211, false, 30);      //Musicianship
            AddLabel(225, 415, 0, @"Parry");              //31
            AddCheck(200, 415, 210, 211, false, 31);      //Parry
            AddLabel(225, 440, 0, @"Peacemaking");        //32
            AddCheck(200, 440, 210, 211, false, 32);      //Peacemaking
            AddLabel(370, 65, 0, @"Poisoning");           //33
            AddCheck(345, 65, 210, 211, false, 33);       //Poisoning
            AddLabel(370, 90, 0, @"Provocation");         //34
            AddCheck(345, 90, 210, 211, false, 34);       //Provocation
            AddLabel(370, 115, 0, @"Remove Trap");        //35
            AddCheck(345, 115, 210, 211, false, 35);      //Remove Trap
            AddLabel(370, 140, 0, @"Resisting Spells");   //36
            AddCheck(345, 140, 210, 211, false, 36);      //Resisting Spells
            AddLabel(370, 165, 0, @"Snooping");           //37
            AddCheck(345, 165, 210, 211, false, 37);      //Snooping
            AddLabel(370, 190, 0, @"Spirit Speak");       //38
            AddCheck(345, 190, 210, 211, false, 38);      //Spirit Speak
            AddLabel(370, 215, 0, @"Stealing");           //39
            AddCheck(345, 215, 210, 211, false, 39);      //Stealing
            AddLabel(370, 240, 0, @"Stealth");            //40
            AddCheck(345, 240, 210, 211, false, 40);      //Stealth
            AddLabel(370, 265, 0, @"Swordsmanship");      //41
            AddCheck(345, 265, 210, 211, false, 41);      //Swordsmanship
            AddLabel(370, 290, 0, @"Tactics");            //42
            AddCheck(345, 290, 210, 211, false, 42);      //Tactics
            AddLabel(370, 315, 0, @"Tailoring");          //43
            AddCheck(345, 315, 210, 211, false, 43);      //Tailoring
            AddLabel(370, 340, 0, @"Taste Ident");        //44
            AddCheck(345, 340, 210, 211, false, 44);      //Taste Ident
            AddLabel(370, 365, 0, @"Tinkering");          //45
            AddCheck(345, 365, 210, 211, false, 45);      //Tinkering
            AddLabel(370, 390, 0, @"Tracking");           //46
            AddCheck(345, 390, 210, 211, false, 46);      //Tracking
            AddLabel(370, 415, 0, @"Veterinary");         //47
            AddCheck(345, 415, 210, 211, false, 47);      //Veterinary
            AddLabel(370, 440, 0, @"Wrestling");          //48
            AddCheck(345, 440, 210, 211, false, 48);      //Wrestling

            //Add more skills here

            //**********************************************************
        }

        public enum Buttons
        {
            Close,
            FinishButton,
        }

        private void AdjustSkillsToCapForPlayer(Mobile m, int skillCapValue, List<SkillName> selectedSkills)
        {
            int totalSkillPoints;
            int excessPoints;

            // Set all non-selected skills to zero
            foreach (Skill skill in m.Skills)
            {
                if (!selectedSkills.Contains(skill.SkillName))
                {
                    skill.Base = 0;
                }
            }

            // Update totalSkillPoints after setting non-selected skills to zero
            totalSkillPoints = m.SkillsTotal / 10;
            excessPoints = totalSkillPoints - skillCapValue;

            // If excessPoints is still greater than 0 after setting non-selected skills to zero,
            // reduce selected skills proportionally
            if (excessPoints > 0)
            {
                double reductionFactor = 1.0 - excessPoints / (double)totalSkillPoints;
                foreach (Skill skill in m.Skills)
                {
                    if (selectedSkills.Contains(skill.SkillName))
                    {
                        skill.Base *= reductionFactor;
                    }
                }
            }
        }

        public class SkillData
        {
            public SkillName Skill { get; }
            public int SwitchId { get; }
            public List<Item> Items { get; }

            public SkillData(SkillName skill, int switchId, Func<List<Item>> createItems)
            {
                Skill = skill;
                SwitchId = switchId;
                Items = createItems();
            }
        }

        public override void OnResponse(NetState state, in RelayInfo info)
        {
            Mobile m = state.Mobile;

            SkillData[] skillsData =
            [
                // Your SkillData array
                new SkillData(SkillName.Alchemy, 1, () => []),
                new SkillData(SkillName.Anatomy, 2, () => []),
                new SkillData(SkillName.AnimalLore, 3, () => []),
                new SkillData(SkillName.AnimalTaming, 4, () => []),
                new SkillData(SkillName.Archery, 5, () => []),
                new SkillData(SkillName.ArmsLore, 6, () => []),
                new SkillData(SkillName.Begging, 7, () => []),
                new SkillData(SkillName.Blacksmith, 8, () => []),
                new SkillData(SkillName.Camping, 9, () => []),
                new SkillData(SkillName.Carpentry, 10, () => []),
                new SkillData(SkillName.Cartography, 11, () => []),
                new SkillData(SkillName.Cooking, 12, () => []),
                new SkillData(SkillName.DetectHidden, 13, () => []),
                new SkillData(SkillName.Discordance, 14, () => []),
                new SkillData(SkillName.EvalInt, 15, () => []),
                new SkillData(SkillName.Fencing, 16, () => []),
                new SkillData(SkillName.Fishing, 17, () => []),
                new SkillData(SkillName.Fletching, 18, () => []),
                new SkillData(SkillName.Forensics, 19, () => []),
                new SkillData(SkillName.Healing, 20, () => []),
                new SkillData(SkillName.Herding, 21, () => []),
                new SkillData(SkillName.Hiding, 22, () => []),
                new SkillData(SkillName.Inscribe, 23, () => []),
                new SkillData(SkillName.ItemID, 24, () => []),
                new SkillData(SkillName.Lockpicking, 25, () => []),
                new SkillData(SkillName.Lumberjacking, 26, () => []),
                new SkillData(SkillName.Macing, 27, () => []),
                new SkillData(SkillName.Magery, 28, () => []),
                new SkillData(SkillName.Mining, 29, () => []),
                new SkillData(SkillName.Musicianship, 30, () => []),
                new SkillData(SkillName.Parry, 31, () => []),
                new SkillData(SkillName.Peacemaking, 32, () => []),
                new SkillData(SkillName.Poisoning, 33, () => []),
                new SkillData(SkillName.Provocation, 34, () => []),
                new SkillData(SkillName.RemoveTrap, 35, () => []),
                new SkillData(SkillName.MagicResist, 36, () => []),
                new SkillData(SkillName.Snooping, 37, () => []),
                new SkillData(SkillName.SpiritSpeak, 38, () => []),
                new SkillData(SkillName.Stealing, 39, () => []),
                new SkillData(SkillName.Stealth, 40, () => []),
                new SkillData(SkillName.Swords, 41, () => []),
                new SkillData(SkillName.Tactics, 42, () => []),
                new SkillData(SkillName.Tailoring, 43, () => []),
                new SkillData(SkillName.TasteID, 44, () => []),
                new SkillData(SkillName.Tinkering, 45, () => []),
                new SkillData(SkillName.Tracking, 46, () => []),
                new SkillData(SkillName.Veterinary, 47, () => []),
                new SkillData(SkillName.Wrestling, 48, () => [])

            ];

            switch (info.ButtonID)
            {
                case 0:
                    break;
                case 1:
                    {
                        int val = 100;
                        int selectedSkills = 0;
                        List<SkillName> selectedSkillNames = [];

                        foreach (var skillData in skillsData)
                        {
                            if (info.IsSwitched(skillData.SwitchId))
                            {
                                selectedSkills++;
                                selectedSkillNames.Add(skillData.Skill);
                            }
                        }

                        if (selectedSkills > m_SkillBook.RemainingSkills)
                        {
                            m.SendGump(new SkillPickGump(m_SkillBook, m_SelectionsMade + 1, m_SelectedSkills));
                            m.SendMessage(0, $"Please get rid of {selectedSkills - m_SkillBook.RemainingSkills} skills, you have exceeded the {NumberOfSkills} skills that are allowed.");
                            break;
                        }

                        foreach (var skillData in skillsData)
                        {
                            //if (info.IsSwitched(skillData.SwitchId) && !m_SelectedSkills.Contains(skillData.Skill))
                            if (!m_SelectedSkills.Contains(skillData.Skill))
                            {
                                if (info.IsSwitched(skillData.SwitchId))
                                {
                                    m.Skills[skillData.Skill].Base = val;
                                    AddSkillItems(m, skillData);
                                    m_SelectedSkills.Add(skillData.Skill);
                                    m_SkillBook.RemainingSkills--; // Only decrement RemainingSkills when a new skill is selected
                                }
                            }
                            else
                            {
                                if (info.IsSwitched(skillData.SwitchId))
                                {
                                    m.SendMessage("You have already selected this skill.");
                                }
                            }

                        }

                        // Ensure the player's skills do not exceed the skill cap value
                        if (m.AccessLevel == AccessLevel.Player)
                        {
                            AdjustSkillsToCapForPlayer(m, SkillCapValue, m_SelectedSkills);
                        }

                        //AdjustSkillsToCap(m, SkillCapValue, m_SelectedSkills);
                        if (m_SkillBook.RemainingSkills > 0)
                        {
                            m.SendGump(new SkillPickGump(m_SkillBook, m_SelectionsMade, m_SelectedSkills));
                            m.SendMessage(0, $"You have {m_SkillBook.RemainingSkills} remaining skills to select.");
                            m.CloseGump<SkillPickGump>();
                        }
                        else
                        {
                            m.SendMessage("All remaining skills have been selected.");
                            m_SkillBook.Delete(); // Delete the book when remaining skills are 0
                        }

                        break;
                    }
            }

        }
    }

    public class SkillBook : Item
    {
        private int m_RemainingSkills;
        private int m_NumberOfSkills;

        public List<SkillName> SelectedSkills { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public int RemainingSkills
        {
            get { return m_RemainingSkills; }
            set { m_RemainingSkills = value; }
        }

        [Constructible]
        public SkillBook() : base(0xEFA)
        {
            Weight = 1.0;
            Hue = 63;
            Name = "a mysterious book";
            Movable = false;


            m_RemainingSkills = SkillPickGump.NumberOfSkills;
            m_NumberOfSkills = SkillPickGump.NumberOfSkills;

            SelectedSkills = [];

        }

        public override void OnDoubleClick(Mobile m)
        {
            if (m.Backpack != null && m.Backpack.GetAmount(typeof(SkillBook)) > 0)
            {
                int selectionsMade = m_NumberOfSkills - m_RemainingSkills;
                m.SendMessage($"Please choose your remaining {m_RemainingSkills} starting skills to boost.");
                m.CloseGump<SkillPickGump>();
                m.SendGump(new SkillPickGump(this, selectionsMade, SelectedSkills)); // Use SkillBook's SelectedSkills property
            }
            else
            {
                m.SendMessage("This must be in your backpack to function.");
            }
        }

        public SkillBook( Serial serial ) : base( serial )
        {
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(1); // version

            // Save the RemainingSkills value
            writer.Write(m_RemainingSkills);
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

            // Load the RemainingSkills value for version 1
            if (version >= 1)
            {
                m_RemainingSkills = reader.ReadInt();
            }
        }
    }
}
