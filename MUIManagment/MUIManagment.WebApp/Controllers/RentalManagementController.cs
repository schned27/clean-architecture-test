using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.RentalManagement.Commands.CreateRental;
using MUIManagement.Application.UseCases.RentalManagement.Commands.DeleteRental;
using MUIManagement.Application.UseCases.RentalManagement.Commands.EditRental;
using MUIManagement.Application.UseCases.RentalManagement.Queries.GetRentalById;
using MUIManagement.Application.UseCases.RentalManagement.Queries.GetAllRentals;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RentalManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalManagementController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<RentalManagementModel>> GetAllRentals()
        {
            return await _mediator.Send(new GetAllRentalsQuery());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<RentalManagementModel> GetRentalById(long id)
        {
            return await _mediator.Send(new GetRentalByIdQuery(id));
        }

        [HttpPost]
        public async Task CreateRental(RentalManagementModel Rental)
        {
            await _mediator.Send(new CreateRentalCommand(Rental));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task EditRental(RentalManagementModel Rental, long id)
        {
            await _mediator.Send(new EditRentalCommand(Rental, id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteRental(long id)
        {
            await _mediator.Send(new DeleteRentalByIdCommand(id));
        }
    }
}
