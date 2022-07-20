using Exphadis.app.Domain.Entity;
using Exphadis.app.Domain.Interface;
using Exphadis.app.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Domain.Core
{
    public class CategorieDomain:ICategorieDomain
    {
        private readonly ICategorieRepository _categorieRepository;
        public CategorieDomain(ICategorieRepository categorieRepository)
        {
            _categorieRepository = categorieRepository;
        }
        public IEnumerable<Categorie> GetList()
        {
            return _categorieRepository.GetList();
        }
    }
}
