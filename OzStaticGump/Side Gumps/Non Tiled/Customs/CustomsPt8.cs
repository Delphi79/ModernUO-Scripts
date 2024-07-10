using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt8Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt8", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt8_OnCommand));
		}

		[Usage("AddCustomPt8")]
		
		public static void AddCustomPt8_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt8Gump>();
			e.Mobile.SendGump(new AddCustomPt8Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
            new ItemInfo(40487), new ItemInfo(40488), new ItemInfo(40489), new ItemInfo(40490), new ItemInfo(40491), new ItemInfo(40492), new ItemInfo(40493), new ItemInfo(40494), new ItemInfo(40495), 
			new ItemInfo(40496), new ItemInfo(40497), new ItemInfo(40498), new ItemInfo(40499), new ItemInfo(40500), new ItemInfo(40501), new ItemInfo(40502), new ItemInfo(40503), new ItemInfo(40504), 
			new ItemInfo(40505), new ItemInfo(40506), new ItemInfo(40507), new ItemInfo(40508), new ItemInfo(40509), new ItemInfo(40510), new ItemInfo(40511), new ItemInfo(40512), new ItemInfo(40513), 
			new ItemInfo(40514), new ItemInfo(40515), new ItemInfo(40516), new ItemInfo(40517), new ItemInfo(40518), new ItemInfo(40519), new ItemInfo(40520), new ItemInfo(40521), new ItemInfo(40522), 
			new ItemInfo(40523), new ItemInfo(40524), new ItemInfo(40525), new ItemInfo(40526), new ItemInfo(40527), new ItemInfo(40528), new ItemInfo(40529), new ItemInfo(40530), new ItemInfo(40531), 
			new ItemInfo(40532), new ItemInfo(40533), new ItemInfo(40534), new ItemInfo(40535), new ItemInfo(40536), new ItemInfo(40537), new ItemInfo(40538), new ItemInfo(40539), new ItemInfo(40540), 
			new ItemInfo(40541), new ItemInfo(40542), new ItemInfo(40543), new ItemInfo(40544), new ItemInfo(40545), new ItemInfo(40546), new ItemInfo(40547), new ItemInfo(40548), new ItemInfo(40549), 
			new ItemInfo(40550), new ItemInfo(40551), new ItemInfo(40552), new ItemInfo(40553), new ItemInfo(40554), new ItemInfo(40555), new ItemInfo(40556), new ItemInfo(40557), new ItemInfo(40558), 
			new ItemInfo(40559), new ItemInfo(40560), new ItemInfo(40561), new ItemInfo(40562), new ItemInfo(40563), new ItemInfo(40564), new ItemInfo(40565), new ItemInfo(40566), new ItemInfo(40567), 
			new ItemInfo(40568), new ItemInfo(40569), new ItemInfo(40570), new ItemInfo(40571), new ItemInfo(40572), new ItemInfo(40573), new ItemInfo(40574), new ItemInfo(40575), new ItemInfo(40576), 
			new ItemInfo(40577), new ItemInfo(40578), new ItemInfo(40579), new ItemInfo(40580), new ItemInfo(40581), new ItemInfo(40582), new ItemInfo(40583), new ItemInfo(40584), new ItemInfo(40585), 
			new ItemInfo(40586), new ItemInfo(40587), new ItemInfo(40588), new ItemInfo(40589), new ItemInfo(40590), new ItemInfo(40591), new ItemInfo(40592), new ItemInfo(40593), new ItemInfo(40594), 
			new ItemInfo(40595), new ItemInfo(40596), new ItemInfo(40597), new ItemInfo(40598), new ItemInfo(40599), new ItemInfo(40600), new ItemInfo(40601), new ItemInfo(40602), new ItemInfo(40603), 
			new ItemInfo(40604), new ItemInfo(40605), new ItemInfo(40606), new ItemInfo(40607), new ItemInfo(40608), new ItemInfo(40609), new ItemInfo(40610), new ItemInfo(40611), new ItemInfo(40612), 
			new ItemInfo(40613), new ItemInfo(40614), new ItemInfo(40615), new ItemInfo(40616), new ItemInfo(40617), new ItemInfo(40618), new ItemInfo(40619), new ItemInfo(40620), new ItemInfo(40621), 
			new ItemInfo(40622), new ItemInfo(40623), new ItemInfo(40624), new ItemInfo(40625), new ItemInfo(40626), new ItemInfo(40627), new ItemInfo(40628), new ItemInfo(40629), new ItemInfo(40630), 
			new ItemInfo(40631), new ItemInfo(40632), new ItemInfo(40633), new ItemInfo(40634), new ItemInfo(40635), new ItemInfo(40636), new ItemInfo(40637), new ItemInfo(40638), new ItemInfo(40639), 
			new ItemInfo(40640), new ItemInfo(40641), new ItemInfo(40642), new ItemInfo(40643), new ItemInfo(40644), new ItemInfo(40645), new ItemInfo(40646), new ItemInfo(40647), new ItemInfo(40648), 
			new ItemInfo(40649), new ItemInfo(40650), new ItemInfo(40651), new ItemInfo(40652), new ItemInfo(40653), new ItemInfo(40654), new ItemInfo(40655), new ItemInfo(40656), new ItemInfo(40657), 
			new ItemInfo(40658), new ItemInfo(40659), new ItemInfo(40660), new ItemInfo(40661), new ItemInfo(40662), new ItemInfo(40663), new ItemInfo(40664), new ItemInfo(40665), new ItemInfo(40666)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt8Gump()
			: this(0)
		{ }

		public AddCustomPt8Gump(int page) 
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

			from.SendGump(new AddCustomPt8Gump(page));
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
