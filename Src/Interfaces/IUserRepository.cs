using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluacion1.Src.Models;

namespace evaluacion1.Src.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(int id, User user);
        Task<User> DeleteUser(int id);   
        Task<bool> ExistByRut(string rut);
    }
}