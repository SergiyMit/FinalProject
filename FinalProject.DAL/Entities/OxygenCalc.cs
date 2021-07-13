using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class OxygenCalc
    {
        public int TimeOxygen { get; set; }
        public int DeepOxygen { get; set; }
        public int TankOxygen { get; set; }
        public int TankPreassure { get; set; }
    }
}
