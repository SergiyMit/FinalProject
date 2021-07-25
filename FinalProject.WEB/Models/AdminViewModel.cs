using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class AdminViewModel : UserViewModel
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PersonalAccessCode { get; set; }
        public int? UserId { get; set; }
    }
}
