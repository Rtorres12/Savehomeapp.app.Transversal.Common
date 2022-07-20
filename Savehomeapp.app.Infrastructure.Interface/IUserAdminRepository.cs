using Exphadis.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Interface
{
    public interface IUserAdminRepository:IRepository<UserAdmin>
    {
        public UserAdmin Authenticate(string username, string password);

    }
}
