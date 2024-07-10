using Server.Network;

namespace Server.Gumps
{
	public class AddGroundStPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGroundStPt3", AccessLevel.GameMaster, new CommandEventHandler(AddGroundStPt3_OnCommand));
		}

		[Usage("AddGroundStPt3")]
		
		public static void AddGroundStPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGroundStPt3Gump>();
			e.Mobile.SendGump(new AddGroundStPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region GroundSts
            new ItemInfo(11973), new ItemInfo(11974), new ItemInfo(11975), new ItemInfo(11976), new ItemInfo(11977), new ItemInfo(11978), new ItemInfo(11979), new ItemInfo(11980), 
            new ItemInfo(11981), new ItemInfo(11982), new ItemInfo(11983), new ItemInfo(11984), new ItemInfo(11985), new ItemInfo(11986), new ItemInfo(11987), new ItemInfo(11988), 
            new ItemInfo(11989), new ItemInfo(11990), new ItemInfo(11991), new ItemInfo(11992), new ItemInfo(11993), new ItemInfo(11994), new ItemInfo(11995), new ItemInfo(12001), 
            new ItemInfo(12002), new ItemInfo(12003), new ItemInfo(12004), new ItemInfo(12005), new ItemInfo(12006), new ItemInfo(12007), new ItemInfo(12008), new ItemInfo(12009), 
            new ItemInfo(12010), new ItemInfo(12011), new ItemInfo(12012), new ItemInfo(12013), new ItemInfo(12014), new ItemInfo(12015), new ItemInfo(12016), new ItemInfo(12017), 
            new ItemInfo(12018), new ItemInfo(12019), new ItemInfo(12020), new ItemInfo(12021), new ItemInfo(12022), new ItemInfo(12023), new ItemInfo(12024), new ItemInfo(12025), 
            new ItemInfo(12026), new ItemInfo(12027), new ItemInfo(12028), new ItemInfo(12029), new ItemInfo(12030), new ItemInfo(12031), new ItemInfo(12032), new ItemInfo(12033), 
            new ItemInfo(12034), new ItemInfo(12035), new ItemInfo(12036), new ItemInfo(12037), new ItemInfo(12038), new ItemInfo(12039), new ItemInfo(12040), new ItemInfo(12041), 
            new ItemInfo(12042), new ItemInfo(12043), new ItemInfo(12044), new ItemInfo(12045), new ItemInfo(12046), new ItemInfo(12130), new ItemInfo(12131), new ItemInfo(12132), 
            new ItemInfo(12133), new ItemInfo(12134), new ItemInfo(12135), new ItemInfo(12136), new ItemInfo(12137), new ItemInfo(12138), new ItemInfo(12139), new ItemInfo(12140), 
            new ItemInfo(12141), new ItemInfo(12142), new ItemInfo(12143), new ItemInfo(12144), new ItemInfo(12145), new ItemInfo(12146), new ItemInfo(12147), new ItemInfo(12148), 
            new ItemInfo(12149), new ItemInfo(12150), new ItemInfo(12151), new ItemInfo(12152), new ItemInfo(12153), new ItemInfo(12154), new ItemInfo(12155), new ItemInfo(12156), 
            new ItemInfo(12157), new ItemInfo(12158), new ItemInfo(12159), new ItemInfo(12160), new ItemInfo(12161), new ItemInfo(12162), new ItemInfo(12163), new ItemInfo(12164), 
            new ItemInfo(12165), new ItemInfo(12166), new ItemInfo(12167), new ItemInfo(12168), new ItemInfo(12169), new ItemInfo(12170), new ItemInfo(12171), new ItemInfo(12172), 
            new ItemInfo(12173), new ItemInfo(12174), new ItemInfo(12175), new ItemInfo(12176), new ItemInfo(12177), new ItemInfo(12178), new ItemInfo(12179), new ItemInfo(12180), 
            new ItemInfo(12181), new ItemInfo(12182), new ItemInfo(12183), new ItemInfo(12184), new ItemInfo(12185), new ItemInfo(12186), new ItemInfo(12187), new ItemInfo(12188), 
            new ItemInfo(12189), new ItemInfo(12190), new ItemInfo(12191), new ItemInfo(12192), new ItemInfo(12193), new ItemInfo(12194), new ItemInfo(12195), new ItemInfo(12196), 
            new ItemInfo(12197), new ItemInfo(12198), new ItemInfo(12199), new ItemInfo(12200), new ItemInfo(12201), new ItemInfo(12202), new ItemInfo(12203), new ItemInfo(12204), 
            new ItemInfo(12205), new ItemInfo(12206), new ItemInfo(12207), new ItemInfo(12208), new ItemInfo(12209), new ItemInfo(12210), new ItemInfo(12211), new ItemInfo(12212), 
            new ItemInfo(12213), new ItemInfo(12519), new ItemInfo(12520), new ItemInfo(12521), new ItemInfo(12522), new ItemInfo(12523), new ItemInfo(12524), new ItemInfo(12525), 
            new ItemInfo(12526), new ItemInfo(12527), new ItemInfo(12528), new ItemInfo(12529), new ItemInfo(12530), new ItemInfo(12531), new ItemInfo(12532), new ItemInfo(12533), 
            new ItemInfo(12534), new ItemInfo(12535), new ItemInfo(12536), new ItemInfo(12537), new ItemInfo(12538), new ItemInfo(12539), new ItemInfo(12540), new ItemInfo(12541)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGroundStPt3Gump()
			: this(0)
		{ }

		public AddGroundStPt3Gump(int page) 
			: base(0, 0)
		{
			int pageCount = 1 + (m_Types.Length / 12);

			if (page >= pageCount)
				page = pageCount - 1;
			else if (page < 0)
				page = 0;

			m_Page = page;

			Closable = true;
			Disposable = true;
			Draggable = true;
			Resizable = false;

			AddPage(0);

			AddBackground(0, 0, 720, 180, 3500);

			AddHtmlLocalized(15, 15, 60, 20, 1042971, page.ToString(), 0x1, false, false); // #

			AddHtmlLocalized(20, 38, 60, 20, 1043353, 0x1, false, false); // Next

			if (page + 1 < pageCount)
				AddButton(15, 55, 0xFA5, 0xFA7, 10000 + (page + 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 55, 0xFA5, 0xFA7, 10000, GumpButtonType.Reply, 0);

			AddHtmlLocalized(20, 93, 60, 20, 1011393, 0x1, false, false); // Back

			if (page > 0)
				AddButton(15, 110, 0xFAE, 0xFB0, 10000 + (page - 1), GumpButtonType.Reply, 0);
			else
				AddButton(15, 110, 0xFAE, 0xFB0, 10000, GumpButtonType.Reply, 0);

			for (int i = 0; i < 12; ++i)
			{
				int index = (page * 12) + i;
				if(index >= m_Types.Length) break;

				int button = 1000000 + index;
				int offset = (i + 1) * 50;

				if (m_Types[index].m_BaseID > 0)
				{
					AddButton(45 + offset, 20, 0x2624, 0x2625, button, GumpButtonType.Reply, m_Types[index].m_BaseID);
					AddItem(50 + offset, 40, m_Types[index].m_BaseID);
				}
				else
				{
					AddImage(25 + offset, 20, 0x2625, 900);
				}
			}
		}

		public override void OnResponse(NetState sender, in RelayInfo info)
		{
			Mobile from = sender.Mobile;

			int button = info.ButtonID;

			if (button <= 0)
				return;

			int page = m_Page;

			if (button >= 1000000)
			{
				button -= 1000000;

				CommandSystem.Handle(from, string.Format("{0}Tile Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddGroundStPt3Gump(page));
		}

		public class ItemInfo
		{
			public int m_BaseID;

			public ItemInfo(int baseID)
			{
				m_BaseID = baseID;
			}
		}
	}
}
