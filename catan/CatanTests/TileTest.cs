﻿using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;

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

            Player player = new("player1", Colors.WHITE);
            player.AddResource(ResourceType.BRICK, 1);
            player.AddResource(ResourceType.LUMBER, 1);
            player.AddResource(ResourceType.WOOL, 1);
            player.AddResource(ResourceType.GRAIN, 1);

            Building? building = BuildingFactory.Building(BuildingType.SETTLEMENT, player);
            tile.BuildOnTile(building, TilePoint.BOTTOMPOINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOMPOINT), Is.EqualTo(building));
        }

        [Test]
        public void AddInvalidBuildingTest() {
            int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player1 = new("player1", Colors.WHITE);
            Player player2 = new("player2", Colors.WHITE);

            Building? building1 = BuildingFactory.Building(BuildingType.SETTLEMENT, player1);
            Building? building2 = BuildingFactory.Building(BuildingType.SETTLEMENT, player2);

            tile.BuildOnTile(building1, TilePoint.BOTTOMLEFTPOINT);
            tile.BuildOnTile(building2, TilePoint.BOTTOMPOINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOMPOINT), Is.Not.EqualTo(building2));
        }

        [Test]
        public void AddNeighbouringTile() {
            int diceNumber = 5;
            Tile tile1 = new(ResourceType.BRICK, diceNumber);

            diceNumber = 3;
            Tile tile2 = new(ResourceType.WOOL, diceNumber);

            tile1.AddNeighbouringTile(tile2, TileSide.BOTTOMLEFTSIDE);

            Assert.Multiple(() => {
                Assert.That(tile1.GetNeighbouringTileByPoint(TileSide.BOTTOMLEFTSIDE), Is.EqualTo(tile2));
                Assert.That(tile2.GetNeighbouringTileByPoint(TileSide.TOPLEFTSIDE), Is.EqualTo(tile1));
            });
        }
    }
}
