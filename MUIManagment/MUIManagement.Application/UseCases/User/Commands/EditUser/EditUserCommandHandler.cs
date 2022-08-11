using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.User.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUserRepository _repository;

        public EditUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditUser(request.Id, request.User);

            return Unit.Value;
        }
    }
}
