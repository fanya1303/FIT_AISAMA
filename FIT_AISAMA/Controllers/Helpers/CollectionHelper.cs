using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.Controllers.Helpers
{
    public static class CollectionHelper
    {
        /// <summary>
        /// Возвращает SelectItems для статусов
        /// </summary>
        public static List<SelectListItem> GetStatusItems()
        {
            var result = new List<SelectListItem>();
            
            result.Add(new SelectListItem
            {
                Value = StatusState.Warehouse.ToString(),
                Text = GetEnumDescription(StatusState.Warehouse)
            });
            result.Add(new SelectListItem
            {
                Value = StatusState.Active.ToString(),
                Text = GetEnumDescription(StatusState.Active)
            });
            result.Add(new SelectListItem
            {
                Value = StatusState.Repair.ToString(),
                Text = GetEnumDescription(StatusState.Repair)
            });
            result.Add(new SelectListItem
            {
                Value = StatusState.IsUsed.ToString(),
                Text = GetEnumDescription(StatusState.IsUsed)
            });
            

            return result;
        }

        /// <summary>
        /// Возвращает значение Description 
        /// </summary>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            
            return value.ToString();
        }
    }
}