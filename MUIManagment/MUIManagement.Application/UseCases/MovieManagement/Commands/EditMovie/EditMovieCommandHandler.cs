﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditMovie
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand>
    {
        private readonly IMovieRepository _repository;

        public EditAuthorCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditMovie(request.Id, request.Movie);

            return Unit.Value;
        }
    }
}
