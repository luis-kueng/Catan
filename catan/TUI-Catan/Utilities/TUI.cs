using Catan.Players;
using Catan.Tiles.Directions;
using System.Text.RegularExpressions;

namespace Catan.Utilities {
    public partial class TUI {
        public static int AmountOfPlayers() {
            String? input;
            int amount;

            Console.WriteLine("How many players are playing?");
            do {
                input = Console.ReadLine();
            } while (input == null || !Int32.TryParse(input, out amount));

            return amount;
        }

        public static int FieldSize(int amountOfPlayers) {
            int fieldSize = amountOfPlayers < 5 ? 3 : 4;

            String? input;

            EmptyLine();
            Console.WriteLine("What size chould the field be?");
            Console.WriteLine("Default: " + fieldSize);
            do {
                input = Console.ReadLine();
                if (input == null) {
                    break;
                }
            } while (!Int32.TryParse(input, out fieldSize));

            return fieldSize;
        }

        public static LinkedList<Player> CreatePlayers(int amountOfPlayers) {
            LinkedList<Player> players = new();

            for (int i = 0; i < amountOfPlayers; i++) {
                EmptyLine();
                Console.WriteLine("What is the name of Player " + (i + 1) + "?");
                string? name = Console.ReadLine();

                players.AddLast(new Player(name ?? "Player " + (i + 1)));
            }

            return players;
        }

        public static GameOptions ChooseBasicOption() {
            return ChooseOption(GameOptionDictionaries.BasicGameOptions);
        }

        public static GameOptions ChooseBuildOption() {
            return ChooseOption(GameOptionDictionaries.BuildGameOptions);
        }

        public static GameOptions ChooseTradeOption() {
            return ChooseOption(GameOptionDictionaries.TradeGameOptions);
        }

        private static GameOptions ChooseOption(Dictionary<string, GameOptions> options) {
            String regexOptions = "^[";
            EmptyLine();
            Console.WriteLine("Options: ");
            EmptyLine();
            foreach (var i in options) {
                Console.WriteLine(
                    "  [" + i.Key + "]  " +
                    i.Value.ToString().Replace('_', ' ').ToUpperInvariant()
                    );

                regexOptions += i.Key;
            }

            string choice = GetInput(
                new Regex(regexOptions + "]$"),
                "Please enter vaild option!"
                );

            return options.GetValueOrDefault(choice);
        }

        public static TilePoint GetPointForBuilding() {
            var tilePoints = Enum.GetValues(typeof(TilePoint)).OfType<TilePoint>().ToList();
            var regexOptions = "";

            int i = 1;
            foreach (var point in tilePoints) {
                Console.WriteLine("[" + i + "]   " + point.ToString());
                regexOptions += i++;
            }

            string input = GetInput(
                new Regex("^[" + regexOptions + "]$"),
                "Please enter valid Option!"
                );

            return tilePoints[int.Parse(input) - 1];
        }

        public static (int, int) ChooseTileCoordinatesForBuilding() {
            string[] cords = GetInput(
                "Which field do you wanna build on?",
                new Regex("^[0-9]+\\s[0-9]+$"),
                "Please insert valid value!"
                ).Split();

            return (int.Parse(cords[0]), int.Parse(cords[1]));
        }

        private static string GetInput(string initialText, Regex regex, string textWhenWrong) {
            EmptyLine();
            Console.WriteLine(initialText);
            EmptyLine();

            string? input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || !regex.IsMatch(input)) {
                Console.WriteLine(textWhenWrong);
                EmptyLine();
                input = Console.ReadLine();
            }

            return input;
        }

        private static string GetInput(Regex regex, string textWhenWrong) {
            return GetInput("", regex, textWhenWrong);
        }

        public static void PrintDiceNumber(int diceNumber) {
            EmptyLine();
            Console.WriteLine("Es wurde " + diceNumber + " gewürfelt!");
            EmptyLine();
        }

        public static void EmptyLine() {
            Console.WriteLine();
        }

        public static void PrintInitialSettlementScreen() {
            EmptyLine();
            Console.WriteLine("Please choose your initial Settlement");
            EmptyLine();
        }

        public static void ResetScreen() {
            Console.Clear();
        }
    }
}
