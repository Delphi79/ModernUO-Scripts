using Server.Network;

namespace Server.Gumps
{
	public class AddGearPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGearPt5", AccessLevel.GameMaster, new CommandEventHandler(AddGearPt5_OnCommand));
		}

		[Usage("AddGearPt5")]
		
		public static void AddGearPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGearPt5Gump>();
			e.Mobile.SendGump(new AddGearPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(11020), new ItemInfo(11021), new ItemInfo(11022), new ItemInfo(11023), new ItemInfo(11024), new ItemInfo(11025), new ItemInfo(11026), new ItemInfo(11027), 
            new ItemInfo(11111), new ItemInfo(11112), new ItemInfo(11113), new ItemInfo(11114), new ItemInfo(11115), new ItemInfo(11116), new ItemInfo(11117), new ItemInfo(11118), 
            new ItemInfo(11119), new ItemInfo(11120), new ItemInfo(11121), new ItemInfo(11122), new ItemInfo(11123), new ItemInfo(11124), new ItemInfo(11125), new ItemInfo(11126), 
            new ItemInfo(11127), new ItemInfo(11128), new ItemInfo(11129), new ItemInfo(11550), new ItemInfo(11551), new ItemInfo(11552), new ItemInfo(11553), new ItemInfo(11554), 
            new ItemInfo(11555), new ItemInfo(11556), new ItemInfo(11557), new ItemInfo(11558), new ItemInfo(11559), new ItemInfo(11560), new ItemInfo(11561), new ItemInfo(11562), 
            new ItemInfo(11563), new ItemInfo(11564), new ItemInfo(11565), new ItemInfo(11566), new ItemInfo(11567), new ItemInfo(11568), new ItemInfo(11569), new ItemInfo(11570), 
            new ItemInfo(11571), new ItemInfo(11572), new ItemInfo(11573), new ItemInfo(12215), new ItemInfo(12216), new ItemInfo(12217), new ItemInfo(12218), new ItemInfo(12227), 
            new ItemInfo(12228), new ItemInfo(12229), new ItemInfo(12230), new ItemInfo(12231), new ItemInfo(12232), new ItemInfo(12233), new ItemInfo(12234), new ItemInfo(12235), 
            new ItemInfo(12638), new ItemInfo(12639), new ItemInfo(12640), new ItemInfo(12641), new ItemInfo(12642), new ItemInfo(12643), new ItemInfo(12644), new ItemInfo(12645), 
            new ItemInfo(12646), new ItemInfo(12647), new ItemInfo(12648), new ItemInfo(12649), new ItemInfo(12650), new ItemInfo(12651), new ItemInfo(12652), new ItemInfo(12653), 
            new ItemInfo(12654), new ItemInfo(12655), new ItemInfo(12656), new ItemInfo(12657), new ItemInfo(12658), new ItemInfo(12659), new ItemInfo(12660), new ItemInfo(12661), 
            new ItemInfo(12662), new ItemInfo(12663), new ItemInfo(12664), new ItemInfo(12665), new ItemInfo(12666), new ItemInfo(12667), new ItemInfo(12668), new ItemInfo(12669), 
            new ItemInfo(12670), new ItemInfo(12671), new ItemInfo(12672), new ItemInfo(12673), new ItemInfo(16384), new ItemInfo(16385), new ItemInfo(16386), new ItemInfo(16387), 
            new ItemInfo(16455), new ItemInfo(16456), new ItemInfo(16457), new ItemInfo(16458), new ItemInfo(16459), new ItemInfo(16460), new ItemInfo(16461), new ItemInfo(16462), 
            new ItemInfo(16463), new ItemInfo(16464), new ItemInfo(16465), new ItemInfo(16466), new ItemInfo(16467), new ItemInfo(16468), new ItemInfo(16469), new ItemInfo(16470), 
            new ItemInfo(16471), new ItemInfo(16472), new ItemInfo(16473), new ItemInfo(16474), new ItemInfo(16475), new ItemInfo(16476), new ItemInfo(16477), new ItemInfo(16478), 
            new ItemInfo(16479), new ItemInfo(16480), new ItemInfo(16481), new ItemInfo(16482), new ItemInfo(16483), new ItemInfo(16484), new ItemInfo(16485), new ItemInfo(16486), 
            new ItemInfo(16487), new ItemInfo(16488), new ItemInfo(16489), new ItemInfo(16490), new ItemInfo(16491), new ItemInfo(16492), new ItemInfo(16493), new ItemInfo(16494), 
            new ItemInfo(16495), new ItemInfo(16496), new ItemInfo(16497), new ItemInfo(16498), new ItemInfo(16499), new ItemInfo(16500), new ItemInfo(16501), new ItemInfo(16502), 
            new ItemInfo(16856), new ItemInfo(16857), new ItemInfo(16892), new ItemInfo(16893), new ItemInfo(16894), new ItemInfo(16895), new ItemInfo(16896), new ItemInfo(16897), 
            new ItemInfo(16898), new ItemInfo(16899), new ItemInfo(16900), new ItemInfo(16901), new ItemInfo(16902), new ItemInfo(16903), new ItemInfo(16904), new ItemInfo(16905), 
            new ItemInfo(16906), new ItemInfo(16907), new ItemInfo(16908), new ItemInfo(16909), new ItemInfo(16910), new ItemInfo(16911), new ItemInfo(16912), new ItemInfo(16913), 
            new ItemInfo(16914), new ItemInfo(16915), new ItemInfo(16936), new ItemInfo(16937), new ItemInfo(16938), new ItemInfo(16939), new ItemInfo(16940), new ItemInfo(16941), 
            new ItemInfo(16942), new ItemInfo(16943), new ItemInfo(16944), new ItemInfo(16945), new ItemInfo(17790), new ItemInfo(17791), new ItemInfo(17792), new ItemInfo(17793), 
            new ItemInfo(17828), new ItemInfo(17829), new ItemInfo(17830), new ItemInfo(17831), new ItemInfo(17841), new ItemInfo(17843), new ItemInfo(18100), new ItemInfo(18101), 
            new ItemInfo(18606), new ItemInfo(18607), new ItemInfo(18608), new ItemInfo(18609), new ItemInfo(18610), new ItemInfo(18611), new ItemInfo(18612), new ItemInfo(18613), 
            new ItemInfo(18614), new ItemInfo(18615), new ItemInfo(18616), new ItemInfo(18617), new ItemInfo(18618), new ItemInfo(18619), new ItemInfo(18620), new ItemInfo(18621), 
            new ItemInfo(18622), new ItemInfo(18623), new ItemInfo(18624), new ItemInfo(18625), new ItemInfo(18626), new ItemInfo(18627), new ItemInfo(18628), new ItemInfo(18629), 
            new ItemInfo(18630), new ItemInfo(18631), new ItemInfo(18632), new ItemInfo(18633), new ItemInfo(18634), new ItemInfo(18635), new ItemInfo(18636), new ItemInfo(18637), 
            new ItemInfo(18638), new ItemInfo(18639), new ItemInfo(18640), new ItemInfo(18641), new ItemInfo(18642), new ItemInfo(18643), new ItemInfo(20696), new ItemInfo(20697)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGearPt5Gump()
			: this(0)
		{ }

		public AddGearPt5Gump(int page) 
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

			from.SendGump(new AddGearPt5Gump(page));
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
