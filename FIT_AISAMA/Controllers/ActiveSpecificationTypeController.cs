using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Searchers;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.ActiveSpecificationType;
using FIT_AISTAMA.Validation.Validators;

namespace FIT_AISAMA.Controllers
{
    public class ActiveSpecificationTypeController : BaseController
    {

        public ActionResult Index()
        {
            var model = new ActiveSpecificationTypeViewModel();

            var activeTypeList = activeTypesService.GetAllActiveType();
            
            foreach (var item in activeTypeList)
            {
                model.ActiveTypeList.Add(new SelectListItem
                {
                    Text = item.TypeCode + " (" + item.TypeName + ")",
                    Value = item.Id.ToString()
                });
            }
            
            return View(model);
        }

        public ActionResult ActiveSpecificationTable(SpecificationTypeSearchModel searchModel)
        {
            var result =
                SpecificationTypeSearch.SearchSpecificationType(searchModel)
                    .Select(o => new ActiveSpecificationTypeModel(o)).OrderBy(o => o.ActiveTypeCode).ToList();
            return PartialView("Partial/SpecificationTypeTable", result);
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
                    var validation = catalogsValidator.NeedSaveSpecificationType(createSpecification);
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
                var model = new ActiveSpecificationTypeModel(specificationType);
                return View(model);
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult EditSpecificationType(int editId)
        {
            var specificationType = activeSpecificationTypeService.GetActiveSpecificationTypesById(editId);
            if (specificationType != null)
            {
                var model = new ActiveSpecificationTypeEditModel(specificationType);
                
                //Вытаскиваем недостающие типы. Тип самого продукта добавляется при создании модели
                var activeTypes = activeTypesService.GetAllActiveType();

                foreach (var item in activeTypes)
                {
                    model.ActiveTypeItems.Add(new SelectListItem
                    {
                        Selected = item.Id == editId,
                        Text = item.TypeCode + " ("+item.TypeName+")",
                        Value = item.Id.ToString()
                    });
                }
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SaveEditSpecificationType(ActiveSpecificationTypeEditModel editSpecificationType)
        {
            if (ModelState.IsValid)
            {
                var saveSpecificationType = new ActiveSpecificationType
                {
                    Id = editSpecificationType.Id,
                    ActiveTypeId = editSpecificationType.ActiveTypeId,
                    TypeName = editSpecificationType.TypeName,
                    IsDeleted = editSpecificationType.IsDeleted
                };

                var validation = catalogsValidator.NeedSaveSpecificationType(saveSpecificationType);
                if (validation.IsValid)
                {
                    activeSpecificationTypeService.SaveActiveSpecificationType(saveSpecificationType);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.WarningMessage = validation.ValidationMessage;
                }

                
            }
            var activeTypes = activeTypesService.GetAllActiveType();
            foreach (var item in activeTypes)
            {
                editSpecificationType.ActiveTypeItems.Add(new SelectListItem
                {
                    Selected = item.Id == editSpecificationType.ActiveTypeId,
                    Text = item.TypeCode + " (" + item.TypeName + ") ",
                    Value = item.Id.ToString()

                });
            }
            return View("EditSpecificationType",editSpecificationType);
        }

        //Сейчас не используется, потому что удаления как такового нет, можно только пометить как неактивную запись
        [HttpPost]
        public ActionResult DeletSpecificationType(int id)
        {
            var delSpecificationType = activeSpecificationTypeService.GetActiveSpecificationTypesById(id);
            if (delSpecificationType != null)
            {
                activeSpecificationTypeService.DeleteActiveSpecificationType(delSpecificationType.Id);
            }
            return RedirectToAction("Index");
        }

    }
}
