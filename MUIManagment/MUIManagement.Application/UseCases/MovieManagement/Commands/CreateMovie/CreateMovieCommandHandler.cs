using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly IMovieManagementRepository _repository;

        public CreateMovieCommandHandler(IMovieManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateMovie(request.Movie);

            return Unit.Value;
        }
    }
}
