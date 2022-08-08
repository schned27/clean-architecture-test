using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Person.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonModel>
    {
        private readonly IPersonRepository _repository;

        public GetPersonByIdQueryHandler(IPersonRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<PersonModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPersonById(request.Id);
        }
    }
}
