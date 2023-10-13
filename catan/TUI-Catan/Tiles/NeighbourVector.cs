using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles {
    public class NeighbourVector {
        public int X {  get; set; }
        public int Y { get; set; }

        public NeighbourVector(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
