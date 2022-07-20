using Exphadis.app.Application.DTO;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Interface
{
    public interface ICourseBookingApplication
    {
        public Response<IEnumerable<CourseBookingDTO>> GetByIdUser(int iduser);
        public Response<int> Insert(CourseBookingDTO courseBookingDTO);
        public Response<IEnumerable<CourseBookingDTO>> GetAll();

    }
}
