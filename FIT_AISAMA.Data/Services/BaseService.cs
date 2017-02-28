using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Services
{
    public class BaseService
    {
        public BaseService()
        {
            if(dbContext == null)
                dbContext = new DataContext();
        }

        public static DataContext dbContext = null;
    }
}
