using Dapper;
using DevShelf.Domain.Repositories;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevShelf.Infrastructure.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksQuery, List<GetAllBooksViewModel>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public Task<List<GetAllBooksViewModel>> Handle(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var books = _bookRepository.GetAllBooks();

            var getAllBooksViews = books.Select(b => new GetAllBooksViewModel()
            {
                Id = b.Id,
                Title = b.Title.Value,
                Description = b.Description.Value,
                Author = b.Author.Name
            }).ToList();

            return Task.FromResult(getAllBooksViews);
        }
    }
}
