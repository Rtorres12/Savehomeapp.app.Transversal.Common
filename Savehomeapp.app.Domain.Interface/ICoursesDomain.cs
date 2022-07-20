using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savehomeapp.app.Domain.Entity;
namespace Savehomeapp.app.Domain.Interface
{
    public interface ICoursesDomain
    {
        public int Insert(Courses products);
        public IEnumerable<Courses> GetList();
        public IEnumerable<Courses> GetByIdCategorie(int categorieId);
        public bool Delete(Courses courses);
        public bool Update(Courses courses);





    }
}
