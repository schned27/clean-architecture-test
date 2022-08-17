using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.AuthorManagement.Commands.CreateAuthor
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IAuthorManagementRepository _repository;

        public CreateAuthorCommandHandler(IAuthorManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAuthor(request.Author);

            return Unit.Value;
        }
    }
}
