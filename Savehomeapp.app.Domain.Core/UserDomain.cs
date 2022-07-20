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
    public class UserDomain:IUserDomain
    {
        private readonly IUserRepository _userRepository;
        public UserDomain(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string username, string password)
        {
            return _userRepository.Authenticate(username, password);
        }

        public int Insert(User user)
        {
            return _userRepository.Insert(user);
        }
    }
}
