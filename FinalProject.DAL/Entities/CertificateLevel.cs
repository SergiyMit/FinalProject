using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class CertificateLevel
    {
        public CertificateLevel()
        {
            DiveCertificates = new HashSet<DiveCertificate>();
        }

        public int IdLevel { get; set; }
        public string LevelName { get; set; }
        public int? MaxAllowedDeep { get; set; }
        public int? RequiredDives { get; set; }
        public string AdditionalInfo { get; set; }

        public virtual ICollection<DiveCertificate> DiveCertificates { get; set; }
    }
}
