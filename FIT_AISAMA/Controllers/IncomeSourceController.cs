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
            var model = new IncomeSourceModel();
            return View("EditIncomeSource", model);
        }

        [HttpPost]
        public ActionResult SaveIncomeSource(IncomeSourceModel newIncome)
        {
            if (ModelState.IsValid)
            {
                var saveIncomeSource = new IncomeSource
                {
                    Id = newIncome.Id,
                    Source = newIncome.Source
                };

                incomeSourceService.SaveIncomeSource(saveIncomeSource);
                return RedirectToAction("Index");
            }

            return View("EditIncomeSource", newIncome);
        }

        [HttpPost]
        public ActionResult DeleteIncomeSource(int id)
        {
            
            var delSource = incomeSourceService.GetSourceById(id);

            if (delSource != null)
            {
                incomeSourceService.DeleteIncomeSource(delSource);
            }

            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult EditIncomeSource(int id)
        {
            var source = incomeSourceService.GetSourceById(id);
            if (source != null)
            {
                var model = new IncomeSourceModel(source);
                return View("EditIncomeSource", model);
            }
            return RedirectToAction("Index");
        }


    }
}
