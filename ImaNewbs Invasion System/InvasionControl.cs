/**********************************************
* Script Name: InvasionControl.cs             *
 * ReWritten by ImaNewb Aka Delphi            *
 * Original Author: RavenWolfe (for ServUO)   *
 * For use with ModernUO                      *
 * Date: June 17, 2024                        *
 * ========================================== *
 * Special thanks to Ravenwolfe, Mr, Batman   *
 * and Voxspire                               *
 **********************************************/

using System;
using System.Collections.Generic;
using System.IO;
using Server.Gumps;
using Server.Network;

namespace Server.Customs.Invasion_System
{
    public static class InvasionControl
    {
        public static List<TownInvasion> Invasions = new();

        private static Mobile _caller;

        public static void Initialize()
        {
            CommandSystem.Register("ListInvasions", AccessLevel.Administrator, ListInvasions_OnCommand);
            InvasionPersistence.Configure();
        }

        [Usage("ListInvasions")]
        [Description("Lists all active invasions.")]
        public static void ListInvasions_OnCommand(CommandEventArgs e)
        {
            _caller = e.Mobile;

            if (Invasions.Count == 0)
            {
                _caller.SendMessage("There are no invasions!");
                return;
            }

            _caller.SendGump(new InvasionGump(Invasions));
        }
    }

    public class InvasionGump : Gump
    {
        private const int EntriesPerPage = 6;        // Number of entries per page
        private const int WhiteColor32 = 0xFFFFFF;   // White color for labels
        private const int RedColor32 = 0xFF0000;     // Red color for specific labels
        private const int GreenColor32 = 0x55E118;   // Green color for specific labels
        private const int OrangeColor32 = 0xFF8200;  // Orange color for specific labels
        private const int SkyBlueColor32 = 0x05C3F9; // Sky Blue color for specific labels

        private int currentPage;

        public InvasionGump(List<TownInvasion> invasions, int page = 0) : base(100, 100)
        {
            currentPage = page;

            Closable = true;
            Disposable = true;
            Draggable = true;
            Resizable = false;

            AddPage(0); // Add the first page

            AddBackground(0, 0, 635, 320, 5054); // +20
            AddBlackAlpha(10, 10, 615, 300);     // -20

            var y = 55;
            var x = 15;

            AddHtml(150, 13, 350, 20, "Town Invasion Status".Center(OrangeColor32));
            AddHtml(x, y, 120, 20, "Town".Center(SkyBlueColor32));
            AddHtml(x + 120, y, 120, 20, "Monster Type".Center(SkyBlueColor32));
            AddHtml(x + 240, y, 120, 20, "Champion".Center(SkyBlueColor32));
            AddHtml(x + 360, y, 140, 20, "Time Scheduled".Center(SkyBlueColor32));
            AddHtml(x + 510, y, 50, 20, "Stop".Center(RedColor32));
            AddHtml(x + 555, y, 50, 20, "Props".Center(WhiteColor32));

            y += 30;

            int start = page * EntriesPerPage;
            int end = Math.Min(start + EntriesPerPage, invasions.Count);

            for (int i = start; i < end; ++i)
            {
                var invasion = invasions[i];
                AddHtml(x, y, 120, 20, invasion.InvasionTown.ToString().Center(WhiteColor32));
                AddHtml(x + 120, y, 120, 20, invasion.TownMonsterType.ToString().Center(WhiteColor32));
                AddHtml(x + 240, y, 120, 20, invasion.TownChampionType.ToString().Center(WhiteColor32));
                AddHtml(x + 360, y, 140, 20, (invasion.IsRunning ? "Active".Center(GreenColor32) : invasion.StartTime.ToString().Center(WhiteColor32)));
                AddButton(x + 520, y, 0xFB1, 0xFB2, 1000 + i); // Stop
                AddButton(x + 565, y, 0xFAB, 0xFAC, 2000 + i); // Props
                y += 30;
            }

            // Add navigation buttons
            if (page > 0)
            {
                AddButton(535, 280, 0xFAE, 0xFAF, 3000); // Previous
            }

            if (end < invasions.Count)
            {
                AddButton(580, 280, 0xFA5, 0xFA6, 3001); // Next
            }
        }

        public override void OnResponse(NetState sender, in RelayInfo info)
        {
            var from = sender.Mobile;

            if (info.ButtonID == 0)
            {
                return;
            }

            if (info.ButtonID >= 1000 && info.ButtonID < 2000)
            {
                var i = info.ButtonID - 1000;
                if (i < InvasionControl.Invasions.Count)
                {
                    var invasion = InvasionControl.Invasions[i];
                    invasion.OnStop();
                    InvasionControl.Invasions.Remove(invasion);
                    from.SendMessage("You have deleted the selected invasion!");
                    from.SendGump(new InvasionGump(InvasionControl.Invasions, currentPage));
                }
            }
            else if (info.ButtonID >= 2000 && info.ButtonID < 3000)
            {
                var i = info.ButtonID - 2000;
                if (i < InvasionControl.Invasions.Count)
                {
                    var prop = InvasionControl.Invasions[i];
                    from.SendGump(new PropertiesGump(from, prop));
                    from.SendGump(new InvasionGump(InvasionControl.Invasions, currentPage));
                }
            }
            else if (info.ButtonID == 3000) // Previous
            {
                if (currentPage > 0)
                {
                    from.SendGump(new InvasionGump(InvasionControl.Invasions, currentPage - 1));
                }
            }
            else if (info.ButtonID == 3001) // Next
            {
                if ((currentPage + 1) * EntriesPerPage < InvasionControl.Invasions.Count)
                {
                    from.SendGump(new InvasionGump(InvasionControl.Invasions, currentPage + 1));
                }
            }
        }

