using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluacion1.Src.Interfaces;
using evaluacion1.Src.Models;

namespace evaluacion1.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> CreateUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistByRut(string rut)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}