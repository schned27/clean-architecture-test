using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.User.Queries.GetUserById
{
    public class GetUserByIdQuery : IRequest<UserManagementModel> 
    {
        public long Id { get; }

        public GetUserByIdQuery() { }

        public GetUserByIdQuery(long id)
        {
            Id = id;
        }
    }
}
