﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.DTO
{
    public class UserAdminDTO
    {
        public int IdUserAdmin { get; set; }
        public string Name { get; set; }
        public string Rol { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
