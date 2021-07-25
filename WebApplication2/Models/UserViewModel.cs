using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}