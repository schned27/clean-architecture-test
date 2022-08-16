using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.RentalManagement.Queries.GetAllRentals
{
    public class GetAllRentalsQueryHandler : IRequestHandler<GetAllRentalsQuery, List<RentalManagementModel>>
    {
        private readonly IRentalManagementRepository _repository;

        public GetAllRentalsQueryHandler(IRentalManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<List<RentalManagementModel>> Handle(GetAllRentalsQuery request,
           CancellationToken cancellationToken)
        {
            return await _repository.GetAllRentals();
        }
    }
}
