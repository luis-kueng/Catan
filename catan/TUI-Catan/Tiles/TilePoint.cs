using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles
{
    public enum TilePoint
    {
        TOP_POINT = 0,
        TOP_RIGHT_POINT = 1,
        BOTTOM_RIGHT_POINT = 2,
        BOTTOM_POINT = 3,
        BOTTOM_LEFT_POINT = 4,
        TOP_LEFT_POINT = 5,

        TOP_LEFT_SIDE = 10,
        TOP_RIGHT_SIDE = 11,
        MID_RIGHT_SIDE = 12,
        BOTTOM_RIGHT_SIDE = 13,
        BOTTOM_LEFT_SIDE = 14,
        MID_LEFT_SIDE = 15,
    }
}
