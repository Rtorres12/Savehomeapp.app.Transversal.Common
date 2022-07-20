using Exphadis.app.Domain.Entity;
using Exphadis.app.Domain.Interface;
using Exphadis.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Core
{
    public class CourseBookingDomain:ICourseBookingDomain
    {
        private readonly ICourseBookingRepository _courseBookingRepository;
        public CourseBookingDomain(ICourseBookingRepository courseBookingRepository)
        {
            _courseBookingRepository = courseBookingRepository;
        }
        public IEnumerable<CourseBooking> GetByIdUser(int iduser)
        {
            return _courseBookingRepository.GetByIdUser(iduser);
        }
        public IEnumerable<CourseBooking> GetAll()
        {
            return _courseBookingRepository.GetAll();
        }
        public int Insert(CourseBooking course)
        {
            return _courseBookingRepository.Insert(course);
        }
    }
}
