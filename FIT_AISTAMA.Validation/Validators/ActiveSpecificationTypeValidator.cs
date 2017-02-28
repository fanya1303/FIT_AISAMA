using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services;
using FIT_AISAMA.Data.Services.Interfaces;
using FIT_AISTAMA.Validation.Models;

namespace FIT_AISTAMA.Validation.Validators
{
    public class ActiveSpecificationTypeValidator
    {
        IActiveSpecificationTypeService activeSpecificationTypeService = new ActiveSpecificationTypeService();


        /// <summary>
        /// ПРоверка на дублирвоание записей
        /// </summary>
        public ValidationInfo NeedSaveSpecificationType(ActiveSpecificationType checkItem)
        {
            var curSpecificationType =
                activeSpecificationTypeService.GetAllActiveSpecificationType()
                    .FirstOrDefault(o => o.ActiveTypeId == checkItem.ActiveTypeId
                                && o.TypeName == checkItem.TypeName);
            
            if (curSpecificationType != null)
                return ValidationInfo.addError("Характеристика с такими значениями уже существует в системе: " + curSpecificationType.ActiveType.TypeCode);

            return ValidationInfo.isValid();
        }
    }
}
