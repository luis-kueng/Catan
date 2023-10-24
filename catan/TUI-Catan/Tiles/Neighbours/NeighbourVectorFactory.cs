using Catan.Tiles.Directions;

namespace Catan.Tiles.Neighbours {
    public static class NeighbourVectorFactory {
        public static NeighbourVector NeighbourVectorByDirection(TileSide direction, bool isEven) {
            int x = 0;
            int y = isEven ? 1 : 0;

            switch (direction) {
                case TileSide.MIDLEFTSIDE:
                    y -= 1;
                    break;

                case TileSide.TOPLEFTSIDE:
                    x -= 1;
                    break;

                case TileSide.TOPRIGHTSIDE:
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
