using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.DeleteMovieById
{
    public class DeleteMovieByIdCommandHandler : IRequestHandler<DeleteMovieByIdCommand>
    {
        private readonly IMovieManagementRepository _repository;

        public DeleteMovieByIdCommandHandler(IMovieManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMovieByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteMovieById(request.Id);

            return Unit.Value;
        }
    }
}
