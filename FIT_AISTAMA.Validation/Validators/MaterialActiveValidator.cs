using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;
using FIT_AISTAMA.Validation.Models;
using FIT_AISTAMA.Validation.Validators.Interfaces;

namespace FIT_AISTAMA.Validation.Validators
{
    public class MaterialActiveValidator: IMaterialActiveValidator
    {
        readonly IMaterialActiveService materialActiveService = new MaterialActiveService();

        /// <summary>
        /// Валидация перед регистрацией
        /// </summary>
        public ValidationInfo BeforeRegistrateValidation(MaterialActive checkItem)
        {
           
            if (materialActiveService.GetAllMaterialActive().Any(o => o.Code == checkItem.Code) && checkItem.Id == 0)
            {
                return ValidationInfo.addError("Материал с таким кодом уже зарегистрирован в системе");
            }
            
            return ValidationInfo.isValid();
        }

        /// <summary>
        /// Валидация перед распределением
        /// </summary>
        public ValidationInfo BeforeDistributionValidation(MaterialActive checkItem)
        {
            var materialActive = materialActiveService.GetMaterialActiveById(checkItem.Id);

            if(materialActive == null)
                return ValidationInfo.addError("Не найден материал");

            
            if (materialActive.IncomeDate.HasValue && checkItem.StartUseDate.HasValue 
                && materialActive.IncomeDate.Value > checkItem.StartUseDate.Value)
                return ValidationInfo.addError("Дата начала использования должна быть меньше даты регистрации " + materialActive.IncomeDate.Value);

            return ValidationInfo.isValid();
        }

    }
}
