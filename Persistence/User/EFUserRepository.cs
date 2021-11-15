using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Services.User.Contract;
using Services.User.Contract.Dtos;

namespace Persistence.User
{
    public class EFUserRepository : UserRepository
    {
        private string _connectionString;

        public EFUserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private IDbConnection Connection => new SqlConnection(_connectionString);
        
        public async Task<IEnumerable<GetUserDto>> GetAll()
        {
            using var connection = Connection;
            connection.Open();
            return await connection.QueryAsync<GetUserDto>(@"SELECT * FROM Users", commandType: CommandType.Text);
        }
    }
}