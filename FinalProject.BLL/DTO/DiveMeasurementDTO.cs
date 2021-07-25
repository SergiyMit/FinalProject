using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTO
{
    public class DiveMeasurementDTO
    {
        public int IdMeasurement { get; set; }
        public int? MaxDiveDeep { get; set; }
        public int? DiveTime { get; set; }
        public decimal? WaterTemperature { get; set; }
        public DateTime? DateOfDive { get; set; }
        public int DiverId { get; set; }
    }
}
