using CQRS.API.Core.Entities;
using CQRS.API.Core.Repositories;
using CQRS.API.Infrastructure.Input.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CQRS.API.Infrastructure.Input.Repositories
{
    public class WriteUserRepository : IWriteUserRepository
    {
        private readonly IConfiguration _configuration;

        public WriteUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void InsertUser(UserEntity user)
        {
            var query = new UserQueries().InsertUserQuery(user);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                connection.Execute(query.Query, query.Parameters);
            }
        }
    }
}