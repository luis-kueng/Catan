using Catan.Buildings;
using Catan.GameFields;
using Catan.Tiles;
using Catan.Tiles.Directions;

namespace Catan.Utilities {
    public class GameFieldUtility {
        private const char _emptySpace = ' ';
        private const string _pointChar = " () ";
        private const string _diagonalUpChar = "//";
        private const string _diagonalDownChar = @"\\";
        private const string _sideChar = " || ";

        string topRow_prefix = "";
        string diagonal1_prefix = "";
        string diagonal2_prefix = "";
        string midRow_prefix = "";
        string side1_prefix = "";
        string side2_prefix = "";

        public GameField Field {
            get; set;
        }

        public GameFieldUtility(GameField field) {
            Field = field;
        }

        public void PrintField() {
            for (int i = 0; i < Field.Field.Length; i++) {
                topRow_prefix = "";
                diagonal1_prefix = "";
                diagonal2_prefix = "";
                midRow_prefix = "";
                side1_prefix = "";
                side2_prefix = "";

                var isUneven = i % 2 != 0;
                var isLowering = i >= Field.FieldSize;

                PrintTop(Field.Field[i], isUneven: isUneven, isLowering: isLowering);

                Console.WriteLine(topRow_prefix);
                Console.WriteLine(diagonal1_prefix);
                Console.WriteLine(diagonal2_prefix);
                Console.WriteLine(midRow_prefix);
                Console.WriteLine(side1_prefix);
                Console.WriteLine(side2_prefix);
            }
        }

        private void PrintTop(Tile?[] tileRow, bool isUneven = false, bool isLowering = false) {
            bool isFrstTile = true;

            foreach (Tile? tile in tileRow) {
                if (tile != null) {
                    if (isFrstTile) {
                        if (isUneven) {
                            if (isLowering) {
                                AddIfUnevenAndLowering();
                            } else {
                                AddIfUneven();
                            }
                        } else if (isLowering) {
                            AddIfLowering();
                        }

                        AddFirstTileSection();
                        isFrstTile = false;
                    }

                    AddTileModule(tile);
                } else {
                    if (isFrstTile) {
                        AddNullTile();
                    }
                }
            }

            if (isLowering) {
                topRow_prefix +=
                    EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                    _pointChar;

                diagonal1_prefix +=
                    EmptySpaces(2 + _diagonalUpChar.Length) +
                    _diagonalUpChar;

                diagonal2_prefix +=
                    _emptySpace +
                    _diagonalUpChar;
            }
        }

        private void AddIfLowering() {
            topRow_prefix =
                topRow_prefix.Remove(0, 3 + _pointChar.Length + (2 * _diagonalDownChar.Length)) +
                _pointChar +
                EmptySpaces(3 + (2 * _diagonalDownChar.Length));

            diagonal1_prefix =
                diagonal1_prefix.Remove(0, 2 + (2 * _diagonalDownChar.Length)) +
                _diagonalDownChar +
                EmptySpaces(2 + _diagonalDownChar.Length);

            diagonal2_prefix =
                diagonal2_prefix.Remove(0, 2 + (2 * _diagonalDownChar.Length)) +
                EmptySpaces(1 + _diagonalDownChar.Length) +
                _diagonalDownChar +
                EmptySpaces(1);
        }

        private void AddIfUnevenAndLowering() {
            int halfTileSize =
                3 +
                (2 * _diagonalUpChar.Length) +
                _pointChar.Length;

            topRow_prefix +=
                _pointChar +
                EmptySpaces(3 + (2 * _diagonalDownChar.Length));

            diagonal1_prefix +=
                EmptySpaces(1 + _pointChar.Length) +
                _diagonalDownChar +
                EmptySpaces(2 + _diagonalDownChar.Length);

            diagonal2_prefix +=
                EmptySpaces(2 + _pointChar.Length + _diagonalDownChar.Length) +
                _diagonalDownChar +
                EmptySpaces(1);

            midRow_prefix += EmptySpaces(halfTileSize);
            side1_prefix += EmptySpaces(halfTileSize);
            side2_prefix += EmptySpaces(halfTileSize);
        }

