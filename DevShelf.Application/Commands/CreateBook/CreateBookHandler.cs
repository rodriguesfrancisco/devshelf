using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand>
    {
        public Task<Unit> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
