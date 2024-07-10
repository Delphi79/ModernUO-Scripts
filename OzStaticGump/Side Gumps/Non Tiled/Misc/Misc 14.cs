using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt14Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt14", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt14_OnCommand));
		}

		[Usage("AddMiscPt14")]
		
		public static void AddMiscPt14_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt14Gump>();
			e.Mobile.SendGump(new AddMiscPt14Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(6262), new ItemInfo(6263), new ItemInfo(6264), new ItemInfo(6265), new ItemInfo(6266), new ItemInfo(6267), new ItemInfo(6268), new ItemInfo(6269), new ItemInfo(6270), 
            new ItemInfo(6271), new ItemInfo(6272), new ItemInfo(6273), new ItemInfo(6274), new ItemInfo(6275), new ItemInfo(6276), new ItemInfo(6277), new ItemInfo(6278), new ItemInfo(6279), 
            new ItemInfo(6280), new ItemInfo(6281), new ItemInfo(6282), new ItemInfo(6283), new ItemInfo(6284), new ItemInfo(6285), new ItemInfo(6286), new ItemInfo(6287), new ItemInfo(6288), 
            new ItemInfo(6289), new ItemInfo(6290), new ItemInfo(6291), new ItemInfo(6300), new ItemInfo(6301), new ItemInfo(6302), new ItemInfo(6303), new ItemInfo(6304), new ItemInfo(6305), 
            new ItemInfo(6306), new ItemInfo(6307), new ItemInfo(6308), new ItemInfo(6309), new ItemInfo(6310), new ItemInfo(6311), new ItemInfo(6312), new ItemInfo(6313), new ItemInfo(6314), 
            new ItemInfo(6315), new ItemInfo(6316), new ItemInfo(6317), new ItemInfo(6318), new ItemInfo(6319), new ItemInfo(6320), new ItemInfo(6321), new ItemInfo(6322), new ItemInfo(6323), 
            new ItemInfo(6324), new ItemInfo(6325), new ItemInfo(6326), new ItemInfo(6327), new ItemInfo(6328), new ItemInfo(6329), new ItemInfo(6330), new ItemInfo(6331), new ItemInfo(6332), 
            new ItemInfo(6333), new ItemInfo(6334), new ItemInfo(6335), new ItemInfo(6336), new ItemInfo(6337), new ItemInfo(6338), new ItemInfo(6339), new ItemInfo(6340), new ItemInfo(6341), 
            new ItemInfo(6342), new ItemInfo(6343), new ItemInfo(6344), new ItemInfo(6345), new ItemInfo(6346), new ItemInfo(6347), new ItemInfo(6348), new ItemInfo(6349), new ItemInfo(6350), 
            new ItemInfo(6351), new ItemInfo(6352), new ItemInfo(6353), new ItemInfo(6354), new ItemInfo(6355), new ItemInfo(6356), new ItemInfo(6357), new ItemInfo(6358), new ItemInfo(6359), 
            new ItemInfo(6360), new ItemInfo(6361), new ItemInfo(6362), new ItemInfo(6363), new ItemInfo(6364), new ItemInfo(6365), new ItemInfo(6366), new ItemInfo(6367), new ItemInfo(6368), 
            new ItemInfo(6369), new ItemInfo(6370), new ItemInfo(6371), new ItemInfo(6372), new ItemInfo(6373), new ItemInfo(6374), new ItemInfo(6375), new ItemInfo(6376), new ItemInfo(6377), 
            new ItemInfo(6378), new ItemInfo(6379), new ItemInfo(6380), new ItemInfo(6381), new ItemInfo(6382), new ItemInfo(6383), new ItemInfo(6384), new ItemInfo(6385), new ItemInfo(6386), 
            new ItemInfo(6387), new ItemInfo(6388), new ItemInfo(6389), new ItemInfo(6390), new ItemInfo(6391), new ItemInfo(6392), new ItemInfo(6393), new ItemInfo(6394), new ItemInfo(6395), 
            new ItemInfo(6396), new ItemInfo(6397), new ItemInfo(6398), new ItemInfo(6399), new ItemInfo(6400), new ItemInfo(6401), new ItemInfo(6402), new ItemInfo(6403), new ItemInfo(6404), 
            new ItemInfo(6405), new ItemInfo(6406), new ItemInfo(6407), new ItemInfo(6408), new ItemInfo(6409), new ItemInfo(6410), new ItemInfo(6411), new ItemInfo(6412), new ItemInfo(6413), 
            new ItemInfo(6414), new ItemInfo(6415), new ItemInfo(6432), new ItemInfo(6433), new ItemInfo(6434), new ItemInfo(6435), new ItemInfo(6436), new ItemInfo(6437), new ItemInfo(6438), 
            new ItemInfo(6439), new ItemInfo(6440), new ItemInfo(6441), new ItemInfo(6442), new ItemInfo(6443), new ItemInfo(6444), new ItemInfo(6445), new ItemInfo(6446), new ItemInfo(6447), 
            new ItemInfo(6448), new ItemInfo(6449), new ItemInfo(6450), new ItemInfo(6451), new ItemInfo(6452), new ItemInfo(6453), new ItemInfo(6454), new ItemInfo(6455), new ItemInfo(6456), 
            new ItemInfo(6463), new ItemInfo(6464), new ItemInfo(6465), new ItemInfo(6466), new ItemInfo(6467), new ItemInfo(6468), new ItemInfo(6469), new ItemInfo(6470), new ItemInfo(6471), 
            new ItemInfo(6472), new ItemInfo(6473), new ItemInfo(6474), new ItemInfo(6475), new ItemInfo(6476), new ItemInfo(6477), new ItemInfo(6478), new ItemInfo(6479), new ItemInfo(6480),
            new ItemInfo(6481), new ItemInfo(6482), new ItemInfo(6483), new ItemInfo(6484), new ItemInfo(6485), new ItemInfo(6486), new ItemInfo(6487), new ItemInfo(6488), new ItemInfo(6489), 
            new ItemInfo(6490), new ItemInfo(6491), new ItemInfo(6492), new ItemInfo(6493), new ItemInfo(6494), new ItemInfo(6495), new ItemInfo(6496), new ItemInfo(6497), new ItemInfo(6498), 
            new ItemInfo(6499), new ItemInfo(6500), new ItemInfo(6501), new ItemInfo(6502), new ItemInfo(6503), new ItemInfo(6504), new ItemInfo(6505), new ItemInfo(6506), new ItemInfo(6507), 
            new ItemInfo(6508), new ItemInfo(6509), new ItemInfo(6510), new ItemInfo(6511), new ItemInfo(6512), new ItemInfo(6513), new ItemInfo(6514), new ItemInfo(6515), new ItemInfo(6516)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt14Gump()
			: this(0)
		{ }

		public AddMiscPt14Gump(int page) 
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

			from.SendGump(new AddMiscPt14Gump(page));
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
