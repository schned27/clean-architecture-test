﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie
{
    public class EditAuthorCommand : IRequest
    {
        public MovieModel Movie { get; }
        public long Id { get; }

        public EditAuthorCommand()
        {
            Movie = new MovieModel();
        }

        public EditAuthorCommand(MovieModel movie, long id)
        {
            Movie = movie;
            Id = id;
        }
    }
}
