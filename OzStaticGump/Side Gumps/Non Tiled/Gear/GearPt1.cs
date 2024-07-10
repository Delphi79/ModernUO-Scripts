using Server.Network;

namespace Server.Gumps
{
	public class AddGearPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGearPt1", AccessLevel.GameMaster, new CommandEventHandler(AddGearPt1_OnCommand));
		}

		[Usage("AddGearPt1")]
		
		public static void AddGearPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGearPt1Gump>();
			e.Mobile.SendGump(new AddGearPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(643), new ItemInfo(644), new ItemInfo(645), new ItemInfo(646), new ItemInfo(647), new ItemInfo(648), new ItemInfo(649), new ItemInfo(650), 
            new ItemInfo(769), new ItemInfo(770), new ItemInfo(771), new ItemInfo(772), new ItemInfo(773), new ItemInfo(774), new ItemInfo(775), new ItemInfo(776), 
            new ItemInfo(777), new ItemInfo(778), new ItemInfo(779), new ItemInfo(780), new ItemInfo(781), new ItemInfo(782), new ItemInfo(784), new ItemInfo(785), 
            new ItemInfo(2301), new ItemInfo(2302), new ItemInfo(2303), new ItemInfo(2304), new ItemInfo(2305), new ItemInfo(2306), new ItemInfo(2307), new ItemInfo(2308), 
            new ItemInfo(2309), new ItemInfo(2310), new ItemInfo(2311), new ItemInfo(2312), new ItemInfo(2313), new ItemInfo(2314), new ItemInfo(2315), new ItemInfo(2316), 
            new ItemInfo(3827), new ItemInfo(3828), new ItemInfo(3829), new ItemInfo(3830), new ItemInfo(3831), new ItemInfo(3832), new ItemInfo(3833), new ItemInfo(3834), 
            new ItemInfo(3835), new ItemInfo(3836), new ItemInfo(3837), new ItemInfo(3838), new ItemInfo(3839), new ItemInfo(3840), new ItemInfo(3841), new ItemInfo(3842), 
            new ItemInfo(3843), new ItemInfo(3844), new ItemInfo(3845), new ItemInfo(3846), new ItemInfo(3847), new ItemInfo(3848), new ItemInfo(3849), new ItemInfo(3850), 
            new ItemInfo(3851), new ItemInfo(3852), new ItemInfo(3853), new ItemInfo(3854), new ItemInfo(3855), new ItemInfo(3856), new ItemInfo(3857), new ItemInfo(3858), 
            new ItemInfo(3859), new ItemInfo(3860), new ItemInfo(3861), new ItemInfo(3862), new ItemInfo(3863), new ItemInfo(3864), new ItemInfo(3865), new ItemInfo(3866), 
            new ItemInfo(3867), new ItemInfo(3868), new ItemInfo(3869), new ItemInfo(3870), new ItemInfo(3871), new ItemInfo(3872), new ItemInfo(3873), new ItemInfo(3874), 
            new ItemInfo(3875), new ItemInfo(3876), new ItemInfo(3877), new ItemInfo(3878), new ItemInfo(3879), new ItemInfo(3880), new ItemInfo(3881), new ItemInfo(3882), 
            new ItemInfo(3883), new ItemInfo(3884), new ItemInfo(3885), new ItemInfo(3886), new ItemInfo(3887), new ItemInfo(3888), new ItemInfo(3889), new ItemInfo(3890), 
            new ItemInfo(3891), new ItemInfo(3892), new ItemInfo(3893), new ItemInfo(3894), new ItemInfo(3895), new ItemInfo(3896), new ItemInfo(3897), new ItemInfo(3898), 
            new ItemInfo(3899), new ItemInfo(3900), new ItemInfo(3901), new ItemInfo(3902), new ItemInfo(3903), new ItemInfo(3904), new ItemInfo(3905), new ItemInfo(3906), 
            new ItemInfo(3907), new ItemInfo(3908), new ItemInfo(3909), new ItemInfo(3910), new ItemInfo(3911), new ItemInfo(3912), new ItemInfo(3913), new ItemInfo(3914), 
            new ItemInfo(3915), new ItemInfo(3916), new ItemInfo(3917), new ItemInfo(3918), new ItemInfo(3919), new ItemInfo(3920), new ItemInfo(3921), new ItemInfo(3922), 
            new ItemInfo(3923), new ItemInfo(3924), new ItemInfo(3925), new ItemInfo(3926), new ItemInfo(3927), new ItemInfo(3928), new ItemInfo(3929), new ItemInfo(3930), 
            new ItemInfo(3931), new ItemInfo(3932), new ItemInfo(3933), new ItemInfo(3934), new ItemInfo(3935), new ItemInfo(3936), new ItemInfo(3937), new ItemInfo(3938), 
            new ItemInfo(3939), new ItemInfo(3940), new ItemInfo(3947), new ItemInfo(5039), new ItemInfo(5040), new ItemInfo(5041), new ItemInfo(5042), new ItemInfo(5043), 
            new ItemInfo(5044), new ItemInfo(5045), new ItemInfo(5046), new ItemInfo(5047), new ItemInfo(5048), new ItemInfo(5049), new ItemInfo(5050), new ItemInfo(5051), 
            new ItemInfo(5052), new ItemInfo(5053), new ItemInfo(5054), new ItemInfo(5055), new ItemInfo(5056), new ItemInfo(5057), new ItemInfo(5058), new ItemInfo(5059)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGearPt1Gump()
			: this(0)
		{ }

		public AddGearPt1Gump(int page) 
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

			from.SendGump(new AddGearPt1Gump(page));
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
