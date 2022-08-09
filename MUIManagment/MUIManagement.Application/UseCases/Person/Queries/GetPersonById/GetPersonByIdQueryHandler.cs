using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models.GetPersonByIdModel;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Person.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, GetPersonByIdModel>
    {
        private readonly IGetPersonByIdRepository _repository;

        public GetPersonByIdQueryHandler(IGetPersonByIdRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<GetPersonByIdModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPersonById(request.Id);
        }
    }
}
