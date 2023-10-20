using Catan.Buildings;
using Catan.GameFields;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;
using Catan.Utilities;

namespace Catan.Games {
    public class Game {
        public LinkedList<Player> Players {
            get; set;
        }

        public LinkedListNode<Player> CurrentPlayer {
            get; set;
        }

        public GameField Field {
            get; set;
        }

        public Game(int fieldSize, LinkedList<Player> players) {
            Players = players;
            Field = new(fieldSize);

            if (Players != null && Players.First != null)
                CurrentPlayer = Players.First;
            else
                throw new Exception();
        }

        public void PlayerFirstBuild(int x, int y, TilePoint point) {
            Console.WriteLine("Please choose your initial Settlement");
            Field.AddBuildingToField(BuildingType.SETTLEMENT, CurrentPlayer.Value, x, y, point);

            NextCurrentPlayer();
        }

        public void GiveOutResourcesForPlayer() {
            Field.GiveOutResources(CurrentPlayer.Value);
        }

        public void GiveOutResourcesForDice() {
            Field.GiveOutResources(Dice.RollTwoDice());
        }

        private void NextCurrentPlayer() {
            if (CurrentPlayer.Next != null)
                CurrentPlayer = CurrentPlayer.Next;
            else if (Players.First != null)
                CurrentPlayer = Players.First;
        }
    }
}
