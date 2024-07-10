/*****************************************
* Script Name: Toolbar                   *
* Author: Joeku AKA Demortris            *
* For use with RunUO 2.0                 *
* Client Tested with: 5.0.7.1            *
* Version: 2.0                           *
* Initial Release: 08/23/06              *
* Revision Date: 04/7/23                 *
******************************************
* Changed by MrBatman, Nerun and ImaNewb *
* For use with ModernUO                  *
* (June 09, 2024)                        *
******************************************/
using System;
using System.Collections.Generic;
using Server;
using Server.Accounting;
using Server.Commands;
using Server.Gumps;
using Server.Network;
using System.IO;

namespace Joeku;

public class JoekuToolbar() : GenericPersistence("JoekuToolbar", 100)
{
    public const int Version = 200;
    public const string ReleaseDate = "June 7, 2023";
    private static readonly Dictionary<Account, ToolbarInfo> _toolbars = new();

    public static void Configure()
    {
        var toolbar = new JoekuToolbar();
        toolbar.Register();
        toolbar.Initialize();
    }

    public void Initialize()
    {
        CommandHandlers.Register("Toolbar", AccessLevel.Counselor, Toolbar_OnCommand);
        EventSink.Connected += OnLogin;
        EventSink.PlayerDeath += OnPlayerDeath;
    }

    public override void Serialize(IGenericWriter writer)
    {
        const int version = 130; // Define the version number being used
        writer.Write(version);
        writer.Write(_toolbars.Count);

        foreach (var (_, t) in _toolbars)
        {
            writer.Write(t.Font);
            writer.Write(t.Phantom);
            writer.Write(t.Stealth);
            writer.Write(t.Reverse);
            writer.Write(t.Lock);
            writer.Write(t.Account == null ? string.Empty : t.Account.Username); // Write account username instead of account directly
            writer.Write(t.Dimensions.Count);
            for (int j = 0; j < t.Dimensions.Count; j++)
            {
                writer.Write(t.Dimensions[j]);
            }
            writer.Write(t.Entries.Count);
            for (int k = 0; k < t.Entries.Count; k++)
            {
                writer.Write(t.Entries[k]);
            }
            writer.Write(t.Skin);
            writer.Write(t.Points.Count);
            for (int l = 0; l < t.Points.Count; l++)
            {
                writer.Write(t.Points[l]);
            }
        }
    }

