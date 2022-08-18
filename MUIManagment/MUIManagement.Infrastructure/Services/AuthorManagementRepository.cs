using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;
using AutoMapper;

namespace MUIManagement.Infrastructure.Services
{
    public class AuthorManagementRepository : IAuthorManagementRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorManagementRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<AuthorManagementModel>> GetAllAuthors()
        {
            return await _context.Authors.Select(x => 
                new AuthorManagementModel(
                    x.Id, 
                    x.FirstName, 
                    x.LastName))
                .ToListAsync();
        }

        public async Task<AuthorManagementModel> GetAuthorById(long id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }
            return _mapper.Map<AuthorManagementModel>(author);
        }

        public async Task CreateAuthor(AuthorManagementModel Author)
        {
            await _context.Authors.AddAsync(new AuthorEntity(Author.Id, Author.FirstName, Author.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthor(long id, AuthorManagementModel AuthorToEdit)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }

            author.FirstName = AuthorToEdit.FirstName;
            author.LastName = AuthorToEdit.LastName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorById(long id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
