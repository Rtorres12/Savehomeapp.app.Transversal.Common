using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Application.Interface;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;

namespace Savehomeapp.app.Application.Main
{
    public class CoursesApplication :ICoursesApplication
    {
        private readonly ICoursesDomain _courseDomain;
        private readonly IMapper _mapper;
        public CoursesApplication(ICoursesDomain coursesDomain, IMapper mapper )
        {
            _courseDomain = coursesDomain;
            _mapper = mapper;
        }
        public Response<IEnumerable<CoursesDTO>> GetList()
        {
            var response = new Response<IEnumerable<CoursesDTO>>();
            try
            {
                var course = _courseDomain.GetList().ToList();
                var courses = _mapper.Map<IEnumerable<CoursesDTO>>(course);
                response.Data = courses;
                

                if (response.Data !=null)
                {
                    response.IsSuccess = true;
                    response.Message = "Lista exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;

        }

        public Response<int> Insert(CoursesDTO course)
        {
            var response = new Response<int>();
            try
            {
                var courses = _mapper.Map<Courses>(course);

                response.Data = _courseDomain.Insert(courses);
                if (response.Data > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message= e.Message;
            }
            return response;
        }

        public Response<IEnumerable<CoursesDTO>> GetByCategorieId(int categorieId) 
        {
            var response = new Response<IEnumerable<CoursesDTO>>();
            try
            {
                var course = _courseDomain.GetByIdCategorie(categorieId).ToList();
                var courses = _mapper.Map<IEnumerable<CoursesDTO>>(course);
                response.Data = courses;


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Lista exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Delete(CoursesDTO course)
        {
            var response = new Response<bool>();
            try
            {
                var courses = _mapper.Map<Courses>(course);

                var courseres = _courseDomain.Delete(courses);
                response.Data = courseres;


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminado con exito";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Update(CoursesDTO course)
        {
            var response = new Response<bool>();
            try
            {
                var courses = _mapper.Map<Courses>(course);

                var courseres = _courseDomain.Update(courses);
                response.Data = courseres;


                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualizado con exito";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;
        }
    }
}
