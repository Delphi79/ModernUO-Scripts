using Server.Network;

namespace Server.Gumps
{
	public class AddFloorPt7Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddFloorPt7", AccessLevel.GameMaster, new CommandEventHandler(AddFloorPt7_OnCommand));
		}

		[Usage("AddFloorPt7")]
		
		public static void AddFloorPt7_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddFloorPt7Gump>();
			e.Mobile.SendGump(new AddFloorPt7Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(20827), new ItemInfo(20828), new ItemInfo(20829), new ItemInfo(20830), new ItemInfo(20831), new ItemInfo(20832), new ItemInfo(20833), new ItemInfo(20834), 
            new ItemInfo(20835), new ItemInfo(20836), new ItemInfo(20837), new ItemInfo(20838), new ItemInfo(20839), new ItemInfo(20840), new ItemInfo(20841), new ItemInfo(20842), 
            new ItemInfo(20843), new ItemInfo(20844), new ItemInfo(20845), new ItemInfo(20846), new ItemInfo(20728), new ItemInfo(20729), new ItemInfo(20730), new ItemInfo(20731), 
            new ItemInfo(20732), new ItemInfo(20771), new ItemInfo(20772), new ItemInfo(20773), new ItemInfo(20774), new ItemInfo(20802), new ItemInfo(20803), new ItemInfo(20804), 
            new ItemInfo(20805), new ItemInfo(20806), new ItemInfo(20807), new ItemInfo(20808), new ItemInfo(20809), new ItemInfo(20852), new ItemInfo(20853), new ItemInfo(20854), 
            new ItemInfo(20855), new ItemInfo(20856), new ItemInfo(20857), new ItemInfo(20858), new ItemInfo(20859), new ItemInfo(20860), new ItemInfo(20861), new ItemInfo(20862), 
            new ItemInfo(20863), new ItemInfo(20864), new ItemInfo(20865), new ItemInfo(20866), new ItemInfo(20867), new ItemInfo(20871), new ItemInfo(20872), new ItemInfo(20873), 
            new ItemInfo(20874), new ItemInfo(20875), new ItemInfo(20876), new ItemInfo(20877), new ItemInfo(20878), new ItemInfo(20879), new ItemInfo(20880), new ItemInfo(20881), 
            new ItemInfo(20882), new ItemInfo(20883), new ItemInfo(20884), new ItemInfo(20885), new ItemInfo(20886), new ItemInfo(20887), new ItemInfo(20888), new ItemInfo(20890), 
            new ItemInfo(20891), new ItemInfo(20892), new ItemInfo(20893), new ItemInfo(20894), new ItemInfo(20895), new ItemInfo(20896), new ItemInfo(20897), new ItemInfo(20898), 
            new ItemInfo(20899), new ItemInfo(20900), new ItemInfo(20901), new ItemInfo(20902), new ItemInfo(20903), new ItemInfo(20904), new ItemInfo(20905), new ItemInfo(20906), 
            new ItemInfo(20907), new ItemInfo(20908), new ItemInfo(20909), new ItemInfo(20910), new ItemInfo(20911), new ItemInfo(20912), new ItemInfo(20913), new ItemInfo(20914), 
            new ItemInfo(20915), new ItemInfo(20916), new ItemInfo(20917), new ItemInfo(20918), new ItemInfo(20919), new ItemInfo(20920), new ItemInfo(20921), new ItemInfo(20922), 
            new ItemInfo(20923), new ItemInfo(20924), new ItemInfo(20925), new ItemInfo(20926), new ItemInfo(20927), new ItemInfo(20928), new ItemInfo(20929), new ItemInfo(20930), 
            new ItemInfo(20931), new ItemInfo(20932), new ItemInfo(20933), new ItemInfo(20934), new ItemInfo(20935), new ItemInfo(20936), new ItemInfo(20937), new ItemInfo(20938), 
            new ItemInfo(20939), new ItemInfo(20940), new ItemInfo(20941), new ItemInfo(20942), new ItemInfo(20943), new ItemInfo(20944), new ItemInfo(20945), new ItemInfo(20946), 
            new ItemInfo(20947), new ItemInfo(20948), new ItemInfo(20949), new ItemInfo(20950), new ItemInfo(20951), new ItemInfo(20952), new ItemInfo(20953), new ItemInfo(20954), 
            new ItemInfo(20955), new ItemInfo(20956), new ItemInfo(20957), new ItemInfo(20958), new ItemInfo(20959), new ItemInfo(20960), new ItemInfo(20961), new ItemInfo(20962), 
            new ItemInfo(20963), new ItemInfo(20964), new ItemInfo(20965), new ItemInfo(20966), new ItemInfo(20967), new ItemInfo(20968), new ItemInfo(20969), new ItemInfo(20970), 
            new ItemInfo(20971), new ItemInfo(20972), new ItemInfo(20973), new ItemInfo(20974), new ItemInfo(20975), new ItemInfo(20976), new ItemInfo(20977), new ItemInfo(20978), 
            new ItemInfo(20979), new ItemInfo(20980), new ItemInfo(20981), new ItemInfo(20982), new ItemInfo(20983), new ItemInfo(20984), new ItemInfo(20985), new ItemInfo(20986), 
            new ItemInfo(20987), new ItemInfo(20988), new ItemInfo(20989), new ItemInfo(20990), new ItemInfo(20991), new ItemInfo(20992), new ItemInfo(20993), new ItemInfo(20994)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddFloorPt7Gump()
			: this(0)
		{ }

		public AddFloorPt7Gump(int page) 
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

			from.SendGump(new AddFloorPt7Gump(page));
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
