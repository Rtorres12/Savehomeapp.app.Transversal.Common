using System;

namespace Savehomeapp.app.Application.DTO
{
    public class ProductsDTO
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public int FlAvailable { get; set; }
    }
}
