using FinalProject.BLL.DTO;
using System;
using System.Collections.Generic;

namespace FinalProject.BLL.Interfaces
{
    public interface IChartService
    {
        public List<DiveMeasurementDTO> GetOxygenChartData(DateTime dateStart, DateTime dateEnd);
    }
}
