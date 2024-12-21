namespace RPGidea
{
    /// <summary>
    /// item decorator adds runtime operations on object variables independently. 
    /// write methods to attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.
    /// </summary>
    public interface IItemDecorator : IItem
    {
        IItem BaseItem { get; }
    }

    /// <summary>
    /// Dedicated weapon decorator for operating on weapon attributes
    /// </summary>
    public class ModDamage : IItemDecorator
    {
        private static int _nextId = 1;
        private readonly IItem _baseItem;

        public int ID { get; }
        public string Description => _baseItem.Description + " (Damage Enhanced)";
        public int TradeValue => _baseItem.TradeValue;
        public int Weight => _baseItem.Weight;
        public int Slot => _baseItem.Slot;
        public StatModifier _StatModifier { get; }

        public IItem BaseItem => _baseItem;

        public ModDamage(IItem baseItem)
        {
            ID = _nextId++;
            _baseItem = baseItem;
            _StatModifier = new StatModifier(
                baseItem._StatModifier.name,
                baseItem._StatModifier.healthModifier,
                baseItem._StatModifier.armorModifier,
                baseItem._StatModifier.damageModifier,
                baseItem._StatModifier.inventoryModifier,
                baseItem._StatModifier.rangeModifier,
                baseItem._StatModifier.strModifier,
                baseItem._StatModifier.agiModifier,
                baseItem._StatModifier.intModifier
            );
        }
    }
}