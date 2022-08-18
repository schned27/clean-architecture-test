using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie
{
    public class EditMovieCommand : IRequest
    {
        public MovieManagementModel Movie { get; }
        public long Id { get; }

        public EditMovieCommand()
        {
            Movie = new MovieManagementModel();
        }

        public EditMovieCommand(MovieManagementModel movie, long id)
        {
            Movie = movie;
            Id = id;
        }
    }
}