    public override void Deserialize(IGenericReader reader)
    {
        try
        {
            var version = reader.ReadInt();
            int count = reader.ReadInt();

            for (int i = 0; i < count; i++)
            {
                int skin;
                List<string> entries;
                List<Point3D> points;
                List<int> dimensions;
                Account account = null;
                int font = 0;
                bool phantom = true, stealth = false, reverse = false, locked = true;

                switch (version)
                {
                    case 130:
                        try
                        {
                            font = reader.ReadInt();
                            phantom = reader.ReadBool();
                            stealth = reader.ReadBool();
                            reverse = reader.ReadBool();
                            locked = reader.ReadBool();
                        }
                        catch (EndOfStreamException e)
                        {
                            Console.WriteLine($"Bad deserialize of JoekuToolbar.bin: {e.Message}");
                            if (PromptSkip())
                                return;
                            throw;
                        }
                        goto case 100;

                    default:
                    case 100:
                        try
                        {
                            var username = reader.ReadString();
                            if (!string.IsNullOrEmpty(username))
                            {
                                account = Accounts.GetAccount(username) as Account;
                            }
                            if (account == null)
                            {
                                throw new InvalidOperationException("Deserialized account is null.");
                            }
                            dimensions = ReadList(reader, reader.ReadInt);
                            entries = ReadList(reader, () => reader.ReadString());
                            skin = reader.ReadInt();
                            points = ReadList(reader, reader.ReadPoint3D);
                        }
                        catch (EndOfStreamException e)
                        {
                            Console.WriteLine($"Bad deserialize of JoekuToolbar.bin: {e.Message}");
                            if (PromptSkip())
                                return;
                            throw;
                        }
                        break;
                }

                var info = new ToolbarInfo(account, dimensions, entries, skin, points, font, [phantom, stealth, reverse, locked
                    ]
                );
                _toolbars.Add(account, info);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"An error occurred during deserialization: {ex.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"An unexpected error occurred during deserialization: {e.Message}");
        }
    }

    private static List<T> ReadList<T>(IGenericReader reader, Func<T> readFunc)
    {
        var list = new List<T>();
        try
        {
            var count = reader.ReadInt();
            for (int i = 0; i < count; i++)
            {
                list.Add(readFunc());
            }
        }
        catch (EndOfStreamException e)
        {
            Console.WriteLine($"Bad deserialize of JoekuToolbar.bin: Not enough data to read list of {typeof(T).Name}. {e.Message}");
            throw;
        }
        return list;
    }

    private static bool PromptSkip()
    {
        Console.WriteLine("Skip this file and continue? (y/n):");
        var response = Console.ReadLine();
        return response?.Trim().ToLower() == "y";
    }

    public static ToolbarInfo CreateNew(Mobile mob, Account acc)
    {
        int access = (int)mob.AccessLevel;
        var dimensions = ToolbarInfo.DefaultDimensions(access);
        var entries = ToolbarInfo.DefaultEntries(access);
        const int skin = 0;
        var points = new List<Point3D>();

        Console.WriteLine($"Creating new toolbar for {mob.Name} (Account: {acc.Username})");
        Console.WriteLine($"Access Level: {access}");
        Console.WriteLine($"Default Dimensions: {string.Join(", ", dimensions)}");
        Console.WriteLine($"Default Entries Count: {entries.Count}");

        for (int i = entries.Count; i <= 135; i++)
        {
            entries.Add("(?) to edit");
        }

        Console.WriteLine($"Entries after filling: {entries.Count}");

        var toolbar = new ToolbarInfo(acc, dimensions, entries, skin, points, 0, [true, false, false, true]);
        _toolbars.Add(toolbar.Account, toolbar);

        Console.WriteLine($"Toolbar created for {acc.Username} with dimensions: {string.Join(", ", toolbar.Dimensions)}");

        return toolbar;
    }


    public static void OnPlayerDeath(Mobile m)
    {
        if (m.AccessLevel >= AccessLevel.Counselor)
        {
            m.CloseGump<Toolbar>();
            Timer.DelayCall(TimeSpan.FromSeconds(2.0), SendToolbar, m);
        }
    }

    private static void OnLogin(Mobile m)
    {
        if (m.AccessLevel >= AccessLevel.Counselor)
        {
            Timer.DelayCall(TimeSpan.FromMilliseconds(100), () =>
            {
                m.CloseGump<Toolbar>();
                SendToolbar(m);
            });

            Console.ForegroundColor = ConsoleColor.Green; Console.WriteLine($"{m.Name}'s Toolbar launched"); Console.ResetColor();

        }
    }

    [Usage("Toolbar")]
    public static void Toolbar_OnCommand(CommandEventArgs e)
    {
        e.Mobile.CloseGump<Toolbar>();
        SendToolbar(e.Mobile);
    }

    public static void SendToolbar(Mobile mob)
    {
        var info = GetToolbarInfo(mob);
        if (info != null)
        {
            mob.SendGump(new Toolbar(info));
        }
    }

    public static ToolbarInfo GetToolbarInfo(Mobile mob)
    {
        EnsureMaxed(mob);
        if (mob.Account is Account acc)
        {
            return _toolbars.TryGetValue(acc, out var toolbar) ? toolbar : CreateNew(mob, acc);
        }

        return null;
    }

    public static void EnsureMaxed(Mobile mob)
    {
        if (mob.AccessLevel > ((Account)mob.Account).AccessLevel)
        {
            mob.Account.AccessLevel = mob.AccessLevel;
            Console.WriteLine("***TOOLBAR*** Account {0}, Mobile {1}: AccessLevel resolved to {2}.", ((Account)mob.Account).Username, mob, mob.AccessLevel);
        }
    }
}

public class ToolbarInfo
{
    public int Font { get; set; }
    public bool Phantom { get; set; }
    public bool Stealth { get; set; }
    public bool Reverse { get; set; }
    public bool Lock { get; set; }
    public Account Account { get; set; }
    public List<int> Dimensions { get; set; }
    public List<string> Entries { get; set; }
    public int Skin { get; set; }
    public List<Point3D> Points { get; set; }

