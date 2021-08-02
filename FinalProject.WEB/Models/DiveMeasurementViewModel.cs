using System;

namespace FinalProject.WEB.Models
{
    public class DiveMeasurementViewModel
    {
        public int IdMeasurement { get; set; }
        public int? MaxDiveDeep { get; set; }
        public int? DiveTime { get; set; }
        public decimal? WaterTemperature { get; set; }
        public DateTime? DateOfDive { get; set; }
        public int DiverId { get; set; }
    }
}
