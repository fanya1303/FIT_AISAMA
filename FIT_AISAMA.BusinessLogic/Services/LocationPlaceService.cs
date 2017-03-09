﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services 
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

       public void DeleteLocationPlace(int delId)
       {
           var delLocationPlace = dbContext.LocationPlaces.FirstOrDefault(o => o.Id == delId);
           if (delLocationPlace != null)
           {
               dbContext.LocationPlaces.Remove(delLocationPlace);
               dbContext.SaveChanges();
           }
       }
        
    }
}