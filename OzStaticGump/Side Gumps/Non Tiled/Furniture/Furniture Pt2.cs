using Server.Network;

namespace Server.Gumps
{
	public class AddFurnPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFurnPt2", AccessLevel.GameMaster, new CommandEventHandler(AddFurnPt2_OnCommand));
		}

		[Usage("AddFurnPt2")]
		public static void AddFurnPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFurnPt2Gump>();
			e.Mobile.SendGump(new AddFurnPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(2895), new ItemInfo(2896), new ItemInfo(2897), new ItemInfo(2898), new ItemInfo(2899), new ItemInfo(2900), new ItemInfo(2901), 
            new ItemInfo(2902), new ItemInfo(2903), new ItemInfo(2904), new ItemInfo(2905), new ItemInfo(2906), new ItemInfo(2907), new ItemInfo(2908), 
            new ItemInfo(2909), new ItemInfo(2910), new ItemInfo(2911), new ItemInfo(2912), new ItemInfo(2913), new ItemInfo(2914), new ItemInfo(2915), 
            new ItemInfo(2916), new ItemInfo(2917), new ItemInfo(2918), new ItemInfo(2919), new ItemInfo(2920), new ItemInfo(2921), new ItemInfo(2922), 
            new ItemInfo(2923), new ItemInfo(2924), new ItemInfo(2925), new ItemInfo(2926), new ItemInfo(2927), new ItemInfo(2928), new ItemInfo(2929), 
            new ItemInfo(2930), new ItemInfo(2931), new ItemInfo(2932), new ItemInfo(2933), new ItemInfo(2934), new ItemInfo(2935), new ItemInfo(2936), 
            new ItemInfo(2937), new ItemInfo(2938), new ItemInfo(2939), new ItemInfo(2940), new ItemInfo(2941), new ItemInfo(2942), new ItemInfo(2943), 
            new ItemInfo(2944), new ItemInfo(2945), new ItemInfo(2946), new ItemInfo(2947), new ItemInfo(2948), new ItemInfo(2949), new ItemInfo(2950), 
            new ItemInfo(2951), new ItemInfo(2952), new ItemInfo(2953), new ItemInfo(2954), new ItemInfo(2955), new ItemInfo(2956), new ItemInfo(2957), 
            new ItemInfo(2958), new ItemInfo(2959), new ItemInfo(2960), new ItemInfo(2961), new ItemInfo(2962), new ItemInfo(2963), new ItemInfo(2964), 
            new ItemInfo(3088), new ItemInfo(3089), new ItemInfo(3090), new ItemInfo(3091), new ItemInfo(3092), new ItemInfo(3093), new ItemInfo(3096), 
            new ItemInfo(3097), new ItemInfo(3098), new ItemInfo(3099), new ItemInfo(3100), new ItemInfo(3101), new ItemInfo(3102), new ItemInfo(3103), 
            new ItemInfo(3104), new ItemInfo(3105), new ItemInfo(3106), new ItemInfo(3107), new ItemInfo(3108), new ItemInfo(3109), new ItemInfo(3110), 
            new ItemInfo(3111), new ItemInfo(3112), new ItemInfo(3113), new ItemInfo(3114), new ItemInfo(3115), new ItemInfo(3121), new ItemInfo(3122), 
            new ItemInfo(3123), new ItemInfo(3124), new ItemInfo(3125), new ItemInfo(3126), new ItemInfo(3664), new ItemInfo(3665), new ItemInfo(3666), 
            new ItemInfo(3667), new ItemInfo(4491), new ItemInfo(4492), new ItemInfo(4493), new ItemInfo(4494), new ItemInfo(4495), new ItemInfo(4496), 
			new ItemInfo(4497), new ItemInfo(4498), new ItemInfo(4558), new ItemInfo(4559), new ItemInfo(4560), new ItemInfo(4561), new ItemInfo(4562), new ItemInfo(4563), 
            new ItemInfo(4564), new ItemInfo(4565), new ItemInfo(4592), new ItemInfo(4593), new ItemInfo(4594), new ItemInfo(4595), new ItemInfo(4596), 
            new ItemInfo(4597), new ItemInfo(4598), new ItemInfo(4599), new ItemInfo(4600), new ItemInfo(4601), new ItemInfo(4602), new ItemInfo(4603), 
            new ItemInfo(4604), new ItemInfo(4605), new ItemInfo(4606), new ItemInfo(4607), new ItemInfo(4608), new ItemInfo(4609), new ItemInfo(4610), 
            new ItemInfo(4611), new ItemInfo(4612), new ItemInfo(4613), new ItemInfo(4614), new ItemInfo(4615), new ItemInfo(4616), new ItemInfo(4617)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFurnPt2Gump()
			: this(0)
		{ }

		public AddFurnPt2Gump(int page) 
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

			from.SendGump(new AddFurnPt2Gump(page));
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
