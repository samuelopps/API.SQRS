using CQRS.API.Infrastructure.Shared.Shared;

namespace CQRS.API.Infrastructure.Output.Queries
{
    public class UserQueries : BaseQuery
    {
        public QueryModel GetAll()
        {
            this.Table = Map.GetUserTable();

            this.Query = $@"
            SELECT 
            V.[ID],
            V.[NAME],
            V.[EMAIL],
            V.[DOCUMENT],
            V.[DATECREATED]
            FROM {this.Table} AS V
            ";

            return new QueryModel(this.Query, null);
        }

        public QueryModel GetById(int id)
        {
            this.Table = Map.GetUserTable();

            this.Query = $@"
            SELECT 
            V.[ID],
            V.[NAME],
            V.[EMAIL],
            V.[DOCUMENT],
            V.[DATECREATED]
            FROM {this.Table}
            WHERE 
            V.ID = @id
            ";
            this.Parameters = new
            {
                id
            };

            return new QueryModel(this.Query, this.Parameters);
        }
    }
}
