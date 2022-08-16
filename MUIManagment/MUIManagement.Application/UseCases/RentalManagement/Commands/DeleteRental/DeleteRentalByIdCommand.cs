using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.RentalManagement.Commands.DeleteRental
{
    public class DeleteRentalByIdCommand : IRequest
    {
        public long Id { get; }

        public DeleteRentalByIdCommand(long id)
        {
            Id = id;
        }
    }
}