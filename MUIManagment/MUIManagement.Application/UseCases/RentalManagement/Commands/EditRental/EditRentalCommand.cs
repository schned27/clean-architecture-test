using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.EditRental
{
    public class EditRentalCommand : IRequest
    {
        public RentalManagementModel Rental { get; }
        public long Id { get; }

        public EditRentalCommand()
        {
            Rental = new RentalManagementModel();
        }

        public EditRentalCommand(RentalManagementModel Rental, long id)
        {
            Rental = Rental;
            Id = id;
        }
    }
}