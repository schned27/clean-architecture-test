using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest
    {
        public MovieModel Movie { get; }

        public CreateMovieCommand()
        {
            Movie = new MovieModel();
        }
        public CreateMovieCommand(MovieModel movie)
        {
            Movie = movie;
        }
    }
}
