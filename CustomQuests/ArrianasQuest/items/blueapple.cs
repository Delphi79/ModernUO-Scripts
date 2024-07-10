/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class Blueapple : Item
    {
        [Constructible]
        public Blueapple() : this( 1 )
        {
        }

        [Constructible]
        public Blueapple( int amount ) : base( 0x9D0 )
        {
            Name = "blue apple";
            Hue = 6;
            Weight = 0.1;
            Amount = amount;
        }

        public Blueapple( Serial serial ) : base( serial )
        {
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( (int) 0 ); // version
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
