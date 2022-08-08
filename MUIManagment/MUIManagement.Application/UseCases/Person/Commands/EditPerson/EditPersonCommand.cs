using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.Person.Commands.EditPerson
{
    public class EditPersonCommand : IRequest
    {
        public PersonModel Person { get; }
        public long Id { get; }

        public EditPersonCommand()
        {
            Person = new PersonModel();
        }

        public EditPersonCommand(PersonModel person, long id)
        {
            Person = person;
            Id = id;
        }
    }
}