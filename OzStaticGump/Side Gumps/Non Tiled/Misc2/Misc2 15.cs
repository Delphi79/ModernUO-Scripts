using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt15Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt15", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt15_OnCommand));
		}

		[Usage("AddMisc2Pt15")]
		
		public static void AddMisc2Pt15_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt15Gump>();
			e.Mobile.SendGump(new AddMisc2Pt15Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(16710), new ItemInfo(16711), new ItemInfo(16712), new ItemInfo(16713), new ItemInfo(16714), new ItemInfo(16715), new ItemInfo(16716), new ItemInfo(16717), new ItemInfo(16801), 
            new ItemInfo(16802), new ItemInfo(16813), new ItemInfo(16814), new ItemInfo(16819), new ItemInfo(16820), new ItemInfo(16829), new ItemInfo(16830), new ItemInfo(16831), new ItemInfo(16832), 
            new ItemInfo(16833), new ItemInfo(16834), new ItemInfo(16835), new ItemInfo(16836), new ItemInfo(16837), new ItemInfo(16838), new ItemInfo(16839), new ItemInfo(16840), new ItemInfo(16841), 
            new ItemInfo(16845), new ItemInfo(16846), new ItemInfo(16847), new ItemInfo(16848), new ItemInfo(16849), new ItemInfo(16850), new ItemInfo(16851), new ItemInfo(16852), new ItemInfo(16853), 
            new ItemInfo(16854), new ItemInfo(16858), new ItemInfo(16859), new ItemInfo(16869), new ItemInfo(16870), new ItemInfo(16871), new ItemInfo(16916), new ItemInfo(16917), new ItemInfo(16918), 
            new ItemInfo(16919), new ItemInfo(16920), new ItemInfo(16921), new ItemInfo(16922), new ItemInfo(16923), new ItemInfo(16924), new ItemInfo(16925), new ItemInfo(16926), new ItemInfo(16927), 
            new ItemInfo(16928), new ItemInfo(16929), new ItemInfo(16930), new ItemInfo(16931), new ItemInfo(16932), new ItemInfo(16933), new ItemInfo(16934), new ItemInfo(16935), new ItemInfo(16954), 
            new ItemInfo(16955), new ItemInfo(16956), new ItemInfo(16957), new ItemInfo(16958), new ItemInfo(16959), new ItemInfo(16960), new ItemInfo(16961), new ItemInfo(16962), new ItemInfo(16963), 
            new ItemInfo(16964), new ItemInfo(16965), new ItemInfo(16966), new ItemInfo(16967), new ItemInfo(16968), new ItemInfo(16969), new ItemInfo(16970), new ItemInfo(16971), new ItemInfo(16972), 
            new ItemInfo(16973), new ItemInfo(16974), new ItemInfo(16975), new ItemInfo(16976), new ItemInfo(16977), new ItemInfo(16978), new ItemInfo(16979), new ItemInfo(16980), new ItemInfo(16981), 
            new ItemInfo(16982), new ItemInfo(16983), new ItemInfo(16984), new ItemInfo(16985), new ItemInfo(16986), new ItemInfo(16987), new ItemInfo(16988), new ItemInfo(16989), new ItemInfo(16990), 
            new ItemInfo(16991), new ItemInfo(16992), new ItemInfo(16993), new ItemInfo(16994), new ItemInfo(16995), new ItemInfo(16996), new ItemInfo(16997), new ItemInfo(16998), new ItemInfo(16999), 
            new ItemInfo(17000), new ItemInfo(17001), new ItemInfo(17002), new ItemInfo(17003), new ItemInfo(17004), new ItemInfo(17005), new ItemInfo(17006), new ItemInfo(17007), new ItemInfo(17008), 
            new ItemInfo(17009), new ItemInfo(17010), new ItemInfo(17011), new ItemInfo(17012), new ItemInfo(17013), new ItemInfo(17014), new ItemInfo(17015), new ItemInfo(17016), new ItemInfo(17017), 
            new ItemInfo(17018), new ItemInfo(17019), new ItemInfo(17020), new ItemInfo(17021), new ItemInfo(17022), new ItemInfo(17023), new ItemInfo(17024), new ItemInfo(17025), new ItemInfo(17026), 
            new ItemInfo(17027), new ItemInfo(17028), new ItemInfo(17029), new ItemInfo(17030), new ItemInfo(17031), new ItemInfo(17032), new ItemInfo(17033), new ItemInfo(17034), new ItemInfo(17035), 
            new ItemInfo(17036), new ItemInfo(17037), new ItemInfo(17038), new ItemInfo(17039), new ItemInfo(17040), new ItemInfo(17041), new ItemInfo(17042), new ItemInfo(17043), new ItemInfo(17044), 
            new ItemInfo(17045), new ItemInfo(17046), new ItemInfo(17047), new ItemInfo(17048), new ItemInfo(17049), new ItemInfo(17050), new ItemInfo(17051), new ItemInfo(17052), new ItemInfo(17053), 
            new ItemInfo(17054), new ItemInfo(17055), new ItemInfo(17056), new ItemInfo(17057), new ItemInfo(17058), new ItemInfo(17059), new ItemInfo(17060), new ItemInfo(17061), new ItemInfo(17062), 
            new ItemInfo(17063), new ItemInfo(17064), new ItemInfo(17065), new ItemInfo(17066), new ItemInfo(17067), new ItemInfo(17068), new ItemInfo(17069), new ItemInfo(17070), new ItemInfo(17071), 
            new ItemInfo(17072), new ItemInfo(17073), new ItemInfo(17074), new ItemInfo(17075), new ItemInfo(17076), new ItemInfo(17077), new ItemInfo(17078), new ItemInfo(17079), new ItemInfo(17080), 
            new ItemInfo(17081), new ItemInfo(17082), new ItemInfo(17083), new ItemInfo(17084), new ItemInfo(17085), new ItemInfo(17086), new ItemInfo(17087), new ItemInfo(17088), new ItemInfo(17089), 
            new ItemInfo(17090), new ItemInfo(17091), new ItemInfo(17092), new ItemInfo(17093), new ItemInfo(17094), new ItemInfo(17095), new ItemInfo(17096), new ItemInfo(17097), new ItemInfo(17098), 
            new ItemInfo(17099), new ItemInfo(17100), new ItemInfo(17101), new ItemInfo(17102), new ItemInfo(17103), new ItemInfo(17104), new ItemInfo(17105), new ItemInfo(17106), new ItemInfo(17107), 
            new ItemInfo(17108), new ItemInfo(17109), new ItemInfo(17110), new ItemInfo(17111), new ItemInfo(17112), new ItemInfo(17113), new ItemInfo(17114), new ItemInfo(17115), new ItemInfo(17116), 
            new ItemInfo(17117), new ItemInfo(17118), new ItemInfo(17119), new ItemInfo(17154), new ItemInfo(17155), new ItemInfo(17156), new ItemInfo(17157), new ItemInfo(17158), new ItemInfo(17159), 
            new ItemInfo(17160), new ItemInfo(17161), new ItemInfo(17162), new ItemInfo(17163), new ItemInfo(17164), new ItemInfo(17165), new ItemInfo(17166), new ItemInfo(17167), new ItemInfo(17168), 
            new ItemInfo(17169), new ItemInfo(17170), new ItemInfo(17171), new ItemInfo(17212), new ItemInfo(17213), new ItemInfo(17214), new ItemInfo(17215), new ItemInfo(17216), new ItemInfo(17217), 
            new ItemInfo(17218), new ItemInfo(17219), new ItemInfo(17220), new ItemInfo(17221), new ItemInfo(17222), new ItemInfo(17223), new ItemInfo(17236), new ItemInfo(17237), new ItemInfo(17238), 
            new ItemInfo(17239), new ItemInfo(17240), new ItemInfo(17241), new ItemInfo(17262), new ItemInfo(17263), new ItemInfo(17264), new ItemInfo(17265), new ItemInfo(17266), new ItemInfo(17267), 
            new ItemInfo(17268), new ItemInfo(17269), new ItemInfo(17270), new ItemInfo(17271), new ItemInfo(17272), new ItemInfo(17273), new ItemInfo(17274), new ItemInfo(17275), new ItemInfo(17276), 
            new ItemInfo(17277), new ItemInfo(17278), new ItemInfo(17279), new ItemInfo(17280), new ItemInfo(17281), new ItemInfo(17282), new ItemInfo(17283), new ItemInfo(17284), new ItemInfo(17285), 
            new ItemInfo(17286), new ItemInfo(17287), new ItemInfo(17288), new ItemInfo(17289), new ItemInfo(17290), new ItemInfo(17291), new ItemInfo(17292), new ItemInfo(17293), new ItemInfo(17294), 
            new ItemInfo(17295), new ItemInfo(17296), new ItemInfo(17297), new ItemInfo(17298), new ItemInfo(17299), new ItemInfo(17300), new ItemInfo(17301), new ItemInfo(17302), new ItemInfo(17303), 
            new ItemInfo(17304), new ItemInfo(17305), new ItemInfo(17306), new ItemInfo(17307), new ItemInfo(17308), new ItemInfo(17309), new ItemInfo(17310), new ItemInfo(17311), new ItemInfo(17312), 
            new ItemInfo(17313), new ItemInfo(17314), new ItemInfo(17315), new ItemInfo(17316), new ItemInfo(17317), new ItemInfo(17318), new ItemInfo(17319), new ItemInfo(17320), new ItemInfo(17321), 
            new ItemInfo(17322), new ItemInfo(17323), new ItemInfo(17324), new ItemInfo(17325), new ItemInfo(17326), new ItemInfo(17327), new ItemInfo(17336), new ItemInfo(17337), new ItemInfo(17338), 
            new ItemInfo(17339), new ItemInfo(17340), new ItemInfo(17341), new ItemInfo(17342), new ItemInfo(17343), new ItemInfo(17601), new ItemInfo(17602), new ItemInfo(17603), new ItemInfo(17604), 
            new ItemInfo(17605), new ItemInfo(17606), new ItemInfo(17607), new ItemInfo(17608), new ItemInfo(17609), new ItemInfo(17610), new ItemInfo(17611), new ItemInfo(17612), new ItemInfo(17613), 
            new ItemInfo(17614), new ItemInfo(17615), new ItemInfo(17616), new ItemInfo(17617), new ItemInfo(17618), new ItemInfo(17619), new ItemInfo(17620), new ItemInfo(17637), new ItemInfo(17638)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt15Gump()
			: this(0)
		{ }

		public AddMisc2Pt15Gump(int page) 
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

			from.SendGump(new AddMisc2Pt15Gump(page));
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
