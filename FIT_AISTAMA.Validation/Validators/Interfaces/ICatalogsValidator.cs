using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISTAMA.Validation.Models;

namespace FIT_AISTAMA.Validation.Validators
{
    public interface ICatalogsValidator
    {
        /// <summary>
        /// Валидация характеристики перед сохранением 
        /// </summary>
        ValidationInfo NeedSaveSpecificationType(ActiveSpecificationType checkItem);

        /// <summary>
        /// Валидация типа МЦ перед сохранением
        /// </summary>
        /// <param name="checkItem"></param>
        /// <returns></returns>
        ValidationInfo ValidateActiveTypeBeforeSave(ActiveType checkItem);

        /// <summary>
        /// Валидация сотрудника перед удалением
        /// </summary>
        ValidationInfo ValidatePersonBeforeDelet(Person checkItem);
    }
}
