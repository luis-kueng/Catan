using Catan.Players;
using Catan.Tiles.Directions;
using Catan.Utilities;

namespace Catan.Games {
    public class GameModelView {
        private readonly Game game;
        private readonly GameFieldUtility fieldUtility;

        private int amountOfPlayers;

        public GameModelView() {
            SetAmountOfPlayers();
            int fieldSize = SetFieldSize();
            LinkedList<Player> players = SetPlayers();

            game = new(fieldSize, players);
            fieldUtility = new(game.Field);
        }

        private void SetAmountOfPlayers() {
            amountOfPlayers = TUI.AmountOfPlayers();
        }

        private int SetFieldSize() {
            return TUI.FieldSize(amountOfPlayers);
        }

        private LinkedList<Player> SetPlayers() {
            return TUI.CreatePlayers(amountOfPlayers);
        }

        public void StartGame() {
            InitialBuildingRound();
        }

        public void InitialBuildingRound() {
            for (int i = 0; i < amountOfPlayers; i++) {
                PlayerFirstBuild();
            }

            game.GiveOutResourcesForPlayer();
        }

        private void PlayerFirstBuild() {
            fieldUtility.PrintField();

            (int x, int y) = TUI.ChooseTileCoordinatesForBuilding();
            TilePoint point = TUI.GetPointForBuilding();
            game.PlayerFirstBuild(x, y, point);
        }
    }
}
