using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    interface IMaterialActiveService
    {
        List<MaterialActive> GetAllMaterialActive();
        MaterialActive GetMaterialActiveById(int id);
        void CreateMaterialActive(MaterialActive newMaterialActive);
        void SaveMaterialActive(MaterialActive newMaterialActive);
        void DeleteMaterialActve(MaterialActive delMaterialActive);
    }
}
