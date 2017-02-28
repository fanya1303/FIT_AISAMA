using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.ActiveSpecificationType;
using FIT_AISTAMA.Validation.Validators;

namespace FIT_AISAMA.Controllers
{
    public class ActiveSpecificationTypeController : BaseController
    {
        ActiveSpecificationTypeValidator specificationTypeValidator = new ActiveSpecificationTypeValidator();

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
            var model = new ActiveSpecificationTypeCreateModel();
            var activeTypes = activeTypesService.GetAllActiveType();
            
            foreach (var item in activeTypes)
            {
                model.ActiveTypeItems.Add(new SelectListItem
                {
                    Text = item.TypeCode+" ("+item.TypeName+") ",
                    Value = item.Id.ToString()

                });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateActiveSpecificationType(ActiveSpecificationTypeCreateModel newSpecification)
        {
            var activeTypes = activeTypesService.GetAllActiveType();

            foreach (var item in activeTypes)
            {
                newSpecification.ActiveTypeItems.Add(new SelectListItem
                {
                    Text = item.TypeCode + " (" + item.TypeName + ") ",
                    Value = item.Id.ToString()

                });
            }

            if (ModelState.IsValid)
            {
                foreach (var itemType in newSpecification.ActiveTypeId)
                {
                    var createSpecification = new ActiveSpecificationType
                    {
                        ActiveTypeId = itemType,
                        TypeName = newSpecification.TypeName
                    };
                    var validation = specificationTypeValidator.NeedSaveSpecificationType(createSpecification);
                    //проверка на существование повторяющейся записи. сохранение только в случае, если такой записи нет
                    if (validation.IsValid)
                    {
                        activeSpecificationTypeService.SaveActiveSpecificationType(createSpecification);
                    }
                    else
                    {
                        ViewBag.WarningMessage = validation.ValidationMessage;
                        return View(newSpecification);
                    }
                }
                return RedirectToAction("Index");
            }
            
            return View(newSpecification);

        }

        public ActionResult SpecificationTypeDetail(int id)
        {
            var specificationType = activeSpecificationTypeService.GetActiveSpecificationTypesById(id);
            if (specificationType != null)
            {
                var model = new ActiveSpecificationTypeViewModel(specificationType);
                return View(model);
            }

            return RedirectToAction("Index");

        }

        [HttpGet]
        public ActionResult EditSpecificationType(int id)
        {
            var specificationType = activeSpecificationTypeService.GetActiveSpecificationTypesById(id);
            if (specificationType != null)
            {
                var model = new ActiveSpecificationTypeEditModel(specificationType);
                var activeTypes = activeTypesService.GetAllActiveType();

                foreach (var item in activeTypes)
                {
                    model.ActiveTypeItems.Add(new SelectListItem
                    {
                        Text = item.TypeCode + " ("+item.TypeName+")",
                        Value = item.Id.ToString()
                    });
                }
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditSpecificationType(ActiveSpecificationTypeEditModel editSpecificationType)
        {
            if (ModelState.IsValid)
            {
                var saveSpecificationType = new ActiveSpecificationType
                {
                    Id = editSpecificationType.Id,
                    ActiveTypeId = editSpecificationType.ActiveTypeId,
                    TypeName = editSpecificationType.TypeName
                };

                //При редактировании, если пользователь сменил объект на такой, который уже существует
                //то не сохраняем его изменения, а удаляем старый объект
                var validation = specificationTypeValidator.NeedSaveSpecificationType(saveSpecificationType);
                if (validation.IsValid)
                {
                    activeSpecificationTypeService.SaveActiveSpecificationType(saveSpecificationType);
                }
                else
                {
                    var delSpecificationType =
                        activeSpecificationTypeService.GetActiveSpecificationTypesById(saveSpecificationType.Id);
                    activeSpecificationTypeService.DeleteActiveSpecificationType(delSpecificationType);
                }

                return RedirectToAction("Index");
            }
            return View(editSpecificationType);
        }

        [HttpPost]
        public ActionResult DeletSpecificationType(int id)
        {
            var delSpecificationType = activeSpecificationTypeService.GetActiveSpecificationTypesById(id);
            if (delSpecificationType != null)
            {
                activeSpecificationTypeService.DeleteActiveSpecificationType(delSpecificationType);
            }
            return RedirectToAction("Index");
        }

    }
}
