using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Searchers;
using FIT_AISAMA.Controllers.Helpers;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;
using FIT_AISAMA.Models.ActiveSpecificationType;
using FIT_AISAMA.Models.MaterialActive;
using FIT_AISTAMA.Validation.Validators.Interfaces;

namespace FIT_AISAMA.Controllers
{
    public class MaterialActiveController : BaseController
    {
        #region Регистрация МЦ
        [HttpGet]
        public ActionResult RegistrateMaterialActive()
        {
            var activeTypes = activeTypesService.GetAllActiveTypes();
            var incomeSources = incomeSourceService.GetAllIncomeSource();
            var persons = personService.GetAllPersons();
            var locations = locationPlaceService.GetAllLocationPlaces();
            var model = new MaterialActiveRegisterModel(activeTypes, incomeSources, persons, locations);

            return View(model);
        }

        [HttpPost]
        public ActionResult RegistrateMaterialActive(MaterialActiveRegisterModel model)
        {
            //область проверок значений с формы
            if (model.ResponsiblePersonId == 0)
                ModelState.AddModelError("ResponsiblePersonId", "Необходимо указать материально ответственного");

            if(model.AmmortizateDate.HasValue && model.AmmortizateDate.Value.Date < model.IncomeDate.Date)
                ModelState.AddModelError("AmmortizateDate", "Дата амортизации должна быть больше даты регистрации");

            if (ModelState.IsValid)
            {
                var registerMaterial = new MaterialActive
                {
                    Code = model.Code,
                    ActiveTypeId = model.ActiveTypeId,
                    Name = model.Name,
                    Manufacturer = model.Manufacturer,
                    IncomeSourceId = model.IncomeSourceId,
                    IncomeDate = model.IncomeDate,
                    AmmortizateDate = model.AmmortizateDate,
                    ResponsiblePersonId = model.ResponsiblePersonId,
                    Price = model.Price,
                    ActiveSpecifications = model.Specifications
                };

                //бизнес валидация
                var validation = materialActiveValidator.BeforeRegistrateValidation(registerMaterial);

                if (validation.IsValid)
                {
                    materialActiveService.RegistrateMaterialActive(registerMaterial);
                    materialActiveStatusHistoryService.SetStatusByMaterialId(registerMaterial.Id, null, StatusState.Warehouse, DateTime.Now, "Постановка на учет");

                    return Json(new {Status = "OK", Message = "МЦ с кодом "+registerMaterial.Code+" успешно зарегистрирован"});
                }
                else
                {
                    return Json(new {Status = "ERROR", Message = validation.ValidationMessage});
                }
            }

            var errorMessage = string.Join(".\n", ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)) + ".";
            var htmlErrorMessage = string.Join(".</br>", ModelState.Values.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)) + ".";
            return Json(new {Status = "ERROR", Message = errorMessage, HtmlMessage = htmlErrorMessage});
        }
        #endregion

        #region Распределение МЦ
        /// <summary>
        /// Страница со списком зарегистрированых МЦ
        /// </summary>
        /// <returns></returns>
        public ActionResult Distribution()
        {
            var activeTypes = activeTypesService.GetAllActiveTypes();
            var incomeSources = incomeSourceService.GetAllIncomeSource();
            var locationPlaces = locationPlaceService.GetAllLocationPlaces();
            var model = new DestributionMaterialActiveSearchModel(activeTypes, incomeSources, locationPlaces);

            return View(model);
        }

        /// <summary>
        /// Грид с МЦ, находящимися на складе для дальнейшего распределения
        /// </summary>
        public ActionResult DistributionTable(MaterialActiveSearchModel search)
        {

            var list =
                MaterialActiveSearch.SearchRegistratedMaterials(search)
                    .Select(o => new MaterialActiveViewModel(o))
                    .ToList();
            return PartialView("Partial/RegisterMaterialActiveTable", list);

        }

        [HttpGet]
        public ActionResult DistributeMaterialActive(int materialId)
        {
            var materialItem = materialActiveService.GetMaterialActiveById(materialId);
            if (materialItem != null)
            {
                var persons = personService.GetAllPersons();
                var locations = locationPlaceService.GetAllLocationPlaces();
                var model = new MaterialActiveDestributionModel(materialItem, persons, locations);
                return View(model);
            }
            return RedirectToAction("Distribution");
        }

        [HttpPost]
        public ActionResult DistributeMaterialActive(MaterialActiveDestributionModel model)
        {
            if (model.LocationPlaceId == 0)
                ModelState.AddModelError("LocationPlaceId", "Необходимо указать Место использования");
            if (!model.StartUseDate.HasValue)
                ModelState.AddModelError("StartUseDate", "Необходимо указать дату начала использования");

            if (ModelState.IsValid)
            {
                var distribMaterialActive = new MaterialActive
                {
                    Id = model.Id,
                    StartUseDate = model.StartUseDate,
                    OwnerPersonId = model.OwnerPersonId,
                    LocationPlaceId = model.LocationPlaceId
                };
                var validation = materialActiveValidator.BeforeDistributionValidation(distribMaterialActive);

                if (validation.IsValid)
                {
                    materialActiveService.DistributeMaterialActive(distribMaterialActive);
                    materialActiveStatusHistoryService.SetStatusByMaterialId(distribMaterialActive.Id, StatusState.Warehouse, StatusState.Active, DateTime.Now, "Распределение МЦ");

                    return Json(new { Status = "OK", Message = "", Action = "/MaterialActive/Distribution" });
                }

                return Json(new { Status = "ERROR", Message = validation.ValidationMessage });
            }
            var htmlErrorMessage = string.Join(".</br>", ModelState.Values.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)) + ".";
            return Json(new {Status = "ERROR", Message = htmlErrorMessage});
        }
