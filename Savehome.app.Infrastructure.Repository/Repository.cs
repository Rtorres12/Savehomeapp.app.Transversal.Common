using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Savehomeapp.app.Infrastructure.Interface;
using Savehomeapp.app.Transversal.Common;

namespace Savehomeapp.app.Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IConnectionFactory _connectionFactory;


        public Repository(IConnectionFactory connectionFactory)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"[{type.Name}]"; };
            _connectionFactory = connectionFactory;
        }
        public virtual bool Delete(T entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return connection.Delete(entity);
            }
        }


        public virtual T GetById(Int64 id)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return connection.Get<T>((Int64)id);
            }
        }


        public virtual IEnumerable<T> GetList()
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return connection.GetAll<T>();
            }
        }


        public virtual int Insert(T entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return (int)connection.Insert(entity);
            }
        }




        public virtual bool Update(T entity)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                return connection.Update(entity);
            }
        }





    }
}

