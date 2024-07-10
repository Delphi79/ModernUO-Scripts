using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt3", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt3_OnCommand));
		}

		[Usage("AddFloorPt3")]
		
		public static void AddFloorPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt3Gump>();
			e.Mobile.SendGump(new AddFloorPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(10404), new ItemInfo(10405), new ItemInfo(10406), new ItemInfo(10407), new ItemInfo(10408), new ItemInfo(10409), new ItemInfo(10410), new ItemInfo(10411), 
            new ItemInfo(10412), new ItemInfo(10413), new ItemInfo(10414), new ItemInfo(10415), new ItemInfo(10592), new ItemInfo(10593), new ItemInfo(10594), new ItemInfo(10595), 
            new ItemInfo(10596), new ItemInfo(10597), new ItemInfo(10598), new ItemInfo(10599), new ItemInfo(10600), new ItemInfo(10601), new ItemInfo(10602), new ItemInfo(10603), 
            new ItemInfo(10604), new ItemInfo(10605), new ItemInfo(10606), new ItemInfo(10607), new ItemInfo(10608), new ItemInfo(10609), new ItemInfo(10610), new ItemInfo(10611), 
            new ItemInfo(10612), new ItemInfo(10613), new ItemInfo(10614), new ItemInfo(10615), new ItemInfo(10616), new ItemInfo(10617), new ItemInfo(10618), new ItemInfo(10619), 
            new ItemInfo(10620), new ItemInfo(10621), new ItemInfo(10622), new ItemInfo(10623), new ItemInfo(10624), new ItemInfo(10625), new ItemInfo(10626), new ItemInfo(10627), 
            new ItemInfo(10628), new ItemInfo(10629), new ItemInfo(10630), new ItemInfo(10631), new ItemInfo(10632), new ItemInfo(10633), new ItemInfo(10634), new ItemInfo(10635), 
            new ItemInfo(10636), new ItemInfo(10637), new ItemInfo(10638), new ItemInfo(10639), new ItemInfo(10688), new ItemInfo(10689), new ItemInfo(10690), new ItemInfo(10691), 
            new ItemInfo(10692), new ItemInfo(10693), new ItemInfo(10694), new ItemInfo(10695), new ItemInfo(10696), new ItemInfo(10697), new ItemInfo(10698), new ItemInfo(10699), 
            new ItemInfo(10700), new ItemInfo(10701), new ItemInfo(10702), new ItemInfo(10703), new ItemInfo(10704), new ItemInfo(10705), new ItemInfo(10706), new ItemInfo(10707), 
            new ItemInfo(10708), new ItemInfo(10709), new ItemInfo(10710), new ItemInfo(10711), new ItemInfo(10712), new ItemInfo(10713), new ItemInfo(10714), new ItemInfo(10715), 
            new ItemInfo(10781), new ItemInfo(10782), new ItemInfo(10783), new ItemInfo(10784), new ItemInfo(10785), new ItemInfo(10786), new ItemInfo(10787), new ItemInfo(10788), 
            new ItemInfo(10789), new ItemInfo(10790), new ItemInfo(10791), new ItemInfo(10792), new ItemInfo(10793), new ItemInfo(10812), new ItemInfo(10813), new ItemInfo(10814), 
            new ItemInfo(10815), new ItemInfo(10816), new ItemInfo(10817), new ItemInfo(10818), new ItemInfo(10819), new ItemInfo(10820), new ItemInfo(11189), new ItemInfo(11190), 
            new ItemInfo(11191), new ItemInfo(11192), new ItemInfo(11215), new ItemInfo(11500), new ItemInfo(11501), new ItemInfo(11502), new ItemInfo(11576), new ItemInfo(11577), 
            new ItemInfo(11578), new ItemInfo(11579), new ItemInfo(11723), new ItemInfo(11724), new ItemInfo(11725), new ItemInfo(11726), new ItemInfo(11846), new ItemInfo(11847), 
			new ItemInfo(12292), new ItemInfo(12293), 
            new ItemInfo(12294), new ItemInfo(12295), new ItemInfo(13746), new ItemInfo(13747), new ItemInfo(13748), new ItemInfo(13749), new ItemInfo(13750), new ItemInfo(13751), 
            new ItemInfo(13752), new ItemInfo(13753), new ItemInfo(13754), new ItemInfo(13755), new ItemInfo(13756), new ItemInfo(13757), new ItemInfo(13850), new ItemInfo(13851), 
            new ItemInfo(13852), new ItemInfo(13853), new ItemInfo(13854), new ItemInfo(13855), new ItemInfo(13856), new ItemInfo(13857), new ItemInfo(13858), new ItemInfo(16510), 
            new ItemInfo(16511), new ItemInfo(16512), new ItemInfo(16513), new ItemInfo(16514), new ItemInfo(16515), new ItemInfo(16516), new ItemInfo(16517), new ItemInfo(16518), 
            new ItemInfo(16519), new ItemInfo(16520), new ItemInfo(16521), new ItemInfo(16522), new ItemInfo(16523), new ItemInfo(16524), new ItemInfo(16525), new ItemInfo(16526), 
            new ItemInfo(16527), new ItemInfo(16528), new ItemInfo(16529), new ItemInfo(16530), new ItemInfo(16531), new ItemInfo(16532), new ItemInfo(16533), new ItemInfo(16534)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt3Gump()
			: this(0)
		{ }

		public AddFloorPt3Gump(int page) 
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

			from.SendGump(new AddFloorPt3Gump(page));
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
