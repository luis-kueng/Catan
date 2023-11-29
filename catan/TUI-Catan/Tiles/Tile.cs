using Catan.Buildings;
using Catan.Players;
using Catan.Tiles.Directions;

namespace Catan.Tiles {
    public class Tile {
        public int DiceNumber {
            get; set;
        }
        public ResourceType ResourceType {
            get; set;
        }
        private readonly Dictionary<TilePoint, Building> Buildings;
        private readonly Dictionary<TileSide, StreetBuilding> Streets;
        private readonly Dictionary<TileSide, Tile> NeighbourTiles;

        private static readonly Random _random = new();

        public Tile(ResourceType resourceType, int diceNumber) {
            ResourceType = resourceType;
            DiceNumber = diceNumber;
            Buildings = new Dictionary<TilePoint, Building>();
            Streets = new Dictionary<TileSide, StreetBuilding>();
            NeighbourTiles = new Dictionary<TileSide, Tile>();
        }

        public static Tile CreateRandomTile() {
            Array values = Enum.GetValues(typeof(ResourceType));

            ResourceType resource = (ResourceType)values.GetValue(_random.Next(values.Length));

            return new Tile(resource, _random.Next(1, 12));
        }

        public void BuildOnTile(Building? building, TilePoint point) {
            if (IsPointAvailable(point) && building != null) {
                AddBuilding(building, point);
                AddBuildingToNeighbour(building, point);
            }
        }

        private void AddBuildingToNeighbour(Building building, TilePoint point) {
            TilePoint mirroredPointRight = DirectionConverter.MirroredPointRight(point);
            TilePoint mirroredPointLeft = DirectionConverter.MirroredPointLeft(point);

            TileSide rightNeighbourSide = DirectionConverter.PointToRightNeighbourSide(point);
            TileSide leftNeighbourSide = DirectionConverter.PointToLeftNeighbourSide(point);

            Tile? rightNeighbour = GetNeighbouringTileByPoint(rightNeighbourSide);
            Tile? leftNeighbour = GetNeighbouringTileByPoint(leftNeighbourSide);

            rightNeighbour?.AddBuilding(building, mirroredPointRight);
            leftNeighbour?.AddBuilding(building, mirroredPointLeft);
        }

        private void AddBuilding(Building building, TilePoint point) {
            Buildings[point] = building;
        }

        public void AddStreet(StreetBuilding? street, TileSide side) {
            if (street != null) {
                Streets[side] = street;
            }
        }

        private bool IsPointAvailable(TilePoint point) {
            return
                IsLeftNeighboutAvailable(point) &&
                IsRightNeighbourAvailable(point) &&
                IsNeighbourOnNextTileAvailable(point);
        }

        private bool IsLeftNeighboutAvailable(TilePoint point) {
            return GetBuildingByPoint(DirectionConverter.PointToLeft(point)) == null;
        }

        private bool IsRightNeighbourAvailable(TilePoint point) {
            return GetBuildingByPoint(DirectionConverter.PointToRight(point)) == null;

        }

        private bool IsNeighbourOnNextTileAvailable(TilePoint point) {
            try {
                TileSide leftDirection = DirectionConverter.PointToLeftNeighbourSide(point);
                TileSide rightDirection = DirectionConverter.PointToRightNeighbourSide(point);

                Tile? leftTile = GetNeighbouringTileByPoint(leftDirection);
                Tile? rightTile = GetNeighbouringTileByPoint(rightDirection);

                if (leftTile != null) {
                    return leftTile.GetBuildingByPoint(DirectionConverter.MirroredPointLeft(point)) == null;
                }

                if (rightTile != null) {
                    return rightTile.GetBuildingByPoint(DirectionConverter.MirroredPointRight(point)) == null;
                }

                return true;
            } catch (NotSupportedException) {
                return false;
            }
        }

        public Building? GetBuildingByPoint(TilePoint point) {
            if (Buildings.TryGetValue(point, out Building? building)) {
                return building;
            }

            return null;
        }

        public void AddNeighbouringTile(Tile tile, TileSide side) {
            if (tile != null && !NeighbourTiles.ContainsKey(side)) {
                NeighbourTiles[side] = tile;
                tile.AddNeighbouringTile(this, DirectionConverter.MirroredSide(side));
            }
        }

        public Tile? GetNeighbouringTileByPoint(TileSide side) {
            if (NeighbourTiles.TryGetValue(side, out Tile? tile)) {
                return tile;
            }

            return null;
        }

        public static bool IsNotNull(Tile? tile) {
            return tile != null;
        }

        public void GiveOutResources() {
            foreach (Building building in Buildings.Values) {
                building.GivePlayerResource(ResourceType);
            }
        }

        public void GiveOutResources(Player buildingOwner) {
            foreach (Building building in Buildings.Values) {
                if (building.Player == buildingOwner)
                    building.GivePlayerResource(ResourceType);
            }
        }
    }
}
