using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Services;
using FIT_AISAMA.Data.Services.Interfaces;

namespace FIT_AISAMA.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// Сервис по рабте с сотрудниками
        /// </summary>
        public static IPersonService personService = new PersonService();
        /// <summary>
        /// Сервис по работе с типами МЦ
        /// </summary>
        public static IActiveTypesService activeTypesService = new ActiveTypeService();
        /// <summary>
        /// Сервис по работе с типами характеристик
        /// </summary>
        public static IActiveSpecificationTypeService activeSpecificationTypeService = new ActiveSpecificationTypeService();

        public ActionResult MainPage()
        {
            return View();
        }
    }
}
