namespace RPGidea
{
    public class Program
    {
        private static void Main(string[] args)
        {
            World world = new World(6, 6);

            Creature c1 = new Creature("Hildetand", 100, 2);
            Creature c2 = new Creature("Den Unge", 120, 2);
            Creature c3 = new Creature("Hårderåde", 100, 3);
            Creature c4 = new Creature("Benløs", 100, 1);


            Weapon w1 = new Weapon(1, "Kølle", "Solidt eg.", 25, 1);
            Weapon w2 = new Weapon(2, "Dymlingen Dyre", "En kniv han mente ikke bed.", 25, 1);
            Weapon w3 = new Weapon(3, "Væringe Spyd", "Fra Miklagård.", 25, 2);
            Weapon w4 = new Weapon(4, "Ben Bue", "Fra Loddenbuks eget lårben.", 35, 4);

            Armor a1 = new Armor(5, "Svinfylking", "Fordi jern bed ham ikke.", 10);
            Armor a2 = new Armor(6, "Bedre Klæder", "Af blårgarn, bast og læder.", 5);
            Armor a3 = new Armor(7, "Tordenværn", "Plyndret fra Hedeby.", 5);
            Armor a4 = new Armor(8,"Krykker", "To styks.", 2);

            c1.AddItem(w1);
            c1.AddItem(a1);
            c2.AddItem(w2);
            c2.AddItem(a2);
            c3.AddItem(w3);
            c3.AddItem(a3);
            c4.AddItem(a4);
            c4.AddItem(w4);
            c1.EquipWeapon(w1);
            c1.EquipArmor(a1);
            c2.EquipWeapon(w2);
            c2.EquipArmor(a2);
            c3.EquipWeapon(w3);
            c3.EquipArmor(a3);
            c4.EquipWeapon(w4);
            c4.EquipArmor(a4);

            world.AddEntity(c1);
            world.AddEntity(c2);
            world.AddEntity(c3);
            world.AddEntity(c4);

            world.SetEntityAt(c1, 2, 0);
            world.SetEntityAt(c2, 3, 0);
            world.SetEntityAt(c3, 2, 5);
            world.SetEntityAt(c4, 3, 5);

            Combat combat = new Combat();
            combat.MoveCreature(c1, 2, 2);
            combat.MoveCreature(c2, 3, 2);
            combat.MoveCreature(c3, 1, 3);
            combat.MoveCreature(c4, 3, 4);
            combat.Attack(c4, c3);
            

            


        }
    }
}