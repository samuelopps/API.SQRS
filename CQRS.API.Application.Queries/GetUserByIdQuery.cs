using CQRS.API.Application.Queries.Interfaces;
using CQRS.API.Core.Result;

namespace CQRS.API.Application.Queries
{
    public class GetUserByIdQuery : IQuery<Result>
    {
        public GetUserByIdQuery(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; }
    }
}