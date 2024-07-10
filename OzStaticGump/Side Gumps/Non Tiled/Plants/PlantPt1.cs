using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt1", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt1_OnCommand));
		}

		[Usage("AddPlantPt1")]
		public static void AddPlantPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt1Gump>();
			e.Mobile.SendGump(new AddPlantPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(731), new ItemInfo(3131), new ItemInfo(3132), new ItemInfo(3133), new ItemInfo(3134), new ItemInfo(3135), new ItemInfo(3136), new ItemInfo(3137), 
            new ItemInfo(3138), new ItemInfo(3141), new ItemInfo(3142), new ItemInfo(3143), new ItemInfo(3144), new ItemInfo(3145), new ItemInfo(3146), new ItemInfo(3147), 
            new ItemInfo(3148), new ItemInfo(3149), new ItemInfo(3150), new ItemInfo(3151), new ItemInfo(3152), new ItemInfo(3153), new ItemInfo(3154), new ItemInfo(3155), 
            new ItemInfo(3156), new ItemInfo(3157), new ItemInfo(3158), new ItemInfo(3159), new ItemInfo(3160), new ItemInfo(3161), new ItemInfo(3162), new ItemInfo(3163), 
            new ItemInfo(3166), new ItemInfo(3167), new ItemInfo(3168), new ItemInfo(3169), new ItemInfo(3170), new ItemInfo(3171), new ItemInfo(3176), new ItemInfo(3177), 
            new ItemInfo(3183), new ItemInfo(3190), new ItemInfo(3197), new ItemInfo(3198), new ItemInfo(3203), new ItemInfo(3204), new ItemInfo(3205), new ItemInfo(3206), 
            new ItemInfo(3207), new ItemInfo(3208), new ItemInfo(3209), new ItemInfo(3210), new ItemInfo(3211), new ItemInfo(3212), new ItemInfo(3213), new ItemInfo(3214), 
            new ItemInfo(3215), new ItemInfo(3216), new ItemInfo(3217), new ItemInfo(3218), new ItemInfo(3219), new ItemInfo(3220), new ItemInfo(3221), new ItemInfo(3222), 
            new ItemInfo(3223), new ItemInfo(3224), new ItemInfo(3225), new ItemInfo(3226), new ItemInfo(3227), new ItemInfo(3228), new ItemInfo(3229), new ItemInfo(3230), 
            new ItemInfo(3231), new ItemInfo(3232), new ItemInfo(3233), new ItemInfo(3234), new ItemInfo(3235), new ItemInfo(3236), new ItemInfo(3237), new ItemInfo(3238), 
            new ItemInfo(3239), new ItemInfo(3240), new ItemInfo(3241), new ItemInfo(3242), new ItemInfo(3243), new ItemInfo(3244), new ItemInfo(3245), new ItemInfo(3246), 
            new ItemInfo(3247), new ItemInfo(3248), new ItemInfo(3249), new ItemInfo(3250), new ItemInfo(3251), new ItemInfo(3252), new ItemInfo(3253), new ItemInfo(3254), 
            new ItemInfo(3255), new ItemInfo(3256), new ItemInfo(3257), new ItemInfo(3258), new ItemInfo(3259), new ItemInfo(3260), new ItemInfo(3261), new ItemInfo(3262), 
            new ItemInfo(3263), new ItemInfo(3264), new ItemInfo(3265), new ItemInfo(3267), new ItemInfo(3268), new ItemInfo(3269), new ItemInfo(3270), new ItemInfo(3271), 
            new ItemInfo(3272), new ItemInfo(3273), new ItemInfo(3274), new ItemInfo(3275), new ItemInfo(3276), new ItemInfo(3277), new ItemInfo(3278), new ItemInfo(3279), 
            new ItemInfo(3280), new ItemInfo(3281), new ItemInfo(3282), new ItemInfo(3283), new ItemInfo(3284), new ItemInfo(3285), new ItemInfo(3286), new ItemInfo(3287), 
            new ItemInfo(3288), new ItemInfo(3289), new ItemInfo(3290), new ItemInfo(3291), new ItemInfo(3292), new ItemInfo(3293), new ItemInfo(3294), new ItemInfo(3295), 
            new ItemInfo(3296), new ItemInfo(3297), new ItemInfo(3298), new ItemInfo(3299), new ItemInfo(3300), new ItemInfo(3301), new ItemInfo(3302), new ItemInfo(3303), 
            new ItemInfo(3304), new ItemInfo(3305), new ItemInfo(3306), new ItemInfo(3307), new ItemInfo(3308), new ItemInfo(3309), new ItemInfo(3310), new ItemInfo(3311), 
            new ItemInfo(3312), new ItemInfo(3313), new ItemInfo(3314), new ItemInfo(3315), new ItemInfo(3316), new ItemInfo(3317), new ItemInfo(3318), new ItemInfo(3319), 
            new ItemInfo(3320), new ItemInfo(3321), new ItemInfo(3322), new ItemInfo(3323), new ItemInfo(3324), new ItemInfo(3325), new ItemInfo(3326), new ItemInfo(3327), 
            new ItemInfo(3328), new ItemInfo(3329), new ItemInfo(3330), new ItemInfo(3331), new ItemInfo(3332), new ItemInfo(3333), new ItemInfo(3334), new ItemInfo(3335)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt1Gump()
			: this(0)
		{ }

		public AddPlantPt1Gump(int page) 
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

			from.SendGump(new AddPlantPt1Gump(page));
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
