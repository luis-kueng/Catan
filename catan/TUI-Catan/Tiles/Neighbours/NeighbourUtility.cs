using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Tiles.Directions;

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
                AddNeighbourToTile(TileSide.MID_LEFT_SIDE, tile);
                AddNeighbourToTile(TileSide.TOP_RIGHT_SIDE, tile);
                AddNeighbourToTile(TileSide.TOP_LEFT_SIDE, tile);
            }
        }

        private void AddNeighbourToTile(TileSide side, Tile tile)
        {
            Tile? neighbour = GetNeighbourByDirection(side);

            if (Tile.IsNotNull(neighbour))
            {
                tile.AddNeighbouringTile(neighbour, side);
            }
        }

        private Tile? GetNeighbourByDirection(TileSide side)
        {
            NeighbourVector vector = GetNeighbourVector(side);

            Tile? tile = GetNeighbourTileByVector(vector);
            return tile;
        }

        private NeighbourVector GetNeighbourVector(TileSide side)
        {
            return NeighbourVectorFactory.NeighbourVectorByDirection(side, IsEvenRow());
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