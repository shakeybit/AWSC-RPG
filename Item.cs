

namespace RPGidea
{


    /// <summary>
    /// Interface representing basic item.
    /// </summary>
    public interface IItem
    {
        int ID { get; }
        string Description { get; }
        int TradeValue { get; }
        int Weight { get; }
        int Slot { get; }
        public StatModifier _StatModifier { get; }
        
    }

    /// <summary>
    /// base item concrete implementation 
    /// </summary>
    public class Item : IItem
    {
        private static int _nextId;
        public int ID { get; }
        public string Description { get; }
        public int TradeValue { get; }
        public int Weight { get; }
        public int Slot { get; }
        public StatModifier _StatModifier { get; set; }


        public Item(string description, int tradeValue, int weight, int slot, StatModifier statModifier)
        {
            ID = _nextId++;
            Description = description;
            TradeValue = tradeValue;
            Weight = weight;
            Slot = slot;
            _StatModifier = statModifier;
        }
    }

    /// <summary>
    /// decorator interface for equipment
    /// </summary>
   


}

