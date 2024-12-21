namespace RPGidea
{
    class Test
    {
        static void Main(string[] args)
        {
            StatModifier swordStats = new StatModifier("Sword of Tests", 0, 0, 20, 0, 1, 2, 0, 0);
            Item sword = new Item("Describe me", 10, 3, 1, swordStats);

            Console.WriteLine($"Name: {sword._StatModifier.name}");
            Console.WriteLine($"Damage: {sword._StatModifier.damageModifier}");
            Console.WriteLine($"Strength: {sword._StatModifier.armorModifier}");
            Console.WriteLine($"Value: {sword.TradeValue}");
        }
    }
}