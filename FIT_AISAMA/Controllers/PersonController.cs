using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.Person;

namespace FIT_AISAMA.Controllers
{
    public class PersonController : BaseController
    {

        public ActionResult Index()
        {
            var persons = personService.GetAllPersons().Select(o => new PersonViewModel(o));
            return View(persons);
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePerson(Person newPerson)
        {
            if (ModelState.IsValid)
            {
                personService.SavePerson(newPerson);
                return RedirectToAction("Index");
            }
            return View(newPerson);
        }

        public ActionResult PersonDetails(int id)
        {
            var person = new PersonDetailViewModel(personService.GetPersonById(id));
            return View(person);
        }

        [HttpGet]
        public ActionResult EditPerson(int id)
        {
            var person = personService.GetPersonById(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult EditPerson(Person editPerson)
        {
            if (ModelState.IsValid)
            {
                personService.SavePerson(editPerson);
                var editedPerson = personService.GetPersonById(editPerson.Id);
                return RedirectToAction("PersonDetails", editedPerson);
            }
            return View(editPerson);
        }

        public ActionResult DeletePerson(int id)
        {
            var delPerson = personService.GetPersonById(id);

            if (delPerson != null)
            {
                personService.DeletePerson(delPerson);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult SearchPerson(string searchPerson)
        {
            if (searchPerson.Length > 0)
            {
                ViewBag.SearchString = searchPerson;
                var result = personService.SearchPersons(searchPerson).Select(o => new PersonViewModel(o)).ToList();
                return View("Index", result);
            }
            return RedirectToAction("Index");
        }

    }
}
