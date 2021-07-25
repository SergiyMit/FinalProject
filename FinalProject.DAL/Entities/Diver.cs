using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class Diver
    {
        public Diver()
        {
            DiveCertificates = new HashSet<DiveCertificate>();
            DiveMeasurements = new HashSet<DiveMeasurement>();
        }

        public int IdDiver { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? Age { get; set; }
        public string Email { get; set; }
        public int? TelNumber { get; set; }
        public int? DeviceNumber { get; set; }
        public int? IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; }
        public virtual ICollection<DiveCertificate> DiveCertificates { get; set; }
        public virtual ICollection<DiveMeasurement> DiveMeasurements { get; set; }
    }
}
