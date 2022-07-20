using Dapper;
using Exphadis.app.Domain.Entity;
using Exphadis.app.Infrastructure.Interface;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Transversal.Common;

namespace Exphadis.app.Infrastructure.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UserRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public User Authenticate(string username, string password)
        {
          using(var connection = _connectionFactory.GetConnection)
            {
                var sql = "ValidateLogin";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@username", username);
                parameters.Add("@password", password);

                var user = connection.QuerySingle<User>(sql,param: parameters, commandType:System.Data.CommandType.StoredProcedure) ;
                return user;
            }
        }
    }
}
