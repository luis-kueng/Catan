using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles.Neighbours
{
    public class NeighbourUtility
    {
        public Tile?[][] Field { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public NeighbourUtility(Tile?[][] field, int row)
        {
            Field = field;
            Row = row;
        }

        private bool IsEvenRow()
        {
            return Row % 2 == 0;
        }

        

        public void AddAllNeighboursInField()
        {
            Tile? tile = Field[Row][Column];

            if (Tile.IsNotNull(tile))
            {
                AddNeighbourToTile(TilePoint.MID_LEFT_SIDE, tile);
                AddNeighbourToTile(TilePoint.TOP_RIGHT_SIDE, tile);
                AddNeighbourToTile(TilePoint.TOP_LEFT_SIDE, tile);
            }
        }

        private void AddNeighbourToTile(TilePoint point, Tile tile)
        {
            Tile? neighbour = GetNeighbourByDirection(point);

            if (Tile.IsNotNull(neighbour))
            {
                tile.AddNeighbouringTile(neighbour, point);
            }
        }

        private Tile? GetNeighbourByDirection(TilePoint point)
        {
            NeighbourVector vector = GetNeighbourVector(point);

            Tile? tile = GetNeighbourTileByVector(vector);
            return tile;
        }

        private NeighbourVector GetNeighbourVector(TilePoint point)
        {
            return NeighbourVectorFactory.NeighbourVectorByDirection(point, IsEvenRow());
        }

        private Tile? GetNeighbourTileByVector(NeighbourVector vector)
        {
            int row = Row + vector.X;
            int column = Column + vector.Y;
            if (row > 0 && row < Field.Length) {
                if (column > 0 && column < Field[row].Length) {
                    if (Field[row][column] != null) {
                        return Field[row][column];
                    }
                }
            }
            return null;
        }
    }
}