/****************************************
 * Created by Admin Delphi              *
 * For use with ModernUO                *
 * Date: June 1, 2024                   *
 ****************************************/

using System;

namespace Server.Items
{
    public class ColorChangingRobe : BaseOuterTorso
    {
        // Configuration Section
        private static readonly int HueStart = 20; // Starting hue for the range
        private static readonly int HueRange = 106;  // # of hues to cycle through
        private static readonly TimeSpan ColorChangeInterval = TimeSpan.FromSeconds(0.25); // Speed

        private Timer m_ColorChangeTimer;

        [Constructible]
        public ColorChangingRobe() : base(0x1F03)
        {
            Name = "Color Changing Robe";
            LootType = LootType.Blessed;
        }

        public ColorChangingRobe(Serial serial) : base(serial)
        {
        }

        private void StartColorChange()
        {
            StopColorChange();

            m_ColorChangeTimer = Timer.DelayCall(TimeSpan.Zero, ColorChangeInterval, () =>
            {
                if (Deleted || !(Parent is Mobile))
                {
                    StopColorChange();
                    return;
                }

                Hue = Utility.Random(HueStart, HueRange); // Random hue within the specified range
            });
        }

        private void StopColorChange()
        {
            m_ColorChangeTimer?.Stop();
            m_ColorChangeTimer = null;
        }

        public override void OnAdded(IEntity parent)
        {
            base.OnAdded(parent);

            if (parent is Mobile)
            {
                StartColorChange();
            }
        }

        public override void OnRemoved(IEntity parent)
        {
            base.OnRemoved(parent);

            if (parent is Mobile)
            {
                StopColorChange();
            }
        }

        public override void OnAfterDelete()
        {
            base.OnAfterDelete();
            StopColorChange();
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
