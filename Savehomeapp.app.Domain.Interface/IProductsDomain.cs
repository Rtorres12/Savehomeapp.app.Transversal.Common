using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Savehomeapp.app.Domain.Entity;
namespace Savehomeapp.app.Domain.Interface
{
    public interface IProductsDomain
    {
        public int Insert(Products products);
        public IEnumerable<Products> GetList();


    }
}
