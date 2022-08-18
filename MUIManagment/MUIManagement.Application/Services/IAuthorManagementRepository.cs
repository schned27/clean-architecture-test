using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IAuthorManagementRepository
    {
        Task<List<AuthorManagementModel>> GetAllAuthors();
        Task<AuthorManagementModel> GetAuthorById(long id);
        Task CreateAuthor(AuthorManagementModel Author);
        Task EditAuthor(long id, AuthorManagementModel Author);
        Task DeleteAuthorById(long id);
    }
}