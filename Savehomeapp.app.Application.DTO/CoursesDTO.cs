using System;

namespace Savehomeapp.app.Application.DTO
{
    public class CoursesDTO
    {
        public int IdCourse { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int FlAvailable { get; set; }
        public int CategorieId { get; set; }
        public DateTime DateStart { get; set; }
        public string Description { get; set; }
        public string Categorie { get; set; }
    }
}
