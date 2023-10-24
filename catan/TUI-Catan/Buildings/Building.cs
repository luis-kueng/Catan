using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings {
    public abstract class Building {
        public Player Player {
            get; set;
        }

        protected Building(Player player) {
            Player = player;
        }

        public abstract void GivePlayerResource(ResourceType type);
    }
}
