using Dapper.Contrib.Extensions;
using System;

namespace Savehomeapp.app.Domain.Entity
{
    public class Products
    {
        [Key]
       public int IdProduct {get;set;}
       public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int FlAvailable { get; set; } 
    }
}
