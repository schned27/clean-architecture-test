using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.Person.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest
    {
        public PersonModel Person { get; }

        public CreatePersonCommand()
        {
            Person = new PersonModel();
        }
        public CreatePersonCommand(PersonModel person)
        {
            Person = person;
        }
    }
}
