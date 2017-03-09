using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.BusinessLogic.Models;
using FIT_AISAMA.BusinessLogic.Searchers;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Models.Person;

namespace FIT_AISAMA.Controllers
{
    public class PersonController : BaseController
    {

        public ActionResult Index()
        {
            //var model = new PersonViewModel();
            
            return View();
        }

        [HttpGet]
        public ActionResult CreatePerson()
        {
            var model = new EditPersonModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult CreatePerson(EditPersonModel newPerson)
        {
            if (ModelState.IsValid)
            {
                var savePerson = new Person
                {
                    Id = newPerson.Id,
                    FullName = newPerson.FullName,
                    Position = newPerson.Position
                };
                personService.SavePerson(savePerson);
                return RedirectToAction("Index");
            }
            return View(newPerson);
        }

        public ActionResult PersonDetails(int id)
        {
            var person = personService.GetPersonById(id);
            
            if (person != null)
            {
                var validation = catalogsValidator.ValidatePersonBeforeDelet(person);
                var model = new PersonDetailViewModel(person);

                model.CanDeletePerson = validation.IsValid;
                model.DeleteMessage = validation.ValidationMessage;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditPerson(int id)
        {
            var person = personService.GetPersonById(id);
            if (person != null)
            {
                var validation = catalogsValidator.ValidatePersonBeforeDelet(person);
                var model = new EditPersonModel(person);
                model.CanDelete = validation.IsValid;
                model.CanDeleteMessage = validation.ValidationMessage;

                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditPerson(EditPersonModel editPerson)
        {
            if (ModelState.IsValid)
            {
                
                var savePerson = new Person
                {
                    Id = editPerson.Id,
                    FullName = editPerson.FullName,
                    Position = editPerson.Position,
                    ResponsiblePerson = editPerson.ResponsiblePerson,
                    IsDeleted = editPerson.IsDeleted
                };
                var validation = catalogsValidator.ValidatePersonBeforeDelet(savePerson);

                if (savePerson.IsDeleted && !validation.IsValid)
                {
                    editPerson.CanDelete = validation.IsValid;
                    editPerson.CanDeleteMessage = validation.ValidationMessage;
                }
                else
                {
                    personService.SavePerson(savePerson);
                    //var editedPerson = personService.GetPersonById(editPerson.Id);
                    return RedirectToAction("PersonDetails", new {id = savePerson.Id});
                }
            }
            return View(editPerson);
        }

        [HttpPost]
        public ActionResult DeletePerson(int id)
        {
            var delPerson = personService.GetPersonById(id);

            if (delPerson != null)
            {
                var validation = catalogsValidator.ValidatePersonBeforeDelet(delPerson);
                if (validation.IsValid)
                {
                    personService.DeletePerson(delPerson.Id);
                }
                else
                {
                    return RedirectToAction("PersonDetails", new {id = id});
                }
            }
            return RedirectToAction("Index");
            
        }

        [HttpPost]
        public ActionResult SearchPerson(PersonSearchModel serchModel)
        {
            var personList = PersonSearcher.SearchPersons(serchModel).Select(o => new PersonTableViewModel(o)).ToList();
            
            return PartialView("PersonTableView",personList);
            
            
        }

        [HttpPost]
        public ActionResult SetAsResponsiblePerson(int id)
        {
            personService.SetAsReponsiblePerson(id);
            return RedirectToAction("PersonDetails", new {id = id});
        }

    }
}
