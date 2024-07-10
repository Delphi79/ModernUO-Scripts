using Server.Network;

namespace Server.Gumps
{
	public class AddWallPt2Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddWallPt2", AccessLevel.GameMaster, new CommandEventHandler(AddWallPt2_OnCommand));
		}

		[Usage("AddWallPt2")]
		
		public static void AddWallPt2_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddWallPt2Gump>();
			e.Mobile.SendGump(new AddWallPt2Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Walls
            new ItemInfo(593), new ItemInfo(594), new ItemInfo(595), new ItemInfo(596), new ItemInfo(597), new ItemInfo(598), new ItemInfo(599), new ItemInfo(600), new ItemInfo(601), new ItemInfo(602), 
            new ItemInfo(603), new ItemInfo(631), new ItemInfo(632), new ItemInfo(633), new ItemInfo(634), new ItemInfo(635), new ItemInfo(636), new ItemInfo(641), new ItemInfo(642), new ItemInfo(657), 
            new ItemInfo(658), new ItemInfo(659), new ItemInfo(660), new ItemInfo(661), new ItemInfo(662), new ItemInfo(663), new ItemInfo(664), new ItemInfo(665), new ItemInfo(666), new ItemInfo(667), 
            new ItemInfo(668), new ItemInfo(669), new ItemInfo(670), new ItemInfo(671), new ItemInfo(672), new ItemInfo(673), new ItemInfo(674), new ItemInfo(675), new ItemInfo(676), new ItemInfo(677), 
            new ItemInfo(678), new ItemInfo(679), new ItemInfo(680), new ItemInfo(681), new ItemInfo(682), new ItemInfo(683), new ItemInfo(684), new ItemInfo(685), new ItemInfo(686), new ItemInfo(693), 
            new ItemInfo(694), new ItemInfo(695), new ItemInfo(696), new ItemInfo(697), new ItemInfo(698), new ItemInfo(699), new ItemInfo(700), new ItemInfo(701), new ItemInfo(702), new ItemInfo(703), 
            new ItemInfo(704), new ItemInfo(711), new ItemInfo(712), new ItemInfo(713), new ItemInfo(714), new ItemInfo(715), new ItemInfo(716), new ItemInfo(717), new ItemInfo(718), new ItemInfo(719), 
            new ItemInfo(720), new ItemInfo(721), new ItemInfo(722), new ItemInfo(723), new ItemInfo(724), new ItemInfo(725), new ItemInfo(726), new ItemInfo(727), new ItemInfo(728), new ItemInfo(729),
            new ItemInfo(734), new ItemInfo(735), new ItemInfo(736), new ItemInfo(737), new ItemInfo(738), new ItemInfo(739), new ItemInfo(740), new ItemInfo(741), new ItemInfo(742), new ItemInfo(743), 
            new ItemInfo(744), new ItemInfo(745), new ItemInfo(746), new ItemInfo(747), new ItemInfo(748), new ItemInfo(761), new ItemInfo(762), new ItemInfo(763), new ItemInfo(764), new ItemInfo(765), 
            new ItemInfo(766), new ItemInfo(767), new ItemInfo(768), new ItemInfo(872), new ItemInfo(873), new ItemInfo(874), new ItemInfo(875), new ItemInfo(876), new ItemInfo(877), new ItemInfo(878), 
            new ItemInfo(879), new ItemInfo(880), new ItemInfo(881), new ItemInfo(895), new ItemInfo(896), new ItemInfo(897), new ItemInfo(898), new ItemInfo(899), new ItemInfo(900), new ItemInfo(901), 
            new ItemInfo(902), new ItemInfo(903), new ItemInfo(904), new ItemInfo(905), new ItemInfo(906), new ItemInfo(907), new ItemInfo(908), new ItemInfo(909), new ItemInfo(910), new ItemInfo(911), 
            new ItemInfo(912), new ItemInfo(913), new ItemInfo(914), new ItemInfo(915), new ItemInfo(916), new ItemInfo(917), new ItemInfo(918), new ItemInfo(947), new ItemInfo(948), new ItemInfo(949), 
            new ItemInfo(950), new ItemInfo(951), new ItemInfo(952), new ItemInfo(953), new ItemInfo(954), new ItemInfo(955), new ItemInfo(956), new ItemInfo(957), new ItemInfo(958), new ItemInfo(959), 
            new ItemInfo(960), new ItemInfo(961), new ItemInfo(962), new ItemInfo(963), new ItemInfo(964), new ItemInfo(965), new ItemInfo(966), new ItemInfo(967), new ItemInfo(968), new ItemInfo(969), 
            new ItemInfo(970), new ItemInfo(971), new ItemInfo(972), new ItemInfo(973), new ItemInfo(974), new ItemInfo(975), new ItemInfo(976), new ItemInfo(977), new ItemInfo(978), new ItemInfo(979), 
            new ItemInfo(980), new ItemInfo(981), new ItemInfo(982), new ItemInfo(983), new ItemInfo(984), new ItemInfo(985), new ItemInfo(986), new ItemInfo(987), new ItemInfo(988), new ItemInfo(989), 
            new ItemInfo(990), new ItemInfo(991), new ItemInfo(992), new ItemInfo(993), new ItemInfo(994), new ItemInfo(8584), new ItemInfo(8585), new ItemInfo(8586), new ItemInfo(8587), new ItemInfo(8588), 
            new ItemInfo(8589), new ItemInfo(8590), new ItemInfo(8591), new ItemInfo(8592), new ItemInfo(8593), new ItemInfo(8594), new ItemInfo(8595), new ItemInfo(8596), new ItemInfo(8597), new ItemInfo(8598), 
            new ItemInfo(8599), new ItemInfo(8613), new ItemInfo(8614), new ItemInfo(8615), new ItemInfo(8616), new ItemInfo(8617), new ItemInfo(8618), new ItemInfo(8619), new ItemInfo(8620), new ItemInfo(8621), 
            new ItemInfo(8622), new ItemInfo(8623), new ItemInfo(8624), new ItemInfo(8625), new ItemInfo(8626), new ItemInfo(8627), new ItemInfo(8628), new ItemInfo(8629), new ItemInfo(8630), new ItemInfo(8631), 
            new ItemInfo(8632), new ItemInfo(8637), new ItemInfo(8638), new ItemInfo(8639), new ItemInfo(8640), new ItemInfo(8641), new ItemInfo(8642), new ItemInfo(8643), new ItemInfo(8644), new ItemInfo(8645), 
            new ItemInfo(8646), new ItemInfo(8647), new ItemInfo(8648), new ItemInfo(8649), new ItemInfo(8650), new ItemInfo(8651), new ItemInfo(8652), new ItemInfo(8653), new ItemInfo(8654), new ItemInfo(8655), 
            new ItemInfo(8656), new ItemInfo(8657), new ItemInfo(8658), new ItemInfo(8659), new ItemInfo(8660), new ItemInfo(8661), new ItemInfo(8662), new ItemInfo(8663), new ItemInfo(8664), new ItemInfo(8665), 
            new ItemInfo(8666), new ItemInfo(8667), new ItemInfo(8668), new ItemInfo(8669), new ItemInfo(8670), new ItemInfo(8671), new ItemInfo(8672), new ItemInfo(8673), new ItemInfo(8674), new ItemInfo(8675), 
            new ItemInfo(8676), new ItemInfo(8677), new ItemInfo(8678), new ItemInfo(8679), new ItemInfo(8680)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddWallPt2Gump()
			: this(0)
		{ }

		public AddWallPt2Gump(int page) 
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

			from.SendGump(new AddWallPt2Gump(page));
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
