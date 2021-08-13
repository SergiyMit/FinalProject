using FinalProject.BLL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Controllers
{
    public class DiverMenuController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LogOut()
        {
            string login = Request.Cookies["userLogin"];
            string idDiver = Request.Cookies["diverId"];
            if (login != null)
            {
                Response.Cookies.Delete(login);
            }
            if (idDiver != null)
            {
                Response.Cookies.Delete(idDiver);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
