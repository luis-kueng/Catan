using Catan.Buildings;
using Catan.Players;
using Catan.Tiles;
using Catan.Tiles.Directions;

namespace Catan.Utilities {
    public class TileUtility {
        public static void PrintTileTop(Tile tile) {
            Console.Write("       ");

            Building? building = tile.GetBuildingByPoint(TilePoint.TOPPOINT);
            if (building != null) {
                Console.Write("(");
                Console.ForegroundColor = ColorMap.MapColorToConsoleColor(building.Player.Color);
                Console.Write("XX");
                Console.ResetColor();
                Console.Write(")");

            } else {
                Console.Write(" () ");
            }

            Console.Write("       ");
        }
    }
}
