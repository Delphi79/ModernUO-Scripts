/****************************************
 * Created by Admin Delphi              *
 * For use with ModernUO                *
 * Date: May 31, 2024                   *
 ****************************************/

using System;
using System.Collections.Generic;
using Server.Network;

namespace Server.Custom
{
    public class LoginLogoutAnnouncer
    {
        // Configuration Toggles
        private static readonly bool FunTitlesEnabled = true;
        private static readonly int MessageHue = 89; // Bright cyan color (Hue: 89)

        private static readonly Dictionary<Mobile, bool> SeeLogInOutSetting = new Dictionary<Mobile, bool>();

        private static readonly List<string> FunTitles =
        [
            "The Magnificent", "The Brave", "The Sneaky", "The Wise", "The Mighty", "The Incredible", "The Sniveling",
            "The Bold", "The Swift", "The Cunning", "The Heroic", "The Fearless", "The Unstoppable", "The Valiant",
            "The Conqueror", "The Portly", "The Feeble", "The Ignastic", "The Aromatic", "The Great", "The Handsy",
            "The Quivering", "The Renowned", "The Crafty", "The Stealthy", "The Agile", "The Fierce", "The Untamed",
            "The Adventurous", "The Venerable", "The Dauntless", "The Gallant", "The Grand", "The Weasely", "The Resolute",
            "The Stalwart", "The Tenacious", "The Vigilant", "The Jubilant", "The Exalted", "The Triumphant", "The Merry",
            "The Jovial", "The Gleeful", "The Jolly", "The Radiant", "The Brilliant", "The Spirited", "The Daring",
            "The Majestic",
            "The Fantastical", "The Magtastic", "The Bizarre", "The Whimsical", "The Absurd", "The Quirky", "The Zany",
            "The Bonkers", "The Ridiculous", "The Wacky", "The Eccentric", "The Unbelievable", "The Outlandish",
            "The Peculiar",
            "The Ludicrous", "The Hilarious", "The Oddball", "The Unpredictable", "The Fanciful", "The Marvelous"
        ];

        public static void Initialize()
        {
            EventSink.Connected += OnConnected;
            EventSink.Disconnected += OnDisconnected;
            EventSink.Logout += OnLogout;
            CommandSystem.Register("SeeLogInOut", AccessLevel.Player, SeeLogInOut_OnCommand);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("LoginLogoutAnnouncer initialized.");
            Console.ResetColor();
        }

        private static void OnConnected(Mobile m)
        {
            if (m.AccessLevel == AccessLevel.Player)
            {
                string message = $"{GetFunTitle(m.Name)} has logged in.";
                Announce(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player connected: {m.Name}");
                Console.WriteLine($"Players currently online: {GetOnlinePlayerCount()}");
                Console.ResetColor();
            }
        }

        private static void OnDisconnected(Mobile m)
        {
            // No need to handle logout here, as it's now managed by the OnLogout event.
        }

        private static void OnLogout(Mobile m)
        {
            if (m.AccessLevel == AccessLevel.Player)
            {
                string message = $"{GetFunTitle(m.Name)} has logged out.";
                Announce(message);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player disconnected: {m.Name}");
                Console.WriteLine($"Players currently online: {GetOnlinePlayerCount()}");
                Console.ResetColor();
            }
        }

        private static string GetFunTitle(string playerName)
        {
            if (FunTitlesEnabled)
            {
                return $"{FunTitles.RandomElement()} {playerName}";
            }
            else
            {
                return playerName;
            }
        }

        private static void Announce(string message)
        {
            foreach (NetState state in NetState.Instances)
            {
                Mobile m = state.Mobile;

                if (m != null)
                {
                    // Check if the player has the setting, default to true if not set
                    SeeLogInOutSetting.TryAdd(m, true);

                    if (SeeLogInOutSetting[m])
                    {
                        m.SendMessage(MessageHue, message); // Bright cyan color
                    }
                }
            }
        }

        private static int GetOnlinePlayerCount()
        {
            int count = 0;
            foreach (NetState state in NetState.Instances)
            {
                Mobile m = state.Mobile;
                if (m is { AccessLevel: AccessLevel.Player })
                {
                    count++;
                }
            }
            return count;
        }

        [Usage("SeeLogInOut")]
        [Description("Toggles seeing other players logging in and out.")]
        public static void SeeLogInOut_OnCommand(CommandEventArgs e)
        {
            Mobile from = e.Mobile;

            if (from != null)
            {
                SeeLogInOutSetting[from] = !SeeLogInOutSetting.GetValueOrDefault(from, false);
                from.SendMessage(MessageHue, SeeLogInOutSetting[from] ? "You will now see other players logging in and out." : "You will no longer see other players logging in and out.");
            }
        }
    }
}
