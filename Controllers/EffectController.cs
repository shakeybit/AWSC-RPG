using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea.Controllers {
    public class Effect
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Effect(int id, string name, string description)
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }

    public class EffectController
    {
        private List<Effect> effects;

        public EffectController()
        {
            effects = new List<Effect>();
        }

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
