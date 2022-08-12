using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.User.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserManagementModel>
    {
        private readonly IUserManagementRepository _repository;

        public GetUserByIdQueryHandler(IUserManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<UserManagementModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserById(request.Id);
        }
    }
}
