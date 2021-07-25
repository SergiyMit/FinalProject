using FinalProject.BLL.DTO;
using FinalProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        DiverDTO GetDiver(int id);
        AdminDTO GetAdmin(int id);
        void AddDiver(DiverDTO diver, UserDTO user);
        void Dispose();
        /*
        void ChangeUser(UserDTO user);
        void ChangeDiver(DiverDTO diver);
        void ChangeAdmin(AdminDTO admin);
        */
    }
}
