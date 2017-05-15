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
        [Required(ErrorMessage = "Необходимо указать код")]
        [MinLength(2, ErrorMessage = "Длина кода должна быть не меньше 2 символов")]
        [MaxLength(5, ErrorMessage = "Длина кода должна быть не больше 5 символов")]
        public string TypeCode { get; set; }
        [Display(Name = "Наименование типа")]
        [Required(ErrorMessage = "Необходимо указать название")]
        [MinLength(4, ErrorMessage = "Название должно содержать не меньше 4 символов")]
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