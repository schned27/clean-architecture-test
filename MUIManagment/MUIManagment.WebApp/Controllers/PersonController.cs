using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.Person.Commands.CreatePerson;
using MUIManagement.Application.UseCases.Queries.GetAllPersons;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<PersonModel>> GetAllPersons()
        {
            var response = await _mediator.Send(new GetAllPersonsQuery());

            return response;
        }

        [HttpPost]
        public async Task CreatePerson(PersonModel person)
        {
            await _mediator.Send(new CreatePersonCommand(person));
        }
    }
}
