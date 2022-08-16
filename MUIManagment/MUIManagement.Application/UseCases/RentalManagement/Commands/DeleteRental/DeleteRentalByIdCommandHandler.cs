using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.DeleteRental
{
    public class DeleteRentalByIdCommandHandler : IRequestHandler<DeleteRentalByIdCommand>
    {
        private readonly IRentalManagementRepository _repository;

        public DeleteRentalByIdCommandHandler(IRentalManagementRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteRentalByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteRentalById(request.Id);

            return Unit.Value;
        }
    }
}
