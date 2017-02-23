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
        public static IPersonService personService = new PersonService();
    }
}
