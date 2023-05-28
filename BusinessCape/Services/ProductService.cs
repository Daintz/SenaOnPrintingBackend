using DataCape.Models;
using PersistenceCape.Interfaces;

namespace BusinessCape.Services
{
    public class ProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync();
        }

        public async Task<ProductModel> GetByIdAsync(long id)
        {
            return await _productRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(ProductModel product)
        {
            await _productRepository.AddAsync(product);
        }

        public async Task UpdateAsync(ProductModel product)
        {
            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(long id)
        {
            await _productRepository.DeleteAsync(id);
        }
    }
}
