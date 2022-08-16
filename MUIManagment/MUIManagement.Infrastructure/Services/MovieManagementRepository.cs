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
    public class MovieManagementRepository : IMovieManagementRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MovieManagementRepository(ApplicationDbContext context, IMapper mapper)
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
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }
            return _mapper.Map<MovieModel>(movie);
        }
        

        public async Task CreateMovie(MovieModel movie)
        {
            await _context.Movies.AddAsync(new MovieEntity(movie.Id, movie.Title, movie.Description, movie.ReleaseDate, movie.AuthorId));
            await _context.SaveChangesAsync();
        }

        public async Task EditMovie(long id, MovieModel MovieToEdit)
        {
            var movie = await _context.Movies.FindAsync(id);

            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }

            movie.Title = MovieToEdit.Title;
            movie.Description = MovieToEdit.Description;
            movie.ReleaseDate = MovieToEdit.ReleaseDate;
            movie.AuthorId = MovieToEdit.AuthorId;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovieById(long id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with id = {id} does not exist.");
            }
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
