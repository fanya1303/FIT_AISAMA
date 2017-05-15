using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface IMaterialActiveStatusHistoryService
    {
        /// <summary>
        /// Установить статус по id МЦ
        /// </summary>
        /// <param name="material">id МЦ</param>
        /// <param name="newStatus">Новый статус</param>
        /// <param name="eventDate">Дата изменения</param>
        /// <param name="reason">Причина изменения статуса</param>
        void SetStatusByMaterialId(int materialId, StatusState? oldStatus, StatusState newStatus, DateTime eventDate, string reason = "");
    }
}
