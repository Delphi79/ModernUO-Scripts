using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt12Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt12", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt12_OnCommand));
		}

		[Usage("AddCustomPt12")]
		
		public static void AddCustomPt12_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt12Gump>();
			e.Mobile.SendGump(new AddCustomPt12Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(41377), new ItemInfo(41378), new ItemInfo(41379), new ItemInfo(41380), new ItemInfo(41381), new ItemInfo(41382), new ItemInfo(41383), new ItemInfo(41384), new ItemInfo(41385), 
			new ItemInfo(41386), new ItemInfo(41387), new ItemInfo(41388), new ItemInfo(41389), new ItemInfo(41390), new ItemInfo(41391), new ItemInfo(41392), new ItemInfo(41393), new ItemInfo(41394), 
			new ItemInfo(41395), new ItemInfo(41396), new ItemInfo(41397), new ItemInfo(41398), new ItemInfo(41399), new ItemInfo(41400), new ItemInfo(41401), new ItemInfo(41402), new ItemInfo(41403), 
			new ItemInfo(41404), new ItemInfo(41405), new ItemInfo(41406), new ItemInfo(41407), new ItemInfo(41408), new ItemInfo(41409), new ItemInfo(41410), new ItemInfo(41411), new ItemInfo(41412), 
			new ItemInfo(41413), new ItemInfo(41414), new ItemInfo(41415), new ItemInfo(41416), new ItemInfo(41417), new ItemInfo(41418), new ItemInfo(41419), new ItemInfo(41420), new ItemInfo(41421), 
			new ItemInfo(41422), new ItemInfo(41423), new ItemInfo(41424), new ItemInfo(41425), new ItemInfo(41426), new ItemInfo(41427), new ItemInfo(41428), new ItemInfo(41429), new ItemInfo(41430), 
			new ItemInfo(41431), new ItemInfo(41432), new ItemInfo(41433), new ItemInfo(41434), new ItemInfo(41435), new ItemInfo(41436), new ItemInfo(41437), new ItemInfo(41438), new ItemInfo(41439), 
			new ItemInfo(41440), new ItemInfo(41441), new ItemInfo(41442), new ItemInfo(41443), new ItemInfo(41444), new ItemInfo(41445), new ItemInfo(41446), new ItemInfo(41447), new ItemInfo(41448), 
			new ItemInfo(41449), new ItemInfo(41450), new ItemInfo(41451), new ItemInfo(41452), new ItemInfo(41453), new ItemInfo(41454), new ItemInfo(41455), new ItemInfo(41456), new ItemInfo(41457), 
			new ItemInfo(41458), new ItemInfo(41459), new ItemInfo(41460), new ItemInfo(41461), new ItemInfo(41462), new ItemInfo(41463), new ItemInfo(41464), new ItemInfo(41465), new ItemInfo(41466), 
			new ItemInfo(41467), new ItemInfo(41468), new ItemInfo(41469), new ItemInfo(41470), new ItemInfo(41471), new ItemInfo(41472), new ItemInfo(41473), new ItemInfo(41474), new ItemInfo(41475), 
			new ItemInfo(41476), new ItemInfo(41477), new ItemInfo(41478), new ItemInfo(41479), new ItemInfo(41480), new ItemInfo(41481), new ItemInfo(41482), new ItemInfo(41483), new ItemInfo(41484), 
			new ItemInfo(41485), new ItemInfo(41486), new ItemInfo(41487), new ItemInfo(41488), new ItemInfo(41489), new ItemInfo(41490), new ItemInfo(41491), new ItemInfo(41492), new ItemInfo(41493), 
			new ItemInfo(41494), new ItemInfo(41495), new ItemInfo(41496), new ItemInfo(41497), new ItemInfo(41498), new ItemInfo(41499), new ItemInfo(41500), new ItemInfo(41501), new ItemInfo(41502), 
			new ItemInfo(41503), new ItemInfo(41504), new ItemInfo(41505), new ItemInfo(41506), new ItemInfo(41507), new ItemInfo(41508), new ItemInfo(41509), new ItemInfo(41510), new ItemInfo(41511), 
			new ItemInfo(41512), new ItemInfo(41513), new ItemInfo(41514), new ItemInfo(41515), new ItemInfo(41516), new ItemInfo(41517), new ItemInfo(41518), new ItemInfo(41519), new ItemInfo(41520), 
			new ItemInfo(41521), new ItemInfo(41522), new ItemInfo(41523), new ItemInfo(41524), new ItemInfo(41525), new ItemInfo(41526), new ItemInfo(41527), new ItemInfo(41528), new ItemInfo(41529), 
			new ItemInfo(41530), new ItemInfo(41531), new ItemInfo(41532), new ItemInfo(41533), new ItemInfo(41534), new ItemInfo(41535), new ItemInfo(41536), new ItemInfo(41537), new ItemInfo(41538), 
			new ItemInfo(41539), new ItemInfo(41540), new ItemInfo(41541), new ItemInfo(41542), new ItemInfo(41543), new ItemInfo(41544), new ItemInfo(41545), new ItemInfo(41546), new ItemInfo(41547), 
			new ItemInfo(41548), new ItemInfo(41549), new ItemInfo(41550), new ItemInfo(41551), new ItemInfo(41552), new ItemInfo(41553), new ItemInfo(41554), new ItemInfo(41555), new ItemInfo(41556), 
			new ItemInfo(41557), new ItemInfo(41558), new ItemInfo(41559), new ItemInfo(41560), new ItemInfo(41561), new ItemInfo(41562), new ItemInfo(41563), new ItemInfo(41564), new ItemInfo(41565), 
			new ItemInfo(41566), new ItemInfo(41567), new ItemInfo(41568), new ItemInfo(41569), new ItemInfo(41570), new ItemInfo(41571), new ItemInfo(41572), new ItemInfo(41573), new ItemInfo(41574), 
			new ItemInfo(41575), new ItemInfo(41576), new ItemInfo(41577), new ItemInfo(41578), new ItemInfo(41579), new ItemInfo(41580), new ItemInfo(41581), new ItemInfo(41582), new ItemInfo(41583), 
			new ItemInfo(41584), new ItemInfo(41585), new ItemInfo(41586), new ItemInfo(41587), new ItemInfo(41588), new ItemInfo(41589), new ItemInfo(41590), new ItemInfo(41591), new ItemInfo(41592), 
			new ItemInfo(41593), new ItemInfo(41594), new ItemInfo(41595), new ItemInfo(41596), new ItemInfo(41597), new ItemInfo(41598), new ItemInfo(41599), new ItemInfo(41600), new ItemInfo(41601)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt12Gump()
			: this(0)
		{ }

		public AddCustomPt12Gump(int page) 
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

			from.SendGump(new AddCustomPt12Gump(page));
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
