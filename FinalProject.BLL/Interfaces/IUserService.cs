using FinalProject.BLL.DTO;

namespace FinalProject.BLL.Services
{
    public interface IUserService
    {
        UserDTO GetUser(int id);
        DiverDTO GetDiver(int id);
        void AddDiver(DiverDTO diver, UserDTO user);
        int GetDiverIdByLogin(string login);
        int GetUserIdByLogin(string login);
        bool CheckLogin(string login, string password);
        bool ChangeDiver(DiverDTO diver);
        bool ChangeUser(UserDTO user);
    }
}
