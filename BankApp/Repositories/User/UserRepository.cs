using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.MVVM
{
    public interface IUserRepository
    {
        Task<IList<UserData>> GetUsers();
    }

    internal class UserRepository : IUserRepository
    {
        private readonly IList<UserData> _users;

        public UserRepository()
        {
            _users = new List<UserData>()
            {
                new UserData(Guid.NewGuid(), "Artur", "Valdna", 25),
                new UserData(Guid.NewGuid(), "Pavel", "Korolko", 34),
            };
        }
        public async Task<IList<UserData>> GetUsers()
        {
            return await Task.FromResult(_users);
        }
    }

    public class UserData
    {
        public Guid Id { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public int Age { get; init; }

        public UserData(Guid id, string firstName, string lastName, int age)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
    }
}
