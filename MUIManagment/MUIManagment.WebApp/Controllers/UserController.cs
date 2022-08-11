using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.User.Commands.CreateUser;
using MUIManagement.Application.UseCases.Queries.GetAllUsers;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<UserModel>> GetAllUsers()
        {
            var response = await _mediator.Send(new GetAllUsersQuery());

            return response;
        }

        [HttpPost]
        public async Task CreateUser(UserModel user)
        {
            await _mediator.Send(new CreateUserCommand(user));
        }
    }
}
