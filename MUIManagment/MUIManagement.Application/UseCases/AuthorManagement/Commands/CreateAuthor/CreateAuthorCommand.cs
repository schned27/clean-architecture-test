using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.AuthorManagement.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest
    {
        public AuthorManagementModel Author { get; }

        public CreateAuthorCommand()
        {
            Author = new AuthorManagementModel();
        }
        public CreateAuthorCommand(AuthorManagementModel author)
        {
            Author = author;
        }
    }
}
