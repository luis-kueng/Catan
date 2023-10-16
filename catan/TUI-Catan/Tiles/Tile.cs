using Catan.Buildings;
using Catan.Tiles.Directions;
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
        public Dictionary<TileSide, StreetBuilding> Streets { get; set; }
        public Dictionary<TileSide, Tile> NeighbourTiles { get; set; }

        private static readonly Random _random = new();

        public Tile(ResourceType resourceType, int diceNumber)
        {
            ResourceType = resourceType;
            DiceNumber = diceNumber;
            Buildings = new Dictionary<TilePoint, Building>();
            Streets = new Dictionary<TileSide, StreetBuilding>();
            NeighbourTiles = new Dictionary<TileSide, Tile>();
        }

        public static Tile CreateRandomTile()
        {
            return new Tile(ResourceType.BRICK, _random.Next(1, 12));
        }

        public void AddBuilding(Building? building, TilePoint point)
        {
            if (IsPointAvailable(point) && building != null)
            {
                Buildings[point] = building;
            }
        }

        public void AddStreet(StreetBuilding? street, TileSide side) {
            if (street != null) {
                Streets[side] = street;
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
            TileSide neighbourDirection = DirectionConverter.PointToLeftNeighbourSide(point);

            Tile? neighbourTile;

            if (NeighbourTiles.ContainsKey(neighbourDirection)) {
                neighbourTile = NeighbourTiles[neighbourDirection];
            } else {
               neighbourDirection = DirectionConverter.PointToRightNeighbourSide(point);

                if (NeighbourTiles.ContainsKey(neighbourDirection)) {
                    neighbourTile = NeighbourTiles[neighbourDirection];
                } else {
                    return false;
                }
            }

            TilePoint directionForNeighbour = TilePoint.TOP_POINT;

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

        public void AddNeighbouringTile(Tile tile, TileSide side)
        {
            if (!NeighbourTiles.ContainsKey(side))
            {
                NeighbourTiles[side] = tile;
                tile.AddNeighbouringTile(this, DirectionConverter.GetMirroredSide(side));
            }
        }

        public Tile? GetNeighbouringTileByPoint(TileSide side)
        {
            if (NeighbourTiles.TryGetValue(side, out Tile? tile))
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
