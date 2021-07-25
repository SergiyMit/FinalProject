using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTO
{
    public class UserDTO
    {
        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }
    }
}
