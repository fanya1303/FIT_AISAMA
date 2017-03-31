using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Searchers;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Enums;
using FIT_AISAMA.Models.ActiveSpecificationType;
using FIT_AISAMA.Models.MaterialActive;
using FIT_AISTAMA.Validation.Validators.Interfaces;

namespace FIT_AISAMA.Controllers
{
    public class MaterialActiveController : BaseController
    {
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

            if(model.AmmortizateDate < model.IncomeDate)
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

                    return Json(new { Status = "OK", Message = "", Action = "/MaterialActive/Distribution" });
                }

                return Json(new { Status = "ERROR", Message = validation.ValidationMessage });
            }
            var htmlErrorMessage = string.Join(".</br>", ModelState.Values.SelectMany(v => v.Errors)
                                            .Select(e => e.ErrorMessage)) + ".";
            return Json(new {Status = "ERROR", Message = htmlErrorMessage});
        }

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
        /// Страница со списком всех МЦ
        /// </summary>
        public ActionResult MaterialActiveMainPage()
        {
            return View();
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
