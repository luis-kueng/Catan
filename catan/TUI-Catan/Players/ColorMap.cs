﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Players {
    public static class ColorMap {
        public static ConsoleColor MapColorToConsoleColor(Colors color) {
            return color switch {
                Colors.BLUE => ConsoleColor.Blue,
                Colors.RED => ConsoleColor.Red,
                Colors.WHITE => ConsoleColor.White,
                Colors.YELLOW => ConsoleColor.Yellow,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
