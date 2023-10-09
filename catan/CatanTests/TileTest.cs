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
            Assert.That(tile, Is.Not.Null);
            Assert.Multiple(() => {
                Assert.That(tile.ResourceType, Is.EqualTo(ResourceType.BRICK));
                Assert.That(tile.DiceNumber, Is.EqualTo(diceNumber));
            });
        }

        [Test]
        public void AddBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player = new();
            Building building = new(player, BuildingType.SETTLEMENT);
            tile.AddBuilding(building, TilePoint.BOTTOM_POINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOM_POINT), Is.EqualTo(building));
        }

        [Test]
        public void AddInvalidBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player1 = new();
            Player player2 = new();

            Building building1 = new(player1, BuildingType.SETTLEMENT);
            Building building2 = new(player2, BuildingType.SETTLEMENT);

            tile.AddBuilding(building1, TilePoint.BOTTOM_LEFT_POINT);
            tile.AddBuilding(building2 , TilePoint.BOTTOM_POINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOM_POINT), Is.Not.EqualTo(building2));
        }

        [Test]
        public void AddStreetTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player = new();
            Building building = new(player, BuildingType.STREET);
            tile.AddBuilding(building, TilePoint.BOTTOM_LEFT_SIDE);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOM_LEFT_SIDE), Is.EqualTo(building));
        }

        [Test]
        public void AddNeighbouringTile() {
            int diceNumber = 5;
            Tile tile1 = new(ResourceType.BRICK, diceNumber);

            diceNumber = 3;
            Tile tile2 = new(ResourceType.WOOL, diceNumber);

            tile1.AddNeighbouringTile(tile2 , TilePoint.BOTTOM_LEFT_SIDE);

            Assert.Multiple(() => {
                Assert.That(tile1.GetNeighbouringTileByPoint(TilePoint.BOTTOM_LEFT_SIDE), Is.EqualTo(tile2));
                Assert.That(tile2.GetNeighbouringTileByPoint(TilePoint.TOP_LEFT_SIDE), Is.EqualTo(tile1));
            });
        }
    }
}
