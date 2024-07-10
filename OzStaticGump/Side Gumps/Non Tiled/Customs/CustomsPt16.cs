using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt16Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt16", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt16_OnCommand));
		}

		[Usage("AddCustomPt16")]
		
		public static void AddCustomPt16_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt16Gump>();
			e.Mobile.SendGump(new AddCustomPt16Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(42277), new ItemInfo(42278), new ItemInfo(42279), new ItemInfo(42280), new ItemInfo(42281), new ItemInfo(42282), new ItemInfo(42283), new ItemInfo(42284), new ItemInfo(42285), 
			new ItemInfo(42286), new ItemInfo(42287), new ItemInfo(42288), new ItemInfo(42289), new ItemInfo(42290), new ItemInfo(42291), new ItemInfo(42292), new ItemInfo(42293), new ItemInfo(42294), 
			new ItemInfo(42295), new ItemInfo(42296), new ItemInfo(42297), new ItemInfo(42298), new ItemInfo(42299), new ItemInfo(42300), new ItemInfo(42301), new ItemInfo(42302), new ItemInfo(42303), 
			new ItemInfo(42304), new ItemInfo(42305), new ItemInfo(42306), new ItemInfo(42307), new ItemInfo(42308), new ItemInfo(42309), new ItemInfo(42310), new ItemInfo(42311), new ItemInfo(42312), 
			new ItemInfo(42313), new ItemInfo(42314), new ItemInfo(42315), new ItemInfo(42316), new ItemInfo(42317), new ItemInfo(42318), new ItemInfo(42319), new ItemInfo(42320), new ItemInfo(42321), 
			new ItemInfo(42322), new ItemInfo(42323), new ItemInfo(42324), new ItemInfo(42325), new ItemInfo(42326), new ItemInfo(42327), new ItemInfo(42328), new ItemInfo(42329), new ItemInfo(42330), 
			new ItemInfo(42331), new ItemInfo(42332), new ItemInfo(42333), new ItemInfo(42334), new ItemInfo(42335), new ItemInfo(42336), new ItemInfo(42337), new ItemInfo(42338), new ItemInfo(42339), 
			new ItemInfo(42340), new ItemInfo(42341), new ItemInfo(42342), new ItemInfo(42343), new ItemInfo(42344), new ItemInfo(42345), new ItemInfo(42346), new ItemInfo(42347), new ItemInfo(42348), 
			new ItemInfo(42349), new ItemInfo(42350), new ItemInfo(42351), new ItemInfo(42352), new ItemInfo(42353), new ItemInfo(42354), new ItemInfo(42355), new ItemInfo(42356), new ItemInfo(42357), 
			new ItemInfo(42358), new ItemInfo(42359), new ItemInfo(42360), new ItemInfo(42361), new ItemInfo(42362), new ItemInfo(42363), new ItemInfo(42364), new ItemInfo(42365), new ItemInfo(42366), 
			new ItemInfo(42367), new ItemInfo(42368), new ItemInfo(42370), new ItemInfo(42371), new ItemInfo(42372), new ItemInfo(42373), new ItemInfo(42374), new ItemInfo(42375), new ItemInfo(42376), 
			new ItemInfo(42377), new ItemInfo(42378), new ItemInfo(42379), new ItemInfo(42380), new ItemInfo(42381), new ItemInfo(42382), new ItemInfo(42383), new ItemInfo(42384), new ItemInfo(42385), 
			new ItemInfo(42386), new ItemInfo(42387), new ItemInfo(42388), new ItemInfo(42389), new ItemInfo(42390), new ItemInfo(42391), new ItemInfo(42392), new ItemInfo(42393), new ItemInfo(42394), 
			new ItemInfo(42395), new ItemInfo(42396), new ItemInfo(42397), new ItemInfo(42398), new ItemInfo(42399), new ItemInfo(42400), new ItemInfo(42401), new ItemInfo(42402), new ItemInfo(42403), 
			new ItemInfo(42404), new ItemInfo(42405), new ItemInfo(42406), new ItemInfo(42407), new ItemInfo(42408), new ItemInfo(42409), new ItemInfo(42410), new ItemInfo(42411), new ItemInfo(42412),
			new ItemInfo(42413), new ItemInfo(42414), new ItemInfo(42415), new ItemInfo(42416), new ItemInfo(42417), new ItemInfo(42418), new ItemInfo(42419), new ItemInfo(42420), new ItemInfo(42421), 
			new ItemInfo(42422), new ItemInfo(42423), new ItemInfo(42424), new ItemInfo(42425), new ItemInfo(42426), new ItemInfo(42427), new ItemInfo(42428), new ItemInfo(42429), new ItemInfo(42430), 
			new ItemInfo(42431), new ItemInfo(42432), new ItemInfo(42433), new ItemInfo(42434), new ItemInfo(42435), new ItemInfo(42436), new ItemInfo(42437), new ItemInfo(42438), new ItemInfo(42439), 
			new ItemInfo(42440), new ItemInfo(42441), new ItemInfo(42442), new ItemInfo(42443), new ItemInfo(42444), new ItemInfo(42445), new ItemInfo(42446), new ItemInfo(42447), new ItemInfo(42448), 
			new ItemInfo(42449), new ItemInfo(42450), new ItemInfo(42451), new ItemInfo(42452), new ItemInfo(42453), new ItemInfo(42454), new ItemInfo(42455), new ItemInfo(42456), new ItemInfo(42457), 
			new ItemInfo(42458), new ItemInfo(42459), new ItemInfo(42460), new ItemInfo(42461), new ItemInfo(42462), new ItemInfo(42463), new ItemInfo(42464), new ItemInfo(42465), new ItemInfo(42466),
			new ItemInfo(42467), new ItemInfo(42468), new ItemInfo(42469), new ItemInfo(42470), new ItemInfo(42471), new ItemInfo(42473), new ItemInfo(42474), new ItemInfo(42475), new ItemInfo(42476), 
			new ItemInfo(42477), new ItemInfo(42478), new ItemInfo(42479), new ItemInfo(42480), new ItemInfo(42481), new ItemInfo(42482), new ItemInfo(42483), new ItemInfo(42484), new ItemInfo(42485), 
			new ItemInfo(42486), new ItemInfo(42487), new ItemInfo(42488), new ItemInfo(42489), new ItemInfo(42490), new ItemInfo(42491), new ItemInfo(42492), new ItemInfo(42493), new ItemInfo(42494),
			new ItemInfo(42495), new ItemInfo(42496), new ItemInfo(42497), new ItemInfo(42498), new ItemInfo(42499), new ItemInfo(42500), new ItemInfo(42501), new ItemInfo(42502), new ItemInfo(42503)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt16Gump()
			: this(0)
		{ }

		public AddCustomPt16Gump(int page) 
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

			from.SendGump(new AddCustomPt16Gump(page));
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
