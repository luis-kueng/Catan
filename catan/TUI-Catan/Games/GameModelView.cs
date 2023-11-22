using Catan.Buildings;
using Catan.Players;
using Catan.Tiles.Directions;
using Catan.Utilities;
using Terminal.Gui;

namespace Catan.Games {
    public class GameModelView {
        private readonly Game game;

        private int amountOfPlayers;

        public GameModelView() {
            /**
            SetAmountOfPlayers();
            int fieldSize = SetFieldSize();
            LinkedList<Player> players = SetPlayers();
           
            game = new(fieldSize, players);
            
            fieldUtility = new(game.Field);
            playerUtility = new(game.CurrentPlayer.Value);
            **/
        }

        public void StartGame() {
            Application.Init();
            List<Player> players = new() {
                new Player("p1", Players.Colors.WHITE),
                new Player("p2", Players.Colors.RED),
                new Player("p3", Players.Colors.YELLOW),
                new Player("p4", Players.Colors.BLUE)
            };

            MainWindow window = new(new Game(2, players));
            Application.Top.Add(window);

            Application.Run();
            Application.Shutdown();

            window.Dispose();
        }

        /**

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

            while (true) {
                ResetScreen();
                NormalPlayerRound();
            }
        }

        private void ResetScreen() {
            TUI.ResetScreen();

            fieldUtility.PrintField();

            TUI.EmptyLine();
            TUI.EmptyLine();

            playerUtility.Player = game.CurrentPlayer.Value;
            playerUtility.PrintPlayer();
        }

        public void InitialBuildingRound() {
            for (int i = 0; i < amountOfPlayers; i++) {
                ResetScreen();
                PlayerFirstBuild();
            }

            game.GiveOutResourcesForPlayer();
        }

        public void NormalPlayerRound() {
            var diceNumber = game.RollDiceAndGiveOutResources();
            TUI.PrintDiceNumber(diceNumber);

            int action;
            do {
                action = BasicAction();
            } while (action >= 0);

            game.EndRound();
        }

        public int BasicAction() {
            GameOptions basicOption = TUI.ChooseBasicOption();

            switch (basicOption) {
                case GameOptions.BUILD:
                    BuildAction();
                    return 1;

                case GameOptions.TRADE:
                    TradeAction();
                    return 2;

                case GameOptions.BUY_CARD:
                case GameOptions.USE_CARD:
                case GameOptions.END_ROUND:
                    return -1;

                default:
                    return 0;
            }
        }

        public void BuildAction() {
            ResetScreen();
            GameOptions buildOption = TUI.ChooseBuildOption();

            switch (buildOption) {
                case GameOptions.BUILD_SETTLEMEN:
                    BuildSettlement();
                    break;
                case GameOptions.BUILD_CITY:
                    BuildCity();
                    break;
                case GameOptions.BUILD_STREET:
                    BuildStreet();
                    break;
            }
        }

        private void BuildSettlement() {
            BuildBuilding(BuildingType.SETTLEMENT);
        }
        private void BuildCity() {
            BuildBuilding(BuildingType.CITY);
        }

        private void BuildStreet() {
            BuildBuilding(BuildingType.STREET);
        }



        public void TradeAction() {
            ResetScreen();
            GameOptions tradeOption = TUI.ChooseTradeOption();

            switch (tradeOption) {
                case GameOptions.TRADE_PLAYER:
                    TradePlayer();
                    break;
                case GameOptions.TRADE_BANK:
                    TradeBank();
                    break;
            }
        }

        private void TradePlayer() {
            game.TradePlayer();
        }

        private void TradeBank() {
            game.TradeBank();
        }

        private void PlayerFirstBuild() {
            BuildBuilding(BuildingType.SETTLEMENT);
        }

        private void BuildBuilding(BuildingType type) {
            ResetScreen();
            TUI.PrintInitialSettlementScreen();
            (int x, int y) = TUI.ChooseTileCoordinatesForBuilding();

            ResetScreen();
            TUI.PrintInitialSettlementScreen();
            TilePoint point = TUI.GetPointForBuilding();

            game.BuildBuilding(x, y, point, type);
        }
        **/
    }
}
