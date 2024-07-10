using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt10Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt10", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt10_OnCommand));
		}

		[Usage("AddMisc2Pt10")]
		
		public static void AddMisc2Pt10_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt10Gump>();
			e.Mobile.SendGump(new AddMisc2Pt10Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(12988), new ItemInfo(12989), new ItemInfo(12990), new ItemInfo(12991), new ItemInfo(12992), new ItemInfo(12993), new ItemInfo(12994), new ItemInfo(12995), new ItemInfo(13040), 
            new ItemInfo(13042), new ItemInfo(13043), new ItemInfo(13044), new ItemInfo(13045), new ItemInfo(13046), new ItemInfo(13047), new ItemInfo(13048), new ItemInfo(13178), new ItemInfo(13549), 
            new ItemInfo(13550), new ItemInfo(13551), new ItemInfo(13552), new ItemInfo(13553), new ItemInfo(13554), new ItemInfo(13555), new ItemInfo(13556), new ItemInfo(13557), new ItemInfo(13558), 
            new ItemInfo(13559), new ItemInfo(13560), new ItemInfo(13561), new ItemInfo(13562), new ItemInfo(13563), new ItemInfo(13564), new ItemInfo(13565), new ItemInfo(13566), new ItemInfo(13567), 
            new ItemInfo(13568), new ItemInfo(13569), new ItemInfo(13570), new ItemInfo(13571), new ItemInfo(13572), new ItemInfo(13573), new ItemInfo(13574), new ItemInfo(13575), new ItemInfo(13576), 
            new ItemInfo(13577), new ItemInfo(13578), new ItemInfo(13579), new ItemInfo(13580), new ItemInfo(13581), new ItemInfo(13582), new ItemInfo(13583), new ItemInfo(13584), new ItemInfo(13585), 
            new ItemInfo(13586), new ItemInfo(13587), new ItemInfo(13588), new ItemInfo(13589), new ItemInfo(13590), new ItemInfo(13591), new ItemInfo(13592), new ItemInfo(13593), new ItemInfo(13594), 
            new ItemInfo(13595), new ItemInfo(13596), new ItemInfo(13597), new ItemInfo(13598), new ItemInfo(13599), new ItemInfo(13600), new ItemInfo(13601), new ItemInfo(13602), new ItemInfo(13603), 
            new ItemInfo(13604), new ItemInfo(13605), new ItemInfo(13606), new ItemInfo(13607), new ItemInfo(13608), new ItemInfo(13700), new ItemInfo(13701), new ItemInfo(13702), new ItemInfo(13703), 
            new ItemInfo(13704), new ItemInfo(13705), new ItemInfo(13706), new ItemInfo(13707), new ItemInfo(13708), new ItemInfo(13709), new ItemInfo(13710), new ItemInfo(13711), new ItemInfo(13712), 
            new ItemInfo(13713), new ItemInfo(13758), new ItemInfo(13759), new ItemInfo(13760), new ItemInfo(13761), new ItemInfo(13762), new ItemInfo(13763), new ItemInfo(13764), new ItemInfo(13765), 
            new ItemInfo(13766), new ItemInfo(13767), new ItemInfo(13768), new ItemInfo(13769), new ItemInfo(13770), new ItemInfo(13771), new ItemInfo(13772), new ItemInfo(13773), new ItemInfo(13774), 
            new ItemInfo(13775), new ItemInfo(13776), new ItemInfo(13777), new ItemInfo(13778), new ItemInfo(13779), new ItemInfo(13780), new ItemInfo(13781), new ItemInfo(13782), new ItemInfo(13799), 
            new ItemInfo(13800), new ItemInfo(13801), new ItemInfo(13802), new ItemInfo(13803), new ItemInfo(13804), new ItemInfo(13805), new ItemInfo(13806), new ItemInfo(13807), new ItemInfo(13808), 
            new ItemInfo(13809), new ItemInfo(13810), new ItemInfo(13811), new ItemInfo(13812), new ItemInfo(13813), new ItemInfo(13814), new ItemInfo(13815), new ItemInfo(13816), new ItemInfo(13817), 
            new ItemInfo(13818), new ItemInfo(13819), new ItemInfo(13820), new ItemInfo(13821), new ItemInfo(13822), new ItemInfo(13823), new ItemInfo(13824), new ItemInfo(13825), new ItemInfo(13826), 
            new ItemInfo(13827), new ItemInfo(13828), new ItemInfo(13829), new ItemInfo(13830), new ItemInfo(13831), new ItemInfo(13832), new ItemInfo(13833), new ItemInfo(13834), new ItemInfo(13835), 
            new ItemInfo(13836), new ItemInfo(13837), new ItemInfo(13878), new ItemInfo(13879), new ItemInfo(13880), new ItemInfo(13881), new ItemInfo(13882), new ItemInfo(13883), new ItemInfo(13884), 
            new ItemInfo(13885), new ItemInfo(13886), new ItemInfo(13887), new ItemInfo(13888), new ItemInfo(13889), new ItemInfo(13890), new ItemInfo(13891), new ItemInfo(13892), new ItemInfo(13893), 
            new ItemInfo(13894), new ItemInfo(13895), new ItemInfo(13896), new ItemInfo(13897), new ItemInfo(13898), new ItemInfo(13899), new ItemInfo(13900), new ItemInfo(13901), new ItemInfo(13902), 
            new ItemInfo(13903), new ItemInfo(13904), new ItemInfo(13905), new ItemInfo(13906), new ItemInfo(13907), new ItemInfo(13908), new ItemInfo(13909), new ItemInfo(13910), new ItemInfo(13911), 
            new ItemInfo(13912), new ItemInfo(13913), new ItemInfo(13914), new ItemInfo(13915), new ItemInfo(13916), new ItemInfo(13917), new ItemInfo(13918), new ItemInfo(13919), new ItemInfo(13920), 
            new ItemInfo(13921), new ItemInfo(13922), new ItemInfo(13923), new ItemInfo(13924), new ItemInfo(13925), new ItemInfo(13926), new ItemInfo(13927), new ItemInfo(13928), new ItemInfo(13929), 
            new ItemInfo(13930), new ItemInfo(13931), new ItemInfo(13932), new ItemInfo(13933), new ItemInfo(13934), new ItemInfo(13935), new ItemInfo(13944), new ItemInfo(13945), new ItemInfo(13946), 
            new ItemInfo(13947), new ItemInfo(13948), new ItemInfo(13949), new ItemInfo(13950), new ItemInfo(13951), new ItemInfo(13952), new ItemInfo(13953), new ItemInfo(13954), new ItemInfo(13955), 
            new ItemInfo(13956), new ItemInfo(13957), new ItemInfo(13958), new ItemInfo(13959), new ItemInfo(13960), new ItemInfo(13961), new ItemInfo(13962), new ItemInfo(13963), new ItemInfo(13964), 
            new ItemInfo(13965), new ItemInfo(13966), new ItemInfo(13967), new ItemInfo(13968), new ItemInfo(13969), new ItemInfo(13970), new ItemInfo(13971), new ItemInfo(13972), new ItemInfo(13973), 
            new ItemInfo(13974), new ItemInfo(13975), new ItemInfo(13976), new ItemInfo(13977), new ItemInfo(13978), new ItemInfo(13979), new ItemInfo(13980), new ItemInfo(13981), new ItemInfo(13982), 
            new ItemInfo(13983), new ItemInfo(13986), new ItemInfo(13987), new ItemInfo(13988), new ItemInfo(13989), new ItemInfo(13990), new ItemInfo(13991), new ItemInfo(13992), new ItemInfo(13993), 
            new ItemInfo(13994), new ItemInfo(13995), new ItemInfo(13996), new ItemInfo(13997), new ItemInfo(13998), new ItemInfo(13999), new ItemInfo(14000), new ItemInfo(14001), new ItemInfo(14002), 
            new ItemInfo(14003), new ItemInfo(14004), new ItemInfo(14005), new ItemInfo(14006), new ItemInfo(14007), new ItemInfo(14008), new ItemInfo(14009), new ItemInfo(14010), new ItemInfo(14011), 
            new ItemInfo(14012), new ItemInfo(14013), new ItemInfo(14014), new ItemInfo(14015), new ItemInfo(14016), new ItemInfo(14017), new ItemInfo(14018), new ItemInfo(14019), new ItemInfo(14020), 
            new ItemInfo(14021), new ItemInfo(14022), new ItemInfo(14023), new ItemInfo(14024), new ItemInfo(14025), new ItemInfo(14026), new ItemInfo(14027), new ItemInfo(14028), new ItemInfo(14029), 
            new ItemInfo(14030), new ItemInfo(14031), new ItemInfo(14032), new ItemInfo(14033), new ItemInfo(14034), new ItemInfo(14035), new ItemInfo(14036), new ItemInfo(14037), new ItemInfo(14038), 
            new ItemInfo(14039), new ItemInfo(14040), new ItemInfo(14041), new ItemInfo(14042), new ItemInfo(14043), new ItemInfo(14044), new ItemInfo(14045), new ItemInfo(14046), new ItemInfo(14047), 
            new ItemInfo(14048), new ItemInfo(14049), new ItemInfo(14050), new ItemInfo(14051), new ItemInfo(14052), new ItemInfo(14053), new ItemInfo(14054), new ItemInfo(14055), new ItemInfo(14056), 
            new ItemInfo(14057), new ItemInfo(14058), new ItemInfo(14059), new ItemInfo(14060), new ItemInfo(14061), new ItemInfo(14062), new ItemInfo(14063), new ItemInfo(14064), new ItemInfo(14065), 
            new ItemInfo(14066), new ItemInfo(14067), new ItemInfo(14068), new ItemInfo(14069), new ItemInfo(14070), new ItemInfo(14071), new ItemInfo(14072), new ItemInfo(14073), new ItemInfo(14074), 
            new ItemInfo(14075), new ItemInfo(14076), new ItemInfo(14077), new ItemInfo(14078), new ItemInfo(14079), new ItemInfo(14080), new ItemInfo(14081), new ItemInfo(14082), new ItemInfo(14083), 
            new ItemInfo(14084), new ItemInfo(14085), new ItemInfo(14086), new ItemInfo(14087), new ItemInfo(14088), new ItemInfo(14089), new ItemInfo(14090), new ItemInfo(14091), new ItemInfo(14092)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt10Gump()
			: this(0)
		{ }

		public AddMisc2Pt10Gump(int page) 
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

			from.SendGump(new AddMisc2Pt10Gump(page));
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
