using System;
using System.Collections.Generic;

namespace retro_api.Interfaces
{
    public interface IHousesModel
    {
        public List<House> GetHouses();
        public List<House> GetHouseById(string id);
    }
}
