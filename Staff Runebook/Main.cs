/****************************************
 * Author: Joeku                        *
 * Revised for MUO: Nerun & Delphi      *
 * For use with ModernUO                *
 * Client Tested with: 7.0.102.3        *
 * Version: 1.10                        *
 * Initial Release: 11/25/2007          *
 * Revision Date: 06/07/2024            *
 **************************************/

using System.Collections.Generic;
using System.IO;
using Server;
using Server.Commands;

namespace Joeku.SR
{
    public partial class SR_Main
    {
        public static int Version = 110;
        public static string ReleaseDate = "February 4, 2009";
        public static string SavePath = "Saves/Staff Runebook";
        public static string FileName = "Rune Accounts.xml";
        public static List<SR_RuneAccount> Info = new List<SR_RuneAccount>();
        public static int Count { get { return Info.Count; } }

        [CallPriority(100)]
        public static void Initialize()
        {
            if (Info.Count == 0)
                SR_Load.ReadData(Path.Combine(SavePath, FileName));

            CommandHandlers.Register("StaffRunebook", AccessLevel.Counselor, new CommandEventHandler(SR_OnCommand));
            CommandHandlers.Register("SR", AccessLevel.Counselor, new CommandEventHandler(SR_OnCommand));
            CommandHandlers.Register("StaffRunebookReset", AccessLevel.Counselor, new CommandEventHandler(SR_Reset_OnCommand));
            EventSink.WorldSave += EventSink_WorldSave;
        }

        [Usage("StaffRunebook")]
        [Aliases("SR")]
        public static void SR_OnCommand(CommandEventArgs e)
        {
            Mobile mob = e.Mobile;
            SR_Gump.Send(mob, SR_Utilities.FetchInfo(mob.Account));
        }

        [Usage("StaffRunebookReset")]
        public static void SR_Reset_OnCommand(CommandEventArgs e)
        {
            Mobile mob = e.Mobile;
            SR_Utilities.NewRuneAcc(SR_Utilities.FetchInfo(mob.Account));
            mob.SendMessage("Your staff runebook has been reset to default.");
        }

        private static void EventSink_WorldSave()
        {
            SR_Save.WriteData();
        }

        public static void AddInfo(SR_RuneAccount runeAccount)
        {
            for (int i = 0; i < Info.Count; i++)
                if (Info[i].Username == runeAccount.Username)
                    Info.RemoveAt(i);
            Info.Add(runeAccount);
        }
    }
}
