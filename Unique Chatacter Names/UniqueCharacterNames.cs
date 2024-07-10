using System;
using Server;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Network;

namespace Felladrin.Automations
{
    public static class UniqueCharacterNames
    {
        public static void Configure()
        {
            EventSink.Connected += OnLogin;
            CommandSystem.Register("NameChange", AccessLevel.Player, new CommandEventHandler(OnCommand));
        }

        [Usage("NameChange")]
        [Description("Display the NameChange")]
        private static void OnCommand(CommandEventArgs args)
        {
            Mobile m = args.Mobile;

            if (m != null && m.AccessLevel != AccessLevel.Player)
                m.SendGump(new NameChangeGump());
        }

        static void OnLogin(Mobile from)
        {
            if (from == null)
            {
                Console.WriteLine("OnLogin: Mobile is null.");
                return;
            }

            if (HasValidName(from))
            {
                Console.WriteLine($"OnLogin: {from.Name} has a valid name.");
                return;
            }

            Console.WriteLine($"OnLogin: {from.Name} has an invalid or duplicate name. Prompting for new name.");
            from.SendMessage($"Your character name '{from.Name}' is already in use by another player or it has been marked as invalid. Please choose a new one.");
            from.RawName = "Generic Player";

            // Set cantwalk to true
            from.CantWalk = true;

            // Log to ensure this line is reached
            Console.WriteLine("Scheduling NameChangeGump...");

            // Use a delay to ensure the client is ready
            Timer.DelayCall(TimeSpan.FromSeconds(1), () =>
            {
                Console.WriteLine("Sending NameChangeGump after delay...");
                from.SendGump(new NameChangeGump());
            });
        }

        static bool HasValidName(Mobile m)
        {
            if (m.AccessLevel != AccessLevel.Player || m.RawName.Contains("GM "))
                return true;

            if (m.RawName == "Generic Player" || !NameVerification.Validate(m.RawName, 2, 16, true, false, true, 1, NameVerification.SpaceDashPeriodQuote))
                return false;

            foreach (Mobile otherPlayer in World.Mobiles.Values)
                if (otherPlayer is PlayerMobile && otherPlayer != m && otherPlayer.RawName != null && m.RawName != null && otherPlayer.RawName.ToLower() == m.RawName.ToLower() && m.Created > otherPlayer.Created)
                    return false;

            return true;
        }

        public class NameChangeGump : Gump
        {
            void AddBlackAlpha(int x, int y, int width, int height)
            {
                AddImageTiled(x, y, width, height, 2624);
                AddAlphaRegion(x, y, width, height);
            }

            void AddTextField(int x, int y, int width, int height, int index)
            {
                AddBackground(x - 2, y - 2, width + 4, height + 4, 0x2486);
                AddTextEntry(x + 2, y + 2, width - 4, height - 4, 0, index, "");
            }

            static string Center(string text)
            {
                return string.Format("<CENTER>{0}</CENTER>", text);
            }

            static string Color(string text, int color)
            {
                return string.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
            }

            void AddButtonLabeled(int x, int y, int buttonID, string text)
            {
                AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
                AddHtml(x + 35, y, 240, 20, Color(text, 0xFFFFFF), false, false);
            }

            public NameChangeGump() : base(50, 50)
            {
                // Log to ensure the gump constructor is called
                Console.WriteLine("NameChangeGump constructor called.");

                Closable = false;
                Draggable = false;
                Resizable = false;

                AddPage(0);
                AddBlackAlpha(10, 120, 250, 85);
                AddHtml(10, 125, 250, 20, Color(Center("Your name is already in use or invalid!"), 0xFFFFFF), false, false);
                AddLabel(73, 15, 1152, "");
                AddLabel(20, 150, 0x480, "New Name:");
                AddTextField(100, 150, 150, 20, 0);
                AddButtonLabeled(175, 180, 1, "Submit");
            }

            public override void OnResponse(NetState sender, in RelayInfo info)
            {
                if (info.ButtonID != 1)
                    return;

                var m = sender.Mobile;
                var nameEntry = info.GetTextEntry(0);

                // Log to ensure the gump response is processed
                Console.WriteLine("NameChangeGump.OnResponse called.");

                m.RawName = nameEntry != null ? nameEntry.Trim() : "Generic Player";

                if (HasValidName(m) && m.RawName != "")
                {
                    m.SendMessage($"Your name has been changed! You are now known as '{m.RawName}'.");

                    // Set cantwalk to false
                    m.CantWalk = false;
                }
                else
                {
                    m.SendMessage(33, "You can't use that name. Please choose a new one.");
                    m.RawName = "Generic Player";
                    m.SendGump(new NameChangeGump());
                }
            }
        }
    }
}
