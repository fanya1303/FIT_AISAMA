using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface IIncomeSourceService
    {
        List<IncomeSource> GetAllIncomeSource();
        IncomeSource GetSourceById(int id);
        void SaveIncomeSource(IncomeSource newIncomeSource);
        void DeleteIncomeSource(IncomeSource delIncomeSource);
    }
}
