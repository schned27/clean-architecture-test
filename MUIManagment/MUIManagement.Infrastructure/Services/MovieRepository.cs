using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using MUIManagement.Infrastructure.Database;
using MUIManagement.Infrastructure.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Infrastructure.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovieRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<MovieModel>> GetAllMovies()
        {
            return await _context.Movies.Select(x =>
                new MovieModel(
                    x.Id,
                    x.Title,
                    x.Description,
                    x.ReleaseDate,
                    x.AuthorId
                    ))
                .ToListAsync();
        }

        public async Task<MovieModel> GetMovieById(long id)
        {
            return _mapper.Map<MovieModel>(await _context.Movies.FindAsync(id));
        }
        

        public async Task CreateMovie(MovieModel movie)
        {
            await _context.Movies.AddAsync(new MovieEntity(movie.Id, movie.Title, movie.Description, movie.ReleaseDate, movie.AuthorId));
            await _context.SaveChangesAsync();
        }

        public async Task EditMovie(long id, MovieModel MovieToEdit)
        {
            var movie = await _context.Movies.FindAsync(id);

            movie.Title = MovieToEdit.Title;
            movie.Description = MovieToEdit.Description;
            movie.ReleaseDate = MovieToEdit.ReleaseDate;
            movie.AuthorId = MovieToEdit.AuthorId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieById(long id)
        {
            _context.Movies.Remove(await _context.Movies.FindAsync(id));
            await _context.SaveChangesAsync();
        }
    }
}
