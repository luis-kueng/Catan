using Catan.Games;
using System.Data;
using Terminal.Gui;

namespace Catan.Utilities {
    public class MainWindow : Window {
        public MainWindow(Game game) {
            Title = "CaTUIan (Ctrl+Q to quit)";

            var playerWindow = new PlayerWindow(game);
            var fieldWindow = new FieldWindow();
            fieldWindow.reloadField(game.Field);

            Add(fieldWindow, playerWindow);
        }
    }
}
