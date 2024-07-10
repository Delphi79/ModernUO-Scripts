/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
    public class ArrianasDiamond : Item
    {
        [Constructible]
        public ArrianasDiamond() : this( 1 )
        {
        }

        [Constructible]
        public ArrianasDiamond( int amount ) : base( 0xF26 )
        {
            Name = "Arrianas Diamond";
            Hue = 1154;
            Weight = 0.1;
            Amount = amount;
        }

        public ArrianasDiamond( Serial serial ) : base( serial )
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
