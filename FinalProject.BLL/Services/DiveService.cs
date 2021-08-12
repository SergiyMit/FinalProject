using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace FinalProject.BLL.Services
{
    public class DiveService : IDiveService
    {
        private readonly IDiveRepository<Dive> diveRepository;
        private readonly IDiveRepository<DiveMeasurement> diveMeasurementRepository;
        public DiveService()
        {
            NixDatabaseContext context = new NixDatabaseContext();
            diveRepository = new DiveRepository<Dive>(context);
            diveMeasurementRepository = new DiveRepository<DiveMeasurement>(context);
        }
        public bool AddDiveMeasurement(DiveMeasurementDTO diveMeasurement)
        {
            bool result;
            DiveMeasurement diveMeasurement1 = new DiveMeasurement { DateOfDive = diveMeasurement.DateOfDive, IdDiver = diveMeasurement.DiverId, WaterTemperature = diveMeasurement.WaterTemperature, DiveTime = diveMeasurement.DiveTime, MaxDiveDeep = diveMeasurement.MaxDiveDeep };
            try
            {
                diveMeasurementRepository.Create(diveMeasurement1);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
        public List<DiveMeasurementDTO> GetAllMeasurements()
        {
            var dives = diveRepository.GetAll();
            List<int> diveToUsed = new List<int>();
            foreach (var dive in dives)
            {
                diveToUsed.Add(dive.IdMeasurement);
            }
            var result = diveMeasurementRepository.GetAll();
            var resultList = new List<DiveMeasurementDTO>();
            foreach (DiveMeasurement measurement in result)
            {
                if (!diveToUsed.Contains(measurement.IdMeasurement))
                {
                    resultList.Add(new DiveMeasurementDTO { DateOfDive = measurement.DateOfDive, DiverId = measurement.IdDiver, DiveTime = measurement.DiveTime, IdMeasurement = measurement.IdMeasurement, MaxDiveDeep = measurement.MaxDiveDeep, WaterTemperature = measurement.WaterTemperature });
                }
             }
            return resultList;
        }
        public void AddDive(DiveDTO dive)
        {
                Dive dive1 = new Dive { DiveType = dive.DiveType, DiveActivity = dive.DiveActivity, DivePlace = dive.DivePlace, DiveSuit = dive.DiveSuit, IdMeasurement = dive.IdMeasurement, WeightAmount = dive.WeightAmount };
                diveRepository.Create(dive1);
        }
        public List<DiveMeasurementDTO> GetAllMeasurementsForDiver()
        {
            var result = diveMeasurementRepository.GetAll();
            var resultList = new List<DiveMeasurementDTO>();
            foreach (DiveMeasurement measurement in result)
            {
                    resultList.Add(new DiveMeasurementDTO { DateOfDive = measurement.DateOfDive, DiverId = measurement.IdDiver, DiveTime = measurement.DiveTime, IdMeasurement = measurement.IdMeasurement, MaxDiveDeep = measurement.MaxDiveDeep, WaterTemperature = measurement.WaterTemperature });
            }
            return resultList;
        }
        public List<DiveDTO> GetAllDiveForDiver()
        {
            var result = diveRepository.GetAll();
            var resultList = new List<DiveDTO>();
            foreach (Dive dive in result)
            {
                resultList.Add(new DiveDTO {DiveActivity = dive.DiveActivity, DivePlace = dive.DivePlace, DiveSuit = dive.DiveSuit, DiveType = dive.DiveType, WeightAmount = dive.WeightAmount, IdDive = dive.IdDive, IdMeasurement = dive.IdMeasurement});
            }
            return resultList;
        }

        public DiveDTO GetDive(int idDive)
        {
            Dive dive = diveRepository.Get(idDive);
            DiveDTO result = new DiveDTO { DiveActivity = dive.DiveActivity, DivePlace = dive.DivePlace, DiveSuit = dive.DiveSuit, DiveType = dive.DiveType, WeightAmount = dive.WeightAmount, IdDive = dive.IdDive, IdMeasurement = dive.IdMeasurement };
            return result;
        }

        public DiveMeasurementDTO GetMeasurementByDive(int idDive)
        {
            List<DiveMeasurementDTO> measurements = GetAllMeasurementsForDiver();
            int idMeasurement = GetDive(idDive).IdMeasurement;
            DiveMeasurementDTO result = measurements.DefaultIfEmpty(null).FirstOrDefault(m => m.IdMeasurement == idMeasurement);
            return result;
        }
    }

}
