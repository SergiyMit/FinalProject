

using System;

namespace FinalProject.WEB.Models
{
    public class LogViewModel
    {
        public string DivePlace { get; set; }
        public int? WeightAmount { get; set; }
        public string DiveType { get; set; }
        public string DiveActivity { get; set; }
        public string DiveSuit { get; set; }
        public int? MaxDiveDeep { get; set; }
        public int? DiveTime { get; set; }
        public decimal? WaterTemperature { get; set; }
        public DateTime? DateOfDive { get; set; }
    }
}
