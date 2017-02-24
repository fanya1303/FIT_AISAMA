using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;


namespace FIT_AISAMA.Data.Services.Interfaces
{
    public interface IActiveTypesService
    {
        /// <summary>
        /// Взять все типы
        /// </summary>
        List<ActiveType> GetAllActiveType();
        /// <summary>
        /// Выбрать запись по id
        /// </summary>
        ActiveType GetActiveTypeById(int id);
        /// <summary>
        /// Добавить или изменить запись
        /// </summary>
        void SaveActiveType(ActiveType saveActiveType);
        /// <summary>
        /// Удалить запись
        /// </summary>
        void DelActiveType(ActiveType delActiveType);





    }
}
