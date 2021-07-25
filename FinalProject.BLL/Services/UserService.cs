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

        public void AddDiver(DiverDTO diver, UserDTO user)
        {
            var userToAdd = new User {Login = user.Login, Password = user.Password, UserType = 1 };
            Database.Users.Create(userToAdd);
            int userId = Database.Users.GetId(user.Login).IdUser;
            var diverToAdd = new Diver { Name = diver.Name, Surname = diver.Surname, Email = diver.Email, Age = diver.Age, TelNumber = 1, DeviceNumber = diver.DeviceNumber, IdUser = userId };
            Database.Divers.Create(diverToAdd);
        }
    }
}
