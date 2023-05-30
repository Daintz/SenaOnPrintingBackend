using DataCape.Models;

namespace PersistenceCape.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllAsync();
        Task<ProductModel> GetByIdAsync(long id);
        Task<ProductModel> AddAsync(ProductModel supplyCategory);
        Task UpdateAsync(ProductModel supplyCategory);
        Task DeleteAsync(long id);
    }
}
