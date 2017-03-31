using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FIT_AISAMA.Models.ActiveSpecificationType;

namespace FIT_AISAMA.Models.ActiveType
{
    public class ActiveTypeDetailsViewModel
    {
        public ActiveTypeDetailsViewModel(){}

        public int Id { get; set; }

        [Display(Name = "Код типа")]
        public string TypeCode { get; set; }

        [Display(Name = "Наименование типа")]
        public string TypeName { get; set; }

        [Display(Name = "Базовый срок амортизации (мес.)")]
        public int? BaseAmmortizationMounth { get; set; }

        public List<ActiveSpecificationTypeModel> ActiveSpecifications { get; set; }

        public ActiveTypeDetailsViewModel(Data.Entities.ActiveType source)
        {
            Id = source.Id;
            TypeCode = source.TypeCode;
            TypeName = source.TypeName;
            BaseAmmortizationMounth = source.BaseAmmortizationMounth;

            ActiveSpecifications = new List<ActiveSpecificationTypeModel>();
            if (source.ActiveSpecifications != null)
            {
                foreach (var item in source.ActiveSpecifications)
                {
                    ActiveSpecifications.Add(new ActiveSpecificationTypeModel(item));
                }
            }
        }
    }
}