using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;


namespace FIT_AISAMA.BusinessLogic.Services
{
    public class ActiveTypeService : IActiveTypesService
    {
        static DataContext dbContext = new DataContext();

        public List<ActiveType> GetAllActiveTypes(bool withDeleted = false)
        {
            var result = dbContext.ActiveTypes.AsNoTracking().ToList();
            if (!withDeleted)
                result = result.Where(o => o.IsDeleted == false).ToList();
            return result;
        }

        public ActiveType GetActiveTypeById(int id)
        {
            var result = dbContext.ActiveTypes.Include(o => o.ActiveSpecifications).AsNoTracking().FirstOrDefault(o => o.Id == id);
            return result;
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
                curActiveType.BaseAmmortizationMounth = saveActiveType.BaseAmmortizationMounth;

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
