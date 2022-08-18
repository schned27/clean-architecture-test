using MediatR;
using MUIManagement.Application.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MUIManagement.Application.UseCases.MovieManagement.Queries.GetAllMovies
{
    public class GetAllMoviesQuery : IRequest<List<MovieManagementModel>>
    { }
}

