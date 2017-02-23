﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Data.Services.Interfaces
{
    interface IActiveSpecificationTypeService
    {
        List<ActiveSpecificationType> GetActiveSpecificationType();
        ActiveSpecificationType GetActiveSpecificationTypesById(int id);
        void SaveActiveSpecificationType(ActiveSpecificationType newActiveSpecificationType);
        void DeleteActiveSpecificationType(ActiveSpecificationType delActiveSpecificationType);
    }
}