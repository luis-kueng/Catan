using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Players;
using Catan.Tiles;

namespace Catan.Buildings
{
    public abstract class Building
    {
        public Player Player { get; set; }

        public Building(Player player)
        {
            Player = player;
        }

        public abstract void AddResource(ResourceType type);
    }
}
