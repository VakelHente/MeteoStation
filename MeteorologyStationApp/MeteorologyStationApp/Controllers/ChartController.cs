using System.Web.Mvc;
using MeteorologyStationApp.Models;

namespace MeteorologyStationApp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            ViewBag.Message = "Wykresy danych pogodowych.";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string DaysNumberForTemperatureChart, string TemperatureChartsType, string DaysNumberForHumidityChart, string HumidityChartsType, string PressureChartsType, string DaysNumberForPressureChart)
        {
            ViewBag.Message = "Wykresy danych pogodowych.";
            ViewBag.TemperatureDaysNumber = DaysNumberForTemperatureChart;
            ViewBag.TemperatureType = TemperatureChartsType;
            ViewBag.HumidityDaysNumber = DaysNumberForHumidityChart;
            ViewBag.HumidityType = HumidityChartsType;
            ViewBag.PressureType = PressureChartsType;
            ViewBag.PressureDaysNumber = DaysNumberForPressureChart;
            return View("Charts");
        }

        public ActionResult GenerateTemperatureChart(int daysNumber, string type)
        {

            var chart = new GenerateSpecifiedChartType();
            return File(chart.Chart(GenerateSpecifiedChartType.ChartName.Temperature, type, daysNumber), "img/png");
        }

        public ActionResult GenerateHumidityChart(int daysNumber, string type)
        {
            var chart = new GenerateSpecifiedChartType();
            return File(chart.Chart(GenerateSpecifiedChartType.ChartName.Humidity, type, daysNumber), "img/png");
        }

        public ActionResult GeneratePressureChart(int daysNumber, string type)
        {
            var chart = new GenerateSpecifiedChartType();
            return File(chart.Chart(GenerateSpecifiedChartType.ChartName.Pressure, type, daysNumber), "img/png");
        }
    }
}