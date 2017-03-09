using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services
{
   public class IncomeSourceService : BaseService, IIncomeSourceService
    {

        public List<IncomeSource> GetAllIncomeSource()
        {
            return dbContext.IncomeSources.ToList();
            
        }

        public IncomeSource GetSourceById(int id)
        {
            return dbContext.IncomeSources.FirstOrDefault(o => o.Id == id);
        }

        public void SaveIncomeSource(IncomeSource newIncomeSource)
        {

            if (newIncomeSource.Id == 0)
            {
                dbContext.IncomeSources.Add(newIncomeSource);
            }
            else
            {
                var curIncomeSource = dbContext.IncomeSources.Single(o => o.Id == newIncomeSource.Id);
                curIncomeSource.Source = newIncomeSource.Source;
            }
            dbContext.SaveChanges();
        }
        public void DeleteIncomeSource(IncomeSource delIncomeSource)
        {
            dbContext.IncomeSources.Remove(delIncomeSource);
            dbContext.SaveChanges();
        }
    }
}
