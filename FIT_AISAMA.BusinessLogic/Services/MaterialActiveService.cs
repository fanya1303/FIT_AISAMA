using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services
{
  public class MaterialActiveService: BaseService, IMaterialActiveService
    {
       
            public List<MaterialActive> GetAllMaterialActive()
            {
                return dbContext.MaterialActives.ToList();

            }

            public MaterialActive GetMaterialActiveById(int id)
            {
                return dbContext.MaterialActives.FirstOrDefault(o => o.Id == id);
            }

            public void CreateMaterialActive(MaterialActive newMaterialActive)
             {
                dbContext.MaterialActives.Add(newMaterialActive);
                dbContext.SaveChanges();
             }
            public void SaveMaterialActive(MaterialActive newMaterialActive)
            {

            }
            public void DeleteMaterialActve(MaterialActive delMaterialActive)
            {
                dbContext.MaterialActives.Remove(delMaterialActive);
                dbContext.SaveChanges();
            }
    }
    
}
