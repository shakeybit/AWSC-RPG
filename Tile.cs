using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{

    public class Tile
    {
        public bool isOccupied = false;
        public IEntity Entity { get; set; }
        public Creature Creature { get; private set; }

        public bool IsOccupied => isOccupied;

        public void PlaceEntity(IEntity entity)
        {
            if (!isOccupied)
            {
                Entity = entity;
                isOccupied = true;
            }
            else
            {
                Console.WriteLine("error: tile occupied");
            }
        }

        public void PlaceCreature(Creature creature)
        {
            if (!isOccupied)
            {
                Creature = creature;
                isOccupied = true;
            }
            else
            {
                Console.WriteLine("error: tile occupied");
            }
        }
    }
}