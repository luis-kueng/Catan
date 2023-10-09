using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan {
    public class Tile {
        public int DiceNumber { get; set; }
        public ResourceType ResourceType { get; set; }
        public Dictionary<TilePoint, Building> Buildings { get; set; }
        public Dictionary<TilePoint,  Tile> NeighbourTiles { get; set; }

        public Tile(ResourceType resourceType, int diceNumber) {
            this.ResourceType = resourceType;
            this.DiceNumber = diceNumber;
            this.Buildings = new Dictionary<TilePoint, Building>();
            this.NeighbourTiles = new Dictionary<TilePoint, Tile>();
        }

        public void AddBuilding(Building building, TilePoint point) {
            if (IsPointAvailable(point)) {
                this.Buildings[point] = building;
            }
        }

        private bool IsPointAvailable(TilePoint point) {
            return IsNeighbourAvailable(point, 1) && IsNeighbourAvailable(point, -1);
        }

        private bool IsNeighbourAvailable(TilePoint point, int neighbour) {
            return !this.Buildings.ContainsKey((TilePoint)((int)point + neighbour));
        }

        public Building? GetBuildingByPoint(TilePoint point) {
            if (this.Buildings.TryGetValue(point, out Building? building)) {
                return building;
            }

            return null;
        }

        public void AddNeighbouringTile(Tile tile, TilePoint point) {
            if (!this.NeighbourTiles.ContainsKey(point)) {
                this.NeighbourTiles[point] = tile;
                tile.AddNeighbouringTile(this, GetMirroredPoint(point));
            }
        }

        private TilePoint GetMirroredPoint(TilePoint point) {
            int result = (int)(point) + 3;

            if (result > 5 && result < 10 || result > 14) {
                result -= 6;
            }

            return (TilePoint)result;
        }

        public Tile? GetNeighbouringTileByPoint(TilePoint point) {
            if (this.NeighbourTiles.TryGetValue(point, out Tile? tile)) { 
                return tile; 
            }

            return null;
        }
    }
}
