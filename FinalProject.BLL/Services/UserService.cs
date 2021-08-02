using FinalProject.BLL.DTO;
using FinalProject.DAL.EF;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;

namespace FinalProject.BLL.Services
{
    public class UserService : IUserService
    {
        private IUserRepository<User> userDatabase { get; set; }
        private IUserRepository<Diver> diverDatabase { get; set; }
        public UserService()
        {
            NixDatabaseContext context = new NixDatabaseContext();
            userDatabase = new UserRepository<User>(context);
            diverDatabase = new UserRepository<Diver>(context);
        }
        public UserDTO GetUser(int id)
        {
            var user = userDatabase.Get(id);
            return new UserDTO { IdUser = user.IdUser, Login = user.Login, Password = user.Password, UserType = user.UserType };
        }
        public DiverDTO GetDiver(int id)
        {
            var diver = diverDatabase.Get(id);
            return new DiverDTO {IdDiver = diver.IdDiver, Age = diver.Age, Name = diver.Name, Surname = diver.Surname, Email = diver.Email, TelNumber = diver.TelNumber, DeviceNumber = diver.DeviceNumber, UserId = diver.IdUser };
        }
        public int GetDiverIdByLogin(string login)
        {
            var diver = diverDatabase.GetDiverByLogin(login);
            int idDiver = diver.IdDiver;
            return idDiver;
        }

        public void AddDiver(DiverDTO diver, UserDTO user)
        {
            var userToAdd = new User {Login = user.Login, Password = user.Password, UserType = 1 };
            userDatabase.Create(userToAdd);
            int userId = userDatabase.GetId(user.Login);
            var diverToAdd = new Diver { Name = diver.Name, Surname = diver.Surname, Email = diver.Email, Age = diver.Age, TelNumber = 1, DeviceNumber = diver.DeviceNumber, IdUser = userId };
            diverDatabase.Create(diverToAdd);
        }
        public bool CheckLogin(string login, string password)
        {
            var user = userDatabase.GetUserByLogin(login);
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        public int GetUserIdByLogin(string login)
        {
            var user = userDatabase.GetUserByLogin(login);
            int idUser = user.IdUser;
            return idUser;
        }

        public bool ChangeDiver(DiverDTO diver)
        {
            try
            {
                int idDiver = diver.IdDiver;
                Diver diver1 =diverDatabase.Get(idDiver);
                if (diver1 == null)
                {
                    return false;
                }
                diver1.Surname = diver.Surname;
                diver1.Name = diver.Name;
                diver1.TelNumber = diver.TelNumber;
                diver1.Email = diver.Email;
                diver1.Age = diver.Age;
                diver1.DeviceNumber = diver.DeviceNumber;
                diverDatabase.Update(diver1);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool ChangeUser(UserDTO user)
        {
            try
            {
                int idUser = user.IdUser;
                User user1 = userDatabase.Get(idUser);
                if (user1 == null)
                {
                    return false;
                }
                user1.Login = user.Login;
                user1.Password = user.Password;
                userDatabase.Update(user1);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
