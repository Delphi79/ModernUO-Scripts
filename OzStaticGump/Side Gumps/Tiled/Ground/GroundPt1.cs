using Server.Network;

namespace Server.Gumps
{
	public class AddGroundStPt1Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGroundStPt1", AccessLevel.GameMaster, new CommandEventHandler(AddGroundStPt1_OnCommand));
		}

		[Usage("AddGroundStPt1")]
		
		public static void AddGroundStPt1_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGroundStPt1Gump>();
			e.Mobile.SendGump(new AddGroundStPt1Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region GroundSts
            new ItemInfo(1339), new ItemInfo(1340), new ItemInfo(1341), new ItemInfo(1342), new ItemInfo(1343), new ItemInfo(1344), new ItemInfo(1345), new ItemInfo(1346), 
            new ItemInfo(1347), new ItemInfo(1348), new ItemInfo(1349), new ItemInfo(1350), new ItemInfo(1351), new ItemInfo(1352), new ItemInfo(1353), new ItemInfo(1354), 
            new ItemInfo(1355), new ItemInfo(1356), new ItemInfo(1357), new ItemInfo(1358), new ItemInfo(1359), new ItemInfo(1386), new ItemInfo(4846), new ItemInfo(4847), 
            new ItemInfo(4848), new ItemInfo(4849), new ItemInfo(4850), new ItemInfo(4852), new ItemInfo(4853), new ItemInfo(4854), new ItemInfo(4855), new ItemInfo(4856), 
            new ItemInfo(4857), new ItemInfo(4858), new ItemInfo(4859), new ItemInfo(4860), new ItemInfo(4861), new ItemInfo(4862), new ItemInfo(4864), new ItemInfo(4865), 
            new ItemInfo(4866), new ItemInfo(4867), new ItemInfo(4868), new ItemInfo(4870), new ItemInfo(4871), new ItemInfo(4872), new ItemInfo(4873), new ItemInfo(4874), 
            new ItemInfo(4876), new ItemInfo(4877), new ItemInfo(4878), new ItemInfo(4879), new ItemInfo(4880), new ItemInfo(4882), new ItemInfo(4883), new ItemInfo(4884), 
            new ItemInfo(4885), new ItemInfo(4886), new ItemInfo(4888), new ItemInfo(4889), new ItemInfo(4890), new ItemInfo(4891), new ItemInfo(4892), new ItemInfo(4894), 
            new ItemInfo(4895), new ItemInfo(4896), new ItemInfo(4897), new ItemInfo(4898), new ItemInfo(4899), new ItemInfo(4900), new ItemInfo(4901), new ItemInfo(4902), 
            new ItemInfo(4903), new ItemInfo(4904), new ItemInfo(4905), new ItemInfo(4906), new ItemInfo(4907), new ItemInfo(4908), new ItemInfo(4909), new ItemInfo(4910), 
            new ItemInfo(4911), new ItemInfo(4912), new ItemInfo(4913), new ItemInfo(4914), new ItemInfo(4915), new ItemInfo(4916), new ItemInfo(4917), new ItemInfo(4918), 
            new ItemInfo(4919), new ItemInfo(4920), new ItemInfo(4921), new ItemInfo(4922), new ItemInfo(4923), new ItemInfo(4924), new ItemInfo(4925), new ItemInfo(4926), 
            new ItemInfo(4927), new ItemInfo(4928), new ItemInfo(4929), new ItemInfo(4930), new ItemInfo(4931), new ItemInfo(4932), new ItemInfo(4933), new ItemInfo(4934), 
            new ItemInfo(4935), new ItemInfo(4936), new ItemInfo(4937), new ItemInfo(4938), new ItemInfo(4939), new ItemInfo(4940), new ItemInfo(4941), new ItemInfo(4974),
            new ItemInfo(4990), new ItemInfo(4992), new ItemInfo(4994), new ItemInfo(6013), new ItemInfo(6014), new ItemInfo(6015), new ItemInfo(6016), new ItemInfo(6017), 
            new ItemInfo(6018), new ItemInfo(6019), new ItemInfo(6020), new ItemInfo(6021), new ItemInfo(6022), new ItemInfo(6023), new ItemInfo(6024), new ItemInfo(6025), 
            new ItemInfo(6038), new ItemInfo(6039), new ItemInfo(6040), new ItemInfo(6041), new ItemInfo(6042), new ItemInfo(6043), new ItemInfo(6044), new ItemInfo(6045), 
            new ItemInfo(6046), new ItemInfo(6047), new ItemInfo(6048), new ItemInfo(6049), new ItemInfo(6050), new ItemInfo(6051), new ItemInfo(6052), new ItemInfo(6053), 
            new ItemInfo(6054), new ItemInfo(6055), new ItemInfo(6056), new ItemInfo(6057), new ItemInfo(6058), new ItemInfo(6059), new ItemInfo(6060), new ItemInfo(6061), 
            new ItemInfo(6062), new ItemInfo(6063), new ItemInfo(6064), new ItemInfo(6065), new ItemInfo(6066), new ItemInfo(6077), new ItemInfo(6078), new ItemInfo(6079), 
            new ItemInfo(6080), new ItemInfo(6081), new ItemInfo(6082), new ItemInfo(6083), new ItemInfo(6084), new ItemInfo(6085), new ItemInfo(6086), new ItemInfo(6087), 
            new ItemInfo(6088), new ItemInfo(6089), new ItemInfo(6090), new ItemInfo(6091), new ItemInfo(6092), new ItemInfo(11070), new ItemInfo(11071), new ItemInfo(11073)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGroundStPt1Gump()
			: this(0)
		{ }

		public AddGroundStPt1Gump(int page) 
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

				CommandSystem.Handle(from, string.Format("{0}Tile Static {1}", CommandSystem.Prefix, m_Types[button].m_BaseID));
			}
			else if (button >= 10000)
			{
				button -= 10000;

				page = button;
			}

			from.SendGump(new AddGroundStPt1Gump(page));
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