        public void AddBlackAlpha(int x, int y, int width, int height)
        {
            AddImageTiled(x, y, width, height, 2624);
            AddAlphaRegion(x, y, width, height);
        }
    }

    public static class InvasionPersistence
    {
        private static readonly string FilePath = Path.Combine("Saves", "Invasions", "Persistence.bin");

        public static void Configure()
        {
            Console.WriteLine("Configuring Invasion Persistence...");
            EventSink.WorldSave += OnSave;
            EventSink.WorldLoad += OnLoad;
            EventSink.WorldSavePostSnapshot += OnWorldSavePostSnapshot;
        }

        private static void OnSave()
        {
            try
            {
                Console.WriteLine("OnSave triggered.");
                string directory = Path.GetDirectoryName(FilePath);
                if (!Directory.Exists(directory))
                {
                    if (directory != null)
                    {
                        Directory.CreateDirectory(directory);
                        Console.WriteLine($"Created directory: {directory}");
                    }
                }

                Console.WriteLine($"Saving invasions to {FilePath}");

                using (var fileStream = new FileStream(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    long initialSize = 1024; // Set an appropriate initial size
                    using (var writer = new MemoryMapFileWriter(fileStream, initialSize))
                    {
                        writer.Write(0); // version
                        writer.Write(InvasionControl.Invasions.Count);
                        Console.WriteLine($"Saving {InvasionControl.Invasions.Count} invasions.");

                        foreach (var invasion in InvasionControl.Invasions)
                        {
                            invasion.Serialize(writer);
                            Console.WriteLine($"Saved invasion: {invasion.InvasionTown}");
                        }
                    }
                }

                Console.WriteLine("Invasion data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving invasion data: " + ex.Message);
            }
        }

        private static void OnLoad()
        {
            if (!File.Exists(FilePath))
            {
                Console.WriteLine($"File not found: {FilePath}");
                return;
            }

            try
            {
                Console.WriteLine($"Loading invasions from {FilePath}");

                using (var fileStream = new FileStream(FilePath, FileMode.Open, FileAccess.Read))
                {
                    var bytes = new byte[fileStream.Length];
                    fileStream.Read(bytes, 0, (int)fileStream.Length);

                    unsafe
                    {
                        fixed (byte* ptr = bytes)
                        {
                            var reader = new UnmanagedDataReader(ptr, bytes.Length);
                            var version = reader.ReadInt();
                            Console.WriteLine($"Invasion data version: {version}");

                            switch (version)
                            {
                                case 0:
                                    {
                                        var count = reader.ReadInt();
                                        Console.WriteLine($"Loading {count} invasions.");

                                        for (var i = 0; i < count; ++i)
                                        {
                                            var invasion = new TownInvasion(reader);
                                            InvasionControl.Invasions.Add(invasion);
                                            Console.WriteLine($"Loaded invasion: {invasion.InvasionTown}");
                                        }
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Unsupported version: " + version);
                                    break;
                            }
                        }
                    }
                }

                Console.WriteLine("Invasion data loaded successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading invasion data: " + ex.Message);
            }
        }

        private static void OnWorldSavePostSnapshot(WorldSavePostSnapshotEventArgs e)
        {
            try
            {
                var backupInvasionsDir = Path.Combine("Backups", "Automatic", DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss"), "Invasions");
                var savesInvasionsDir = Path.Combine("Saves", "Invasions");

                if (!Directory.Exists(savesInvasionsDir))
                {
                    Directory.CreateDirectory(savesInvasionsDir);
                    Console.WriteLine($"Created directory: {savesInvasionsDir}");
                }

                var persistenceFile = Path.Combine(backupInvasionsDir, "Persistence.bin");
                var targetFile = Path.Combine(savesInvasionsDir, "Persistence.bin");

                if (File.Exists(persistenceFile))
                {
                    File.Copy(persistenceFile, targetFile, true);
                    Console.WriteLine($"Copied {persistenceFile} to {targetFile}");
                }
                else
                {
                    Console.WriteLine($"Persistence file not found: {persistenceFile}");
                }

                Console.WriteLine("Invasion data copied to the saves directory.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error copying Invasions directory after world save: " + ex.Message);
            }
        }
    }
}
