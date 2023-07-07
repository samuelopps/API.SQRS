using CQRS.API.Core.Entities;
using CQRS.API.Core.Repositories;
using CQRS.API.Infrastructure.Output.Queries;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CQRS.API.Infrastructure.Output.Repositories
{
    public class ReadUserRepository : IReadUserRepository
    {
        private readonly IConfiguration _configuration;

        public ReadUserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            var query = new UserQueries().GetAll();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<IEnumerable<UserEntity>>(query.Query, query.Parameters);
            }
        }

        public async Task<UserEntity> GetById(int id)
        {
            var query = new UserQueries().GetById(id);

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                connection.Open();
                return await connection.QueryFirstOrDefaultAsync<UserEntity>(query.Query, query.Parameters);
            }
        }        
    }
}
