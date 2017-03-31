using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.BusinessLogic.Services;
using FIT_AISAMA.BusinessLogic.Services.Interfaces;
using FIT_AISAMA.Data.Entities;

using FIT_AISTAMA.Validation.Validators;
using FIT_AISTAMA.Validation.Validators.Interfaces;


namespace FIT_AISAMA.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (personService == null)
                personService = new PersonService();
            
            if (activeTypesService == null)
                activeTypesService = new ActiveTypeService();

            if(activeSpecificationTypeService == null)
                activeSpecificationTypeService = new ActiveSpecificationTypeService();
            
            if(incomeSourceService == null)
                incomeSourceService=new IncomeSourceService();

            if (locationPlaceService == null)
                locationPlaceService = new LocationPlaceService();

            if (catalogsValidator == null)
                catalogsValidator = new CatalogsValidator();

            if (materialActiveService == null)
                materialActiveService= new MaterialActiveService();

            if (materialActiveValidator == null)
                materialActiveValidator = new MaterialActiveValidator();
            
        }
        /// <summary>
        /// Валидатор справочников
        /// </summary>
        public static ICatalogsValidator catalogsValidator;

        /// <summary>
        /// Валидатор для МЦ
        /// </summary>
        public static IMaterialActiveValidator materialActiveValidator;

        /// <summary>
        /// Сервис по рабте с сотрудниками
        /// </summary>
        public static IPersonService personService;

        /// <summary>
        /// Сервис по работе с типами МЦ
        /// </summary>
        public static IActiveTypesService activeTypesService;

        /// <summary>
        /// Сервис по работе с типами характеристик
        /// </summary>
        public static IActiveSpecificationTypeService activeSpecificationTypeService;

        /// <summary>
        /// Сервис по работе c поступленими
        /// </summary>

        public static IIncomeSourceService incomeSourceService;

        /// <summary>
        /// Сервис по работе c местом расположения материала
        /// </summary>
        public static ILocationPlaceService locationPlaceService;

        public static IMaterialActiveService materialActiveService;

        public ActionResult MainPage()
        {
            return View();
        }
    }
}
