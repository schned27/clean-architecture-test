using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Person.Commands.EditPerson
{
    public class EditPersonCommandHandler : IRequestHandler<EditPersonCommand>
    {
        private readonly IEditPersonRepository _repository;

        public EditPersonCommandHandler(IEditPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditPersonCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditPerson(request.Id, request.Person);

            return Unit.Value;
        }
    }
}
