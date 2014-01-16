using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;
using WeatherApp.Models.Repository;
using WeatherApp.Models.Webservices;
using WeatherApp.ViewModels;

namespace WeatherApp.Controllers
{
    public class WeatherAppController : Controller
    {
        private IRepository _repository;
        private GeoWebService locationFinder;
        private WeatherWebService weatherFinder;
        private Location checkedLocation;

        public WeatherAppController()
            : this(new Repository())
        {
        }

        internal WeatherAppController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: /WeatherApp/

        public ActionResult Search()
        {
            return View("Search");
        }

        // POST: /WeatherApp/

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Search(LocationName location)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    locationFinder = new GeoWebService();
                    weatherFinder = new WeatherWebService();
                    checkedLocation = new Location();
                    checkedLocation = locationFinder.GetLocationInfo(location);

                    List<WeatherInfo> weatherList = new List<WeatherInfo>();
                    weatherList = weatherFinder.GetWeatherInfo(checkedLocation);

                    _repository.AddWeather(weatherList);
                    _repository.Save();

                    return View("Index", weatherList);
                }
                else
                {
                    return View("Search");
                }
            }
            catch (Exception e)
            {
                string error = "This city was not found in the Geonames API";
                ModelState.AddModelError(String.Empty, error + e.InnerException);
                return View("Search");
            }
        }
    }
}
