using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea

{
    public interface ICreature : IEntity {
        List<IItem> Items { get; set;}
        int MovementRange { get; set; }

        
    }
    public class Creature : ICreature
    {
        public int ID { get; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MovementRange { get; set; }
        public List<IItem> Items { get; set; }
        public Weapon EquippedWeapon { get; private set; }
        public Armor EquippedArmor { get; private set;}
        public int Accept(IEntityVisitor visitor) {
            return visitor.Visit(this);
        }
        


        public Creature(string name, int hitPoints, int movementRange) {
            Name = name;
            HitPoints = hitPoints;
            Items = new List<IItem>();
            MovementRange = movementRange;
        }

        public List<IItem> GetItems() { 
            return Items; 
            }

            /*
        public List<Weapon> GetWeapons()
        {
            return Items.OfType<Weapon>().ToList();
        }

        public List<Armor> GetArmor()
        {
            return Items.OfType<Armor>().ToList();
        } */

        public void EquipWeapon(Weapon weapon) {
            EquippedWeapon = weapon;
        }

        public void EquipArmor(Armor armor) {
            EquippedArmor = armor;
        }

        public Weapon GetEquippedWeapon() {
            return EquippedWeapon;
        }
        public Armor GetEquippedArmor() {
            return EquippedArmor;
        }
        
        public void AddItem(IItem item) { Items.Add(item); }
        public void RemoveItem(Item item) { Items.Remove(item); }
    }

}
