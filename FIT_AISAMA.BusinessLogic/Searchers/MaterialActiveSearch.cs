using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Services;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Searchers
{
    public class MaterialActiveSearch
    {
        static readonly IMaterialActiveService materialActiveService = new MaterialActiveService();

        /// <summary>
        /// Поиск по зарегистрированым материалам
        /// </summary>
        public static List<MaterialActive> SearchRegistratedMaterials(MaterialActiveSearchModel search)
        {
            var result = materialActiveService.GetMaterialsByState(StatusState.Warehouse);

            if (!string.IsNullOrEmpty(search.NameOrManufacturer))
            {
                result =
                    result.Where(o => o.Manufacturer.ToLower().Contains(search.NameOrManufacturer.ToLower())
                    || o.Name.ToLower().Contains(search.NameOrManufacturer.ToLower())).ToList();
            }

            if (search.IncomeDate.HasValue)
            {
                result =
                    result.Where(o => o.IncomeDate.HasValue && o.IncomeDate.Value.Date == search.IncomeDate.Value)
                        .ToList();
            }

            return result;
        }

        /// <summary>
        /// Поиск по всем материалам
        /// </summary>
        public static List<MaterialActive> SearchMainMaterials(MaterialActiveSearchModel search)
        {
            var result = materialActiveService.GetAllMaterialActive(search.ShowDeleted);

            if (search.Statuses != null && search.Statuses.Any())
                result = result.Where(o => search.Statuses.Contains(o.Status)).ToList();

            if (search.ActiveTypeIds != null && search.ActiveTypeIds.Any())
                result = result.Where(o => search.ActiveTypeIds.Contains(o.ActiveTypeId)).ToList();
            

            if (!string.IsNullOrEmpty(search.NameOrManufacturer))
                result =
                    result.Where(o => o.Manufacturer.ToLower().Contains(search.NameOrManufacturer.ToLower())
                    || o.Name.ToLower().Contains(search.NameOrManufacturer.ToLower())).ToList();
            

            if (search.SinceIncomeDate.HasValue)
                result =
                    result.Where(o => o.IncomeDate.HasValue && o.IncomeDate.Value.Date >= search.SinceIncomeDate.Value.Date)
                        .ToList();
            

            if (search.ToIncomeDate.HasValue)
                result =
                    result.Where(o => o.IncomeDate.HasValue && o.IncomeDate.Value.Date <= search.ToIncomeDate.Value.Date)
                        .ToList();
            

            return result;
        }

        
    }
}
