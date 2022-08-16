using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie
{
    public class EditMovieCommand : IRequest
    {
        public MovieModel Movie { get; }
        public long Id { get; }

        public EditMovieCommand()
        {
            Movie = new MovieModel();
        }

        public EditMovieCommand(MovieModel movie, long id)
        {
            Movie = movie;
            Id = id;
        }
    }
}
