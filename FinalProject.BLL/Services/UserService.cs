using FinalProject.BLL.DTO;
using FinalProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.BLL.Services
{
    class UserService : IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork uow)
        {
            Database = uow;
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
    }
}
