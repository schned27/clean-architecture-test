﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.DeleteMovieById
{
    public class DeleteAuthorByIdCommandHandler : IRequestHandler<DeleteAuthorByIdCommand>
    {
        private readonly IMovieRepository _repository;

        public DeleteAuthorByIdCommandHandler(IMovieRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteAuthorByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteMovieById(request.Id);

            return Unit.Value;
        }
    }
}
