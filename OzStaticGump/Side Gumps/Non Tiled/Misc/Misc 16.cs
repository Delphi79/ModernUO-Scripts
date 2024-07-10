using Server.Network;

namespace Server.Gumps
{
	public class AddMiscPt16Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMiscPt16", AccessLevel.GameMaster, new CommandEventHandler(AddMiscPt16_OnCommand));
		}

		[Usage("AddMiscPt16")]
		
		public static void AddMiscPt16_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMiscPt16Gump>();
			e.Mobile.SendGump(new AddMiscPt16Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(6744), new ItemInfo(6745), new ItemInfo(6746), new ItemInfo(6747), new ItemInfo(6748), new ItemInfo(6749), new ItemInfo(6750), new ItemInfo(6751), new ItemInfo(6752), 
            new ItemInfo(6753), new ItemInfo(6754), new ItemInfo(6755), new ItemInfo(6756), new ItemInfo(6757), new ItemInfo(6758), new ItemInfo(6759), new ItemInfo(6760), new ItemInfo(6761), 
            new ItemInfo(6762), new ItemInfo(6763), new ItemInfo(6764), new ItemInfo(6765), new ItemInfo(6766), new ItemInfo(6767), new ItemInfo(6768), new ItemInfo(6769), new ItemInfo(6770), 
            new ItemInfo(6771), new ItemInfo(6772), new ItemInfo(6773), new ItemInfo(6774), new ItemInfo(6775), new ItemInfo(6776), new ItemInfo(6777), new ItemInfo(6778), new ItemInfo(6779), 
            new ItemInfo(6780), new ItemInfo(6781), new ItemInfo(6782), new ItemInfo(6783), new ItemInfo(6784), new ItemInfo(6785), new ItemInfo(6786), new ItemInfo(6787), new ItemInfo(6788), 
            new ItemInfo(6789), new ItemInfo(6790), new ItemInfo(6791), new ItemInfo(6792), new ItemInfo(6793), new ItemInfo(6794), new ItemInfo(6795), new ItemInfo(6796), new ItemInfo(6797), 
            new ItemInfo(6798), new ItemInfo(6799), new ItemInfo(6800), new ItemInfo(6801), new ItemInfo(6807), new ItemInfo(6808), new ItemInfo(6812), new ItemInfo(6813), new ItemInfo(6814), 
            new ItemInfo(6815), new ItemInfo(6816), new ItemInfo(6817), new ItemInfo(6818), new ItemInfo(6819), new ItemInfo(6820), new ItemInfo(6821), new ItemInfo(6822), new ItemInfo(6823), 
            new ItemInfo(6824), new ItemInfo(6825), new ItemInfo(6826), new ItemInfo(6827), new ItemInfo(6828), new ItemInfo(6829), new ItemInfo(6830), new ItemInfo(6831), new ItemInfo(6832), 
            new ItemInfo(6833), new ItemInfo(6834), new ItemInfo(6835), new ItemInfo(6836), new ItemInfo(6837), new ItemInfo(6838), new ItemInfo(6839), new ItemInfo(6840), new ItemInfo(6841), 
            new ItemInfo(6842), new ItemInfo(6843), new ItemInfo(6844), new ItemInfo(6845), new ItemInfo(6846), new ItemInfo(6847), new ItemInfo(6848), new ItemInfo(6849), new ItemInfo(6850), 
            new ItemInfo(6851), new ItemInfo(6852), new ItemInfo(6853), new ItemInfo(6854), new ItemInfo(6855), new ItemInfo(6856), new ItemInfo(6857), new ItemInfo(6858), new ItemInfo(6859), 
            new ItemInfo(6860), new ItemInfo(6861), new ItemInfo(6862), new ItemInfo(6863), new ItemInfo(6864), new ItemInfo(6865), new ItemInfo(6866), new ItemInfo(6867), new ItemInfo(6868), 
            new ItemInfo(6869), new ItemInfo(6870), new ItemInfo(6871), new ItemInfo(6872), new ItemInfo(6873), new ItemInfo(6874), new ItemInfo(6875), new ItemInfo(6876), new ItemInfo(6877), 
            new ItemInfo(6878), new ItemInfo(6879), new ItemInfo(6880), new ItemInfo(6881), new ItemInfo(6882), new ItemInfo(6883), new ItemInfo(6884), new ItemInfo(6885), new ItemInfo(6886), 
            new ItemInfo(6887), new ItemInfo(6888), new ItemInfo(6889), new ItemInfo(6890), new ItemInfo(6891), new ItemInfo(6892), new ItemInfo(6893), new ItemInfo(6894), new ItemInfo(6895), 
            new ItemInfo(6896), new ItemInfo(6897), new ItemInfo(6898), new ItemInfo(6899), new ItemInfo(6900), new ItemInfo(6901), new ItemInfo(6902), new ItemInfo(6903), new ItemInfo(6904), 
            new ItemInfo(6905), new ItemInfo(6906), new ItemInfo(6907), new ItemInfo(6908), new ItemInfo(6909), new ItemInfo(6910), new ItemInfo(6911), new ItemInfo(6912), new ItemInfo(6913), 
            new ItemInfo(6914), new ItemInfo(6915), new ItemInfo(6916), new ItemInfo(6917), new ItemInfo(6918), new ItemInfo(6919), new ItemInfo(6920), new ItemInfo(6921), new ItemInfo(6922), 
            new ItemInfo(6923), new ItemInfo(6924), new ItemInfo(6925), new ItemInfo(6926), new ItemInfo(6927), new ItemInfo(6928), new ItemInfo(6929), new ItemInfo(6930), new ItemInfo(6931), 
            new ItemInfo(6932), new ItemInfo(6933), new ItemInfo(6934), new ItemInfo(6935), new ItemInfo(6936), new ItemInfo(6937), new ItemInfo(6938), new ItemInfo(6939), new ItemInfo(6940), 
            new ItemInfo(6941), new ItemInfo(6942), new ItemInfo(6943), new ItemInfo(6944), new ItemInfo(6945), new ItemInfo(6946), new ItemInfo(6947), new ItemInfo(6948), new ItemInfo(6949), 
            new ItemInfo(6950), new ItemInfo(6951), new ItemInfo(6952), new ItemInfo(6953), new ItemInfo(6954), new ItemInfo(6955), new ItemInfo(6956), new ItemInfo(6957), new ItemInfo(6958), 
            new ItemInfo(6959), new ItemInfo(6960), new ItemInfo(6961), new ItemInfo(6962), new ItemInfo(6963), new ItemInfo(6964), new ItemInfo(6965), new ItemInfo(6966), new ItemInfo(6967), 
            new ItemInfo(6968), new ItemInfo(6969), new ItemInfo(6970), new ItemInfo(6971), new ItemInfo(6972), new ItemInfo(6973), new ItemInfo(6974), new ItemInfo(6975), new ItemInfo(6976)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMiscPt16Gump()
			: this(0)
		{ }

		public AddMiscPt16Gump(int page) 
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

			from.SendGump(new AddMiscPt16Gump(page));
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
