using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class OxygenCalculationViewModel
    {
        public int Oxygen { get; set; }
        public int Tank { get; set; }
        public int Deep { get; set; }
        public int Time { get; set; }
        public double Result { get; set; }

    }
}
