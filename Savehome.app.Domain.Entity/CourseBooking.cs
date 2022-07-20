using Dapper.Contrib.Extensions;
using Savehomeapp.app.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Entity
{
    public class CourseBooking
    {
        [Key]
        public int IdCourseBooking { get; set; }    
        public int UserId { get; set; } 
        public int CourseId { get; set; }

        [Write(false)]
        [Computed]
        public Courses Courses { get; set; }
           [Write(false)]
        [Computed]
        public User User { get; set; }
    }
}
