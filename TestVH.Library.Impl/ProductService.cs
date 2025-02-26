using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestVH.Infrastructure.Contracts.Entities;
using TestVH.Infrastructure.Impl.Data;
using TestVH.Library.Contracts.DTOs;

public class ProductService : IProductService
{
    private readonly Test_130225Context _context;
    private readonly IMapper _mapper;

    public ProductService(Test_130225Context context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDTO>> GetAllAsync()
    {
        var products = await _context.Products.AsNoTracking().ToListAsync();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public async Task<ProductDTO> GetByIdAsync(int id)
    {
        var product = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.id == id);
        return _mapper.Map<ProductDTO>(product);
    }

    public async Task<ProductDTO> CreateAsync(ProductDTO productDto)
    {
        // Verificar si la categoría existe antes de insertar el producto
        bool categoryExists = await _context.Categories.AnyAsync(c => c.id == productDto.CategoryId);

        if (!categoryExists)
        {
            throw new Exception($"La categoría con ID {productDto.CategoryId} no existe. No se puede insertar el producto.");
        }

        var productEntity = _mapper.Map<Product>(productDto);
        _context.Products.Add(productEntity);
        await _context.SaveChangesAsync();

        return _mapper.Map<ProductDTO>(productEntity);
    }



    public async Task<bool> UpdateAsync(int id, ProductDTO productDto)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null) return false;

        _mapper.Map(productDto, product);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product == null)
            return false;

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();
        return true;
    }

}
