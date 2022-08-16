using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.RentalManagement.Queries.GetAllRentals
{
    public class GetAllRentalsQuery : IRequest<List<RentalManagementModel>>
    {}
}
