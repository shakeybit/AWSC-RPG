using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    public interface IGobject : IEntity {
        int ID { get;}
        string Name { get; }
        int HitPoints { get; }
        public List<IItem> Items { get; set; }



    }

    public class Gobject : IGobject
    {
        public int ID { get; } 
        public string Name { get; set;}
        public int HitPoints { get; set; }
        public List<IItem> Items { get; set; }
        
        public Armor GetEquippedArmor() { return new Armor(0, "None", "Unarmored", 0); } 
        // default : not part of List<IItem>, eg. dont show up in creature/gobject inventory, only equipped status 

        public int Accept(IEntityVisitor visitor) {
            return visitor.Visit(this);
        }




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



