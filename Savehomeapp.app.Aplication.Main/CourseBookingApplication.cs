using AutoMapper;
using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Domain.Entity;
using Exphadis.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Main
{
    public class CourseBookingApplication : ICourseBookingApplication
    {
        private readonly ICourseBookingDomain _courseBookingDomain;
        private readonly IMapper _mapper;
        public CourseBookingApplication(IMapper mapper, ICourseBookingDomain courseBookingApplication)
        {
            _mapper = mapper;
            _courseBookingDomain = courseBookingApplication;
        }
        public Response<IEnumerable<CourseBookingDTO>> GetByIdUser(int iduser)
        {
            var response = new Response<IEnumerable<CourseBookingDTO>>();
            try
            {
                var course = _courseBookingDomain.GetByIdUser(iduser).ToList();
                var courses = _mapper.Map<IEnumerable<CourseBookingDTO>>(course);

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
        public Response<IEnumerable<CourseBookingDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CourseBookingDTO>>();
            try
            {
                var course = _courseBookingDomain.GetAll().ToList();
                var courses = _mapper.Map<IEnumerable<CourseBookingDTO>>(course);

                response.Data = courses;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Listado exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;

        }

        public Response<int> Insert(CourseBookingDTO courseBookingDTO)
        {
            var response = new Response<int>();
            try
            {
                var courseBooking = _mapper.Map<CourseBooking>(courseBookingDTO);
                response.Data = _courseBookingDomain.Insert(courseBooking);

                if (response.Data > 0)
                {
                    response.IsSuccess = true;
                    response.Message = "Inserccion Exitosa";
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

