using MediatR;
using MUIManagement.Application.Domain.Models.GetPersonByIdModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.Person.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<GetPersonByIdModel> 
    {
        public long Id { get; }

        public GetPersonByIdQuery() { }

        public GetPersonByIdQuery(long id)
        {
            Id = id;
        }
    }
}
