using VShop.ProductApi.Models;

namespace VShop.ProductApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Create(Product Product);
        Task<Product> Update(Product Product);
        Task<Product> Delete(int id);
    }
}
