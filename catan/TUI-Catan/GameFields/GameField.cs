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
                FillRowWithTiles(AmountOfTiles, i);
            }
        }

        private int CalculateAmountOfTiles(int i)
        {
            return i < FieldSize ? FieldSize + i : (FieldSize - 1) * 3 + 1 - i;
        }

        private void FillRowWithTiles(int amountOfTiles, int row)
        {
            Field[row] = new Tile[_rowSize];
            Tile?[] tiles = Field[row]; 
            int prefix = CalculateAmountOfNullValuesInTileRow(amountOfTiles);
            NeighbourUtility nb = new NeighbourUtility(Field, row);

            for (int i = 0; i < amountOfTiles; i++)
            {
                Tile newTile = Tile.CreateRandomTile();
                tiles[prefix + i] = newTile;

                nb.Column = i;
                nb.AddNeighbours();
            }
        }


        private int CalculateAmountOfNullValuesInTileRow(int amountOfTiles)
        {
            int nullSpaces = _rowSize - amountOfTiles;
            return FieldSize % 2 == 0 ? nullSpaces / 2 + 1 : nullSpaces / 2;
        }
    }
}
