namespace Catan.Tiles.Directions {
    public static class DirectionConverter {
        public static TileSide PointToLeftNeighbourSide(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TileSide.TOPLEFTSIDE,
                TilePoint.TOPLEFTPOINT => TileSide.MIDLEFTSIDE,
                TilePoint.BOTTOMLEFTPOINT => TileSide.BOTTOMLEFTSIDE,
                TilePoint.BOTTOMPOINT => TileSide.BOTTOMRIGHTSIDE,
                TilePoint.BOTTOMRIGHTPOINT => TileSide.MIDRIGHTSIDE,
                TilePoint.TOPRIGHTPOINT => TileSide.TOPRIGHTSIDE,
                _ => throw new NotSupportedException(),
            };
        }

        public static TileSide PointToRightNeighbourSide(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TileSide.TOPRIGHTSIDE,
                TilePoint.TOPRIGHTPOINT => TileSide.MIDRIGHTSIDE,
                TilePoint.BOTTOMRIGHTPOINT => TileSide.BOTTOMRIGHTSIDE,
                TilePoint.BOTTOMPOINT => TileSide.BOTTOMLEFTSIDE,
                TilePoint.BOTTOMLEFTPOINT => TileSide.MIDLEFTSIDE,
                TilePoint.TOPLEFTPOINT => TileSide.TOPLEFTSIDE,
                _ => throw new NotSupportedException(),
            };
        }

        public static TileSide MirroredSide(TileSide side) {
            return side switch {
                TileSide.TOPRIGHTSIDE => TileSide.BOTTOMLEFTSIDE,
                TileSide.TOPLEFTSIDE => TileSide.BOTTOMRIGHTSIDE,
                TileSide.MIDRIGHTSIDE => TileSide.MIDLEFTSIDE,
                TileSide.BOTTOMRIGHTSIDE => TileSide.TOPLEFTSIDE,
                TileSide.BOTTOMLEFTSIDE => TileSide.TOPRIGHTSIDE,
                TileSide.MIDLEFTSIDE => TileSide.MIDRIGHTSIDE,
                _ => throw new NotSupportedException(),
            };
        }

        public static TilePoint MirroredPointLeft(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TilePoint.BOTTOMRIGHTPOINT,
                TilePoint.TOPLEFTPOINT => TilePoint.TOPRIGHTPOINT,
                TilePoint.BOTTOMLEFTPOINT => TilePoint.TOPPOINT,
                TilePoint.BOTTOMPOINT => TilePoint.TOPLEFTPOINT,
                TilePoint.BOTTOMRIGHTPOINT => TilePoint.BOTTOMLEFTPOINT,
                TilePoint.TOPRIGHTPOINT => TilePoint.BOTTOMPOINT,
                _ => throw new NotSupportedException(),
            };
        }

        public static TilePoint MirroredPointRight(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TilePoint.BOTTOMLEFTPOINT,
                TilePoint.TOPRIGHTPOINT => TilePoint.TOPLEFTPOINT,
                TilePoint.BOTTOMRIGHTPOINT => TilePoint.TOPPOINT,
                TilePoint.BOTTOMPOINT => TilePoint.TOPRIGHTPOINT,
                TilePoint.BOTTOMLEFTPOINT => TilePoint.BOTTOMRIGHTPOINT,
                TilePoint.TOPLEFTPOINT => TilePoint.BOTTOMPOINT,
                _ => throw new NotSupportedException(),
            };
        }

        public static TilePoint PointToLeft(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TilePoint.TOPLEFTPOINT,
                TilePoint.TOPLEFTPOINT => TilePoint.BOTTOMLEFTPOINT,
                TilePoint.BOTTOMLEFTPOINT => TilePoint.BOTTOMPOINT,
                TilePoint.BOTTOMPOINT => TilePoint.BOTTOMRIGHTPOINT,
                TilePoint.BOTTOMRIGHTPOINT => TilePoint.TOPRIGHTPOINT,
                TilePoint.TOPRIGHTPOINT => TilePoint.TOPPOINT,
                _ => throw new NotSupportedException()
            };
        }

        public static TilePoint PointToRight(TilePoint point) {
            return point switch {
                TilePoint.TOPPOINT => TilePoint.TOPRIGHTPOINT,
                TilePoint.TOPRIGHTPOINT => TilePoint.BOTTOMRIGHTPOINT,
                TilePoint.BOTTOMRIGHTPOINT => TilePoint.BOTTOMPOINT,
                TilePoint.BOTTOMPOINT => TilePoint.BOTTOMLEFTPOINT,
                TilePoint.BOTTOMLEFTPOINT => TilePoint.TOPLEFTPOINT,
                TilePoint.TOPLEFTPOINT => TilePoint.TOPPOINT,
                _ => throw new NotSupportedException()
            };
        }
    }
}
