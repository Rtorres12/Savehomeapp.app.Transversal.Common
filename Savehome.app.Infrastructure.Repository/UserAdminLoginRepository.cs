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
    public class UserAdminLoginRepository:Repository<UserAdminLogin> ,IUserAdminLoginRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public UserAdminLoginRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
    }
}
