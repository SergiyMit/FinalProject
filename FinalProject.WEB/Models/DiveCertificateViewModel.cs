using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class DiveCertificateViewModel
    {
        public int IdCertificate { get; set; }
        public string CertNumber { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public int CertificateLevelId { get; set; }
        public int DiverId { get; set; }
    }
}
