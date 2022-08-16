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
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<MovieModel>>
    {
        private readonly IMovieRepository _repository;

        public GetAllAuthorsQueryHandler(IMovieRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<MovieModel>> Handle(GetAllAuthorsQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllMovies();
        }
    }
}
