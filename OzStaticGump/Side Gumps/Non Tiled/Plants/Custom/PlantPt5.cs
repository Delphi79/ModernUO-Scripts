using Server.Network;

namespace Server.Gumps
{
	public class AddPlantPt5Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddPlantPt5", AccessLevel.GameMaster, new CommandEventHandler(AddPlantPt5_OnCommand));
		}

		[Usage("AddPlantPt5")]
		public static void AddPlantPt5_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddPlantPt5Gump>();
			e.Mobile.SendGump(new AddPlantPt5Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(41763), new ItemInfo(41764), new ItemInfo(41765), new ItemInfo(41766), new ItemInfo(41767), new ItemInfo(41768), new ItemInfo(41769), new ItemInfo(41770), 
            new ItemInfo(41771), new ItemInfo(41772), new ItemInfo(41773), new ItemInfo(41774), new ItemInfo(41775), new ItemInfo(41776), new ItemInfo(41777), new ItemInfo(41778), 
            new ItemInfo(41779), new ItemInfo(41780), new ItemInfo(41781), new ItemInfo(41782), new ItemInfo(41783), new ItemInfo(41784), new ItemInfo(41785), new ItemInfo(41786), 
            new ItemInfo(41787), new ItemInfo(41788), new ItemInfo(41789), new ItemInfo(41790), new ItemInfo(41791), new ItemInfo(41792), new ItemInfo(41793), new ItemInfo(41794), 
            new ItemInfo(41795), new ItemInfo(41796), new ItemInfo(41797), new ItemInfo(41798), new ItemInfo(41799), new ItemInfo(41800), new ItemInfo(41801), new ItemInfo(41802), 
            new ItemInfo(41803), new ItemInfo(41804), new ItemInfo(41805), new ItemInfo(41806), new ItemInfo(41807), new ItemInfo(41808), new ItemInfo(41809), new ItemInfo(41810), 
            new ItemInfo(41811), new ItemInfo(41812), new ItemInfo(41813), new ItemInfo(41814), new ItemInfo(41815), new ItemInfo(41816), new ItemInfo(41817), new ItemInfo(41818), 
            new ItemInfo(41819), new ItemInfo(41820), new ItemInfo(41821), new ItemInfo(41822), new ItemInfo(41823), new ItemInfo(41824), new ItemInfo(41825), new ItemInfo(41826), 
            new ItemInfo(41827), new ItemInfo(41828), new ItemInfo(41829), new ItemInfo(41830), new ItemInfo(41831), new ItemInfo(41832), new ItemInfo(41833), new ItemInfo(41834), 
            new ItemInfo(41835), new ItemInfo(41836), new ItemInfo(41837), new ItemInfo(41838), new ItemInfo(41839), new ItemInfo(41840), new ItemInfo(41841), new ItemInfo(41842), 
            new ItemInfo(41843), new ItemInfo(41844), new ItemInfo(41845), new ItemInfo(41846), new ItemInfo(41847), new ItemInfo(41848), new ItemInfo(41849), new ItemInfo(41850), 
            new ItemInfo(41851), new ItemInfo(41852), new ItemInfo(41853), new ItemInfo(41854), new ItemInfo(41855), new ItemInfo(41856), new ItemInfo(41857), new ItemInfo(41858), 
            new ItemInfo(41859), new ItemInfo(41860), new ItemInfo(41861), new ItemInfo(41862), new ItemInfo(41863), new ItemInfo(41864), new ItemInfo(41865), new ItemInfo(41866), 
            new ItemInfo(41867), new ItemInfo(41868), new ItemInfo(41869), new ItemInfo(41870), new ItemInfo(41871), new ItemInfo(41872), new ItemInfo(41873), new ItemInfo(41874), 
            new ItemInfo(41875), new ItemInfo(41876), new ItemInfo(41877), new ItemInfo(41878), new ItemInfo(41879), new ItemInfo(41880), new ItemInfo(41881), new ItemInfo(41882), 
            new ItemInfo(41883), new ItemInfo(41884), new ItemInfo(41885), new ItemInfo(41886), new ItemInfo(41887), new ItemInfo(41888), new ItemInfo(41889), new ItemInfo(41890), 
            new ItemInfo(41891), new ItemInfo(41892), new ItemInfo(41893), new ItemInfo(41894), new ItemInfo(41895), new ItemInfo(41896), new ItemInfo(41897), new ItemInfo(41898), 
            new ItemInfo(41899), new ItemInfo(41900), new ItemInfo(41901), new ItemInfo(41902), new ItemInfo(41903), new ItemInfo(41904), new ItemInfo(41905), new ItemInfo(41906), 
            new ItemInfo(41907), new ItemInfo(41908), new ItemInfo(41909), new ItemInfo(41910), new ItemInfo(41911), new ItemInfo(41912), new ItemInfo(41913), new ItemInfo(41914), 
            new ItemInfo(41915), new ItemInfo(41916), new ItemInfo(41917), new ItemInfo(41918), new ItemInfo(41919), new ItemInfo(41920), new ItemInfo(41921), new ItemInfo(41922), 
            new ItemInfo(41923), new ItemInfo(41924), new ItemInfo(41925), new ItemInfo(41926), new ItemInfo(41927), new ItemInfo(41928), new ItemInfo(41929), new ItemInfo(41930), 
            new ItemInfo(41931), new ItemInfo(41932), new ItemInfo(41933), new ItemInfo(41934), new ItemInfo(41935), new ItemInfo(41936), new ItemInfo(41937), new ItemInfo(41938)
			
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddPlantPt5Gump()
			: this(0)
		{ }

		public AddPlantPt5Gump(int page) 
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

			from.SendGump(new AddPlantPt5Gump(page));
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
