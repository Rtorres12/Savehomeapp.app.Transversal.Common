using System;
using Savehomeapp.app.Domain.Entity;
using Savehomeapp.app.Domain.Core;
using Savehomeapp.app.Infrastructure.Interface;
using Savehomeapp.app.Domain.Interface;
using System.Collections.Generic;

namespace Savehomeapp.app.Domain.Core
{
    public class ProductsDomain:IProductsDomain
    {
        private readonly IProductsRepository _productRepository;
        public ProductsDomain(IProductsRepository productsRepository)
        {
            _productRepository = productsRepository;
        }
        public int Insert(Products products)
        {
            return _productRepository.Insert(products);
        }
        public bool Update(Products products)
        {
            return _productRepository.Update(products);
        }
        public IEnumerable<Products> GetList()
        {
        return _productRepository.GetList();
        }
    }
}
