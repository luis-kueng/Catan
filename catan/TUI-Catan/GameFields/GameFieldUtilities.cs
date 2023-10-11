using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Tiles;

namespace Catan.GameFields
{
    public class GameFieldUtilities
    {
        private static readonly char _emptySpace = ' ';
        private static readonly string _pointChar = "(  )";
        private static readonly string _diagonalUpChar = "//";
        private static readonly string _diagonalDownChar = @"\\";
        private static readonly string _sideChar = " || ";

        public GameField Field { get; set; }

        public GameFieldUtilities(GameField field)
        {
            Field = field;
        }

        public void PrintField()
        {
            PrintTop(Field.Field[0]);
            PrintTop(Field.Field[1], isUneven: true);
            PrintTop(Field.Field[2]);
            PrintTop(Field.Field[3], true, true);
            PrintTop(Field.Field[4], isLowering: true);
        }

        private static void PrintTop(Tile?[] tileRow, bool isUneven = false, bool isLowering = false)
        {
            string topRow_prefix = "";
            string diagonal1_prefix = "";
            string diagonal2_prefix = "";
            string midRow_prefix = "";
            string side1_prefix = "";
            string side2_prefix = "";


            bool hasStarted = false;

            for (int i = 0; i < tileRow.Length; i++)
            {
                Tile? tile = tileRow[i];

                if (tile == null)
                {

                    topRow_prefix += EmptySpaces(22);
                    diagonal1_prefix += EmptySpaces(22);
                    diagonal2_prefix += EmptySpaces(22);
                    midRow_prefix += EmptySpaces(22);
                    side1_prefix += EmptySpaces(22);
                    side2_prefix += EmptySpaces(22);

                }
                else
                {

                    if (!hasStarted)
                    {
                        if (isUneven)
                        {
                            int halfTileSize = 2 + _pointChar.Length + 2 * _diagonalUpChar.Length + 1;
                            topRow_prefix += EmptySpaces(halfTileSize);
                            diagonal1_prefix += EmptySpaces(halfTileSize - _diagonalDownChar.Length + 2);
                            diagonal2_prefix += EmptySpaces(halfTileSize - _diagonalDownChar.Length + 2);
                            midRow_prefix += EmptySpaces(halfTileSize);
                            side1_prefix += EmptySpaces(halfTileSize);
                            side2_prefix += EmptySpaces(halfTileSize);
                        }

                        if (isLowering)
                        {
                            topRow_prefix += _pointChar;
                            diagonal1_prefix = EmptySpaces(1 + _pointChar.Length) + _diagonalDownChar;
                            diagonal2_prefix = EmptySpaces(2 + _diagonalDownChar.Length + _pointChar.Length) + _diagonalDownChar;
                        }

                        midRow_prefix += _pointChar;
                        side1_prefix += _sideChar;
                        side2_prefix += _sideChar;

                    }

                    hasStarted = true;

                    topRow_prefix += EmptySpaces(3 + 2 * _diagonalUpChar.Length + _pointChar.Length) + _pointChar + EmptySpaces(3 + 2 * _diagonalUpChar.Length);
                    diagonal1_prefix += EmptySpaces(2 + _diagonalUpChar.Length + _pointChar.Length) + _diagonalUpChar + EmptySpaces(2 + _pointChar.Length) + _diagonalDownChar + EmptySpaces(2 + _diagonalDownChar.Length);
                    diagonal2_prefix += EmptySpaces(1 + _pointChar.Length) + _diagonalUpChar + EmptySpaces(4 + _diagonalUpChar.Length + _pointChar.Length + _diagonalDownChar.Length) + _diagonalDownChar + EmptySpaces(1);
                    midRow_prefix += EmptySpaces(6 + 2 * _diagonalUpChar.Length + _pointChar.Length + 2 * _diagonalDownChar.Length) + _pointChar;
                    side1_prefix += EmptySpaces(3 + 2 * _diagonalUpChar.Length) + "[" + (tile.DiceNumber < 10 ? "0" + tile.DiceNumber : tile) + "]" + EmptySpaces(3 + 2 * _diagonalUpChar.Length) + _sideChar;
                    side2_prefix += EmptySpaces(3 + 2 * _diagonalUpChar.Length) + "[" + tile.ResourceType.ToString()[0] + tile.ResourceType.ToString()[1] + "]" + EmptySpaces(3 + 2 * _diagonalUpChar.Length) + _sideChar;

                }
            }

            Console.WriteLine(topRow_prefix);
            Console.WriteLine(diagonal1_prefix);
            Console.WriteLine(diagonal2_prefix);
            Console.WriteLine(midRow_prefix);
            Console.WriteLine(side1_prefix);
            Console.WriteLine(side2_prefix);
        }

        private static string EmptySpaces(int amount)
        {
            return new string(_emptySpace, amount);
        }
    }
}
