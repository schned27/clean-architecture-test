using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetMovieById
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, MovieModel>
    {
        private readonly IMovieManagementRepository _repository;

        public GetMovieByIdQueryHandler(IMovieManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<MovieModel> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMovieById(request.Id);
        }
    }
}