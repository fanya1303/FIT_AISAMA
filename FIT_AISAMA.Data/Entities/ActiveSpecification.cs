using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Entities
{
    public class ActiveSpecification
    {
        public int Id { get; set; }
        public int SpecificationTypeId { get; set; }
        public int MaterialActiveId { get; set; }
        public string SpecificationValue { get; set; }
        public bool IsDeleted { get; set; }

        [ForeignKey("SpecificationTypeId")]
        public virtual ActiveSpecificationType SpecificationType { get; set; }
        [ForeignKey("MaterialActiveId")]
        public virtual MaterialActive MaterialActive { get; set; }
    }
}
