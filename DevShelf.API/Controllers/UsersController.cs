using DevShelf.API.Extensions;
using DevShelf.Application.Commands.CreateUser;
using DevShelf.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShelf.API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            return await this.ProcessCommand(command, _mediator);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            return await this.ProcessCommand(command, _mediator);
        }
    }
}
