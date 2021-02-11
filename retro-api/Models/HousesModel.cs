using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using retro_api.Interfaces;

namespace retro_api.Models
{
    public class HouseModel : IHousesModel
    {
        private IPotterContext _potterContext;

        public HouseModel(IPotterContext potterContext)
        {
            _potterContext = potterContext;
        }


        public List<House> GetHouses()
        {
            try
            {
                return _potterContext.houses.ToList(); 
            }
            catch (Exception err)
            {
                return null;
            }
        }

        public List<House> GetHouseById(string id)
        {
            try
            {
                return _potterContext.houses.Where(house => house.Id == Int32.Parse(id)).ToList(); ;
            } catch (Exception err)
            {
                return null;
            }
        }
    }
}
