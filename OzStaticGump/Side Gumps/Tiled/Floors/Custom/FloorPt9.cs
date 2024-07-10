using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt9Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt9", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt9_OnCommand));
		}

		[Usage("AddFloorPt9")]
		
		public static void AddFloorPt9_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt9Gump>();
			e.Mobile.SendGump(new AddFloorPt9Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(39517), new ItemInfo(39518), new ItemInfo(39519), new ItemInfo(39520), new ItemInfo(39521), new ItemInfo(39522), new ItemInfo(39523), new ItemInfo(39524), 
            new ItemInfo(39525), new ItemInfo(39526), new ItemInfo(39527), new ItemInfo(39528), new ItemInfo(39529), new ItemInfo(39530), new ItemInfo(39531), new ItemInfo(39532), 
            new ItemInfo(39533), new ItemInfo(39534), new ItemInfo(39535), new ItemInfo(39536), new ItemInfo(39537), new ItemInfo(39538), new ItemInfo(39539), new ItemInfo(39540), 
            new ItemInfo(39541), new ItemInfo(39542), new ItemInfo(39543), new ItemInfo(39544), new ItemInfo(39545), new ItemInfo(39546), new ItemInfo(39547), new ItemInfo(39548), 
            new ItemInfo(39549), new ItemInfo(39550), new ItemInfo(39551), new ItemInfo(39552), new ItemInfo(39553), new ItemInfo(39554), new ItemInfo(39555), new ItemInfo(39556), 
            new ItemInfo(39557), new ItemInfo(39558), new ItemInfo(39559), new ItemInfo(39560), new ItemInfo(39561), new ItemInfo(39562), new ItemInfo(39563), new ItemInfo(39564), 
            new ItemInfo(39565), new ItemInfo(39566), new ItemInfo(39567), new ItemInfo(39568), new ItemInfo(39569), new ItemInfo(39570), new ItemInfo(39571), new ItemInfo(39572), 
            new ItemInfo(39573), new ItemInfo(39574), new ItemInfo(39575), new ItemInfo(39576), new ItemInfo(39577), new ItemInfo(39578), new ItemInfo(39579), new ItemInfo(39580), 
            new ItemInfo(39581), new ItemInfo(39582), new ItemInfo(39583), new ItemInfo(39584), new ItemInfo(39585), new ItemInfo(39586), new ItemInfo(39587), new ItemInfo(39588), 
            new ItemInfo(39589), new ItemInfo(39590), new ItemInfo(39591), new ItemInfo(39592), new ItemInfo(39593), new ItemInfo(39594), new ItemInfo(39595), new ItemInfo(39596), 
            new ItemInfo(39597), new ItemInfo(39598), new ItemInfo(39599), new ItemInfo(39600), new ItemInfo(39601), new ItemInfo(39602), new ItemInfo(39603), new ItemInfo(39604), 
            new ItemInfo(39605), new ItemInfo(39606), new ItemInfo(39607), new ItemInfo(39608), new ItemInfo(39609), new ItemInfo(39610), new ItemInfo(39611), new ItemInfo(39612), 
            new ItemInfo(39613), new ItemInfo(39614), new ItemInfo(39615), new ItemInfo(39616), new ItemInfo(39617), new ItemInfo(39618), new ItemInfo(39619), new ItemInfo(39620), 
            new ItemInfo(39621), new ItemInfo(39622), new ItemInfo(39623), new ItemInfo(39624), new ItemInfo(39625), new ItemInfo(39626), new ItemInfo(39627), new ItemInfo(39628), 
            new ItemInfo(39629), new ItemInfo(39630), new ItemInfo(39631), new ItemInfo(39632), new ItemInfo(39633), new ItemInfo(39634), new ItemInfo(39635), new ItemInfo(39636), 
            new ItemInfo(39637), new ItemInfo(39638), new ItemInfo(39639), new ItemInfo(39640), new ItemInfo(39641), new ItemInfo(39642), new ItemInfo(39643), new ItemInfo(39644), 
            new ItemInfo(39645), new ItemInfo(39646), new ItemInfo(39647), new ItemInfo(39648), new ItemInfo(39649), new ItemInfo(39650), new ItemInfo(39651), new ItemInfo(39652), 
            new ItemInfo(39653), new ItemInfo(39654), new ItemInfo(39655), new ItemInfo(39656), new ItemInfo(39657), new ItemInfo(39658), new ItemInfo(39659), new ItemInfo(39660), 
            new ItemInfo(39661), new ItemInfo(39662), new ItemInfo(39663), new ItemInfo(39664), new ItemInfo(39665), new ItemInfo(39666), new ItemInfo(39667), new ItemInfo(39668), 
            new ItemInfo(39669), new ItemInfo(39670), new ItemInfo(39671), new ItemInfo(39672), new ItemInfo(39673), new ItemInfo(39674), new ItemInfo(39675), new ItemInfo(39676), 
            new ItemInfo(39677), new ItemInfo(39678), new ItemInfo(39679), new ItemInfo(39680), new ItemInfo(39681), new ItemInfo(39682), new ItemInfo(39683), new ItemInfo(39684), 
            new ItemInfo(39685), new ItemInfo(39686), new ItemInfo(39687), new ItemInfo(39688), new ItemInfo(39689), new ItemInfo(39690), new ItemInfo(39691), new ItemInfo(39692)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt9Gump()
			: this(0)
		{ }

		public AddFloorPt9Gump(int page) 
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

			from.SendGump(new AddFloorPt9Gump(page));
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
