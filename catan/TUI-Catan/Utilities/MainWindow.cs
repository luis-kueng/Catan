using Catan.Buildings;
using Catan.Exceptions;
using Catan.Games;
using Catan.Tiles.Directions;
using NStack;
using Terminal.Gui;

namespace Catan.Utilities {
    public class MainWindow : Window {
        private readonly Game Game;

        private ustring coordinates = "";
        private int buildingType;
        private int point;

        private readonly FieldWindow fieldWindow;
        private readonly PlayerWindow playerWindow;
        private readonly Dialog buildOptions;

        private readonly ustring[] tileDirection = {
                "Top Point",
                "Top Right Point",
                "Top Left Point",
                "Bottom Point",
                "Bottom Right Point",
                "Bottom Left Point"
            };

        private readonly ustring[] tileSides = {
                "Top Right Side",
                "Top Left Side",
                "Mid Right Side",
                "Bottom Right Side",
                "Bottom Left Side",
                "Mid Left Side"
            };

        private readonly RadioGroup points;

        private readonly Button cancelButton = new() {
            Text = "Cancel"
        };

        private readonly Button buildButton = new() {
            Text = "Build"
        };

        private readonly Dialog tradeOptions = new() {
            Title = "Trade Options",
            Width = Dim.Sized(30),
            Height = Dim.Sized(30)
        };

        public MainWindow(Game game) {
            Game = game;

            Title = "CaTUIan (Ctrl+Q to quit)";

            playerWindow = new PlayerWindow(Game, BuildAction, TradeOptionDialog);
            fieldWindow = new FieldWindow();
            fieldWindow.ReloadField(Game.Field);

            buildOptions = new() {
                Title = "Build Options",
                Width = Dim.Sized(40),
                Height = Dim.Sized(18)
            };

            points = new() {
                X = 0,
                Y = 4,
                RadioLabels = tileSides,
                SelectedItem = 0
            };

            Add(fieldWindow, playerWindow);
        }

        public void BuildAction() {
            ustring[] buildingTypes = {
                "Street",
                "Settlement",
                "City"
            };

            RadioGroup buildings = new() {
                X = 0,
                Y = 0,
                RadioLabels = buildingTypes,
                SelectedItem = 0
            };

            buildings.SelectedItemChanged += Buildings_SelectedItemChanged;

            if (buildingType != 0) {
                points.RadioLabels = tileDirection;
            }

            points.SelectedItemChanged += Points_SelectedItemChanged;

            TextField coordinateField = new() {
                X = 0,
                Y = 12,
                Width = 30,
            };

            coordinateField.TextChanging += CoordinateField_TextChanged;

            Label label = new(0, 11, "Please enter the Field to build on");

            buildOptions.Add(buildings, points, label, coordinateField);

            buildButton.Clicked += (() => {
                int x;
                int y;
                bool isCastSuccessful;

                ustring[] input = coordinates.Split(" ");

                try {
                    try {
                        var cast = Int32.TryParse((string)input[0], out x);
                        var cast2 = Int32.TryParse((string)input[1], out y);

                        isCastSuccessful = cast && cast2;
                    } catch (IndexOutOfRangeException e) {
                        throw new InvalidCoordinatesException("invalid input", e);
                    }

                    if (isCastSuccessful) {
                        var pointCasted = (TilePoint)point;
                        var type = (BuildingType)buildingType;

                        Game.BuildBuilding(x, y, pointCasted, type);
                        Console.WriteLine("Building " + type + " at " + x + " - " + y + ", " + point);

                        fieldWindow.ReloadField(Game.Field);
                        playerWindow.ReloadResources();
                    } else {
                        throw new InvalidCoordinatesException("invalid input");
                    }
                } catch (InvalidCoordinatesException e) {
                    Console.WriteLine(e.Message);
                }

                Remove(buildOptions);
            });

            buildOptions.AddButton(cancelButton);
            buildOptions.AddButton(buildButton);

            this.Add(buildOptions);
        }

        private void Points_SelectedItemChanged(SelectedItemChangedArgs args) {
            point = args.SelectedItem;
        }

        private void Buildings_SelectedItemChanged(SelectedItemChangedArgs args) {
            buildingType = args.SelectedItem;

            if (buildingType == 0)
                points.RadioLabels = tileSides;
            else
                points.RadioLabels = tileDirection;

            points.SetNeedsDisplay();
        }

        private void CoordinateField_TextChanged(TextChangingEventArgs args) {
            coordinates = args.NewText;
        }

        public void TradeOptionDialog() {
            Application.Run(tradeOptions);
        }

        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            fieldWindow.Dispose();
            playerWindow.Dispose();
            points?.Dispose();
            buildOptions.Dispose();
            buildButton.Dispose();
            cancelButton.Dispose();
            tradeOptions.Dispose();
        }
    }
}