using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services
{
    public interface IOxygenService
    {
        double GetOxygen(int time, int deep, int tank);
        double GetAllowedTime(int oxygen, int tank, int deep);
    }
}
