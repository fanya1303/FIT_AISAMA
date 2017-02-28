using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Entities
{
    [Table("Persons")]
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public bool? ResponsiblePerson { get; set; }

        public virtual ICollection<MaterialActive> MaterialActives { get; set; }
    }
}
