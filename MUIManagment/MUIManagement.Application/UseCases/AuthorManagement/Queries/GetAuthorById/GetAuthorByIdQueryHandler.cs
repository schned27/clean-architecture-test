using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorManagementModel>
    {
        private readonly IAuthorManagementRepository _repository;

        public GetAuthorByIdQueryHandler(IAuthorManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<AuthorManagementModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAuthorById(request.Id);
        }
    }
}