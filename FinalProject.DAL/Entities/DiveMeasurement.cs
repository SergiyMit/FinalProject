using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class DiveMeasurement
    {
        public int IdMeasurement { get; set; }
        public int? MaxDiveDeep { get; set; }
        public int? DiveTime { get; set; }
        public decimal? WaterTemperature { get; set; }
        public DateTime? DateOfDive { get; set; }
        public int? IdDiver { get; set; }

        public virtual Diver IdDiverNavigation { get; set; }
    }
}
