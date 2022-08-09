using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.Queries.GetAllPersons
{
    public class GetAllPersonsQuery : IRequest<List<PersonModel>>
    {}
}
