using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IUserRepository
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(long id);
        Task CreateUser(UserModel user);
        Task EditUser(long id, UserModel user);
        Task DeleteUserById(long id);
    }
}