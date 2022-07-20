using System;
using Savehomeapp.app.Transversal.Common;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Interface;
using Dapper;
using Savehomeapp.app.Infrastructure.Repository;
using System.Collections.Generic;

namespace Savehomeapp.app.Infrastructure.Repository
{
    public class CoursesRepository: Repository<Courses>,ICoursesRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CoursesRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }
        public IEnumerable<Courses> GetByIdCategorie(int categorieId)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var sql = "select * from Courses where CategorieId = @categorieId";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@categorieId", categorieId);

                var user = connection.Query<Courses>(sql,parameters);
                return user;
            }
        }


    }
}
