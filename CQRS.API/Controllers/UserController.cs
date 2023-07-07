using CQRS.API.Application.Commands;
using CQRS.API.Application.Commands.Handlers;
using CQRS.API.Application.Queries;
using CQRS.API.Application.Queries.Handlers;
using CQRS.API.Core.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public Result Post([FromServices] CreateUserHandler handler, CreateUserCommand command)
        {
            return (Result)handler.Handle(command);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<Result> GetById([FromServices] GetUserByIdHandler handler, GetUserByIdQuery command)
        {
            return await handler.HandleAsync(command);
        }
    }
}
