using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Games {
    public static class Dice {
        private static readonly Random _ran = new();

        public static int RollTwoDice() {
            return RollDice(2);
        }

        private static int RollDice(int amt) {
            return _ran.Next(0, amt * 6 + 1);
        }
    }
}
