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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<AuthorModel>> GetAllAuthors()
        {
            return await _context.Authors.Select(x => 
                new AuthorModel(
                    x.Id, 
                    x.FirstName, 
                    x.LastName))
                .ToListAsync();
        }

        public async Task<AuthorModel> GetAuthorById(long id)
        {
            return null;
        }

        public async Task CreateAuthor(AuthorModel Author)
        {
            await _context.Authors.AddAsync(new AuthorEntity(Author.Id, Author.FirstName, Author.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthor(long id, AuthorModel Author)
        {

        }

        public async Task DeleteAuthorById(long id)
        {

        }
    }
}
