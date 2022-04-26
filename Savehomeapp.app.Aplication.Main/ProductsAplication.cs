using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Savehomeapp.app.Application.DTO;
using Savehomeapp.app.Application.Interface;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Domain.Interface;
using Savehomeapp.app.Transversal.Common;

namespace Savehomeapp.app.Application.Main
{
    public class ProductsAplication :IProductsApplication
    {
        private readonly IProductsDomain _productsDomain;
        private readonly IMapper _mapper;
        public ProductsAplication(IProductsDomain productsDomain, IMapper mapper )
        {
            _productsDomain = productsDomain;
            _mapper = mapper;
        }
        public Response<IEnumerable<ProductsDTO>> GetList()
        {
            var response = new Response<IEnumerable<ProductsDTO>>();
            try
            {
                var product = _productsDomain.GetList().ToList();
                var products = _mapper.Map<IEnumerable<ProductsDTO>>(product);

                response.Data = products;
                if (response.Data !=null)
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

        public Response<int> Insert(ProductsDTO products)
        {
            var response = new Response<int>();
            try
            {
                var product = _mapper.Map<Products>(products);
                response.Data = _productsDomain.Insert(product);
                if (response.Data==1)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro exitoso";
                }
            }
            catch (Exception e)
            {

                response.Message= e.Message;
            }
            return response;
        }
    }
}
