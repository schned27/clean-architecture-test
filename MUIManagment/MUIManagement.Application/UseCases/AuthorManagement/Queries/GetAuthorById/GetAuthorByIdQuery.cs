using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAuthorById
{
    public class GetAuthorByIdQuery : IRequest<AuthorModel>
    {
        public long Id { get; }

        public GetAuthorByIdQuery() { }

        public GetAuthorByIdQuery(long id)
        {
            Id = id;
        }

    }
}