using Catan.Buildings;
using Catan.Exceptions;
using Catan.GameFields;
using Catan.Players;
using Catan.Tiles.Directions;
using System.Collections.ObjectModel;

namespace Catan.Games {
    public class Game {
        public Collection<Player> Players {
            get;
        }

        private int CurrentPlayer;

        public GameField Field {
            get;
        }

        public Game(int fieldSize, Collection<Player> players) {
            Players = players ?? throw new PLayersListEmptyException();
            Field = new(fieldSize);
            CurrentPlayer = 0;
        }

        public void PlayerFirstBuild(int x, int y, TilePoint point) {
            BuildBuilding(x, y, point, BuildingType.SETTLEMENT);
        }

        public void BuildBuilding(int x, int y, TilePoint point, BuildingType type) {
            Console.WriteLine("Trying to build");
            Field.AddBuildingToField(type, GetCurrentPlayer(), x, y, point);
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

        public Player GetCurrentPlayer() {
            return Players[CurrentPlayer];
        }
    }
}
