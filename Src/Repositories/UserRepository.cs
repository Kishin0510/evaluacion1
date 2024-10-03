using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using evaluacion1.Src.Data;
using evaluacion1.Src.Interfaces;
using evaluacion1.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace evaluacion1.Src.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var userToDelete = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ExistByRut(string rut)
        {
            return await _context.Users.AnyAsync(x => x.RUT == rut);
        }

        public async Task<User> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> GetUserDesOrAsc(string sort)
        {
            var users = _context.Users.AsQueryable();
            users = sort == "asc" ? users.OrderBy(u => u.Name) : users.OrderByDescending(u => u.Name);
            return await users.ToListAsync();
        }

        public Task<List<User>> GetUserDesOrAscByGender(string sort, string gender)
        {
            var users = _context.Users.AsQueryable();
            users = users.Where(u => u.Gender == gender);
            if(sort == "asc")
            {
                users = users.OrderBy(u => u.Name);
            } else {
                users = users.OrderByDescending(u => u.Name);
            }
            return users.ToListAsync();
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetUsersByGender(string gender)
        {
            var users = _context.Users.AsQueryable();
            users = users.Where(u => u.Gender == gender);
            return await users.ToListAsync();
        }

        public async Task<bool> UpdateUser(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}