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
        public ICreature Creature { get; set; }

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
                Logger.Instance.LogError("Tile occupied.");
            }
        }

        public void PlaceCreature(ICreature creature)
        {
            if (!isOccupied)
            {
                Creature = creature;
                isOccupied = true;
            }
            else
            {
                Logger.Instance.LogError("Tile occupied.");
            }
        }

    }
}