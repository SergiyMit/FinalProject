using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.BLL.Services
{
    public class ChartService : IChartService
    {
        private readonly IDiveRepository<DiveMeasurement> diveMeasurementRepository;
        public ChartService()
        {
            NixDatabaseContext context = new NixDatabaseContext();
            diveMeasurementRepository = new DiveRepository<DiveMeasurement>(context);
        }
        public List<DiveMeasurementDTO> GetOxygenChartData(DateTime dateStart, DateTime dateEnd)
        {
            var measurements = diveMeasurementRepository.GetAll().Where (m => m.DateOfDive >= dateStart && m.DateOfDive <= dateEnd);
                var resultList = new List<DiveMeasurementDTO>();
                foreach (DiveMeasurement measurement in measurements)
                {
                    resultList.Add(new DiveMeasurementDTO { DateOfDive = measurement.DateOfDive, DiverId = measurement.IdDiver, DiveTime = measurement.DiveTime, IdMeasurement = measurement.IdMeasurement, MaxDiveDeep = measurement.MaxDiveDeep, WaterTemperature = measurement.WaterTemperature });
                }
                return resultList;
        }
    }
}
