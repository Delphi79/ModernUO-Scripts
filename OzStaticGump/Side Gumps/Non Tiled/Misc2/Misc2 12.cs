using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt12Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt12", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt12_OnCommand));
		}

		[Usage("AddMisc2Pt12")]
		
		public static void AddMisc2Pt12_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt12Gump>();
			e.Mobile.SendGump(new AddMisc2Pt12Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(14453), new ItemInfo(14454), new ItemInfo(14455), new ItemInfo(14456), new ItemInfo(14457), new ItemInfo(14458), new ItemInfo(14459), new ItemInfo(14460), new ItemInfo(14461), 
            new ItemInfo(14462), new ItemInfo(14463), new ItemInfo(14464), new ItemInfo(14465), new ItemInfo(14466), new ItemInfo(14467), new ItemInfo(14468), new ItemInfo(14469), new ItemInfo(14470), 
            new ItemInfo(14471), new ItemInfo(14472), new ItemInfo(14473), new ItemInfo(14474), new ItemInfo(14475), new ItemInfo(14476), new ItemInfo(14477), new ItemInfo(14478), new ItemInfo(14479), 
            new ItemInfo(14480), new ItemInfo(14481), new ItemInfo(14482), new ItemInfo(14483), new ItemInfo(14484), new ItemInfo(14485), new ItemInfo(14486), new ItemInfo(14487), new ItemInfo(14488), 
            new ItemInfo(14489), new ItemInfo(14490), new ItemInfo(14491), new ItemInfo(14492), new ItemInfo(14493), new ItemInfo(14494), new ItemInfo(14495), new ItemInfo(14496), new ItemInfo(14497), 
            new ItemInfo(14498), new ItemInfo(14499), new ItemInfo(14500), new ItemInfo(14501), new ItemInfo(14502), new ItemInfo(14503), new ItemInfo(14504), new ItemInfo(14505), new ItemInfo(14506), 
            new ItemInfo(14507), new ItemInfo(14508), new ItemInfo(14509), new ItemInfo(14510), new ItemInfo(14511), new ItemInfo(14512), new ItemInfo(14513), new ItemInfo(14514), new ItemInfo(14515), 
            new ItemInfo(14516), new ItemInfo(14517), new ItemInfo(14518), new ItemInfo(14519), new ItemInfo(14520), new ItemInfo(14521), new ItemInfo(14522), new ItemInfo(14523), new ItemInfo(14524), 
            new ItemInfo(14525), new ItemInfo(14526), new ItemInfo(14527), new ItemInfo(14528), new ItemInfo(14529), new ItemInfo(14530), new ItemInfo(14531), new ItemInfo(14532), new ItemInfo(14533), 
            new ItemInfo(14534), new ItemInfo(14535), new ItemInfo(14536), new ItemInfo(14537), new ItemInfo(14538), new ItemInfo(14539), new ItemInfo(14540), new ItemInfo(14541), new ItemInfo(14542), 
            new ItemInfo(14543), new ItemInfo(14544), new ItemInfo(14545), new ItemInfo(14546), new ItemInfo(14547), new ItemInfo(14548), new ItemInfo(14549), new ItemInfo(14550), new ItemInfo(14551), 
            new ItemInfo(14552), new ItemInfo(14553), new ItemInfo(14554), new ItemInfo(14555), new ItemInfo(14556), new ItemInfo(14557), new ItemInfo(14558), new ItemInfo(14559), new ItemInfo(14560), 
            new ItemInfo(14561), new ItemInfo(14562), new ItemInfo(14563), new ItemInfo(14564), new ItemInfo(14565), new ItemInfo(14566), new ItemInfo(14567), new ItemInfo(14568), new ItemInfo(14569), 
            new ItemInfo(14570), new ItemInfo(14571), new ItemInfo(14572), new ItemInfo(14573), new ItemInfo(14574), new ItemInfo(14575), new ItemInfo(14576), new ItemInfo(14577), new ItemInfo(14578), 
            new ItemInfo(14579), new ItemInfo(14580), new ItemInfo(14581), new ItemInfo(14582), new ItemInfo(14583), new ItemInfo(14584), new ItemInfo(14585), new ItemInfo(14586), new ItemInfo(14587), 
            new ItemInfo(14588), new ItemInfo(14589), new ItemInfo(14590), new ItemInfo(14591), new ItemInfo(14592), new ItemInfo(14593), new ItemInfo(14594), new ItemInfo(14595), new ItemInfo(14596), 
            new ItemInfo(14597), new ItemInfo(14598), new ItemInfo(14599), new ItemInfo(14600), new ItemInfo(14601), new ItemInfo(14602), new ItemInfo(14603), new ItemInfo(14604), new ItemInfo(14605), 
            new ItemInfo(14606), new ItemInfo(14607), new ItemInfo(14608), new ItemInfo(14609), new ItemInfo(14610), new ItemInfo(14611), new ItemInfo(14612), new ItemInfo(14613), new ItemInfo(14614), 
            new ItemInfo(14615), new ItemInfo(14616), new ItemInfo(14617), new ItemInfo(14618), new ItemInfo(14619), new ItemInfo(14620), new ItemInfo(14621), new ItemInfo(14622), new ItemInfo(14623), 
            new ItemInfo(14624), new ItemInfo(14625), new ItemInfo(14626), new ItemInfo(14627), new ItemInfo(14628), new ItemInfo(14629), new ItemInfo(14630), new ItemInfo(14631), new ItemInfo(14632), 
            new ItemInfo(14633), new ItemInfo(14634), new ItemInfo(14635), new ItemInfo(14636), new ItemInfo(14637), new ItemInfo(14638), new ItemInfo(14639), new ItemInfo(14640), new ItemInfo(14641), 
            new ItemInfo(14642), new ItemInfo(14643), new ItemInfo(14644), new ItemInfo(14645), new ItemInfo(14646), new ItemInfo(14647), new ItemInfo(14648), new ItemInfo(14649), new ItemInfo(14650), 
            new ItemInfo(14651), new ItemInfo(14652), new ItemInfo(14653), new ItemInfo(14654), new ItemInfo(14655), new ItemInfo(14656), new ItemInfo(14657), new ItemInfo(14658), new ItemInfo(14659), 
            new ItemInfo(14660), new ItemInfo(14661), new ItemInfo(14662), new ItemInfo(14663), new ItemInfo(14664), new ItemInfo(14665), new ItemInfo(14666), new ItemInfo(14667), new ItemInfo(14668), 
            new ItemInfo(14669), new ItemInfo(14670), new ItemInfo(14671), new ItemInfo(14672), new ItemInfo(14673), new ItemInfo(14674), new ItemInfo(14675), new ItemInfo(14676), new ItemInfo(14677), 
            new ItemInfo(14678), new ItemInfo(14679), new ItemInfo(14680), new ItemInfo(14681), new ItemInfo(14682), new ItemInfo(14683), new ItemInfo(14684), new ItemInfo(14685), new ItemInfo(14686), 
            new ItemInfo(14687), new ItemInfo(14688), new ItemInfo(14689), new ItemInfo(14690), new ItemInfo(14691), new ItemInfo(14692), new ItemInfo(14693), new ItemInfo(14694), new ItemInfo(14695), 
            new ItemInfo(14696), new ItemInfo(14697), new ItemInfo(14698), new ItemInfo(14699), new ItemInfo(14700), new ItemInfo(14701), new ItemInfo(14702), new ItemInfo(14703), new ItemInfo(14704), 
            new ItemInfo(14705), new ItemInfo(14706), new ItemInfo(14707), new ItemInfo(14708), new ItemInfo(14709), new ItemInfo(14710), new ItemInfo(14711), new ItemInfo(14712), new ItemInfo(14713), 
            new ItemInfo(14714), new ItemInfo(14715), new ItemInfo(14716), new ItemInfo(14717), new ItemInfo(14718), new ItemInfo(14719), new ItemInfo(14720), new ItemInfo(14721), new ItemInfo(14722), 
            new ItemInfo(14723), new ItemInfo(14724), new ItemInfo(14725), new ItemInfo(14726), new ItemInfo(14727), new ItemInfo(14728), new ItemInfo(14729), new ItemInfo(14730), new ItemInfo(14731), 
            new ItemInfo(14732), new ItemInfo(14733), new ItemInfo(14734), new ItemInfo(14735), new ItemInfo(14736), new ItemInfo(14737), new ItemInfo(14738), new ItemInfo(14739), new ItemInfo(14740), 
            new ItemInfo(14741), new ItemInfo(14742), new ItemInfo(14743), new ItemInfo(14744), new ItemInfo(14745), new ItemInfo(14746), new ItemInfo(14747), new ItemInfo(14748), new ItemInfo(14749), 
            new ItemInfo(14750), new ItemInfo(14751), new ItemInfo(14752), new ItemInfo(14753), new ItemInfo(14754), new ItemInfo(14768), new ItemInfo(14781), new ItemInfo(14782), new ItemInfo(14783), 
            new ItemInfo(14784), new ItemInfo(14785), new ItemInfo(14786), new ItemInfo(14855), new ItemInfo(14856), new ItemInfo(14933), new ItemInfo(14934), new ItemInfo(14935), new ItemInfo(14936), 
            new ItemInfo(14937), new ItemInfo(14938), new ItemInfo(14939), new ItemInfo(14940), new ItemInfo(14941), new ItemInfo(14942), new ItemInfo(14943), new ItemInfo(14944), new ItemInfo(14945), 
            new ItemInfo(14946), new ItemInfo(14947), new ItemInfo(14948), new ItemInfo(14949), new ItemInfo(14950), new ItemInfo(14951), new ItemInfo(14952), new ItemInfo(14953), new ItemInfo(14954), 
            new ItemInfo(14955), new ItemInfo(14956), new ItemInfo(14957), new ItemInfo(14958), new ItemInfo(14959), new ItemInfo(14960), new ItemInfo(14961), new ItemInfo(14962), new ItemInfo(14963), 
            new ItemInfo(14964), new ItemInfo(14965), new ItemInfo(14966), new ItemInfo(14967), new ItemInfo(14968), new ItemInfo(14969), new ItemInfo(14970), new ItemInfo(14971), new ItemInfo(14972), 
            new ItemInfo(14973), new ItemInfo(14974), new ItemInfo(14975), new ItemInfo(14976), new ItemInfo(14977), new ItemInfo(14978), new ItemInfo(14979), new ItemInfo(14980), new ItemInfo(14981)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt12Gump()
			: this(0)
		{ }

		public AddMisc2Pt12Gump(int page) 
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

			from.SendGump(new AddMisc2Pt12Gump(page));
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
