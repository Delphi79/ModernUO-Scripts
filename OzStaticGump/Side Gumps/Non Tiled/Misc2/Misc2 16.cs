using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt16Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt16", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt16_OnCommand));
		}

		[Usage("AddMisc2Pt16")]
		
		public static void AddMisc2Pt16_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt16Gump>();
			e.Mobile.SendGump(new AddMisc2Pt16Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(17639), new ItemInfo(17640), new ItemInfo(17641), new ItemInfo(17642), new ItemInfo(17643), new ItemInfo(17644), new ItemInfo(17645), new ItemInfo(17646), new ItemInfo(17647), 
            new ItemInfo(17648), new ItemInfo(17649), new ItemInfo(17650), new ItemInfo(17651), new ItemInfo(17652), new ItemInfo(17653), new ItemInfo(17654), new ItemInfo(17655), new ItemInfo(17656), 
            new ItemInfo(17677), new ItemInfo(17678), new ItemInfo(17683), new ItemInfo(17684), new ItemInfo(17685), new ItemInfo(17686), new ItemInfo(17687), new ItemInfo(17774), new ItemInfo(17775), 
            new ItemInfo(17776), new ItemInfo(17777), new ItemInfo(17778), new ItemInfo(17779), new ItemInfo(17780), new ItemInfo(17781), new ItemInfo(17782), new ItemInfo(17783), new ItemInfo(17784), 
            new ItemInfo(17785), new ItemInfo(17786), new ItemInfo(17787), new ItemInfo(17788), new ItemInfo(17789), new ItemInfo(17844), new ItemInfo(17845), new ItemInfo(17846), new ItemInfo(17847), 
            new ItemInfo(17848), new ItemInfo(17849), new ItemInfo(17850), new ItemInfo(17851), new ItemInfo(17852), new ItemInfo(17853), new ItemInfo(17854), new ItemInfo(17855), new ItemInfo(17856), 
            new ItemInfo(17857), new ItemInfo(17858), new ItemInfo(17859), new ItemInfo(17860), new ItemInfo(17861), new ItemInfo(17862), new ItemInfo(17863), new ItemInfo(17864), new ItemInfo(17865), 
            new ItemInfo(17866), new ItemInfo(17867), new ItemInfo(17868), new ItemInfo(17869), new ItemInfo(17870), new ItemInfo(17871), new ItemInfo(17872), new ItemInfo(17873), new ItemInfo(17874), 
            new ItemInfo(17875), new ItemInfo(17876), new ItemInfo(17877), new ItemInfo(17878), new ItemInfo(17879), new ItemInfo(17880), new ItemInfo(17881), new ItemInfo(17882), new ItemInfo(17883), 
            new ItemInfo(17884), new ItemInfo(17885), new ItemInfo(17886), new ItemInfo(17887), new ItemInfo(17888), new ItemInfo(17889), new ItemInfo(17890), new ItemInfo(17891), new ItemInfo(17892), 
            new ItemInfo(17893), new ItemInfo(17894), new ItemInfo(17895), new ItemInfo(17896), new ItemInfo(17897), new ItemInfo(17898), new ItemInfo(17899), new ItemInfo(17900), new ItemInfo(17901), 
            new ItemInfo(17902), new ItemInfo(17903), new ItemInfo(17904), new ItemInfo(17905), new ItemInfo(17906), new ItemInfo(17907), new ItemInfo(17908), new ItemInfo(17909), new ItemInfo(17910), 
            new ItemInfo(17911), new ItemInfo(17912), new ItemInfo(17913), new ItemInfo(17914), new ItemInfo(17915), new ItemInfo(17916), new ItemInfo(17917), new ItemInfo(17918), new ItemInfo(17919), 
            new ItemInfo(17920), new ItemInfo(17921), new ItemInfo(17922), new ItemInfo(17923), new ItemInfo(17924), new ItemInfo(17925), new ItemInfo(17926), new ItemInfo(17927), new ItemInfo(17928), 
            new ItemInfo(17929), new ItemInfo(17930), new ItemInfo(17931), new ItemInfo(17932), new ItemInfo(17933), new ItemInfo(17934), new ItemInfo(17935), new ItemInfo(17936), new ItemInfo(17937), 
            new ItemInfo(17938), new ItemInfo(17939), new ItemInfo(17940), new ItemInfo(17941), new ItemInfo(17942), new ItemInfo(17943), new ItemInfo(17944), new ItemInfo(17945), new ItemInfo(17946), 
            new ItemInfo(17947), new ItemInfo(17948), new ItemInfo(17949), new ItemInfo(17950), new ItemInfo(17951), new ItemInfo(17952), new ItemInfo(17953), new ItemInfo(17954), new ItemInfo(17955), 
            new ItemInfo(17956), new ItemInfo(17957), new ItemInfo(17958), new ItemInfo(17959), new ItemInfo(17960), new ItemInfo(17961), new ItemInfo(17962), new ItemInfo(17963), new ItemInfo(17964), 
            new ItemInfo(17965), new ItemInfo(17966), new ItemInfo(17967), new ItemInfo(17968), new ItemInfo(17969), new ItemInfo(17970), new ItemInfo(17971), new ItemInfo(17972), new ItemInfo(17973), 
            new ItemInfo(17974), new ItemInfo(17975), new ItemInfo(17976), new ItemInfo(17977), new ItemInfo(17978), new ItemInfo(17979), new ItemInfo(17980), new ItemInfo(17981), new ItemInfo(17982), 
            new ItemInfo(17983), new ItemInfo(17984), new ItemInfo(17985), new ItemInfo(17986), new ItemInfo(17987), new ItemInfo(17988), new ItemInfo(17989), new ItemInfo(17990), new ItemInfo(17991), 
            new ItemInfo(17992), new ItemInfo(17993), new ItemInfo(17994), new ItemInfo(17995), new ItemInfo(17996), new ItemInfo(17997), new ItemInfo(17998), new ItemInfo(17999), new ItemInfo(18000), 
            new ItemInfo(18001), new ItemInfo(18002), new ItemInfo(18003), new ItemInfo(18004), new ItemInfo(18005), new ItemInfo(18006), new ItemInfo(18007), new ItemInfo(18008), new ItemInfo(18009), 
            new ItemInfo(18010), new ItemInfo(18011), new ItemInfo(18012), new ItemInfo(18013), new ItemInfo(18014), new ItemInfo(18015), new ItemInfo(18016), new ItemInfo(18017), new ItemInfo(18018), 
            new ItemInfo(18019), new ItemInfo(18020), new ItemInfo(18021), new ItemInfo(18022), new ItemInfo(18023), new ItemInfo(18024), new ItemInfo(18025), new ItemInfo(18026), new ItemInfo(18027), 
            new ItemInfo(18028), new ItemInfo(18029), new ItemInfo(18030), new ItemInfo(18031), new ItemInfo(18032), new ItemInfo(18033), new ItemInfo(18034), new ItemInfo(18035), new ItemInfo(18036), 
            new ItemInfo(18037), new ItemInfo(18038), new ItemInfo(18039), new ItemInfo(18040), new ItemInfo(18041), new ItemInfo(18042), new ItemInfo(18043), new ItemInfo(18044), new ItemInfo(18045), 
            new ItemInfo(18046), new ItemInfo(18047), new ItemInfo(18048), new ItemInfo(18049), new ItemInfo(18050), new ItemInfo(18051), new ItemInfo(18052), new ItemInfo(18053), new ItemInfo(18054), 
            new ItemInfo(18055), new ItemInfo(18056), new ItemInfo(18057), new ItemInfo(18058), new ItemInfo(18059), new ItemInfo(18065), new ItemInfo(18066), new ItemInfo(18067), new ItemInfo(18068), 
            new ItemInfo(18069), new ItemInfo(18070), new ItemInfo(18071), new ItemInfo(18072), new ItemInfo(18073), new ItemInfo(18074), new ItemInfo(18075), new ItemInfo(18076), new ItemInfo(18082), 
            new ItemInfo(18083), new ItemInfo(18084), new ItemInfo(18085), new ItemInfo(18086), new ItemInfo(18087), new ItemInfo(18088), new ItemInfo(18089), new ItemInfo(18090), new ItemInfo(18091), 
            new ItemInfo(18092), new ItemInfo(18093), new ItemInfo(18094), new ItemInfo(18095), new ItemInfo(18098), new ItemInfo(18099), new ItemInfo(18102), new ItemInfo(18103), new ItemInfo(18104), 
            new ItemInfo(18105), new ItemInfo(18106), new ItemInfo(18107), new ItemInfo(18108), new ItemInfo(18137), new ItemInfo(18141), new ItemInfo(18142), new ItemInfo(18143), new ItemInfo(18144), 
            new ItemInfo(18145), new ItemInfo(18146), new ItemInfo(18147), new ItemInfo(18148), new ItemInfo(18149), new ItemInfo(18150), new ItemInfo(18151), new ItemInfo(18152), new ItemInfo(18153), 
            new ItemInfo(18154), new ItemInfo(18155), new ItemInfo(18156), new ItemInfo(18157), new ItemInfo(18158), new ItemInfo(18159), new ItemInfo(18160), new ItemInfo(18161), new ItemInfo(18162), 
            new ItemInfo(18163), new ItemInfo(18164), new ItemInfo(18165), new ItemInfo(18166), new ItemInfo(18167), new ItemInfo(18168), new ItemInfo(18169), new ItemInfo(18170), new ItemInfo(18171), 
            new ItemInfo(18172), new ItemInfo(18173), new ItemInfo(18174), new ItemInfo(18175), new ItemInfo(18176), new ItemInfo(18177), new ItemInfo(18178), new ItemInfo(18179), new ItemInfo(18182), 
            new ItemInfo(18183), new ItemInfo(18184), new ItemInfo(18185), new ItemInfo(18186), new ItemInfo(18187), new ItemInfo(18188), new ItemInfo(18189), new ItemInfo(18190), new ItemInfo(18191), 
            new ItemInfo(18192), new ItemInfo(18193), new ItemInfo(18194), new ItemInfo(18195), new ItemInfo(18196), new ItemInfo(18197), new ItemInfo(18198), new ItemInfo(18199), new ItemInfo(18200), 
            new ItemInfo(18201), new ItemInfo(18202), new ItemInfo(18203), new ItemInfo(18204), new ItemInfo(18205), new ItemInfo(18206), new ItemInfo(18207), new ItemInfo(18208), new ItemInfo(18209)

            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt16Gump()
			: this(0)
		{ }

		public AddMisc2Pt16Gump(int page) 
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

			from.SendGump(new AddMisc2Pt16Gump(page));
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
