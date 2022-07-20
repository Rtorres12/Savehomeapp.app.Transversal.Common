using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Entity
{
    public class UserAdmin
    {
        [Key]
        public int IdUserAdmin { get; set; }
        public string Name { get; set; }    
        public string Rol { get; set; }
        public int LoginId { get; set; }

    }
}
