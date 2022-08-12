using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.User.Commands.DeleteUser
{
    public class DeleteUserByIdCommand : IRequest
    {
        public long Id { get; }

        public DeleteUserByIdCommand(long id)
        {
            Id = id;
        }
    }
}