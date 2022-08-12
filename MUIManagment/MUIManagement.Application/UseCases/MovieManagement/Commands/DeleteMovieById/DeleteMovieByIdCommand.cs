using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.DeleteMovieById
{
    public class DeleteMovieByIdCommand : IRequest
    {
        public long Id { get; }

        public DeleteMovieByIdCommand(long id)
        {

            Id = id;
        }
    }
}
