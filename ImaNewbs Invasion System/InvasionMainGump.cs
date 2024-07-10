/**********************************************
* Script Name: InvasionSettings.cs            *
 * ReWritten by ImaNewb Aka Delphi            *
 * Original Author: RavenWolfe (for ServUO)   *
 * For use with ModernUO                      *
 * Date: June 17, 2024                        *
 * ========================================== *
 * Special thanks to Ravenwolfe, Mr, Batman   *
 * and Voxspire                               *
 **********************************************/

using System;
using Server.Gumps;
using Server.Network;

namespace Server.Customs.Invasion_System
{
    public static class InvasionMainGumpHandler
    {
        public static void Initialize()
        {
            CommandSystem.Register("InvasionSystem", AccessLevel.Administrator, InvasionMainGump_OnCommand);
        }

        [Usage("InvasionSystem")]
        [Description("Opens the Invasion System gump.")]
        public static void InvasionMainGump_OnCommand(CommandEventArgs e)
        {
            var from = e.Mobile;
            from.SendGump(new InvasionMainGump(from));
        }
    }

    public sealed class InvasionMainGump : Gump
    {
        private const int SelectedColor32 = 0x8080FF; //Button Selected Color
        private const int WhiteColor32 = 0xFFFFFF;    // White color for labels
        private const int YellowColor32 = 0xFFFF00;   // Yellow color for specific labels
        private const int RedColor32 = 0xFF0000;      // Red color for specific labels
        private const int GreenColor32 = 0x55E118;    //Green color for specific labels
        private const int OrangeColor32 = 0xFF8200;   //Green color for specific labels
        private const int SkyBlueColor32 = 0x05C3F9;  //Green color for specific labels

        public InvasionTowns SelectedTown;
        public TownMonsterType SelectedMonster;
        public TownChampionType SelectedChamp;
        public InvasionMap SelectedMap;

        public InvasionMainGump(Mobile caller, InvasionTowns selectedTown = InvasionTowns.None, TownMonsterType selectedMonster = TownMonsterType.None, TownChampionType selectedChamp = TownChampionType.None, InvasionMap selectedMap = InvasionMap.None)
            : base(50, 50)
        {
            Closable = true;
            Draggable = true;

            SelectedTown = selectedTown;
            SelectedMonster = selectedMonster;
            SelectedChamp = selectedChamp;
            SelectedMap = selectedMap;

            AddPage(0);

            AddBackground(0, 0, 600, 510, 5054); //Border Size +20
            AddBlackAlpha(10, 10, 580, 490);     //Alpha Size -20
            AddHtml(115, 12, 350, 20, "ImaNewb's Town Invasion".Center(OrangeColor32), false, false);

            //+160 TextEntry and Tiled
            AddHtml(20, 105, 150, 20, "Invasion Schedule (UTC):".Color(GreenColor32), false, false);
            AddImageTiled(180, 105, 150, 20, 0xBBC);
            AddTextEntry(180, 105, 148, 20, WhiteColor32, 5, DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), 22);

            AddHtml(20, 135, 100, 20, "Invasion City".Color(SkyBlueColor32), false, false);
            AddHtml(180, 135, 150, 20, "Invasion Monster".Color(SkyBlueColor32), false, false);
            AddHtml(340, 135, 100, 20, "Invasion Champion".Color(SkyBlueColor32), false, false);
            AddHtml(500, 135, 100, 20, "Invasion Map".Color(SkyBlueColor32), false, false);

            // Adding map selection buttons
            AddMapButtons();

            // Adding city buttons
            AddCityButtons();

            // Adding monster type buttons
            AddMonsterTypeButtons();

            // Adding champion buttons
            AddChampionButtons();

            // OK and Cancel buttons
            AddButton(500, 470, 0xFB7, 0xFB8, 1); // OK button
            AddButton(540, 470, 0xFB1, 0xFB2, 0); // Cancel button (30 pixels gap)
        }

        private void AddCityButtons()
        {
            foreach (InvasionTowns town in Enum.GetValues(typeof(InvasionTowns)))
            {
                if (town == InvasionTowns.None)
                {
                    continue;
                }

                int hue = SelectedTown == town ? SelectedColor32 : WhiteColor32;
                AddButtonLabeled(20, 140 + (int)town * 25, (int)town + 100, town.GetDescription(), hue);
            }
        }

        private void AddMonsterTypeButtons()
        {
            foreach (TownMonsterType monster in Enum.GetValues(typeof(TownMonsterType)))
            {
                if (monster == TownMonsterType.None)
                {
                    continue;
                }

                int hue = SelectedMonster == monster ? SelectedColor32 : WhiteColor32;
                AddButtonLabeled(180, 140 + (int)monster * 25, (int)monster + 200, monster.GetDescription(), hue);
            }
        }

        private void AddChampionButtons()
        {
            foreach (TownChampionType champion in Enum.GetValues(typeof(TownChampionType)))
            {
                if (champion == TownChampionType.None)
                {
                    continue;
                }

                int hue = SelectedChamp == champion ? SelectedColor32 : WhiteColor32;
                AddButtonLabeled(340, 140 + (int)champion * 25, (int)champion + 300, champion.GetDescription(), hue);
            }
        }

