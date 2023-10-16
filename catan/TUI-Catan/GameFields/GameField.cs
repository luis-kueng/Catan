using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Neighbours;

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
            for (int row = 0; row < _rowSize; row++)
            {
                int AmountOfTiles = CalculateAmountOfTiles(row);
                FillRowWithTiles(AmountOfTiles, row);
            }
        }

        private int CalculateAmountOfTiles(int i)
        {
            return i < FieldSize ? FieldSize + i : (FieldSize - 1) * 3 + 1 - i;
        }

        private void FillRowWithTiles(int amountOfTiles, int row)
        {
            NeighbourUtility nb = new(Field, row);
            Field[row] = new Tile[_rowSize];
            int prefix = CalculateAmountOfNullValuesInTileRow(amountOfTiles);

            for (int i = 0; i < amountOfTiles; i++)
            {
                Field[row][prefix + i] = Tile.CreateRandomTile(); ;

                nb.Column = i;
                nb.AddAllNeighboursInField();
            }
        }


        private int CalculateAmountOfNullValuesInTileRow(int amountOfTiles)
        {
            int nullSpaces = _rowSize - amountOfTiles;
            return FieldSize % 2 == 0 ? ((nullSpaces == 0) ? 0 : nullSpaces / 2 + 1) : nullSpaces / 2;
        }

        public void AddBuildingToField(BuildingType buildingType, Player player, int x, int y) {
            if (Tile.IsNotNull(Field[x][y])) {
                Building? building = BuildingFactory.Building(buildingType, player);
                Field[x][y]?.AddBuilding(building, TilePoint.BOTTOM_RIGHT_POINT);
            }
        }

        public void GiveOutResources() {
            foreach (var field in Field) {
                foreach (var tile in field) {
                    tile?.GiveOutResources();
                }
            }
        }
    }
}
