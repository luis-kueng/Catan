using Catan.Players;
using Catan.Tiles;

namespace Catan.Utilities {
    public class PlayerUtility {
        public Player Player {
            get; set;
        }

        public PlayerUtility(Player player) {
            Player = player;
        }

        public void PrintPlayer() {
            Console.ForegroundColor = ColorMap.MapColorToConsoleColor(Player.Color);
            Console.WriteLine(Player.Name);
            Console.WriteLine("  Bricks:\t{0}", Player.Resources[ResourceType.BRICK]);
            Console.WriteLine("  Lumber:\t{0}", Player.Resources[ResourceType.LUMBER]);
            Console.WriteLine("  Wool:  \t{0}", Player.Resources[ResourceType.WOOL]);
            Console.WriteLine("  Grain: \t{0}", Player.Resources[ResourceType.GRAIN]);
            Console.WriteLine("  Ore:   \t{0}", Player.Resources[ResourceType.ORE]);
            Console.ResetColor();
        }
    }
}
