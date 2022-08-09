using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models.CreatePersonModel;

namespace MUIManagement.Application.UseCases.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest
    {
        public CreatePersonModel Person { get; }

        public CreatePersonCommand()
        {
            Person = new CreatePersonModel();
        }
        public CreatePersonCommand(CreatePersonModel person)
        {
            Person = person;
        }
    }
}
