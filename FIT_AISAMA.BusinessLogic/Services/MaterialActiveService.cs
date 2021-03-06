﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;

namespace FIT_AISAMA.BusinessLogic.Services
{
  public class MaterialActiveService: IMaterialActiveService
    {
        static DataContext dbContext = new DataContext();

        public List<MaterialActive> GetAllMaterialActive(bool withDeleted = false)
        {
            var result = dbContext.MaterialActives.AsNoTracking().ToList();

            if (!withDeleted)
                result = result.Where(o => o.IsDeleted == false).ToList();

            return result;

        }

        public List<MaterialActive> GetMaterialsByState(StatusState status)
        {
            var result = dbContext.MaterialActives.Where(o => o.Status == status && o.IsDeleted == false).AsNoTracking().ToList();
            return result;
        }

        public MaterialActive GetMaterialActiveById(int id)
        {
            return dbContext.MaterialActives.Where(o => o.Id == id && !o.IsDeleted).AsNoTracking().FirstOrDefault();
        }

        public void RegistrateMaterialActive(MaterialActive newMaterialActive)
        {
            newMaterialActive.Status = StatusState.Warehouse;
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

        public string GetNewMaterialActiveCode()
        {
            var material = dbContext.MaterialActives.OrderByDescending(o => o.Code).FirstOrDefault();
            if (material != null)
            {
                var newCode = Convert.ToInt32(material.Code)+1;
                var result = newCode.ToString().PadLeft(8, '0');
                return result;
            }
            return "00000001";
        }

        public void DistributeMaterialActive(MaterialActive distMaterialActive)
        {
            var curMaterialActive = dbContext.MaterialActives.FirstOrDefault(o=> o.Id == distMaterialActive.Id);

            if (curMaterialActive != null)
            {
                curMaterialActive.StartUseDate = distMaterialActive.StartUseDate;
                curMaterialActive.OwnerPersonId = distMaterialActive.OwnerPersonId;
                curMaterialActive.LocationPlaceId = distMaterialActive.LocationPlaceId;
                curMaterialActive.Status = StatusState.Active;
                dbContext.SaveChanges();
            }
        }

        public void WriteOffMaterialActive(MaterialActive writeOffMaterialActive)
        {
            var curMaterialActive = dbContext.MaterialActives.FirstOrDefault(o => o.Id == writeOffMaterialActive.Id);

            if (curMaterialActive != null)
            {
                curMaterialActive.StopUseDate = writeOffMaterialActive.StopUseDate;
                curMaterialActive.Status = StatusState.IsUsed;
                dbContext.SaveChanges();
            }
        }

        public MaterialActive GetLastMaterialActive()
        {
            var maxId = dbContext.MaterialActives.Max(o => o.Id);
            var lastMaterial = dbContext.MaterialActives.FirstOrDefault(o => o.Id == maxId);
            return lastMaterial;
        }
        
    }
    
}
