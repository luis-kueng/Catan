using Catan.Buildings;
using Catan.Tiles.TilePoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles
{
    public class Tile
    {
        public int DiceNumber { get; set; }
        public ResourceType ResourceType { get; set; }
        public Dictionary<TilePoint, Building> Buildings { get; set; }
        public Dictionary<TilePoint, Tile> NeighbourTiles { get; set; }

        private static readonly Random _random = new();

        public Tile(ResourceType resourceType, int diceNumber)
        {
            ResourceType = resourceType;
            DiceNumber = diceNumber;
            Buildings = new Dictionary<TilePoint, Building>();
            NeighbourTiles = new Dictionary<TilePoint, Tile>();
        }

        public static Tile CreateRandomTile()
        {
            return new Tile(ResourceType.BRICK, _random.Next(1, 10));
        }

        public void AddBuilding(Building? building, TilePoint point)
        {
            if (IsPointAvailable(point) && building != null)
            {
                Buildings[point] = building;
            }
        }

        private bool IsPointAvailable(TilePoint point)
        {
            return 
                IsNeighbourAvailable(point, 1) && 
                IsNeighbourAvailable(point, -1) &&
                IsNeighbourOnNextTileAvailable(point);
        }

        private bool IsNeighbourAvailable(TilePoint point, int neighbour)
        {
            return !Buildings.ContainsKey((TilePoint)((int)point + neighbour));
        }

        private bool IsNeighbourOnNextTileAvailable(TilePoint point) {
            TilePoint neighbourDirection = TilePointConverter.PointToLeftNeighbourSide(point);

            Tile? neighbourTile;

            if (NeighbourTiles.ContainsKey(neighbourDirection)) {
                neighbourTile = NeighbourTiles[neighbourDirection];
            } else {
               neighbourDirection = TilePointConverter.PointToRightNeighbourSide(point);

                if (NeighbourTiles.ContainsKey(neighbourDirection)) {
                    neighbourTile = NeighbourTiles[neighbourDirection];
                } else {
                    return false;
                }
            }

            TilePoint directionForNeighbour;

            switch (neighbourDirection) {
                case TilePoint.TOP_RIGHT_SIDE:
                    directionForNeighbour = TilePoint.TOP_RIGHT_POINT;
                    break;

                default:
                    return true;
            }

            return !neighbourTile.Buildings.ContainsKey(directionForNeighbour);
        }

        public Building? GetBuildingByPoint(TilePoint point)
        {
            if (Buildings.TryGetValue(point, out Building? building))
            {
                return building;
            }

            return null;
        }

        public void AddNeighbouringTile(Tile tile, TilePoint point)
        {
            if (!NeighbourTiles.ContainsKey(point))
            {
                NeighbourTiles[point] = tile;
                tile.AddNeighbouringTile(this, GetMirroredPoint(point));
            }
        }

        private static TilePoint GetMirroredPoint(TilePoint point)
        {
            int result = (int)point + 3;

            if (result > 5 && result < 10 || result > 15)
            {
                result -= 6;
            }

            return (TilePoint)result;
        }

        public Tile? GetNeighbouringTileByPoint(TilePoint point)
        {
            if (NeighbourTiles.TryGetValue(point, out Tile? tile))
            {
                return tile;
            }

            return null;
        }

        public static bool IsNotNull(Tile? tile) {
            return tile != null;
        }

        public void GiveOutResources() {
            foreach (Building building in Buildings.Values) {
                building.AddResource(ResourceType);
            }
        }
    }
}
