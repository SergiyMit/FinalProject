using FinalProject.BLL.Services;
using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WEB.Controllers
{
    public class CalculationController : Controller
    {
        IOxygenService service;
        public CalculationController()
            {
            this.service = new OxygenService();
            }
        public IActionResult GetOxygen()
        {
            OxygenCalculationViewModel oxygenResult = new OxygenCalculationViewModel { Result = 0 };
            return View(oxygenResult);
        }
        [HttpPost]
        public IActionResult GetOxygen(int time, int deep, int tank)
        {
            double result = service.GetOxygen(time, deep, tank);
            OxygenCalculationViewModel oxygenResult = new OxygenCalculationViewModel { Result = result };
            return View(oxygenResult);
        }
        public IActionResult GetAllowedTime()
        {
            OxygenCalculationViewModel timeResult = new OxygenCalculationViewModel { Result = 0 };
            return View(timeResult);
        }
        [HttpPost]
        public IActionResult GetAllowedTime(int oxygen, int tank, int deep)
        {
            double result = service.GetAllowedTime(oxygen, tank, deep);
            OxygenCalculationViewModel timeResult = new OxygenCalculationViewModel { Result = result };
            return View(timeResult);
        }
    }
}
