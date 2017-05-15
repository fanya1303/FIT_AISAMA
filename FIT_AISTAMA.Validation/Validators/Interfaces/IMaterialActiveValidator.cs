using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISTAMA.Validation.Models;

namespace FIT_AISTAMA.Validation.Validators.Interfaces
{
    public interface IMaterialActiveValidator
    {
        /// <summary>
        /// Валидация перед регистрацией
        /// </summary>
        ValidationInfo BeforeRegistrateValidation(MaterialActive checkItem);
        
        /// <summary>
        /// Валидация перед распределением
        /// </summary>
        ValidationInfo BeforeDistributionValidation(MaterialActive checkItem);

        /// <summary>
        /// Валидация перед списанием
        /// </summary>
        ValidationInfo DeforeWriteOffValidation(MaterialActive chekItem);
    }
}
