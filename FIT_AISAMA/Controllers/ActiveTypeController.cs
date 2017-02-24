using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.ActiveType;

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
                activeTypesService.SaveActiveType(new Data.Entities.ActiveType
                {
                    Id = newActiveType.Id,
                    TypeCode = newActiveType.TypeCode,
                    TypeName = newActiveType.TypeName
                });
                return RedirectToAction("Index");
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
                var model = new ActiveType
                {
                    Id = editActiveType.Id,
                    TypeCode = editActiveType.TypeCode,
                    TypeName = editActiveType.TypeName
                };
                activeTypesService.SaveActiveType(model);
                return RedirectToAction("ActiveTypeDetails", editActiveType);
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
