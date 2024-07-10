/**********************************************
* Script Name: InvasionSystem.cs              *
 * ReWritten by ImaNewb Aka Delphi            *
 * Original Author: RavenWolfe (for ServUO)   *
 * For use with ModernUO                      *
 * Date: June 17, 2024                        *
 * ========================================== *
 * Special thanks to Ravenwolfe, Mr, Batman   *
 * and Voxspire                               *
 **********************************************/

using System;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Regions;

namespace Server.Customs.Invasion_System
{
    public class TownInvasion : ISerializable
    {
        public DateTime Created { get; set; }
        public long SavePosition { get; set; }
        public BufferWriter SaveBuffer { get; set; }
        public Serial Serial { get; private set; }
        public bool Deleted { get; private set; }
        public InvasionTowns InvasionTown { get; set; }
        public TownMonsterType TownMonsterType { get; set; }
        public TownChampionType TownChampionType { get; set; }
        public bool IsRunning { get; set; }
        public DateTime StartTime { get; set; }
        public List<Mobile> Spawned { get; set; }
        private static List<int> usedTeamIDs = new List<int>();
        private static readonly int CheckSpawnIntervalSeconds = 15;
        private static readonly int AnnounceIntervalMinutes = 1;
        private const double ParagonProbability = 0.1; // 10% chance for a creature to be a Paragon. Adjust as needed.

        private int MinionTeamID { get; set; }
        private int ChampionTeamID { get; set; }

        public static void Initialize()
        {
            Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(30.0), GlobalSync);
        }

        #region Private Variables

        private bool _FinalStage;
        private Point3D _Top = new(4394, 1058, 30);
        private Point3D _Bottom = new(4481, 1173, 0);
        private DateTime _lastAnnounce = DateTime.UtcNow;
        private bool WasDisabledRegion;
        private int TeamID;

        #endregion

        #region Public Variables

        public int MinSpawnZ { get; set; }
        public int MaxSpawnZ { get; set; }
        public Point3D Top
        {
            get => _Top;
            set => _Top = value;
        }

        public Point3D Bottom
        {
            get => _Bottom;
            set => _Bottom = value;
        }

        public Map SpawnMap { get; set; }
        public Timer SpawnTimer { get; set; }

        [CommandProperty(AccessLevel.GameMaster)]
        public string TownInvaded { get; private set; }

        #endregion

        #region Constructor

        public TownInvasion(InvasionTowns town, TownMonsterType monster, TownChampionType champion, DateTime time, InvasionMap map)
        {
            Spawned = new List<Mobile>();
            InvasionTown = town;
            TownMonsterType = monster;
            TownChampionType = champion;
            StartTime = time;
            MinionTeamID = GenerateUniqueTeamID();
            ChampionTeamID = GenerateUniqueTeamID();
            SpawnMap = map == InvasionMap.Felucca ? Map.Felucca : Map.Trammel;
            TownInvaded = town.ToString(); // Set dynamically
            InvasionControl.Invasions.Add(this);
        }

        // Serialization constructor
        public TownInvasion(IGenericReader reader)
        {
            Deserialize(reader);
        }

        public unsafe TownInvasion(Serial serial)
        {
            byte[] bytes = BitConverter.GetBytes(serial.Value);
            fixed (byte* ptr = bytes)
            {
                UnmanagedDataReader reader = new UnmanagedDataReader(ptr, bytes.Length);
                Deserialize(reader);
            }
        }


        #endregion
        #region ISerializable Implementation

        public void Serialize(IGenericWriter writer)
        {
            writer.Write(0); // version
            writer.Write((int)InvasionTown);
            writer.Write((int)TownMonsterType);
            writer.Write((int)TownChampionType);
            writer.Write(StartTime);
            writer.Write(Spawned);
            writer.Write(IsRunning);
            writer.Write(TeamID);
            writer.Write((int)(SpawnMap == Map.Felucca ? InvasionMap.Felucca : InvasionMap.Trammel)); // Save the map
        }

        public void Deserialize(IGenericReader reader)
        {
            var version = reader.ReadInt();
            InvasionTown = (InvasionTowns)reader.ReadInt();
            TownMonsterType = (TownMonsterType)reader.ReadInt();
            TownChampionType = (TownChampionType)reader.ReadInt();
            StartTime = reader.ReadDateTime();
            Spawned = reader.ReadEntityList<Mobile>();
            IsRunning = reader.ReadBool();
            TeamID = reader.ReadInt();
            InvasionMap map = (InvasionMap)reader.ReadInt();
            SpawnMap = map == InvasionMap.Felucca ? Map.Felucca : Map.Trammel;
            TownInvaded = InvasionTown.ToString(); // Set dynamically
            MinionTeamID = GenerateUniqueTeamID();
            ChampionTeamID = GenerateUniqueTeamID();
        }

