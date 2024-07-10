/****************************************
 * Original Author Unknown              *
 * Updated for MUO by Admin Delphi      *
 * For use with ModernUO                *
 * Date: June 8, 2024                   *
 ****************************************/

namespace Server.Items
{
   public class DiamondHoopEarrings : Item
   {
      [Constructible]
      public DiamondHoopEarrings() : this( 1 )
      {
      }

      [Constructible]
      public DiamondHoopEarrings( int amount ) : base( 0x1F07 )
      {
	 Name = "Diamond Hoop Earrings";
	 Hue = 1154;
         Weight = 0.1;

      }

      public DiamondHoopEarrings( Serial serial ) : base( serial )
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
