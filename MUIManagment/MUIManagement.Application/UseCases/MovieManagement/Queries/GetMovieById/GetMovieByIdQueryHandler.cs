using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetMovieById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, MovieModel>
    {
        private readonly IMovieRepository _repository;

        public GetAuthorByIdQueryHandler(IMovieRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<MovieModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMovieById(request.Id);
        }
    }
}