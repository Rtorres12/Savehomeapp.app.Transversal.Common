using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Entity
{
    public class Categorie
    {
        [Key]
        public int IdCategorie { get; set; }
        public string Name { get; set; }
    }
}
