using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject.WEB.Controllers
{
    public class DiveController : Controller
    {
        private readonly IDiveService diveService = new DiveService();
        public IActionResult AddMeasurement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddMeasurement(DateTime dateOfDive, int waterTemperature, int diveTime, int maxDiveDeep)
        {
            int idDiver = Convert.ToInt32(Request.Cookies["diverId"]);
            DiveMeasurementDTO diveMeasurement = new DiveMeasurementDTO { DiverId = idDiver, DateOfDive = dateOfDive, DiveTime = diveTime, MaxDiveDeep = maxDiveDeep, WaterTemperature = waterTemperature };
            bool result = diveService.AddDiveMeasurement(diveMeasurement);
            if (result)
            {
                return RedirectToAction("MeasurementSuccess", "Dive");
            }
            return RedirectToAction("MeasurementError", "Dive");
        }

        public IActionResult MeasurementSuccess()
        {
            return View();
        }
        public IActionResult MeasurementError()
        {
            return View();
        }
    }
}
