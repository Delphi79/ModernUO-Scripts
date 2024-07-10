using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt18Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt18", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt18_OnCommand));
		}

		[Usage("AddMiscPt18")]
		
		public static void AddMiscPt18_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt18Gump>();
			e.Mobile.SendGump(new AddMiscPt18Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(7223), new ItemInfo(7224), new ItemInfo(7225), new ItemInfo(7226), new ItemInfo(7227), new ItemInfo(7228), new ItemInfo(7229), new ItemInfo(7230), new ItemInfo(7231), 
            new ItemInfo(7232), new ItemInfo(7233), new ItemInfo(7234), new ItemInfo(7235), new ItemInfo(7236), new ItemInfo(7237), new ItemInfo(7238), new ItemInfo(7239), new ItemInfo(7240), 
            new ItemInfo(7241), new ItemInfo(7242), new ItemInfo(7243), new ItemInfo(7244), new ItemInfo(7245), new ItemInfo(7246), new ItemInfo(7247), new ItemInfo(7248), new ItemInfo(7249), 
            new ItemInfo(7250), new ItemInfo(7251), new ItemInfo(7252), new ItemInfo(7253), new ItemInfo(7254), new ItemInfo(7255), new ItemInfo(7256), new ItemInfo(7257), new ItemInfo(7258), 
            new ItemInfo(7259), new ItemInfo(7260), new ItemInfo(7261), new ItemInfo(7262), new ItemInfo(7263), new ItemInfo(7264), new ItemInfo(7265), new ItemInfo(7266), new ItemInfo(7267), 
            new ItemInfo(7268), new ItemInfo(7269), new ItemInfo(7270), new ItemInfo(7271), new ItemInfo(7272), new ItemInfo(7273), new ItemInfo(7274), new ItemInfo(7275), new ItemInfo(7276), 
            new ItemInfo(7277), new ItemInfo(7278), new ItemInfo(7279), new ItemInfo(7280), new ItemInfo(7281), new ItemInfo(7282), new ItemInfo(7283), new ItemInfo(7284), new ItemInfo(7285), 
            new ItemInfo(7286), new ItemInfo(7287), new ItemInfo(7291), new ItemInfo(7292), new ItemInfo(7293), new ItemInfo(7294), new ItemInfo(7295), new ItemInfo(7296), new ItemInfo(7297), 
            new ItemInfo(7298), new ItemInfo(7299), new ItemInfo(7300), new ItemInfo(7301), new ItemInfo(7302), new ItemInfo(7303), new ItemInfo(7304), new ItemInfo(7305), new ItemInfo(7306), 
            new ItemInfo(7307), new ItemInfo(7308), new ItemInfo(7309), new ItemInfo(7310), new ItemInfo(7311), new ItemInfo(7312), new ItemInfo(7313), new ItemInfo(7314), new ItemInfo(7315), 
            new ItemInfo(7316), new ItemInfo(7317), new ItemInfo(7318), new ItemInfo(7319), new ItemInfo(7320), new ItemInfo(7321), new ItemInfo(7322), new ItemInfo(7323), new ItemInfo(7324), 
            new ItemInfo(7325), new ItemInfo(7326), new ItemInfo(7327), new ItemInfo(7328), new ItemInfo(7329), new ItemInfo(7330), new ItemInfo(7331), new ItemInfo(7332), new ItemInfo(7333), 
            new ItemInfo(7334), new ItemInfo(7335), new ItemInfo(7336), new ItemInfo(7337), new ItemInfo(7338), new ItemInfo(7339), new ItemInfo(7340), new ItemInfo(7341), new ItemInfo(7342), 
            new ItemInfo(7343), new ItemInfo(7344), new ItemInfo(7345), new ItemInfo(7346), new ItemInfo(7347), new ItemInfo(7348), new ItemInfo(7349), new ItemInfo(7350), new ItemInfo(7351), 
            new ItemInfo(7352), new ItemInfo(7353), new ItemInfo(7354), new ItemInfo(7355), new ItemInfo(7356), new ItemInfo(7357), new ItemInfo(7358), new ItemInfo(7359), new ItemInfo(7360), 
            new ItemInfo(7361), new ItemInfo(7362), new ItemInfo(7363), new ItemInfo(7364), new ItemInfo(7365), new ItemInfo(7366), new ItemInfo(7367), new ItemInfo(7368), new ItemInfo(7369), 
            new ItemInfo(7370), new ItemInfo(7371), new ItemInfo(7372), new ItemInfo(7373), new ItemInfo(7374), new ItemInfo(7375), new ItemInfo(7376), new ItemInfo(7377), new ItemInfo(7378), 
            new ItemInfo(7379), new ItemInfo(7380), new ItemInfo(7381), new ItemInfo(7382), new ItemInfo(7383), new ItemInfo(7384), new ItemInfo(7385), new ItemInfo(7386), new ItemInfo(7387), 
            new ItemInfo(7388), new ItemInfo(7389), new ItemInfo(7390), new ItemInfo(7391), new ItemInfo(7392), new ItemInfo(7393), new ItemInfo(7394), new ItemInfo(7395), new ItemInfo(7396), 
            new ItemInfo(7397), new ItemInfo(7398), new ItemInfo(7399), new ItemInfo(7400), new ItemInfo(7401), new ItemInfo(7402), new ItemInfo(7403), new ItemInfo(7404), new ItemInfo(7405), 
            new ItemInfo(7406), new ItemInfo(7407), new ItemInfo(7408), new ItemInfo(7409), new ItemInfo(7410), new ItemInfo(7411), new ItemInfo(7412), new ItemInfo(7413), new ItemInfo(7414), 
            new ItemInfo(7415), new ItemInfo(7416), new ItemInfo(7417), new ItemInfo(7418), new ItemInfo(7419), new ItemInfo(7420), new ItemInfo(7421), new ItemInfo(7422), new ItemInfo(7423), 
            new ItemInfo(7424), new ItemInfo(7425), new ItemInfo(7426), new ItemInfo(7427), new ItemInfo(7428), new ItemInfo(7429), new ItemInfo(7430), new ItemInfo(7431), new ItemInfo(7432), 
            new ItemInfo(7433), new ItemInfo(7434), new ItemInfo(7435), new ItemInfo(7436), new ItemInfo(7437), new ItemInfo(7438), new ItemInfo(7439), new ItemInfo(7440), new ItemInfo(7441), 
            new ItemInfo(7442), new ItemInfo(7443), new ItemInfo(7444), new ItemInfo(7445), new ItemInfo(7446), new ItemInfo(7447), new ItemInfo(7448), new ItemInfo(7449), new ItemInfo(7450)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt18Gump()
			: this(0)
		{ }

		public AddMiscPt18Gump(int page) 
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

			from.SendGump(new AddMiscPt18Gump(page));
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
