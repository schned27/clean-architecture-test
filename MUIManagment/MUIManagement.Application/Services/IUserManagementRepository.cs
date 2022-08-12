using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IUserManagementRepository
    {
        Task<List<UserManagementModel>> GetAllUsers();
        Task<UserManagementModel> GetUserById(long id);
        Task CreateUser(UserManagementModel user);
        Task EditUser(long id, UserManagementModel user);
        Task DeleteUserById(long id);
    }
}