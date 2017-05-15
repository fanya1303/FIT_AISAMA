using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.Data.Entities
{
    public class MaterialActiveStatusHistory
    {
        public int Id { get; set; }
        public int MaterialActiveId { get; set; }
        public StatusState? OldState { get; set; }
        public StatusState NewState { get; set; }
        public string Reason { get; set; }
        public DateTime EventDate { get; set; }
    }
}
