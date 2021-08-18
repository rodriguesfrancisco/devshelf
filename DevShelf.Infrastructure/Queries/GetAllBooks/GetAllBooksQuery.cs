using DevShelf.Application.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Queries.GetAllBooks
{
    public class GetAllBooksQuery : Command<List<GetAllBooksViewModel>>
    {
        public override void Validate()
        {
            
        }
    }
}
