using Server.Network;

namespace Server.Gumps
{
	public class AddLightsStatic6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddLightsStatic", AccessLevel.GameMaster, new CommandEventHandler(AddLightsStatic6_OnCommand));
		}

		[Usage("AddLightsStatic6")]
		public static void AddLightsStatic6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddLightsStatic6Gump>();
			e.Mobile.SendGump(new AddLightsStatic6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(2555), new ItemInfo(2556), new ItemInfo(2557), new ItemInfo(2558), new ItemInfo(2559), new ItemInfo(2560), new ItemInfo(2561), 
            new ItemInfo(2562), new ItemInfo(2563), new ItemInfo(2564), new ItemInfo(2565), new ItemInfo(2566), new ItemInfo(2567), new ItemInfo(2568), 
            new ItemInfo(2569), new ItemInfo(2570), new ItemInfo(2571), new ItemInfo(2572), new ItemInfo(2573), new ItemInfo(2574), new ItemInfo(2575), 
            new ItemInfo(2576), new ItemInfo(2577), new ItemInfo(2578), new ItemInfo(2579), new ItemInfo(2580), new ItemInfo(2581), new ItemInfo(2582), 
            new ItemInfo(2583), new ItemInfo(2584), new ItemInfo(2585), new ItemInfo(2586), new ItemInfo(2587), new ItemInfo(2588), new ItemInfo(2589), 
            new ItemInfo(2594), new ItemInfo(2595), new ItemInfo(2596), new ItemInfo(2597), new ItemInfo(2598), new ItemInfo(2599), new ItemInfo(2600), 
            new ItemInfo(2601), new ItemInfo(2842), new ItemInfo(2843), new ItemInfo(2844), new ItemInfo(2845), new ItemInfo(2846), new ItemInfo(2847), 
            new ItemInfo(2848), new ItemInfo(2849), new ItemInfo(2850), new ItemInfo(2851), new ItemInfo(2852), new ItemInfo(2853), new ItemInfo(2854), 
            new ItemInfo(2855), new ItemInfo(2856), new ItemInfo(3553), new ItemInfo(3554), new ItemInfo(3555), new ItemInfo(3556), new ItemInfo(3557), 
            new ItemInfo(3558), new ItemInfo(3559), new ItemInfo(3560), new ItemInfo(3561), new ItemInfo(3562), new ItemInfo(5164), new ItemInfo(5165), 
            new ItemInfo(5166), new ItemInfo(5167), new ItemInfo(5168), new ItemInfo(5169), new ItemInfo(5170), new ItemInfo(5171), new ItemInfo(5172), 
            new ItemInfo(5173), new ItemInfo(5174), new ItemInfo(5175), new ItemInfo(6227), new ItemInfo(6228), new ItemInfo(6229), new ItemInfo(6230), 
            new ItemInfo(6231), new ItemInfo(6232), new ItemInfo(6233), new ItemInfo(6234), new ItemInfo(6570), new ItemInfo(6587), new ItemInfo(7288), 
            new ItemInfo(7289), new ItemInfo(7290), new ItemInfo(15764), new ItemInfo(15765), new ItemInfo(15766), new ItemInfo(15767), new ItemInfo(15768), 
            new ItemInfo(15769), new ItemInfo(15770), new ItemInfo(15771)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddLightsStatic6Gump()
			: this(0)
		{ }

		public AddLightsStatic6Gump(int page) 
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

			from.SendGump(new AddLightsStatic6Gump(page));
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
