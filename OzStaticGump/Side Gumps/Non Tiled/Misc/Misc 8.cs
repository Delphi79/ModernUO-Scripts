using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt8Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt8", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt8_OnCommand));
		}

		[Usage("AddMiscPt8")]
		
		public static void AddMiscPt8_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt8Gump>();
			e.Mobile.SendGump(new AddMiscPt8Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(4403), new ItemInfo(4404), new ItemInfo(4405), new ItemInfo(4406), new ItemInfo(4407), new ItemInfo(4408), new ItemInfo(4409), new ItemInfo(4410), new ItemInfo(4411), 
            new ItemInfo(4412), new ItemInfo(4413), new ItemInfo(4414), new ItemInfo(4415), new ItemInfo(4416), new ItemInfo(4417), new ItemInfo(4418), new ItemInfo(4419), new ItemInfo(4420), 
            new ItemInfo(4421), new ItemInfo(4422), new ItemInfo(4423), new ItemInfo(4424), new ItemInfo(4425), new ItemInfo(4426), new ItemInfo(4427), new ItemInfo(4428), new ItemInfo(4429), 
            new ItemInfo(4430), new ItemInfo(4431), new ItemInfo(4432), new ItemInfo(4433), new ItemInfo(4434), new ItemInfo(4435), new ItemInfo(4436), new ItemInfo(4437), new ItemInfo(4438), 
            new ItemInfo(4439), new ItemInfo(4440), new ItemInfo(4441), new ItemInfo(4442), new ItemInfo(4443), new ItemInfo(4444), new ItemInfo(4445), new ItemInfo(4446), new ItemInfo(4447), 
            new ItemInfo(4448), new ItemInfo(4449), new ItemInfo(4450), new ItemInfo(4451), new ItemInfo(4452), new ItemInfo(4453), new ItemInfo(4454), new ItemInfo(4455), new ItemInfo(4456), 
            new ItemInfo(4457), new ItemInfo(4458), new ItemInfo(4459), new ItemInfo(4460), new ItemInfo(4461), new ItemInfo(4462), new ItemInfo(4463), new ItemInfo(4464), new ItemInfo(4465), 
            new ItemInfo(4466), new ItemInfo(4467), new ItemInfo(4468), new ItemInfo(4469), new ItemInfo(4470), new ItemInfo(4471), new ItemInfo(4472), new ItemInfo(4473), new ItemInfo(4474), 
            new ItemInfo(4475), new ItemInfo(4476), new ItemInfo(4477), new ItemInfo(4478), new ItemInfo(4479), new ItemInfo(4480), new ItemInfo(4481), new ItemInfo(4482), new ItemInfo(4483), 
            new ItemInfo(4484), new ItemInfo(4485), new ItemInfo(4486), new ItemInfo(4487), new ItemInfo(4488), new ItemInfo(4489), new ItemInfo(4490), new ItemInfo(4491), new ItemInfo(4492), 
            new ItemInfo(4493), new ItemInfo(4494), new ItemInfo(4495), new ItemInfo(4496), new ItemInfo(4497), new ItemInfo(4498), new ItemInfo(4499), new ItemInfo(4500), new ItemInfo(4501), 
            new ItemInfo(4502), new ItemInfo(4503), new ItemInfo(4504), new ItemInfo(4505), new ItemInfo(4506), new ItemInfo(4507), new ItemInfo(4508), new ItemInfo(4509), new ItemInfo(4510), 
            new ItemInfo(4511), new ItemInfo(4512), new ItemInfo(4513), new ItemInfo(4514), new ItemInfo(4515), new ItemInfo(4516), new ItemInfo(4517), new ItemInfo(4518), new ItemInfo(4519), 
            new ItemInfo(4520), new ItemInfo(4521), new ItemInfo(4522), new ItemInfo(4523), new ItemInfo(4524), new ItemInfo(4525), new ItemInfo(4526), new ItemInfo(4527), new ItemInfo(4528), 
            new ItemInfo(4529), new ItemInfo(4530), new ItemInfo(4531), new ItemInfo(4532), new ItemInfo(4533), new ItemInfo(4534), new ItemInfo(4535), new ItemInfo(4536), new ItemInfo(4537), 
            new ItemInfo(4538), new ItemInfo(4539), new ItemInfo(4544), new ItemInfo(4545), new ItemInfo(4546), new ItemInfo(4547), new ItemInfo(4548), new ItemInfo(4549), new ItemInfo(4550), 
            new ItemInfo(4551), new ItemInfo(4552), new ItemInfo(4553), new ItemInfo(4554), new ItemInfo(4555), new ItemInfo(4556), new ItemInfo(4557), new ItemInfo(4566), new ItemInfo(4567),
            new ItemInfo(3565), new ItemInfo(3566), new ItemInfo(3567), new ItemInfo(3568), new ItemInfo(3569), new ItemInfo(3570), new ItemInfo(3571), new ItemInfo(3572), new ItemInfo(3573), 
            new ItemInfo(4568), new ItemInfo(4569), new ItemInfo(4570), new ItemInfo(4571), new ItemInfo(4572), new ItemInfo(4573), new ItemInfo(4574), new ItemInfo(4575), new ItemInfo(4576), 
            new ItemInfo(4577), new ItemInfo(4578), new ItemInfo(4579), new ItemInfo(4580), new ItemInfo(4581), new ItemInfo(4582), new ItemInfo(4583), new ItemInfo(4584), new ItemInfo(4585), 
            new ItemInfo(4586), new ItemInfo(4587), new ItemInfo(4588), new ItemInfo(4589), new ItemInfo(4590), new ItemInfo(4591), new ItemInfo(4621), new ItemInfo(4622), new ItemInfo(4623), 
            new ItemInfo(4624), new ItemInfo(4625), new ItemInfo(4626), new ItemInfo(4627), new ItemInfo(4628), new ItemInfo(4629), new ItemInfo(4630), new ItemInfo(4631), new ItemInfo(4636), 
            new ItemInfo(4637), new ItemInfo(4638), new ItemInfo(4639), new ItemInfo(4640), new ItemInfo(4641), new ItemInfo(4642), new ItemInfo(4643), new ItemInfo(4644), new ItemInfo(4645), 
            new ItemInfo(4646), new ItemInfo(4647), new ItemInfo(4648), new ItemInfo(4649), new ItemInfo(4650), new ItemInfo(4651), new ItemInfo(4652), new ItemInfo(4653), new ItemInfo(4654), 
            new ItemInfo(4655), new ItemInfo(4656), new ItemInfo(4657), new ItemInfo(4658), new ItemInfo(4659), new ItemInfo(4660), new ItemInfo(4661), new ItemInfo(4662), new ItemInfo(4663)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt8Gump()
			: this(0)
		{ }

		public AddMiscPt8Gump(int page) 
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

			from.SendGump(new AddMiscPt8Gump(page));
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
