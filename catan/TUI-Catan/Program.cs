using Catan.GameFields;
using Catan.Games;

namespace Catan {
    public class Program {
        public static void Main() {
            GameModelView game = new();
            game.StartGame();
        }
    }
}