using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorManagementModel>>
    {
        private readonly IAuthorRepository _repository;

        public GetAllAuthorsQueryHandler(IAuthorRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<AuthorManagementModel>> Handle(GetAllAuthorsQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllAuthors();
        }
    }
}
