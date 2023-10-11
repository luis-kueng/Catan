using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings
{
    public class CityBuilding : Building
    {
        public CityBuilding(Player player) : base(player)
        {
        }

        public override void AddResource(ResourceType type)
        {
            Player.AddResource(type, 2);
        }
    }
}
