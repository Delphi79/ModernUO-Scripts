using System;
using Server.Network;

namespace Server.Items
{
    public class StaffOrb : Item
    {
        private Mobile m_Owner;
        private AccessLevel m_StaffLevel;
        public Point3D m_HomeLocation;
        public Map m_HomeMap;
        private bool m_AutoRes = true;

        [Constructible]
        public StaffOrb( ) : base( 0x0E2F )
        {
            LootType = LootType.Blessed;
            Weight = 0;
            Name = "Termax Staff Orb";
        }

        public StaffOrb( Serial serial ) : base( serial )
        {
        }

        [CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
        public Point3D HomeLocation
        {
            get
            {
                return m_HomeLocation;
            }
            set
            {
                m_HomeLocation = value;
            }
        }

        [CommandProperty( AccessLevel.Counselor, AccessLevel.GameMaster )]
        public Map HomeMap
        {
            get
            {
                return m_HomeMap;
            }
            set
            {
                m_HomeMap = value;
            }
        }

        [CommandProperty( AccessLevel.Counselor)]
        public bool AutoRes
        {
            get
            {
                return m_AutoRes;
            }
            set
            {
                m_AutoRes = value;
            }
        }

        public override DeathMoveResult OnInventoryDeath(Mobile parent)
        {
            if ( m_AutoRes && parent == m_Owner )
            {
                SwitchAccessLevels( parent );
                new AutoResTimer( parent ).Start();
            }
            return base.OnInventoryDeath (parent);
        }

        public override void OnDoubleClick(Mobile from)
        {
            // set owner if not already set -- this is only done the first time.
            if ( m_Owner == null )
            {
                m_Owner = from;
                Name = m_Owner.Name + "'s Staff Orb";
                HomeLocation = from.Location;
                HomeMap = from.Map;
                from.SendMessage( "This orb has been assigned to you." );
            }
            else
            {
                if ( m_Owner != from )
                {
                    from.SendMessage( "This is not yours to use." );
                }
                else
                {
                    if (from.AccessLevel == AccessLevel.Player)
                    {
                        from.NetState.SendSpeedControl(SpeedControlSetting.Mount);
                    }
                    else
                    {
                        from.NetState.SendSpeedControl(SpeedControlSetting.Disable);
                    }

                    SwitchAccessLevels(from);
                }
            }
        }

        private class AutoResTimer : Timer
        {
            private readonly Mobile m_Mobile;
            public AutoResTimer( Mobile mob ) : base( TimeSpan.FromSeconds( 5.0 ) )
            {
                m_Mobile = mob;
            }

            protected override void OnTick()
            {
                m_Mobile.Resurrect();
                m_Mobile.SendMessage( "As a staff member, you should be more careful in the future." );
                Stop();
            }

        }

        private void SwitchAccessLevels( Mobile from )
        {
            // check current access level
            if ( from.AccessLevel == AccessLevel.Player )
            {
                // return to staff status
                from.AccessLevel = m_StaffLevel;
                from.Blessed = true;
                from.Hidden = true;
                if(from.AccessLevel == AccessLevel.Counselor)
                {
                    from.Title = "[Counselor]";
                }
                if(from.AccessLevel == AccessLevel.GameMaster)
                {
                    from.Title = "[GM]";
                }
                if(from.AccessLevel == AccessLevel.Seer)
                {
                    from.Title = "[Seer]";
                }
                if(from.AccessLevel == AccessLevel.Administrator)
                {
                    from.Title = "[Admin]";
                }
                if(from.AccessLevel == AccessLevel.Developer)
                {
                    from.Title = "[Developer]";
                }
                if(from.AccessLevel == AccessLevel.Owner)
                {
                    from.Title = "[Owner]";
                }
            }
            else
            {
                m_StaffLevel = from.AccessLevel;
                from.AccessLevel = AccessLevel.Player;
                from.Blessed = false;
                from.Hidden = false;
                from.Title = null;
            }
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( 3 ); // version

            // version 3
            writer.Write( m_AutoRes );

            // version 2
            writer.Write( m_HomeLocation );
            writer.Write( m_HomeMap );

            writer.Write( m_Owner );
            writer.WriteEncodedInt( (int)m_StaffLevel );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
            switch ( version )
            {
                case 3:
                    {
                        m_AutoRes = reader.ReadBool();
                        goto case 2;
                    }
                case 2:
                    {
                        m_HomeLocation = reader.ReadPoint3D();
                        m_HomeMap = reader.ReadMap();
                        goto case 1;
                    }
                case 1:
                    {
                        m_Owner = reader.ReadEntity<Mobile>();
                        m_StaffLevel = (AccessLevel)reader.ReadEncodedInt();
                        break;
                    }

            }
        }

    }
}
