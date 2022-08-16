using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorModel>
    {
        private readonly IAuthorRepository _repository;

        public GetAuthorByIdQueryHandler(IAuthorRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<AuthorModel> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAuthorById(request.Id);
        }
    }
}