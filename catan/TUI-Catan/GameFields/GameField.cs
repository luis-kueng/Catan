using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;
using Catan.Tiles.Neighbours;

namespace Catan.GameFields {
    public class GameField {
        public Tile?[][] Field {
            get; set;
        }
        private readonly int FieldSize;

        private readonly int _rowSize;
        private readonly NeighbourUtility nb;
        private readonly Tile[] allTiles;

        public GameField(int fieldSize) {
            FieldSize = fieldSize;
            _rowSize = (2 * fieldSize) - 1;
            Field = new Tile?[(2 * FieldSize) - 1][];
            nb = new(Field, 0);

            GenerateField();
            allTiles = CollectAllTiles();
        }

        private Tile[] CollectAllTiles() {
            List<Tile> tiles = new();

            foreach (var row in Field) {
                foreach (var tile in row) {
                    if (tile == null) continue;
                    tiles.Add(tile);
                }
            }

            return tiles.ToArray();
        }

        private void GenerateField() {
            for (int row = 0; row < _rowSize; row++) {
                int AmountOfTiles = CalculateAmountOfTiles(row);
                FillRowWithTiles(AmountOfTiles, row);
            }
        }

        private int CalculateAmountOfTiles(int i) {
            return i < FieldSize ? FieldSize + i : ((FieldSize - 1) * 3) + 1 - i;
        }

        private void FillRowWithTiles(int amountOfTiles, int row) {
            MakeNewRow(row);

            int prefix = CalculateAmountOfNullValuesInTileRow(amountOfTiles);

            for (int i = 0; i < amountOfTiles; i++) {
                AddRandomTileToField(row, prefix + i);
                AddAllNeighbours(i);
            }
        }

        private void MakeNewRow(int row) {
            nb.Row = row;
            Field[row] = new Tile[_rowSize];
        }

        private int CalculateAmountOfNullValuesInTileRow(int amountOfTiles) {
            int nullSpaces = _rowSize - amountOfTiles;
            return FieldSize % 2 == 0 ? ((nullSpaces == 0) ? 0 : (amountOfTiles % 2 == 0 ? (nullSpaces / 2) + 1 : (nullSpaces / 2))) : nullSpaces / 2;
        }

        private void AddRandomTileToField(int row, int column) {
            Field[row][column] = Tile.CreateRandomTile();
        }

        private void AddAllNeighbours(int i) {
            nb.Column = i;
            nb.AddAllNeighboursInField();
        }

        public void AddBuildingToField(BuildingType buildingType, Player player, int x, int y, TilePoint point) {
            Console.WriteLine("Creating Building");
            Building? building = BuildingFactory.Building(buildingType, player);
            if (building != null) {
                Console.WriteLine("Built " + building.GetType().Name + " by Player " + building.Player.Name);
                Field[x][y]?.BuildOnTile(building, point);
            }
        }

        public void GiveOutResources(int diceNumber) {
            foreach (var tile in allTiles) {
                if (tile.DiceNumber == diceNumber)
                    tile.GiveOutResources();
            }
        }

        public void GiveOutResources(Player buildingOwner) {
            foreach (var tile in allTiles) {
                tile.GiveOutResources(buildingOwner);
            }
        }
    }
}
