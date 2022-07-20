using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname {get; set; }
        public string Document { get; set; }    
        public string Email { get; set; }   
        public int LoginId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }       
}
}
