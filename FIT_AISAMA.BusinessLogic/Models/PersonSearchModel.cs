using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.BusinessLogic.Models
{
    public class PersonSearchModel
    {
        public string SearchPersonText { get; set; }
        public bool ShowDeletedPerson { get; set; }
    }
}
