using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.CreateRental
{
    public class CreateRentalCommand : IRequest
    {
        public RentalManagementModel Rental { get; }

        public CreateRentalCommand()
        {
            Rental = new RentalManagementModel();
        }
        public CreateRentalCommand(RentalManagementModel Rental)
        {
            Rental = Rental;
        }
    }
}
