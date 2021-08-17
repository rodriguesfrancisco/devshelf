using DevShelf.API.Extensions;
using DevShelf.Application.Commands.CreateBook;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DevShelf.API.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public Task<IActionResult> CreateBook([FromBody] CreateBookCommand command)
        {
            return this.ProcessCommand(command, _mediator);
        }
    }
}
