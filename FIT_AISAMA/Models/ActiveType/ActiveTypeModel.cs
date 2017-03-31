using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.ActiveType
{
    public class ActiveTypeModel
    {
        public ActiveTypeModel() { }

        public int Id { get; set; }
        [Display(Name = "Код типа")]
        public string TypeCode { get; set; }
        [Display(Name = "Наименование типа")]
        public string TypeName { get; set; }
        [Display(Name = "Базовый срок амортизации (мес.)")]
        public int? BaseAmmortizationMounth { get; set; }

        public ActiveTypeModel(Data.Entities.ActiveType source)
        {
            Id = source.Id;
            TypeCode = source.TypeCode;
            TypeName = source.TypeName;
            BaseAmmortizationMounth = source.BaseAmmortizationMounth;
        }
        
    }
}