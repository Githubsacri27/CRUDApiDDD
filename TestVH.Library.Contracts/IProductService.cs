
namespace TestVH.Library.Contracts.DTOs;

public interface IProductService
{
    Task<IEnumerable<ProductDTO>> GetAllAsync();
    Task<ProductDTO> GetByIdAsync(int id);
    Task<ProductDTO> CreateAsync(ProductDTO productDto);
    Task<bool> UpdateAsync(int id, ProductDTO productDto);
    Task<bool> DeleteAsync(int id);
}
