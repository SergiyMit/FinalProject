using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class Admin : User
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PersonalAccessCode { get; set; }
        public User User { get; set; }
    }
}
