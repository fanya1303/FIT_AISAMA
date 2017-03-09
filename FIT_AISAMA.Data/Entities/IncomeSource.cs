using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Entities
{
    public class IncomeSource
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public bool IsDeleted { get; set; }
    }
}
