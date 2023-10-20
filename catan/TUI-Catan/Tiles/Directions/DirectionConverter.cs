namespace Catan.Tiles.Directions {
    public static class DirectionConverter {
        public static TileSide PointToLeftNeighbourSide(TilePoint point) {
            return point switch {
                TilePoint.TOP_POINT => TileSide.TOP_LEFT_SIDE,
                TilePoint.TOP_LEFT_POINT => TileSide.MID_LEFT_SIDE,
                TilePoint.BOTTOM_LEFT_POINT => TileSide.BOTTOM_LEFT_SIDE,
                TilePoint.BOTTOM_POINT => TileSide.BOTTOM_RIGHT_SIDE,
                TilePoint.BOTTOM_RIGHT_POINT => TileSide.MID_RIGHT_SIDE,
                TilePoint.TOP_RIGHT_POINT => TileSide.TOP_RIGHT_SIDE,
                _ => throw new NotSupportedException(),
            };
        }

        public static TileSide PointToRightNeighbourSide(TilePoint point) {
            return point switch {
                TilePoint.TOP_POINT => TileSide.TOP_RIGHT_SIDE,
                TilePoint.TOP_RIGHT_POINT => TileSide.MID_RIGHT_SIDE,
                TilePoint.BOTTOM_RIGHT_POINT => TileSide.BOTTOM_RIGHT_SIDE,
                TilePoint.BOTTOM_POINT => TileSide.BOTTOM_LEFT_SIDE,
                TilePoint.BOTTOM_LEFT_POINT => TileSide.MID_LEFT_SIDE,
                TilePoint.TOP_LEFT_POINT => TileSide.TOP_LEFT_SIDE,
                _ => throw new NotSupportedException(),
            };
        }

        public static TileSide MirroredSide(TileSide side) {
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

        public static TilePoint MirroredPointLeft(TilePoint point) {
            return point switch {
                TilePoint.TOP_POINT => TilePoint.BOTTOM_RIGHT_POINT,
                TilePoint.TOP_LEFT_POINT => TilePoint.TOP_RIGHT_POINT,
                TilePoint.BOTTOM_LEFT_POINT => TilePoint.TOP_POINT,
                TilePoint.BOTTOM_POINT => TilePoint.TOP_LEFT_POINT,
                TilePoint.BOTTOM_RIGHT_POINT => TilePoint.BOTTOM_LEFT_POINT,
                TilePoint.TOP_RIGHT_POINT => TilePoint.BOTTOM_POINT,
                _ => throw new NotSupportedException(),
            };
        }

        public static TilePoint MirroredPointRight(TilePoint point) {
            return point switch {
                TilePoint.TOP_POINT => TilePoint.BOTTOM_LEFT_POINT,
                TilePoint.TOP_RIGHT_POINT => TilePoint.TOP_LEFT_POINT,
                TilePoint.BOTTOM_RIGHT_POINT => TilePoint.TOP_POINT,
                TilePoint.BOTTOM_POINT => TilePoint.TOP_RIGHT_POINT,
                TilePoint.BOTTOM_LEFT_POINT => TilePoint.BOTTOM_RIGHT_POINT,
                TilePoint.TOP_LEFT_POINT => TilePoint.BOTTOM_POINT,
                _ => throw new NotSupportedException(),
            };
        }
    }
}
