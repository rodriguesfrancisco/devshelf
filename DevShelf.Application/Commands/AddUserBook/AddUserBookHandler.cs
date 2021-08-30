using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Application.Commands.AddUserBook
{
    public class AddUserBookHandler : IRequestHandler<AddUserBookCommand>
    {
        public Task<Unit> Handle(AddUserBookCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
