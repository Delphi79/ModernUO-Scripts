using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt8Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt8", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt8_OnCommand));
		}

		[Usage("AddMisc2Pt8")]
		
		public static void AddMisc2Pt8_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt8Gump>();
			e.Mobile.SendGump(new AddMisc2Pt8Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(10898), new ItemInfo(10899), new ItemInfo(10900), new ItemInfo(10901), new ItemInfo(10902), new ItemInfo(10903), new ItemInfo(10904), new ItemInfo(10905), new ItemInfo(10906), 
            new ItemInfo(10907), new ItemInfo(10908), new ItemInfo(10909), new ItemInfo(10910), new ItemInfo(10911), new ItemInfo(10912), new ItemInfo(10913), new ItemInfo(10914), new ItemInfo(10915), 
            new ItemInfo(10916), new ItemInfo(10917), new ItemInfo(10918), new ItemInfo(10919), new ItemInfo(10920), new ItemInfo(10921), new ItemInfo(10922), new ItemInfo(10923), new ItemInfo(10924), 
            new ItemInfo(10925), new ItemInfo(10926), new ItemInfo(10927), new ItemInfo(10928), new ItemInfo(10929), new ItemInfo(10930), new ItemInfo(10931), new ItemInfo(10932), new ItemInfo(10933), 
            new ItemInfo(10934), new ItemInfo(10935), new ItemInfo(10936), new ItemInfo(10937), new ItemInfo(10938), new ItemInfo(10939), new ItemInfo(10940), new ItemInfo(10941), new ItemInfo(10942), 
            new ItemInfo(10943), new ItemInfo(10944), new ItemInfo(10945), new ItemInfo(10946), new ItemInfo(10947), new ItemInfo(10948), new ItemInfo(10949), new ItemInfo(10950), new ItemInfo(10951), 
            new ItemInfo(10952), new ItemInfo(10953), new ItemInfo(10954), new ItemInfo(10955), new ItemInfo(10956), new ItemInfo(10957), new ItemInfo(10958), new ItemInfo(10959), new ItemInfo(10960), 
            new ItemInfo(10961), new ItemInfo(10962), new ItemInfo(10963), new ItemInfo(10964), new ItemInfo(10965), new ItemInfo(10966), new ItemInfo(10967), new ItemInfo(10968), new ItemInfo(10969), 
            new ItemInfo(10970), new ItemInfo(10971), new ItemInfo(10972), new ItemInfo(10973), new ItemInfo(10974), new ItemInfo(10975), new ItemInfo(10976), new ItemInfo(10977), new ItemInfo(10978), 
            new ItemInfo(10979), new ItemInfo(10980), new ItemInfo(10981), new ItemInfo(10982), new ItemInfo(10983), new ItemInfo(10984), new ItemInfo(10985), new ItemInfo(10986), new ItemInfo(10987), 
            new ItemInfo(10988), new ItemInfo(10989), new ItemInfo(10990), new ItemInfo(10991), new ItemInfo(10992), new ItemInfo(10993), new ItemInfo(10994), new ItemInfo(10995), new ItemInfo(10996), 
            new ItemInfo(10997), new ItemInfo(10998), new ItemInfo(10999), new ItemInfo(11000), new ItemInfo(11001), new ItemInfo(11002), new ItemInfo(11003), new ItemInfo(11004), new ItemInfo(11005), 
            new ItemInfo(11006), new ItemInfo(11007), new ItemInfo(11008), new ItemInfo(11028), new ItemInfo(11110), new ItemInfo(11130), new ItemInfo(11131), new ItemInfo(11132), new ItemInfo(11133), 
            new ItemInfo(11134), new ItemInfo(11135), new ItemInfo(11136), new ItemInfo(11216), new ItemInfo(11225), new ItemInfo(11226), new ItemInfo(11227), new ItemInfo(11228), new ItemInfo(11229), 
            new ItemInfo(11230), new ItemInfo(11231), new ItemInfo(11232), new ItemInfo(11233), new ItemInfo(11234), new ItemInfo(11235), new ItemInfo(11236), new ItemInfo(11237), new ItemInfo(11238), 
            new ItemInfo(11239), new ItemInfo(11240), new ItemInfo(11517), new ItemInfo(11518), new ItemInfo(11519), new ItemInfo(11520), new ItemInfo(11521), new ItemInfo(11522), new ItemInfo(11523), 
            new ItemInfo(11524), new ItemInfo(11533), new ItemInfo(11534), new ItemInfo(11535), new ItemInfo(11536), new ItemInfo(11537), new ItemInfo(11538), new ItemInfo(11539), new ItemInfo(11540), 
            new ItemInfo(11541), new ItemInfo(11542), new ItemInfo(11543), new ItemInfo(11574), new ItemInfo(11575), new ItemInfo(11590), new ItemInfo(11591), new ItemInfo(11592), new ItemInfo(11593), 
            new ItemInfo(11594), new ItemInfo(11595), new ItemInfo(11596), new ItemInfo(11597), new ItemInfo(11598), new ItemInfo(11599), new ItemInfo(11600), new ItemInfo(11601), new ItemInfo(11602), 
            new ItemInfo(11603), new ItemInfo(11604), new ItemInfo(11605), new ItemInfo(11606), new ItemInfo(11607), new ItemInfo(11608), new ItemInfo(11609), new ItemInfo(11610), new ItemInfo(11611), 
            new ItemInfo(11612), new ItemInfo(11613), new ItemInfo(11614), new ItemInfo(11615), new ItemInfo(11616), new ItemInfo(11617), new ItemInfo(11618), new ItemInfo(11619), new ItemInfo(11620), 
            new ItemInfo(11621), new ItemInfo(11622), new ItemInfo(11623), new ItemInfo(11624), new ItemInfo(11625), new ItemInfo(11626), new ItemInfo(11627), new ItemInfo(11628), new ItemInfo(11629), 
            new ItemInfo(11630), new ItemInfo(11631), new ItemInfo(11632), new ItemInfo(11633), new ItemInfo(11634), new ItemInfo(11635), new ItemInfo(11636), new ItemInfo(11637), new ItemInfo(11638), 
            new ItemInfo(11639), new ItemInfo(11640), new ItemInfo(11641), new ItemInfo(11642), new ItemInfo(11643), new ItemInfo(11644), new ItemInfo(11645), new ItemInfo(11646), new ItemInfo(11647), 
            new ItemInfo(11648), new ItemInfo(11649), new ItemInfo(11650), new ItemInfo(11651), new ItemInfo(11652), new ItemInfo(11653), new ItemInfo(11654), new ItemInfo(11655), new ItemInfo(11656), 
            new ItemInfo(11657), new ItemInfo(11658), new ItemInfo(11659), new ItemInfo(11660), new ItemInfo(11661), new ItemInfo(11662), new ItemInfo(11663), new ItemInfo(11664), new ItemInfo(11665), 
            new ItemInfo(11666), new ItemInfo(11667), new ItemInfo(11668), new ItemInfo(11669), new ItemInfo(11670), new ItemInfo(11671), new ItemInfo(11672), new ItemInfo(11673), new ItemInfo(11674), 
            new ItemInfo(11675), new ItemInfo(11676), new ItemInfo(11677), new ItemInfo(11678), new ItemInfo(11679), new ItemInfo(11680), new ItemInfo(11681), new ItemInfo(11682), new ItemInfo(11683), 
            new ItemInfo(11684), new ItemInfo(11685), new ItemInfo(11686), new ItemInfo(11687), new ItemInfo(11688), new ItemInfo(11689), new ItemInfo(11690), new ItemInfo(11691), new ItemInfo(11692), 
            new ItemInfo(11693), new ItemInfo(11694), new ItemInfo(11695), new ItemInfo(11696), new ItemInfo(11697), new ItemInfo(11698), new ItemInfo(11699), new ItemInfo(11700), new ItemInfo(11701), 
            new ItemInfo(11702), new ItemInfo(11703), new ItemInfo(11704), new ItemInfo(11705), new ItemInfo(11706), new ItemInfo(11707), new ItemInfo(11708), new ItemInfo(11709), new ItemInfo(11710), 
            new ItemInfo(11730), new ItemInfo(11731), new ItemInfo(11732), new ItemInfo(11733), new ItemInfo(11734), new ItemInfo(11735), new ItemInfo(11736), new ItemInfo(11737), new ItemInfo(11738), 
            new ItemInfo(11739), new ItemInfo(11740), new ItemInfo(11741), new ItemInfo(11742), new ItemInfo(11777), new ItemInfo(11836), new ItemInfo(11837), new ItemInfo(11838), new ItemInfo(11839), 
            new ItemInfo(12047), new ItemInfo(12048), new ItemInfo(12049), new ItemInfo(12050), new ItemInfo(12051), new ItemInfo(12052), new ItemInfo(12053), new ItemInfo(12054), new ItemInfo(12055), 
            new ItemInfo(12056), new ItemInfo(12057), new ItemInfo(12058), new ItemInfo(12073), new ItemInfo(12074), new ItemInfo(12075), new ItemInfo(12076), new ItemInfo(12077), new ItemInfo(12078)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt8Gump()
			: this(0)
		{ }

		public AddMisc2Pt8Gump(int page) 
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

			from.SendGump(new AddMisc2Pt8Gump(page));
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
