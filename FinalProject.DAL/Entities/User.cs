using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class User 
    {

        public User()
        {
            Admins = new HashSet<Admin>();
            Divers = new HashSet<Diver>();
        }

        public int IdUser { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public int UserType { get; set; }

        public virtual ICollection<Admin> Admins { get; set; }
        public virtual ICollection<Diver> Divers { get; set; }
    }
}
