using Catan.GameFields;

namespace CatanTests.Tests
{
    internal class GameFieldTest
    {
        [Test]
        public void CreateFieldTest()
        {
            const int fieldSize = 3;
            GameField gameField = new(fieldSize);

            Assert.That(gameField, Is.Not.Null);
        }
    }
}
