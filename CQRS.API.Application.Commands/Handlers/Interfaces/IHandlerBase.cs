using CQRS.API.Application.Commands.Interfaces;
using CQRS.API.Core.Result.Interfaces;

namespace CQRS.API.Application.Commands.Handlers.Interfaces
{
    public interface IHandlerBase<in T>
    where T : ICommand
    {
        IResultBase Handle(T command);
    }
}
