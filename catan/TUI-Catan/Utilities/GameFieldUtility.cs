using Catan.GameFields;
using Catan.Tiles;

namespace Catan.Utilities {
    public class GameFieldUtility {
        public Tile?[][] Field {
            get;
        }

        public GameFieldUtility(GameField gameField) {
            if (gameField == null)
                throw new ArgumentNullException(nameof(gameField));

            Field = gameField.Field;
        }

        public void PrintField() {
            foreach (var row in Field) {
                foreach (var tile in row) {
                    if (tile != null) {
                        TileUtility.PrintTileTop(tile);
                        Console.WriteLine();
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.Write("                  ");
                    } else {
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                        Console.SetCursorPosition(Console.CursorLeft - 18, Console.CursorTop);
                        Console.WriteLine("                  ");
                    }

                    Console.SetCursorPosition(Console.CursorLeft + 18, Console.CursorTop - 5);
                }

                Console.SetCursorPosition(Console.CursorLeft - (row.Length + 1) * 18, Console.CursorTop + 6);
            }
        }
    }
}
