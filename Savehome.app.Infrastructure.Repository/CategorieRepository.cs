using Exphadis.app.Domain.Entity;
using Exphadis.app.Infrastructure.Interface;
using Savehomeapp.app.Infrastructure.Repository;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Infrastructure.Repository
{
    public class CategorieRepository:Repository<Categorie>, ICategorieRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CategorieRepository(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

    }
}
