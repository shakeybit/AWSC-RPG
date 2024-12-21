namespace RPGidea
{    /// Represents item effects.


    /// <summary>
    /// Effect interface
    /// </summary>
    
    public interface IEffect {
        int ID { get; }
        string Description { get; }
        int CastTime { get; }
        int Duration { get; }
        int Range { get; }
        int Cooldown { get; }
        int AreaRadius { get; }
        int NumberOfTargets { get; }

        public StatModifier _StatModifier { get; }
    }

    
    /// <summary>
    /// Effect constructor
    /// </summary>

    public class Effect : IEffect
    {
        private static int _nextId;
        public int ID { get; }
        public string Description { get; set; }
        public int CastTime { get; }
        public int Duration { get; }
        public int Range { get; }
        public int Cooldown { get; }
        public int AreaRadius { get; }
        public int NumberOfTargets { get; }
        public StatModifier _StatModifier { get; set; }



        public Effect(string description, int castTime, int duration, int range, int cooldown, int areaRadius, int numberOfTargets, StatModifier statModifier)
        {
            ID = _nextId++;
            Description = description;
            CastTime = castTime;
            Duration = duration;
            Range = range;
            Cooldown = cooldown;
            AreaRadius = areaRadius;
            NumberOfTargets = numberOfTargets;
            _StatModifier = statModifier;
        }
    }


    /// <summary>
    /// Effect controller
    /// </summary>
        public class EffectController
    {
        private List<Effect> effects;

        public EffectController()
        {
            effects = new List<Effect>();
        }


        




    /// <summary>
    /// Effect adders and removers
    /// </summary>


        public void AddEffect(Effect effect)
        {
            effects.Add(effect);
        }

        public void RemoveEffect(int id)
        {
            effects.RemoveAll(e => e.ID == id);
        }

        public Effect GetEffect(int id)
        {
            return effects.Find(e => e.ID == id);
        }

        public List<Effect> GetAllEffects()
        {
            return new List<Effect>(effects);
        }


    }


}