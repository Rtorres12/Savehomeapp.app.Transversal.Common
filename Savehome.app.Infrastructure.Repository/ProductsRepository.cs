using System;
using Savehomeapp.app.Transversal.Common;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Infrastructure.Interface;
using Dapper;
using Savehomeapp.app.Infrastructure.Repository;
namespace Savehomeapp.app.Infrastructure.Repository
{
    public class ProductsRepository: Repository<Products>,IProductsRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ProductsRepository(IConnectionFactory connectionFactory) : base(connectionFactory.GetConnection.ConnectionString)
        {

        }


    }
}
