using System;
using Xunit;
using FinalProject.BLL.Services;
using FinalProject.BLL.DTO;

namespace FinalProject.Test
{
    public class Test
    {
        readonly OxygenService oxygenService = new OxygenService();
        readonly UserService userService = new UserService();
        [Theory]
        [InlineData(15, 25, 145, 57)]
        [InlineData(45, 50, 130, 101)]
        [InlineData(25, 35, 120, 70)]
        [InlineData(75, 15, 115, 82)]
        public void GetOxygenTest(int time, int deep, int tank, double expected)
        {
            double result = oxygenService.GetOxygen(time, deep, tank);
            Assert.Equal(expected,result);
        }
        [Theory]
        [InlineData(80, 125, 25, 133)]
        [InlineData(63, 120, 55, 50)]
        [InlineData(89, 145, 75, 64)]
        [InlineData(120, 130, 15, 312)]
        public void GetAllowedTimeTest(int oxygen, int tank, int deep, double expected)
        {
            double result = oxygenService.GetAllowedTime(oxygen, tank, deep);
            Assert.Equal(expected, result);
        }
        [Fact]
        public void GetUserTest()
        {
            int i = 1002;
            UserDTO expected = new UserDTO { IdUser = 1002, Login = "TestLogin2", Password = "123456", UserType = 1 };
            var result = userService.GetUser(i);
            Assert.True(expected.IdUser == result.IdUser && expected.Login == result.Login && expected.Password == result.Password && expected.UserType == result.UserType);
        }
        [Fact]
        public void GetDiverTest()
        {
            int i = 1002;
            DiverDTO expected = new DiverDTO { Name = "TestName2", Surname = "TestSurname2", Age = 19, Email = "test2@email.com", DeviceNumber = 2, IdDiver = 1002, UserId = 1002, TelNumber = 1 };
            var result = userService.GetDiver(i);
            Assert.True(expected.Name == result.Name && expected.Surname == result.Surname && expected.Age == result.Age && expected.Email == result.Email
                && expected.DeviceNumber == result.DeviceNumber && expected.TelNumber == result.TelNumber && expected.UserId == result.UserId);
        }

    }
}
