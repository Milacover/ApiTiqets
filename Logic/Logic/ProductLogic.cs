using Data;
using Entities.Entities;
using Logic.Ilogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductLogic : BaseContextLogic, IProductLogic
    {
        public ProductLogic(ServiceContext serviceContext) : base(serviceContext) {  }
        public void DeleteProductById(int Id)
        {
            var chooseProduct = _serviceContext.Set<ProductEntity>().Where(p => p.Id == Id).First();
            _serviceContext.SaveChanges();
        }

        public void InsertProduct(ProductEntity product)
        {
            _serviceContext.Products.Add(product);
            _serviceContext.SaveChanges();
        }

        public void PatchProduct(ProductEntity product)
        {
            _serviceContext.Products.Update(product);
            _serviceContext.SaveChanges();
        }

        public List<ProductEntity> GetProduct()
        {
            return _serviceContext.Set<ProductEntity>().ToList();

        }
        public List<ProductEntity> GetAllProducts()
        {
            return _serviceContext.Set<ProductEntity>().ToList();

        }
    }
}

