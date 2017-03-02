using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_AISAMA.Models.ActiveSpecificationType
{
    public class ActiveSpecificationTypeViewModel
    {
        public ActiveSpecificationTypeViewModel()
        {
            ActiveSpecificationTypeList = new List<ActiveSpecificationTypeModel>();
            ActiveTypeList = new List<SelectListItem>();
        }

        /// <summary>
        /// Список характеристик
        /// </summary>
        public List<ActiveSpecificationTypeModel> ActiveSpecificationTypeList { get; set; }

        /// <summary>
        /// Список типов МЦ
        /// </summary>
        public List<SelectListItem> ActiveTypeList { get; set; }

        
    }
}