        public void Delete()
        {
            Deleted = true;
        }

        #endregion

        #region Methods

        public void OnStart()
        {
            if (!IsRunning)
            {
                IsRunning = true;
                var invading = InvasionTown;
                World.Broadcast(0x35, true, $"A monster invasion in {InvasionTown} ({SpawnMap.Name}) has begun ! Help defend the realm!");

                // Find the corresponding region
                Region invasionRegion = Region.Regions.Find(r => r.Name == InvasionTown.ToString() && r.Map == SpawnMap);
                if (invasionRegion == null)
                {
                    Console.WriteLine($"[ERROR] Region for town {InvasionTown} not found in {SpawnMap.Name}");
                    return;
                }

                // Calculate the bounding box of the region
                var (minX, minY, maxX, maxY) = GetRegionBounds(invasionRegion);
                Top = new Point3D(minX, minY, 0);
                Bottom = new Point3D(maxX, maxY, 0);

                // Set the town invaded property
                TownInvaded = InvasionTown.ToString(); // Set dynamically

                // Enable invasion region guards
                foreach (var r in Region.Regions)
                {
                    if (r is GuardedRegion && r.Name == TownInvaded && r.Map == SpawnMap)
                    {
                        WasDisabledRegion = ((GuardedRegion)r).GuardsDisabled;
                        ((GuardedRegion)r).GuardsDisabled = true;
                    }
                }

                Spawn();
            }
        }

        private (int minX, int minY, int maxX, int maxY) GetRegionBounds(Region region)
        {
            int minX = int.MaxValue, minY = int.MaxValue, maxX = int.MinValue, maxY = int.MinValue;

            foreach (var rect in region.Area)
            {
                if (rect.Start.X < minX) minX = rect.Start.X;
                if (rect.Start.Y < minY) minY = rect.Start.Y;
                if (rect.End.X > maxX) maxX = rect.End.X;
                if (rect.End.Y > maxY) maxY = rect.End.Y;
            }

            return (minX, minY, maxX, maxY);
        }

        public void OnStop()
        {
            if (!IsRunning)
            {
                return;
            }

            Despawn();
            IsRunning = false;
            World.Broadcast(0x35, true, $"The monster invasion in {InvasionTown} has ended. Thank you for defending the realm!");

            if (!WasDisabledRegion)
            {
                foreach (var r in Region.Regions)
                {
                    if (r is GuardedRegion && r.Name == TownInvaded && r.Map == SpawnMap)
                    {
                        ((GuardedRegion)r).GuardsDisabled = false;
                    }
                }
            }

            if (SpawnTimer != null)
            {
                SpawnTimer.Stop();
            }

            InvasionControl.Invasions.Remove(this);
        }

        private void Spawn()
        {
            Despawn();
            MonsterTownSpawnEntry[] entries;

            switch (TownMonsterType)
            {
                case TownMonsterType.Abyss:
                    entries = MonsterTownSpawnEntry.Abyss;
                    break;
                case TownMonsterType.Arachnid:
                    entries = MonsterTownSpawnEntry.Arachnid;
                    break;
                case TownMonsterType.DragonKind:
                    entries = MonsterTownSpawnEntry.DragonKind;
                    break;
                case TownMonsterType.Elementals:
                    entries = MonsterTownSpawnEntry.Elementals;
                    break;
                case TownMonsterType.Humanoid:
                    entries = MonsterTownSpawnEntry.Humanoid;
                    break;
                case TownMonsterType.Ophidian:
                    entries = MonsterTownSpawnEntry.Ophidian;
                    break;
                case TownMonsterType.OrcsandRatmen:
                    entries = MonsterTownSpawnEntry.OrcsandRatmen;
                    break;
                case TownMonsterType.OreElementals:
                    entries = MonsterTownSpawnEntry.OreElementals;
                    break;
                //Coming in next Revision
                /*case TownMonsterType.SeaMonsters:
                    entries = MonsterTownSpawnEntry.SeaMonsters;
                    break;*/
                case TownMonsterType.Snakes:
                    entries = MonsterTownSpawnEntry.Snakes;
                    break;
                case TownMonsterType.Undead:
                    entries = MonsterTownSpawnEntry.Undead;
                    break;
                case TownMonsterType.Giants:
                    entries = MonsterTownSpawnEntry.Giants;
                    break;
                default:
                    Console.WriteLine($"[ERROR] Unknown TownMonsterType: {TownMonsterType}");
                    return;
            }

            for (var i = 0; i < entries.Length; ++i)
            {
                for (var count = 0; count < entries[i].Amount; ++count)
                {
                    AddMonster(entries[i].Monster, MinionTeamID);
                }
            }

            if (Spawned.Count == 0)
            {
                OnStop();
                return;
            }

            InitTimer();
        }

