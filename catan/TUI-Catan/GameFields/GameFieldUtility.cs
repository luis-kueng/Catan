using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Tiles;

namespace Catan.GameFields
{
    public class GameFieldUtility
    {
        private static readonly char _emptySpace = ' ';
        private static readonly string _pointChar = " () ";
        private static readonly string _diagonalUpChar = "//";
        private static readonly string _diagonalDownChar = @"\\";
        private static readonly string _sideChar = " || "; 

        string topRow_prefix = "";
        string diagonal1_prefix = "";
        string diagonal2_prefix = "";
        string midRow_prefix = "";
        string side1_prefix = "";
        string side2_prefix = "";

        public GameField Field { get; set; }

        public GameFieldUtility(GameField field)
        {
            Field = field;
        }

        public void PrintField()
        {
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

        private void PrintTop(Tile?[] tileRow, bool isUneven = false, bool isLowering = false)
        {
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
                    AddNullTile();
                }
            }
        }

        private void AddIfLowering() {

        }

        private void AddIfUnevenAndLowering() {
            int halfTileSize =
                3 +
                2 * _diagonalUpChar.Length +
                _pointChar.Length;

            topRow_prefix += 
                _pointChar +
                EmptySpaces(3 + 2*_diagonalDownChar.Length);

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
                2 * _diagonalUpChar.Length +
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

        private void AddTileModule(Tile tile) 
        {
            topRow_prefix += 
                EmptySpaces(3 + 2*_diagonalUpChar.Length) +
                _pointChar +
                EmptySpaces(3 + 2 * _diagonalUpChar.Length + _pointChar.Length)
                ;

            diagonal1_prefix +=
                EmptySpaces(2 + _diagonalUpChar.Length) +
                _diagonalUpChar +
                EmptySpaces(2 + _pointChar.Length) +
                _diagonalDownChar +
                EmptySpaces(2 + _diagonalDownChar.Length + _pointChar.Length);

            diagonal2_prefix +=
                _emptySpace +
                _diagonalUpChar +
                EmptySpaces(
                    4 + 
                    _diagonalUpChar.Length + 
                    _pointChar.Length + 
                    _diagonalDownChar.Length
                    ) +
                _diagonalDownChar +
                EmptySpaces(1 + _pointChar.Length);

            midRow_prefix +=
                EmptySpaces(
                    6 + 
                    2 * _diagonalUpChar.Length + 
                    2 * _diagonalDownChar.Length + 
                    _pointChar.Length
                    ) +
                _pointChar;

            side1_prefix +=
                EmptySpaces(3 + 2 * _diagonalUpChar.Length) +
                GetDiceNumberFormatted(tile) +
                EmptySpaces(3 + 2 * _diagonalUpChar.Length) +
                _sideChar;

            side2_prefix +=
                EmptySpaces(3 + 2 * _diagonalUpChar.Length) +
                GetResourceTypeFormatted(tile) +
                EmptySpaces(3 + 2 * _diagonalUpChar.Length) +
                _sideChar;
        }

        private void AddNullTile() {
            string nullTile =
                EmptySpaces(
                    6 +
                    2 * _diagonalUpChar.Length +
                    2 * _diagonalDownChar.Length +
                    2 * _pointChar.Length
                    );

            topRow_prefix += nullTile;
            diagonal1_prefix += nullTile;
            diagonal2_prefix += nullTile;
            midRow_prefix += nullTile;
            side1_prefix += nullTile;
            side2_prefix += nullTile;
        }

        private static string GetDiceNumberFormatted(Tile tile) {
            return (tile.DiceNumber > 9 ? "[" + tile.DiceNumber + "]" : "[0" + tile.DiceNumber + "]");
        }

        private static string GetResourceTypeFormatted(Tile tile) {
            string resourceType = tile.ResourceType.ToString();
            return "[" + resourceType[0] + resourceType[1] + "]";
        }

        

        private static string EmptySpaces(int amount)
        {
            return new string(_emptySpace, amount);
        }
    }
}
