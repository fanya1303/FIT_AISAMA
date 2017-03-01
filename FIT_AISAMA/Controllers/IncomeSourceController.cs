using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.IncomeSource;

namespace FIT_AISAMA.Controllers
{
    public class IncomeSourceController : BaseController
    {
        
        public ActionResult Index()
        {
            var listS = incomeSourceService.GetAllIncomeSource().Select(o => new IncomeSourceModel(o)).ToList();
            return View(listS);

        }
        [HttpGet]
        public ActionResult CreateIncomeSource()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateIncomeSource(IncomeSourceModel newIncome)
        {
            if (ModelState.IsValid)
            {
                var saveIncomeSource = new IncomeSource
                {
                    Source = newIncome.Source
                };

                incomeSourceService.SaveIncomeSource(saveIncomeSource);
                return RedirectToAction("Index");
            }

            return View(newIncome);
        }
        [HttpPost]
        public ActionResult DeleteIncomeSource(int id)
        {
            
            var delSource = incomeSourceService.GetSourcesById(id);

            if (delSource != null)
            {
                incomeSourceService.DeleteIncomeSource(delSource);
            }

            return RedirectToAction("Index");
            
        }
        public ActionResult SourceDetails(int id)
        {
            var source = new IncomeSourceModel(incomeSourceService.GetSourcesById(id));
            return View(source);
        }


    }
}
