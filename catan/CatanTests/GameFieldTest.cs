using Catan.GameFields;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatanTests
{
    internal class GameFieldTest {
        [Test]
        public void CreateFieldTest() {
            var fieldSize = 3;
            GameField gameField = new(fieldSize);

            Assert.That(gameField, Is.Not.Null);
        }
    }
}
