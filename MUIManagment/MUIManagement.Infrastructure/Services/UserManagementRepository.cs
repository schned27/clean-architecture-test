using AutoMapper;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;

namespace MUIManagement.Infrastructure.Services
{
    public class UserManagementRepository : IUserManagementRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserManagementRepository(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<UserManagementModel>> GetAllUsers()
        {
            return await _context.Users.Select(x => 
                _mapper.Map<UserManagementModel>(x))
                .ToListAsync();
        }

        public async Task<UserManagementModel> GetUserById(long id)
        {
            var user = await _context.Users.FindAsync(id);
            return _mapper.Map<UserManagementModel>(user);
        }

        public async Task CreateUser(UserManagementModel user)
        {
            await _context.Users.AddAsync(new UserEntity(user.Id, user.FirstName, user.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditUser(long id, UserManagementModel editUser)
        {
            var user = await _context.Users.FindAsync(id);
            user.FirstName = editUser.FirstName;
            user.LastName = editUser.LastName;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserById(long id)
        {
            _context.Users.Remove(await _context.Users.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
