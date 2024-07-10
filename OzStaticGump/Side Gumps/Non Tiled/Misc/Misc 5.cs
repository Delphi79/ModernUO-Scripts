using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt5", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt5_OnCommand));
		}

		[Usage("AddMiscPt5")]
		
		public static void AddMiscPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt5Gump>();
			e.Mobile.SendGump(new AddMiscPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(3574), new ItemInfo(3575), new ItemInfo(3576), new ItemInfo(3577), new ItemInfo(3578), new ItemInfo(3579), new ItemInfo(3580), new ItemInfo(3581), new ItemInfo(3582), 
            new ItemInfo(3583), new ItemInfo(3584), new ItemInfo(3585), new ItemInfo(3586), new ItemInfo(3587), new ItemInfo(3588), new ItemInfo(3589), new ItemInfo(3590), new ItemInfo(3591),
            new ItemInfo(3592), new ItemInfo(3593), new ItemInfo(3594), new ItemInfo(3595), new ItemInfo(3596), new ItemInfo(3597), new ItemInfo(3598), new ItemInfo(3599), new ItemInfo(3600), 
            new ItemInfo(3601), new ItemInfo(3602), new ItemInfo(3603), new ItemInfo(3604), new ItemInfo(3605), new ItemInfo(3606), new ItemInfo(3607), new ItemInfo(3608), new ItemInfo(3609), 
            new ItemInfo(3610), new ItemInfo(3611), new ItemInfo(3612), new ItemInfo(3613), new ItemInfo(3614), new ItemInfo(3615), new ItemInfo(3616), new ItemInfo(3617), new ItemInfo(3618), 
            new ItemInfo(3619), new ItemInfo(3620), new ItemInfo(3621), new ItemInfo(3622), new ItemInfo(3623), new ItemInfo(3624), new ItemInfo(3625), new ItemInfo(3626), new ItemInfo(3627), 
            new ItemInfo(3628), new ItemInfo(3629), new ItemInfo(3630), new ItemInfo(3631), new ItemInfo(3632), new ItemInfo(3633), new ItemInfo(3634), new ItemInfo(3635), new ItemInfo(3636), 
            new ItemInfo(3637), new ItemInfo(3638), new ItemInfo(3639), new ItemInfo(3640), new ItemInfo(3641), new ItemInfo(3642), new ItemInfo(3643), new ItemInfo(3644), new ItemInfo(3645), 
            new ItemInfo(3646), new ItemInfo(3647), new ItemInfo(3648), new ItemInfo(3649), new ItemInfo(3650), new ItemInfo(3651), new ItemInfo(3652), new ItemInfo(3653), new ItemInfo(3654), 
            new ItemInfo(3655), new ItemInfo(3656), new ItemInfo(3657), new ItemInfo(3658), new ItemInfo(3659), new ItemInfo(3660), new ItemInfo(3661), new ItemInfo(3662), new ItemInfo(3663), 
            new ItemInfo(3668), new ItemInfo(3669), new ItemInfo(3670), new ItemInfo(3671), new ItemInfo(3672), new ItemInfo(3673), new ItemInfo(3674), new ItemInfo(3675), new ItemInfo(3676), 
            new ItemInfo(3677), new ItemInfo(3678), new ItemInfo(3679), new ItemInfo(3680), new ItemInfo(3681), new ItemInfo(3682), new ItemInfo(3683), new ItemInfo(3684), new ItemInfo(3685), 
            new ItemInfo(3686), new ItemInfo(3687), new ItemInfo(3688), new ItemInfo(3689), new ItemInfo(3690), new ItemInfo(3691), new ItemInfo(3692), new ItemInfo(3693), new ItemInfo(3694), 
            new ItemInfo(3695), new ItemInfo(3696), new ItemInfo(3697), new ItemInfo(3698), new ItemInfo(3699), new ItemInfo(3700), new ItemInfo(3701), new ItemInfo(3702), new ItemInfo(3703), 
            new ItemInfo(3704), new ItemInfo(3705), new ItemInfo(3706), new ItemInfo(3707), new ItemInfo(3708), new ItemInfo(3709), new ItemInfo(3710), new ItemInfo(3711), new ItemInfo(3712), 
            new ItemInfo(3713), new ItemInfo(3714), new ItemInfo(3715), new ItemInfo(3716), new ItemInfo(3717), new ItemInfo(3718), new ItemInfo(3719), new ItemInfo(3720), new ItemInfo(3721), 
            new ItemInfo(3722), new ItemInfo(3723), new ItemInfo(3724), new ItemInfo(3725), new ItemInfo(3726), new ItemInfo(3727), new ItemInfo(3728), new ItemInfo(3729), new ItemInfo(3730), 
            new ItemInfo(3731), new ItemInfo(3732), new ItemInfo(3733), new ItemInfo(3734), new ItemInfo(3735), new ItemInfo(3736), new ItemInfo(3737), new ItemInfo(3738), new ItemInfo(3739), 
            new ItemInfo(3740), new ItemInfo(3741), new ItemInfo(3742), new ItemInfo(3743), new ItemInfo(3744), new ItemInfo(3745), new ItemInfo(3746), new ItemInfo(3747), new ItemInfo(3748), 
            new ItemInfo(3749), new ItemInfo(3750), new ItemInfo(3751), new ItemInfo(3752), new ItemInfo(3753), new ItemInfo(3754), new ItemInfo(3755), new ItemInfo(3756), new ItemInfo(3757), 
            new ItemInfo(3758), new ItemInfo(3759), new ItemInfo(3760), new ItemInfo(3761), new ItemInfo(3762), new ItemInfo(3763), new ItemInfo(3764), new ItemInfo(3765), new ItemInfo(3766), 
            new ItemInfo(3767), new ItemInfo(3768), new ItemInfo(3769), new ItemInfo(3770), new ItemInfo(3771), new ItemInfo(3772), new ItemInfo(3773), new ItemInfo(3774), new ItemInfo(3775), 
            new ItemInfo(3776), new ItemInfo(3777), new ItemInfo(3778), new ItemInfo(3779), new ItemInfo(3780), new ItemInfo(3781), new ItemInfo(3782), new ItemInfo(3783), new ItemInfo(3784), 
            new ItemInfo(3785), new ItemInfo(3786), new ItemInfo(3787), new ItemInfo(3788), new ItemInfo(3789), new ItemInfo(3790), new ItemInfo(3791), new ItemInfo(3792), new ItemInfo(3793), 
            new ItemInfo(3794), new ItemInfo(3795), new ItemInfo(3796), new ItemInfo(3797), new ItemInfo(3798), new ItemInfo(3799), new ItemInfo(3800), new ItemInfo(3801), new ItemInfo(3802)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt5Gump()
			: this(0)
		{ }

		public AddMiscPt5Gump(int page) 
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

			from.SendGump(new AddMiscPt5Gump(page));
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
