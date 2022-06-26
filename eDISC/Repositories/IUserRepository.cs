using eDISC.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace eDISC.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByEmail(string email);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
    }
}
