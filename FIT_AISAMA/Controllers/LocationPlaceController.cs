using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT_AISAMA.Data.Entities;
using FIT_AISAMA.Data.Services;
using FIT_AISAMA.Models.LocationPlace;

namespace FIT_AISAMA.Controllers
{
    public class LocationPlaceController : BaseController
    {

        public ActionResult Index()
        {
            var places = locationPlaceService.GetAllLocationPlaces().Select(o => new LocationPlaceModel(o)).ToList();
            return View(places);
        }

        [HttpGet]
        public ActionResult CreateLocationPlace()
        {
            var model = new LocationPlaceModel();
            return View("EditLocationPlace",model);
        }

        [HttpPost]
        public ActionResult SaveLocationPlace(LocationPlaceModel newLocation)
        {
            if (ModelState.IsValid)
            {
                var saveLocationPlace = new LocationPlace
                {
                    Id = newLocation.Id,
                    LocationName = newLocation.LocationName
                };

                locationPlaceService.SaveLocationPlace(saveLocationPlace);

                return RedirectToAction("Index");
            }

            return View("EditLocationPlace", newLocation);
        }

        [HttpPost]
        public ActionResult DeleteLocationPlace(int id)
        {
            locationPlaceService.DeleteLocationPlace(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditLocationPlace(int id)
        {
            var location = locationPlaceService.GetLocationPlaceById(id);

            if (location != null)
            {
                var editLocation = new LocationPlaceModel(location);
                return View(editLocation);
            }

            return RedirectToAction("Index");
        }
    }
}
