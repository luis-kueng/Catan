using Catan.Buildings;
using Catan.Exceptions;
using Catan.GameFields;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;
using Catan.Utilities;

namespace Catan.Games {
    public class Game {
        public List<Player> Players {
            get;
        }

        public int CurrentPlayer {
            get; set;
        }

        public GameField Field {
            get;
        }

        public Game(int fieldSize, List<Player> players) {
            if (players == null)
                throw new PLayersListEmptyException();

            Players = players;
            Field = new(fieldSize);
            CurrentPlayer = 0;
        }

        public void PlayerFirstBuild(int x, int y, TilePoint point) {
            BuildBuilding(x, y, point, BuildingType.SETTLEMENT);
        }

        public void BuildBuilding(int x, int y, TilePoint point, BuildingType type) {
            Field.AddBuildingToField(type, getCurrentPlayer(), x, y, point);
            NextCurrentPlayer();
        }

        public void GiveOutResourcesForPlayer() {
            Field.GiveOutResources(CurrentPlayer);
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
            if (CurrentPlayer == Players.Count - 1)
                CurrentPlayer = 0;
            else
                CurrentPlayer++;
        }

        internal void TradePlayer() {
            throw new NotImplementedException();
        }

        internal void TradeBank() {
            throw new NotImplementedException();
        }

        public Player getCurrentPlayer() {
            return Players[CurrentPlayer];
        }
    }
}
