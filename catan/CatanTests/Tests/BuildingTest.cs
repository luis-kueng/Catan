using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanTests.Tests {
    [TestFixture]
    internal class BuildingTest {
        private readonly Player player = new("player", Colors.BLUE);

        [SetUp]
        public void SetUp() {
            player.AddResource(ResourceType.GRAIN, 999);
            player.AddResource(ResourceType.LUMBER, 999);
            player.AddResource(ResourceType.WOOL, 999);
            player.AddResource(ResourceType.BRICK, 999);
            player.AddResource(ResourceType.ORE, 999);
        }

        [Test]
        public void CreateSettlementTest() {
            Building? settlement = BuildingFactory.Building(BuildingType.SETTLEMENT, player);
            Assert.That(settlement, Is.Not.Null);
        }

        [Test]
        public void CreateCityTest() {
            Building? city = BuildingFactory.Building(BuildingType.CITY, player);
            Assert.That(city, Is.Not.Null);
        }

        [Test]
        public void CreateStreetTest() {
            Building? street = BuildingFactory.Building(BuildingType.STREET, player);
            Assert.That(street, Is.Not.Null);
        }
    }
}
