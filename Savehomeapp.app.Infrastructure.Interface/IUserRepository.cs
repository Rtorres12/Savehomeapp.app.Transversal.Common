using Exphadis.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Interface
{
    public interface IUserRepository:IRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
