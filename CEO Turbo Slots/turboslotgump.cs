/****************************************
 * Original Author CEO                  *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 7, 2024                   *
 ****************************************/

using System;
using Server.Items;
using Server.Network;

namespace Server.Gumps
{
    public class TurboSlotGump : Gump
    {
        private TurboSlot m_Slot;
        private int[] m_Symbols;

        public enum SlotThemeType { Classic, ClassicII, ClassicIII, FarmerFaceoff, GruesomeGambling, Holiday1, LadyLuck, MinerMadness, OffToTheRaces, Pirates, PowerScrolls, StatScrolls, TailorTreats, TrophyHunter }
        public TurboSlotGump(TurboSlot Slot, int[] Symbols)
            : base(25, 25)
        {
            m_Slot = Slot;
            m_Symbols = Symbols;

            if (m_Slot == null)
                return; // Something is obviously wrong!
            int dispy = m_Symbols[13];
            int backgroundcolor = m_Symbols[14];
            int titlecolor = m_Symbols[15];
            int titlestyle = m_Symbols[16];
            int headingcolor1 = m_Symbols[17];
            int headingcolor2 = m_Symbols[18];
            int paycolor = m_Symbols[19];
            int slotart = m_Symbols[20];
            string[] Jackpot;
            bool progressive = false;
            int ProgressiveHue = 0;
            int PayoutHue;
            int lastjackpotstarty = 85;
            int progstarty = 65;
            int symbolxoffset = 0;
            string text;
            int tilecolor = 9304;
            if ((SlotThemeType)m_Slot.SlotTheme == SlotThemeType.GruesomeGambling || (SlotThemeType)m_Slot.SlotTheme == SlotThemeType.StatScrolls)
                tilecolor = 9204;
            else if ((SlotThemeType)m_Slot.SlotTheme == SlotThemeType.Holiday1)
                tilecolor = 0xBBC;
            else if ((SlotThemeType)m_Slot.SlotTheme == SlotThemeType.FarmerFaceoff || (SlotThemeType)m_Slot.SlotTheme == SlotThemeType.OffToTheRaces
                     || (SlotThemeType)m_Slot.SlotTheme == SlotThemeType.TrophyHunter)
                tilecolor = 2524;
            else if ((SlotThemeType)m_Slot.SlotTheme == SlotThemeType.PowerScrolls)
            {
                tilecolor = 9354;
                symbolxoffset = 16;
            }

            if (backgroundcolor == 0)
                text =
                    $"<body bgcolor=\"black\"><basefont SIZE={titlestyle} COLOR=\"#{titlecolor:x6}\"><CENTER>{m_Slot.Name}</CENTER></basefont></body>";
            else if (backgroundcolor < 0)
                text = $"<basefont SIZE={titlestyle} COLOR=\"#{titlecolor:x6}\"><CENTER>{m_Slot.Name}</CENTER></basefont>";
            else
                text =
                    $"<body bgcolor=\"#{backgroundcolor:x6}\"><basefont SIZE={titlestyle} COLOR=\"#{titlecolor:x6}\"><CENTER>{m_Slot.Name}</CENTER></basefont></body>";
            TurboSlot progSlotMaster = null;

            if ((m_Slot?.ProgSlotMaster is { Deleted: false } && (progSlotMaster = m_Slot.ProgSlotMaster as TurboSlot)?.ProgIsMaster == true) || m_Slot?.ProgIsMaster == true)
            {
                progressive = true;
                lastjackpotstarty = 110;

                if (m_Slot.ProgIsMaster)
                {
                    // pjackpot += m_Slot.ProgJackpot;
                    ProgressiveHue = m_Slot.Hue;
                }
                else if (progSlotMaster != null)
                {
                    // pjackpot += progSlotMaster.ProgJackpot;
                    ProgressiveHue = progSlotMaster.Hue;
                }

                ProgressiveHue += -1;

                if (ProgressiveHue < 0)
                {
                    ProgressiveHue = 1149;
                }
            }
            Closable = true;
            Disposable = true;
            Draggable = true;
            Resizable = false;
            AddPage(0);
            AddBackground(18, 64, 371, 278, 5120);
            AddBackground(32, 193, 345, 100, 2620);
            AddImageTiled(23, 298, 363, 10, 5121);
            AddHtml(30, 65, 170, 23, @text);

            if (m_Slot.ShowPayback || (m_Slot.InUseBy != null && m_Slot.InUseBy.AccessLevel != AccessLevel.Player))
            {
                float payoutdif = Math.Abs(m_Slot.w_Percentage - m_Slot.WinningPercentage);
                PayoutHue = 267;
                if (payoutdif > 15.0f || m_Slot.WinningPercentage > 100.0f)
                    PayoutHue = 37;
                else if (payoutdif > 7.0f)
                    PayoutHue = 55;
                else if (payoutdif > 3.0f)
                    PayoutHue = 87;
                text = $"{m_Slot.WinningPercentage:##0.00}%";
                AddLabel(205, 65, headingcolor1, @"Payback Percentage:");
                AddLabel(330, 65, PayoutHue, @text);
                progstarty = 85;
                if (progressive)
                    lastjackpotstarty = 125;
                if (m_Slot.InUseBy != null && m_Slot.InUseBy.AccessLevel != AccessLevel.Player)
                {
                    if (m_Slot.w_Percentage > 99.5f)
                        PayoutHue = 37;
                    else if (m_Slot.w_Percentage > 90.0f)
                        PayoutHue = 267;
                    else if (m_Slot.w_Percentage > 80.0f)
                        PayoutHue = 87;
                    else if (m_Slot.w_Percentage > 60.0f)
                        PayoutHue = 55;
                    else if (m_Slot.w_Percentage > 40.0f)
                        PayoutHue = 37;
                    string[] pstring = new string[] { "L", "N", "T", "E", "C", "R" };
                    text = $"({pstring[(int)m_Slot.CurrentPayback]})";
                    if ((int)m_Slot.SlotPaybackOdds == 5)
                        AddLabel(208, 80, 37, @text);
                    else
                        AddLabel(208, 80, headingcolor1, @text);
                    AddLabel(232, 80, headingcolor1, @"Statisical Odds:");
                    text = $"{m_Slot.w_Percentage:##0.00}%";
                    AddLabel(330, 80, PayoutHue, @text);
                    progstarty = 155;
                    lastjackpotstarty = 94;
                }
            }
            AddImageTiled(37, 200, 335, 86, 9354);
            AddImageTiled(150, 202, 2, 83, 9353);
            AddLabel(30, 100, headingcolor2, @"Cost: ");
            AddLabel(65, 100, paycolor, m_Slot.Cost.ToString());
            AddLabel(30, 120, headingcolor2, @"Credits: ");
            AddLabel(80, 120, paycolor, m_Slot.Won.ToString());
            AddLabel(30, 140, headingcolor2, @"Last Pay: ");
            AddLabel(92, 140, paycolor, m_Slot.LastPay.ToString());
            AddButton(30, 163, 4026, 4027, 11);
            AddLabel(65, 164, headingcolor1, @"View Pay Table");
            AddButton(30, 307, 4020, 4021, 12);
            if (m_Slot.FreeSpin)
                AddLabel(65, 307, headingcolor2, @"Free");
            else
                AddLabel(65, 307, headingcolor1, @"Spin");
            AddButton(118, 307, 4029, 4030, 13);
            AddLabel(153, 307, headingcolor1, @"Cash Out");
            AddButton(235, 300, 4037, 4036, 14);
            AddLabel(270, 307, headingcolor1, @"ATM");
            AddImageTiled(60, 205, 75, 75, tilecolor);
            AddImageTiled(167, 205, 75, 75, tilecolor);
            AddImageTiled(274, 205, 75, 75, tilecolor);
            AddImageTiled(258, 202, 2, 83, 9353);
            if (slotart != 0)
                ShowSymbol(155, 90, slotart);
            if (m_Slot.LastWonBy is { Deleted: false })
            {
                AddLabel(230, lastjackpotstarty, headingcolor2, "Last Jackpot won by:");
                text = $"<BASEFONT COLOR=#FFFFFF><Center>{m_Slot.LastWonBy.Name}<//Center></BASEFONT>";
                AddHtml(205, lastjackpotstarty + 15, 180, 15, @text);
                text = $"{m_Slot.LastWonByDate:MM/dd/yy hh:mm:ss tt}";
                AddLabel(205, lastjackpotstarty + 30, headingcolor2, "Date:");
                AddLabel(237, lastjackpotstarty + 30, paycolor, text);
                text = $"{m_Slot.LastWonAmount:##,###,### Gold!}";
                AddLabel(202, lastjackpotstarty + 45, headingcolor2, "Value:");
                AddLabel(237, lastjackpotstarty + 45, paycolor, text);
            }
            if (progressive)
            {
                Jackpot = m_Slot.GetJackpotPayoutStr(0, out _);
                AddHtml(245, progstarty, 356, 23, @"<BASEFONT COLOR=#FFFFFF><U>Progressive Jackpot</U></BASEFONT>");
                AddLabel(280, progstarty + 15, ProgressiveHue, Jackpot[0]);
            }
            ShowSymbol(75 - symbolxoffset, 220 - dispy / 3, m_Slot.ReelOne);
            ShowSymbol(183 - symbolxoffset, 220 - dispy / 3, m_Slot.ReelTwo);
            ShowSymbol(290 - symbolxoffset, 220 - dispy / 3, m_Slot.ReelThree);
            if (Utility.Random(25000) == 45)
                CEOCookie(headingcolor2);
        }

