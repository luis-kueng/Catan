﻿using Catan.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Players {
    public class PlayerUtility 
    {
        public Player Player { get; set; }
        
        public PlayerUtility(Player player) 
        { 
            Player = player;
        }

        public void PrintPlayer() {
            Console.WriteLine(Player.Name);
            Console.WriteLine("  Bricks:\t{0}", Player.Resources[ResourceType.BRICK]);
            Console.WriteLine("  Lumber:\t{0}", Player.Resources[ResourceType.LUMBER]);
            Console.WriteLine("  Wool:  \t{0}", Player.Resources[ResourceType.WOOL]);
            Console.WriteLine("  Grain: \t{0}", Player.Resources[ResourceType.GRAIN]);
            Console.WriteLine("  Ore:   \t{0}", Player.Resources[ResourceType.ORE]);
        }
    }
}
