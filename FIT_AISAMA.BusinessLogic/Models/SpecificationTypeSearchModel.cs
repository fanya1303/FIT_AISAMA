using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.BusinessLogic.Models
{
    public class SpecificationTypeSearchModel
    {
        public int[] ActiveTypes { get; set; }
        public bool WithDeleted { get; set; }
    }
}
