using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    // Decorator interface - Each decorator adds specific behavior or responsibilities to the component
    public interface IItem
    {
        int ID { get; }
        string Name { get; }
        string Description { get; }

        void Accept(IItemVisitor visitor); // visitor pattern - Accept method in relevant classes to permit visitor
    }

    // Concrete implementation of the base item
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

    public void Accept(IItemVisitor visitor) {
        visitor.Visit(this);
    }
}

    // weapon interface
    public interface IWeapon : IItem
    {
        int DamageValue { get; }
        int AttackRange { get; }
    }

    // Base class for weapons
    public class Weapon : IWeapon
    {
        public int ID {get;} 
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

        public void Accept(IItemVisitor visitor) {
            visitor.Visit(this);
        }
    }

    public interface IArmor : IItem
    {
    int ArmorValue { get; }
    }
    
    public class Armor : IArmor
    {
        public int ID {get;}
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
        public void Accept(IItemVisitor visitor) {
            visitor.Visit(this);
        }
    }

}









/*
    public class Armor : Item {
        private int _ArmorValue { get; set; }
        private enum _ArmorType
        {
            Cloth,Light,Heavy
        }

        public Armor(string name, string description, int armorValue) : base(name, description)
        {
            _ArmorValue = armorValue;
        }

public class Potion : Item {
            private int _Value { get; set; }
            private int _Duration { get; set; }
            private enum _PotionType
            {
                Healing, Damage, Protection
            }
            public Potion (string name, string description, int value, int duration) : base(name, description) {
                _Value = value;
                _Duration = duration;
            }
        }


public class Weapon : Item, IWeapon
{
    public int DamageValue { get; }
    public int AttackRange { get; }

    public Weapon(string name, string description, int damage, int range)
        : base(name, description)
    {
        DamageValue = damage;
        AttackRange = range;
    }
}

*/













