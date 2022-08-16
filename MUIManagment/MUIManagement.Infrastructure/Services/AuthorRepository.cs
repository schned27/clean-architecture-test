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
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public AuthorRepository(ApplicationDbContext context, IMapper mapper)
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
            return _mapper.Map<AuthorModel>(await _context.Authors.FindAsync(id));
        }

        public async Task CreateAuthor(AuthorModel Author)
        {
            await _context.Authors.AddAsync(new AuthorEntity(Author.Id, Author.FirstName, Author.LastName));
            await _context.SaveChangesAsync();
        }

        public async Task EditAuthor(long id, AuthorModel AuthorToEdit)
        {
            var author = await _context.Authors.FindAsync(id);

            author.FirstName = AuthorToEdit.FirstName;
            author.LastName = AuthorToEdit.LastName;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAuthorById(long id)
        {
            _context.Authors.Remove(await _context.Authors.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
