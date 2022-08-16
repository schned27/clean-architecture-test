using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie
{
    public class EditMovieCommandHandler : IRequestHandler<EditMovieCommand>
    {
        private readonly IMovieManagementRepository _repository;

        public EditMovieCommandHandler(IMovieManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditMovieCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditMovie(request.Id, request.Movie);

            return Unit.Value;
        }
    }
}
