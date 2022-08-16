using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.CreateRental
{
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand>
    {
        private readonly IRentalManagementRepository _repository;

        public CreateRentalCommandHandler(IRentalManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateRental(request.Rental);

            return Unit.Value;
        }
    }
}
