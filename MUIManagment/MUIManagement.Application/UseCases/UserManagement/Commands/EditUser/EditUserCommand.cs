using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.User.Commands.EditUser
{
    public class EditUserCommand : IRequest
    {
        public UserManagementModel User { get; }
        public long Id { get; }

        public EditUserCommand()
        {
            User = new UserManagementModel();
        }

        public EditUserCommand(UserManagementModel user, long id)
        {
            User = user;
            Id = id;
        }
    }
}