using Catan.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catan.Buildings
{
    public static class BuildingFactory
    {
        public static Building? Building(BuildingType type, Player player)
        {
            switch (type)
            {
                case BuildingType.STREET:
                    if (player.HasResourcesForStreet())
                    {
                        player.BuildCity();
                        return new StreetBuilding(player);
                    }
                    return null;

                case BuildingType.SETTLEMENT:
                    if (player.HasResourcesForSettlement())
                    {
                        player.BuildSettlement();
                        return new SettlementBuilding(player);
                    }

                    return null;

                case BuildingType.CITY:
                    if (player.HasResourcesForCity())
                    {
                        player.BuildCity();
                        return new CityBuilding(player);
                    }

                    return null;

                default:
                    throw new NotImplementedException();
            }
        }
    }
}
