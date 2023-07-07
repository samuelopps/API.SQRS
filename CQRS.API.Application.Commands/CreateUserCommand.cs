using CQRS.API.Application.Commands.Interfaces;
using CQRS.API.Core.ValueObjects;

namespace CQRS.API.Application.Commands
{
    public class CreateUserCommand : ICommand
    {
        public Name Name { get; set; }
        public Document Document { get; set; }
        public string Email { get; set; }
    }
}