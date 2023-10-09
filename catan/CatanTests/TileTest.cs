using Catan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CatanTests {
    public class TileTest {
        [Test] 
        public void CreateTileTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);
            Assert.IsNotNull(tile);
            Assert.Equals(ResourceType.BRICK, tile.GetResource());
            Assert.Equals(diceNumber, tile.GetDiceNumber());
        }

        [Test]
        public void AddBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player = new();
            Building building = new Building(player, BuildingType.SETTLEMENT);
            tile.AddBuilding(building, TilePoint.BOTTOM);

            Assert.Contains(building, tile.GetBuildings());
            Assert.Equals(building, tile.GetBuilding(TilePoint.BOTTOM));
        }

        [Test]
        public void AddInvalidBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player1 = new();
            Player player2 = new();

            Building building1 = new Building(player1, BuildingType.SETTLEMENT);
            Building building2 = new Building(player2, BuildingType.SETTLEMENT);

            tile.AddBuilding(building1, TilePoint.LEFT_DOWN);
            tile.AddBuilding(building2 , TilePoint.BOTTOM);

            Assert.That(tile.GetBuildings(), Does.Not.Contain(building2));
        }
    }
}
