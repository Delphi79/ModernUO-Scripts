/****************************************
 * Script Name: GMEthereal.cs           *
 * Author: snicker7                     *
 * Revised for MUO: Delphi              *
 * For use with ModernUO                *
 * Client Tested with: 7.0.102.3        *
 * Version: 1.10                        *
 * Initial Release: 03/26/2006          *
 * Revision Date: 06/07/2024            *
 **************************************/

namespace Server.Mobiles
{
    public class GMEthereal : EtherealMount
    {
        private static readonly EtherealInfo[] EthyItemTypes = new EtherealInfo[]
        {
            new EtherealInfo(0x20DD, 0x3EAA), //Horse
            new EtherealInfo(0x20F6, 0x3EAB), //Llama
            new EtherealInfo(0x2135, 0x3EAC), //Ostard
            new EtherealInfo(8501, 16035),    //DesertOstard
            new EtherealInfo(8502, 16036),    //FrenziedOstard
            new EtherealInfo(0x2615, 0x3E9A), //Ridgeback
            new EtherealInfo(0x25CE, 0x3E9B), //Unicorn
            new EtherealInfo(0x260F, 0x3E97), //Beetle
            new EtherealInfo(0x25A0, 0x3E9C), //Kirin
            new EtherealInfo(0x2619, 0x3E98), //SwampDragon
            new EtherealInfo(9751, 16059),    //SkeletalMount
            new EtherealInfo(10090, 16020),   //Hiryu
            new EtherealInfo(11676, 16018),   //ChargerOfTheFallen
            new EtherealInfo(9658, 16051),    //SeaHorse
            new EtherealInfo(11669, 16016),   //Chimera
            new EtherealInfo(11670, 16017),   //CuSidhe
            new EtherealInfo(8417, 16069),    //PolarBear
            new EtherealInfo(0x46f8, 0x3EC6), //Boura
            new EtherealInfo(0x9844, 0x3EC7)  //Tiger
        };

        private EtherealTypes m_EthyType;

        [Constructible]
        public GMEthereal()
            : this(EtherealTypes.Horse)
        {
        }

        [Constructible]
        public GMEthereal(EtherealTypes type)
            : base(0, 0)
        {
            EthyType = type;
            LootType = LootType.Blessed;
            Hue = 2406;
        }

        public GMEthereal(Serial serial)
            : base(serial)
        {
        }

        public enum EtherealTypes
        {
            Horse,
            Llama,
            Ostard,
            OstardDesert,
            OstardFrenzied,
            Ridgeback,
            Unicorn,
            Beetle,
            Kirin,
            SwampDragon,
            SkeletalHorse,
            Hiryu,
            ChargerOfTheFallen,
            SeaHorse,
            Chimera,
            CuSidhe,
            PolarBear,
            Boura,
            Tiger
        }

        [CommandProperty(AccessLevel.Counselor)]
        public EtherealTypes EthyType
        {
            get => m_EthyType;
            set
            {
                if ((int)value >= EthyItemTypes.Length)
                    return;

                m_EthyType = value;
                MountedID = EthyItemTypes[(int)value].MountedID;
                RegularID = EthyItemTypes[(int)value].RegularID;
            }
        }

        public override string DefaultName => "A GM's Ethereal Mount";

        public override int FollowerSlots => 0;

        public override void OnDoubleClick(Mobile from)
        {
            if (from.AccessLevel > AccessLevel.Player)
            {
                if (from.Mounted)
                {
                    from.SendLocalizedMessage(1005583); // Please dismount first.
                }
                else if (from.HasTrade)
                {
                    from.SendLocalizedMessage(1042317, "", 0x41); // You may not ride at this time.
                }
                else if (Multis.DesignContext.Check(from))
                {
                    if (!Deleted && Rider == null && IsChildOf(from.Backpack))
                    {
                        Rider = from;
                        if (MountedID == 16051)
                            Rider.CanSwim = true;
                    }
                }
            }
            else
            {
                from.SendMessage("Players cannot ride this. Sorry, BALEETED!");
                Delete();
            }
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
            writer.Write((int)m_EthyType);
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            m_EthyType = (EtherealTypes)reader.ReadInt();
        }

        public struct EtherealInfo
        {
            public int RegularID;
            public int MountedID;

            public EtherealInfo(int id, int mid)
            {
                RegularID = id;
                MountedID = mid;
            }
        }
    }

    public class GMEthVirtual : EtherealMount
    {
        public GMEthVirtual(int id, int mid)
            : base(id, mid)
        {
        }

        public GMEthVirtual(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
            Delete();
        }
    }
}
