using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt2", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt2_OnCommand));
		}

		[Usage("AddCustomPt2")]
		
		public static void AddCustomPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt2Gump>();
			e.Mobile.SendGump(new AddCustomPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(39394), new ItemInfo(39395), new ItemInfo(39396), new ItemInfo(39397), new ItemInfo(39398), new ItemInfo(39399), new ItemInfo(39400), new ItemInfo(39401), new ItemInfo(39402), 
			new ItemInfo(39403), new ItemInfo(39404), new ItemInfo(39405), new ItemInfo(39406), new ItemInfo(39407), new ItemInfo(39408), new ItemInfo(39409), new ItemInfo(39410), new ItemInfo(39411), 
			new ItemInfo(39412), new ItemInfo(39413), new ItemInfo(39414), new ItemInfo(39415), new ItemInfo(39416), new ItemInfo(39417), new ItemInfo(39418), new ItemInfo(39419), new ItemInfo(39420), 
			new ItemInfo(39421), new ItemInfo(39422), new ItemInfo(39423), new ItemInfo(39424), new ItemInfo(39425), new ItemInfo(39426), new ItemInfo(39427), new ItemInfo(39428), new ItemInfo(39429), 
			new ItemInfo(39430), new ItemInfo(39431), new ItemInfo(39432), new ItemInfo(39433), new ItemInfo(39434), new ItemInfo(39435), new ItemInfo(39436), new ItemInfo(39437), new ItemInfo(39438), 
			new ItemInfo(39439), new ItemInfo(39440), new ItemInfo(39441), new ItemInfo(39442), new ItemInfo(39443), new ItemInfo(39444), new ItemInfo(39445), new ItemInfo(39446), new ItemInfo(39447), 
			new ItemInfo(39448), new ItemInfo(39449), new ItemInfo(39450), new ItemInfo(39451), new ItemInfo(39452), new ItemInfo(39453), new ItemInfo(39454), new ItemInfo(39455), new ItemInfo(39456), 
			new ItemInfo(39457), new ItemInfo(39458), new ItemInfo(39459), new ItemInfo(39460), new ItemInfo(39461), new ItemInfo(39462), new ItemInfo(39463), new ItemInfo(39464), new ItemInfo(39465), 
			new ItemInfo(39466), new ItemInfo(39467), new ItemInfo(39468), new ItemInfo(39469), new ItemInfo(39470), new ItemInfo(39471), new ItemInfo(39472), new ItemInfo(39473), new ItemInfo(39474), 
			new ItemInfo(39475), new ItemInfo(39476), new ItemInfo(39477), new ItemInfo(39478), new ItemInfo(39479), new ItemInfo(39480), new ItemInfo(39481), new ItemInfo(39482), new ItemInfo(39483), 
			new ItemInfo(39484), new ItemInfo(39485), new ItemInfo(39486), new ItemInfo(39487), new ItemInfo(39488), new ItemInfo(39489), new ItemInfo(39490), new ItemInfo(39491), new ItemInfo(39492), 
			new ItemInfo(39493), new ItemInfo(39494), new ItemInfo(39495), new ItemInfo(39496), new ItemInfo(39497), new ItemInfo(39498), new ItemInfo(39499), new ItemInfo(39500), new ItemInfo(39501), 
			new ItemInfo(39502), new ItemInfo(39503), new ItemInfo(39504), new ItemInfo(39505), new ItemInfo(39506), new ItemInfo(39507), new ItemInfo(39508), new ItemInfo(39509), new ItemInfo(39510), 
			new ItemInfo(39511), new ItemInfo(39512), new ItemInfo(39513), new ItemInfo(39514), new ItemInfo(39515), new ItemInfo(39517), new ItemInfo(39518), new ItemInfo(39519), new ItemInfo(39520), 
			new ItemInfo(39521), new ItemInfo(39522), new ItemInfo(39523), new ItemInfo(39524), new ItemInfo(39525), new ItemInfo(39526), new ItemInfo(39527), new ItemInfo(39528), new ItemInfo(39529), 
			new ItemInfo(39530), new ItemInfo(39531), new ItemInfo(39532), new ItemInfo(39533), new ItemInfo(39534), new ItemInfo(39535), new ItemInfo(39536), new ItemInfo(39537), new ItemInfo(39538), 
			new ItemInfo(39539), new ItemInfo(39540), new ItemInfo(39541), new ItemInfo(39542), new ItemInfo(39543), new ItemInfo(39544), new ItemInfo(39545), new ItemInfo(39546), new ItemInfo(39547), 
			new ItemInfo(39548), new ItemInfo(39549), new ItemInfo(39550), new ItemInfo(39551), new ItemInfo(39552), new ItemInfo(39553), new ItemInfo(39554), new ItemInfo(39555), new ItemInfo(39556), 
			new ItemInfo(39557), new ItemInfo(39558), new ItemInfo(39559), new ItemInfo(39560), new ItemInfo(39561), new ItemInfo(39562), new ItemInfo(39563), new ItemInfo(39564), new ItemInfo(39565), 
			new ItemInfo(39566), new ItemInfo(39567), new ItemInfo(39568), new ItemInfo(39569), new ItemInfo(39570), new ItemInfo(39571), new ItemInfo(39572), new ItemInfo(39573), new ItemInfo(39574)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt2Gump()
			: this(0)
		{ }

		public AddCustomPt2Gump(int page) 
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

			from.SendGump(new AddCustomPt2Gump(page));
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
