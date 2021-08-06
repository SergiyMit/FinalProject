using FinalProject.BLL.DTO;
using System.Collections.Generic;

namespace FinalProject.BLL.Interfaces
{
    public interface IDiveService
    {
        public bool AddDiveMeasurement(DiveMeasurementDTO diveMeasurement);
        public List<DiveMeasurementDTO> GetAllMeasurements();
        public void AddDive(DiveDTO dive);
        public List<DiveMeasurementDTO> GetAllMeasurementsForDiver();
    }
}
