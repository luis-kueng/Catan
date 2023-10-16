using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles.TilePoints {
    public static class TilePointConverter {
        public static TilePoint PointToLeftNeighbourSide(TilePoint point) {
            switch (point) {
                case TilePoint.TOP_POINT:
                    return TilePoint.TOP_LEFT_SIDE;
                case TilePoint.BOTTOM_POINT:
                    return TilePoint.BOTTOM_LEFT_SIDE;

                default:
                    throw new NotSupportedException();
            }
        }

        public static TilePoint PointToRightNeighbourSide(TilePoint point) {
            switch (point) {
                case TilePoint.TOP_POINT:
                    return TilePoint.TOP_RIGHT_SIDE;
                case TilePoint.BOTTOM_POINT:
                    return TilePoint.BOTTOM_RIGHT_SIDE;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
