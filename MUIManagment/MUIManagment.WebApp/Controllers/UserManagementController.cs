using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.User.Commands.CreateUser;
using MUIManagement.Application.UseCases.Queries.GetAllUsers;
using MUIManagement.Application.UseCases.User.Commands.DeleteUser;
using MUIManagement.Application.UseCases.User.Commands.EditUser;
using MUIManagement.Application.UseCases.User.Queries.GetUserById;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserManagementController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<UserManagementModel>> GetAllUsers()
        {
            return await _mediator.Send(new GetAllUsersQuery());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<UserManagementModel> GetUserById(long id)
        {
            return await _mediator.Send(new GetUserByIdQuery(id));
        }

        [HttpPost]
        public async Task CreateUser(UserManagementModel user)
        {
            await _mediator.Send(new CreateUserCommand(user));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task EditUser(UserManagementModel user, long id)
        {
            await _mediator.Send(new EditUserCommand(user, id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteUser(long id)
        {
            await _mediator.Send(new DeleteUserByIdCommand(id));
        }
    }
}
