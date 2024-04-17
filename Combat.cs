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

        public Combat(World world)
        {
            World = world;
        }

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
            int baseDamage = CalculateBaseDamage(attackerWeapon);

            if (target is Creature)
            {
                Armor targetArmor = ((Creature)target).EquippedArmor;
                damage = baseDamage - targetArmor.ArmorValue;
            }
            else
            {
                damage = baseDamage;
            }

            if (damage < 0)
            {
                damage = 0;
            }

            return damage;
        }
        /// <summary>
        /// Calculates the base damage of a weapon, handling decorator operation if applicable
        /// </summary>
        /// <param name="weapon">weapon to be calculated</param>
        /// <returns></returns>
        

        private int CalculateBaseDamage(Weapon weapon)
        {
            int baseDamage = weapon.DamageValue;

            if (weapon is IWeaponDecorator weaponDecorator)
            {
                baseDamage = weaponDecorator.DamageValue;
            }

            return baseDamage;
        }



        /// <summary>
        /// Basic attack method subtracts CalculateDamage from target entity hitpoints if IsInAttackRange is true 
        /// </summary>
        /// <param name="attacker">attacker is a Creature, only creatures should attack</param>
        /// <param name="target">Target is IEntity, either creature, gobject or other types that can be struck</param>
        public virtual void Attack(Creature attacker, IEntity target) // virtual: hvis arver fra klasse kan attack ellers overwrites
        {
            Weapon weapon = attacker.EquippedWeapon;
            if (IsInAttackRange(attacker, target))
            {
                int damage = CalculateDamage(attacker, target);
                target.HitPoints -= damage;

                Logger.Instance.LogInfo(attacker.Name + " attacks " + target.Name + " for " + damage + " damage using " + weapon.Name + ".\n"
                + target.Name + " currently has " + target.HitPoints + " remaining hit points.");
            }
            else
            {
                Logger.Instance.LogError(attacker.Name + " tried to attack " + target.Name + " but could not reach with " + attacker.EquippedWeapon.Name + ".");
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
            int[] creatureStartCoordinates = World.GetEntityCoordinates(creature); // "Object reference not set to an instance of an object"

            int distance = World.CalculateDistance(creatureStartCoordinates, [x, y]);

            if (creature.MovementRange >= distance)
            {
                World.SetEntityAt(creature, x, y);
                World.ClearTile(creatureStartCoordinates[0], creatureStartCoordinates[1]);
                Logger.Instance.LogInfo(creature.Name + " moved " + distance + " tiles to " + x + ", " + y);
            }
            else
            {
                Logger.Instance.LogError("Coordinates out of " + creature.Name + " movement range of " + creature.MovementRange);
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






