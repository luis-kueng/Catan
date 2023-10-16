using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles.Neighbours
{
    public static class NeighbourVectorFactory
    {
        public static NeighbourVector NeighbourVectorByDirection(TilePoint direction, bool isEven)
        {
            int x = 0;
            int y = isEven ? 0 : 1;

            switch (direction)
            {
                case TilePoint.TOP_RIGHT_SIDE:
                    x -= 1;
                    y += 1;
                    break;

                case TilePoint.TOP_LEFT_SIDE:
                    x -= 1;
                    break;

                case TilePoint.MID_LEFT_SIDE:
                    y -= 1;
                    break;

                case TilePoint.MID_RIGHT_SIDE:
                    y += 1;
                    break;

                default:
                    x = 0;
                    y = 0;
                    break;
            }

            return new NeighbourVector(x, y);
        }
    }
}
