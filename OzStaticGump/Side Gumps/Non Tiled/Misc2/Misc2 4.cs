using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt4Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt4", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt4_OnCommand));
		}

		[Usage("AddMisc2Pt4")]
		
		public static void AddMisc2Pt4_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt4Gump>();
			e.Mobile.SendGump(new AddMisc2Pt4Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(8788), new ItemInfo(8789), new ItemInfo(8790), new ItemInfo(8791), new ItemInfo(8792), new ItemInfo(8793), new ItemInfo(8794), new ItemInfo(8795), new ItemInfo(8796), 
            new ItemInfo(8797), new ItemInfo(8798), new ItemInfo(8799), new ItemInfo(8800), new ItemInfo(8801), new ItemInfo(8802), new ItemInfo(8803), new ItemInfo(8804), new ItemInfo(8805), 
            new ItemInfo(8806), new ItemInfo(8807), new ItemInfo(8808), new ItemInfo(8809), new ItemInfo(8810), new ItemInfo(8811), new ItemInfo(8812), new ItemInfo(8813), new ItemInfo(8814), 
            new ItemInfo(8815), new ItemInfo(8816), new ItemInfo(8817), new ItemInfo(8818), new ItemInfo(8819), new ItemInfo(8820), new ItemInfo(8821), new ItemInfo(8822), new ItemInfo(8823), 
            new ItemInfo(8824), new ItemInfo(8825), new ItemInfo(8826), new ItemInfo(8827), new ItemInfo(8828), new ItemInfo(8829), new ItemInfo(8830), new ItemInfo(8831), new ItemInfo(8832), 
            new ItemInfo(8833), new ItemInfo(8834), new ItemInfo(8835), new ItemInfo(8836), new ItemInfo(8837), new ItemInfo(8838), new ItemInfo(8839), new ItemInfo(8840), new ItemInfo(8841), 
            new ItemInfo(8842), new ItemInfo(8843), new ItemInfo(8844), new ItemInfo(8845), new ItemInfo(8846), new ItemInfo(8847), new ItemInfo(8848), new ItemInfo(8849), new ItemInfo(8850), 
            new ItemInfo(8851), new ItemInfo(8852), new ItemInfo(8853), new ItemInfo(8854), new ItemInfo(8855), new ItemInfo(8856), new ItemInfo(8857), new ItemInfo(8858), new ItemInfo(8859), 
            new ItemInfo(8860), new ItemInfo(8861), new ItemInfo(8862), new ItemInfo(8863), new ItemInfo(8864), new ItemInfo(8865), new ItemInfo(8866), new ItemInfo(8867), new ItemInfo(8868), 
            new ItemInfo(8869), new ItemInfo(8870), new ItemInfo(8871), new ItemInfo(8872), new ItemInfo(8873), new ItemInfo(8874), new ItemInfo(8875), new ItemInfo(8876), new ItemInfo(8877), 
            new ItemInfo(8878), new ItemInfo(8879), new ItemInfo(8880), new ItemInfo(8881), new ItemInfo(8882), new ItemInfo(8883), new ItemInfo(8884), new ItemInfo(8885), new ItemInfo(8886), 
            new ItemInfo(8887), new ItemInfo(8888), new ItemInfo(8889), new ItemInfo(8890), new ItemInfo(8891), new ItemInfo(8892), new ItemInfo(8893), new ItemInfo(8894), new ItemInfo(8895), 
            new ItemInfo(8896), new ItemInfo(8897), new ItemInfo(8898), new ItemInfo(8899), new ItemInfo(8900), new ItemInfo(8901), new ItemInfo(8902), new ItemInfo(8903), new ItemInfo(8904), 
            new ItemInfo(8905), new ItemInfo(8906), new ItemInfo(8907), new ItemInfo(8908), new ItemInfo(8909), new ItemInfo(8910), new ItemInfo(8911), new ItemInfo(8912), new ItemInfo(8913), 
            new ItemInfo(8914), new ItemInfo(8915), new ItemInfo(8916), new ItemInfo(8917), new ItemInfo(8918), new ItemInfo(8919), new ItemInfo(8920), new ItemInfo(8921), new ItemInfo(8922), 
            new ItemInfo(8923), new ItemInfo(8924), new ItemInfo(8925), new ItemInfo(8926), new ItemInfo(8927), new ItemInfo(8928), new ItemInfo(8929), new ItemInfo(8930), new ItemInfo(8931), 
            new ItemInfo(8932), new ItemInfo(8933), new ItemInfo(8934), new ItemInfo(8935), new ItemInfo(8936), new ItemInfo(8937), new ItemInfo(8938), new ItemInfo(8939), new ItemInfo(8940), 
            new ItemInfo(8941), new ItemInfo(8942), new ItemInfo(8943), new ItemInfo(8944), new ItemInfo(8945), new ItemInfo(8946), new ItemInfo(8947), new ItemInfo(8948), new ItemInfo(8949), 
            new ItemInfo(8950), new ItemInfo(8951), new ItemInfo(8952), new ItemInfo(8953), new ItemInfo(8954), new ItemInfo(8955), new ItemInfo(8956), new ItemInfo(8957), new ItemInfo(8958), 
            new ItemInfo(8959), new ItemInfo(8960), new ItemInfo(8961), new ItemInfo(8962), new ItemInfo(8963), new ItemInfo(8964), new ItemInfo(8977), new ItemInfo(8978), new ItemInfo(8979), 
            new ItemInfo(8980), new ItemInfo(8981), new ItemInfo(8982), new ItemInfo(8983), new ItemInfo(8984), new ItemInfo(8985), new ItemInfo(8986), new ItemInfo(8987), new ItemInfo(8988), 
            new ItemInfo(8989), new ItemInfo(8990), new ItemInfo(8991), new ItemInfo(8992), new ItemInfo(8993), new ItemInfo(8994), new ItemInfo(8995), new ItemInfo(8996), new ItemInfo(8997), 
            new ItemInfo(8998), new ItemInfo(8999), new ItemInfo(9000), new ItemInfo(9001), new ItemInfo(9002), new ItemInfo(9003), new ItemInfo(9004), new ItemInfo(9005), new ItemInfo(9006), 
            new ItemInfo(9007), new ItemInfo(9008), new ItemInfo(9009), new ItemInfo(9010), new ItemInfo(9011), new ItemInfo(9012), new ItemInfo(9013), new ItemInfo(9014), new ItemInfo(9015), 
            new ItemInfo(9016), new ItemInfo(9017), new ItemInfo(9018), new ItemInfo(9019), new ItemInfo(9020), new ItemInfo(9021), new ItemInfo(9022), new ItemInfo(9023), new ItemInfo(9024)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt4Gump()
			: this(0)
		{ }

		public AddMisc2Pt4Gump(int page) 
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

			from.SendGump(new AddMisc2Pt4Gump(page));
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
