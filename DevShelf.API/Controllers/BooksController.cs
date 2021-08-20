using DevShelf.API.Extensions;
using DevShelf.Application.Commands.CreateBook;
using DevShelf.Infrastructure.Queries.GetAllBooks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevShelf.API.Controllers
{
    [Route("api/books")]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var query = new GetAllBooksQuery();

            return await this.ProcessCommand(query, _mediator);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            return await this.ProcessCommand(command, _mediator);
        }
    }
}
