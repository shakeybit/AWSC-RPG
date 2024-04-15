

namespace RPGidea
{


    /// <summary>
    /// Interface representing basic item.
    /// </summary>
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }
    }

    /// <summary>
    /// base item concrete implementation 
    /// </summary>
    public class Item : IItem
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }

        public Item(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }

    /// <summary>
    /// decorator interface for item
    /// </summary>

        public interface IWeapon : IItem
    {
        int DamageValue { get; }
        int AttackRange { get; }
    }

    /// <summary>
    /// Interface for armor
    /// </summary>
    public interface IArmor : IItem
    {
        int ArmorValue { get; }
    }


    /// <summary>
    /// Base class for weapons
    /// </summary>
    public class Weapon : IWeapon
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int DamageValue { get; }
        public int AttackRange { get; }


        public Weapon(int id, string name, string description, int damage, int range)
        {
            ID = id;
            Name = name;
            Description = description;
            DamageValue = damage;
            AttackRange = range;

        }
    }

    /// <summary>
    /// Base class for armor
    /// </summary>
    public class Armor : IArmor
    {
        public int ID { get; }
        public string Name { get; }
        public string Description { get; }
        public int ArmorValue { get; }
        
        public Armor(int id, string name, string description, int armor)
        {
            ID = id;
            Name = name;
            Description = description;
            ArmorValue = armor;
        }
    }
}

