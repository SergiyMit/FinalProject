using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.BLL.Services;
using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public IActionResult AddDive()
        {
            List<DiveMeasurementDTO> measurements = diveService.GetAllMeasurements();
            List<DiveMeasurementViewModel> result = new List<DiveMeasurementViewModel>();
            int idDiver = Convert.ToInt32(Request.Cookies["diverId"]);
            foreach (var measurement in measurements)
            {
                if (measurement.DiverId == idDiver)
                {
                    result.Add(new DiveMeasurementViewModel { DateOfDive = measurement.DateOfDive, DiverId = measurement.DiverId, DiveTime = measurement.DiveTime, IdMeasurement = measurement.IdMeasurement, MaxDiveDeep = measurement.MaxDiveDeep, WaterTemperature = measurement.WaterTemperature });
                }
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult AddDive(int idMeasurement, string divePlace, string diveType, int weightAmount, string diveActivity, string diveSuit)
        {
            DiveDTO dive = new DiveDTO {DiveActivity = diveActivity, IdMeasurement = idMeasurement, DivePlace = divePlace, DiveSuit = diveSuit, DiveType = diveType, WeightAmount = weightAmount };
            diveService.AddDive(dive);
            return View();
        }
        public IActionResult GetAllMeasurement(int page = 1)
        {
            List<DiveMeasurementDTO> measurements = diveService.GetAllMeasurementsForDiver();
            List<DiveMeasurementViewModel> source = new List<DiveMeasurementViewModel>();
            int idDiver = Convert.ToInt32(Request.Cookies["diverId"]);
            foreach (var measurement in measurements)
            {
                if (measurement.DiverId == idDiver)
                {
                    source.Add(new DiveMeasurementViewModel { DateOfDive = measurement.DateOfDive, DiverId = measurement.DiverId, DiveTime = measurement.DiveTime, IdMeasurement = measurement.IdMeasurement, MaxDiveDeep = measurement.MaxDiveDeep, WaterTemperature = measurement.WaterTemperature });
                }
            }
            int pageSize = 3;
            var count = source.Count();
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            MeasurementPageViewModel viewModel = new MeasurementPageViewModel
            {
                PageViewModel = pageViewModel,
                Measurements = items
            };
            return View(viewModel);
        }
    }
}
