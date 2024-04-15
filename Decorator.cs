namespace RPGidea
{

/// <summary>
/// item decorator adds runtime operations on object variables independently. write methods to attach new behaviors to objects by placing these objects inside special wrapper objects that contain the behaviors.
/// </summary>
    public interface IItemDecorator : IItem
    {
        IItem GetBaseItem { get; }
    }
    public class ModDamage : IItemDecorator, IWeapon
    {
        private readonly IWeapon _baseWeapon;
        private readonly int _damageIncrease;

        public ModDamage(IWeapon baseWeapon, int damageIncrease)
        {
            _baseWeapon = baseWeapon;
            _damageIncrease = damageIncrease;
        }

        /// <summary>
        /// Implement IItem interface properties
        /// </summary>
        public int ID => _baseWeapon.ID;
        public string Name => _baseWeapon.Name + " (Force Enhanced)";
        public string Description => _baseWeapon.Description;

        /// <summary>
        /// Implement IWeapon interface properties
        /// </summary>
        public int DamageValue => _baseWeapon.DamageValue + _damageIncrease;
        public int AttackRange => _baseWeapon.AttackRange;

        /// <summary>
        /// Implement GetBaseItem property from IItemDecorator interface
        /// </summary>
        public IItem GetBaseItem => _baseWeapon;
    }
}