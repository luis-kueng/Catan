using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings
{
    public class StreetBuilding : Building
    {
        public StreetBuilding(Player player) : base(player)
        {
        }

        public override void AddResource(ResourceType type)
        {
        }
    }
}
