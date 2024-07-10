using Server.Network;

namespace Server.Gumps
{
	public class AddCustomPt19Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddCustomPt19", AccessLevel.GameMaster, new CommandEventHandler(AddCustomPt19_OnCommand));
		}

		[Usage("AddCustomPt19")]
		
		public static void AddCustomPt19_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddCustomPt19Gump>();
			e.Mobile.SendGump(new AddCustomPt19Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Customs
            
           new ItemInfo(42973), new ItemInfo(42974), new ItemInfo(42975), new ItemInfo(42976), new ItemInfo(42977), new ItemInfo(42978), new ItemInfo(42979), new ItemInfo(42980), new ItemInfo(42981), 
			new ItemInfo(42982), new ItemInfo(42983), new ItemInfo(42984), new ItemInfo(42985), new ItemInfo(42986), new ItemInfo(42987), new ItemInfo(42988), new ItemInfo(42989), new ItemInfo(42990), 
			new ItemInfo(42991), new ItemInfo(42992), new ItemInfo(42993), new ItemInfo(42994), new ItemInfo(42995), new ItemInfo(42996), new ItemInfo(42997), new ItemInfo(42998), new ItemInfo(42999), 
			new ItemInfo(43000), new ItemInfo(43002), new ItemInfo(43003), new ItemInfo(43004), new ItemInfo(43005), new ItemInfo(43006), new ItemInfo(43007), new ItemInfo(43008), new ItemInfo(43009), 
			new ItemInfo(43010), new ItemInfo(43011), new ItemInfo(43012), new ItemInfo(43013), new ItemInfo(43014), new ItemInfo(43015), new ItemInfo(43016), new ItemInfo(43017), new ItemInfo(43019), 
			new ItemInfo(43020), new ItemInfo(43021), new ItemInfo(43022), new ItemInfo(43023), new ItemInfo(43024), new ItemInfo(43025), new ItemInfo(43026), new ItemInfo(43027), new ItemInfo(43028), 
			new ItemInfo(43029), new ItemInfo(43030), new ItemInfo(43031), new ItemInfo(43032), new ItemInfo(43033), new ItemInfo(43034), new ItemInfo(43036), new ItemInfo(43037), new ItemInfo(43038), 
			new ItemInfo(43039), new ItemInfo(43040), new ItemInfo(43041), new ItemInfo(43042), new ItemInfo(43043), new ItemInfo(43044), new ItemInfo(43045), new ItemInfo(43046), new ItemInfo(43047), 
			new ItemInfo(43048), new ItemInfo(43049), new ItemInfo(43050), new ItemInfo(43051), new ItemInfo(43052), new ItemInfo(43053), new ItemInfo(43054), new ItemInfo(43055), new ItemInfo(43056), 
			new ItemInfo(43057), new ItemInfo(43058), new ItemInfo(43059), new ItemInfo(43060), new ItemInfo(43061), new ItemInfo(43062), new ItemInfo(43063), new ItemInfo(43064), new ItemInfo(43065), 
			new ItemInfo(43066), new ItemInfo(43067), new ItemInfo(43068), new ItemInfo(43069), new ItemInfo(43070), new ItemInfo(43071), new ItemInfo(43072), new ItemInfo(43073), new ItemInfo(43074), 
			new ItemInfo(43075), new ItemInfo(43077), new ItemInfo(43078), new ItemInfo(43079), new ItemInfo(43080), new ItemInfo(43081), new ItemInfo(43082), new ItemInfo(43083), new ItemInfo(43084), 
			new ItemInfo(43085), new ItemInfo(43086), new ItemInfo(43087), new ItemInfo(43088), new ItemInfo(43089), new ItemInfo(43090), new ItemInfo(43091), new ItemInfo(43092), new ItemInfo(43094), 
			new ItemInfo(43095), new ItemInfo(43096), new ItemInfo(43097), new ItemInfo(43098), new ItemInfo(43099), new ItemInfo(43100), new ItemInfo(43101), new ItemInfo(43102), new ItemInfo(43103), 
			new ItemInfo(43104), new ItemInfo(43105), new ItemInfo(43106), new ItemInfo(43107), new ItemInfo(43108), new ItemInfo(43109), new ItemInfo(43111), new ItemInfo(43112), new ItemInfo(43113), 
			new ItemInfo(43114), new ItemInfo(43115), new ItemInfo(43116), new ItemInfo(43117), new ItemInfo(43118), new ItemInfo(43119), new ItemInfo(43120), new ItemInfo(43121), new ItemInfo(43122), 
			new ItemInfo(43123), new ItemInfo(43124), new ItemInfo(43125), new ItemInfo(43126), new ItemInfo(43128), new ItemInfo(43129), new ItemInfo(43130), new ItemInfo(43131), new ItemInfo(43132), 
			new ItemInfo(43133), new ItemInfo(43134), new ItemInfo(43135), new ItemInfo(43136), new ItemInfo(43137), new ItemInfo(43138), new ItemInfo(43139), new ItemInfo(43140), new ItemInfo(43141), 
			new ItemInfo(43142), new ItemInfo(43143), new ItemInfo(43145), new ItemInfo(43146), new ItemInfo(43147), new ItemInfo(43148), new ItemInfo(43149), new ItemInfo(43150), new ItemInfo(43151), 
			new ItemInfo(43152), new ItemInfo(43153), new ItemInfo(43154), new ItemInfo(43155), new ItemInfo(43156), new ItemInfo(43157), new ItemInfo(43158), new ItemInfo(43159), new ItemInfo(43160), 
			new ItemInfo(43162), new ItemInfo(43163), new ItemInfo(43164), new ItemInfo(43165), new ItemInfo(43166), new ItemInfo(43167), new ItemInfo(43168), new ItemInfo(43169), new ItemInfo(43170), 
			new ItemInfo(43171), new ItemInfo(43172), new ItemInfo(43173), new ItemInfo(43174), new ItemInfo(43175), new ItemInfo(43176), new ItemInfo(43177), new ItemInfo(43178), new ItemInfo(43179), 
			new ItemInfo(43180), new ItemInfo(43181), new ItemInfo(43182), new ItemInfo(43183), new ItemInfo(43184), new ItemInfo(43185), new ItemInfo(43186), new ItemInfo(43187), new ItemInfo(43188)
            
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddCustomPt19Gump()
			: this(0)
		{ }

		public AddCustomPt19Gump(int page) 
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

			from.SendGump(new AddCustomPt19Gump(page));
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
