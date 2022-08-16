using MediatR;
using Microsoft.AspNetCore.Mvc;
using MUIManagement.Application.Domain.Models;
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

        //[HttpGet]
        //public async Task<List<AuthorModel>> GetAllAuthors()
        //{

        //}
    }
}