    public ToolbarInfo(Account account, List<int> dimensions, List<string> entries, int skin, List<Point3D> points, int font, bool[] switches)
    {
        Dimensions = [];
        Entries = [];
        Points = [];
        SetAttributes(account, dimensions, entries, skin, points, font, switches);
    }

    public void SetAttributes(Account account, List<int> dimensions, List<string> entries, int skin, List<Point3D> points, int font, bool[] switches)
    {
        Font = font;
        Phantom = switches[0];
        Stealth = switches[1];
        Reverse = switches[2];
        Lock = switches[3];
        Account = account;
        Dimensions = dimensions;
        Entries = entries;
        Skin = skin;
        Points = points;
    }

    public static List<string> DefaultEntries(int i)
    {
        var entries = new List<string>();
        switch (i)
        {
            case 0:
                break;
            case 1:
                entries.Add("GMBody"); entries.Add("StaffRunebook"); entries.Add("Stuck"); entries.Add("M Tele"); for (int j = 0; j < 5; j++) { entries.Add("-"); }
                entries.Add("Where"); entries.Add("Who"); entries.Add("Self Hide"); entries.Add("Self Unhide");
                break;
            case 2:
                entries.Add("GMBody"); entries.Add("StaffRunebook"); entries.Add("M Tele"); entries.Add("Where"); entries.Add("Who"); entries.Add("Self Hide"); entries.Add("Self Unhide"); entries.Add("Recover"); for (int j = 0; j < 1; j++) { entries.Add("-"); }
                entries.Add("Spawn"); entries.Add("Move"); entries.Add("M Remove"); entries.Add("Wipe"); entries.Add("Props"); entries.Add("Get Location"); entries.Add("Get ItemID"); entries.Add("AddStairs"); for (int j = 0; j < 1; j++) { entries.Add("-"); }
                entries.Add("AddDoor"); entries.Add("ViewEquip"); entries.Add("Skills"); entries.Add("Kick"); entries.Add("Kill");
                break;
            case 3:
                goto case 2;
            case 4:
                entries.Add("Admin"); entries.Add("GMBody"); entries.Add("StaffRunebook"); entries.Add("Go"); entries.Add("M Tele"); entries.Add("Where"); entries.Add("Who"); entries.Add("Self Hide"); for (int j = 0; j < 1; j++) { entries.Add("-"); }
                entries.Add("Save"); entries.Add("Spawn"); entries.Add("Move"); entries.Add("M Remove"); entries.Add("Wipe"); entries.Add("Props"); entries.Add("Recover"); entries.Add("Self Unhide"); for (int j = 0; j < 1; j++) { entries.Add("-"); }
                entries.Add("AddonGen"); entries.Add("Get Location"); entries.Add("Get ItemID"); entries.Add("AddDoor"); entries.Add("AddStairs"); entries.Add("SpeedBoost"); entries.Add("StaffAccess Player"); entries.Add("ViewEquip");
                break;
            case 5:
                goto case 4;
            case 6:
                goto case 4;
        }
        return entries;
    }

