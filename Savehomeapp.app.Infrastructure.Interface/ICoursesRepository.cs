using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Savehomeapp.app.Domain.Entity;
using System.Threading.Tasks;
namespace Savehomeapp.app.Infrastructure.Interface
{
    public interface ICoursesRepository:IRepository<Courses>
    {
        public IEnumerable<Courses> GetByIdCategorie(int categorieId);

    }
}
