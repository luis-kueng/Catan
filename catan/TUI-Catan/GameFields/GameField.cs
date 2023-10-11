using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Tiles;

namespace Catan.GameFields
{
    public class GameField
    {
        public Tile?[][] Field { get; set; }
        public int FieldSize { get; set; }

        private readonly int _rowSize;


        public GameField(int fieldSize)
        {
            FieldSize = fieldSize;
            Field = new Tile?[2 * FieldSize - 1][];
            _rowSize = 2 * fieldSize - 1;
            GenerateField();
        }
        private void GenerateField()
        {
            for (int i = 0; i < _rowSize; i++)
            {
                int AmountOfTiles = CalculateAmountOfTiles(i);
                Field[i] = FillRowWithTiles(AmountOfTiles, i);
            }
        }

        private int CalculateAmountOfTiles(int i)
        {
            return i < FieldSize ? FieldSize + i : (FieldSize - 1) * 3 + 1 - i;
        }

        private Tile?[] FillRowWithTiles(int amountOfTiles, int row)
        {
            Tile?[] tiles = new Tile[_rowSize];
            int prefix = CalculateAmountOfNullValuesInTileRow(amountOfTiles);

            for (int i = 0; i < amountOfTiles; i++)
            {
                Tile newTile = Tile.CreateRandomTile();

                if (row % 2 == 0)
                {
                    if (prefix + i > 0)
                    {
                        Tile? leftTile = tiles[prefix + i - 1];

                        if (leftTile != null)
                        {
                            newTile.AddNeighbouringTile(leftTile, TilePoint.MID_LEFT_SIDE);
                        }
                    }

                    if (row > 0)
                    {
                        if (i <= Field[row - 1].Length && i > 0)
                        {
                            Tile? topLeftTile = Field[row - 1][i - 1];

                            if (topLeftTile != null)
                            {
                                newTile.AddNeighbouringTile(topLeftTile, TilePoint.TOP_LEFT_SIDE);
                            }
                        }

                        Tile? topRightTile = Field[row - 1][i];

                        if (topRightTile != null)
                        {
                            newTile.AddNeighbouringTile(topRightTile, TilePoint.TOP_RIGHT_SIDE);
                        }
                    }
                }
                else
                {
                    if (prefix + i > 0)
                    {
                        Tile? leftTile = tiles[prefix + i - 1];

                        if (leftTile != null)
                        {
                            newTile.AddNeighbouringTile(leftTile, TilePoint.MID_LEFT_SIDE);
                        }
                    }

                    if (row > 0)
                    {
                        AddNeighbourTile(newTile, TilePoint.TOP_LEFT_SIDE, row, i);
                        AddNeighbourTile(newTile, TilePoint.TOP_RIGHT_SIDE, row, i);
                    }
                }

                tiles[prefix + i] = newTile;
            }

            return tiles;
        }

        private void AddNeighbourTile(Tile newTile, TilePoint point, int row, int i)
        {
            FieldCoordinatesByDirection(point, row, i, out int x, out int y);
            Tile? neighbourTile = Field[x][y];

            if (neighbourTile != null)
            {
                newTile.AddNeighbouringTile(neighbourTile, point);
            }
        }

        private void FieldCoordinatesByDirection(TilePoint point, int row, int i, out int x, out int y)
        {
            switch (point)
            {
                case TilePoint.TOP_RIGHT_SIDE:
                    x = row - 1;
                    y = i + 1;
                    break;

                case TilePoint.TOP_LEFT_SIDE:
                    x = row - 1;
                    y = i;
                    break;

                case TilePoint.MID_LEFT_SIDE:
                    y = row;
                    x = i - 1;
                    break;

                case TilePoint.MID_RIGHT_SIDE:
                    y = row;
                    x = i + 1;
                    break;

                default:
                    x = row;
                    y = i;
                    break;
            }
        }


        private int CalculateAmountOfNullValuesInTileRow(int amountOfTiles)
        {
            int nullSpaces = _rowSize - amountOfTiles;
            return FieldSize % 2 == 0 ? nullSpaces / 2 + 1 : nullSpaces / 2;
        }
    }
}
