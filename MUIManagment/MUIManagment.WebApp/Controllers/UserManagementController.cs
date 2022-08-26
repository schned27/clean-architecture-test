using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.UserManagement.Commands.CreateUser;
using MUIManagement.Application.UseCases.UserManagement.Commands.DeleteUser;
using MUIManagement.Application.UseCases.UserManagement.Commands.EditUser;
using MUIManagement.Application.UseCases.UserManagement.Queries.GetAllUsers;
using MUIManagement.Application.UseCases.UserManagement.Queries.GetUserById;
using MUIManagement.WebApp.Middleware;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            if (user.Id != id)
            {
                throw new AppException("IDs don't match.");
            }
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
