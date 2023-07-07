using CQRS.API.Core.Entities;

namespace CQRS.API.Core.Repositories
{
    public interface IReadUserRepository
    {
        Task<IEnumerable<UserEntity>> GetAll();
        Task<UserEntity> GetById(int id);
    }
}
