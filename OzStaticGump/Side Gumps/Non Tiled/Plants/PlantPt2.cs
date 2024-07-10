using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt2", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt2_OnCommand));
		}

		[Usage("AddPlantPt2")]
		public static void AddPlantPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt2Gump>();
			e.Mobile.SendGump(new AddPlantPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(3336), new ItemInfo(3337), new ItemInfo(3338), new ItemInfo(3339), new ItemInfo(3340), new ItemInfo(3341), new ItemInfo(3342), new ItemInfo(3343), 
            new ItemInfo(3344), new ItemInfo(3345), new ItemInfo(3346), new ItemInfo(3347), new ItemInfo(3348), new ItemInfo(3349), new ItemInfo(3350), new ItemInfo(3351), 
            new ItemInfo(3352), new ItemInfo(3353), new ItemInfo(3365), new ItemInfo(3366), new ItemInfo(3367), new ItemInfo(3368), new ItemInfo(3369), new ItemInfo(3370), 
            new ItemInfo(3371), new ItemInfo(3372), new ItemInfo(3373), new ItemInfo(3374), new ItemInfo(3375), new ItemInfo(3376), new ItemInfo(3377), new ItemInfo(3378), 
            new ItemInfo(3379), new ItemInfo(3380), new ItemInfo(3381), new ItemInfo(3382), new ItemInfo(3383), new ItemInfo(3384), new ItemInfo(3385), new ItemInfo(3386), 
            new ItemInfo(3387), new ItemInfo(3388), new ItemInfo(3389), new ItemInfo(3391), new ItemInfo(3392), new ItemInfo(3393), new ItemInfo(3394), new ItemInfo(3395), 
            new ItemInfo(3396), new ItemInfo(3397), new ItemInfo(3398), new ItemInfo(3399), new ItemInfo(3400), new ItemInfo(3401), new ItemInfo(3402), new ItemInfo(3403), 
            new ItemInfo(3404), new ItemInfo(3405), new ItemInfo(3406), new ItemInfo(3407), new ItemInfo(3408), new ItemInfo(3409), new ItemInfo(3410), new ItemInfo(3411), 
            new ItemInfo(3412), new ItemInfo(3413), new ItemInfo(3414), new ItemInfo(3415), new ItemInfo(3416), new ItemInfo(3417), new ItemInfo(3418), new ItemInfo(3419), 
            new ItemInfo(3420), new ItemInfo(3421), new ItemInfo(3422), new ItemInfo(3423), new ItemInfo(3424), new ItemInfo(3425), new ItemInfo(3426), new ItemInfo(3427), 
            new ItemInfo(3428), new ItemInfo(3429), new ItemInfo(3430), new ItemInfo(3431), new ItemInfo(3432), new ItemInfo(3433), new ItemInfo(3434), new ItemInfo(3435), 
            new ItemInfo(3436), new ItemInfo(3437), new ItemInfo(3438), new ItemInfo(3439), new ItemInfo(3440), new ItemInfo(3441), new ItemInfo(3442), new ItemInfo(3443), 
            new ItemInfo(3444), new ItemInfo(3445), new ItemInfo(3446), new ItemInfo(3447), new ItemInfo(3448), new ItemInfo(3449), new ItemInfo(3450), new ItemInfo(3451), 
            new ItemInfo(3452), new ItemInfo(3453), new ItemInfo(3454), new ItemInfo(3455), new ItemInfo(3456), new ItemInfo(3457), new ItemInfo(3458), new ItemInfo(3459), 
            new ItemInfo(3460), new ItemInfo(3461), new ItemInfo(3462), new ItemInfo(3463), new ItemInfo(3464), new ItemInfo(3465), new ItemInfo(3466), new ItemInfo(3467), 
            new ItemInfo(3468), new ItemInfo(3469), new ItemInfo(3470), new ItemInfo(3471), new ItemInfo(3472), new ItemInfo(3473), new ItemInfo(3474), new ItemInfo(3475), 
            new ItemInfo(3476), new ItemInfo(3477), new ItemInfo(3478), new ItemInfo(3479), new ItemInfo(3480), new ItemInfo(3481), new ItemInfo(3482), new ItemInfo(3483), 
            new ItemInfo(3484), new ItemInfo(3485), new ItemInfo(3486), new ItemInfo(3487), new ItemInfo(3488), new ItemInfo(3489), new ItemInfo(3490), new ItemInfo(3491), 
            new ItemInfo(3492), new ItemInfo(3493), new ItemInfo(3494), new ItemInfo(3495), new ItemInfo(3496), new ItemInfo(3497), new ItemInfo(3498), new ItemInfo(3499), 
            new ItemInfo(3500), new ItemInfo(3501), new ItemInfo(3502), new ItemInfo(3503), new ItemInfo(3512), new ItemInfo(3513), new ItemInfo(3514), new ItemInfo(3515), 
            new ItemInfo(3516), new ItemInfo(3517), new ItemInfo(3518), new ItemInfo(3519), new ItemInfo(3520), new ItemInfo(3521), new ItemInfo(3522), new ItemInfo(3523), 
            new ItemInfo(3524), new ItemInfo(3525), new ItemInfo(4789), new ItemInfo(4790), new ItemInfo(4791), new ItemInfo(4792), new ItemInfo(4793), new ItemInfo(4794)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt2Gump()
			: this(0)
		{ }

		public AddPlantPt2Gump(int page) 
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

			from.SendGump(new AddPlantPt2Gump(page));
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
