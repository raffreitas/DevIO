using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;
public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(DevIODbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<Product>> GetProductsBySupplier(Guid supplierId)
    {
        return await Get(p => p.SupplierId == supplierId);
    }

    public async Task<IEnumerable<Product>> GetProductsSuppliers()
    {
        return await Db.Products.AsNoTracking()
            .Include(p => p.Supplier)
            .OrderBy(p => p.Name)
            .ToListAsync();
    }

    public async Task<Product> GetProductSupplier(Guid id)
    {
        return await Db.Products.AsNoTracking()
            .Include(p => p.Supplier)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}
