using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services
{
    public class OxygenService: IOxygenService
    {

        public double GetOxygen(int time, int deep, int tank)
        {
            double requiredOxygen = 50 + (25 * time * (1 + (deep / 10)) / tank);
            return requiredOxygen;
        }
        public double GetAllowedTime(int oxygen, int tank, int deep)
        {
            int allowedTime = (oxygen * (tank)) / (25 * (1 + (deep / 10)));
            return allowedTime;
        }
    }
}
