using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

namespace FIT_AISAMA.BusinessLogic.Services
{
    public class ActiveSpecificationService: BaseService, IActiveSpecificationService
    {
        public ActiveSpecificationService():base()
        {
            
        }

        public List<ActiveSpecification> GetAllActiveSpecification()
        {
            return dbContext.ActiveSpecifications.ToList();
        }
        public ActiveSpecification GetActiveSpecificationById(int id)
        {
            return dbContext.ActiveSpecifications.FirstOrDefault(o => o.Id == id);

        }
        public void SaveActiveSpecification(ActiveSpecification newActiveSpecification)
        {

            if (newActiveSpecification.Id == 0)
            {
                dbContext.ActiveSpecifications.Add(newActiveSpecification);
            }
            else
            {
                var curActiveSpecification = dbContext.ActiveSpecifications.Single(o => o.Id == newActiveSpecification.Id);
                curActiveSpecification.MaterialActive = newActiveSpecification.MaterialActive;
                curActiveSpecification.MaterialActiveId = newActiveSpecification.MaterialActiveId;
                curActiveSpecification.SpecificationType = newActiveSpecification.SpecificationType;
                curActiveSpecification.SpecificationTypeId = newActiveSpecification.SpecificationTypeId;
                curActiveSpecification.SpecificationValue = newActiveSpecification.SpecificationValue;
            }
            dbContext.SaveChanges();
        }

        public void DeleteActiveSpecification(int delId)
        {
            var delItem = dbContext.ActiveSpecifications.FirstOrDefault(o => o.Id == delId);
            if (delItem != null)
            {
                delItem.IsDeleted = true;
                dbContext.SaveChanges();
            }
            
        }

    }
}
