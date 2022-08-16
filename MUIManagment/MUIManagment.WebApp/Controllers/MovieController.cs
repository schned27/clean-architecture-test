﻿using System.Collections.Generic;
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


namespace MUIManagement.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MovieController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator _mediator)
        {
            this._mediator = _mediator;
        }

        [HttpGet]
        public async Task<List<MovieModel>> GetAllMovies()
        {
            var response = await _mediator.Send(new GetAllAuthorsQuery());

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<MovieModel> GetMovieById(long id)
        {
            var response = await _mediator.Send(new GetMovieByIdQuery(id));

            return response;
        }

        [HttpPost]
        public async Task CreateMovie(MovieModel Movie)
        {
            await _mediator.Send(new CreateMovieCommand(Movie));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task EditMovie(MovieModel movie, long id)
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
