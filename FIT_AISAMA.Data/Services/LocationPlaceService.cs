using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services.Interfaces;

namespace FIT_AISAMA.Data.Services 
{
   public class LocationPlaceService: BaseService, ILocationPlaceService
    {
        public List<LocationPlace> GetAllLocationPlaces()
        {
            return dbContext.LocationPlaces.ToList();
        }
        public LocationPlace GetLocationPlaceById(int id)
        {
            return dbContext.LocationPlaces.FirstOrDefault(o => o.Id == id);
 
        }
        public void SaveLocationPlace(LocationPlace newLocationPlace)
        {

            if(newLocationPlace.Id==0)
            {
                dbContext.LocationPlaces.Add(newLocationPlace);             
            }
            else
            {
               var curLocationPlace = dbContext.LocationPlaces.Single(o => o.Id == newLocationPlace.Id);
                curLocationPlace.LocationName = newLocationPlace.LocationName;               
            }
            dbContext.SaveChanges();
        }

       public void DeleteLocationPlace(LocationPlace delLocationPlace)
        {
            dbContext.LocationPlaces.Remove(delLocationPlace);
            dbContext.SaveChanges();
        }
        
    }
}
