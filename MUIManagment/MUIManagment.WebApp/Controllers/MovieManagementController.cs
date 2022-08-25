using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MUIManagement.Application.Domain.Models;
using MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie;
using MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie;
using MUIManagement.Application.UseCases.MovieManagement.Commands.DeleteMovieById;
using MUIManagement.Application.UseCases.MovieManagement.Queries.GetAllMovies;
using MUIManagement.Application.UseCases.MovieManagement.Queries.GetMovieById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class MovieManagementController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieManagementController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<MovieManagementModel>> GetAllMovies()
        {
            var response = await _mediator.Send(new GetAllMoviesQuery());

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MovieManagementModel> GetMovieById(long id)
        {
            var response = await _mediator.Send(new GetMovieByIdQuery(id));

            return response;
        }

        [HttpPost]
        public async Task CreateMovie(MovieManagementModel Movie)
        {
            await _mediator.Send(new CreateMovieCommand(Movie));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task EditMovie(MovieManagementModel movie, long id)
        {
            await _mediator.Send(new EditMovieCommand(movie, id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task DeleteMovie(long id)
        {
            await _mediator.Send(new DeleteMovieByIdCommand(id));
        }
    }
}
