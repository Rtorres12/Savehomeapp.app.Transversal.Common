using AutoMapper;
using Exphadis.app.Application.DTO;
using Exphadis.app.Application.Interface;
using Exphadis.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exphadis.app.Application.Main
{
    public class CategorieApplication:ICategorieApplication
    {
        private readonly ICategorieDomain _categorieDomain;
        private readonly IMapper _mapper;
        public CategorieApplication(ICategorieDomain categorieDomain, IMapper mapper)
        {
            _categorieDomain = categorieDomain;
            _mapper = mapper;
        }
        public Response<IEnumerable<CategorieDTO>> GetList()
        {
            var response = new Response<IEnumerable<CategorieDTO>>();
            try
            {
                var course = _categorieDomain.GetList().ToList();
                var courses = _mapper.Map<IEnumerable<CategorieDTO>>(course);

                response.Data = courses;
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Lista exitosa";
                }
            }
            catch (Exception e)
            {

                response.Message = e.Message;
            }
            return response;

        }
    }
}
