using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Transversal.Common;
namespace Savehomeapp.app.Application.Interface
{
    public interface IProductsApplication
    {
        public Response<int> Insert(ProductsDTO products);
        public Response<IEnumerable<ProductsDTO>> GetList();


    }
}
