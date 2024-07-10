/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Delphi            *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class PrizedLeather : Item
    {
        [Constructible]
        public PrizedLeather() : this( 1 )
        {
        }

        [Constructible]
        public PrizedLeather( int amount ) : base( 0x1081 )
        {
            Name = "Prized Leather";
            Stackable = true;
            Hue = 1337;
            Weight = 0.1;
            Amount = amount;
        }

        public PrizedLeather( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( 0 ); // version
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
