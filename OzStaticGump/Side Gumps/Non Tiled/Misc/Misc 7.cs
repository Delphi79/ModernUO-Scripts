using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt7", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt7_OnCommand));
		}

		[Usage("AddMiscPt7")]
		
		public static void AddMiscPt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt7Gump>();
			e.Mobile.SendGump(new AddMiscPt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(4177), new ItemInfo(4178), new ItemInfo(4179), new ItemInfo(4180), new ItemInfo(4181), new ItemInfo(4182), new ItemInfo(4183), new ItemInfo(4184), new ItemInfo(4185), 
            new ItemInfo(4186), new ItemInfo(4187), new ItemInfo(4188), new ItemInfo(4189), new ItemInfo(4190), new ItemInfo(4191), new ItemInfo(4192), new ItemInfo(4193), new ItemInfo(4194), 
            new ItemInfo(4195), new ItemInfo(4196), new ItemInfo(4197), new ItemInfo(4198), new ItemInfo(4199), new ItemInfo(4200), new ItemInfo(4201), new ItemInfo(4202), new ItemInfo(4203), 
            new ItemInfo(4204), new ItemInfo(4205), new ItemInfo(4206), new ItemInfo(4207), new ItemInfo(4208), new ItemInfo(4209), new ItemInfo(4210), new ItemInfo(4211), new ItemInfo(4212), 
            new ItemInfo(4213), new ItemInfo(4214), new ItemInfo(4215), new ItemInfo(4216), new ItemInfo(4217), new ItemInfo(4218), new ItemInfo(4219), new ItemInfo(4220), new ItemInfo(4221), 
            new ItemInfo(4222), new ItemInfo(4223), new ItemInfo(4224), new ItemInfo(4225), new ItemInfo(4226), new ItemInfo(4228), new ItemInfo(4229), new ItemInfo(4230), new ItemInfo(4231), 
            new ItemInfo(4232), new ItemInfo(4233), new ItemInfo(4234), new ItemInfo(4235), new ItemInfo(4236), new ItemInfo(4237), new ItemInfo(4238), new ItemInfo(4239), new ItemInfo(4240), 
            new ItemInfo(4241), new ItemInfo(4242), new ItemInfo(4243), new ItemInfo(4244), new ItemInfo(4245), new ItemInfo(4246), new ItemInfo(4247), new ItemInfo(4248), new ItemInfo(4249), 
            new ItemInfo(4250), new ItemInfo(4251), new ItemInfo(4252), new ItemInfo(4253), new ItemInfo(4254), new ItemInfo(4255), new ItemInfo(4256), new ItemInfo(4257), new ItemInfo(4258), 
            new ItemInfo(4259), new ItemInfo(4260), new ItemInfo(4261), new ItemInfo(4262), new ItemInfo(4263), new ItemInfo(4264), new ItemInfo(4265), new ItemInfo(4266), new ItemInfo(4267), 
            new ItemInfo(4268), new ItemInfo(4269), new ItemInfo(4270), new ItemInfo(4271), new ItemInfo(4272), new ItemInfo(4273), new ItemInfo(4274), new ItemInfo(4275), new ItemInfo(4276), 
            new ItemInfo(4277), new ItemInfo(4278), new ItemInfo(4279), new ItemInfo(4280), new ItemInfo(4281), new ItemInfo(4282), new ItemInfo(4283), new ItemInfo(4284), new ItemInfo(4285), 
            new ItemInfo(4286), new ItemInfo(4287), new ItemInfo(4288), new ItemInfo(4289), new ItemInfo(4290), new ItemInfo(4291), new ItemInfo(4292), new ItemInfo(4293), new ItemInfo(4294), 
            new ItemInfo(4295), new ItemInfo(4296), new ItemInfo(4297), new ItemInfo(4298), new ItemInfo(4299), new ItemInfo(4300), new ItemInfo(4301), new ItemInfo(4302), new ItemInfo(4303), 
            new ItemInfo(4304), new ItemInfo(4305), new ItemInfo(4306), new ItemInfo(4307), new ItemInfo(4308), new ItemInfo(4309), new ItemInfo(4310), new ItemInfo(4311), new ItemInfo(4312), 
            new ItemInfo(4313), new ItemInfo(4314), new ItemInfo(4315), new ItemInfo(4316), new ItemInfo(4317), new ItemInfo(4318), new ItemInfo(4319), new ItemInfo(4320), new ItemInfo(4321), 
            new ItemInfo(4322), new ItemInfo(4323), new ItemInfo(4324), new ItemInfo(4325), new ItemInfo(4326), new ItemInfo(4327), new ItemInfo(4328), new ItemInfo(4329), new ItemInfo(4330), 
            new ItemInfo(4331), new ItemInfo(4332), new ItemInfo(4333), new ItemInfo(4334), new ItemInfo(4335), new ItemInfo(4336), new ItemInfo(4337), new ItemInfo(4338), new ItemInfo(4339), 
            new ItemInfo(4340), new ItemInfo(4341), new ItemInfo(4342), new ItemInfo(4343), new ItemInfo(4344), new ItemInfo(4345), new ItemInfo(4346), new ItemInfo(4347), new ItemInfo(4348), 
            new ItemInfo(4349), new ItemInfo(4350), new ItemInfo(4351), new ItemInfo(4352), new ItemInfo(4353), new ItemInfo(4354), new ItemInfo(4355), new ItemInfo(4356), new ItemInfo(4357), 
            new ItemInfo(4358), new ItemInfo(4359), new ItemInfo(4360), new ItemInfo(4361), new ItemInfo(4362), new ItemInfo(4363), new ItemInfo(4364), new ItemInfo(4365), new ItemInfo(4366), 
            new ItemInfo(4367), new ItemInfo(4368), new ItemInfo(4369), new ItemInfo(4370), new ItemInfo(4371), new ItemInfo(4372), new ItemInfo(4373), new ItemInfo(4374), new ItemInfo(4375), 
            new ItemInfo(4376), new ItemInfo(4377), new ItemInfo(4378), new ItemInfo(4379), new ItemInfo(4380), new ItemInfo(4381), new ItemInfo(4382), new ItemInfo(4383), new ItemInfo(4384), 
            new ItemInfo(4385), new ItemInfo(4386), new ItemInfo(4387), new ItemInfo(4388), new ItemInfo(4389), new ItemInfo(4390), new ItemInfo(4391), new ItemInfo(4392), new ItemInfo(4393), 
            new ItemInfo(4394), new ItemInfo(4395), new ItemInfo(4396), new ItemInfo(4397), new ItemInfo(4398), new ItemInfo(4399), new ItemInfo(4400), new ItemInfo(4401), new ItemInfo(4402)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt7Gump()
			: this(0)
		{ }

		public AddMiscPt7Gump(int page) 
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

			from.SendGump(new AddMiscPt7Gump(page));
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
