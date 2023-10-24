using Catan.Tiles.Directions;

namespace Catan.Tiles.Neighbours {
    public class NeighbourUtility {
        public Tile?[][] Field {
            get; set;
        }
        public int Row {
            get; set;
        }
        public int Column {
            get; set;
        }

        public NeighbourUtility(Tile?[][] field, int row) {
            Field = field;
            Row = row;
        }

        private bool IsEvenRow() {
            return Row % 2 == 0;
        }



        public void AddAllNeighboursInField() {
            Tile? tile = Field[Row][Column];

            if (tile != null) {
                AddNeighbourToTile(TileSide.MIDLEFTSIDE, tile);
                AddNeighbourToTile(TileSide.TOPLEFTSIDE, tile);
                AddNeighbourToTile(TileSide.TOPRIGHTSIDE, tile);

            }
        }

        private void AddNeighbourToTile(TileSide side, Tile tile) {
            Tile? neighbour = GetNeighbourByDirection(side);

            if (neighbour != null) {
                tile.AddNeighbouringTile(neighbour, side);
            }
        }

        private Tile? GetNeighbourByDirection(TileSide side) {
            NeighbourVector vector = GetNeighbourVector(side);

            Tile? tile = GetNeighbourTileByVector(vector);
            return tile;
        }

        private NeighbourVector GetNeighbourVector(TileSide side) {
            return NeighbourVectorFactory.NeighbourVectorByDirection(side, IsEvenRow());
        }

        private Tile? GetNeighbourTileByVector(NeighbourVector vector) {
            int row = Row + vector.X;
            int column = Column + vector.Y;
            if (row >= 0 && row < Field.Length) {
                if (column >= 0 && column < Field[row].Length) {
                    if (Field[row][column] != null) {
                        return Field[row][column];
                    }
                }
            }

            return null;
        }
    }
}