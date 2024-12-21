namespace RPGidea{

    /// <summary>
    /// interface stat sheet; wraps concrete and decorator
    /// </summary>
public interface IStatModifier
{
    String name { get; }
    int healthModifier { get; }
    int armorModifier { get; }
    int damageModifier { get; }
    int inventoryModifier { get; }
    int rangeModifier { get; }
    //int moveModifier { get; }
    int strModifier { get; }
    int agiModifier { get; }
    int intModifier { get; }
}

/// <summary>
/// base stat sheet concrete implementation 
/// applied onto creatures and items
/// </summary>
public class StatModifier : IStatModifier
{
    public String _name { get; private set; }
    public int _healthModifier { get; private set; }
    public int _armorModifier { get; private set; }
    public int _damageModifier { get; private set; }
    public int _inventoryModifier { get; private set; }
    public int _rangeModifier { get; private set; }

    //public int _moveModifier { get; private set; }
    public int _strModifier { get; private set; }
    public int _agiModifier { get; private set; }
    public int _intModifier { get; private set; }

    public String name => _name;
    public int healthModifier => _healthModifier;
    public int armorModifier => _armorModifier;
    public int damageModifier => _damageModifier;
    public int inventoryModifier => _inventoryModifier;
    public int rangeModifier => _rangeModifier; 
        // range determines EITHER movement or attack distance
    
    //public int moveModifier => _moveModifier;
    public int strModifier => _strModifier;
    public int agiModifier => _agiModifier;
    public int intModifier => _intModifier;

    // Constructor to initialize the modifiers
    public StatModifier(String name, int health, int armor, int damage, int inventory, int range, int str, int agi, int intel)
    {
        _name = name;
        _healthModifier = health;
        _armorModifier = armor;
        _damageModifier = damage;
        _inventoryModifier = inventory;
        _rangeModifier = range;
        //_moveModifier = move;
        _strModifier = str;
        _agiModifier = agi;
        _intModifier = intel;
    }
}


}