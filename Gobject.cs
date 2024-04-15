using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
        /// <summary>
        /// gobject has no unique values to entity. TODO: IItem Key that creature must possess to loot gobject
        /// </summary>        
    public interface IGobject : IEntity 

    {

    }

    public class Gobject : IEntity
    {
        public int ID { get; }
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public List<IItem> Items { get; set; }

        public Gobject(int hitPoints)
        {
            HitPoints = hitPoints;
            Items = new List<IItem>();
        }

        public void AddItem(IItem item)
        {
            Items.Add(item);
        }

        public List<IItem> GetItems()
        {
            return Items;
        }
    }
}



