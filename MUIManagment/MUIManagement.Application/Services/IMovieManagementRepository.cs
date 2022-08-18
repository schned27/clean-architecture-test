using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MUIManagement.Application.Services
{
    public interface IMovieManagementRepository
    {
        Task<List<MovieManagementModel>> GetAllMovies();
        Task<MovieManagementModel> GetMovieById(long id);
        Task CreateMovie(MovieManagementModel Movie);
        Task EditMovie(long id, MovieManagementModel Movie);
        Task DeleteMovieById(long id);
    }
}
