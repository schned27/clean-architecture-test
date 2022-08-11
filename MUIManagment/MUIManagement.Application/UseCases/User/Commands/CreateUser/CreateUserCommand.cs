using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public UserModel User { get; }

        public CreateUserCommand()
        {
            User = new UserModel();
        }
        public CreateUserCommand(UserModel user)
        {
            User = user;
        }
    }
}
