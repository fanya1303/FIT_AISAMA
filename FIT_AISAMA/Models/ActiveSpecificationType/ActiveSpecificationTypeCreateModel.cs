using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_AISAMA.Models.ActiveSpecificationType
{
    public class ActiveSpecificationTypeCreateModel
    {
        public ActiveSpecificationTypeCreateModel()
        {
            ActiveTypeItems = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Display(Name = "Тип МЦ")]
        public int[] ActiveTypeId { get; set; }

        [Display(Name = "Наименование характеристики")]
        public string TypeName { get; set; }

        public List<SelectListItem> ActiveTypeItems { get; set; }


    }
}