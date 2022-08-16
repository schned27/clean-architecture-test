﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MUIManagement.Application.Services;

namespace MUIManagement.Application.UseCases.MovieManagement.Commands.EditAuthor
{
    public class EditAuthorCommandHandler : IRequestHandler<EditAuthorCommand>
    {
        private readonly IAuthorRepository _repository;

        public EditAuthorCommandHandler(IAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(EditAuthorCommand request, CancellationToken cancellationToken)
        {
            await _repository.EditAuthor(request.Id, request.Author);

            return Unit.Value;
        }
    }
}
