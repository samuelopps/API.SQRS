using CQRS.API.Application.Commands.Handlers.Interfaces;
using CQRS.API.Core.Entities;
using CQRS.API.Core.Notifications;
using CQRS.API.Core.Repositories;
using CQRS.API.Core.Result;
using CQRS.API.Core.Result.Interfaces;

namespace CQRS.API.Application.Commands.Handlers
{
    public class CreateUserHandler : IHandlerBase<CreateUserCommand>
    {
        private readonly IWriteUserRepository _repository;
        public CreateUserHandler(IWriteUserRepository repository)
        {
            _repository = repository;
        }

        public IResultBase Handle(CreateUserCommand command)
        {
            var user = new UserEntity(command.Name, command.Email, command.Document);
            Result result;

            if (user.Validate())
            {
                try
                {
                    _repository.InsertUser(user);
                    result = new Result(200, $"{user.Name.FirstName} inserido com sucesso", true);
                    result.SetData(user);
                }
                catch (Exception ex)
                {
                    result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
                }

                return result;
            }

            result = new Result(400, $"Falha ao inserir {user.Name.FirstName} na base de dados, verifique os campos e tente novamente.", false);
            result.SetNotifications(user.Notifications as List<Notification>);
            
            return result;
        }
    }
}
