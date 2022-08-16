﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.CreateMovie
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
    {
        private readonly IMovieRepository _repository;

        public CreateAuthorCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateMovie(request.Movie);

            return Unit.Value;
        }
    }
}
