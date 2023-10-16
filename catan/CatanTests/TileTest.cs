using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CatanTests
{
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

            Player player = new("player1");
            player.AddResource(ResourceType.BRICK, 1);
            player.AddResource(ResourceType.LUMBER, 1);
            player.AddResource(ResourceType.WOOL, 1);
            player.AddResource(ResourceType.GRAIN, 1);

            Building? building = BuildingFactory.Building(BuildingType.SETTLEMENT, player);
            tile.AddBuilding(building, TilePoint.BOTTOM_POINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOM_POINT), Is.EqualTo(building));
        }

        [Test]
        public void AddInvalidBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player1 = new("player1");
            Player player2 = new("player2");

            Building? building1 = BuildingFactory.Building(BuildingType.SETTLEMENT, player1);
            Building? building2 = BuildingFactory.Building(BuildingType.SETTLEMENT, player2);

            tile.AddBuilding(building1, TilePoint.BOTTOM_LEFT_POINT);
            tile.AddBuilding(building2 , TilePoint.BOTTOM_POINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOM_POINT), Is.Not.EqualTo(building2));
        }

        [Test]
        public void AddNeighbouringTile() {
            int diceNumber = 5;
            Tile tile1 = new(ResourceType.BRICK, diceNumber);

            diceNumber = 3;
            Tile tile2 = new(ResourceType.WOOL, diceNumber);

            tile1.AddNeighbouringTile(tile2 , TileSide.BOTTOM_LEFT_SIDE);

            Assert.Multiple(() => {
                Assert.That(tile1.GetNeighbouringTileByPoint(TileSide.BOTTOM_LEFT_SIDE), Is.EqualTo(tile2));
                Assert.That(tile2.GetNeighbouringTileByPoint(TileSide.TOP_LEFT_SIDE), Is.EqualTo(tile1));
            });
        }
    }
}
