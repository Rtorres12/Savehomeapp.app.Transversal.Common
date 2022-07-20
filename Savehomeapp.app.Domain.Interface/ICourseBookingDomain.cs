using Exphadis.app.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Interface
{
    public interface ICourseBookingDomain
    {
        public IEnumerable<CourseBooking> GetByIdUser(int iduser);
        public IEnumerable<CourseBooking> GetAll();

        public int Insert(CourseBooking course);

    }
}
