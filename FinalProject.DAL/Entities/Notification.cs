using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public class Notification
    {
        public string Title { get; set; }
        public string NotificationText { get; set; }
        public Diver Diver { get; set; }
    }
}
