using FinalProject.BLL.DTO;
using FinalProject.BLL.Interfaces;
using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;

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

    }

}
