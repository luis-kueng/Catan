using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan {
    public class Building {
        public Player Player { get; set; }
        public BuildingType BuildingType { get; set; }

        public Building(Player player, BuildingType buildingType) {
            this.Player = player;
            this.BuildingType = buildingType;
        }
    }
}
