using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    public interface ICreature : IEntity
    {
        int MovementRange { get; set; }
        Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }

    }

    public class Creature : ICreature
    {
        public int ID { get; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int MovementRange { get; set; }
        public List<IItem> Items { get; set; }

        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Creature(string name, int hitPoints, int movementRange)
        {
            Name = name;
            HitPoints = hitPoints;
            MovementRange = movementRange;
            Items = new List<IItem>();
        }

        public bool HasItem(IItem itemToFind)
        {
            return Items.Any(item => item.ID == itemToFind.ID);
        }

        public void EquipWeapon(Weapon weapon)
        {
            if (HasItem(weapon))
            {
                EquippedWeapon = weapon;
            }
            else
            {
                Logger.Instance.LogError("Creature does not have weapon " + weapon.Name + " in inventory");
            }
        }

        public void EquipArmor(Armor armor)
        {
            // Check if the creature has the armor
            if (HasItem(armor))
            {
                EquippedArmor = armor;
            }
            else
            {
                Logger.Instance.LogError("Creature does not have armor " + armor.Name + " in inventory");
            }
        }

        public void AddItem(IItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            Items.Remove(item);
        }
    }
}


