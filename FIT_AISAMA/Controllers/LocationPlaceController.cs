﻿using System;
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
        //
        // GET: /LocationPlace/

        public ActionResult Index()
        {
            var places = locationPlaceService.GetAllLocationPlaces().Select(o => new LocationPlaceModel(o)).ToList();
            return View(places);
        }
        [HttpGet]
        public ActionResult CreateLocationPlace()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateLocationPlace(LocationPlaceModel newLocation)
        {
            if (ModelState.IsValid)
            {
                var saveLocationPlace = new LocationPlace {LocationName = newLocation.LocationName};

               locationPlaceService.SaveLocationPlace(saveLocationPlace);
                return RedirectToAction("Index");
            }

            return View(newLocation);
        }

        [HttpPost]
        public ActionResult DeleteLocationPlace(int id)
        {
            var delLocationPlace = locationPlaceService.GetLocationPlaceById(id);

            if (delLocationPlace != null)
            {
                locationPlaceService.DeleteLocationPlace(delLocationPlace);
                
            }
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

        [HttpPost]
        public ActionResult EditLocationPlace(LocationPlaceModel editLocPlace)
        {
            if (ModelState.IsValid)
            {
                var saveLocPlace = new LocationPlace
                {
                    Id = editLocPlace.Id,
                    LocationName = editLocPlace.LocationName
                };
                locationPlaceService.SaveLocationPlace(saveLocPlace);
                return RedirectToAction("Index");
            }
            return View(editLocPlace);
        }
    }
}
