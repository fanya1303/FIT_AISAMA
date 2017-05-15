using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services
{
   public class IncomeSourceService : IIncomeSourceService
    {
       static DataContext dbContext = new DataContext();

        public List<IncomeSource> GetAllIncomeSource(bool withDeleted = false)
        {
            var result = dbContext.IncomeSources.ToList();
            if (!withDeleted)
                result = result.Where(o => o.IsDeleted == false).ToList();
            return result;

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
            var curIncomeSource =  dbContext.IncomeSources.FirstOrDefault(o=> o.Id == delIncomeSource.Id);
            if (curIncomeSource != null)
            {
                curIncomeSource.IsDeleted = true;
                dbContext.SaveChanges();
            }
        }
    }
}
