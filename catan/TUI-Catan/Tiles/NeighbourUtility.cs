using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles {
    public class NeighbourUtility {
        public Tile?[][] Field {  get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        private bool IsEven;

        public NeighbourUtility(Tile?[][] field, int row) {
            this.Field = field;
            this.Row = row;
            IsEven = IsEvenRow();
        }

        private bool IsEvenRow() {
            return Row % 2 == 0;
        }

        public void AddNeighbours() {
            Tile? tile = Field[Row][Column];

            if (tile != null) {
                AddNeighbour(TilePoint.MID_LEFT_SIDE, tile);
                AddNeighbour(TilePoint.TOP_RIGHT_SIDE, tile);
                AddNeighbour(TilePoint.TOP_LEFT_SIDE, tile);
            }
        }

        private void AddNeighbour(TilePoint point, Tile tile) {
            Tile? neighbour = GetNeighbour(point);

            if (neighbour != null) {
                tile.AddNeighbouringTile(neighbour, point);
            }
        }

        private Tile? GetNeighbour(TilePoint point) {
            try {
                NeighbourVector vector = GetNeighbourVector(point);

                Tile? tile = GetNeighbourTileByVector(vector);
                return tile;

            } catch (IndexOutOfRangeException) {
                return null;
            }
        }

        private NeighbourVector GetNeighbourVector(TilePoint point) {
            return NeighbourVectorFactory.NeighbourVectorByDirection(point, IsEven);
        }

        private Tile? GetNeighbourTileByVector(NeighbourVector vector) {
            int row = Row + vector.X;
            int column = Column + vector.Y;
            return Field[row][column];
        }
    }
}