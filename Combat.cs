using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    public class CombatVisitor : IEntityVisitor // separate the logic for operating on different types of entities from the entities themselves
    {
        public int CalculateCreatureDamage(Creature creature)
        {
            Weapon weapon = creature.GetEquippedWeapon();
            Armor armor = creature.GetEquippedArmor();

        }

    }





    public class Combat // LEGACY CLASS (no visitor)
    {
        public List<Creature> Players;
        public List<Creature> Monsters;
        public List<Gobject> Objects;
        public World World;
        public int Turn;
        
        public Combat(List<Creature> players, List<Creature> monsters, List<Gobject> objects, World world) // no constructor need?
        {
            Players = players;
            Monsters = monsters;
            Objects = objects;
            World = world;
        }

        public void EquipWeapon(Weapon weapon, Creature creature) {
            if (creature.GetWeapons().Contains(weapon)) {
                creature.EquipWeapon(weapon);
            } else {
                Console.WriteLine("Error: Weapon not in inventory");
            }
        } 

        public void EquipArmor(Armor armor, Creature creature) {
            if (creature.GetArmor().Contains(armor)) {
                creature.EquipArmor(armor);
            } else {
                Console.WriteLine("Error: Weapon not in inventory");
            }
        } 


        public int CalculateDamage(Creature attacker, IEntity target) 
        {
            Weapon attackerWeapon = attacker.GetEquippedWeapon();
            Armor targetArmor = target.GetEquippedArmor(); // target IEntity does not have GetEquippedArmor, only creature-entities should

            int damage = attackerWeapon.DamageValue;
            int armor = targetArmor.ArmorValue;

            damage = damage - armor;

            if (damage < 0) {
                damage = 0;
            }
            return damage;
        }

            // calculate distance between coordinates
        public int CalculateDistance(int[] coord1, int[] coord2)
        {

            // "Manhattan distance formular"
            return Math.Abs(coord1[0] - coord1[1]) + Math.Abs(coord2[0] - coord2[1]);
        }
            // checks if creature's weapon has sufficient range to damage creature/gobject
        public bool IsInRange(Creature attacker, IEntity target) {
            int distance = CalculateDistance(World.GetEntityCoordinates(attacker), World.GetEntityCoordinates(target));
            if (attacker.GetEquippedWeapon().AttackRange < distance) {
                return false;
            } else {
                return true;
            }
        }



        public void Attack(Creature attacker, IEntity target) {
            if (IsInRange(attacker, target)) {
                target.HitPoints = - CalculateDamage(attacker, target);
            }
            Weapon weapon = attacker.GetEquippedWeapon();
            Console.WriteLine(attacker.Name + " attacks " + target.Name + " for " + CalculateDamage(attacker, target) + " damage using " + weapon.Name + ".");
        }

        

        public void LootEntity(Creature player, Entity entity)
        {
            List<IItem> loot = entity.Items;
            if (loot.Count == 0) {
                Console.WriteLine(entity.Name + " is empty!");
            }

            foreach (IItem item in loot) {
                entity.AddItem(item);
                Console.WriteLine(entity.Name + " looted " + item.Name);
            }

        }


    }

}



/*

      public void LootObject(Creature creature, Gobject gobject)
        {
            List<IItem> loot = gobject.GetItems();
            if (loot.Count == 0) {
                Console.WriteLine(gobject.Name + " is empty!");
            }

            foreach (IItem item in loot) {
                creature.AddItem(item);
                Console.WriteLine(creature.Name + " looted " + item.Name);
            }

        }


*/


    
