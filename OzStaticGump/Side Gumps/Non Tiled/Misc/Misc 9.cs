using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt9Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt9", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt9_OnCommand));
		}

		[Usage("AddMiscPt9")]
		
		public static void AddMiscPt9_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt9Gump>();
			e.Mobile.SendGump(new AddMiscPt9Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(4664), new ItemInfo(4665), new ItemInfo(4666), new ItemInfo(4667), new ItemInfo(4668), new ItemInfo(4669), new ItemInfo(4670), new ItemInfo(4671), new ItemInfo(4672), 
            new ItemInfo(4673), new ItemInfo(4674), new ItemInfo(4675), new ItemInfo(4676), new ItemInfo(4677), new ItemInfo(4678), new ItemInfo(4679), new ItemInfo(4680), new ItemInfo(4681), 
            new ItemInfo(4682), new ItemInfo(4683), new ItemInfo(4684), new ItemInfo(4685), new ItemInfo(4686), new ItemInfo(4687), new ItemInfo(4688), new ItemInfo(4689), new ItemInfo(4690), 
            new ItemInfo(4691), new ItemInfo(4692), new ItemInfo(4693), new ItemInfo(4694), new ItemInfo(4695), new ItemInfo(4696), new ItemInfo(4697), new ItemInfo(4698), new ItemInfo(4699),
            new ItemInfo(4700), new ItemInfo(4701), new ItemInfo(4702), new ItemInfo(4703), new ItemInfo(4704), new ItemInfo(4705), new ItemInfo(4706), new ItemInfo(4707), new ItemInfo(4708), 
            new ItemInfo(4709), new ItemInfo(4710), new ItemInfo(4711), new ItemInfo(4712), new ItemInfo(4713), new ItemInfo(4714), new ItemInfo(4715), new ItemInfo(4716), new ItemInfo(4717), 
            new ItemInfo(4718), new ItemInfo(4719), new ItemInfo(4720), new ItemInfo(4721), new ItemInfo(4722), new ItemInfo(4723), new ItemInfo(4724), new ItemInfo(4725), new ItemInfo(4726), 
            new ItemInfo(4727), new ItemInfo(4728), new ItemInfo(4729), new ItemInfo(4730), new ItemInfo(4731), new ItemInfo(4732), new ItemInfo(4733), new ItemInfo(4734), new ItemInfo(4735), 
            new ItemInfo(4736), new ItemInfo(4737), new ItemInfo(4738), new ItemInfo(4739), new ItemInfo(4740), new ItemInfo(4741), new ItemInfo(4742), new ItemInfo(4743), new ItemInfo(4744), 
            new ItemInfo(4745), new ItemInfo(4746), new ItemInfo(4747), new ItemInfo(4748), new ItemInfo(4749), new ItemInfo(4750), new ItemInfo(4751), new ItemInfo(4752), new ItemInfo(4753), 
            new ItemInfo(4754), new ItemInfo(4755), new ItemInfo(4756), new ItemInfo(4757), new ItemInfo(4758), new ItemInfo(4759), new ItemInfo(4760), new ItemInfo(4761), new ItemInfo(4762), 
            new ItemInfo(4763), new ItemInfo(4764), new ItemInfo(4765), new ItemInfo(4766), new ItemInfo(4767), new ItemInfo(4768), new ItemInfo(4769), new ItemInfo(4770), new ItemInfo(4771),
            new ItemInfo(4772), new ItemInfo(4773), new ItemInfo(4774), new ItemInfo(4775), new ItemInfo(4776), new ItemInfo(4777), new ItemInfo(4778), new ItemInfo(4779), new ItemInfo(4780), 
            new ItemInfo(4781), new ItemInfo(4782), new ItemInfo(4783), new ItemInfo(4784), new ItemInfo(4785), new ItemInfo(4786), new ItemInfo(4787), new ItemInfo(4788), new ItemInfo(4808), 
            new ItemInfo(4809), new ItemInfo(4810), new ItemInfo(4811), new ItemInfo(4812), new ItemInfo(4813), new ItemInfo(4814), new ItemInfo(4815), new ItemInfo(4816), new ItemInfo(4817), 
            new ItemInfo(4818), new ItemInfo(4819), new ItemInfo(4820), new ItemInfo(4821), new ItemInfo(4822), new ItemInfo(4823), new ItemInfo(4824), new ItemInfo(4825), new ItemInfo(4826), 
            new ItemInfo(4827), new ItemInfo(4828), new ItemInfo(4829), new ItemInfo(4830), new ItemInfo(4831), new ItemInfo(4832), new ItemInfo(4833), new ItemInfo(4834), new ItemInfo(4835), 
            new ItemInfo(4836), new ItemInfo(4837), new ItemInfo(4838), new ItemInfo(4839), new ItemInfo(4840), new ItemInfo(4841), new ItemInfo(4842), new ItemInfo(4843), new ItemInfo(4844), 
            new ItemInfo(4845), new ItemInfo(4942), new ItemInfo(4975), new ItemInfo(4976), new ItemInfo(4977), new ItemInfo(4978), new ItemInfo(4979), new ItemInfo(4980), new ItemInfo(4981), 
            new ItemInfo(4982), new ItemInfo(4983), new ItemInfo(4984), new ItemInfo(4985), new ItemInfo(4986), new ItemInfo(4987), new ItemInfo(4988), new ItemInfo(4989), new ItemInfo(4995), 
            new ItemInfo(4996), new ItemInfo(4997), new ItemInfo(4998), new ItemInfo(4999), new ItemInfo(5000), new ItemInfo(5001), new ItemInfo(5002), new ItemInfo(5003), new ItemInfo(5004), 
            new ItemInfo(5005), new ItemInfo(5006), new ItemInfo(5007), new ItemInfo(5008), new ItemInfo(5009), new ItemInfo(5010), new ItemInfo(5011), new ItemInfo(5012), new ItemInfo(5013), 
            new ItemInfo(5014), new ItemInfo(5015), new ItemInfo(5016), new ItemInfo(5017), new ItemInfo(5018), new ItemInfo(5019), new ItemInfo(5020), new ItemInfo(5021), new ItemInfo(5022), 
            new ItemInfo(5023), new ItemInfo(5024), new ItemInfo(5025), new ItemInfo(5026), new ItemInfo(5027), new ItemInfo(5028), new ItemInfo(5029), new ItemInfo(5030), new ItemInfo(5031), 
            new ItemInfo(5032), new ItemInfo(5033), new ItemInfo(5034), new ItemInfo(5035), new ItemInfo(5036), new ItemInfo(5037), new ItemInfo(5038), new ItemInfo(5152), new ItemInfo(5153), 
            new ItemInfo(5154), new ItemInfo(5155), new ItemInfo(5156), new ItemInfo(5157), new ItemInfo(5158), new ItemInfo(5159), new ItemInfo(5160), new ItemInfo(5161), new ItemInfo(5162)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt9Gump()
			: this(0)
		{ }

		public AddMiscPt9Gump(int page) 
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

			from.SendGump(new AddMiscPt9Gump(page));
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
