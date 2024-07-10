using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt15Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt15", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt15_OnCommand));
		}

		[Usage("AddMiscPt15")]
		
		public static void AddMiscPt15_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt15Gump>();
			e.Mobile.SendGump(new AddMiscPt15Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(6517), new ItemInfo(6518), new ItemInfo(6519), new ItemInfo(6520), new ItemInfo(6521), new ItemInfo(6522), new ItemInfo(6523), new ItemInfo(6524), new ItemInfo(6525), 
            new ItemInfo(6526), new ItemInfo(6527), new ItemInfo(6528), new ItemInfo(6529), new ItemInfo(6530), new ItemInfo(6531), new ItemInfo(6532), new ItemInfo(6533), new ItemInfo(6534), 
            new ItemInfo(6535), new ItemInfo(6536), new ItemInfo(6537), new ItemInfo(6538), new ItemInfo(6539), new ItemInfo(6540), new ItemInfo(6541), new ItemInfo(6542), new ItemInfo(6543), 
            new ItemInfo(6544), new ItemInfo(6545), new ItemInfo(6546), new ItemInfo(6547), new ItemInfo(6548), new ItemInfo(6549), new ItemInfo(6550), new ItemInfo(6551), new ItemInfo(6552), 
            new ItemInfo(6553), new ItemInfo(6554), new ItemInfo(6555), new ItemInfo(6556), new ItemInfo(6557), new ItemInfo(6558), new ItemInfo(6559), new ItemInfo(6560), new ItemInfo(6561), 
            new ItemInfo(6562), new ItemInfo(6563), new ItemInfo(6564), new ItemInfo(6565), new ItemInfo(6566), new ItemInfo(6567), new ItemInfo(6568), new ItemInfo(6569), new ItemInfo(6571), 
            new ItemInfo(6572), new ItemInfo(6573), new ItemInfo(6574), new ItemInfo(6575), new ItemInfo(6576), new ItemInfo(6577), new ItemInfo(6578), new ItemInfo(6579), new ItemInfo(6580), 
            new ItemInfo(6581), new ItemInfo(6582), new ItemInfo(6583), new ItemInfo(6584), new ItemInfo(6585), new ItemInfo(6586), new ItemInfo(6588), new ItemInfo(6589), new ItemInfo(6590), 
            new ItemInfo(6591), new ItemInfo(6592), new ItemInfo(6593), new ItemInfo(6594), new ItemInfo(6595), new ItemInfo(6596), new ItemInfo(6597), new ItemInfo(6598), new ItemInfo(6599), 
            new ItemInfo(6600), new ItemInfo(6601), new ItemInfo(6602), new ItemInfo(6603), new ItemInfo(6604), new ItemInfo(6605), new ItemInfo(6606), new ItemInfo(6607), new ItemInfo(6608), 
            new ItemInfo(6609), new ItemInfo(6610), new ItemInfo(6611), new ItemInfo(6612), new ItemInfo(6613), new ItemInfo(6614), new ItemInfo(6615), new ItemInfo(6616), new ItemInfo(6617), 
            new ItemInfo(6618), new ItemInfo(6619), new ItemInfo(6620), new ItemInfo(6621), new ItemInfo(6622), new ItemInfo(6623), new ItemInfo(6624), new ItemInfo(6625), new ItemInfo(6626), 
            new ItemInfo(6627), new ItemInfo(6628), new ItemInfo(6629), new ItemInfo(6630), new ItemInfo(6631), new ItemInfo(6632), new ItemInfo(6633), new ItemInfo(6634), new ItemInfo(6635), 
            new ItemInfo(6636), new ItemInfo(6637), new ItemInfo(6638), new ItemInfo(6639), new ItemInfo(6640), new ItemInfo(6641), new ItemInfo(6642), new ItemInfo(6643), new ItemInfo(6644), 
            new ItemInfo(6645), new ItemInfo(6646), new ItemInfo(6647), new ItemInfo(6648), new ItemInfo(6649), new ItemInfo(6650), new ItemInfo(6651), new ItemInfo(6652), new ItemInfo(6653), 
            new ItemInfo(6654), new ItemInfo(6655), new ItemInfo(6656), new ItemInfo(6657), new ItemInfo(6658), new ItemInfo(6659), new ItemInfo(6660), new ItemInfo(6661), new ItemInfo(6662),
            new ItemInfo(6663), new ItemInfo(6664), new ItemInfo(6665), new ItemInfo(6666), new ItemInfo(6667), new ItemInfo(6668), new ItemInfo(6669), new ItemInfo(6670), new ItemInfo(6671), 
            new ItemInfo(6672), new ItemInfo(6673), new ItemInfo(6674), new ItemInfo(6675), new ItemInfo(6676), new ItemInfo(6677), new ItemInfo(6678), new ItemInfo(6679), new ItemInfo(6680), 
            new ItemInfo(6681), new ItemInfo(6682), new ItemInfo(6683), new ItemInfo(6684), new ItemInfo(6685), new ItemInfo(6686), new ItemInfo(6687), new ItemInfo(6688), new ItemInfo(6689), 
            new ItemInfo(6690), new ItemInfo(6691), new ItemInfo(6692), new ItemInfo(6693), new ItemInfo(6694), new ItemInfo(6695), new ItemInfo(6696), new ItemInfo(6697), new ItemInfo(6698), 
            new ItemInfo(6699), new ItemInfo(6700), new ItemInfo(6701), new ItemInfo(6702), new ItemInfo(6703), new ItemInfo(6704), new ItemInfo(6705), new ItemInfo(6706), new ItemInfo(6707), 
            new ItemInfo(6708), new ItemInfo(6709), new ItemInfo(6710), new ItemInfo(6711), new ItemInfo(6712), new ItemInfo(6713), new ItemInfo(6714), new ItemInfo(6715), new ItemInfo(6716), 
            new ItemInfo(6717), new ItemInfo(6718), new ItemInfo(6719), new ItemInfo(6720), new ItemInfo(6721), new ItemInfo(6722), new ItemInfo(6723), new ItemInfo(6724), new ItemInfo(6725), 
            new ItemInfo(6726), new ItemInfo(6727), new ItemInfo(6728), new ItemInfo(6729), new ItemInfo(6730), new ItemInfo(6731), new ItemInfo(6732), new ItemInfo(6733), new ItemInfo(6734), 
            new ItemInfo(6735), new ItemInfo(6736), new ItemInfo(6737), new ItemInfo(6738), new ItemInfo(6739), new ItemInfo(6740), new ItemInfo(6741), new ItemInfo(6742), new ItemInfo(6743)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt15Gump()
			: this(0)
		{ }

		public AddMiscPt15Gump(int page) 
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

			from.SendGump(new AddMiscPt15Gump(page));
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
