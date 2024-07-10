using ModernUO.Serialization;

namespace Server.Items
{
    [SerializationGenerator(0, false)]
    [Flippable(0xE86, 0xE85)]
    public partial class LockTrainBox : LockableContainer
    {
        [Constructible]
        public LockTrainBox() : base(0x9A8)
        {
            RequiredSkill = 0;
            Name = "Lockpick Training chest";
            Locked = true;
            LockLevel = 1;
        }

        public override void OnDoubleClick(Mobile from)
        {
            var skills = from.Skills;

            RequiredSkill = (int)skills.Lockpicking.Value;
            LockLevel = RequiredSkill;
            from.SendMessage($"Training Chest adjusted to {skills.Lockpicking.Value} Lockpicking");
            Locked = true;
        }

        public override void LockPick(Mobile from)
        {
            Locked = true;
            from.SendMessage("The Chest is Locked Again");
        }
        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, $"Set to {RequiredSkill} Lockpicking");
            LabelTo(from, $"{Name}");
            from.SendMessage("Double click the box to set set it to your Lockpicking Skill.");
        }

    }

    [SerializationGenerator(0, false)]
    [Flippable(0xE86, 0xE85)]
    public partial class TrapTrainBox : LockableContainer
    {
        [Constructible]
        public TrapTrainBox() : base(0x9A8)
        {
            RequiredSkill = 0;
            Name = "Remve Trap Training chest";
            Locked = false;
            LockLevel = 0;
            TrapOnLockpick = true;
            TrapLevel = 1;
            TrapType = TrapType.ExplosionTrap;
        }

        public override void OnDoubleClick(Mobile from)
        {
            var skills = from.Skills;

            RequiredSkill = (int)skills.RemoveTrap.Value;
            TrapLevel = RequiredSkill;
            from.SendMessage($"Training Chest adjusted to {skills.RemoveTrap.Value} Remove Trap");
            Locked = false;
            TrapOnLockpick = true;
            TrapType = TrapType.ExplosionTrap;
        }

        public override void LockPick(Mobile from)
        {
            Locked = false;
            from.SendMessage("The Chest is trapped Again");
        }
        public override void OnSingleClick(Mobile from)
        {
            LabelTo(from, $"Set to {RequiredSkill} Remove Trap");
            LabelTo(from, $"{Name}");
            from.SendMessage("Double click the box to set set it to your Remove Trap Skill.");
        }

    }

}
