using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    public class Combat
    {
        public World World;
        public int Turn;

        /// <summary>
        /// Calculates damage output of a creature attacking an entity
        /// Attacked creatures armor reduce damage
        /// Non-creature entity like chest or barrel have no armor 
        /// </summary>
        /// <param name="attacker">adds the DamageValue of its EquippedWeapon to damage</param>
        /// <param name="target">subtracts the DamageValue of its EquippedArmor from damage (if creature)</param>
        /// <returns></returns>
        public int CalculateDamage(Creature attacker, IEntity target)
        {
            int damage = 0;

            Weapon attackerWeapon = attacker.EquippedWeapon;

            if (target is Creature)
            {
                Armor targetArmor = ((Creature)target).EquippedArmor;
                damage = attackerWeapon.DamageValue - targetArmor.ArmorValue;
            }
            else
            {
                damage = attackerWeapon.DamageValue;
            }

            if (damage < 0)
            {
                damage = 0;
            }

            return damage;
        }




        public void Attack(Creature attacker, IEntity target)
        {
            Weapon weapon = attacker.EquippedWeapon;
            if (IsInAttackRange(attacker, target))
            {
                target.HitPoints = -CalculateDamage(attacker, target);
                Logger.Instance.LogInfo(attacker.Name + " attacks " + target.Name + " for " + CalculateDamage(attacker, target) + " damage using " + weapon.Name + ".");
            }
            else
            {
                Logger.Instance.LogError(target.Name + " out of weapon range.");
            }
        }



        public void LootEntity(Creature player, Entity entity)
        {
            List<IItem> loot = entity.Items;
            if (loot.Count == 0)
            {
                Logger.Instance.LogWarning(entity.Name + " holds no items.");
            }
            if (entity.HitPoints == 0)
            {
                foreach (IItem item in loot)
                {
                    player.AddItem(item);
                    Console.WriteLine(player.Name + " looted " + item.Name);
                }
            }
            else
            {
                Logger.Instance.LogWarning(entity.Name + " can't be looted until at 0 Hit Points.");
            }
        }

        public void MoveCreature(Creature creature, int x, int y)
        {
            int[] creatureStartCoordinates = World.GetEntityCoordinates(creature);
            if (creature.MovementRange <= World.CalculateDistance(creatureStartCoordinates, [x, y]))
            {
                World.SetEntityAt(creature, x, y);
                World.ClearTile(creatureStartCoordinates[0], creatureStartCoordinates[1]);
                Logger.Instance.LogInfo(creature.Name + " moved to " + x + ", " + y);
            }
            else 
            {
                Logger.Instance.LogError("Coordinates out of creature movement range.");
            }

        }

        /// <summary>
        /// checks if creature's weapon has sufficient range to entity
        /// </summary>
        /// <param name="attacker"> has a position in the world and a weapon with specific range.</param>
        /// <param name="target"> has a position in the world.</param>
        /// <returns></returns>
        public bool IsInAttackRange(Creature attacker, IEntity target)
        {
            int distance = World.CalculateDistance(World.GetEntityCoordinates(attacker), World.GetEntityCoordinates(target));
            if (attacker.EquippedWeapon.AttackRange < distance)
            {
                return false;
            }
            else
            {
                return true;
            }
        }




    }

}






