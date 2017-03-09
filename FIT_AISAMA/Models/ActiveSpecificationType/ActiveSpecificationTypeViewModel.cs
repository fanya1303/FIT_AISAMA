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
            ActiveTypeList = new List<SelectListItem>();
        }

        /// <summary>
        /// Список типов МЦ
        /// </summary>
        public List<SelectListItem> ActiveTypeList { get; set; }

        public bool ShowDeleted { get; set; }

        
    }
}