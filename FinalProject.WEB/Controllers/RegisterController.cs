using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;
using FinalProject.BLL.Services;
using FinalProject.BLL.DTO;
using FinalProject.DAL.Entities;
using Ninject;
using Ninject.Modules;
using FinalProject.WEB.Util;
using FinalProject.BLL.Infrastructure;

namespace FinalProject.WEB.Controllers
{
    public class RegisterController : Controller
    {
        IUserService userService;
        public RegisterController(IUserService serv)
        {
            userService = serv;
        }

        [HttpGet]
        public ActionResult RegisterPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterPage(string login, string password, string name, string surname, int age, string email, int deviceNumber, int telNumber)
        {
            DiverDTO diver = new DiverDTO { Name = name, Surname = surname, Age = age, Email = email, DeviceNumber = deviceNumber, TelNumber = 0 };
            UserDTO user = new UserDTO { Login = login, Password = password, UserType = 1 };
            userService.AddDiver(diver, user);
            userService.Dispose();
             
            return View();
        }
    }
}
