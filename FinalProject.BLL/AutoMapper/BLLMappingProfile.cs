using AutoMapper;
using FinalProject.BLL.DTO;
using FinalProject.DAL.Entities;

namespace FinalProject.BLL.AutoMapper
{
    public class BLLMappingProfile: Profile
    {
        public BLLMappingProfile()
        {
            CreateMap<User, UserDTO > ();
            CreateMap<Diver, DiverDTO>();
            CreateMap<Admin, AdminDTO>();
            CreateMap<CertificateLevel, CertificateLevelDTO>();
            CreateMap<DiveCertificate, DiveCertificateDTO>();
            CreateMap<DiveMeasurement, DiveMeasurementDTO>();

        }
    }
}
