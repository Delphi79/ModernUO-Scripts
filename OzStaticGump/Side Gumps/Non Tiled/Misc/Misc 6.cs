using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt6Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt6", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt6_OnCommand));
		}

		[Usage("AddMiscPt6")]
		
		public static void AddMiscPt6_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt6Gump>();
			e.Mobile.SendGump(new AddMiscPt6Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(3803), new ItemInfo(3804), new ItemInfo(3805), new ItemInfo(3806), new ItemInfo(3807), new ItemInfo(3808), new ItemInfo(3809), new ItemInfo(3810), new ItemInfo(3811), 
            new ItemInfo(3812), new ItemInfo(3813), new ItemInfo(3814), new ItemInfo(3815), new ItemInfo(3816), new ItemInfo(3817), new ItemInfo(3818), new ItemInfo(3819), new ItemInfo(3820), 
            new ItemInfo(3821), new ItemInfo(3822), new ItemInfo(3823), new ItemInfo(3824), new ItemInfo(3825), new ItemInfo(3826), new ItemInfo(3941), new ItemInfo(3942), new ItemInfo(3943), 
            new ItemInfo(3944), new ItemInfo(3945), new ItemInfo(3946), new ItemInfo(3948), new ItemInfo(3949), new ItemInfo(3950), new ItemInfo(3951), new ItemInfo(3952), new ItemInfo(3953), 
            new ItemInfo(3954), new ItemInfo(3955), new ItemInfo(3956), new ItemInfo(3957), new ItemInfo(3958), new ItemInfo(3959), new ItemInfo(3960), new ItemInfo(3961), new ItemInfo(3962), 
            new ItemInfo(3963), new ItemInfo(3964), new ItemInfo(3965), new ItemInfo(3966), new ItemInfo(3967), new ItemInfo(3968), new ItemInfo(3969), new ItemInfo(3970), new ItemInfo(3971), 
            new ItemInfo(3972), new ItemInfo(3973), new ItemInfo(3974), new ItemInfo(3975), new ItemInfo(3976), new ItemInfo(3977), new ItemInfo(3978), new ItemInfo(3979), new ItemInfo(3980), 
            new ItemInfo(3981), new ItemInfo(3982), new ItemInfo(3983), new ItemInfo(3984), new ItemInfo(3985), new ItemInfo(3986), new ItemInfo(3987), new ItemInfo(3988), new ItemInfo(3989), 
            new ItemInfo(3990), new ItemInfo(3991), new ItemInfo(3992), new ItemInfo(3993), new ItemInfo(3994), new ItemInfo(3995), new ItemInfo(3996), new ItemInfo(3997), new ItemInfo(3998), 
            new ItemInfo(3999), new ItemInfo(4000), new ItemInfo(4001), new ItemInfo(4002), new ItemInfo(4003), new ItemInfo(4004), new ItemInfo(4005), new ItemInfo(4006), new ItemInfo(4007), 
            new ItemInfo(4008), new ItemInfo(4009), new ItemInfo(4010), new ItemInfo(4011), new ItemInfo(4012), new ItemInfo(4013), new ItemInfo(4014), new ItemInfo(4015), new ItemInfo(4016), 
            new ItemInfo(4017), new ItemInfo(4018), new ItemInfo(4019), new ItemInfo(4020), new ItemInfo(4021), new ItemInfo(4022), new ItemInfo(4023), new ItemInfo(4024), new ItemInfo(4025), 
            new ItemInfo(4026), new ItemInfo(4027), new ItemInfo(4028), new ItemInfo(4029), new ItemInfo(4030), new ItemInfo(4031), new ItemInfo(4032), new ItemInfo(4033), new ItemInfo(4034), 
            new ItemInfo(4035), new ItemInfo(4036), new ItemInfo(4037), new ItemInfo(4038), new ItemInfo(4039), new ItemInfo(4040), new ItemInfo(4041), new ItemInfo(4042), new ItemInfo(4043), 
            new ItemInfo(4044), new ItemInfo(4045), new ItemInfo(4046), new ItemInfo(4047), new ItemInfo(4048), new ItemInfo(4049), new ItemInfo(4050), new ItemInfo(4051), new ItemInfo(4052), 
            new ItemInfo(4053), new ItemInfo(4054), new ItemInfo(4055), new ItemInfo(4056), new ItemInfo(4057), new ItemInfo(4058), new ItemInfo(4059), new ItemInfo(4060), new ItemInfo(4061), 
            new ItemInfo(4062), new ItemInfo(4063), new ItemInfo(4064), new ItemInfo(4065), new ItemInfo(4066), new ItemInfo(4067), new ItemInfo(4068), new ItemInfo(4069), new ItemInfo(4070), 
            new ItemInfo(4071), new ItemInfo(4072), new ItemInfo(4073), new ItemInfo(4074), new ItemInfo(4075), new ItemInfo(4076), new ItemInfo(4077), new ItemInfo(4078), new ItemInfo(4079), 
            new ItemInfo(4080), new ItemInfo(4081), new ItemInfo(4082), new ItemInfo(4083), new ItemInfo(4084), new ItemInfo(4085), new ItemInfo(4106), new ItemInfo(4107), new ItemInfo(4108), 
            new ItemInfo(4109), new ItemInfo(4110), new ItemInfo(4111), new ItemInfo(4112), new ItemInfo(4113), new ItemInfo(4114), new ItemInfo(4115), new ItemInfo(4116), new ItemInfo(4117), 
            new ItemInfo(4118), new ItemInfo(4119), new ItemInfo(4120), new ItemInfo(4121), new ItemInfo(4122), new ItemInfo(4123), new ItemInfo(4124), new ItemInfo(4125), new ItemInfo(4126), 
            new ItemInfo(4127), new ItemInfo(4128), new ItemInfo(4129), new ItemInfo(4130), new ItemInfo(4131), new ItemInfo(4132), new ItemInfo(4133), new ItemInfo(4134), new ItemInfo(4135), 
            new ItemInfo(4136), new ItemInfo(4137), new ItemInfo(4138), new ItemInfo(4139), new ItemInfo(4140), new ItemInfo(4141), new ItemInfo(4142), new ItemInfo(4143), new ItemInfo(4144), 
            new ItemInfo(4145), new ItemInfo(4146), new ItemInfo(4147), new ItemInfo(4148), new ItemInfo(4149), new ItemInfo(4150), new ItemInfo(4151), new ItemInfo(4152), new ItemInfo(4167),
            new ItemInfo(4168), new ItemInfo(4169), new ItemInfo(4170), new ItemInfo(4171), new ItemInfo(4172), new ItemInfo(4173), new ItemInfo(4174), new ItemInfo(4175), new ItemInfo(4176)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt6Gump()
			: this(0)
		{ }

		public AddMiscPt6Gump(int page) 
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

			from.SendGump(new AddMiscPt6Gump(page));
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
