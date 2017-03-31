using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;


namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface ILocationPlaceService
    {   
        /// <summary>
        /// Вернуть все места
        /// </summary>
        List<LocationPlace> GetAllLocationPlaces(bool withDeleted = false);
        /// <summary>
        /// Взять места по Id
        /// </summary>
        LocationPlace GetLocationPlaceById(int id);
        /// <summary>
        /// Сохранить или добавить место
        /// </summary>
        void SaveLocationPlace(LocationPlace newLocationPlace);
        /// <summary>
        /// Удалить место 
        /// </summary>
        void DeleteLocationPlace(int delId);

    }
}
