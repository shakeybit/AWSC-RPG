namespace RPGidea
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Logger.Instance.LogInfo("App running");

            

            List<IEntity> entities = new List<IEntity>();
            World world = new World(6, 6);
            Combat combat = new Combat(world);

            Creature c1 = new Creature(1, "Hildetand", 120, 2);
            Creature c2 = new Creature(2, "Unge Ramund", 100, 2);
            Creature c3 = new Creature(3, "Hårderåde", 100, 3);
            Creature c4 = new Creature(4, "Benløs", 100, 1);


            Weapon w1 = new Weapon(1, "Kølle", "Solidt eg.", 25, 2);
            Weapon w2 = new Weapon(2, "Dymlingen Dyre", "En kniv han mente ikke bed.", 35, 1);
            Weapon w3 = new Weapon(3, "Væringe Spyd", "Fra Miklagård.", 25, 2);
            Weapon w4 = new Weapon(4, "Loddenben Bue", "Fra Loddenbuks eget lårben.", 25, 3);

            Armor a1 = new Armor(5, "Svinfylking", "Fordi jern bed ham ikke.", 10);
            Armor a2 = new Armor(6, "Bedre Klæder", "Af blårgarn, bast og læder.", 5);
            Armor a3 = new Armor(7, "Tordenværn", "Plyndret fra Hedeby.", 5);
            Armor a4 = new Armor(8,"Krykker", "To styks.", 2);
            IWeaponDecorator moddedWeapon = new ModDamage(w1, 10);

            c1.AddItemList(w1, a1);
            c2.AddItemList(w2, a2);
            c3.AddItemList(w3, a3);
            c4.AddItemList(w4, a4);
            

            c1.EquipWeapon(w1);
            c1.EquipArmor(a1);
            c2.EquipWeapon(w2);
            c2.EquipArmor(a2);
            c3.EquipWeapon(w3);
            c3.EquipArmor(a3);
            c4.EquipWeapon(w4);
            c4.EquipArmor(a4);


            world.AddEntities(c1, c2, c3, c4);

            world.SetEntityAt(c1, 2, 0);
            world.SetEntityAt(c2, 2, 5);
            world.SetEntityAt(c3, 3, 0);
            world.SetEntityAt(c4, 3, 5);

            combat.MoveCreature(c1, 2, 2);
            combat.MoveCreature(c2, 2, 3);
            combat.MoveCreature(c3, 3, 1);
            combat.MoveCreature(c4, 3, 4);

            combat.Attack(c4, c2);
            combat.Attack(c3, c1);
            combat.Attack(c2, c3);
            combat.Attack(c1, c2);



            Logger.Instance.LogInfo("App ended");
            

            


        }
    }
}