        private void CEOCookie(int hue)
        {
            AddImageTiled(310, 50, 142, 230, 990);
            AddLabel(20, 230, hue, "TurboSlot Author, CEO, says \"Hello! Enjoying my slot machine?\" :)");
            if (m_Slot.InUseBy != null)
                m_Slot.InUseBy.PlaySound(Utility.RandomList(1358, 1359, 1360, 1361, 1362, 1363, 1368, 1382));
        }

        private void ShowSymbol(int x, int y, int symbol)
        {
            string text;
            switch (symbol)
            {
                case 0:
                    break;

                case 90001:
                    text = "<BASEFONT SIZE=6 COLOR=RED><CENTER><B>7</B></CENTER></BASEFONT>";
                    AddHtml(x, y + 10, 40, 50, text);
                    break;

                case 90002:
                    text = "<BASEFONT SIZE=6 COLOR=BLACK><CENTER><B>7</B></CENTER></BASEFONT>";
                    AddHtml(x, y + 10, 40, 50, text);
                    break;

                case 90003:
                    text = "<BASEFONT SIZE=6 COLOR=WHITE><CENTER><B>7</B></CENTER></BASEFONT>";
                    AddHtml(x, y + 10, 40, 50, text);
                    break;

                case 90004:
                    text = "<BASEFONT SIZE=6 COLOR=BLUE><CENTER><B>7</B></CENTER></BASEFONT>";
                    AddHtml(x, y + 10, 40, 50, text);
                    break;

                case 90100: //White "Lucky" Necklace & Golden Robe
                    AddItem(x, y, 7940, 2213);
                    AddItem(x - 8, y + 3, 4232, 1150);
                    break;

                case 90101: //Golden Cloak and Sash
                    AddItem(x, y, 5424, 2213);
                    break;

                case 90102: //Golden Sash
                    AddItem(x, y + 5, 5441, 2213);
                    break;

                case 90103: //Golden Bars
                    AddItem(x, y, 7153, 2213);
                    break;

                case 90104: //Golden Horseshoes
                    AddItem(x, y, 4022, 2213);
                    break;

                case 90110: //Golden Statue
                    AddItem(x - 3, y - 18, 4782, 2213);
                    break;

                case 90200: // Barbed Kit
                    AddItem(x, y, 3997, 2128);
                    break;

                case 90201: // Horned Kit
                    AddItem(x, y, 3997, 2116);
                    break;

                case 90202: // Spined Kit
                    AddItem(x, y, 3997, 2219);
                    break;

                case 90203: // Purple Fancy Shirt
                    AddItem(x, y, 7933, 23);
                    break;

                case 90204: // Colored Folded Cloth
                    AddItem(x, y, 5984, 1151);
                    break;

                case 90210: // Loom
                    AddItem(x - 10, y - 12, 4197);
                    AddItem(x + 15, y + 25, 4198);
                    break;

                case 90250: // Sea Horse
                    AddItem(x, y, 8479, 694);
                    break;

                case 90300: // Stat Scroll
                    AddItem(x, y+15, 5359, 1153);
                    break;

                case 90301: // TrueHarrower
                    AddItem(x-10, y+10, 9736, 1175);
                    break;

                case 90302: // Red Corpser
                    AddItem(x, y, 8402, 36);
                    break;

                case 90303: // Fake Harrower
                    AddItem(x+10, y+5, 9659);
                    break;

                case 90304: // OrnateCrown
                    AddItem(x, y+15, 5201, 1269);
                    break;

                case 90305: // Summon Altars
                    AddItem(x, y+15, 6587, 1109);
                    break;

                case 90306: // Red Skull Candle
                    AddItem(x, y+5, 6228, 37);
                    break;

                default:
                    AddItem(x, y, symbol);
                    break;
            }
        }

