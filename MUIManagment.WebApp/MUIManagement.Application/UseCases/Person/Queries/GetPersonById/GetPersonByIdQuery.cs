using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.Person.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<PersonModel> 
    {
        public long Id { get; }

        public GetPersonByIdQuery() { }

        public GetPersonByIdQuery(long id)
        {
            Id = id;
        }
    }
}
