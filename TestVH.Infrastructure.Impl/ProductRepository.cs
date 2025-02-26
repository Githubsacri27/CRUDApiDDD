using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestVH.Infrastructure.Contracts;
using TestVH.Infrastructure.Contracts.Entities;
using TestVH.Infrastructure.Impl.Data;

namespace TestVH.Infrastructure.Impl
{
    public class ProductRepository : IProductRepository
    {
        private readonly Test_130225Context _context;

        public ProductRepository(Test_130225Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.id == id);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            var existingProduct = await _context.Products.FindAsync(product.id);
            if (existingProduct == null)
                return false;

            existingProduct.name = product.name;
            existingProduct.price = product.price;
            existingProduct.categoryId = product.categoryId;

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
}
