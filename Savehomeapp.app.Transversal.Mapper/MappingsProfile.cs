using System;
using AutoMapper;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Domain.Entity;

namespace Savehomeapp.app.Transversal.Mapper
{
    public class MappingsProfile:Profile
    {
        public MappingsProfile()
        {
            CreateMap<Products, ProductsDTO>().ReverseMap();
        }
    }
}
