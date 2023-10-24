using Catan.Buildings;
using Catan.Exceptions;
using Catan.GameFields;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;
using Catan.Utilities;

namespace Catan.Games {
    public class Game {
        public LinkedList<Player> Players {
            get;
        }

        public LinkedListNode<Player> CurrentPlayer {
            get; set;
        }

        public GameField Field {
            get;
        }

        public Game(int fieldSize, LinkedList<Player> players) {
            Players = players;
            Field = new(fieldSize);

            if (Players?.First != null)
                CurrentPlayer = Players.First;
            else
                throw new PLayersListEmptyException();
        }

        public void PlayerFirstBuild(int x, int y, TilePoint point) {
            BuildBuilding(x, y, point, BuildingType.SETTLEMENT);
        }

        public void BuildBuilding(int x, int y, TilePoint point, BuildingType type) {
            Field.AddBuildingToField(type, CurrentPlayer.Value, x, y, point);
            NextCurrentPlayer();
        }

        public void GiveOutResourcesForPlayer() {
            Field.GiveOutResources(CurrentPlayer.Value);
        }

        public int RollDiceAndGiveOutResources() {
            var diceNumber = Dice.RollTwoDice();
            Field.GiveOutResources(diceNumber);

            return diceNumber;
        }

        public void EndRound() {
            NextCurrentPlayer();
        }

        private void NextCurrentPlayer() {
            if (CurrentPlayer.Next != null)
                CurrentPlayer = CurrentPlayer.Next;
            else if (Players.First != null)
                CurrentPlayer = Players.First;
        }

        internal void TradePlayer() {
            throw new NotImplementedException();
        }

        internal void TradeBank() {
            throw new NotImplementedException();
        }
    }
}
