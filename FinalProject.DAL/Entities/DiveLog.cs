﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class DiveLog
    {
        private int IdDive;
        public int WeightsAmount { get; set; }
        public string WetsuitType { get; set; }
        public decimal OxygenAtStart { get; set; }
        public decimal OxygenAtEnd { get; set; }
        public string DiveSite { get; set; }
        DiveMeasurement diveMeasurement;
    }
}
