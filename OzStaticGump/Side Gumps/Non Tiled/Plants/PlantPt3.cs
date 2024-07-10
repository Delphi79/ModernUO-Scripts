using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt3Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt3", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt3_OnCommand));
		}

		[Usage("AddPlantPt3")]
		public static void AddPlantPt3_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt3Gump>();
			e.Mobile.SendGump(new AddPlantPt3Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(4795), new ItemInfo(4796), new ItemInfo(4797), new ItemInfo(4798), new ItemInfo(4799), new ItemInfo(4800), new ItemInfo(4801), new ItemInfo(4802), 
            new ItemInfo(4803), new ItemInfo(4804), new ItemInfo(4805), new ItemInfo(4806), new ItemInfo(4807), new ItemInfo(6802), new ItemInfo(6803), new ItemInfo(6804), 
            new ItemInfo(6805), new ItemInfo(6806), new ItemInfo(6809), new ItemInfo(6810), new ItemInfo(6811), new ItemInfo(7038), new ItemInfo(9324), new ItemInfo(9325), 
            new ItemInfo(9326), new ItemInfo(9327), new ItemInfo(9328), new ItemInfo(9329), new ItemInfo(9330), new ItemInfo(9331), new ItemInfo(9332), new ItemInfo(9333), 
            new ItemInfo(9334), new ItemInfo(9335), new ItemInfo(9336), new ItemInfo(9337), new ItemInfo(9338), new ItemInfo(9339), new ItemInfo(9340), new ItemInfo(9341), 
            new ItemInfo(9342), new ItemInfo(9965), new ItemInfo(9966), new ItemInfo(9967), new ItemInfo(9968), new ItemInfo(9969), new ItemInfo(9970), new ItemInfo(9971),
			new ItemInfo(11513), new ItemInfo(11514), new ItemInfo(11515), new ItemInfo(11516), new ItemInfo(12444), new ItemInfo(12445), new ItemInfo(12446), 
            new ItemInfo(12447), new ItemInfo(12448), new ItemInfo(12449), new ItemInfo(12450), new ItemInfo(12451), new ItemInfo(12452), new ItemInfo(12453), new ItemInfo(12454), 
            new ItemInfo(12455), new ItemInfo(12456), new ItemInfo(12457), new ItemInfo(12458), new ItemInfo(12459), new ItemInfo(12460), new ItemInfo(12461), new ItemInfo(12462), 
            new ItemInfo(12463), new ItemInfo(12464), new ItemInfo(12465), new ItemInfo(12466), new ItemInfo(12467), new ItemInfo(12468), new ItemInfo(12469), new ItemInfo(12470), 
            new ItemInfo(12471), new ItemInfo(12472), new ItemInfo(12473), new ItemInfo(12474), new ItemInfo(12475), new ItemInfo(12476), new ItemInfo(12477), new ItemInfo(12478), 
            new ItemInfo(12479), new ItemInfo(12480), new ItemInfo(12481), new ItemInfo(12482), new ItemInfo(12483), new ItemInfo(12484), new ItemInfo(12485), new ItemInfo(12486), 
            new ItemInfo(12487), new ItemInfo(12488), new ItemInfo(12489), new ItemInfo(12490), new ItemInfo(12491), new ItemInfo(12492), new ItemInfo(12493), new ItemInfo(12494), 
            new ItemInfo(12495), new ItemInfo(12496), new ItemInfo(12497), new ItemInfo(12498), new ItemInfo(12499), new ItemInfo(12500), new ItemInfo(12501), new ItemInfo(12502), 
            new ItemInfo(12503), new ItemInfo(12504), new ItemInfo(12505), new ItemInfo(12506), new ItemInfo(12507), new ItemInfo(12508), new ItemInfo(12509), new ItemInfo(12510), 
            new ItemInfo(12578), new ItemInfo(12579), new ItemInfo(12580), new ItemInfo(13984), new ItemInfo(13985), new ItemInfo(14755), new ItemInfo(14756), new ItemInfo(14757), 
            new ItemInfo(14758), new ItemInfo(14759), new ItemInfo(14760), new ItemInfo(14761), new ItemInfo(14762), new ItemInfo(14763), new ItemInfo(14764), new ItemInfo(14765), 
            new ItemInfo(14766), new ItemInfo(14767), new ItemInfo(14769), new ItemInfo(14770), new ItemInfo(14771), new ItemInfo(14772), new ItemInfo(14773), new ItemInfo(14774), 
            new ItemInfo(14775), new ItemInfo(14776), new ItemInfo(14777), new ItemInfo(14778), new ItemInfo(14779), new ItemInfo(14780), new ItemInfo(14787), new ItemInfo(14788), 
            new ItemInfo(14789), new ItemInfo(14790), new ItemInfo(14791), new ItemInfo(14792), new ItemInfo(14793), new ItemInfo(14794), new ItemInfo(14795), new ItemInfo(14796), 
            new ItemInfo(14797), new ItemInfo(14798), new ItemInfo(14799), new ItemInfo(14800), new ItemInfo(14801), new ItemInfo(14802), new ItemInfo(14803), new ItemInfo(14804), 
            new ItemInfo(14805), new ItemInfo(14806), new ItemInfo(14807), new ItemInfo(14808), new ItemInfo(14809), new ItemInfo(14810), new ItemInfo(14811), new ItemInfo(14812), 
            new ItemInfo(14813), new ItemInfo(14814), new ItemInfo(14815), new ItemInfo(14816), new ItemInfo(14817), new ItemInfo(14818), new ItemInfo(14819), new ItemInfo(14820)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt3Gump()
			: this(0)
		{ }

		public AddPlantPt3Gump(int page) 
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

			from.SendGump(new AddPlantPt3Gump(page));
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
