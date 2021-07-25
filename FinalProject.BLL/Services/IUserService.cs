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
        int GetDiverIdByLogin(string login);
        int GetUserIdByLogin(string login);
        bool CheckLogin(string login, string password);
        bool ChangeDiver(DiverDTO diver);
        /*
        void ChangeUser(UserDTO user);
        void ChangeDiver(DiverDTO diver);
        void ChangeAdmin(AdminDTO admin);
        */
    }
}
