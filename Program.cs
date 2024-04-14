namespace RPGidea
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Creature creature = new Creature("Bob", 100);
            creature.AddItem(new Weapon(1, "Sword", "Short steel sword", 10, 1));
            Weapon weapon = creature.GetWeapons()[0];
            creature.EquipWeapon(weapon);
            Console.WriteLine(creature.Name + " Equipped " + weapon.Name);
            
            Creature target = new Creature("Bums", 20);
            Armor armor = new Armor(2, "Boots", "Yeezies", 5);
            target.EquipArmor(armor);

            World world = new World(10, 10);
            


        }
    }
}