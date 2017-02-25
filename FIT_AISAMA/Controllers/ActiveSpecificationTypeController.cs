using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.ActiveSpecificationType;

namespace FIT_AISAMA.Controllers
{
    public class ActiveSpecificationTypeController : BaseController
    {

        public ActionResult Index()
        {
            var list =
                activeSpecificationTypeService.GetAllActiveSpecificationType()
                    .Select(o => new ActiveSpecificationTypeViewModel(o))
                    .ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult CreateActiveSpecificationType()
        {
            var model = new ActiveSpecificationTypeEditModel();
            var activeTypes = activeTypesService.GetAllActiveType();
            
            foreach (var item in activeTypes)
            {
                model.ActiveTypeItems.Add(new SelectListItem
                {
                    Text = item.TypeCode,
                    Value = item.Id.ToString()

                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateActiveSpecificationType(ActiveSpecificationTypeEditModel newSpecification)
        {
            if (ModelState.IsValid)
            {
                /*var createSpecification = new ActiveSpecificationType
                {
                    ActiveTypeId = newSpecification.ActiveTypeId,
                    TypeName = newSpecification.TypeName
                };

                activeSpecificationTypeService.SaveActiveSpecificationType(createSpecification);*/
                return RedirectToAction("Index");
            }
            return View(newSpecification);
        }

    }
}
