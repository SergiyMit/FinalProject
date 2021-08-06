using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTO
{
    public class DiveDTO
    {
        public int IdDive { get; set; }
        public int IdMeasurement { get; set; }
        public string DivePlace { get; set; }
        public int? WeightAmount { get; set; }
        public string DiveType { get; set; }
        public string DiveActivity { get; set; }
        public string DiveSuit { get; set; }
    }
}
