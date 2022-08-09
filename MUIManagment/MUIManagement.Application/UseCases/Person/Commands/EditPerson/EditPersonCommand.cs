using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models.EditPersonModel;

namespace MUIManagement.Application.UseCases.Person.Commands.EditPerson
{
    public class EditPersonCommand : IRequest
    {
        public EditPersonModel Person { get; }
        public long Id { get; }

        public EditPersonCommand()
        {
            Person = new EditPersonModel();
        }

        public EditPersonCommand(EditPersonModel person, long id)
        {
            Person = person;
            Id = id;
        }
    }
}