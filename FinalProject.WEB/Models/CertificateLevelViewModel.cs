using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.WEB.Models
{
    public class CertificateLevelViewModel
    {
        public int IdLevel { get; set; }
        public string LevelName { get; set; }
        public int? MaxAllowedDeep { get; set; }
        public int? RequiredDives { get; set; }
        public string AdditionalInfo { get; set; }
        public int DiveCertificateId { get; set; }
    }
}
