using Catan.Buildings;
using Catan.GameFields;
using Catan.Players;
using Catan.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Games
{
    public class Game
    {
        public Player[] Players { get; set; }
        public int CurrentPlayer { get; set; }
        public GameField Field { get; set; }
        public GameFieldUtility FieldUtility { get; set; }
        public PlayerUtility PlayerUtility { get; set; }

        public Game() 
        {
            Players = new Player[4];
            Players[0] = new Player("player 1");
            Players[1] = new Player("player 2");
            Players[2] = new Player("player 3"); 
            Players[3] = new Player("player 4");

            CurrentPlayer = 0;

            Field = new GameField(3);
            FieldUtility = new(Field);
            PlayerUtility = new(Players[CurrentPlayer]);
        }

        public void Start() {
            Player currPlayer = Players[CurrentPlayer];
            PrintGame();
            Console.WriteLine();
            PrintPlayerInformation();

            currPlayer.AddResource(ResourceType.BRICK, 1);
            currPlayer.AddResource(ResourceType.LUMBER, 1);
            currPlayer.AddResource(ResourceType.WOOL, 1);
            currPlayer.AddResource(ResourceType.GRAIN, 1);

            Console.WriteLine();
            PrintPlayerInformation();

            Field.AddBuildingToField(BuildingType.SETTLEMENT, currPlayer, 1, 1);
            Console.WriteLine();
            PrintPlayerInformation();

            Field.GiveOutResources();

            Console.WriteLine();
            PrintPlayerInformation();
        }

        public void PrintGame() {
            FieldUtility.PrintField();
        }

        public void PrintPlayerInformation() {
            PlayerUtility.PrintPlayer();
        }
    }
}
