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
    public class CatalogsValidator : ICatalogsValidator
    {
        IActiveSpecificationTypeService activeSpecificationTypeService = new ActiveSpecificationTypeService();
        IActiveTypesService activeTypesService = new ActiveTypeService();


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
        
        public ValidationInfo ValidateBeforeSave(ActiveType checkItem)
        {
            var curActiveType = activeTypesService.GetAllActiveType().FirstOrDefault(o => o.TypeCode == checkItem.TypeCode);

            if (curActiveType != null)
                return ValidationInfo.addError("Тип с таким кодом уже существует в системе. Измените или удалите существующий тип.");

            return ValidationInfo.isValid();
        }
    }
}
