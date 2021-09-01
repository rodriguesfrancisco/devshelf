using DevShelf.API.Extensions;
using DevShelf.Application.Commands.AddUserBook;
using DevShelf.Application.Commands.CreateUser;
using DevShelf.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShelf.API.Controllers
{
    [Route("api/users")]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            return await this.ProcessCommand(command, _mediator);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            return await this.ProcessCommand(command, _mediator);
        }

        [HttpPost("add-book")]
        public async Task<IActionResult> AddUserBook([FromBody] AddUserBookCommand command)
        {
            var userEmail = User.Identity.UserEmail();
            command.UserEmail = userEmail;

            return await this.ProcessCommand(command, _mediator);
        }
    }
}