    public static List<int> DefaultDimensions(int i)
    {
        var dimensions = new List<int>();
        switch (i)
        {
            case 0:
                dimensions.Add(0); dimensions.Add(0);
                break;
            case 1:
                dimensions.Add(4); dimensions.Add(2);
                break;
            case 2:
                dimensions.Add(7); dimensions.Add(2);
                break;
            case 3:
                goto case 2;
            case 4:
                dimensions.Add(8); dimensions.Add(3);
                break;
            case 5:
                goto case 4;
            case 6:
                goto case 4;
        }

        return dimensions;
    }
}

public class Toolbar : Gump
{
    private readonly ToolbarInfo p_Info;

    public int Font { get; }
    public bool Phantom { get; }
    public bool Stealth { get; }
    public bool Reverse { get; }
    public bool Lock { get; }
    public List<string> Commands { get; }
    public int Skin { get; }
    public int Columns { get; }
    public int Rows { get; }
    public int InitOptsW, InitOptsH;

    public Toolbar(ToolbarInfo info) : base(0, 28)
    {
        p_Info = info;
        Font = info.Font;
        Phantom = info.Phantom;
        Stealth = info.Stealth;
        Reverse = info.Reverse;
        Lock = info.Lock;
        Commands = info.Entries;
        Skin = info.Skin;
        Columns = info.Dimensions[0];
        Rows = info.Dimensions[1];

        if (Lock)
        {
            Closable = false;
            Disposable = false;
        }

        int offset = GumpIDs.Misc[(int)GumpIDs.MiscIDs.ButtonOffset].Content[Skin, 0];
        int bx = offset * 2 + Columns * 110, by = offset * 2 + Rows * 24, byx = by, cy = 0;

        SetCoords(offset);

        if (Reverse)
        {
            cy = InitOptsH;
            by = 0;
        }

        AddPage(0);
        AddPage(1);
        if (Stealth)
        {
            AddMinimized(by, offset);
            AddPage(2);
        }

        AddInitOpts(by, offset);

        AddBackground(0, cy, bx, byx, GumpIDs.Misc[(int)GumpIDs.MiscIDs.Background].Content[Skin, 0]);

        string font = GumpIDs.Fonts[Font];
        if (Phantom)
        {
            font += "<BASEFONT COLOR=#FFFFFF>";
        }

        int temp = 0;
        for (int i = 0; i < Columns * Rows; i++)
        {
            var x = offset + i % Columns * 110;
            var y = offset + i / Columns * 24 + cy;
            AddButton(x + 1, y, 2445, 2445, temp + 10);
            AddBackground(x, y, 110, 24, GumpIDs.Misc[(int)GumpIDs.MiscIDs.Buttonground].Content[Skin, 0]);

            if (Phantom)
            {
                AddImageTiled(x + 2, y + 2, 106, 20, 2624);
                AddAlphaRegion(x + 2, y + 2, 106, 20);
            }

            AddHtml(x + 5, y + 3, 100, 20, $"<center>{font}{Commands[temp]}");

            if (i % Columns == Columns - 1)
            {
                temp += 9 - Columns;
            }

            temp++;
        }

        if (!Stealth)
        {
            AddPage(2);
            AddMinimized(by, offset);
        }
    }

    public override void OnResponse(NetState sender, in RelayInfo info)
    {
        var mob = sender.Mobile;
        string prefix = CommandSystem.Prefix;

        switch (info.ButtonID)
        {
            default:
                mob.SendGump(this);
                mob.SendMessage(Commands[info.ButtonID - 10]);
                CommandSystem.Handle(mob, $"{prefix}{Commands[info.ButtonID - 10]}");
                break;
            case 0:
                break;
            case 1:
                mob.SendGump(this);
                mob.CloseGump<ToolbarEdit>();
                mob.SendGump(new ToolbarEdit(p_Info));
                break;
        }
    }

