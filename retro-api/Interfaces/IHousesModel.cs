using System;
using System.Collections.Generic;
using retro_api.Models;

namespace retro_api.Interfaces
{
    public interface IHousesModel
    {
        public List<House> GetHouses();
        public House GetHouseById(int id);
        public House InsertHouse(HouseRequest newHouse);
        public bool DeleteHouse(int id);
    }
}
