using System;
using System.Collections.Generic;
using System.Linq;
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



        public House GetHouseById(int id)
        {
            try
            {
                return _potterContext.houses.Where(house => house.Id == id).First();
            } catch (Exception err)
            {
                return null;
            }
        }

        public House InsertHouse(HouseRequest newHouse)
        {
            // try catch?
            // if house has null, db has NON-NULL

            // if EntryEntity.State == "Added"
            // remove id from incoming object?
            // create RequestHouse.cs
            // Add throws error on duplicate id
            House houseToInsert = newHouse.ToHouse();
            //map HouseRequest -> House
            // new House(newHouse.name, newHouse.founder, ne)

            // 🤩
            // create method to HouseRequest (.toHouse())
            // do via binding

            // (ignore for now...)
            // 'automapper' package - create profiles that do this job for me
            try
            {
            var EntryEntity = _potterContext.houses.Add(houseToInsert);
            // ? use int from SaveChanges?
            _potterContext.SaveChanges();
            return houseToInsert;
            } catch (Exception err)
            {
                throw err;
            }
        }

        public bool DeleteHouse(int id)
        {
            try
            {
            var houseToDelete = _potterContext.houses.Where(house => house.Id == id).Single();
            var trackingEntity = _potterContext.houses.Remove(houseToDelete);

            // error handle this
            var changesMade = _potterContext.SaveChanges();
            return true;
            } catch (Exception err)
            {
                return false;
            }
        }
    }
}
