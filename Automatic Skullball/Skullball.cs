/****************************************
 * Originally Created by Joeku          *
 * Updated by Admin Delphi              *
 * For use with ModernUO                *
 * Date: June 7, 2024                   *
 ****************************************/
using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;

namespace Server.Items
{
    public class Skullball : Item
    {
        private int m_silverscore;
        private int m_goldscore;
        //private int m_101 = 0;
        //private int m_102;
        private int m_Xp;
        private int m_Yp;
        private int m_Xn;
        private int m_Yn;
        private int m_silverb1;
        private int m_silverb2;
        private int m_silverb3;
        private int m_silverb4;
        private int m_goldb1;
        private int m_goldb2;
        private int m_goldb3;
        private int m_goldb4;
        private int m_HomeY;
        private int m_HomeX;
        private Mobile m_AllowedPlayer1;
        private Mobile m_AllowedPlayer2;
        private bool m_GiveReward = true;
        private bool m_FreezePlayers = true;
        private double m_FreezeTime = 3.0;
        private int m_GiveRewardMinTeamCount = 1;
        private bool m_DisplayDateOnReward = true;
        private bool m_DisplayNameOnReward = true;
        private bool m_DisplayTeamCountOnReward = true;


        [CommandProperty( AccessLevel.Administrator )]
        public int Yp{ get => m_Yp;
            set => m_Yp = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int Xp{ get => m_Xp;
            set => m_Xp = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int Yn{ get => m_Yn;
            set => m_Yn = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int Xn{ get => m_Xn;
            set => m_Xn = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int silverb1{ get => m_silverb1;
            set => m_silverb1 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int silverb2{ get => m_silverb2;
            set => m_silverb2 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int silverb3{ get => m_silverb3;
            set => m_silverb3 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int silverb4{ get => m_silverb4;
            set => m_silverb4 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int goldb1{ get => m_goldb1;
            set => m_goldb1 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int goldb2{ get => m_goldb2;
            set => m_goldb2 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int goldb3{ get => m_goldb3;
            set => m_goldb3 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int goldb4{ get => m_goldb4;
            set => m_goldb4 = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int HomeX{ get => m_HomeX;
            set => m_HomeX = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int HomeY{ get => m_HomeY;
            set => m_HomeY = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int silverscore{ get => m_silverscore;
            set => m_silverscore = value;
        }
        [CommandProperty( AccessLevel.Administrator )]
        public int goldscore{ get => m_goldscore;
            set => m_goldscore = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public Mobile MobileSilverTeam{ get => m_AllowedPlayer1;
            set => m_AllowedPlayer1 = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public Mobile MobileGoldTeam{ get => m_AllowedPlayer2;
            set => m_AllowedPlayer2 = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public bool GiveReward{ get => m_GiveReward;
            set => m_GiveReward = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public bool FreezePlayers{ get => m_FreezePlayers;
            set => m_FreezePlayers = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public double FreezeTime{ get => m_FreezeTime;
            set => m_FreezeTime = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public int GiveRewardMinTeamCount{ get => m_GiveRewardMinTeamCount;
            set => m_GiveRewardMinTeamCount = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public bool DisplayDateOnReward{ get => m_DisplayDateOnReward;
            set => m_DisplayDateOnReward = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public bool DisplayNameOnReward{ get => m_DisplayNameOnReward;
            set => m_DisplayNameOnReward = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public bool DisplayTeamCountOnReward{ get => m_DisplayTeamCountOnReward;
            set => m_DisplayTeamCountOnReward = value;
        }


        [Constructible]
        public Skullball() : base( 6880 )
        {
            Movable = false;
            Hue = 1152;
            Name = "a skullball";
            Light = LightType.Circle300;
        }

        public Skullball( Serial serial ) : base( serial )
        {
        }

        public void goldteamb()
        {
            X = m_HomeX;
            Y = m_HomeY + Utility.RandomMinMax(-1,1);	// Added this to offset the skullball, either 1 up, 1 down, or in the middle.

            if( m_goldscore >= 10)
            {
                var oldgoldscore = m_goldscore;
                var oldsilverscore = m_silverscore;
                m_goldscore = 0;
                m_silverscore = 0;
                SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );

                if( m_AllowedPlayer2 != null )
                    m_AllowedPlayer2.Say( "Gold won! The final score is "+ oldgoldscore +" to " + oldsilverscore + ".");
                if( m_AllowedPlayer1 != null )
                    m_AllowedPlayer1.Say( "Gold won! The final score is "+ oldgoldscore +" to " + oldsilverscore + ".");

                return;
            }

            if( m_AllowedPlayer2 != null )
            {
                if( m_goldscore > m_silverscore )
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Gold is winning, the score is " + m_goldscore + " to " + m_silverscore + ".");
                }
                else if( m_goldscore < m_silverscore )
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Silver is winning, the score is " + m_silverscore + " to " + m_goldscore + ".");
                }
                else
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Both teams are tied, the score is " + m_goldscore + " to " + m_silverscore + ".");
                }
            }

            if( m_AllowedPlayer1 != null )
            {
                if( m_goldscore > m_silverscore )
                    m_AllowedPlayer1.Say( "Gold is winning, the score is " + m_goldscore + " to " + m_silverscore + ".");
                else if( m_goldscore < m_silverscore )
                    m_AllowedPlayer1.Say( "Silver is winning, the score is " + m_silverscore + " to " + m_goldscore + ".");
                else
                    m_AllowedPlayer1.Say( "Both teams are tied, the score is " + m_goldscore + " to " + m_silverscore + ".");
            }
        }

        public void silverteamb()
        {
            X = m_HomeX;
            Y = m_HomeY + Utility.RandomMinMax(-1,1);	// Added this to offset the skullball, either 1 up, 1 down, or in the middle.

            if( m_silverscore >= 10)
            {
                var oldgoldscore = m_goldscore;
                var oldsilverscore = m_silverscore;
                m_goldscore = 0;
                m_silverscore = 0;
                SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );

                if( m_AllowedPlayer2 != null )
                    m_AllowedPlayer2.Say( "Silver won! The final score is "+ oldsilverscore +" to " + oldgoldscore + ".");
                if( m_AllowedPlayer1 != null )
                    m_AllowedPlayer1.Say( "Silver won! The final score is "+ oldsilverscore +" to " + oldgoldscore + ".");

                return;
            }

            if( m_AllowedPlayer2 != null )
            {
                if( m_goldscore > m_silverscore )
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Gold is winning, the score is " + m_goldscore + " to " + m_silverscore + ".");
                }
                else if( m_goldscore < m_silverscore )
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Silver is winning, the score is " + m_silverscore + " to " + m_goldscore + ".");
                }
                else
                {
                    SetHue( m_AllowedPlayer1.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer1, m_AllowedPlayer2.FindItemOnLayer( Layer.OuterTorso ), m_AllowedPlayer2, this );
                    m_AllowedPlayer2.Say( "Both teams are tied, the score is " + m_goldscore + " to " + m_silverscore + ".");
                }
            }

            if( m_AllowedPlayer1 != null )
            {
                if( m_goldscore > m_silverscore )
                    m_AllowedPlayer1.Say( "Gold is winning, the score is " + m_goldscore + " to " + m_silverscore + ".");
                else if( m_goldscore < m_silverscore )
                    m_AllowedPlayer1.Say( "Silver is winning, the score is " + m_silverscore + " to " + m_goldscore + ".");
                else
                    m_AllowedPlayer1.Say( "Both teams are tied, the score is " + m_goldscore + " to " + m_silverscore + ".");
            }
        }

        public virtual void StartMoveBack( Mobile m )
        {
            Timer.DelayCall(TimeSpan.FromSeconds(0.0), () => MoveBack_Callback(m));
        }

        private void MoveBack_Callback( object state )
        {
            MoveBack( (Mobile) state );
        }

        public virtual void MoveBack( Mobile m )
        {
            if( m is PlayerMobile )
            {
                Map map = Map;

                if ( map == null || map == Map.Internal )
                    map = m.Map;

                if (m_goldscore == 0 && m_silverscore == 0) // This was set to 10 && 10 but it didn't work because the scores are reset prior to calling this method. It's ok though, this gets it done.
                {
                    var items = m.Map.GetItemsInRange(m.Location, 30);

                    foreach (Item g in items)
                    {
                        if (g is SkullballExitGate gate)
                        {
                            gate.OnMoveOver(m);
                        }
                    }

                    return;
                }

                if( m.SolidHueOverride == 2125 )	// Move gold players back to their side
                {
                    Point3D p = new Point3D( (m_HomeX - Utility.RandomMinMax(7,8)) , (m_HomeY + Utility.RandomMinMax(-2,2)), Z );
                    m.MoveToWorld( p, map );
                    if( m_FreezePlayers )
                    {
                        m.CantWalk = true;
                        StartUnfreezePlayers(m);
                    }
                }
                else if( m.SolidHueOverride == 2101 )	// Move silver players back to their side
                {
                    Point3D p = new Point3D( (m_HomeX + Utility.RandomMinMax(7,8)), (m_HomeY + Utility.RandomMinMax(-2,2)), Z );
                    m.MoveToWorld( p, map );
                    if( m_FreezePlayers )
                    {
                        m.CantWalk = true;
                        StartUnfreezePlayers(m);
                    }
                }
            }
        }

        public virtual void UnfreezePlayers( Mobile m )
        {
            if( m is PlayerMobile && m.CantWalk )
                m.CantWalk = false;
        }

        public virtual void StartUnfreezePlayers( Mobile m )
        {
            if( m_FreezeTime < 0.0 )	// Safety Min.
                m_FreezeTime = 0.0;
            if( m_FreezeTime > 60.0 )	// Safety Max.
                m_FreezeTime = 60.0;

            Timer.DelayCall(TimeSpan.FromSeconds(m_FreezeTime), () => UnfreezePlayers_Callback(m));
        }

        private void UnfreezePlayers_Callback( object state )
        {
            UnfreezePlayers( (Mobile)state );
        }

        public void bc()
        {
            ArrayList mobs = new ArrayList( World.Mobiles.Values );

            int goldteamcount = 0;
            int silverteamcount = 0;

            foreach ( Mobile ko in mobs )
            {
                if( ko is PlayerMobile )
                {
                    if ( ko.SolidHueOverride == 2101 )
                    {
                        silverteamcount++;	// count the number of players who are silver
                    }
                    if ( ko.SolidHueOverride == 2125 )
                    {
                        goldteamcount++;	// count the number of players who are gold
                    }
                }
            }
            foreach ( Mobile ko in mobs )
            {
                if ( ( ko is PlayerMobile )  )
                {
                    if ( ko.SolidHueOverride == 2101 || ko.SolidHueOverride == 2125 )
                    {
                        if( m_goldscore >= 10)
                        {
                            if( m_AllowedPlayer2 != null )
                                ko.SendMessage( ko.SolidHueOverride, "Gold won! The final score is "+ m_goldscore +" to " + m_silverscore + ".");
                            if( m_AllowedPlayer1 != null )
                                ko.SendMessage( ko.SolidHueOverride, "Gold won! The final score is "+ m_goldscore +" to " + m_silverscore + ".");

                            if( ko.SolidHueOverride == 2125 && m_GiveReward )	//Gold Winners Reward
                            {
                                if( goldteamcount >= m_GiveRewardMinTeamCount && silverteamcount >= m_GiveRewardMinTeamCount )
                                {
                                    Item prize = Loot.RandomStatue();
                                    prize.Hue = 2125;
                                    prize.Name = ( DisplayNameOnReward ? ko.Name + ": " : "" ) + "Skullball Winner *** GOLD TEAM *** " + ( DisplayTeamCountOnReward ? "[" + goldteamcount + "v" + silverteamcount + "] " : "" ) + ( DisplayDateOnReward ? DateTime.Now.ToString() : "" );
                                    prize.LootType = LootType.Blessed;
                                    ko.AddToBackpack( prize );
                                }
                                else
                                {
                                    ko.SendMessage( 33, "There was not enough players to qualify for a trophy." );
                                }
                            }

                            return;
                        }

                        if( m_silverscore >= 10)
                        {
                            if( m_AllowedPlayer2 != null )
                                ko.SendMessage( ko.SolidHueOverride, "Silver won! The final score is "+ m_silverscore +" to " + m_goldscore + ".");
                            if( m_AllowedPlayer1 != null )
                                ko.SendMessage( ko.SolidHueOverride, "Silver won! The final score is "+ m_silverscore +" to " + m_goldscore + ".");

                            if( ko.SolidHueOverride == 2101 && m_GiveReward )	// Silver Winners Reward
                            {
                                if( goldteamcount >= m_GiveRewardMinTeamCount && silverteamcount >= m_GiveRewardMinTeamCount )
                                {
                                    Item prize = Loot.RandomStatue();
                                    prize.Hue = 2101;
                                    prize.Name = ( DisplayNameOnReward ? ko.Name + ": " : "" ) + "Skullball Winner *** SILVER TEAM *** " + ( DisplayTeamCountOnReward ? "[" + silverteamcount + "v" + goldteamcount + "] " : "" ) + ( DisplayDateOnReward ? DateTime.Now.ToString() : "" );
                                    prize.LootType = LootType.Blessed;
                                    ko.AddToBackpack( prize );
                                }
                                else
                                {
                                    ko.SendMessage( 33, "There was not enough players to qualify for a trophy." );
                                }
                            }


                            return;
                        }


                        if( m_goldscore > m_silverscore )
                            ko.SendMessage( ko.SolidHueOverride, "Gold is winning, the score is " + m_goldscore + " to " + m_silverscore + ".");
                        else if( m_goldscore < m_silverscore )
                            ko.SendMessage( ko.SolidHueOverride, "Silver is winning, the score is " + m_silverscore + " to " + m_goldscore + ".");
                        else
                            ko.SendMessage( ko.SolidHueOverride, "Both teams are tied, the score is " + m_goldscore + " to " + m_silverscore + ".");

                    }
                }
            }
        }

        public static void SetHue(Item g, Mobile a, Item r, Mobile s, Skullball b)
        {
            if( b.goldscore > b.silverscore )
            {
                if( g != null )
                    g.Hue = 2125;
                if( a != null )
                    a.SpeechHue = 2125;
                if( r != null )
                    r.Hue = 2125;
                if( s != null )
                    s.SpeechHue = 2125;
                b.Hue = 2125;
            }
            else if( b.silverscore > b.goldscore )
            {
                if( g != null )
                    g.Hue = 2101;
                if( a != null )
                    a.SpeechHue = 2101;
                if( r != null )
                    r.Hue = 2101;
                if( s != null )
                    s.SpeechHue = 2101;
                b.Hue = 2101;
            }
            else
            {
                if( g != null )
                    g.Hue = 1152;
                if( a != null )
                    a.SpeechHue = 1153;
                if( r != null )
                    r.Hue = 1152;
                if( s != null )
                    s.SpeechHue = 1153;
                b.Hue = 1153;
            }
        }

        public override bool OnMoveOver( Mobile m )
        {
            if ( m.SolidHueOverride == 2125 || m.SolidHueOverride == 2101  )
            {
                if ( m.Direction == Direction.East || (m.Direction & ~Direction.Running) == Direction.East )
                {
                    if( ( m_goldb1 == Y ) && ( m_Xp == X ) || ( m_goldb2 == Y )  && ( m_Xp == X ) || ( m_goldb3 == Y )  && ( m_Xp == X )  || ( m_goldb4 == Y )  && ( m_Xp == X ) )
                    {
                        m_goldscore += 1;
                        bc();
                        goldteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);

                    }
                    else
                    {
                        if( m_Xp != X )
                            X += 1;
                        else
                            X -= 1;
                    }
                }
                else if ( m.Direction == Direction.West || (m.Direction & ~Direction.Running) == Direction.West )
                {
                    if( ( m_silverb1 == Y ) && ( m_Xn == X ) || ( m_silverb2 == Y )  && ( m_Xn == X )|| ( m_silverb3 == Y )  && ( m_Xn == X )|| (m_silverb4 == Y )  && ( m_Xn == X ))
                    {
                        m_silverscore += 1;
                        bc();
                        silverteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);
                    }
                    else
                    {
                        if( m_Xn != X )
                            X -= 1;
                        else
                            X += 1;
                    }
                }
                else if ( m.Direction == Direction.South || (m.Direction & ~Direction.Running) == Direction.South )
                {
                    if( m_Yp != Y )
                        Y += 1;
                    else
                        Y -= 1;
                }
                else if ( m.Direction == Direction.North || m.Direction == Direction.Running )
                {
                    if( m_Yn != Y )
                        Y -= 1;
                    else
                        Y += 1;
                }
                else if ( m.Direction == Direction.Down || (m.Direction & ~Direction.Running) == Direction.Down )
                {
                    if( ( m_goldb2 == Y )  && ( m_Xp == X ) || ( m_goldb3 == Y )  && ( m_Xp == X )  || ( m_goldb4 == Y )  && ( m_Xp == X ) )
                    {
                        m_goldscore += 1;
                        bc();
                        goldteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);
                    }
                    else
                    {
                        if( m_Yp != Y )
                            Y += 1;
                        else
                            Y -= 1;
                        if( m_Xp != X )
                            X += 1;
                        else
                            X -= 1;
                    }
                }
                else if ( m.Direction == Direction.Mask || m.Direction == Direction.ValueMask )
                {
                    if( ( m_silverb1 == Y ) && ( m_Xn == X ) || ( m_silverb2 == Y )  && ( m_Xn == X )|| ( m_silverb3 == Y )  && ( m_Xn == X ))
                    {
                        m_silverscore += 1;
                        bc();
                        silverteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);

                    }
                    else
                    {
                        if( m_Yn != Y )
                            Y -= 1;
                        else
                            Y += 1;
                        if( m_Xn != X )
                            X -= 1;
                        else
                            X += 1;
                    }
                }
                else if ( m.Direction == Direction.Left || (m.Direction & ~Direction.Running) == Direction.Left )
                {
                    if( ( m_silverb2 == Y )  && ( m_Xn == X )|| ( m_silverb3 == Y )  && ( m_Xn == X )|| (m_silverb4 == Y )  && ( m_Xn == X ))
                    {
                        m_silverscore += 1;
                        bc();
                        silverteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);

                    }
                    else
                    {
                        if( m_Yp != Y )
                            Y += 1;
                        else
                            Y -= 1;
                        if( m_Xn != X )
                            X -= 1;
                        else
                            X += 1;
                    }
                }
                else if ( m.Direction == Direction.Right || (m.Direction & ~Direction.Running) == Direction.Right )
                {
                    if( ( m_goldb1 == Y ) && ( m_Xp == X ) || ( m_goldb2 == Y )  && ( m_Xp == X ) || ( m_goldb3 == Y )  && ( m_Xp == X ) )
                    {
                        m_goldscore += 1;
                        bc();
                        goldteamb();

                        foreach( Mobile mob in GetMobilesInRange(30) )
                            StartMoveBack(mob);

                    }
                    else
                    {
                        if( m_Yn != Y )
                            Y -= 1;
                        else
                            Y += 1;

                        if( m_Xp != X )
                            X += 1;
                        else
                            X -= 1;
                    }
                }

                ItemID = Utility.Random(5) switch
                {
                    0 => 6880,
                    1 => 6881,
                    2 => 6882,
                    3 => 6883,
                    4 => 6884,
                    _ => ItemID
                };
            }

            return true;
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );

            writer.Write( 0 );

            writer.Write( m_silverscore );
            writer.Write( m_goldscore );
            writer.Write( m_Xp );
            writer.Write( m_Yp );
            writer.Write( m_Xn );
            writer.Write( m_Yn );
            writer.Write( m_silverb1 );
            writer.Write( m_silverb2 );
            writer.Write( m_silverb3 );
            writer.Write( m_silverb4 );
            writer.Write( m_goldb1 );
            writer.Write( m_goldb2 );
            writer.Write( m_goldb3 );
            writer.Write( m_goldb4 );
            writer.Write( m_HomeY );
            writer.Write( m_HomeX );
            writer.Write( m_AllowedPlayer1 );
            writer.Write( m_AllowedPlayer2 );
            writer.Write( m_GiveReward );
            writer.Write( m_FreezePlayers );
            writer.Write( m_FreezeTime );
            writer.Write( m_GiveRewardMinTeamCount );
            writer.Write( m_DisplayDateOnReward );
            writer.Write( m_DisplayNameOnReward );
            writer.Write( m_DisplayTeamCountOnReward );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            m_silverscore = reader.ReadInt();
            m_goldscore = reader.ReadInt();
            m_Xp = reader.ReadInt();
            m_Yp = reader.ReadInt();
            m_Xn = reader.ReadInt();
            m_Yn = reader.ReadInt();
            m_silverb1 = reader.ReadInt();
            m_silverb2 = reader.ReadInt();
            m_silverb3 = reader.ReadInt();
            m_silverb4 = reader.ReadInt();
            m_goldb1 = reader.ReadInt();
            m_goldb2 = reader.ReadInt();
            m_goldb3 = reader.ReadInt();
            m_goldb4 = reader.ReadInt();
            m_HomeY = reader.ReadInt();
            m_HomeX = reader.ReadInt();
            m_AllowedPlayer1 = reader.ReadEntity<Mobile>();
            m_AllowedPlayer2 = reader.ReadEntity<Mobile>();
            m_GiveReward = reader.ReadBool();
            m_FreezePlayers = reader.ReadBool();
            m_FreezeTime = reader.ReadDouble();
            m_GiveRewardMinTeamCount = reader.ReadInt();
            m_DisplayDateOnReward = reader.ReadBool();
            m_DisplayNameOnReward = reader.ReadBool();
            m_DisplayTeamCountOnReward = reader.ReadBool();
        }
    }

    public enum Team
    {
        Gold,
        Silver
    }

    public class SkullballEnterGate : Item
    {
        private Team m_Team;
        private Point3D m_PointDest;
        private Map m_MapDest;

        [CommandProperty( AccessLevel.GameMaster )]
        public Team Team{ get => m_Team;
            set => m_Team = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public Point3D PointDest{ get => m_PointDest;
            set => m_PointDest = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public Map MapDest{ get => m_MapDest;
            set => m_MapDest = value;
        }

        [Constructible]
        public SkullballEnterGate() : base( 0xF6C )
        {
            Movable = false;
            Name = "Enter Skullball";
            Light = LightType.Circle300;
        }

        public SkullballEnterGate( Serial serial ) : base( serial )
        {
        }

        public override bool OnMoveOver( Mobile m )
        {
            if( m is not PlayerMobile )
                return true;

            Point3D p = m_PointDest;
            Map map = m_MapDest;
            if ( map == null || map == Map.Internal )
                map = m.Map;

            if( p == Point3D.Zero )
            {
                m.SendMessage( "There is no destination set for this gate. Please contact a GM." );
                return true;
            }

            if( m.SolidHueOverride == 2125 || m.SolidHueOverride == 2101 )
            {
                m.SendMessage( "You are already in a Skullball game!" );
                return true;
            }

            if( m.Mounted )
            {
                m.SendMessage( "Please dismount before entering the Skullball field." );
                return true;
            }

            if ( m_Team == Team.Gold )
            {
                m.MoveToWorld( p, map );
                m.Blessed = true;
                m.SolidHueOverride = 2125;

                ArrayList mobs = new ArrayList( World.Mobiles.Values );
                foreach ( Mobile ko in mobs )
                {
                    if ( ( ko is PlayerMobile )  )
                    {
                        if ( ko.SolidHueOverride == 2101 || ko.SolidHueOverride == 2125 )
                            ko.SendMessage( ko.SolidHueOverride, m.Name + " has joined the Skullball game." );
                    }
                }
            }
            else
            {
                m.MoveToWorld( p, map );
                m.Blessed = true;
                m.SolidHueOverride = 2101;

                ArrayList mobs = new ArrayList( World.Mobiles.Values );
                foreach ( Mobile ko in mobs )
                {
                    if ( ( ko is PlayerMobile )  )
                    {
                        if ( ko.SolidHueOverride == 2101 || ko.SolidHueOverride == 2125 )
                            ko.SendMessage( ko.SolidHueOverride, m.Name + " has joined the Skullball game." );
                    }
                }
            }
            return false;
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 );

            writer.Write( (int) m_Team );
            writer.Write( m_PointDest );
            writer.Write( m_MapDest );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            m_Team = (Team)reader.ReadInt();
            m_PointDest = reader.ReadPoint3D();
            m_MapDest = reader.ReadMap();
        }
    }

    public class SkullballExitGate : Item
    {
        private Point3D m_PointDest;
        private Map m_MapDest;

        [CommandProperty( AccessLevel.GameMaster )]
        public Point3D PointDest{ get => m_PointDest;
            set => m_PointDest = value;
        }
        [CommandProperty( AccessLevel.GameMaster )]
        public Map MapDest{ get => m_MapDest;
            set => m_MapDest = value;
        }

        [Constructible]
        public SkullballExitGate() : base( 0xF6C )
        {
            Movable = false;
            Name = "Exit Skullball";
            Light = LightType.Circle300;
        }

        public SkullballExitGate( Serial serial ) : base( serial )
        {
        }

        public override bool OnMoveOver( Mobile m )
        {
            if( m is not PlayerMobile )
                return false;

            Point3D p = m_PointDest;
            Map map = m_MapDest;
            if ( map == null || map == Map.Internal )
                map = m.Map;

            if( p == Point3D.Zero )
            {
                m.SendMessage( "There is no destination set for this gate. Please contact a GM." );
                return false;
            }

            if( m.SolidHueOverride != 2125 && m.SolidHueOverride != 2101 )
            {
                m.MoveToWorld( p, map );
                m.Blessed = false;

                return false;
            }

            ArrayList mobs = new ArrayList( World.Mobiles.Values );
            foreach ( Mobile ko in mobs )
            {
                if ( ( ko is PlayerMobile )  )
                {
                    if ( ko.SolidHueOverride == 2101 || ko.SolidHueOverride == 2125 )
                    {
                        if( ko.Location == Location )	// Only send the leave message if they use the gate. (we call this wehen the game is over, don't need message then).
                            ko.SendMessage( ko.SolidHueOverride, m.Name + " has left the Skullball game." );
                    }
                }
            }

            m.MoveToWorld( p, map );
            m.Blessed = false;
            m.SolidHueOverride = -1;

            return false;
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 );

            writer.Write( m_PointDest );
            writer.Write( m_MapDest );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();

            m_PointDest = reader.ReadPoint3D();
            m_MapDest = reader.ReadMap();
        }
    }

    public class SkullballSetupStone : Item
    {
        [Constructible]
        public SkullballSetupStone() : base( 4483 )
        {
            Movable = false;
            Name = "Skullball Setup Stone";
            Hue = 33;
            Light = LightType.Circle300;
        }

        public SkullballSetupStone( Serial serial ) : base( serial )
        {
        }

        public override void OnDoubleClick( Mobile m )
        {
            ///////////////////////////////////////////////////////////////////  body
            for ( int Yy = Y; Yy <= 9 + Y; ++Yy )
                for ( int Xx = X; Xx <= 20 + X; ++Xx )
                    new Static( 6014 ).MoveToWorld( new Point3D( Xx, Yy, Z ), Map );
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////// out side area
            //for ( int Yy = this.Y; Yy <= 9 + this.Y; ++Yy )
            for ( int Xx = X; Xx <= 22 + X; ++Xx )
            {
                new Static( 1313 ).MoveToWorld( new Point3D( Xx - 1, Y - 1, Z ), Map );
                new Static( 1313 ).MoveToWorld( new Point3D( Xx - 1, Y + 10, Z ), Map );
            }

            for ( int Yy = Y; Yy <= 2 + Y; ++Yy )
            {
                new Static( 1313 ).MoveToWorld( new Point3D( X - 1, Yy, Z ), Map );
                new Static( 1313 ).MoveToWorld( new Point3D( X + 21, Yy, Z ), Map );

                new Static( 1313 ).MoveToWorld( new Point3D( X - 1, Yy + 7, Z ), Map );
                new Static( 1313 ).MoveToWorld( new Point3D( X + 21, Yy + 7, Z ), Map );

            }

            for ( int Yy = Y; Yy <= 5 + Y; ++Yy )
            {
                new Static( 1313 ).MoveToWorld( new Point3D( X - 2, Yy + 2, Z ), Map );
                new Static( 1313 ).MoveToWorld( new Point3D( X + 22, Yy + 2, Z ), Map );
            }
            ////////////////////////////////////////////////////////////////////

            ////////////////////////////////////////////////////////////////////// out side area 2
            //for ( int Yy = this.Y; Yy <= 9 + this.Y; ++Yy )
            for ( int Xx = X; Xx <= 24 + X; ++Xx )
            {
                new Static( 1848 ).MoveToWorld( new Point3D( Xx - 2, Y - 2, Z ), Map );
                new Static( 1848 ).MoveToWorld( new Point3D( Xx - 2, Y + 11, Z ), Map );
            }

            for ( int Yy = Y; Yy <= 2 + Y; ++Yy )
            {
                new Static( 1848 ).MoveToWorld( new Point3D( X - 2, Yy -1, Z ), Map );
                new Static( 1848 ).MoveToWorld( new Point3D( X + 22, Yy -1, Z ), Map );

                new Static( 1848 ).MoveToWorld( new Point3D( X - 2, Yy + 8, Z ), Map );
                new Static( 1848 ).MoveToWorld( new Point3D( X + 22, Yy + 8, Z ), Map );

            }

            for ( int Yy = Y; Yy <= 7 + Y; ++Yy )
            {
                new Static( 1848 ).MoveToWorld( new Point3D( X - 3, Yy + 1, Z ), Map );
                new Static( 1848 ).MoveToWorld( new Point3D( X + 23, Yy + 1, Z ), Map );
            }
            ////////////////////////////////////////////////////////////////////




            //////////////////////////////// GOALS /////////////////////////////

            ////////////////////////////// GOLD SIDE ///////////////////////////
            Item wall1 = new Static( 9350 ); wall1.Hue = 2125; wall1.MoveToWorld( new Point3D( X - 2, Y + 6, Z ), Map ); // back wall
            Item wall2 = new Static( 9350 ); wall2.Hue = 2125; wall2.MoveToWorld( new Point3D( X - 2, Y + 5, Z ), Map );	// back wall
            Item wall3 = new Static( 9350 ); wall3.Hue = 2125; wall3.MoveToWorld( new Point3D( X - 2, Y + 4, Z ), Map );	// back wall
            Item wall4 = new Static( 9350 ); wall4.Hue = 2125; wall4.MoveToWorld( new Point3D( X - 2, Y + 3, Z ), Map );	// back wall
            Item wall5 = new Static( 9354 ); wall5.Hue = 2125; wall5.MoveToWorld( new Point3D( X - 2, Y + 2, Z ), Map );	// corner post
            Item wall6 = new Static( 9351 ); wall6.Hue = 2125; wall6.MoveToWorld( new Point3D( X - 1, Y + 2, Z ), Map );	// goal side 1
            Item wall7 = new Static( 9351 ); wall7.Hue = 2125; wall7.MoveToWorld( new Point3D( X - 1, Y + 6, Z ), Map ); // goal side 2
            new Blocker().MoveToWorld( new Point3D( X - 2, Y + 7, Z ), Map ); // blocker

            // GOALIE BOX
            new Static( 1313 ).MoveToWorld( new Point3D( X, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 1, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 3, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 4, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 5, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 6, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 2, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 1, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X , Y + 7, Z ), Map ); // stone pavern

            ///////////////////////////// SILVER SIDE //////////////////////////
            Item wall8 = new Static( 9350 ); wall8.Hue = 2101; wall8.MoveToWorld( new Point3D( X + 21, Y + 5, Z ), Map ); // back wall
            Item wall9 = new Static( 9350 ); wall9.Hue = 2101; wall9.MoveToWorld( new Point3D( X + 21, Y + 4, Z ), Map ); // back wall
            Item wall10 = new Static( 9350 ); wall10.Hue = 2101; wall10.MoveToWorld( new Point3D( X + 21, Y + 3, Z ), Map ); // back wall
            Item wall11 = new Static( 9351 ); wall11.Hue = 2101; wall11.MoveToWorld( new Point3D( X + 21, Y + 2, Z ), Map ); // goal side 1
            Item wall12 = new Static( 9349 ); wall12.Hue = 2101; wall12.MoveToWorld( new Point3D( X + 21, Y + 6, Z ), Map ); // goal side 2 & back wall/corner
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 2, Z ), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 3, Z ), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 4, Z ), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 5, Z ), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 6, Z ), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 22, Y + 7, Z ), Map ); // blocker

            // GOALIE BOX
            new Static( 1313 ).MoveToWorld( new Point3D( X + 20, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 19, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 3, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 4, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 5, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 6, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 18, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 19, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 20, Y + 7, Z ), Map ); // stone pavern

            // CENTER LINE
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 1, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 3, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 4, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 5, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 6, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 8, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 10, Y + 9, Z ), Map ); // stone pavern

            // CENTER CIRCLE
            new Static( 1313 ).MoveToWorld( new Point3D( X + 11, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 9, Y + 2, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 12, Y + 3, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 8, Y + 3, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 13, Y + 4, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 7, Y + 4, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 13, Y + 5, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 7, Y + 5, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 12, Y + 6, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 8, Y + 6, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 11, Y + 7, Z ), Map ); // stone pavern
            new Static( 1313 ).MoveToWorld( new Point3D( X + 9, Y + 7, Z ), Map ); // stone pavern

            ////////////////////////// GATE DIVIDE BLOCK ///////////////////////
            new Static( 1848 ).MoveToWorld( new Point3D( X + 10, Y + 12, Z ), Map );
            new Blocker().MoveToWorld( new Point3D( X + 10, Y + 12, Z + 5), Map ); // blocker

            new Blocker().MoveToWorld( new Point3D( X + 10, Y - 2, Z + 5), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 11, Y - 2, Z + 5), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X + 9, Y - 2, Z + 5), Map );  // blocker

