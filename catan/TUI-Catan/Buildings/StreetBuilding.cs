using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings {
    public class StreetBuilding : Building {
        public StreetBuilding(Player player) : base(player) {
        }

        public override void GivePlayerResource(ResourceType type) {
        }
    }
}
