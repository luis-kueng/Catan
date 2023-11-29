using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;

namespace CatanTests.Tests {
    public class TileTest {
        [Test]
        public void CreateTileTest() {
            const int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);
            Assert.That(tile, Is.Not.Null);
            Assert.Multiple(() => {
                Assert.That(tile.ResourceType, Is.EqualTo(ResourceType.BRICK));
                Assert.That(tile.DiceNumber, Is.EqualTo(diceNumber));
            });
        }

        [Test]
        public void AddBuildingTest() {
            const int diceNumber = 5;
            Tile tile = new(ResourceType.BRICK, diceNumber);

            Player player = new("player1", Colors.WHITE);
            player.AddResource(ResourceType.BRICK, 1);
            player.AddResource(ResourceType.LUMBER, 1);
            player.AddResource(ResourceType.WOOL, 1);
            player.AddResource(ResourceType.GRAIN, 1);

            Building building = BuildingFactory.Building(BuildingType.SETTLEMENT, player) ?? throw new Exception();
            tile.BuildOnTile(building, TilePoint.TOPPOINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.TOPPOINT), Is.EqualTo(building));
        }

        [Test]
        public void AddInvalidBuildingTest() {
            Tile tile = Tile.CreateRandomTile();

            Player player1 = new("player1", Colors.WHITE);
            Player player2 = new("player2", Colors.WHITE);

            Building? building1 = BuildingFactory.Building(BuildingType.SETTLEMENT, player1);
            Building? building2 = BuildingFactory.Building(BuildingType.SETTLEMENT, player2);

            tile.BuildOnTile(building1, TilePoint.BOTTOMLEFTPOINT);
            tile.BuildOnTile(building2, TilePoint.BOTTOMPOINT);

            Assert.That(tile.GetBuildingByPoint(TilePoint.BOTTOMPOINT), Is.Null);
        }

        [Test]
        public void AddNeighbouringTile() {
            Tile tile1 = Tile.CreateRandomTile();
            Tile tile2 = Tile.CreateRandomTile();

            tile1.AddNeighbouringTile(tile2, TileSide.BOTTOMLEFTSIDE);

            Assert.Multiple(() => {
                Assert.That(tile1.GetNeighbouringTileByPoint(TileSide.BOTTOMLEFTSIDE), Is.EqualTo(tile2));
                Assert.That(tile2.GetNeighbouringTileByPoint(TileSide.TOPRIGHTSIDE), Is.EqualTo(tile1));
            });
        }
    }
}
