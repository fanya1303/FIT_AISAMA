using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISTAMA.Validation.Models;

namespace FIT_AISTAMA.Validation.Validators
{
    public interface IActiveSpecificationTypeValidator
    {
        /// <summary>
        /// Валидация перед сохранением
        /// </summary>
        ValidationInfo NeedSaveSpecificationType(ActiveSpecificationType checkItem);
    }
}