        private void CloseAllGumps(Mobile from)
        {
            from.CloseGump<TurboSlotGump>();
            from.CloseGump<NewMinerBonusGump>();
            from.CloseGump<TurboSlotPayTableGump>();
        }


        public override void OnResponse(NetState state, in RelayInfo info)
        {
            Mobile from = state.Mobile;

            if (from == null || m_Slot == null)
                return;
            if (m_Slot.InUseBy == null)
            {
                from.SendMessage("Someone else played this machine while you were idle. Double click it again to resume play.");
                CloseAllGumps(from);
                return;
            }
            if (from.Serial != m_Slot.InUseBy.Serial)
            {
                from.SendMessage($"You have left this machine idle too long and {m_Slot.InUseBy.Name} has taken it over!");
                CloseAllGumps(from);
                return;
            }

            if (!m_Slot.Active || m_Slot.Deleted)
            {
                from.SendMessage("This slot machine is no longer available.");
                if (m_Slot.Won != 0)
                {
                    from.SendMessage($"Cashing out your winnings of {m_Slot.Won} gold.");
                    m_Slot.DoCashOut(from);
                }
                CloseAllGumps(from);
                m_Slot.InUseBy = null;
                return;
            }

            if (!from.Alive)
            {
                from.SendMessage("Ghosts can not play this game.");
                if (m_Slot.Won != 0)
                {
                    from.SendMessage($"Cashing out your winnings of {m_Slot.Won} gold.");
                    m_Slot.DoCashOut(from);
                }
                CloseAllGumps(from);
                m_Slot.InUseBy = null;
                return;
            }

            m_Slot.LastPlayed = DateTime.Now;

            if (info.ButtonID == 0) // Close
            {
                if (m_Slot.Won != 0)
                {
                    from.SendMessage($"You quit playing this machine and cash out your credits of {m_Slot.Won} gold.");
                    m_Slot.DoCashOut(from);
                    CloseAllGumps(from);
                }
                m_Slot.InUseBy = null;
                return;
            }

            if (info.ButtonID == 11) // Pay Table
            {
                from.CloseGump<TurboSlotPayTableGump>();
                from.SendGump(new TurboSlotGump(m_Slot, m_Symbols));
                from.SendGump(new TurboSlotPayTableGump(m_Slot, m_Symbols));
                return;
            }

            if (info.ButtonID == 12) // Spin
            {
                int amount;
                if (!from.InRange(m_Slot.GetWorldLocation(), 2) || !from.InLOS(m_Slot))
                {
                    from.SendMessage("You are too far away from the machine, others may now play it.");
                    if (m_Slot.Won != 0)
                    {
                        m_Slot.DoCashOut(from);
                        m_Slot.InUseBy = null;
                    }
                    return;
                }
                if (m_Slot.FreeSpin)
                {
                    m_Slot.DoSpin(from);
                    m_Slot.LastPay = 0;
                }
                else
                {
                    if (from.Backpack.ConsumeTotal(typeof(CasinoToken)))
                    {
                        m_Slot.DoSpin(from);
                        m_Slot.LastPay = 0;
                    }
                    else if (from.Backpack.ConsumeTotal(typeof(Gold), m_Slot.Cost))
                    {
                        m_Slot.DoSpin(from);
                        m_Slot.LastPay = 0;
                        m_Slot.SlotTotalCollected += m_Slot.Cost;
                    }
                    else if (m_Slot.Won >= m_Slot.Cost)
                    {
                        m_Slot.SlotWon -= m_Slot.Cost;
                        m_Slot.DoSpin(from);
                        m_Slot.LastPay = 0;
                        m_Slot.SlotTotalCollected += m_Slot.Cost;
                    }
                    else if (m_Slot.CashCheck(from, out amount))
                    {
                        from.SendMessage($"Cashing bank check for {amount} gold from your backpack, you may now spin again.");
                        from.SendGump(new TurboSlotGump(m_Slot, m_Symbols));
                    }
                    else
                    {
                        from.SendMessage($"You must have at least {m_Slot.Cost} gold, or credits on the machine to play.");
                        from.SendGump(new TurboSlotGump(m_Slot, m_Symbols));
                    }
                }
                return;
            }

            if (info.ButtonID == 13) // Cash Out
            {
                if (m_Slot.Won != 0)
                    m_Slot.DoCashOut(from);
                from.SendGump(new TurboSlotGump(m_Slot, m_Symbols));
                return;
            }

            if (info.ButtonID == 14) // Withdraw m_Slot.CreditATMIncrements from bank
            {
                if (m_Slot.Won >= m_Slot.CreditATMLimit)
                {
                    from.SendMessage("This machine is at or over its credit limit.");
                }
                else
                {
                    int amount = (m_Slot.CreditATMLimit - m_Slot.Won < m_Slot.CreditATMIncrements) ? m_Slot.CreditATMLimit - m_Slot.Won : m_Slot.CreditATMIncrements;
                    if (from.BankBox.ConsumeTotal(typeof(Gold), amount))
                    {
                        m_Slot.SlotWon += amount;
                        from.SendMessage($"{amount} gold has been withdrawn from your bank and added to this machine's credit counter.");

                        Effects.PlaySound(new Point3D(m_Slot.X, m_Slot.Y, m_Slot.Z), m_Slot.Map, 501);
                    }
                    else
                        from.SendMessage("Insufficient funds for ATM withdrawal.");
                }
                from.SendGump(new TurboSlotGump(m_Slot, m_Symbols));
                return;
            }
            from.SendMessage("Invalid button detected. Fix your macro!");
        }
    }
}
