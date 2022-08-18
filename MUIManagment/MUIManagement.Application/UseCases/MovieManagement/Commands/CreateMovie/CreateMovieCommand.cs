using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest
    {
        public MovieManagementModel Movie { get; }

        public CreateMovieCommand()
        {
            Movie = new MovieManagementModel();
        }
        public CreateMovieCommand(MovieManagementModel movie)
        {
            Movie = movie;
        }
    }
}
