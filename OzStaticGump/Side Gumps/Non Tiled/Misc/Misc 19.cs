using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt19Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt19", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt19_OnCommand));
		}

		[Usage("AddMiscPt19")]
		
		public static void AddMiscPt19_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt19Gump>();
			e.Mobile.SendGump(new AddMiscPt19Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(7451), new ItemInfo(7452), new ItemInfo(7453), new ItemInfo(7454), new ItemInfo(7455), new ItemInfo(7456), new ItemInfo(7457), new ItemInfo(7458), new ItemInfo(7459), 
            new ItemInfo(7460), new ItemInfo(7461), new ItemInfo(7462), new ItemInfo(7463), new ItemInfo(7464), new ItemInfo(7465), new ItemInfo(7466), new ItemInfo(7467), new ItemInfo(7468), 
            new ItemInfo(7469), new ItemInfo(7470), new ItemInfo(7471), new ItemInfo(7472), new ItemInfo(7473), new ItemInfo(7474), new ItemInfo(7475), new ItemInfo(7476), new ItemInfo(7477), 
            new ItemInfo(7478), new ItemInfo(7479), new ItemInfo(7480), new ItemInfo(7481), new ItemInfo(7482), new ItemInfo(7483), new ItemInfo(7484), new ItemInfo(7485), new ItemInfo(7486), 
            new ItemInfo(7487), new ItemInfo(7488), new ItemInfo(7489), new ItemInfo(7490), new ItemInfo(7491), new ItemInfo(7492), new ItemInfo(7493), new ItemInfo(7494), new ItemInfo(7495), 
            new ItemInfo(7496), new ItemInfo(7497), new ItemInfo(7498), new ItemInfo(7499), new ItemInfo(7500), new ItemInfo(7501), new ItemInfo(7502), new ItemInfo(7503), new ItemInfo(7504), 
            new ItemInfo(7505), new ItemInfo(7506), new ItemInfo(7507), new ItemInfo(7508), new ItemInfo(7509), new ItemInfo(7510), new ItemInfo(7511), new ItemInfo(7512), new ItemInfo(7513), 
            new ItemInfo(7514), new ItemInfo(7515), new ItemInfo(7516), new ItemInfo(7517), new ItemInfo(7518), new ItemInfo(7519), new ItemInfo(7520), new ItemInfo(7521), new ItemInfo(7522), 
            new ItemInfo(7523), new ItemInfo(7524), new ItemInfo(7525), new ItemInfo(7526), new ItemInfo(7527), new ItemInfo(7528), new ItemInfo(7529), new ItemInfo(7530), new ItemInfo(7531), 
            new ItemInfo(7532), new ItemInfo(7533), new ItemInfo(7534), new ItemInfo(7535), new ItemInfo(7536), new ItemInfo(7537), new ItemInfo(7538), new ItemInfo(7539), new ItemInfo(7540), 
            new ItemInfo(7541), new ItemInfo(7542), new ItemInfo(7543), new ItemInfo(7544), new ItemInfo(7545), new ItemInfo(7546), new ItemInfo(7547), new ItemInfo(7548), new ItemInfo(7549), 
            new ItemInfo(7550), new ItemInfo(7551), new ItemInfo(7552), new ItemInfo(7553), new ItemInfo(7554), new ItemInfo(7555), new ItemInfo(7556), new ItemInfo(7557), new ItemInfo(7558), 
            new ItemInfo(7559), new ItemInfo(7560), new ItemInfo(7561), new ItemInfo(7562), new ItemInfo(7563), new ItemInfo(7564), new ItemInfo(7565), new ItemInfo(7566), new ItemInfo(7567), 
            new ItemInfo(7568), new ItemInfo(7569), new ItemInfo(7570), new ItemInfo(7571), new ItemInfo(7572), new ItemInfo(7573), new ItemInfo(7574), new ItemInfo(7575), new ItemInfo(7576), 
            new ItemInfo(7577), new ItemInfo(7578), new ItemInfo(7579), new ItemInfo(7580), new ItemInfo(7581), new ItemInfo(7582), new ItemInfo(7583), new ItemInfo(7584), new ItemInfo(7585), 
            new ItemInfo(7586), new ItemInfo(7587), new ItemInfo(7588), new ItemInfo(7597), new ItemInfo(7598), new ItemInfo(7599), new ItemInfo(7600), new ItemInfo(7601), new ItemInfo(7602), 
            new ItemInfo(7603), new ItemInfo(7604), new ItemInfo(7605), new ItemInfo(7606), new ItemInfo(7607), new ItemInfo(7608), new ItemInfo(7609), new ItemInfo(7610), new ItemInfo(7635), 
            new ItemInfo(7636), new ItemInfo(7637), new ItemInfo(7638), new ItemInfo(7639), new ItemInfo(7640), new ItemInfo(7641), new ItemInfo(7642), new ItemInfo(7643), new ItemInfo(7644), 
            new ItemInfo(7645), new ItemInfo(7646), new ItemInfo(7647), new ItemInfo(7648), new ItemInfo(7649), new ItemInfo(7650), new ItemInfo(7651), new ItemInfo(7652), new ItemInfo(7653), 
            new ItemInfo(7654), new ItemInfo(7655), new ItemInfo(7656), new ItemInfo(7657), new ItemInfo(7658), new ItemInfo(7659), new ItemInfo(7660), new ItemInfo(7661), new ItemInfo(7662), 
            new ItemInfo(7663), new ItemInfo(7664), new ItemInfo(7665), new ItemInfo(7666), new ItemInfo(7667), new ItemInfo(7668), new ItemInfo(7669), new ItemInfo(7670), new ItemInfo(7671), 
            new ItemInfo(7672), new ItemInfo(7673), new ItemInfo(7674), new ItemInfo(7675), new ItemInfo(7676), new ItemInfo(7677), new ItemInfo(7678), new ItemInfo(7679), new ItemInfo(7680), 
            new ItemInfo(7681), new ItemInfo(7682), new ItemInfo(7683), new ItemInfo(7684), new ItemInfo(7685), new ItemInfo(7686), new ItemInfo(7687), new ItemInfo(7688), new ItemInfo(7689), 
            new ItemInfo(7690), new ItemInfo(7691), new ItemInfo(7692), new ItemInfo(7693), new ItemInfo(7694), new ItemInfo(7695), new ItemInfo(7696), new ItemInfo(7697), new ItemInfo(7698), 
            new ItemInfo(7699), new ItemInfo(7700), new ItemInfo(7712), new ItemInfo(7713), new ItemInfo(7714), new ItemInfo(7715), new ItemInfo(7716), new ItemInfo(7717), new ItemInfo(7718)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt19Gump()
			: this(0)
		{ }

		public AddMiscPt19Gump(int page) 
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

			from.SendGump(new AddMiscPt19Gump(page));
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
