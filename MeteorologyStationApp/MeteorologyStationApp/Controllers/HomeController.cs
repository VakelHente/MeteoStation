using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MeteorologyStationApp.Models;

namespace MeteorologyStationApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult WeatherForecast()
        {
            var predict = new PredictionWheather();
            string[] weatherForecast =  predict.Prediction();

            ViewBag.Message = "Prognoza pogody";
            ViewBag.Opinion = weatherForecast[3];
            ViewBag.Pressure = weatherForecast[0];
            ViewBag.Humidity = weatherForecast[1];
            ViewBag.Temperature = weatherForecast[2];

            return View();
        }
    }
}