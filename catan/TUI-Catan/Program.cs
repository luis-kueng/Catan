using Catan.GameFields;

namespace Catan
{
    public class Program {
        public static void Main() {
            GameField gameField = new(3);
            GameFieldUtilities fieldUtilities = new(gameField);
            fieldUtilities.PrintField();
        }
    }
}