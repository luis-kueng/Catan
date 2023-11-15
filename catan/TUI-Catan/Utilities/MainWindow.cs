using Catan.Buildings;
using Catan.Games;
using Catan.Tiles;
using System.Data;
using Terminal.Gui;

namespace Catan.Utilities {
    public class MainWindow : Window {
        private Game Game;

        public MainWindow(Game game) {
            Game = game;

            Title = "CaTUIan (Ctrl+Q to quit)";

            var playerWindow = new PlayerWindow(game, buildAction, tradeOptionDialog);
            var fieldWindow = new FieldWindow();
            fieldWindow.reloadField(game.Field);

            Add(fieldWindow, playerWindow);
        }
        public void buildAction() {
            List<string> buildingTypes = new() {
                "Street",
                "Settlement"
            };

            ListView buildings = new ListView(buildingTypes) {
            };

            Dialog buildOptions = new Dialog() {
                Title = "Build Options",
                Width = Dim.Sized(30),
                Height = Dim.Sized(30)
            };

            buildOptions.Add(buildings);

            Button cancelButton = new() {
                Text = "Cancel"
            };

            Button buildButton = new() {
                Text = "Build"
            };

            cancelButton.Clicked += (() => {
                this.Remove(buildOptions);
            });

            buildOptions.AddButton(cancelButton);
            buildOptions.AddButton(buildButton);

            this.Add(buildOptions);
        }

        public void tradeOptionDialog() {
            Dialog tradeOptions = new Dialog() {
                Title = "Trade Options",
                Width = Dim.Sized(30),
                Height = Dim.Sized(30)
            };

            this.Add(tradeOptions);
        }
    }
}