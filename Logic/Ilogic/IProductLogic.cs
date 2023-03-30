using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Ilogic
{
    public interface IProductLogic
    {
        void DeleteProductById(int Id);
        List<ProductEntity> GetProduct();
        List<ProductEntity> GetAllProducts();
        void InsertProduct(ProductEntity product);
        void PatchProduct(ProductEntity product);
    }
}

