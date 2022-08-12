using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public UserManagementModel User { get; }

        public CreateUserCommand()
        {
            User = new UserManagementModel();
        }
        public CreateUserCommand(UserManagementModel user)
        {
            User = user;
        }
    }
}
