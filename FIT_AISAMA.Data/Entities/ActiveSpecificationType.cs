using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Entities
{
    public class ActiveSpecificationType
    {
        public int Id { get; set; }
        public int ActiveTypeId { get; set; }
        public string TypeName { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("ActiveTypeId")]
        public virtual ActiveType ActiveType { get; set; }
    }
}
