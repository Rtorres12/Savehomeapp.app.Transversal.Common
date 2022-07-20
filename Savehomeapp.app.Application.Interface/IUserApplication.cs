using Exphadis.app.Application.DTO;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Interface
{
    public interface IUserApplication
    {
        public Response<int> Insert(UserDTO user);
        public Response<UserDTO> Autheticate(string username, string password);

    }
}
