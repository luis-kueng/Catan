using Catan.Games;
using Catan.Tiles;
using System.Data;
using Terminal.Gui;

namespace Catan.Utilities {
    public class PlayerWindow : Window {
        private Game Game;

        private Label profile;
        private TableView resourceTable;

        public PlayerWindow(Game game) {
            Game = game;

            Title = "Player";
            Width = Dim.Sized(30);
            Height = Dim.Fill();

            profile = new Label() {
                X = 0,
                Y = 0,
                Width = Dim.Fill(),
                Height = Dim.Sized(2)
            };

            setPlayerName();

            resourceTable = new TableView() {
                X = 0,
                Y = 2,
                Width = Dim.Fill(),
                Height = Dim.Fill(5)
            };

            setResources();

            var options = new View() {
                X = 0,
                Y = 15,
                Width = Dim.Fill(),
                Height = Dim.Sized(5)
            };

            var buildButton = new Button() {
                Text = "Build     ",
                X = 0,
                Y = 0
            };

            var tradeButton = new Button() {
                Text = "Trade     ",
                X = 0,
                Y = Pos.Bottom(buildButton)
            };

            var nextRoundButton = new Button() {
                Text = "Next Round",
                X = 0,
                Y = Pos.Bottom(tradeButton)
            };

            buildButton.Clicked += buildAction;
            tradeButton.Clicked += tradeAction;
            nextRoundButton.Clicked += nextRoundAction;

            options.Add(buildButton, tradeButton, nextRoundButton);

            Add(profile, resourceTable, options);
        }

        public void buildAction() {

        }

        public void tradeAction() {
            Application.MainLoop.Invoke(() => {
                Game.getCurrentPlayer().Resources[ResourceType.BRICK] = 5;

                setResources();

                profile.SetNeedsDisplay();
                resourceTable.SetNeedsDisplay();
            });
        }

        private void nextRoundAction() {
            Application.MainLoop.Invoke(() => {
                Game.EndRound();

                setPlayerName();
                setResources();

                profile.SetNeedsDisplay();
                resourceTable.SetNeedsDisplay();
            });
        }

        private void setResources() {
            var dt = new DataTable();
            dt.Columns.Add("Resource", typeof(string));
            dt.Columns.Add("Amount", typeof(int));

            Dictionary<ResourceType, int> resources = Game.getCurrentPlayer().Resources;

            dt.Rows.Add("Brick", resources[ResourceType.BRICK]);
            dt.Rows.Add("Grain", resources[ResourceType.GRAIN]);
            dt.Rows.Add("Lumber", resources[ResourceType.LUMBER]);
            dt.Rows.Add("Ore", resources[ResourceType.ORE]);
            dt.Rows.Add("Wool", resources[ResourceType.WOOL]);

            resourceTable.Table = dt;
        }

        private void setPlayerName() {
            profile.Text = Game.getCurrentPlayer().Name;
        }
    }
}
