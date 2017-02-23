using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Data.Services.Interfaces
{
    interface IIncomeSourceService
    {
        List<IncomeSource> GetAllIncomeSource();
        IncomeSource GetSourcesById(int id);
        void SaveIncomeSource(IncomeSource newIncomeSource);
        void DeleteIncomeSource(IncomeSource delIncomeSource);
    }
}
