using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Infrastructure.Services
{
    public class MovieRepository : IMovieRepository
    {
        public async Task<List<MovieModel>> GetAllMovies()
        {
            return null;
        }

        public async Task<MovieModel> GetMovieById(long id)
        {
            return null;
        }

        public async Task CreateMovie(MovieModel Movie)
        {

        }

        public async Task EditMovie(long id, MovieModel Movie)
        {

        }

        public async Task DeleteMovieById(long id)
        {

        }
    }
}
