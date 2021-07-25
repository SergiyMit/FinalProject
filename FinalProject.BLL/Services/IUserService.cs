using FinalProject.BLL.DTO;

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