    public void SetCoords(int offset)
    {
        InitOptsW = 50 + offset * 2 + GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 2] + 5 + GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 2];
        InitOptsH = offset * 2 + GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 3];
        if (GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 3] + offset * 2 > InitOptsH)
        {
            InitOptsH = GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 3] + offset * 2;
        }
    }

    public void AddInitOpts(int y, int offset)
    {
        AddBackground(0, y, InitOptsW, InitOptsH, GumpIDs.Misc[(int)GumpIDs.MiscIDs.Background].Content[Skin, 0]);
        AddButton(offset, y + offset, GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 0], GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 1], 0, GumpButtonType.Page, Stealth ? 1 : 2);
        AddButton(offset + GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 2] + 5, y + offset, GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 0], GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 1], 1);
    }

    public void AddMinimized(int y, int offset)
    {
        AddBackground(0, y, InitOptsW, InitOptsH, GumpIDs.Misc[(int)GumpIDs.MiscIDs.Background].Content[Skin, 0]);
        AddButton(offset, y + offset, GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Maximize].Content[Skin, 0], GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Maximize].Content[Skin, 1], 0, GumpButtonType.Page, Stealth ? 2 : 1);
        AddButton(offset + GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Minimize].Content[Skin, 2] + 5, y + offset, GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 0], GumpIDs.Buttons[(int)GumpIDs.ButtonIDs.Customize].Content[Skin, 1], 1);
    }
}

public class ToolbarEdit : Gump
{
    public static readonly string HTML =
        $"<center><u>Command Toolbar v{(double)JoekuToolbar.Version / 100}</u><br>Made by Joeku AKA Demortris<br>{JoekuToolbar.ReleaseDate}<br>- Customized to Nerun's Distro -</center><br>   This toolbar is extremely versatile. You can switch skins and increase or decrease columns or rows. The toolbar operates like a spreadsheet; you can use the navigation menu to scroll through different commands and bind them. Enjoy!<br><p>If you have questions, concerns, or bug reports, please <A HREF=\"mailto:demortris@adelphia.net\">e-mail me</A>.";
    private readonly bool p_Expanded;
    private readonly int p_ExpandedInt;
    private readonly ToolbarInfo p_Info;

    public int Font { get; set; }
    public bool Phantom { get; set; }
    public bool Stealth { get; set; }
    public bool Reverse { get; set; }
    public bool Lock { get; set; }
    public List<string> Commands { get; set; }
    public int Skin { get; set; }
    public int Columns { get; set; }
    public int Rows { get; set; }

    public ToolbarEdit(ToolbarInfo info, bool expanded = false) : this(
        info,
        expanded,
        info.Entries,
        info.Skin,
        info.Dimensions[0],
        info.Dimensions[1],
        info.Font,
        [info.Phantom, info.Stealth, info.Reverse, info.Lock]
    )
    {
    }

    public ToolbarEdit(ToolbarInfo info, List<string> commands, int skin, int columns, int rows, int font, bool[] switches) :
        this(info, false, commands, skin, columns, rows, font, switches)
    {
    }

    public ToolbarEdit(ToolbarInfo info, bool expanded, List<string> commands, int skin, int columns, int rows, int font, bool[] switches) : base(0, 28)
    {
        p_Info = info;
        p_Expanded = expanded;
        p_ExpandedInt = expanded ? 2 : 1;

        Font = font;
        Phantom = switches[0];
        Stealth = switches[1];
        Reverse = switches[2];
        Lock = switches[3];

        Commands = commands;
        Skin = skin;
        Columns = columns;
        Rows = rows;

        AddInit();
        AddControls();
        AddNavigation();
        AddResponses();
        AddEntries();
    }

