using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class DiverViewModel : UserViewModel
    {
        public int IdDiver { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public int? TelNumber { get; set; }
        public int? DeviceNumber { get; set; }
        public int? UserId { get; set; }
    }
}
