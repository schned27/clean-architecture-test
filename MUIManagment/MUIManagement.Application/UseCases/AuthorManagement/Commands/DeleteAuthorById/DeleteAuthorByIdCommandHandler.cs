using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.AuthorManagement.Commands.DeleteAuthorById
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand>
    {
        private readonly IAuthorRepository _repository;

        public DeleteAuthorByIdCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAuthorById(request.Id);

            return Unit.Value;
        }
    }
}
