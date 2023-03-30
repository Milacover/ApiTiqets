using Entities.Entities;

namespace ApiTiqets.IService
{
    public interface IProductService
    {

        void DeleteProductById(int id);
        List<ProductEntity> GetProduct();
        List<ProductEntity> GetAllProducts();
        int InsertProduct(ProductEntity product);
        int PatchProduct(ProductEntity product);
    }
}