            new Blocker().MoveToWorld( new Point3D( X - 1, Y - 2, Z + 5), Map ); // blocker
            new Blocker().MoveToWorld( new Point3D( X - 2, Y - 2, Z + 5), Map ); // blocker

            ////////////////////////// EXIT GATE STAIRS ////////////////////////
            new Static( 1856 ).MoveToWorld( new Point3D( X + 21, Y - 1, Z ), Map );

            ///////////////////////////// EXIT GATE ////////////////////////////
            SkullballExitGate exitgate = new SkullballExitGate
            {
                PointDest = new Point3D( X + 10, Y + 13, Z ),
                MapDest = Map,
                Hue = 33
            };
            exitgate.MoveToWorld( new Point3D( X + 22, Y - 2, Z + 5 ), Map );
            new Blocker().MoveToWorld( new Point3D( X + 21, Y - 2, Z + 5 ), Map ); // blocker

            ////////////////////////// ENTRANCE GATES //////////////////////////
            SkullballEnterGate entergateG = new SkullballEnterGate
            {
                PointDest = new Point3D( X + 1, Y + 5, Z ),
                MapDest = Map,
                Team = Team.Gold,
                Hue = 2125,
                ItemID = 14170
            };	// Gold
            entergateG.MoveToWorld( new Point3D( X + 9, Y + 12, Z ), Map );

