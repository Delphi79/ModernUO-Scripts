/****************************************
 * Author: Joeku                        *
 * Revised for MUO: Nerun & Delphi      *
 * For use with ModernUO                *
 * Client Tested with: 7.0.102.3        *
 * Version: 1.10                        *
 * Initial Release: 11/25/2007          *
 * Revision Date: 06/07/2024            *
 **************************************/

using System;
using Server;
using Server.Items;

namespace Joeku.SR
{
    public class SR_RuneGate : Moongate
    {
        public SR_RuneGate(Point3D target, Map map)
            : base(target, map)
        {
            this.Map = map;

            if (this.ShowFeluccaWarning && map == Map.Felucca)
                this.ItemID = 0xDDA;

            this.Dispellable = false;

            new InternalTimer(this).Start();
        }

        public SR_RuneGate(Serial serial)
            : base(serial)
        {
        }

        public override bool ShowFeluccaWarning => false;

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize(writer);
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize(reader);

            this.Delete();
        }

        private class InternalTimer : Timer
        {
            private readonly Item _item;

            public InternalTimer(Item item)
                : base(TimeSpan.FromSeconds(30.0))
            {
                _item = item;
            }

            protected override void OnTick()
            {
                _item.Delete();
            }
        }
    }
}
