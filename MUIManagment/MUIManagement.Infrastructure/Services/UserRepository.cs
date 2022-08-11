using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _context.Users.Select(x => 
                new UserModel(
                    x.Id, 
                    x.FirstName, 
                    x.LastName))
                .ToListAsync();
        }

        public async Task<UserModel> GetUserById(long id)
        {
            return null;
        }

        public async Task CreateUser(UserModel user)
        {
            await _context.Users.AddAsync(new UserEntity(user.Id, user.FirstName, user.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(long id, UserModel user)
        {

        }

        public async Task DeleteUserById(long id)
        {

        }
    }
}
