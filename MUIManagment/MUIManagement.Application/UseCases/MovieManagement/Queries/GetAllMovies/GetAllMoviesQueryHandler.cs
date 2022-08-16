using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetAllMovies
{
    public class GetAllMoviesQueryHandler : IRequestHandler<GetAllMoviesQuery, List<MovieModel>>
    {
        private readonly IMovieManagementRepository _repository;

        public GetAllMoviesQueryHandler(IMovieManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<MovieModel>> Handle(GetAllMoviesQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllMovies();
        }
    }
}
