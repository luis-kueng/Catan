using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings {
    public class CityBuilding : Building {
        public CityBuilding(Player player) : base(player) {
        }

        public override void GivePlayerResource(ResourceType type) {
            Player.AddResource(type, 2);
        }
    }
}
