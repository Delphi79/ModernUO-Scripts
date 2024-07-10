using Server.Network;

namespace Server.Gumps
{
	public class AddGroundStPt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddGroundStPt4", AccessLevel.GameMaster, new CommandEventHandler(AddGroundStPt4_OnCommand));
		}

		[Usage("AddGroundStPt4")]
		
		public static void AddGroundStPt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddGroundStPt4Gump>();
			e.Mobile.SendGump(new AddGroundStPt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region GroundSts
            new ItemInfo(12542), new ItemInfo(12543), new ItemInfo(12544), new ItemInfo(12545), new ItemInfo(12546), new ItemInfo(12547), new ItemInfo(12548), new ItemInfo(12549), 
            new ItemInfo(12550), new ItemInfo(12551), new ItemInfo(12552), new ItemInfo(12553), new ItemInfo(12554), new ItemInfo(12788), new ItemInfo(12789), new ItemInfo(12790), 
            new ItemInfo(12791), new ItemInfo(12792), new ItemInfo(12793), new ItemInfo(12794), new ItemInfo(12795), new ItemInfo(12809), new ItemInfo(12810), new ItemInfo(12813), 
            new ItemInfo(12814), new ItemInfo(12815), new ItemInfo(12816), new ItemInfo(12817), new ItemInfo(12819), new ItemInfo(12820), new ItemInfo(12821), new ItemInfo(12822), 
            new ItemInfo(12823), new ItemInfo(12824), new ItemInfo(12826), new ItemInfo(12827), new ItemInfo(12828), new ItemInfo(12829), new ItemInfo(12830), new ItemInfo(12832), 
            new ItemInfo(12833), new ItemInfo(12834), new ItemInfo(12835), new ItemInfo(12836), new ItemInfo(12838), new ItemInfo(12839), new ItemInfo(12840), new ItemInfo(12841), 
            new ItemInfo(12842), new ItemInfo(12844), new ItemInfo(12845), new ItemInfo(12846), new ItemInfo(12847), new ItemInfo(12848), new ItemInfo(12849), new ItemInfo(12850), 
            new ItemInfo(12851), new ItemInfo(12852), new ItemInfo(12854), new ItemInfo(12855), new ItemInfo(12856), new ItemInfo(12857), new ItemInfo(12858), new ItemInfo(12859), 
            new ItemInfo(12860), new ItemInfo(12861), new ItemInfo(12862), new ItemInfo(12863), new ItemInfo(12865), new ItemInfo(12866), new ItemInfo(12867), new ItemInfo(12868), 
            new ItemInfo(12869), new ItemInfo(12870), new ItemInfo(12871), new ItemInfo(12872), new ItemInfo(12873), new ItemInfo(12874), new ItemInfo(12875), new ItemInfo(12876), 
            new ItemInfo(12877), new ItemInfo(12878), new ItemInfo(12879), new ItemInfo(12880), new ItemInfo(12881), new ItemInfo(12882), new ItemInfo(12883), new ItemInfo(12884), 
            new ItemInfo(12885), new ItemInfo(12886), new ItemInfo(12887), new ItemInfo(12888), new ItemInfo(12889), new ItemInfo(12890), new ItemInfo(12891), new ItemInfo(12892), 
            new ItemInfo(12893), new ItemInfo(12894), new ItemInfo(12895), new ItemInfo(12896), new ItemInfo(12897), new ItemInfo(12898), new ItemInfo(12899), new ItemInfo(12900), 
            new ItemInfo(12901), new ItemInfo(12902), new ItemInfo(12903), new ItemInfo(12904), new ItemInfo(12905), new ItemInfo(12906), new ItemInfo(12907), new ItemInfo(12908), 
            new ItemInfo(12909), new ItemInfo(12910), new ItemInfo(12911), new ItemInfo(12912), new ItemInfo(12913), new ItemInfo(12914), new ItemInfo(12915), new ItemInfo(12916), 
            new ItemInfo(12917), new ItemInfo(12918), new ItemInfo(12919), new ItemInfo(12920), new ItemInfo(12921), new ItemInfo(12922), new ItemInfo(12923), new ItemInfo(12924), 
            new ItemInfo(12925), new ItemInfo(12926), new ItemInfo(12927), new ItemInfo(12928), new ItemInfo(12929), new ItemInfo(12930), new ItemInfo(12931), new ItemInfo(12932), 
            new ItemInfo(12933), new ItemInfo(12934), new ItemInfo(12935), new ItemInfo(12936), new ItemInfo(12937), new ItemInfo(12938), new ItemInfo(12939), new ItemInfo(12940), 
            new ItemInfo(12941), new ItemInfo(12942), new ItemInfo(12943), new ItemInfo(12944), new ItemInfo(12945), new ItemInfo(12946), new ItemInfo(12947), new ItemInfo(12948), 
            new ItemInfo(12949), new ItemInfo(12950), new ItemInfo(12951), new ItemInfo(12952), new ItemInfo(12953), new ItemInfo(12954), new ItemInfo(12955), new ItemInfo(12956), 
            new ItemInfo(12957), new ItemInfo(12958), new ItemInfo(12959), new ItemInfo(12960), new ItemInfo(12961), new ItemInfo(12962), new ItemInfo(12963), new ItemInfo(12964), 
            new ItemInfo(12965), new ItemInfo(12966), new ItemInfo(12967), new ItemInfo(12968), new ItemInfo(12969), new ItemInfo(12970), new ItemInfo(12971), new ItemInfo(12972), 
            new ItemInfo(12973), new ItemInfo(12974), new ItemInfo(12975), new ItemInfo(12976), new ItemInfo(12977), new ItemInfo(13001), new ItemInfo(13002), new ItemInfo(13371)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddGroundStPt4Gump()
			: this(0)
		{ }

		public AddGroundStPt4Gump(int page) 
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

			from.SendGump(new AddGroundStPt4Gump(page));
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
