using Catan.Tiles.Directions;

namespace Catan.Tiles.Neighbours {
    public static class NeighbourVectorFactory {
        public static NeighbourVector NeighbourVectorByDirection(TileSide direction, bool isEven) {
            int x = 0;
            int y = isEven ? 1 : 0;

            switch (direction) {
                case TileSide.MID_LEFT_SIDE:
                    y -= 1;
                    break;

                case TileSide.TOP_LEFT_SIDE:
                    x -= 1;
                    break;

                case TileSide.TOP_RIGHT_SIDE:
                    x -= 1;
                    y += 1;
                    break;

                default:
                    throw new NotSupportedException();
            }

            return new NeighbourVector(x, y);
        }
    }
}
