using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
