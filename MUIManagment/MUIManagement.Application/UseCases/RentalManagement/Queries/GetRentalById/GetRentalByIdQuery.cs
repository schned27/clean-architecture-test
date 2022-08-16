using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.RentalManagement.Queries.GetRentalById
{
    public class GetRentalByIdQuery : IRequest<RentalManagementModel> 
    {
        public long Id { get; }

        public GetRentalByIdQuery() { }

        public GetRentalByIdQuery(long id)
        {
            Id = id;
        }
    }
}
