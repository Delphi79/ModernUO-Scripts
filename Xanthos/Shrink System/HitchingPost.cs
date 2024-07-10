#region AuthorHeader
//
//	Shrink System version 2.1, by Xanthos
//
//
#endregion AuthorHeader
/****************************************
 * Original Author Xanthos              *
 * Modified for MUO by Delphi           *
 * For use with ModernUO                *
 * Date: June 13, 2024                  *
 ****************************************/
using Server;
using Server.Items;
using Xanthos.Interfaces;

namespace Xanthos.ShrinkSystem
{
    [Flippable( 0x14E8, 0x14E7 )]
    public class HitchingPost : AddonComponent, IShrinkTool
    {
        private int m_Charges = ShrinkConfig.ShrinkCharges;

        [CommandProperty( AccessLevel.GameMaster )]
        public int ShrinkCharges
        {
            get { return m_Charges; }
            set
            {
                if ( 0 == m_Charges || 0 == (m_Charges = value ))
                    Delete();
                else
                    InvalidateProperties();
            }
        }

        public override bool ForceShowProperties{ get{ return ObjectPropertyList.Enabled; }}

        [Constructible]
        public HitchingPost() : this( 0x14E7 )
        {
        }

        [Constructible]
        public HitchingPost( int itemID ) : base( itemID )
        {
        }

        public HitchingPost( Serial serial ) : base( serial )
        {
        }

        public virtual void AddNameProperties( ObjectPropertyList list )
        {
            base.AddNameProperties( list );

            if ( m_Charges >= 0 )
                list.Add(1060658, string.Format("Charges\t{0}", m_Charges));

        }

        public override void OnDoubleClick( Mobile from )
        {
            if( from.InRange( this.GetWorldLocation(), 2 ) == false )
                from.SendLocalizedMessage( 500486 ); //That is too far away.

            else if ( from.Skills[SkillName.AnimalTaming].Value >= ShrinkConfig.TamingRequired )
                from.Target = new ShrinkTarget( from, this, false );

            else
                from.SendMessage( "You must have at least " + ShrinkConfig.TamingRequired + " animal taming to use a hitching post." );
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 ); // version
            writer.Write( m_Charges );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );
            int version = reader.ReadInt();
            m_Charges = reader.ReadInt();
        }
    }

    public class HitchingPostEastAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new HitchingPostEastDeed(); }}

        [Constructible]
        public HitchingPostEastAddon()
        {
            AddComponent( new HitchingPost( 0x14E7 ), 0, 0, 0);
        }

        public HitchingPostEastAddon( Serial serial ) : base( serial )
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

    public class HitchingPostEastDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new HitchingPostEastAddon(); }}

        [Constructible]
        public HitchingPostEastDeed()
        {
            Name = "Hitching Post (east)";
        }

        public HitchingPostEastDeed( Serial serial ) : base( serial )
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


    public class HitchingPostSouthAddon : BaseAddon
    {
        public override BaseAddonDeed Deed{ get{ return new HitchingPostSouthDeed(); }}

        [Constructible]
        public HitchingPostSouthAddon()
        {
            AddComponent( new HitchingPost( 0x14E8 ), 0, 0, 0);
        }

        public HitchingPostSouthAddon( Serial serial ) : base( serial )
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

    public class HitchingPostSouthDeed : BaseAddonDeed
    {
        public override BaseAddon Addon{ get{ return new HitchingPostSouthAddon(); }}

        [Constructible]
        public HitchingPostSouthDeed()
        {
            Name = "Hitching Post (south)";
        }

        public HitchingPostSouthDeed( Serial serial ) : base( serial )
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
