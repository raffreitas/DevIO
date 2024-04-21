using DevIO.Business.Models;

namespace DevIO.Business.Interfaces;

public interface ISupplierRepository : IRepository<Supplier>
{
    Task<Supplier> GetSupplierAddress(Guid id);
    Task<Supplier> GetSupplierProductsAddress(Guid id);

    Task<Address> GetAddressBySupplier(Guid supplerId);
    Task DeleteAddressSupplier(Address address);
}
