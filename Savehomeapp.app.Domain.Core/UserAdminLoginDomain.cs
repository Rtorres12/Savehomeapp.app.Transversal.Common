using Exphadis.app.Domain.Interface;
using Exphadis.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Core
{
    public class UserAdminLoginDomain:IUserAdminLoginDomain
    {
        private readonly IUserAdminLoginRepository _userRepository;

        public UserAdminLoginDomain(IUserAdminLoginRepository userLoginRepository)
        {
            _userRepository = userLoginRepository;

        }
    }
}
