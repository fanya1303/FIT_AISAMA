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
        [Required(ErrorMessage = "Необходимо указать типы, которым принадлежит характеристика")]
        public int[] ActiveTypeId { get; set; }

        [Display(Name = "Наименование характеристики")]
        [Required(ErrorMessage = "Необходимо указать наименование характеристики")]
        [MinLength(3, ErrorMessage = "Длина наименования характеристики должна быть не меньше 3")]
        public string TypeName { get; set; }

        [Display(Name = "Единицы измерения")]
        public string MeasureType { get; set; }

        public List<SelectListItem> ActiveTypeItems { get; set; }


    }
}