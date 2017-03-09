using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Entities
{
    public class ActiveType
    {
        public int Id { get; set; }
        public string TypeCode { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<ActiveSpecificationType> ActiveSpecifications { get; set; }
    }
}
