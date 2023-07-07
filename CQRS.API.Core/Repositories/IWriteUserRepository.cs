using CQRS.API.Core.Entities;

namespace CQRS.API.Core.Repositories
{
    public interface IWriteUserRepository
    {
        void InsertUser(UserEntity user);
    }
}
