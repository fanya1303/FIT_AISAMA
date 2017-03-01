using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.LocationPlace
{
    public class LocationPlaceModel
    {
        public LocationPlaceModel()
        {
            
        }
        public int Id { get; set; }
        [Display (Name = "Место")]
        public string LocationName{ get; set; }

        public LocationPlaceModel(Data.Entities.LocationPlace source)
        {
            Id = source.Id;
            LocationName = source.LocationName;
        }


    }
}