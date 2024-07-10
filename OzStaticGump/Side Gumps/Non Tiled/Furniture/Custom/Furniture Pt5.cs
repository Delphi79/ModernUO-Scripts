using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt5", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt5_OnCommand));
		}

		[Usage("AddFurnPt5")]
		public static void AddFurnPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt5Gump>();
			e.Mobile.SendGump(new AddFurnPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(40447), new ItemInfo(40448), new ItemInfo(40449), new ItemInfo(40450), new ItemInfo(40451), new ItemInfo(40452), new ItemInfo(40453), 
            new ItemInfo(40454), new ItemInfo(40455), new ItemInfo(40456), new ItemInfo(40457), new ItemInfo(40458), new ItemInfo(40459), new ItemInfo(40460), 
            new ItemInfo(40461), new ItemInfo(40462), new ItemInfo(40463), new ItemInfo(40464), new ItemInfo(40465), new ItemInfo(40466), new ItemInfo(40467), 
            new ItemInfo(40468), new ItemInfo(40469), new ItemInfo(40470), new ItemInfo(40471), new ItemInfo(40472), new ItemInfo(40473), new ItemInfo(40474), 
            new ItemInfo(40475), new ItemInfo(40476), new ItemInfo(40477), new ItemInfo(40478), new ItemInfo(40479), new ItemInfo(40480), new ItemInfo(40481), 
            new ItemInfo(40482), new ItemInfo(40483), new ItemInfo(40484), new ItemInfo(40485), new ItemInfo(40486), new ItemInfo(40487), new ItemInfo(40488), 
            new ItemInfo(40489), new ItemInfo(40490), new ItemInfo(40491), new ItemInfo(40492), new ItemInfo(40493), new ItemInfo(40494), new ItemInfo(40495), 
            new ItemInfo(40496), new ItemInfo(40497), new ItemInfo(40498), new ItemInfo(40499), new ItemInfo(40500), new ItemInfo(40501), new ItemInfo(40502), 
            new ItemInfo(40503), new ItemInfo(40504), new ItemInfo(40505), new ItemInfo(40506), new ItemInfo(40507), new ItemInfo(40508), new ItemInfo(40509), 
            new ItemInfo(40510), new ItemInfo(40511), new ItemInfo(40512), new ItemInfo(40513), new ItemInfo(40514), new ItemInfo(40515), new ItemInfo(40516), 
            new ItemInfo(40517), new ItemInfo(40518), new ItemInfo(40519), new ItemInfo(40520), new ItemInfo(40521), new ItemInfo(40522), new ItemInfo(40523), 
            new ItemInfo(40524), new ItemInfo(40525), new ItemInfo(40526), new ItemInfo(40527), new ItemInfo(40528), new ItemInfo(40529), new ItemInfo(40530), 
            new ItemInfo(40531), new ItemInfo(40532), new ItemInfo(40533), new ItemInfo(40534), new ItemInfo(40535), new ItemInfo(40536), new ItemInfo(40537), 
            new ItemInfo(40538), new ItemInfo(40539), new ItemInfo(40540), new ItemInfo(40541), new ItemInfo(40542), new ItemInfo(40543), new ItemInfo(40544), 
            new ItemInfo(40545), new ItemInfo(40546), new ItemInfo(40547), new ItemInfo(40548), new ItemInfo(40549), new ItemInfo(40550), new ItemInfo(40551), 
            new ItemInfo(40552), new ItemInfo(40553), new ItemInfo(40554), new ItemInfo(40555), new ItemInfo(40556), new ItemInfo(40557), new ItemInfo(40558), 
            new ItemInfo(40559), new ItemInfo(40560), new ItemInfo(40561), new ItemInfo(40562), new ItemInfo(40563), new ItemInfo(40564), new ItemInfo(40565), 
            new ItemInfo(40566), new ItemInfo(40567), new ItemInfo(40568), new ItemInfo(40569), new ItemInfo(40570), new ItemInfo(40571), new ItemInfo(40572), 
            new ItemInfo(40616), new ItemInfo(40617), new ItemInfo(40618), new ItemInfo(40619), new ItemInfo(40620), new ItemInfo(40621), new ItemInfo(40622), 
            new ItemInfo(40623), new ItemInfo(40624), new ItemInfo(40625), new ItemInfo(40626), new ItemInfo(40627), new ItemInfo(40628), new ItemInfo(40629)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt5Gump()
			: this(0)
		{ }

		public AddFurnPt5Gump(int page) 
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

			from.SendGump(new AddFurnPt5Gump(page));
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
