using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Services.Interfaces
{
    public interface IMaterialActiveService
    {
        /// <summary>
        /// Взять все МЦ
        /// </summary>
        List<MaterialActive> GetAllMaterialActive(bool withDeleted = false);

        /// <summary>
        /// Взять все МЦ по статусу
        /// </summary>
        List<MaterialActive> GetMaterialsByState(StatusState status);
        MaterialActive GetMaterialActiveById(int id);
        void RegistrateMaterialActive(MaterialActive newMaterialActive);
        void SaveMaterialActive(MaterialActive newMaterialActive);
        void DeleteMaterialActve(MaterialActive delMaterialActive);
        string GetNewMaterialActiveCode();

        /// <summary>
        /// Распределить МЦ
        /// </summary>
        void DistributeMaterialActive(MaterialActive distMaterialActive);
    }
}
