using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt4", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt4_OnCommand));
		}

		[Usage("AddFurnPt4")]
		public static void AddFurnPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt4Gump>();
			e.Mobile.SendGump(new AddFurnPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(11755), new ItemInfo(11756), new ItemInfo(11757), new ItemInfo(11758), new ItemInfo(11759), new ItemInfo(11760), new ItemInfo(11761), 
            new ItemInfo(11762), new ItemInfo(11763), new ItemInfo(11764), new ItemInfo(11765), new ItemInfo(11766), new ItemInfo(12364), new ItemInfo(12365), 
            new ItemInfo(12368), new ItemInfo(12369), new ItemInfo(12370), new ItemInfo(12371), new ItemInfo(12372), new ItemInfo(12373), new ItemInfo(12374), 
            new ItemInfo(12375), new ItemInfo(12376), new ItemInfo(12377), new ItemInfo(12420), new ItemInfo(12421), new ItemInfo(12422), new ItemInfo(12423), 
            new ItemInfo(12424), new ItemInfo(12425), new ItemInfo(12426), new ItemInfo(12427), new ItemInfo(12428), new ItemInfo(12429), new ItemInfo(12430), 
            new ItemInfo(12431), new ItemInfo(12432), new ItemInfo(12433), new ItemInfo(12434), new ItemInfo(12435), new ItemInfo(12436), new ItemInfo(12437), 
            new ItemInfo(12438), new ItemInfo(12439), new ItemInfo(12440), new ItemInfo(12441), new ItemInfo(12442), new ItemInfo(12443), new ItemInfo(12511), 
            new ItemInfo(12512), new ItemInfo(12513), new ItemInfo(12514), new ItemInfo(12515), new ItemInfo(12516), new ItemInfo(12517), new ItemInfo(12518), 
            new ItemInfo(12698), new ItemInfo(12699), new ItemInfo(15754), new ItemInfo(15755), new ItemInfo(15756), new ItemInfo(15757), new ItemInfo(15758), 
            new ItemInfo(15759), new ItemInfo(15760), new ItemInfo(15761), new ItemInfo(15762), new ItemInfo(15763), new ItemInfo(16396), new ItemInfo(16397), 
            new ItemInfo(16398), new ItemInfo(16399), new ItemInfo(16400), new ItemInfo(16401), new ItemInfo(16402), new ItemInfo(16403), new ItemInfo(16404), 
            new ItemInfo(16405), new ItemInfo(16406), new ItemInfo(16407), new ItemInfo(16408), new ItemInfo(16409), new ItemInfo(16410), new ItemInfo(16411), 
            new ItemInfo(16412), new ItemInfo(16413), new ItemInfo(16414), new ItemInfo(16415), new ItemInfo(16416), new ItemInfo(16417), new ItemInfo(16419), 
            new ItemInfo(16420), new ItemInfo(16423), new ItemInfo(16424), new ItemInfo(16425), new ItemInfo(16426), new ItemInfo(16427), new ItemInfo(16428), 
            new ItemInfo(16429), new ItemInfo(16430), new ItemInfo(16431), new ItemInfo(16432), new ItemInfo(16433), new ItemInfo(16434), new ItemInfo(16435), 
            new ItemInfo(16436), new ItemInfo(16437), new ItemInfo(16438), new ItemInfo(16439), new ItemInfo(16440), new ItemInfo(16441), new ItemInfo(16442), 
            new ItemInfo(16443), new ItemInfo(16444), new ItemInfo(16445), new ItemInfo(16446), new ItemInfo(16447), new ItemInfo(16448), new ItemInfo(16449), 
            new ItemInfo(16450), new ItemInfo(16451), new ItemInfo(16452), new ItemInfo(16453), new ItemInfo(16454), new ItemInfo(17621), new ItemInfo(17622), 
            new ItemInfo(17623), new ItemInfo(17624), new ItemInfo(17625), new ItemInfo(17626), new ItemInfo(17627), new ItemInfo(17628), new ItemInfo(17629), 
            new ItemInfo(17630), new ItemInfo(17631), new ItemInfo(17632), new ItemInfo(17633), new ItemInfo(17634), new ItemInfo(17635), new ItemInfo(17636)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt4Gump()
			: this(0)
		{ }

		public AddFurnPt4Gump(int page) 
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

				CommandSystem.Handle(from, string.Format("{0}M Add Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddFurnPt4Gump(page));
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
