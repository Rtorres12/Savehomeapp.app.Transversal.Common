using Dapper;
using Exphadis.app.Domain.Entity;
using Exphadis.app.Infrastructure.Interface;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Repository
{
    public class UserAdminRepository:Repository<UserAdmin>,IUserAdminRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserAdminRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public UserAdmin Authenticate(string username, string password)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "ValidateAdminLogin";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@username", username);
                parameters.Add("@password", password);

                var user = connection.QuerySingle<UserAdmin>(sql, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                return user;
            }
        }
    }
}
