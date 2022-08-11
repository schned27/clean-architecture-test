using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserModel>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<UserModel>> Handle(GetAllUsersQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllUsers();
        }
    }
}
