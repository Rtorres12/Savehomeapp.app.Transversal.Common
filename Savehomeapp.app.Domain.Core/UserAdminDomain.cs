using Exphadis.app.Domain.Entity;
using Exphadis.app.Domain.Interface;
using Exphadis.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Core
{
    public class UserAdminDomain:IUserAdminDomain
    {
        private readonly IUserAdminRepository _userAdminRepository;
        public UserAdminDomain(IUserAdminRepository userAdminRepository)
        {
            _userAdminRepository = userAdminRepository;
        }
    
        public UserAdmin Authenticate(string username, string password)
        {
            return _userAdminRepository.Authenticate(username, password);
        }
    }
}
