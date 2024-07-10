using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt3", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt3_OnCommand));
		}

		[Usage("AddFurnPt3")]
		public static void AddFurnPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt3Gump>();
			e.Mobile.SendGump(new AddFurnPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(4618), new ItemInfo(4619), new ItemInfo(4620), new ItemInfo(4632), new ItemInfo(4633), new ItemInfo(4634), new ItemInfo(4635), 
			new ItemInfo(4566), new ItemInfo(4567), new ItemInfo(4568), new ItemInfo(4569), new ItemInfo(4570), new ItemInfo(4571), new ItemInfo(4572), 
			new ItemInfo(4573), new ItemInfo(4574), new ItemInfo(4575), new ItemInfo(4576), new ItemInfo(4577), 
            new ItemInfo(6292), new ItemInfo(6293), new ItemInfo(6294), new ItemInfo(6295), new ItemInfo(6296), new ItemInfo(6297), new ItemInfo(6298), 
            new ItemInfo(6299), new ItemInfo(6416), new ItemInfo(6417), new ItemInfo(6418), new ItemInfo(6419), new ItemInfo(6420), new ItemInfo(6421), 
            new ItemInfo(6422), new ItemInfo(6423), new ItemInfo(6424), new ItemInfo(6425), new ItemInfo(6426), new ItemInfo(6427), new ItemInfo(6428), 
            new ItemInfo(6429), new ItemInfo(6430), new ItemInfo(6431), new ItemInfo(7589), new ItemInfo(7590), new ItemInfo(7591), new ItemInfo(7592), 
            new ItemInfo(7593), new ItemInfo(7594), new ItemInfo(7595), new ItemInfo(7596), new ItemInfo(7611), new ItemInfo(7612), new ItemInfo(7613),
            new ItemInfo(7614), new ItemInfo(7615), new ItemInfo(7616), new ItemInfo(7617), new ItemInfo(7618), new ItemInfo(7619), new ItemInfo(7620), 
            new ItemInfo(7621), new ItemInfo(7622), new ItemInfo(7623), new ItemInfo(7624), new ItemInfo(7625), new ItemInfo(7626), new ItemInfo(7627), 
            new ItemInfo(7628), new ItemInfo(7629), new ItemInfo(7630), new ItemInfo(7631), new ItemInfo(7632), new ItemInfo(7633), new ItemInfo(7634), 
            new ItemInfo(7790), new ItemInfo(7791), new ItemInfo(7792), new ItemInfo(7793), new ItemInfo(7794), new ItemInfo(7795), new ItemInfo(7796), 
            new ItemInfo(7797), new ItemInfo(7798), new ItemInfo(7799), new ItemInfo(7800), new ItemInfo(7801), new ItemInfo(7802), new ItemInfo(7803), 
            new ItemInfo(7804), new ItemInfo(7805), new ItemInfo(7806), new ItemInfo(7807), new ItemInfo(7808), new ItemInfo(7809), new ItemInfo(7810), 
            new ItemInfo(7972), new ItemInfo(7973), new ItemInfo(7974), new ItemInfo(7975), new ItemInfo(10251), new ItemInfo(10252), new ItemInfo(10253), 
            new ItemInfo(10254), new ItemInfo(10255), new ItemInfo(10256), new ItemInfo(10257), new ItemInfo(10258), new ItemInfo(10259), new ItemInfo(10260), 
            new ItemInfo(10261), new ItemInfo(10262), new ItemInfo(10263), new ItemInfo(10264), new ItemInfo(10265), new ItemInfo(10266), new ItemInfo(10327), 
            new ItemInfo(10328), new ItemInfo(10329), new ItemInfo(10330), new ItemInfo(10331), new ItemInfo(10332), new ItemInfo(10333), new ItemInfo(10334), 
            new ItemInfo(11217), new ItemInfo(11218), new ItemInfo(11219), new ItemInfo(11220), new ItemInfo(11221), new ItemInfo(11222), new ItemInfo(11223), 
            new ItemInfo(11224), new ItemInfo(11525), new ItemInfo(11526), new ItemInfo(11527), new ItemInfo(11528), new ItemInfo(11529), new ItemInfo(11530), 
            new ItemInfo(11531), new ItemInfo(11532), new ItemInfo(11743), new ItemInfo(11744), new ItemInfo(11745), new ItemInfo(11746), new ItemInfo(11747), 
            new ItemInfo(11748), new ItemInfo(11749), new ItemInfo(11750), new ItemInfo(11751), new ItemInfo(11752), new ItemInfo(11753), new ItemInfo(11754)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt3Gump()
			: this(0)
		{ }

		public AddFurnPt3Gump(int page) 
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

			from.SendGump(new AddFurnPt3Gump(page));
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
