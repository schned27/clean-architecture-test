using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IMovieManagementRepository
    {
        Task<List<MovieModel>> GetAllMovies();
        Task<MovieModel> GetMovieById(long id);
        Task CreateMovie(MovieModel Movie);
        Task EditMovie(long id, MovieModel Movie);
        Task DeleteMovieById(long id);
    }
}
