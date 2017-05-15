using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Services
{
    public class MaterialActiveStatusHistoryService : IMaterialActiveStatusHistoryService
    {
        static DataContext dbContext = new DataContext();

        /// <summary>
        /// Установить статус по id МЦ
        /// </summary>
        public void SetStatusByMaterialId(int materialId, StatusState? oldStatus, StatusState newStatus, DateTime eventDate, string reason = "")
        {
            var materialActive = dbContext.MaterialActives.Where(o => o.Id == materialId).AsNoTracking().FirstOrDefault();

            if (materialActive != null)
            {
                var statusHistory = new MaterialActiveStatusHistory
                {
                    MaterialActiveId = materialActive.Id,
                    OldState = oldStatus,
                    NewState = newStatus,
                    EventDate = eventDate,
                    Reason = reason
                };
                dbContext.MaterialActiveStatusHistories.Add(statusHistory);
                dbContext.SaveChanges();
            }
        }
    }
}
