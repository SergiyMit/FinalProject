using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.DTO
{
    public class DiveCertificateDTO
    {
        public int IdCertificate { get; set; }
        public string CertNumber { get; set; }
        public DateTime? DateOfIssuance { get; set; }
        public int CertificateLevelId { get; set; }
        public int DiverId { get; set; }
    }
}
