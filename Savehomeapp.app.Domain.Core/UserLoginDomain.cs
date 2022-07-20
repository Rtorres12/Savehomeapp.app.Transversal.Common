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
    public class UserLoginDomain : IUserLoginDomain
    {
        private readonly IUserLoginRepository _userRepository;

        public UserLoginDomain(IUserLoginRepository userLoginRepository)
        {
            _userRepository = userLoginRepository;

        }

        public int Insert(UserLogin login)
        {
            return _userRepository.Insert(login);
        }
    }
}
