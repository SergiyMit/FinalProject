using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FinalProject.WEB.Controllers
{
    public class ChartController : Controller
    {
        private readonly IChartService chartService;
        public ChartController(IChartService service)
        {
            chartService = service;
        }
        public IActionResult GetDiveTimeChartMenu()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetDiveTimeChartMenu(DateTime dateStart, DateTime dateEnd)
        {
            List<DiveMeasurementDTO> measurements = chartService.GetOxygenChartData(dateStart, dateEnd);
            List<DiveTimeChartViewModel> result = new List<DiveTimeChartViewModel>();
            int idDiver = Convert.ToInt32(Request.Cookies["diverId"]);
            foreach (var measurement in measurements)
            {
                if (measurement.DiverId == idDiver)
                {
                    result.Add(new DiveTimeChartViewModel { DateOfDive = measurement.DateOfDive, DiveTime = measurement.DiveTime });
                }
            }
            int?[] arrayTime = new int?[6];
            string[] arrayDate = new string[6];
            int count = 0;
            foreach (var measurement in result)
            {
                arrayTime[count] = measurement.DiveTime;
                arrayDate[count] = measurement.DateOfDive.ToString();
                count++;
            }
            ViewBag.Date = arrayDate;
            ViewBag.Time = arrayTime;
            return View();
        }
    }
}
