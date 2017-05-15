using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace FIT_AISAMA.Data.Enums
{
    public enum StatusState
    {
        [Description("На складе")]
        Warehouse = 1,

        [Description("Используется")]
        Active = 2,

        [Description("На ремонте")]
        Repair = 3,

        [Description("Списано")]
        IsUsed = 4
    }
}
