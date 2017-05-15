using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT_AISAMA.Models.ActiveSpecificationType
{
    public class ActiveSpecificationTypeEditModel
    {
        public ActiveSpecificationTypeEditModel()
        {
            ActiveTypeItems = new List<SelectListItem>();
        }

        public int Id { get; set; }

        [Display(Name = "Тип МЦ")]
        public int ActiveTypeId { get; set; }

        [Display(Name = "Наименвоание характеристики")]
        public string TypeName { get; set; }

        [Display(Name = "Единицы измерения")]
        public string MeasureType { get; set; }

        public bool IsDeleted { get; set; }

        public List<SelectListItem> ActiveTypeItems { get; set; }

        public ActiveSpecificationTypeEditModel(Data.Entities.ActiveSpecificationType source)
        {
            Id = source.Id;
            ActiveTypeId = ActiveTypeId;
            TypeName = source.TypeName;
            MeasureType = source.MeasureType;
            IsDeleted = source.IsDeleted;
            ActiveTypeItems = new List<SelectListItem>();

            
        }
    }
}