        public void CheckSpawn()
        {
            var count = 0;

            for (var i = 0; i < Spawned.Count; ++i)
            {
                if (Spawned[i] != null && !Spawned[i].Deleted && Spawned[i].Alive)
                {
                    ++count;
                }
            }

            if (!_FinalStage)
            {
                if (count == 0)
                {
                    SpawnChamp();
                }
            }
            else
            {
                if (count == 0)
                {
                    OnStop();
                }
            }

            if (DateTime.UtcNow >= _lastAnnounce + TimeSpan.FromMinutes(AnnounceIntervalMinutes))
            {
                string message;
                if (!_FinalStage)
                {
                    message = $"Invasion minions remaining in {TownInvaded}: {count}";
                }
                else
                {
                    message = $"Invasion champions remaining in {TownInvaded}: {count}";
                }

                foreach (var tc in TownCrier.Instances)
                {
                    tc.PublicOverheadMessage(MessageType.Yell, 0, false, message);
                }

                World.Broadcast(0x35, true, message);

                _lastAnnounce = DateTime.UtcNow;
            }
        }

        private void Despawn()
        {
            foreach (var m in Spawned)
            {
                if (m != null && !m.Deleted)
                {
                    m.Delete();
                }
            }

            Spawned.Clear();
            _FinalStage = false;
        }

        private Point3D FindSpawnLocation()
        {
            int x, y, z;
            var count = 100;

            do
            {
                x = Utility.Random(_Top.X, _Bottom.X - _Top.X);
                y = Utility.Random(_Top.Y, _Bottom.Y - _Top.Y);
                z = SpawnMap.GetAverageZ(x, y);
            } while (!SpawnMap.CanSpawnMobile(x, y, z) && --count >= 0);

            if (count < 0)
            {
                x = y = z = 0;
            }

            return new Point3D(x, y, z);
        }

        private void AddMonster(Type type, int teamID)
        {
            var monster = Activator.CreateInstance(type);

            if (monster is Mobile from)
            {
                var location = FindSpawnLocation();

                if (location == Point3D.Zero)
                {
                    return;
                }

                from.OnBeforeSpawn(location, SpawnMap);
                from.MoveToWorld(location, SpawnMap);
                from.OnAfterSpawn();

                if (from is BaseCreature bc)
                {
                    bc.Team = teamID;

                    // Set as Paragon with a certain probability
                    if (Utility.RandomDouble() < ParagonProbability)
                    {
                        bc.IsParagon = true;
                    }
                }

                Spawned.Add(from);
            }
        }

        public void SpawnChamp()
        {
            Despawn();
            _FinalStage = true;
            World.Broadcast(0x35, true, $"An invasion champion has spawned in {InvasionTown}! Defeat it to end the invasion!");

            Type championType = TownChampionType switch
            {
                TownChampionType.Barracoon => typeof(Barracoon),
                TownChampionType.Harrower => typeof(Harrower),
                TownChampionType.LordOaks => typeof(LordOaks),
                TownChampionType.Mephitis => typeof(Mephitis),
                TownChampionType.Neira => typeof(Neira),
                TownChampionType.Rikktor => typeof(Rikktor),
                TownChampionType.Semidar => typeof(Semidar),
                TownChampionType.Serado => typeof(Serado),
                _ => typeof(Barracoon),
            };

            AddMonster(championType, ChampionTeamID);
        }

        private static void GlobalSync()
        {
            var index = InvasionControl.Invasions.Count;

            while (--index >= 0)
            {
                if (index >= InvasionControl.Invasions.Count)
                {
                    continue;
                }

                var obj = InvasionControl.Invasions[index];

                if (!obj.IsRunning && obj.StartTime <= DateTime.UtcNow)
                {
                    obj.OnStart();
                }

                if (obj.IsRunning)
                {
                    obj.CheckSpawn();
                }
            }
        }

        private void InitTimer()
        {
            if (!IsRunning)
            {
                SpawnTimer = Timer.DelayCall(TimeSpan.Zero, TimeSpan.FromSeconds(CheckSpawnIntervalSeconds), CheckSpawn);
            }
        }

        private int GenerateUniqueTeamID()
        {
            int id;
            do
            {
                id = Utility.RandomMinMax(10000, 99999);
            } while (usedTeamIDs.Contains(id));

            usedTeamIDs.Add(id);
            return id;
        }

        #endregion
    }
}