        private void AddIfUneven() {
            int halfTileSize =
                3 +
                (2 * _diagonalUpChar.Length) +
                _pointChar.Length;

            topRow_prefix += EmptySpaces(halfTileSize);
            diagonal1_prefix += EmptySpaces(halfTileSize);
            diagonal2_prefix += EmptySpaces(halfTileSize);
            midRow_prefix += EmptySpaces(halfTileSize);
            side1_prefix += EmptySpaces(halfTileSize);
            side2_prefix += EmptySpaces(halfTileSize);
        }

        private void AddFirstTileSection() {
            topRow_prefix += EmptySpaces(_pointChar.Length);
            diagonal1_prefix += EmptySpaces(_pointChar.Length);
            diagonal2_prefix += EmptySpaces(_pointChar.Length);
            midRow_prefix += _pointChar;
            side1_prefix += _sideChar;
            side2_prefix += _sideChar;
        }

        private void AddTileModule(Tile tile) {
            tile.Buildings.TryGetValue(TilePoint.TOPPOINT, out Building? building);

            topRow_prefix +=
                EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                (building == null ? _pointChar : "(XX)") +
                EmptySpaces(3 + (2 * _diagonalUpChar.Length) + _pointChar.Length)
                ;

            tile.Streets.TryGetValue(TileSide.TOPLEFTSIDE, out StreetBuilding? street_topLeft);
            tile.Streets.TryGetValue(TileSide.TOPRIGHTSIDE, out StreetBuilding? street_topRight);

            diagonal1_prefix +=
                EmptySpaces(2 + _diagonalUpChar.Length) +
                (street_topLeft == null ? _diagonalUpChar : "XX") +
                EmptySpaces(2 + _pointChar.Length) +
                (street_topRight == null ? _diagonalDownChar : "XX") +
                EmptySpaces(2 + _diagonalDownChar.Length + _pointChar.Length);

            diagonal2_prefix +=
                _emptySpace +
                (street_topLeft == null ? _diagonalUpChar : "XX") +
                EmptySpaces(
                    4 +
                    _diagonalUpChar.Length +
                    _pointChar.Length +
                    _diagonalDownChar.Length
                    ) +
                (street_topRight == null ? _diagonalDownChar : "XX") +
                EmptySpaces(1 + _pointChar.Length);

            tile.Buildings.TryGetValue(TilePoint.TOPRIGHTPOINT, out Building? building2);

            midRow_prefix +=
                EmptySpaces(
                    6 +
                    (2 * _diagonalUpChar.Length) +
                    (2 * _diagonalDownChar.Length) +
                    _pointChar.Length
                    ) +
                (building2 == null ? _pointChar : "(XX)");

            tile.Streets.TryGetValue(TileSide.MIDRIGHTSIDE, out StreetBuilding? street_midRight);

            side1_prefix +=
                EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                GetDiceNumberFormatted(tile) +
                EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                (street_midRight == null ? _sideChar : " SS ");

            side2_prefix +=
                EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                GetResourceTypeFormatted(tile) +
                EmptySpaces(3 + (2 * _diagonalUpChar.Length)) +
                (street_midRight == null ? _sideChar : " SS ");
        }

        private void AddNullTile() {
            string nullTile =
                EmptySpaces(
                    6 +
                    (2 * _diagonalUpChar.Length) +
                    (2 * _diagonalDownChar.Length) +
                    (2 * _pointChar.Length)
                    );

            topRow_prefix += nullTile;
            diagonal1_prefix += nullTile;
            diagonal2_prefix += nullTile;
            midRow_prefix += nullTile;
            side1_prefix += nullTile;
            side2_prefix += nullTile;
        }

        private static string GetDiceNumberFormatted(Tile tile) {
            return tile.DiceNumber > 9 ? "[" + tile.DiceNumber + "]" : "[0" + tile.DiceNumber + "]";
        }

        private static string GetResourceTypeFormatted(Tile tile) {
            string resourceType = tile.ResourceType.ToString();
            return "[" + resourceType[0] + resourceType[1] + "]";
        }

        private static string EmptySpaces(int amount) {
            return new string(_emptySpace, amount);
        }
    }
}
