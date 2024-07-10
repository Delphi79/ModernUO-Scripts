using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt13Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt13", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt13_OnCommand));
		}

		[Usage("AddMisc2Pt13")]
		
		public static void AddMisc2Pt13_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt13Gump>();
			e.Mobile.SendGump(new AddMisc2Pt13Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(14982), new ItemInfo(14983), new ItemInfo(14984), new ItemInfo(14985), new ItemInfo(14986), new ItemInfo(14987), new ItemInfo(14988), new ItemInfo(14989), new ItemInfo(14990), 
            new ItemInfo(14991), new ItemInfo(14992), new ItemInfo(14993), new ItemInfo(14994), new ItemInfo(14995), new ItemInfo(14996), new ItemInfo(14997), new ItemInfo(14998), new ItemInfo(14999), 
            new ItemInfo(15000), new ItemInfo(15001), new ItemInfo(15002), new ItemInfo(15003), new ItemInfo(15097), new ItemInfo(15098), new ItemInfo(15099), new ItemInfo(15100), new ItemInfo(15101), 
            new ItemInfo(15102), new ItemInfo(15103), new ItemInfo(15104), new ItemInfo(15105), new ItemInfo(15106), new ItemInfo(15107), new ItemInfo(15108), new ItemInfo(15109), new ItemInfo(15110), 
            new ItemInfo(15111), new ItemInfo(15112), new ItemInfo(15113), new ItemInfo(15114), new ItemInfo(15115), new ItemInfo(15116), new ItemInfo(15117), new ItemInfo(15118), new ItemInfo(15119), 
            new ItemInfo(15120), new ItemInfo(15121), new ItemInfo(15122), new ItemInfo(15123), new ItemInfo(15124), new ItemInfo(15125), new ItemInfo(15160), new ItemInfo(15161), new ItemInfo(15162), 
            new ItemInfo(15163), new ItemInfo(15164), new ItemInfo(15165), new ItemInfo(15166), new ItemInfo(15167), new ItemInfo(15168), new ItemInfo(15169), new ItemInfo(15170), new ItemInfo(15171),
            new ItemInfo(15283), new ItemInfo(15284), new ItemInfo(15285), new ItemInfo(15286), new ItemInfo(15287), new ItemInfo(15288), new ItemInfo(15289), new ItemInfo(15290), new ItemInfo(15291), 
            new ItemInfo(15292), new ItemInfo(15634), new ItemInfo(15639), new ItemInfo(15640), new ItemInfo(15716), new ItemInfo(15717), new ItemInfo(15718), new ItemInfo(15719), new ItemInfo(15720), 
            new ItemInfo(15721), new ItemInfo(15722), new ItemInfo(15723), new ItemInfo(15748), new ItemInfo(15750), new ItemInfo(15751), new ItemInfo(15772), new ItemInfo(15773), new ItemInfo(15774), 
            new ItemInfo(15775), new ItemInfo(15776), new ItemInfo(15777), new ItemInfo(15778), new ItemInfo(15779), new ItemInfo(15780), new ItemInfo(15781), new ItemInfo(15782), new ItemInfo(15783), 
            new ItemInfo(15784), new ItemInfo(15785), new ItemInfo(15786), new ItemInfo(15787), new ItemInfo(15788), new ItemInfo(15789), new ItemInfo(15790), new ItemInfo(15791), new ItemInfo(15792), 
            new ItemInfo(15793), new ItemInfo(15794), new ItemInfo(15795), new ItemInfo(15796), new ItemInfo(15797), new ItemInfo(15798), new ItemInfo(15799), new ItemInfo(15800), new ItemInfo(15801), 
            new ItemInfo(15802), new ItemInfo(15803), new ItemInfo(15871), new ItemInfo(15872), new ItemInfo(15874), new ItemInfo(15875), new ItemInfo(15876), new ItemInfo(15877), new ItemInfo(15878), 
            new ItemInfo(15879), new ItemInfo(15880), new ItemInfo(15881), new ItemInfo(15882), new ItemInfo(15883), new ItemInfo(15911), new ItemInfo(15912), new ItemInfo(15913), new ItemInfo(15914), 
            new ItemInfo(15915), new ItemInfo(15916), new ItemInfo(15917), new ItemInfo(15918), new ItemInfo(15919), new ItemInfo(15920), new ItemInfo(15921), new ItemInfo(15922), new ItemInfo(15923), 
            new ItemInfo(15924), new ItemInfo(15925), new ItemInfo(15926), new ItemInfo(15927), new ItemInfo(15928), new ItemInfo(15929), new ItemInfo(15930), new ItemInfo(15935), new ItemInfo(15936), 
            new ItemInfo(15937), new ItemInfo(15938), new ItemInfo(15939), new ItemInfo(15940), new ItemInfo(15941), new ItemInfo(15942), new ItemInfo(15943), new ItemInfo(15944), new ItemInfo(15945), 
            new ItemInfo(15946), new ItemInfo(15947), new ItemInfo(15948), new ItemInfo(15949), new ItemInfo(15950), new ItemInfo(15951), new ItemInfo(15952), new ItemInfo(15953), new ItemInfo(15954), 
            new ItemInfo(15955), new ItemInfo(15956), new ItemInfo(15957), new ItemInfo(15958), new ItemInfo(15959), new ItemInfo(15960), new ItemInfo(15961), new ItemInfo(15962), new ItemInfo(15963), 
            new ItemInfo(15964), new ItemInfo(15965), new ItemInfo(15966), new ItemInfo(15967), new ItemInfo(15968), new ItemInfo(15969), new ItemInfo(15970), new ItemInfo(15971), new ItemInfo(15972), 
            new ItemInfo(15973), new ItemInfo(15974), new ItemInfo(15975), new ItemInfo(15976), new ItemInfo(15977), new ItemInfo(15978), new ItemInfo(15979), new ItemInfo(15980), new ItemInfo(15981), 
            new ItemInfo(15982), new ItemInfo(15983), new ItemInfo(15984), new ItemInfo(15985), new ItemInfo(15986), new ItemInfo(15987), new ItemInfo(15988), new ItemInfo(15989), new ItemInfo(15990), 
            new ItemInfo(15991), new ItemInfo(15992), new ItemInfo(15993), new ItemInfo(15994), new ItemInfo(15995), new ItemInfo(15996), new ItemInfo(15997), new ItemInfo(15998), new ItemInfo(15999), 
            new ItemInfo(16000), new ItemInfo(16001), new ItemInfo(16002), new ItemInfo(16003), new ItemInfo(16004), new ItemInfo(16005), new ItemInfo(16006), new ItemInfo(16007), new ItemInfo(16008), 
            new ItemInfo(16009), new ItemInfo(16010), new ItemInfo(16011), new ItemInfo(16012), new ItemInfo(16013), new ItemInfo(16014), new ItemInfo(16015), new ItemInfo(16016), new ItemInfo(16017), 
            new ItemInfo(16018), new ItemInfo(16019), new ItemInfo(16020), new ItemInfo(16021), new ItemInfo(16022), new ItemInfo(16023), new ItemInfo(16024), new ItemInfo(16025), new ItemInfo(16026), 
            new ItemInfo(16027), new ItemInfo(16028), new ItemInfo(16029), new ItemInfo(16030), new ItemInfo(16031), new ItemInfo(16032), new ItemInfo(16033), new ItemInfo(16034), new ItemInfo(16035), 
            new ItemInfo(16036), new ItemInfo(16037), new ItemInfo(16038), new ItemInfo(16039), new ItemInfo(16040), new ItemInfo(16041), new ItemInfo(16042), new ItemInfo(16043), new ItemInfo(16044), 
            new ItemInfo(16045), new ItemInfo(16046), new ItemInfo(16047), new ItemInfo(16048), new ItemInfo(16049), new ItemInfo(16050), new ItemInfo(16051), new ItemInfo(16052), new ItemInfo(16053), 
            new ItemInfo(16054), new ItemInfo(16055), new ItemInfo(16056), new ItemInfo(16057), new ItemInfo(16058), new ItemInfo(16059), new ItemInfo(16060), new ItemInfo(16061), new ItemInfo(16062), 
            new ItemInfo(16063), new ItemInfo(16064), new ItemInfo(16065), new ItemInfo(16066), new ItemInfo(16067), new ItemInfo(16068), new ItemInfo(16069), new ItemInfo(16070), new ItemInfo(16071), 
            new ItemInfo(16072), new ItemInfo(16073), new ItemInfo(16074), new ItemInfo(16075), new ItemInfo(16076), new ItemInfo(16077), new ItemInfo(16078), new ItemInfo(16079), new ItemInfo(16080), 
            new ItemInfo(16081), new ItemInfo(16082), new ItemInfo(16083), new ItemInfo(16084), new ItemInfo(16085), new ItemInfo(16086), new ItemInfo(16087), new ItemInfo(16088), new ItemInfo(16089), 
            new ItemInfo(16090), new ItemInfo(16091), new ItemInfo(16092), new ItemInfo(16093), new ItemInfo(16094), new ItemInfo(16095), new ItemInfo(16096), new ItemInfo(16097), new ItemInfo(16098), 
            new ItemInfo(16099), new ItemInfo(16100), new ItemInfo(16101), new ItemInfo(16102), new ItemInfo(16103), new ItemInfo(16104), new ItemInfo(16105), new ItemInfo(16106), new ItemInfo(16107), 
            new ItemInfo(16108), new ItemInfo(16109), new ItemInfo(16110), new ItemInfo(16111), new ItemInfo(16112), new ItemInfo(16113), new ItemInfo(16114), new ItemInfo(16115), new ItemInfo(16116), 
            new ItemInfo(16117), new ItemInfo(16118), new ItemInfo(16119), new ItemInfo(16120), new ItemInfo(16121), new ItemInfo(16122), new ItemInfo(16123), new ItemInfo(16124), new ItemInfo(16125), 
            new ItemInfo(16126), new ItemInfo(16127), new ItemInfo(16128), new ItemInfo(16129), new ItemInfo(16130), new ItemInfo(16131), new ItemInfo(16132), new ItemInfo(16133), new ItemInfo(16134), 
            new ItemInfo(16135), new ItemInfo(16136), new ItemInfo(16137), new ItemInfo(16138), new ItemInfo(16139), new ItemInfo(16140), new ItemInfo(16141), new ItemInfo(16142), new ItemInfo(16143), 
            new ItemInfo(16144), new ItemInfo(16145), new ItemInfo(16146), new ItemInfo(16147), new ItemInfo(16148), new ItemInfo(16149), new ItemInfo(16150), new ItemInfo(16151), new ItemInfo(16152)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt13Gump()
			: this(0)
		{ }

		public AddMisc2Pt13Gump(int page) 
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

			from.SendGump(new AddMisc2Pt13Gump(page));
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
