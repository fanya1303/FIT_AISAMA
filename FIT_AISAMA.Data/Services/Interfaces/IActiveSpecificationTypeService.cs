using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.Data.Services.Interfaces
{
    public interface IActiveSpecificationTypeService
    {
        List<ActiveSpecificationType> GetAllActiveSpecificationType();
        ActiveSpecificationType GetActiveSpecificationTypesById(int id);
        void SaveActiveSpecificationType(ActiveSpecificationType newActiveSpecificationType);
        void DeleteActiveSpecificationType(ActiveSpecificationType delActiveSpecificationType);
    }
}
