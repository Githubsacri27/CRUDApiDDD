using System.Collections.Generic;
using System.Threading.Tasks;
using TestVH.Infrastructure.Contracts.Entities;

namespace TestVH.Infrastructure.Contracts
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<bool> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
}
