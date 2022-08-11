using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.User.Commands.EditUser
{
    public class EditUserCommand : IRequest
    {
        public UserModel User { get; }
        public long Id { get; }

        public EditUserCommand()
        {
            User = new UserModel();
        }

        public EditUserCommand(UserModel user, long id)
        {
            User = user;
            Id = id;
        }
    }
}