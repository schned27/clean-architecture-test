using MediatR;
using Microsoft.AspNetCore.Mvc;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.AuthorManagement.Commands.CreateAuthor;
using MUIManagement.Application.UseCases.AuthorManagement.Commands.DeleteAuthorById;
using MUIManagement.Application.UseCases.AuthorManagement.Commands.EditAuthor;
using MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAllAuthors;
using MUIManagement.Application.UseCases.AuthorManagement.Queries.GetAuthorById;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AuthorManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorManagementController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<AuthorManagementModel>> GetAllAuthors()
        {
            return await _mediator.Send(new GetAllAuthorsQuery());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<AuthorManagementModel> GetAuthorById(long id)
        {
            return await _mediator.Send(new GetAuthorByIdQuery(id));
        }

        [HttpPost]
        public async Task CreateAuthor(AuthorManagementModel author)
        {
            await _mediator.Send(new CreateAuthorCommand(author));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task EditAuthor(long id, AuthorManagementModel author)
        {
            await _mediator.Send(new EditAuthorCommand(author, id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteAuthorById(long id)
        {
            await _mediator.Send(new DeleteAuthorByIdCommand(id));
        }
    }
}
