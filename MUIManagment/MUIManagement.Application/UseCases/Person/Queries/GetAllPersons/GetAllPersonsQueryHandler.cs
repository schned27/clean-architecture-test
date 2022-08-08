using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<PersonModel>>
    {
        private readonly IPersonRepository _repository;

        public GetAllPersonsQueryHandler(IPersonRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<PersonModel>> Handle(GetAllPersonsQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllPersons();
        }
    }
}