#endregion

        #region Основной список
        /// <summary>
        /// Страница со списком всех МЦ
        /// </summary>
        public ActionResult MaterialActiveMainPage()
        {
            var activeTypes = activeTypesService.GetAllActiveTypes();
            var statuses = CollectionHelper.GetStatusItems();
            var model = new MainMaterialActiveSearchModel(activeTypes, statuses);
            return View(model);
        }

        /// <summary>
        /// Основная таблица со списком МЦ
        /// </summary>
        /// <returns></returns>
        public ActionResult MainMaterialActiveTable(MaterialActiveSearchModel search)
        {
            var list =
                MaterialActiveSearch.SearchMainMaterials(search).Select(o => new MaterialActiveViewModel(o)).ToList();
            return PartialView("Partial/MainMaterialActiveTable", list);
        }
        #endregion

        #region Списание МЦ

        [HttpGet]
        public ActionResult WriteOffMaterialActive()
        {
            var materialActives = materialActiveService.GetMaterialsByState(StatusState.Active);
            var model = new WriteOffMaterialActiveModel(materialActives);

            return View("WriteOffMaterialActive", model);

        }


        [HttpPost]
        public ActionResult WriteOffMaterialActive(WriteOffMaterialActiveModel model)
        {
            if (ModelState.IsValid)
            {
                var materialActive = new MaterialActive()
                {
                    Id = model.Id,
                    StopUseDate = model.StopUseDate
                };
                var validation = materialActiveValidator.DeforeWriteOffValidation(materialActive);

                if (validation.IsValid)
                {
                    var curMaterialActive = materialActiveService.GetMaterialActiveById(materialActive.Id);

                    materialActiveService.WriteOffMaterialActive(materialActive);
                    materialActiveStatusHistoryService.SetStatusByMaterialId(curMaterialActive.Id, curMaterialActive.Status, StatusState.IsUsed, DateTime.Now, model.WriteOffReason);
                    return Json(new {Status = "OK", Message = "МЦ успешно списан"}, JsonRequestBehavior.DenyGet);
                }
                else
                {
                    return Json(new { Status = "ERROR", Message = validation.ValidationMessage });
                }
            }
            var htmlErrorMessage = string.Join(".</br>", ModelState.Values.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)) + ".";

            return Json(new {Status = "ERROR", Message = htmlErrorMessage});
        }

        public ActionResult ShortMaterialActiveInformation(int materialId)
        {
            var model = new MaterialActiveViewModel(materialActiveService.GetMaterialActiveById(materialId));

            return PartialView("Partial/ShortMaterialActiveInfo", model);
        }

        #endregion


        /// <summary>
        /// Подробная информация по МЦ
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult MaterialActiveDetail(int id)
        {
            var materialActive = materialActiveService.GetMaterialActiveById(id);

            if (materialActive != null)
            {
                var model = new MaterialActiveViewModel(materialActive);
                return View(model);
            }

            return RedirectToAction("Distribution");
        }

        /// <summary>
        /// Генерирует новый код
        /// </summary>
        [HttpPost]
        public ActionResult SetNewMaterialActiveBaseValues(int typeId)
        {
            var newCode = materialActiveService.GetNewMaterialActiveCode();
            var activeType = activeTypesService.GetActiveTypeById(typeId);
            int baseAmmortizationMounth = 0;
            if (activeType.BaseAmmortizationMounth.HasValue)
                baseAmmortizationMounth = activeType.BaseAmmortizationMounth.Value;
            return Json(new { Code = newCode, BaseAmmortizationMounth = baseAmmortizationMounth }, JsonRequestBehavior.DenyGet);
        }


    }
}
