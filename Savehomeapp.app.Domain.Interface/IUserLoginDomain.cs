using Exphadis.app.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Interface
{
    public interface IUserLoginDomain
    {
        public int Insert(UserLogin login);

    }
}
