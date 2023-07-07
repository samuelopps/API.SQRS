using CQRS.API.Core.Entities;
using CQRS.API.Infrastructure.Shared.Shared;

namespace CQRS.API.Infrastructure.Input.Queries
{
    public class UserQueries : BaseQuery
    {
        public QueryModel InsertUserQuery(UserEntity user)
        {
            this.Table = Map.GetUserTable();
            this.Query = $@"
            INSERT INTO {this.Table}
            VALUES
            (
                @Name,
                @Email,
                @Document,
            )
            ";

            this.Parameters = new
            {
                Name = user.Name,
                Email = user.Email,
                Document = user.Document,
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
