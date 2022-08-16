﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MUIManagement.Application.Domain.Models;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie
{
    public class CreateAuthorCommand : IRequest
    {
        public MovieModel Movie { get; }

        public CreateAuthorCommand()
        {
            Movie = new MovieModel();
        }
        public CreateAuthorCommand(MovieModel movie)
        {
            Movie = movie;
        }
    }
}
