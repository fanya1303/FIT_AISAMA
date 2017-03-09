using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Services;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Searchers
{
    public static class SpecificationTypeSearch
    {
        private static readonly IActiveSpecificationTypeService specificationTypeService = new ActiveSpecificationTypeService();

        public static List<ActiveSpecificationType> SearchSpecificationType(SpecificationTypeSearchModel searchModel)
        {
            var result = specificationTypeService.GetAllActiveSpecificationType(searchModel.WithDeleted);
            bool showAll = searchModel.ActiveTypes == null ||  searchModel.ActiveTypes.Length == 1 && searchModel.ActiveTypes[0] == 0;

            if (searchModel.ActiveTypes != null && searchModel.ActiveTypes.Length > 0 &&
                !showAll)
            {
                result = result.Where(o => searchModel.ActiveTypes.Contains(o.ActiveTypeId)).ToList();
            }
            return result;
        }
    }
}
