using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.AuthorManagement.Commands.EditAuthor
{
    public class EditAuthorCommand : IRequest
    {
        public AuthorManagementModel Author { get; }
        public long Id { get; }

        public EditAuthorCommand()
        {
            Author = new AuthorManagementModel();
        }

        public EditAuthorCommand(AuthorManagementModel author, long id)
        {
            Author = author;
            Id = id;
        }
    }
}
