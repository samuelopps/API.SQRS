using CQRS.API.Application.Queries.Interfaces;
using CQRS.API.Core.Repositories;
using CQRS.API.Core.Result;

namespace CQRS.API.Application.Queries.Handlers
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, Result>
    {
        private readonly IReadUserRepository _repository;

        public GetUserByIdHandler(IReadUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> HandleAsync(GetUserByIdQuery query)
        {
            Result result;
            try
            {
                var user = await _repository.GetById(query.UserId);
                result = new Result(200, "Sucesso", true);
                result.SetData(user);
            }
            catch (Exception ex)
            {
                result = new Result(500, $"Falha interna do servidor, detalhes: {ex.Message}", false);
            }

            return result;
        }
    }
}
