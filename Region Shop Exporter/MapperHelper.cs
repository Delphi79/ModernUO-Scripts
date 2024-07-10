using System;
using System.Buffers.Binary;
using ModernUO.Serialization;
using Server.Network;

namespace Server.Items
{
    [SerializationGenerator(0, false)]
    public partial class MappingHelper : Item
    {
        private const ushort GMItemId = 0x1183;
        private static readonly TimeSpan Interval = TimeSpan.FromSeconds(5);
        private Timer m_Timer;

        [Constructible]
        public MappingHelper() : base(8612)
        {
            Movable = false;
            Hue = 2736;
            Name = "MappingHelper";
            StartTimer();
        }

        public MappingHelper(Serial serial) : base(serial)
        {
            StartTimer();
        }

        private void StartTimer()
        {
            if (m_Timer != null)
                m_Timer.Stop();

            m_Timer = Timer.DelayCall(Interval, Interval, SayPhrase);
        }

        private void SayPhrase()
        {
            if (Deleted || !this.IsAccessibleTo(null))
            {
                m_Timer?.Stop();
                return;
            }

            PublicOverheadMessage(MessageType.Regular, 2736, false, "Corner Here");
        }

        public override void OnDelete()
        {
            base.OnDelete();
            m_Timer?.Stop();
        }

        public override void SendWorldPacketTo(NetState ns, ReadOnlySpan<byte> world = default)
        {
            var mob = ns.Mobile;
            if (mob?.AccessLevel >= AccessLevel.GameMaster)
            {
                SendGMItem(ns);
            }
            else
            {
                base.SendWorldPacketTo(ns, world);
            }
        }

        private void SendGMItem(NetState ns)
        {
            // GM Packet
            Span<byte> buffer = stackalloc byte[OutgoingEntityPackets.MaxWorldEntityPacketLength].InitializePacket();

            int length;

            if (ns.StygianAbyss)
            {
                length = OutgoingEntityPackets.CreateWorldEntity(buffer, this, ns.HighSeas);
                BinaryPrimitives.WriteUInt16BigEndian(buffer[8..10], GMItemId);
            }
            else
            {
                length = OutgoingItemPackets.CreateWorldItem(buffer, this);
                BinaryPrimitives.WriteUInt16BigEndian(buffer[7..9], GMItemId);
            }

            ns.Send(buffer[..length]);
        }
    }
}
