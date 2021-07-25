using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class Admin
    {
        public int IdAdmin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? PersonalAccessCode { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
    }
}
