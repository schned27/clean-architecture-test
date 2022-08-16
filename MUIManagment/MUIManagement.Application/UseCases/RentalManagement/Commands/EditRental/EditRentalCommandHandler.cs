using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.EditRental
{
    public class EditRentalCommandHandler : IRequestHandler<EditRentalCommand>
    {
        private readonly IRentalManagementRepository _repository;

        public EditRentalCommandHandler(IRentalManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditRentalCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditRental(request.Id, request.Rental);

            return Unit.Value;
        }
    }
}
