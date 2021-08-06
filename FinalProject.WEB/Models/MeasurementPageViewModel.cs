using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class MeasurementPageViewModel
    {
        public IEnumerable<DiveMeasurementViewModel> Measurements { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