    public override void OnResponse(NetState sender, in RelayInfo info)
    {
        var m = sender.Mobile;

        bool[] switches =
        [
            info.IsSwitched(21),
            info.IsSwitched(23),
            info.IsSwitched(25),
            info.IsSwitched(27)
        ];

        switch (info.ButtonID)
        {
            case 0:
                break;
            case 1:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin + 1, Columns, Rows, Font, switches)); break;
            case 2:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin - 1, Columns, Rows, Font, switches)); break;
            case 3:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows + 1, Font, switches)); break;
            case 4:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows - 1, Font, switches)); break;
            case 5:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns + 1, Rows, Font, switches)); break;
            case 6:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns - 1, Rows, Font, switches)); break;
            case 9:
                var toolbarinfo = ToolbarInfo.DefaultEntries((int)m.AccessLevel);
                CombineEntries(info, toolbarinfo);
                toolbarinfo.AddRange(AnalyzeEntries(info, toolbarinfo.Count));
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, toolbarinfo, Skin, Columns, Rows, Font, switches));
                break;
            case 10:
                goto case 12;
            case 11:
                goto case 0;
            case 12:
                var toolbar = JoekuToolbar.GetToolbarInfo(m);
                if (toolbar != null)
                {
                    List<int> dims = [Columns, Rows];
                    toolbar.SetAttributes(m.Account as Account, dims, AnalyzeEntries(info), Skin, toolbar.Points, Font, switches);

                    if (info.ButtonID == 12)
                    {
                        m.SendGump(new ToolbarEdit(toolbar, p_Expanded));
                    }

                    m.CloseGump<Toolbar>();
                    m.SendGump(new Toolbar(toolbar));
                }
                break;
            case 18:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font + 1, switches)); break;
            case 19:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font - 1, switches)); break;
            case 20:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font, switches));
                m.SendMessage(2101, "Phantom mode turns the toolbar semi-transparent.");
                break;
            case 22:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font, switches));
                m.SendMessage(2101, "Stealth mode makes the toolbar automatically minimize when you click a button.");
                break;
            case 24:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font, switches));
                m.SendMessage(2101, "Reverse mode puts the minimize bar above the toolbar instead of below.");
                break;
            case 26:
                m.SendGump(new ToolbarEdit(p_Info, p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font, switches));
                m.SendMessage(2101, "Lock mode disables closing the toolbar with right-click.");
                break;
            case 28:
                m.SendGump(new ToolbarEdit(p_Info, !p_Expanded, AnalyzeEntries(info), Skin, Columns, Rows, Font, switches));
                m.SendMessage(2101, p_Expanded ? "Expanded view deactivated." : "Expanded view activated.");
                break;
        }
    }

    public void CombineEntries(RelayInfo info, List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            string temp;
            if (list[i] == "-*UNUSED*-" && (temp = info.GetTextEntry(i + 13)) != "")
            {
                list[i] = temp;
            }
        }
    }

    public List<string> AnalyzeEntries(RelayInfo info) => AnalyzeEntries(info, 0);

    public List<string> AnalyzeEntries(RelayInfo info, int i)
    {
        var list = new List<string>();

        for (int j = i; j < 135; j++)
        {
            string temp = info.GetTextEntry(j + 13);
            list.Add(temp == "" ? "-*UNUSED*-" : temp);
        }

        return list;
    }

    public void AddInit()
    {
        AddPage(0);
        AddBackground(0, 0, 620, 120, 9200);
        AddHtml(10, 10, 240, 100, HTML, true, true);
    }

    public void AddControls()
    {
        AddBackground(260, 0, 240, 120, 9200);
        AddLabel(274, 11, 0, $"Skin - {Skin + 1}");
        if (Skin < GumpIDs.Skins - 1)
        {
            AddButton(359, 10, 2435, 2436, 1);
        }

        if (Skin > 0)
        {
            AddButton(359, 21, 2437, 2438, 2);
        }

        AddLabel(274, 36, 0, $"Rows - {Rows}");
        if (Rows < 15)
        {
            AddButton(359, 35, 2435, 2436, 3);
        }

        if (Rows > 1)
        {
            AddButton(359, 46, 2437, 2438, 4);
        }

        AddLabel(274, 61, 0, $"Columns - {Columns}");
        if (Columns < 9)
        {
            AddButton(359, 60, 2435, 2436, 5);
        }

        if (Columns > 1)
        {
            AddButton(359, 71, 2437, 2438, 6);
        }

        AddHtml(276, 87, 100, 20, $"{GumpIDs.Fonts[Font]}Font - {Font + 1}");
        if (Font < GumpIDs.Fonts.Length - 1)
        {
            AddButton(359, 85, 2435, 2436, 18);
        }

        if (Font > 0)
        {
            AddButton(359, 96, 2437, 2438, 19);
        }

        AddLabel(389, 11, 0, "Phantom");
        AddButton(446, 13, 22153, 22155, 20);
        AddCheck(469, 11, 210, 211, Phantom, 21);
        AddLabel(389, 36, 0, "Stealth");
        AddButton(446, 38, 22153, 22155, 22);
        AddCheck(469, 36, 210, 211, Stealth, 23);
        AddLabel(389, 61, 0, "Reverse");
        AddButton(446, 63, 22153, 22155, 24);
        AddCheck(469, 61, 210, 211, Reverse, 25);
        AddLabel(389, 86, 0, "Lock");
        AddButton(446, 88, 22153, 22155, 26);
        AddCheck(469, 86, 210, 211, Lock, 27);
    }

    public void AddNavigation()
    {
        AddBackground(500, 0, 120, 120, 9200);
        AddHtml(500, 10, 120, 20, @"<center><u>Navigation</u></center>");
        AddLabel(508, 92, 0, "Expanded View");
        AddButton(595, 95, p_Expanded ? 5603 : 5601, p_Expanded ? 5607 : 5605, 28);
    }

    public void AddResponses()
    {
        int temp = 170 + p_ExpandedInt * 100;
        AddBackground(0, temp, 500, 33, 9200);
        AddButton(50, temp + 5, 246, 244, 9);
        AddButton(162, temp + 5, 249, 248, 10);
        AddButton(275, temp + 5, 243, 241, 11);
        AddButton(387, temp + 5, 239, 240, 12);
    }

    public void AddEntries()
    {
        int buffer = 2;
        int entryX = p_ExpandedInt * 149, entryY = p_ExpandedInt * 20;
        int bgX = 10 + 4 + buffer * 3 + entryX * 3, bgY = 10 + 8 + entryY * 5;
        int divX = bgX - 10, divY = bgY - 10;

        AddBackground(0, 120, 33 + bgX, 32 + bgY, 9200);
        AddBackground(33, 152, bgX, bgY, 9200);

        for (int m = 1; m <= 2; m++)
        {
            AddImageTiled(38 + m * entryX + buffer + (m - 1) * 4, 157, 2, divY, 10004);
        }

        for (int n = 1; n <= 4; n++)
        {
            AddImageTiled(38, 155 + n * (entryY + 2), divX, 2, 10001);
        }

        int start = -3;

        for (int i = 1; i <= 9; i++)
        {
            start += 3;
            start = i switch
            {
                4 => 45,
                7 => 90,
                _ => start
            };

            var temp = start;

            AddPage(i);
            CalculatePages(i);

            for (int j = 0; j < 3; j++)
            {
                AddHtml(38 + buffer + j % 3 * (buffer + entryX + 2), 128, entryX, 20,
                    $"<center>Column {j + 1 + CalculateColumns(i)}</center>");
            }

            AddHtml(2, 128, 30, 20, "<center>Row</center>");

            int tempInt = 0;
            if (p_Expanded)
            {
                tempInt = 11;
            }

            for (int k = 0; k < 5; k++)
            {
                AddHtml(0, 157 + k * (entryY + 2) + tempInt, 32, 20, $"<center>{k + 1 + CalculateRows(i)}</center>");
            }

            for (int l = 0; l < 15; l++)
            {
                AddTextEntry(38 + buffer + l % 3 * (buffer * 2 + entryX), 157 + (int)Math.Floor((double)l / 3) * (entryY + 2), entryX - 1, entryY, 2101, temp + 13, Commands[temp]);

                if (l % 3 == 2)
                {
                    temp += 6;
                }

                temp++;
            }
        }
    }

    public void CalculatePages(int i)
    {
        int up = 0, down = 0, left = 0, right = 0;
        switch (i)
        {
            case 1:
                down = 4; right = 2; break;
            case 2:
                down = 5; left = 1; right = 3; break;
            case 3:
                down = 6; left = 2; break;
            case 4:
                up = 1; down = 7; right = 5; break;
            case 5:
                up = 2; down = 8; left = 4; right = 6; break;
            case 6:
                up = 3; down = 9; left = 5; break;
            case 7:
                up = 4; right = 8; break;
            case 8:
                up = 5; left = 7; right = 9; break;
            case 9:
                up = 6; left = 8; break;
        }

        AddNavigation(up, down, left, right);
    }

    public void AddNavigation(int up, int down, int left, int right)
    {
        if (up > 0)
        {
            AddButton(549, 34, 9900, 9902, 0, GumpButtonType.Page, up);
        }

        if (down > 0)
        {
            AddButton(549, 65, 9906, 9908, 0, GumpButtonType.Page, down);
        }

        if (left > 0)
        {
            AddButton(523, 50, 9909, 9911, 0, GumpButtonType.Page, left);
        }

        if (right > 0)
        {
            AddButton(575, 50, 9903, 9905, 0, GumpButtonType.Page, right);
        }
    }

    public static int CalculateColumns(int i) =>
        i switch
        {
            1 or 4 or 7 => 0,
            2 or 5 or 8 => 3,
            _ => 6
        };

    public static int CalculateRows(int i) =>
        i switch
        {
            >= 1 and <= 3 => 0,
            <= 6 => 5,
            _ => 10
        };
}

