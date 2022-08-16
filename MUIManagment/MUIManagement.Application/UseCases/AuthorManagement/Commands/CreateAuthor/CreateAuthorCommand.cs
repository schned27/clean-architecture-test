using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateAuthor
{
    public class CreateAuthorCommand : IRequest
    {
        public AuthorModel Author { get; }

        public CreateAuthorCommand()
        {
            Author = new AuthorModel();
        }
        public CreateAuthorCommand(AuthorModel author)
        {
            Author = author;
        }
    }
}
