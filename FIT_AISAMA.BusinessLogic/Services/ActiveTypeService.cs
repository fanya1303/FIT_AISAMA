using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;


namespace FIT_AISAMA.BusinessLogic.Services
{
    public class ActiveTypeService : BaseService, IActiveTypesService
    {

        public List<ActiveType> GetAllActiveType()
        {
            return dbContext.ActiveTypes.ToList();
        }

        public ActiveType GetActiveTypeById(int id)
        {
            return dbContext.ActiveTypes.FirstOrDefault(o => o.Id == id);
        }

        public void SaveActiveType(ActiveType saveActiveType)
        {
            if (saveActiveType.Id == 0)
            {
                dbContext.ActiveTypes.Add(saveActiveType);
            }
            else
            {
                var curActiveType = dbContext.ActiveTypes.Single(o => o.Id == saveActiveType.Id);
                curActiveType.TypeCode = saveActiveType.TypeCode;
                curActiveType.TypeName = saveActiveType.TypeName;
                
            }
            dbContext.SaveChanges();
        }

        public void DelActiveType(ActiveType delActiveType)
        {
            dbContext.ActiveTypes.Remove(delActiveType);
            dbContext.SaveChanges();
        }
            
    }
}
