﻿using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetMovieById
{
    public class GetAuthorByIdQuery : IRequest<MovieModel>
    {
        public long Id { get; }

        public GetAuthorByIdQuery() { }

        public GetAuthorByIdQuery(long id)
        {
            Id = id;
        }

    }
}