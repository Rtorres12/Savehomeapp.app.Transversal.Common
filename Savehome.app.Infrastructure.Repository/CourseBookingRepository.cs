using Dapper;
using Exphadis.app.Domain.Entity;
using Exphadis.app.Infrastructure.Interface;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Repository
{
    public class CourseBookingRepository:Repository<CourseBooking>,ICourseBookingRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CourseBookingRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public IEnumerable<CourseBooking> GetByIdUser(int iduser)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "GetAllBookingByUser";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@iduser", iduser);

                var user = connection.Query<CourseBooking, User, Courses, CourseBooking>(sql, (booking, user, courses) => {

                    booking.Courses = courses;
                    booking.User = user;
                    return booking;
                }, param: parameters, commandType: System.Data.CommandType.StoredProcedure,splitOn:"Id,IdCourse");
                return user;
            }
        }

        public IEnumerable<CourseBooking> GetAll()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "getAllBookings";
                DynamicParameters parameters = new DynamicParameters();

                var user = connection.Query<CourseBooking, User, Courses, CourseBooking>(sql, (booking, user, courses) => {

                    booking.Courses = courses;
                    booking.User = user;
                    return booking;
                } , commandType: System.Data.CommandType.StoredProcedure, splitOn: "Id,IdCourse");
                return user;
            }
        }
    }
}
