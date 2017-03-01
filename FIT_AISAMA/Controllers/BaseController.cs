using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services;
using FIT_AISAMA.Data.Services.Interfaces;

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
            
            if(incomeSourceService==null)
                incomeSourceService=new IncomeSourceService();

            if (locationPlaceService== null)
                locationPlaceService = new LocationPlaceService();
            
        }

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

        public ActionResult MainPage()
        {
            return View();
        }
    }
}
