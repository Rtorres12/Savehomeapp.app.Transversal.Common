using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Transversal.Common;
namespace Savehomeapp.app.Application.Interface
{
    public interface ICoursesApplication
    {
        public Response<int> Insert(CoursesDTO course);
        public Response<IEnumerable<CoursesDTO>> GetList();
        public Response<IEnumerable<CoursesDTO>> GetByCategorieId(int categorieId);
        public Response<bool> Delete(CoursesDTO course);
        public Response<bool> Update(CoursesDTO course);




    }
}
