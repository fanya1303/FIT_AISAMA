using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services
{
    public class ActiveSpecificationTypeService: IActiveSpecificationTypeService
    {
        static DataContext dbContext = new DataContext();     

        public List<ActiveSpecificationType> GetAllActiveSpecificationType(bool withDeleted = false)
        {
            var result = dbContext.ActiveSpecificationTypes.AsNoTracking().ToList();
            if (!withDeleted)
            {
                result = result.Where(o => o.IsDeleted == false).ToList();
            }
            return result;
        }

        public List<ActiveSpecificationType> GetSpecificationsByActiveType(int activeId)
        {
            return dbContext.ActiveSpecificationTypes.Where(o => o.ActiveTypeId == activeId).AsNoTracking().ToList();
        }

        public ActiveSpecificationType GetActiveSpecificationTypeById(int id)
        {
            return dbContext.ActiveSpecificationTypes.AsNoTracking().FirstOrDefault(o => o.Id == id);

        }
        public void SaveActiveSpecificationType(ActiveSpecificationType newActiveSpecificationType)
        {

            if (newActiveSpecificationType.Id == 0)
            {
                dbContext.ActiveSpecificationTypes.Add(newActiveSpecificationType);
            }
            else
            {
                var curActiveSpecificationType = dbContext.ActiveSpecificationTypes.Single(o => o.Id == newActiveSpecificationType.Id);
                curActiveSpecificationType.ActiveTypeId = newActiveSpecificationType.ActiveTypeId;
                curActiveSpecificationType.TypeName = newActiveSpecificationType.TypeName;
                curActiveSpecificationType.MeasureType = newActiveSpecificationType.MeasureType;
                curActiveSpecificationType.IsDeleted = newActiveSpecificationType.IsDeleted;
            }
            dbContext.SaveChanges();
        }

        public void DeleteActiveSpecificationType(int delId)
        {
            var delItem = dbContext.ActiveSpecificationTypes.FirstOrDefault(o => o.Id == delId);
            if (delItem != null)
            {
                delItem.IsDeleted = true;
                dbContext.SaveChanges();
            }
            
        }

    }
    
}
