using FinalProject.BLL.DTO;
using FinalProject.DAL.Entities;
using FinalProject.DAL.Interfaces;
using FinalProject.DAL.Repositories;

namespace FinalProject.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService()
        {
            Database = new EFUnitOfWork("connection");
        }
        public void Dispose()
        {
            Database.Dispose();
        }
        public UserDTO GetUser(int id)
        {
            var user = Database.Users.Get(id);
            return new UserDTO { IdUser = user.IdUser, Login = user.Login, Password = user.Password, UserType = user.UserType };
        }
        public AdminDTO GetAdmin(int id)
        {
            var admin = Database.Admins.Get(id);
            return new AdminDTO { IdAdmin = admin.IdAdmin, Name = admin.Name, Surname = admin.Surname, PersonalAccessCode = admin.PersonalAccessCode, UserId = admin.IdUser };
        }

        public DiverDTO GetDiver(int id)
        {
            var diver = Database.Divers.Get(id);
            return new DiverDTO {IdDiver = diver.IdDiver, Age = diver.Age, Name = diver.Name, Surname = diver.Surname, Email = diver.Email, TelNumber = diver.TelNumber, DeviceNumber = diver.DeviceNumber, UserId = diver.IdUser };
        }
        public int GetDiverIdByLogin(string login)
        {
            var diver = Database.Divers.GetByLogin(login);
            int idDiver = diver.IdDiver;
            return idDiver;
        }

        public void AddDiver(DiverDTO diver, UserDTO user)
        {
            var userToAdd = new User {Login = user.Login, Password = user.Password, UserType = 1 };
            Database.Users.Create(userToAdd);
            int userId = Database.Users.GetId(user.Login).IdUser;
            var diverToAdd = new Diver { Name = diver.Name, Surname = diver.Surname, Email = diver.Email, Age = diver.Age, TelNumber = 1, DeviceNumber = diver.DeviceNumber, IdUser = userId };
            Database.Divers.Create(diverToAdd);
        }
        public bool CheckLogin(string login, string password)
        {
            var user = Database.Users.GetId(login);
            if (user.Password == password)
            {
                return true;
            }
            return false;
        }

        public int GetUserIdByLogin(string login)
        {
            var user = Database.Users.GetByLogin(login);
            int idUser = user.IdUser;
            return idUser;
        }

        public bool ChangeDiver(DiverDTO diver)
        {
            try
            {
                int idDiver = diver.IdDiver;
                Diver diver1 = Database.Divers.Get(idDiver);
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
                Database.Divers.Update(diver1);
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
                User user1 = Database.Users.Get(idUser);
                if (user1 == null)
                {
                    return false;
                }
                user1.Login = user.Login;
                user1.Password = user.Password;
                Database.Users.Update(user1);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
