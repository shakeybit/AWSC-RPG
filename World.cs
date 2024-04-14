using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    public class World
    {
        public int _maxX { get; set; }
        public int _maxY { get; set; }
        public List<IEntity> Entities { get; set; }
        public List<Gobject> _Objects { get; set; }
        public List<Creature> _Creatures { get; set; }
        public Tile[,] Tiles { get; set; } // 2D tile array


        public World(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;

            Tiles = new Tile[maxX, maxY];
            // initialize each tile
            for (int x = 0; x < maxX; x++)
            {
                for (int y = 0; y < maxY; y++)
                {
                    Tiles[x, y] = new Tile();
                }
            }
        }

        // MODEL

    public int[] GetEntityCoordinates(IEntity entity)
    {
    for (int x = 0; x < _maxX; x++)
    {
        for (int y = 0; y < _maxY; y++)
        {
            if (Tiles[x, y].Entity == entity)
            {
                // found tile containing creature, return coordinates
                return [x, y];
            }
        }
    }

    // If the creature is not found, return null or throw an exception
    throw new Exception("error: " + entity.Name + " not found on map");
    }   


        // TILES (?)
        public Tile GetEntityTile(IEntity entity) { 
            foreach (Tile tile in Tiles) {
                if (tile.Entity == entity) {
                    return tile;
                }
            }
            Console.WriteLine("Error: " + entity.Name + " not found");
            return Tiles[0, 0];
            }


        // GET/SET

        public IEntity? GetEntityAt(int x, int y)
        {
            if (x >= 0 && x < _maxX && y >= 0 && y < _maxY)
            {
                return Tiles[x, y].Entity;
            }
            else
            {
                Console.WriteLine("error: coordinate out of bounds");
                return null;
            }
        }


        public void SetEntityAt(IEntity entity, int x, int y)
        {
            if (x >= 0 && x < _maxX && y >= 0 && y < _maxY)
            {
                Tiles[x, y].PlaceEntity(entity);
            }
            else
            {
                Console.WriteLine("error: coordinate out of bounds");
            }
        }

        public void ClearTile(int x, int y)
        {
            if (x >= 0 && x < _maxX && y >= 0 && y < _maxY)
            {
                Tiles[x, y].isOccupied = false;
             }
        }
    }
}


