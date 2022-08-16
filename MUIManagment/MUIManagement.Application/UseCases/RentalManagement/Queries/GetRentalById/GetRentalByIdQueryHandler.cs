using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.RentalManagement.Queries.GetRentalById
{
    public class GetRentalByIdQueryHandler : IRequestHandler<GetRentalByIdQuery, RentalManagementModel>
    {
        private readonly IRentalManagementRepository _repository;

        public GetRentalByIdQueryHandler(IRentalManagementRepository _repository)
        {
            this._repository = _repository;
        }

        public async Task<RentalManagementModel> Handle(GetRentalByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRentalById(request.Id);
        }
    }
}
