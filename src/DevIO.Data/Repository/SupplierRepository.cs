using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Repository;
public class SupplierRepository : Repository<Supplier>, ISupplierRepository
{
    public SupplierRepository(DevIODbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Supplier> GetSupplierAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Supplier> GetSupplierProductsAddress(Guid id)
    {
        return await Db.Suppliers.AsNoTracking()
            .Include(s => s.Products)
            .Include(s => s.Address)
            .FirstOrDefaultAsync(s => s.Id == id);
    }

    public async Task<Address> GetAddressBySupplier(Guid supplierId)
    {
        return await Db.Addresses.AsNoTracking()
            .FirstOrDefaultAsync(a => a.SupplierId == supplierId);
    }

    public async Task DeleteAddressSupplier(Address address)
    {
        Db.Addresses.Remove(address);
        await SaveChanges();
    }
}
