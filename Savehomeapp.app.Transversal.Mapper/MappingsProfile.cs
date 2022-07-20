using System;
using AutoMapper;
using Exphadis.app.Application.DTO;
using Exphadis.app.Domain.Entity;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Domain.Entity;

namespace Savehomeapp.app.Transversal.Mapper
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<Courses, CoursesDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Categorie, CategorieDTO>().ReverseMap();
            CreateMap<CourseBooking, CourseBookingDTO>().ReverseMap();
            CreateMap<UserAdmin, UserAdminDTO>().ReverseMap();




        }
    }
}
