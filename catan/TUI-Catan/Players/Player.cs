using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catan.Buildings;
using Catan.Tiles;

namespace Catan.Players
{
    public class Player
    {
        public string Name { get; set; }

        public Dictionary<ResourceType, int> Resources { get; set; }

        public Player(string name)
        {
            Name = name;
            Resources = LoadResources();
        }

        private static Dictionary<ResourceType, int> LoadResources()
        {
            var Resources = new Dictionary<ResourceType, int>();

            foreach (ResourceType type in Enum.GetValues(typeof(ResourceType)))
            {
                Resources.Add(type, 0);
            }

            return Resources;
        }

        public void AddResource(ResourceType type, int amount)
        {
            Resources[type] += amount;
        }

        public void RemoveResource(ResourceType type, int amount)
        {
            Resources[type] -= amount;
        }

        public Building? BuildBuilding(BuildingType type)
        {
            Building? building = BuildingFactory.Building(type, this);
            return building;
        }

        public bool HasResourcesForStreet()
        {
            return
                HasResources(ResourceType.BRICK, 1) &&
                HasResources(ResourceType.LUMBER, 1);
        }

        public void BuildStreet()
        {
            RemoveResource(ResourceType.BRICK, 1);
            RemoveResource(ResourceType.LUMBER, 1);
        }

        public bool HasResourcesForSettlement()
        {
            return
                HasResources(ResourceType.BRICK, 1) &&
                HasResources(ResourceType.LUMBER, 1) &&
                HasResources(ResourceType.WOOL, 1) &&
                HasResources(ResourceType.GRAIN, 1);
        }

        public void BuildSettlement()
        {
            RemoveResource(ResourceType.BRICK, 1);
            RemoveResource(ResourceType.LUMBER, 1);
            RemoveResource(ResourceType.WOOL, 1);
            RemoveResource(ResourceType.GRAIN, 1);
        }

        public bool HasResourcesForCity()
        {
            return
                HasResources(ResourceType.ORE, 3) &&
                HasResources(ResourceType.GRAIN, 2);
        }

        public void BuildCity()
        {
            RemoveResource(ResourceType.ORE, 3);
            RemoveResource(ResourceType.GRAIN, 2);
        }

        private bool HasResources(ResourceType type, int amount)
        {
            return Resources.ContainsKey(type) && Resources[type] >= amount;
        }
    }
}
