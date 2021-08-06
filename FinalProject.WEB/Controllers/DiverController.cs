using FinalProject.BLL.DTO;
using FinalProject.BLL.Services;
using FinalProject.WEB.Models;
using Microsoft.AspNetCore.Mvc;


namespace FinalProject.WEB.Controllers
{
    public class DiverController : Controller
    {
        private readonly IUserService userService;
        public DiverController()
        {
            userService = new UserService();
        }
        public IActionResult ChangeDiver()
        {
            string login = Request.Cookies["userLogin"];
            int id = userService.GetDiverIdByLogin(login);
            DiverDTO diverFromDB = userService.GetDiver(id);
            DiverViewModel diver = new DiverViewModel { Name = diverFromDB.Name, Surname = diverFromDB.Surname, Age = diverFromDB.Age, Email = diverFromDB.Email, TelNumber = diverFromDB.TelNumber, DeviceNumber = diverFromDB.DeviceNumber, IdDiver = id };
            return View(diver);
        }
        [HttpPost]
        public IActionResult ChangeDiver(string name, string surname, int age, string email, int deviceNumber, int telNumber, int idDiver)
        {
            string login = Request.Cookies["userLogin"];
            int id = userService.GetUserIdByLogin(login);
            DiverDTO diver = new DiverDTO { Name = name, Surname = surname, Age = age, Email = email, DeviceNumber = deviceNumber, TelNumber = telNumber, IdDiver = idDiver, UserId = id };
            bool result = userService.ChangeDiver(diver);
            if (result)
            {
                ViewBag.Message = "Succesfully changed"!;
                return View();
            }
            ViewBag.Message = "Error! Try again!"!;
            return View();
        }
        public IActionResult ChangeUser()
        {
            string login = Request.Cookies["userLogin"];
            int userId = userService.GetUserIdByLogin(login);
            UserDTO user = userService.GetUser(userId);
            UserViewModel user1 = new UserViewModel { Login = user.Login, IdUser = user.IdUser, Password = user.Password, UserType = user.UserType };
            return View(user1);
        }

        [HttpPost]
        public IActionResult ChangeUser(string login, string password, int userType, int idUser)
        {
            UserDTO user = new UserDTO { Login = login, Password = password, IdUser = idUser, UserType = userType };
            bool result = userService.ChangeUser(user);
            if (result)
            {
                string login1 = Request.Cookies["userLogin"];
                Response.Cookies.Delete(login1);
                return RedirectToAction("UserChangeSuccesfull", "Diver");
            }
            ViewBag.Message = "Error! Try again!";
            return View();
        }
        public IActionResult UserChangeSuccesfull()
        {
            return View();
        }
    }
}
