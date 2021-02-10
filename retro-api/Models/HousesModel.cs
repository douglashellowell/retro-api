using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace retro_api.Models
{
    public class HouseModel
    {
        private IPotterContext _potterContext;

        public HouseModel(IPotterContext potterContext)
        {
            _potterContext = potterContext;
        }


        public List<House> GetHouses()
        {
            Console.WriteLine("getting houses....");
            try
            {
                return _potterContext.houses.ToList(); 
            }
            catch (Exception err)
            {
                return null;
            }
        }
    }
}
