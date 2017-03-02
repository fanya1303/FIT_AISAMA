using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FIT_AISAMA.Models.IncomeSource
{
    public class IncomeSourceModel
    {
        public IncomeSourceModel()
        {
            
        }
        
        public int Id { get; set; }

        [Display(Name = "Источник")]
        [Required]
        [MinLength(5, ErrorMessage = "Наименование источника поступления должно содержать не менее 5 символов")]
        public string Source { get; set; }

        public IncomeSourceModel(Data.Entities.IncomeSource source)
        {
            Id = source.Id;
            Source = source.Source;
            
        }
        
    }
}