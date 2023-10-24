using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings {
    public class SettlementBuilding : Building {
        public SettlementBuilding(Player player) : base(player) {
        }

        public override void GivePlayerResource(ResourceType type) {
            Player.AddResource(type, 1);
        }
    }
}
