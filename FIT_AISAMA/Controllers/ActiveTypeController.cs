using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.ActiveType;
using FIT_AISTAMA.Validation.Validators;

namespace FIT_AISAMA.Controllers
{
    public class ActiveTypeController : BaseController
    {

        public ActionResult Index()
        {
            var items = activeTypesService.GetAllActiveType().Select(o => new ActiveTypeModel(o));
            return View(items);
        }

        [HttpGet]
        public ActionResult CreateActiveType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateActiveType(ActiveTypeModel newActiveType)
        {
            if (ModelState.IsValid)
            {
                var newActive = new Data.Entities.ActiveType
                {
                    TypeCode = newActiveType.TypeCode,
                    TypeName = newActiveType.TypeName
                };
                var validate = catalogsValidator.ValidateActiveTypeBeforeSave(newActive);

                if (validate.IsValid)
                {
                    activeTypesService.SaveActiveType(newActive);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.WarningMessage = validate.ValidationMessage;
                }
                
            }
            return View(newActiveType);
        }

        public ActionResult ActiveTypeDetails(int id)
        {
            var activeType = activeTypesService.GetActiveTypeById(id);
            if (activeType != null)
            {
                var model = new ActiveTypeModel(activeType);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult EditActiveType(int id)
        {
            var activeType = activeTypesService.GetActiveTypeById(id);
            if (activeType != null)
            {
                var model= new ActiveTypeModel(activeType);
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditActiveType(ActiveTypeModel editActiveType)
        {
            if (ModelState.IsValid)
            {
                var saveActiveType = new ActiveType
                {
                    Id = editActiveType.Id,
                    TypeCode = editActiveType.TypeCode,
                    TypeName = editActiveType.TypeName
                };
                var validate = catalogsValidator.ValidateActiveTypeBeforeSave(saveActiveType);

                if (validate.IsValid)
                {
                    activeTypesService.SaveActiveType(saveActiveType);
                    return RedirectToAction("ActiveTypeDetails", new {id = editActiveType.Id});
                }
                else
                {
                    ViewBag.WarningMessage = validate.ValidationMessage;
                }
            }
            return View(editActiveType);
        }

        public ActionResult DeleteActiveType(int id)
        {
            var delActiveType = activeTypesService.GetActiveTypeById(id);
            if (delActiveType != null)
            {
                activeTypesService.DelActiveType(delActiveType);
                
            }
            return RedirectToAction("Index");
        }

    }
}
