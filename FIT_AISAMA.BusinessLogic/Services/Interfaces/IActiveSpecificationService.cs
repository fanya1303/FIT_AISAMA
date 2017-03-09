using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface IActiveSpecificationService
    {
        List<ActiveSpecification> GetAllActiveSpecification();
        ActiveSpecification GetActiveSpecificationById(int id);
        void SaveActiveSpecification(ActiveSpecification newActiveSpecification);
        void DeleteActiveSpecification(int delId);

    }
}
