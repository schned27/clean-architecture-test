using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<List<AuthorManagementModel>>
    { }
}