public class GumpIDs
{
    public enum MiscIDs
    {
        Background = 0,
        Color = 1,
        Buttonground = 2,
        ButtonOffset = 3,
    }

    public enum ButtonIDs
    {
        Minimize = 0,
        Maximize = 1,
        Customize = 2,
        SpecialCommand = 3,
        Send = 4,
        Teleport = 5,
        Gate = 6,
    }

    public int ID { get; set; }
    public int[,] Content { get; }
    public string Name { get; set; }

    public GumpIDs(int id, string name, int[,] content)
    {
        ID = id;
        Content = content;
        Name = name;
    }

    public static string[] Fonts { get; } = ["", "<b>", "<i>", "<b><i>", "<small>", "<b><small>", "<i><small>", "<b><i><small>", "<big>", "<b><big>", "<i><big>", "<b><i><big>"
    ];
    public const int Skins = 2;
    public static GumpIDs[] Misc { get; set; } =
    [
        new(0, "Background", new[,]{{ 9200 }, { 9270 }}),
        new(1, "Color", new[,]{{ 0 }, { 0 }}),
        new(2, "Buttonground", new[,]{{ 9200 }, { 9350 }}),
        new(3, "ButtonOffset", new[,]{{ 5 }, { 7 }})
    ];

    public static GumpIDs[] Buttons { get; set; } =
    [
        new(0, "Minimize", new[,]{{ 5603, 5607, 16, 16 }, { 5537, 5539, 19, 21 }}),
        new(1, "Maximize", new[,]{{ 5601, 5605, 16, 16 }, { 5540, 5542, 19, 21 }}),
        new(2, "Customize", new[,]{{ 22153, 22155, 16, 16 }, { 5525, 5527, 62, 24 }}),
        new(3, "SpecialCommand", new[,]{{ 2117, 2118, 15, 15 }, { 9720, 9722, 29, 29 }}),
        new(4, "Send", new[,]{{ 2360, 2360, 11, 11 }, { 2360, 2360, 11, 11 }}),
        new(5, "Teleport", new[,]{{ 2361, 2361, 11, 11 }, { 2361, 2361, 11, 11 }}),
        new(6, "Gate", new[,]{{ 2362, 2362, 11, 11 }, { 2361, 2361, 11, 11 }})
    ];
}
