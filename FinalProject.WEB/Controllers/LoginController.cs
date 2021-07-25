using FinalProject.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.WEB.Controllers
{
    public class LoginController : Controller
    {
        readonly IUserService userService;
        public LoginController()
        {
            userService = new UserService();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(string login, string password) 
        {
            bool result = userService.CheckLogin(login, password);
            if (result)
            {
                Response.Cookies.Append("userLogin",login);
                return RedirectToAction("Index", "DiverMenu");
            }
            return RedirectToAction("LoginError","Login");
        }
        public IActionResult LoginError()
        {
            return View();
        }
    }
}
