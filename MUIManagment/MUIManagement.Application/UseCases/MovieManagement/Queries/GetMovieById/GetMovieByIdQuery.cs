using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetMovieById
{
    public class GetMovieByIdQuery : IRequest<MovieModel>
    {
        public long Id { get; }

        public GetMovieByIdQuery() { }

        public GetMovieByIdQuery(long id)
        {
            Id = id;
        }

    }
}