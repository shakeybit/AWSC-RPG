using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGidea
{
    /// <summary>
    /// World is responsible for mapping, tracking and populating a grid that position entities in the game
    /// </summary>
    public class World
    {
        public int _maxX { get; set; }
        public int _maxY { get; set; }
        public List<IEntity> Entities { get; set; }
        public List<Gobject> _Objects { get; set; }

        public Tile[,] Tiles { get; set; }


        public World(int maxX, int maxY)
        {
            _maxX = maxX;
            _maxY = maxY;
            Entities = new List<IEntity>();


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

        /// <summary>
        /// Methods to handle coordinates
        /// </summary>
        /// <param name="entity">An Entity placed in Tile grid</param>
        /// <returns>entity coordinates</returns>
        /// <exception cref="Exception">if Entity isn't placed can't get it</exception>

        public int[] GetEntityCoordinates(IEntity entity)
        {
            for (int x = 0; x < _maxX; x++)
            {
                for (int y = 0; y < _maxY; y++)
                {
                    if (Tiles[x, y].Entity == entity)
                    {
                        return [x, y];
                    }
                }
            }
            Logger.Instance.LogError("Entity not found.");
            throw new Exception("Entity not found.");
        }
    



    /// <summary>
    /// Uses "Manhattan distance formular" to determine the distance between 2 points in the 2D array grid
    /// </summary>
    /// <param name="coord1"> an array of 2 coordinates representing a position of a placement inside the 2d array grid </param>
    /// <param name="coord2"> coordinates for second position </param>
    /// <returns>the amount of posistions between the two coordinates</returns>
    public int CalculateDistance(int[] coord1, int[] coord2)
    {
        return Math.Abs(coord1[0] - coord2[0]) + Math.Abs(coord1[1] - coord2[1]);
    }


    /// <summary>
    /// Methods to handle Entity in World 
    /// </summary>

    public void AddEntity(IEntity entity)
    {
        Entities.Add(entity);
    }
    public void RemoveEntity(IEntity entity)
    {
        Entities.Remove(entity);
    }

    /// <summary>
    /// LINQ create enumerable list of entities and adds them to world
    /// </summary>

    public void AddEntities(params IEntity[] entities)
    {

        var entitiesToAdd = entities.ToList();


        Entities.AddRange(entitiesToAdd);
    }


    public IEntity GetEntityAt(int x, int y)
    {
        if (x >= 0 && x < _maxX && y >= 0 && y < _maxY)
        {
            return Tiles[x, y].Entity;
        }
        else
        {

            Logger.Instance.LogError("Entity not found.");
            throw new Exception();
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
            Logger.Instance.LogError("Coordinates out of bounds.");
        }
    }

    /// <summary>
    /// Methods to handle Tile in World
    /// </summary>

    public Tile GetEntityTile(IEntity entity)
    {
        foreach (Tile tile in Tiles)
        {
            if (tile.Entity == entity)
            {
                return tile;
            }
        }
        Logger.Instance.LogError("Entity not found.");
        throw new Exception();
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


