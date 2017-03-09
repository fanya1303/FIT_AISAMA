using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface IActiveSpecificationTypeService
    {
        /// <summary>
        /// Взять все характеристики
        /// </summary>
        List<ActiveSpecificationType> GetAllActiveSpecificationType(bool withDeleted = false);

        /// <summary>
        /// Взять характеристику по Id
        /// </summary>
        ActiveSpecificationType GetActiveSpecificationTypesById(int id);

        /// <summary>
        /// Сохранить характеристику
        /// </summary>
        void SaveActiveSpecificationType(ActiveSpecificationType newActiveSpecificationType);

        /// <summary>
        /// Удалить характеристику
        /// </summary>
        void DeleteActiveSpecificationType(int delId);

        /// <summary>
        /// Взять характеристики по определенному типу МЦ
        /// </summary>
        List<ActiveSpecificationType> GetSpecificationsByActiveType(int activeId);
    }
}
