using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.Person.Commands.CreatePerson
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IPersonRepository _repository;

        public CreatePersonCommandHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreatePerson(request.Person);

            return Unit.Value;
        }
    }
}
