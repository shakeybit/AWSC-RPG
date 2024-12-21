
namespace RPGidea

{
    public interface IEntity
    {
        public List<IItem> Items { get; set; }
        public List<IItem> EquippedItems { get; set; }
        public StatModifier StatModifier { get; set; }

    }

    public class Entity : IEntity
    {
        public List<IItem> Items { get; set; }
        public List<IItem> EquippedItems { get; set; }
        public StatModifier StatModifier { get; set; }

   public Entity(List<IItem> items, StatModifier statModifier)
    {
        Items = items;
        StatModifier = statModifier;
    }

        public bool HasItem(IItem itemToFind)
        {
            return Items.Any(item => item.ID == itemToFind.ID);
        }
        public void AddItem(IItem item) { Items.Add(item); }
        public void RemoveItem(IItem item) { Items.Remove(item); }
        public void AddItemList(params IItem[] items)
        {
            var itemsToAdd = items.ToList();
            Items.AddRange(itemsToAdd);
        }




        public void EquipItem(Item item)
        {
            if (HasItem(item) && !isSlotOccupied(item))
            {
                EquippedItems.Add(item);
            }
            else
            {
                if (HasItem(item))
                {Logger.Instance.LogError("Creature does not have item " + item._StatModifier._name + " in inventory");}


                else
                { Logger.Instance.LogError("Slot is occupied");}
            }
        }

                public void UnequipItem(Item item)
        {
            if (HasItem(item))
            {
                EquippedItems.Remove(item);
            }
            else
            {
                Logger.Instance.LogError("Creature does not have item " + item._StatModifier._name + " in inventory");
            }
        }

        public bool isSlotOccupied(Item item)
        {
            return EquippedItems.Any(equippedItem => equippedItem.Slot == item.Slot);
        }
        
        

    }
    
}
