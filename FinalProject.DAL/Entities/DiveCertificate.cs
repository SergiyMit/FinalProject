using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.DAL.Entities
{
    public partial class DiveCertificate
    {
        public int IdCertificate { get; set; }
        public string CertNumber { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public CertificateLevel CertificateLevel { get; set; }
        public Diver Diver { get; set; }
    }
}
