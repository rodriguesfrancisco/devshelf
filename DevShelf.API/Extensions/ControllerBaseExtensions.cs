using DevShelf.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevShelf.API.Extensions
{
    public static class ControllerBaseExtensions
    {
        public static async Task<IActionResult> ProcessCommand<T>(this ControllerBase controller, Command<T> command, IMediator mediator)
        {
            command.Validate();
            if(!command.IsValid)
            {
                return controller.BadRequest(command.Notifications);
            } else
            {
                var result = await mediator.Send(command);
                if(!command.IsValid)
                {
                    return controller.BadRequest(command.Notifications);
                }

                return controller.Ok(result);
            }
        }
    }
}
