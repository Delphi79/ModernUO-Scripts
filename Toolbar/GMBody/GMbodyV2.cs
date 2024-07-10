/******************************************
 * Script Name: GMBodyV2.cs               *
 * Original author Nerun                  *
 * Modified by Nerun, Mr. Batman & Delphi *
 * For use with ModernUO                  *
 * Date: June 10, 2024                    *
 ******************************************/

using System;
using System.Diagnostics.CodeAnalysis;
using Server.Accounting;
using Server.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Commands
{
    public class GMbody
    {
        public static void Configure()
        {
            Register("GMbody", AccessLevel.Counselor, GM_OnCommand);
            EventSink.PlayerDeath += EventSink_PlayerDeath;
        }

        public static void Register(string command, AccessLevel access, CommandEventHandler handler)
        {
            CommandSystem.Register(command, access, handler);
        }

        [Usage("GMbody")]
        [Description("Helps senior staff members set their body to GM style.")]
        public static void GM_OnCommand(CommandEventArgs e)
        {
            e.Mobile.Target = new GMmeTarget();
        }

        private class GMmeTarget : Target
        {
            public GMmeTarget() : base(-1, false, TargetFlags.None)
            {
            }

            private static Mobile m_Mobile;

            private static void EquipItem(Item item, bool mustEquip = false)
            {
                item.LootType = LootType.Blessed;

                if (m_Mobile != null && m_Mobile.EquipItem(item))
                    return;

                if (m_Mobile != null)
                {
                    Container pack = m_Mobile.Backpack;

                    if (!mustEquip && pack != null)
                        pack.DropItem(item);
                    else
                        item.Delete();
                }
            }

            private static void PackItem(Item item)
            {
                Container pack = m_Mobile.Backpack;

                if (pack != null)
                    pack.DropItem(item);
                else
                    item.Delete();
            }

            protected override void OnTarget(Mobile from, object targeted)
            {
                if (targeted is Mobile targ)
                {
                    if (from != targ)
                    {
                        from.SendMessage("You may only set your own body to GM style.");
                        return;
                    }

                    m_Mobile = from;

                    CommandLogging.WriteLine(from, $"{from.AccessLevel} {CommandLogging.Format(from)} is assuming a GM body");

                    Container pack = from.Backpack;

                    using (var itemsToDelete = PooledRefQueue<Item>.Create())
                    {
                        foreach (Item item in from.Items)
                        {
                            if (item.Layer != Layer.Bank && item.Layer != Layer.Hair && item.Layer != Layer.FacialHair && item.Layer != Layer.Mount && item.Layer != Layer.Backpack)
                            {
                                itemsToDelete.Enqueue(item);
                            }
                        }

                        while (itemsToDelete.Count > 0)
                        {
                            itemsToDelete.Dequeue().Delete();
                        }
                    }

                    if (pack == null)
                    {
                        pack = new Backpack();
                        pack.Movable = false;
                        from.AddItem(pack);
                    }
                    else
                    {
                        pack.Delete();
                        pack = new Backpack();
                        pack.Movable = false;
                        from.AddItem(pack);
                    }

                    from.Hunger = 20;
                    from.Thirst = 20;
                    from.Fame = 0;
                    from.Karma = 0;
                    from.Kills = 0;
                    from.Hidden = true;
                    from.Blessed = true;
                    from.Hits = from.HitsMax;
                    from.Mana = from.ManaMax;
                    from.Stam = from.StamMax;

                    if (from.AccessLevel >= AccessLevel.Counselor)
                    {
                        from.NetState.SendSpeedControl(SpeedControlSetting.Mount);

                        Spellbook book1 = new Spellbook(ulong.MaxValue);

                        PackItem(book1);

                        from.RawStr = 100;
                        from.RawDex = 100;
                        from.RawInt = 100;
                        from.Hits = from.HitsMax;
                        from.Mana = from.ManaMax;
                        from.Stam = from.StamMax;

                        for (int i = 0; i < targ.Skills.Length; ++i)
                            targ.Skills[i].Base = 100;
                    }

                    if (from.AccessLevel == AccessLevel.Counselor)
                    {
                        EquipItem(new CounselorRobe());
                        EquipItem(new Boots(0x3));

                        from.Title = "[Counselor]";
                    }

                    if (from.AccessLevel == AccessLevel.GameMaster)
                    {
                        EquipItem(new GMRobe());
                        EquipItem(new Boots(0x26));

                        from.Title = "[GM]";
                    }

                    if (from.AccessLevel == AccessLevel.Seer)
                    {
                        EquipItem(new SeerRobe());
                        EquipItem(new Boots(0x1D3));

                        from.Title = "[Seer]";
                    }

                    if (from.AccessLevel == AccessLevel.Administrator)
                    {
                        EquipItem(new AdminRobe());
                        EquipItem(new Boots(1));

                        from.Title = "[Admin]";
                    }

                    if (from.AccessLevel == AccessLevel.Developer)
                    {
                        EquipItem(new DevRobe());
                        EquipItem(new Boots(11));

                        from.Title = "[Developer]";
                    }

                    if (from.AccessLevel == AccessLevel.Owner)
                    {
                        EquipItem(new OwnerRobe());
                        EquipItem(new Boots(1150));

                        from.Title = "[Owner]";
                    }

                    from.SendMessage("GMbody applied.");

                    // Sparkles, Remove if desired
                    Effects.SendLocationEffect(from.Location, from.Map, 0x3779, 10, 1, 1152);
                    Effects.PlaySound(from.Location, from.Map, 0x1FD);
                }
            }
        }

        private class DevRobe : BaseSuit
        {
            [Constructible]
            public DevRobe() : base(AccessLevel.Developer, 11, 0x204F) => Name = "Developer Robe";

            [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by serialization")]
            public DevRobe(Serial serial) : base(serial)
            {
            }

            public override void Serialize(IGenericWriter writer)
            {
                base.Serialize(writer);
                writer.Write(0);
            }

            public override void Deserialize(IGenericReader reader)
            {
                base.Deserialize(reader);
                int version = reader.ReadInt();
            }
        }

        private class OwnerRobe : BaseSuit
        {
            [Constructible]
            public OwnerRobe() : base(AccessLevel.Owner, 1150, 0x204F) => Name = "Owner Robe";

            [SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Used by serialization")]
            public OwnerRobe(Serial serial) : base(serial)
            {
            }

            public override void Serialize(IGenericWriter writer)
            {
                base.Serialize(writer);
                writer.Write(0);
            }

            public override void Deserialize(IGenericReader reader)
            {
                base.Deserialize(reader);
                int version = reader.ReadInt();
            }
        }

        private static void EventSink_PlayerDeath(Mobile from)
        {
            if (from is PlayerMobile { Account: Account account } pm)
            {
                Timer.DelayCall(TimeSpan.FromMilliseconds(1), () =>
                {
                    if (!pm.Alive)
                    {
                        if (pm.Corpse != null)
                        {
                            pm.Corpse.Delete();
                        }

                        pm.Resurrect();
                        pm.SendMessage(0x35, "As a staff member, you should be more careful.");
                        pm.Blessed = true;
                        pm.Hidden = true;
                        pm.Hits = pm.HitsMax;
                        pm.Stam = pm.StamMax;
                        pm.Mana = pm.ManaMax;
                        pm.ResetStaffAccess();
                        ReEquipStaffItems(pm);
                        SetTitle(pm);

                        pm.NetState.SendSpeedControl(SpeedControlSetting.Mount);

                        CommandSystem.Handle(pm, "ResetStaffDress");

                        // Play death effect (helps mask body falling on death) Remove if desired
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y + 1, from.Z + 11), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y + 1, from.Z + 7), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y + 1, from.Z + 3), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y + 1, from.Z - 1), from.Map, 0x3728, 13, 1);

                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y, from.Z + 4), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y, from.Z), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X + 1, from.Y, from.Z - 4), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X, from.Y + 1, from.Z + 4), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X, from.Y + 1, from.Z), from.Map, 0x3728, 13, 1);
                        Effects.SendLocationEffect(new Point3D(from.X, from.Y + 1, from.Z - 4), from.Map, 0x3728, 13, 1);

                        Effects.SendLocationEffect(from.Location, from.Map, 0x3709, 15, 1, 1264, 7);
                        Effects.SendBoltEffect(from);

                    }
                });
            }
        }

        private static void ReEquipStaffItems(PlayerMobile pm)
        {
            if (pm.Backpack != null)
            {
                // Re-equip boots
                Item boots = pm.Backpack.FindItemByType(typeof(Boots));
                if (boots != null)
                {
                    pm.EquipItem(boots);
                }

                // Re-equip other specific items
                foreach (Item item in pm.Backpack.Items)
                {
                    if (item is DevRobe || item is OwnerRobe || item is CounselorRobe || item is GMRobe || item is SeerRobe || item is AdminRobe)
                    {
                        pm.EquipItem(item);
                    }
                }
            }
        }

        private static void SetTitle(PlayerMobile pm)
        {
            pm.Title = pm.AccessLevel switch
            {
                AccessLevel.Counselor     => "[Counselor]",
                AccessLevel.GameMaster    => "[GM]",
                AccessLevel.Seer          => "[Seer]",
                AccessLevel.Administrator => "[Admin]",
                AccessLevel.Developer     => "[Developer]",
                AccessLevel.Owner         => "[Owner]",
                _                         => null
            };
        }
    }
}
