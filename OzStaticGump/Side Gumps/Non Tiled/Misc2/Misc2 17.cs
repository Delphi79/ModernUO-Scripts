using Server.Network;

namespace Server.Gumps
{
	public class AddMisc2Pt17Gump : Gump
	{
		public static void Initialize()
		{
			CommandSystem.Register("AddMisc2Pt17", AccessLevel.GameMaster, new CommandEventHandler(AddMisc2Pt17_OnCommand));
		}

		[Usage("AddMisc2Pt17")]
		
		public static void AddMisc2Pt17_OnCommand(CommandEventArgs e)
		{
			e.Mobile.CloseGump<AddMisc2Pt17Gump>();
			e.Mobile.SendGump(new AddMisc2Pt17Gump());
		}

		public static ItemInfo[] m_Types = new ItemInfo[]
		{
            #region Floors
            new ItemInfo(18210), new ItemInfo(18211), new ItemInfo(18212), new ItemInfo(18213), new ItemInfo(18214), new ItemInfo(18215), new ItemInfo(18216), new ItemInfo(18217), new ItemInfo(18218), 
            new ItemInfo(18219), new ItemInfo(18220), new ItemInfo(18221), new ItemInfo(18222), new ItemInfo(18223), new ItemInfo(18224), new ItemInfo(18225), new ItemInfo(18226), new ItemInfo(18227), 
            new ItemInfo(18228), new ItemInfo(18229), new ItemInfo(18230), new ItemInfo(18231), new ItemInfo(18232), new ItemInfo(18233), new ItemInfo(18234), new ItemInfo(18235), new ItemInfo(18236), 
            new ItemInfo(18237), new ItemInfo(18238), new ItemInfo(18239), new ItemInfo(18240), new ItemInfo(18241), new ItemInfo(18242), new ItemInfo(18243), new ItemInfo(18244), new ItemInfo(18245), 
            new ItemInfo(18246), new ItemInfo(18247), new ItemInfo(18248), new ItemInfo(18249), new ItemInfo(18250), new ItemInfo(18251), new ItemInfo(18252), new ItemInfo(18253), new ItemInfo(18254), 
            new ItemInfo(18255), new ItemInfo(18256), new ItemInfo(18257), new ItemInfo(18258), new ItemInfo(18259), new ItemInfo(18260), new ItemInfo(18261), new ItemInfo(18262), new ItemInfo(18263), 
            new ItemInfo(18264), new ItemInfo(18265), new ItemInfo(18266), new ItemInfo(18267), new ItemInfo(18268), new ItemInfo(18269), new ItemInfo(18270), new ItemInfo(18271), new ItemInfo(18272), 
            new ItemInfo(18273), new ItemInfo(18274), new ItemInfo(18275), new ItemInfo(18276), new ItemInfo(18277), new ItemInfo(18278), new ItemInfo(18279), new ItemInfo(18280), new ItemInfo(18281), 
            new ItemInfo(18282), new ItemInfo(18283), new ItemInfo(18284), new ItemInfo(18285), new ItemInfo(18286), new ItemInfo(18287), new ItemInfo(18288), new ItemInfo(18289), new ItemInfo(18290), 
            new ItemInfo(18291), new ItemInfo(18292), new ItemInfo(18293), new ItemInfo(18294), new ItemInfo(18295), new ItemInfo(18296), new ItemInfo(18297), new ItemInfo(18298), new ItemInfo(18299), 
            new ItemInfo(18300), new ItemInfo(18320), new ItemInfo(18321), new ItemInfo(18322), new ItemInfo(18323), new ItemInfo(18324), new ItemInfo(18325), new ItemInfo(18330), new ItemInfo(18331), 
            new ItemInfo(18332), new ItemInfo(18333), new ItemInfo(18334), new ItemInfo(18335), new ItemInfo(18336), new ItemInfo(18337), new ItemInfo(18338), new ItemInfo(18339), new ItemInfo(18340), 
            new ItemInfo(18341), new ItemInfo(18342), new ItemInfo(18343), new ItemInfo(18344), new ItemInfo(18345), new ItemInfo(18346), new ItemInfo(18347), new ItemInfo(18348), new ItemInfo(18349), 
            new ItemInfo(18350), new ItemInfo(18351), new ItemInfo(18352), new ItemInfo(18353), new ItemInfo(18354), new ItemInfo(18355), new ItemInfo(18356), new ItemInfo(18357), new ItemInfo(18358), 
            new ItemInfo(18359), new ItemInfo(18360), new ItemInfo(18361), new ItemInfo(18362), new ItemInfo(18363), new ItemInfo(18364), new ItemInfo(18365), new ItemInfo(18366), new ItemInfo(18367), 
            new ItemInfo(18368), new ItemInfo(18369), new ItemInfo(18370), new ItemInfo(18371), new ItemInfo(18372), new ItemInfo(18373), new ItemInfo(18374), new ItemInfo(18375), new ItemInfo(18376), 
            new ItemInfo(18377), new ItemInfo(18378), new ItemInfo(18379), new ItemInfo(18380), new ItemInfo(18381), new ItemInfo(18382), new ItemInfo(18383), new ItemInfo(18384), new ItemInfo(18385), 
            new ItemInfo(18386), new ItemInfo(18387), new ItemInfo(18388), new ItemInfo(18389), new ItemInfo(18390), new ItemInfo(18391), new ItemInfo(18392), new ItemInfo(18393), new ItemInfo(18394), 
            new ItemInfo(18395), new ItemInfo(18396), new ItemInfo(18397), new ItemInfo(18398), new ItemInfo(18399), new ItemInfo(18400), new ItemInfo(18401), new ItemInfo(18402), new ItemInfo(18403), 
            new ItemInfo(18404), new ItemInfo(18405), new ItemInfo(18406), new ItemInfo(18407), new ItemInfo(18408), new ItemInfo(18409), new ItemInfo(18491), new ItemInfo(18492), new ItemInfo(18493), 
            new ItemInfo(18494), new ItemInfo(18495), new ItemInfo(18496), new ItemInfo(18497), new ItemInfo(18498), new ItemInfo(18499), new ItemInfo(18500), new ItemInfo(18501), new ItemInfo(18502), 
            new ItemInfo(18503), new ItemInfo(18504), new ItemInfo(18505), new ItemInfo(18506), new ItemInfo(18507), new ItemInfo(18508), new ItemInfo(18509), new ItemInfo(18510), new ItemInfo(18511), 
            new ItemInfo(18512), new ItemInfo(18513), new ItemInfo(18514), new ItemInfo(18515), new ItemInfo(18516), new ItemInfo(18517), new ItemInfo(18518), new ItemInfo(18519), new ItemInfo(18520), 
            new ItemInfo(18521), new ItemInfo(18522), new ItemInfo(18523), new ItemInfo(18524), new ItemInfo(18525), new ItemInfo(18526), new ItemInfo(18527), new ItemInfo(18528), new ItemInfo(18529), 
            new ItemInfo(18530), new ItemInfo(18531), new ItemInfo(18532), new ItemInfo(18533), new ItemInfo(18534), new ItemInfo(18535), new ItemInfo(18536), new ItemInfo(18537), new ItemInfo(18538), 
            new ItemInfo(18539), new ItemInfo(18540), new ItemInfo(18541), new ItemInfo(18542), new ItemInfo(18543), new ItemInfo(18544), new ItemInfo(18545), new ItemInfo(18546), new ItemInfo(18547), 
            new ItemInfo(18548), new ItemInfo(18549), new ItemInfo(18550), new ItemInfo(18551), new ItemInfo(18552), new ItemInfo(18553), new ItemInfo(18554), new ItemInfo(18555), new ItemInfo(18556), 
            new ItemInfo(18557), new ItemInfo(18558), new ItemInfo(18559), new ItemInfo(18560), new ItemInfo(18561), new ItemInfo(18562), new ItemInfo(18563), new ItemInfo(18564), new ItemInfo(18565), 
            new ItemInfo(18566), new ItemInfo(18567), new ItemInfo(18568), new ItemInfo(18569), new ItemInfo(18570), new ItemInfo(18571), new ItemInfo(18572), new ItemInfo(18573), new ItemInfo(18574), 
            new ItemInfo(18575), new ItemInfo(18576), new ItemInfo(18577), new ItemInfo(18578), new ItemInfo(18579), new ItemInfo(18580), new ItemInfo(18581), new ItemInfo(18582), new ItemInfo(18583), 
            new ItemInfo(18584), new ItemInfo(18585), new ItemInfo(18586), new ItemInfo(18587), new ItemInfo(18588), new ItemInfo(18589), new ItemInfo(18590), new ItemInfo(18591), new ItemInfo(18592), 
            new ItemInfo(18593), new ItemInfo(18594), new ItemInfo(18595), new ItemInfo(18596), new ItemInfo(18597), new ItemInfo(18598), new ItemInfo(18599), new ItemInfo(18600), new ItemInfo(18601), 
            new ItemInfo(18602), new ItemInfo(18603), new ItemInfo(18604), new ItemInfo(18605), new ItemInfo(18644), new ItemInfo(18645), new ItemInfo(18646), new ItemInfo(18647), new ItemInfo(18648), 
            new ItemInfo(18649), new ItemInfo(18650), new ItemInfo(18651), new ItemInfo(18652), new ItemInfo(18653), new ItemInfo(18654), new ItemInfo(18655), new ItemInfo(18656), new ItemInfo(18657), 
            new ItemInfo(18658), new ItemInfo(18659), new ItemInfo(18661), new ItemInfo(18662), new ItemInfo(18663), new ItemInfo(18664), new ItemInfo(18665), new ItemInfo(18666), new ItemInfo(18667), 
            new ItemInfo(18668), new ItemInfo(18669), new ItemInfo(18670), new ItemInfo(18671), new ItemInfo(18672), new ItemInfo(18673), new ItemInfo(18674), new ItemInfo(18675), new ItemInfo(18676), 
            new ItemInfo(18677), new ItemInfo(18678), new ItemInfo(18679), new ItemInfo(18680), new ItemInfo(18681), new ItemInfo(18682), new ItemInfo(18683), new ItemInfo(18684), new ItemInfo(18685), 
            new ItemInfo(18686), new ItemInfo(18687), new ItemInfo(18688), new ItemInfo(18689), new ItemInfo(18690), new ItemInfo(18691), new ItemInfo(18692), new ItemInfo(18693), new ItemInfo(18694), 
            new ItemInfo(18695), new ItemInfo(18696), new ItemInfo(18697), new ItemInfo(18698), new ItemInfo(18699), new ItemInfo(18700), new ItemInfo(18701), new ItemInfo(18702), new ItemInfo(18703), 
            new ItemInfo(18704), new ItemInfo(18705), new ItemInfo(18706), new ItemInfo(18707), new ItemInfo(18708), new ItemInfo(18709), new ItemInfo(18710), new ItemInfo(18711), new ItemInfo(18712)
            #endregion
        };

		private int m_Page;

		//private readonly int m_Type;

		public AddMisc2Pt17Gump()
			: this(0)
		{ }

		public AddMisc2Pt17Gump(int page) 
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

			from.SendGump(new AddMisc2Pt17Gump(page));
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
