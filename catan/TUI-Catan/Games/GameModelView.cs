using Catan.Players;
using Catan.Utilities;
using System.Collections.ObjectModel;
using Terminal.Gui;

namespace Catan.Games {
    public class GameModelView {
        private readonly Game game;
        private readonly Collection<Player> players;

        public GameModelView() {
            players = new() {
                new Player("p1", Players.Colors.WHITE),
                new Player("p2", Players.Colors.RED),
                new Player("p3", Players.Colors.YELLOW),
                new Player("p4", Players.Colors.BLUE)
            };

            game = new Game(4, players);
        }

        public void StartGame() {
            Application.Init();

            MainWindow window = new(game);
            Application.Top.Add(window);

            Application.Run();
            Application.Shutdown();

            window.Dispose();
        }
    }
}
