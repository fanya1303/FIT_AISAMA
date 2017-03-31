using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.MaterialActive
{
    public class DestributionMaterialActiveSearchModel
    {
        public DestributionMaterialActiveSearchModel()
        {
            ActiveTypes = new List<Data.Entities.ActiveType>();
            IncomeSources = new List<Data.Entities.IncomeSource>();
            LocationPlaces =new List<Data.Entities.LocationPlace>();
        }

        public List<Data.Entities.ActiveType> ActiveTypes { get; set; }
        public List<Data.Entities.IncomeSource> IncomeSources { get; set; }
        public List<Data.Entities.LocationPlace> LocationPlaces { get; set; }

        public DestributionMaterialActiveSearchModel(List<Data.Entities.ActiveType> activeTypes, 
            List<Data.Entities.IncomeSource> incomeSources,
            List<Data.Entities.LocationPlace> locationPlaces)
        {
            ActiveTypes = activeTypes;
            IncomeSources = incomeSources;
            LocationPlaces = locationPlaces;


        }
    }
}