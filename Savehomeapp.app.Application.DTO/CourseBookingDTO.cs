using Savehomeapp.app.Application.DTO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.DTO
{
    public class CourseBookingDTO
    {
        public int IdCourseBooking { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }

     
        public CoursesDTO Courses { get; set; }
      
        public UserDTO User { get; set; }


    }
}
