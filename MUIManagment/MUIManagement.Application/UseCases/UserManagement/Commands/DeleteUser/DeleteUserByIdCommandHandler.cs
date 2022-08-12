using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.User.Commands.DeleteUser
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IUserManagementRepository _repository;

        public DeleteUserByIdCommandHandler(IUserManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserById(request.Id);

            return Unit.Value;
        }
    }
}
