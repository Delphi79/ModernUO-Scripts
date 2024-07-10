/****************************************
 * Original Author CEO                  *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 7, 2024                   *
 ****************************************/

using System;
using Server.Gumps;
using System.Collections;

namespace Server.Items
{
    public class TurboSlotStats : Item
    {
        public enum PaybackType { Loose, Normal, Tight, ExtremelyTight, CasinoCheats, Random }
        private TimeSpan m_UpdateTimer = TimeSpan.FromHours(24); // Minimum time to regenerate the slot array
        private DateTime m_LastBuild = DateTime.Now;
        private TimeSpan m_TimeOut;
        private bool m_refresh;
        ArrayList itemarray;
        ArrayList turboslotsarray = new ArrayList();

        [CommandProperty(AccessLevel.GameMaster)]
        public bool RefreshSlotList
        {
            get { return m_refresh; }
            set {
                if (value)
                    BuildArrayList(null);
                m_refresh = false;
            }
        }

        [CommandProperty(AccessLevel.GameMaster)]
        public TimeSpan NextRefresh
        {
            get { return (m_UpdateTimer - (DateTime.Now - m_LastBuild)); }
        }

        [Constructible]
        public TurboSlotStats()
            : base(8977)
        {
            Movable = false;
            Hue = 56;
            Name = "TurboSlots Top Ten";
        }

        public override void OnDoubleClick(Mobile from)
        {
            if ((!from.InRange(GetWorldLocation(), 2) || !from.InLOS(this)) && from.AccessLevel == AccessLevel.Player)
            {
                from.SendLocalizedMessage(500446); // That is too far away.
                return;
            }
            m_TimeOut = DateTime.Now - m_LastBuild;
            if (m_UpdateTimer < m_TimeOut || itemarray == null)
                BuildArrayList(from);
            else if (turboslotsarray != null)
            {
                foreach (TurboSlot t in turboslotsarray)
                {
                    if ((t == null || t.Deleted) )
                    {
                        BuildArrayList(from);
                        break;
                    }
                }
            }
            if (turboslotsarray != null)
            {
                from.CloseGump<TurboSlotsStatGump>();

                from.SendGump(new TurboSlotsStatGump(from, turboslotsarray));
            }
        }

        public void BuildArrayList(Mobile from)
        {
            try
            {
                // Initialize itemarray to avoid potential null reference
                itemarray = new ArrayList(World.Items.Values);
                m_LastBuild = DateTime.Now;

                // Initialize turboslotsarray if it is null
                if (turboslotsarray == null)
                {
                    turboslotsarray = new ArrayList();
                }

                // Clear turboslotsarray if it contains items
                if (turboslotsarray.Count > 0)
                {
                    turboslotsarray.Clear();
                }

                // Iterate through itemarray and add TurboSlot items to turboslotsarray
                foreach (Item i in itemarray)
                {
                    if (i is TurboSlot && !i.Deleted)
                    {
                        turboslotsarray.Add(i);
                    }
                }
            }
            catch
            {
                if (from != null)
                {
                    from.SendMessage("Unable to search World.Items");
                }
            }
        }

        public TurboSlotStats(Serial serial)
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
        }
    }
}
