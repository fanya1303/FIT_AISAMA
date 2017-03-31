using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.Data.Entities
{
    public class MaterialActive
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public int ActiveTypeId { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public int IncomeSourceId { get; set; }

        public DateTime? IncomeDate { get; set; }

        public DateTime? StartUseDate { get; set; }

        public DateTime? AmmortizateDate { get; set; }

        public DateTime? StopUseDate { get; set; }

        public int ResponsiblePersonId { get; set; }

        public int? OwnerPersonId { get; set; }

        public int? LocationPlaceId { get; set; }

        public int Price { get; set; }

        public StatusState Status { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("LocationPlaceId")]
        public virtual LocationPlace LocationPlace { get; set; }

        [ForeignKey("OwnerPersonId")]
        [InverseProperty("MaterialActives")]
        public virtual Person OwnerPerson { get; set; }

        [ForeignKey("ResponsiblePersonId")]
        public virtual Person ResponsiblePerson { get; set; }

        [ForeignKey("ActiveTypeId")]
        public virtual ActiveType ActiveType { get; set; }

        [ForeignKey("IncomeSourceId")]
        public virtual IncomeSource IncomeSource { get; set; }

        public virtual ICollection<ActiveSpecification> ActiveSpecifications { get; set; }

    }
}
