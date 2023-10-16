using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Tiles.Directions {
    public static class DirectionConverter {
        public static TileSide PointToLeftNeighbourSide(TilePoint point) {
            switch (point) {
                case TilePoint.TOP_POINT:
                    return TileSide.TOP_LEFT_SIDE;
                case TilePoint.BOTTOM_POINT:
                    return TileSide.BOTTOM_LEFT_SIDE;

                case TilePoint.TOP_RIGHT_POINT:
                case TilePoint.BOTTOM_RIGHT_POINT:
                case TilePoint.BOTTOM_LEFT_POINT:
                case TilePoint.TOP_LEFT_POINT:
                default:
                    throw new NotSupportedException();
            }
        }

        public static TileSide PointToRightNeighbourSide(TilePoint point) {
            switch (point) {
                case TilePoint.TOP_POINT:
                    return TileSide.TOP_RIGHT_SIDE;
                case TilePoint.BOTTOM_POINT:
                    return TileSide.BOTTOM_RIGHT_SIDE;

                case TilePoint.TOP_RIGHT_POINT:
                case TilePoint.BOTTOM_RIGHT_POINT:
                case TilePoint.BOTTOM_LEFT_POINT:
                case TilePoint.TOP_LEFT_POINT:
                default:
                    throw new NotSupportedException();
            }
        }

        public static TileSide GetMirroredSide(TileSide side) {
            return side switch {
                TileSide.TOP_RIGHT_SIDE => TileSide.BOTTOM_LEFT_SIDE,
                TileSide.TOP_LEFT_SIDE => TileSide.BOTTOM_RIGHT_SIDE,
                TileSide.MID_RIGHT_SIDE => TileSide.MID_LEFT_SIDE,
                TileSide.BOTTOM_RIGHT_SIDE => TileSide.TOP_LEFT_SIDE,
                TileSide.BOTTOM_LEFT_SIDE => TileSide.TOP_RIGHT_SIDE,
                TileSide.MID_LEFT_SIDE => TileSide.MID_RIGHT_SIDE,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