        private void AddMapButtons()
        {
            foreach (InvasionMap map in Enum.GetValues(typeof(InvasionMap)))
            {
                if (map == InvasionMap.None)
                {
                    continue;
                }

                int hue = SelectedMap == map ? SelectedColor32 : WhiteColor32;
                AddButtonLabeled(500, 140 + (int)map * 25, (int)map + 400, map.GetDescription(), hue);
            }
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            Mobile from = sender.Mobile;

            if (info.ButtonID == 1)
            {
                string time = info.GetTextEntry(5);
                if (string.IsNullOrEmpty(time) || !DateTime.TryParse(time, out DateTime timeToStart) || timeToStart < DateTime.UtcNow)
                {
                    from.SendMessage("You've entered an invalid date or time. Please follow the example format.");
                    from.SendGump(new InvasionMainGump(from, SelectedTown, SelectedMonster, SelectedChamp, SelectedMap));
                    return;
                }

                if (info.IsSwitched(1))
                {
                    SelectedTown = GetRandomEnumValue<InvasionTowns>();
                    SelectedMonster = GetRandomEnumValue<TownMonsterType>();
                    SelectedChamp = GetRandomEnumValue<TownChampionType>();
                    SelectedMap = GetRandomEnumValue<InvasionMap>();
                }
                else
                {
                    int townIndex = GetSelectedId(info, 100, 200);
                    if (townIndex != -1) SelectedTown = (InvasionTowns)townIndex;

                    int monsterIndex = GetSelectedId(info, 200, 300);
                    if (monsterIndex != -1) SelectedMonster = (TownMonsterType)monsterIndex;

                    int champIndex = GetSelectedId(info, 300, 400);
                    if (champIndex != -1) SelectedChamp = (TownChampionType)champIndex;

                    int mapIndex = GetSelectedId(info, 400, 500);
                    if (mapIndex != -1) SelectedMap = (InvasionMap)mapIndex;
                }

                if (SelectedTown == InvasionTowns.None || SelectedMonster == TownMonsterType.None || SelectedChamp == TownChampionType.None || SelectedMap == InvasionMap.None)
                {
                    from.SendMessage("Please ensure that None is not selected for Town, Monster, Champion or Map.");
                    from.SendGump(new InvasionMainGump(from, SelectedTown, SelectedMonster, SelectedChamp, SelectedMap));
                    return;
                }

                from.SendMessage($"You have scheduled an invasion for {SelectedTown} at {timeToStart} in {SelectedMap.GetDescription()}");

                _ = new TownInvasion(SelectedTown, SelectedMonster, SelectedChamp, timeToStart, SelectedMap); // Assigned to discard
            }
            else if (info.ButtonID == 0)
            {
                // Close the gump
                return;
            }
            else
            {
                // Determine which button was clicked and update the corresponding selection
                if (info.ButtonID >= 100 && info.ButtonID < 200)
                {
                    SelectedTown = (InvasionTowns)(info.ButtonID - 100);
                }
                else if (info.ButtonID >= 200 && info.ButtonID < 300)
                {
                    SelectedMonster = (TownMonsterType)(info.ButtonID - 200);
                }
                else if (info.ButtonID >= 300 && info.ButtonID < 400)
                {
                    SelectedChamp = (TownChampionType)(info.ButtonID - 300);
                }
                else if (info.ButtonID >= 400 && info.ButtonID < 500)
                {
                    SelectedMap = (InvasionMap)(info.ButtonID - 400);
                }

                // Refresh the gump to show the updated selections
                from.SendGump(new InvasionMainGump(from, SelectedTown, SelectedMonster, SelectedChamp, SelectedMap));
            }
        }

        private int GetSelectedId(RelayInfo info, int start, int end)
        {
            for (var i = start; i < end; i++)
            {
                if (info.IsSwitched(i))
                {
                    return i - start;
                }
            }
            return -1;
        }

        private T GetRandomEnumValue<T>() where T : Enum
        {
            Array values = Enum.GetValues(typeof(T));
            return (T)values.GetValue(Utility.Random(1, values.Length - 1)); // Skip the first value which is 'None'
        }

        public void AddButtonLabeled(int x, int y, int buttonID, string text, int hue)
        {
            AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            AddHtml(x + 35, y, 200, 20, text.Color(hue), false, false);
        }

        public void AddBlackAlpha(int x, int y, int width, int height)
        {
            AddImageTiled(x, y, width, height, 2624);
            AddAlphaRegion(x, y, width, height);
        }
    }

    public static class StringExtensions
    {
        public static string Color(this string text, int color)
        {
            return $"<BASEFONT COLOR=#{color:X6}>{text}</BASEFONT>";
        }

        public static string Center(this string text, int color)
        {
            return $"<CENTER>{text.Color(color)}</CENTER>";
        }
    }
}
