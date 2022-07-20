using Exphadis.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Interface
{
    public interface ICourseBookingRepository:IRepository<CourseBooking>
    {
        public IEnumerable<CourseBooking> GetByIdUser(int categorieId);
        public IEnumerable<CourseBooking> GetAll();


    }
}