            SkullballEnterGate entergateS = new SkullballEnterGate
            {
                PointDest = new Point3D( X + 18, Y + 5, Z ),
                MapDest = Map,
                Team = Team.Silver,
                Hue = 2101,
                ItemID = 14170
            }; // Silver
            entergateS.MoveToWorld( new Point3D( X + 11, Y + 12, Z ), Map );


            ////////////////////////// Fire Columns ///////////////////////////
            // 1
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y - 2, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y - 2, Z + 5 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y - 2, Z + 10 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y - 2, Z + 11 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y - 1, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y - 1, Z + 5), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y - 1, Z + 10 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y - 1, Z + 15 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y - 1, Z + 16 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y, Z + 5), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y, Z + 10 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y, Z + 15 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y, Z + 20 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y, Z + 21 ), Map );
            // 2
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y - 2, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y - 2, Z + 5 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y - 2, Z + 10 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y - 2, Z + 11 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y - 1, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y - 1, Z + 5), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y - 1, Z + 10 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y - 1, Z + 15 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y - 1, Z + 16 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y, Z + 5 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y, Z + 10 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y, Z + 15 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y, Z + 20 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y, Z + 21 ), Map );
            // 3
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 11, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 11, Z + 5 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y + 11, Z + 10 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y + 11, Z + 11 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 10, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 10, Z + 5 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 10, Z + 10 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y + 10, Z + 15 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y + 10, Z + 16 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z + 5), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z + 10 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z + 15 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z + 20 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X + 23, Y + 9, Z + 21 ), Map );
            // 4
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 11, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 11, Z + 5 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y + 11, Z + 10 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y + 11, Z + 11 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 10, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 10, Z + 5 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 10, Z + 10 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y + 10, Z + 15 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y + 10, Z + 16 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z + 5 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z + 10 ), Map );
            new Static( 933 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z + 15 ), Map );
            new Static( 6587 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z + 20 ), Map );
            new Static( 6571 ).MoveToWorld( new Point3D( X - 3, Y + 9, Z + 21 ), Map );




            Static static1 = new Static( 1179 )
            {
                Hue = 2125,
                X = X -1,
                Y = Y +3,
                Z = Z,
                Map = Map
            };	// Gold Goal Floor
            Static static2 = new Static( 1179 )
            {
                Hue = static1.Hue,
                X = static1.X,
                Y = static1.Y +1,
                Z = Z,
                Map = Map
            };
            Static static3 = new Static( 1179 )
            {
                Hue = static1.Hue,
                X = static1.X,
                Y = static1.Y +2,
                Z = Z,
                Map = Map
            };
            Static static4 = new Static( 1179 )
            {
                Hue = static1.Hue,
                X = static1.X,
                Y = static1.Y +3,
                Z = Z,
                Map = Map
            };

            Static static5 = new Static( 1179 )
            {
                Hue = 2101,
                X = X +21,
                Y = Y +3,
                Z = Z,
                Map = Map
            };	// Silver Goal Floor
            Static static6 = new Static( 1179 )
            {
                Hue = static5.Hue,
                X = static5.X,
                Y = static5.Y +1,
                Z = Z,
                Map = Map
            };
            Static static7 = new Static( 1179 )
            {
                Hue = static5.Hue,
                X = static5.X,
                Y = static5.Y +2,
                Z = Z,
                Map = Map
            };
            Static static8 = new Static( 1179 )
            {
                Hue = static5.Hue,
                X = static5.X,
                Y = static5.Y +3,
                Z = Z,
                Map = Map
            };


            Skullball ball = new Skullball
            {
                Yn = Y,
                Yp = Y + 9,
                Xn = X,
                Xp = X + 20,
                goldb4 = Y + 3,
                goldb3 = Y + 4,
                goldb2 = Y + 5,
                goldb1 = Y + 6,
                silverb4 = Y + 3,
                silverb3 = Y + 4,
                silverb2 = Y + 5,
                silverb1 = Y + 6,
                HomeX = X + 10,
                HomeY = Y + 4
            };


            Referee ref1 = new Referee();
            ball.MobileSilverTeam = ref1;
            ref1.Direction = Direction.South;
            ref1.MoveToWorld( new Point3D( X + 10, Y - 2, Z + 5 ), Map );

            Referee ref2 = new Referee();
            ball.MobileGoldTeam = ref2;
            ref2.Direction = Direction.North;
            ref2.MoveToWorld( new Point3D( X + 10, Y + 11, Z + 5 ), Map );

            ball.MoveToWorld( new Point3D( X + 10, Y + 4, Z + 2 ), Map );

            Delete();
        }

        public override void Serialize( IGenericWriter writer )
        {
            base.Serialize( writer );
            writer.Write( 0 );
        }

        public override void Deserialize( IGenericReader reader )
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}

namespace Server.Mobiles
{
    [CorpseName( "a referee corpse" )]
    public class Referee : Mobile
    {
        [Constructible]
        public Referee()
        {
            Name = "a referee";
            Body = 400;
            Hue = 1153;
            Blessed = true;
            SpeechHue = 1153;
            CantWalk = true;

            GMRobe robe = new GMRobe
            {
                Hue = 1153,
                Name = "Referee's Robe"
            };
            AddItem( robe );
        }

        public Referee( Serial serial ) : base( serial )
        {
        }

        public override void Serialize(IGenericWriter writer)
        {
            base.Serialize( writer );

            writer.Write( 0 );
        }

        public override void Deserialize(IGenericReader reader)
        {
            base.Deserialize( reader );

            int version = reader.ReadInt();
        }
    }
}
