using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IAuthorManagementRepository
    {
        Task<List<AuthorModel>> GetAllAuthors();
        Task<AuthorModel> GetAuthorById(long id);
        Task CreateAuthor(AuthorModel Author);
        Task EditAuthor(long id, AuthorModel Author);
        Task DeleteAuthorById(long id);
    }
}