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
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }
            return _mapper.Map<AuthorModel>(author);
        }

        public async Task CreateAuthor(AuthorModel Author)
        {
            await _context.Authors.AddAsync(new AuthorEntity(Author.Id, Author.FirstName, Author.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthor(long id, AuthorModel AuthorToEdit)
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
