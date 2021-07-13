using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTO
{
    class AdminDTO
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PersonalAccessCode { get; set; }
        public int UserId { get; set; }
    }
}
