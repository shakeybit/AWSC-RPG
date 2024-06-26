
namespace RPGidea

{
    public interface IEntity
    {
        int ID { get; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public List<IItem> Items { get; set; }


    }

    public class Entity : IEntity
    {
        public int ID { get; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public List<IItem> Items { get; set; }

        public Entity(int id, string name, int hitPoints)
        {
            ID = id;
            Name = name;
            HitPoints = hitPoints;
            Items = new List<IItem>();

        }
        public void AddItem(IItem item) { Items.Add(item); }
        public void RemoveItem(IItem item) { Items.Remove(item); }

        public void AddItemList(params IItem[] items)
        {
            var itemsToAdd = items.ToList();
            Items.AddRange(itemsToAdd);
        }

    }
}
