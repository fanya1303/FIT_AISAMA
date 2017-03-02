using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services.Interfaces;

namespace FIT_AISAMA.Data.Services
{
    public class ActiveSpecificationTypeService: BaseService, IActiveSpecificationTypeService
    {
            

        public List<ActiveSpecificationType> GetAllActiveSpecificationType()
        {
            return dbContext.ActiveSpecificationTypes.ToList();
        }

        public List<ActiveSpecificationType> GetSpecificationsByActiveType(int activeId)
        {
            return dbContext.ActiveSpecificationTypes.Where(o => o.ActiveTypeId == activeId).ToList();
        }

        public ActiveSpecificationType GetActiveSpecificationTypesById(int id)
        {
            return dbContext.ActiveSpecificationTypes.FirstOrDefault(o => o.Id == id);

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
            }
            dbContext.SaveChanges();
        }

        public void DeleteActiveSpecificationType(ActiveSpecificationType delActiveSpecificationType)
        {
            dbContext.ActiveSpecificationTypes.Remove(delActiveSpecificationType);
            dbContext.SaveChanges();
        }

    }
    
}
