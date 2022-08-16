using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.AuthorManagement.Commands.DeleteAuthorById
{
    public class DeleteAuthorByIdCommand : IRequest
    {
        public long Id { get; }

        public DeleteAuthorByIdCommand(long id)
        {

            Id = id;
        }
    }
}
