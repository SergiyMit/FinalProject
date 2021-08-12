using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Parsing;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using System.Data;
using System.IO;
using Syncfusion.Drawing;

namespace FinalProject.WEB.Controllers
{
    public class DiveController : Controller
    {
        private readonly IDiveService diveService;
        public DiveController(IDiveService service)
        {
            diveService = service;
        }
        public List<DiveMeasurementViewModel> GetMeasurementTable()
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
            return result;
        }
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
                ViewBag.Message = "Succesfully added!";
                return View();
            }
            ViewBag.Message = "Error! Try again!";
            return View();
        }


        public IActionResult AddDive()
        {
            var result = GetMeasurementTable();
            return View(result);
        }
        [HttpPost]
        public IActionResult AddDive(int idMeasurement, string divePlace, string diveType, int weightAmount, string diveActivity, string diveSuit)
        {

            DiveDTO dive = new DiveDTO {DiveActivity = diveActivity, IdMeasurement = idMeasurement, DivePlace = divePlace, DiveSuit = diveSuit, DiveType = diveType, WeightAmount = weightAmount };
            diveService.AddDive(dive);
            var result = GetMeasurementTable();
            return View(result);
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
            var count = source.Count;
            var items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            MeasurementPageViewModel viewModel = new MeasurementPageViewModel
            {
                PageViewModel = pageViewModel,
                Measurements = items
            };
            return View(viewModel);
        }
        public IActionResult GetPrintableReport()
        {
            List<DiveDTO> dive = diveService.GetAllDiveForDiver();
            List<DiveViewModel> result = new List<DiveViewModel>();
            foreach (DiveDTO item in dive)
            {
                result.Add(new DiveViewModel {DiveActivity = item.DiveActivity, DivePlace = item.DivePlace, DiveSuit = item.DiveSuit, DiveType = item.DiveType, IdDive = item.IdDive, IdMeasurement = item.IdMeasurement, WeightAmount = item.WeightAmount });
            }
            return View(result);
        }
        [HttpPost]
        public IActionResult GetPrintableReport(int idDive)
        {
            DiveDTO dive = diveService.GetDive(idDive);
            DiveMeasurementDTO measurement = diveService.GetMeasurementByDive(idDive);
            LogViewModel log = new LogViewModel { DateOfDive = measurement.DateOfDive,
                DiveActivity = dive.DiveActivity, DivePlace = dive.DivePlace, DiveSuit = dive.DiveSuit,
                DiveTime = measurement.DiveTime, DiveType = dive.DiveType, MaxDiveDeep = measurement.MaxDiveDeep,
                WaterTemperature = measurement.WaterTemperature, WeightAmount = dive.WeightAmount };
            PdfDocument doc = new PdfDocument();
            PdfPage page = doc.Pages.Add();
            PdfGrid pdfGrid = new PdfGrid();
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Place of the dive");
            dataTable.Columns.Add("Amount of weights");
            dataTable.Columns.Add("Type of the dive");
            dataTable.Columns.Add("Activity during dive");
            dataTable.Columns.Add("Divesuit type");
            dataTable.Columns.Add("Max deep during dive");
            dataTable.Columns.Add("Time of the dive (minutes)");
            dataTable.Columns.Add("Water temperature (celsius)");
            dataTable.Columns.Add("Date of the dive");
            dataTable.Columns.Add("Signature (Stamp)");
            dataTable.Rows.Add(new object[] {log.DivePlace.ToString(), log.WeightAmount.ToString(), log.DiveType.ToString(), log.DiveActivity.ToString(),
                log.DiveSuit.ToString(), log.MaxDiveDeep.ToString(),
                log.DiveTime.ToString(), log.WaterTemperature.ToString(), log.DateOfDive.ToString(), ""  });
            pdfGrid.DataSource = dataTable;
            pdfGrid.Draw(page, new PointF(10, 10));
            MemoryStream stream = new MemoryStream();
            doc.Save(stream);
            stream.Position = 0;
            doc.Close(true);
            string contentType = "application/pdf";
            string fileName = "DiveLog.pdf";
            return File(stream, contentType, fileName);

        }
    }
}
