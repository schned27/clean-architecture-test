using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.UserManagement.Commands.EditUser
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand>
    {
        private readonly IUserManagementRepository _repository;

        public EditUserCommandHandler(IUserManagementRepository repository)
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
