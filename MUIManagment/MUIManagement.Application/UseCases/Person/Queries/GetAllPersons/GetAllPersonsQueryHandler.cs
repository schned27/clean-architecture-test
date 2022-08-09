using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models.GetAllPersonsModel;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Queries.GetAllPersons
{
    public class GetAllPersonsQueryHandler : IRequestHandler<GetAllPersonsQuery, List<GetAllPersonsModel>>
    {
        private readonly IGetAllPersonsRepository _repository;

        public GetAllPersonsQueryHandler(IGetAllPersonsRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<GetAllPersonsModel>> Handle(GetAllPersonsQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllPersons();
        }
    }
}
