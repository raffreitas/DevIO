using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;

public class SupplierService : BaseService, ISupplierService
{
    private readonly ISupplierRepository _supplierRepository;

    public SupplierService(ISupplierRepository supplierRepository)
    {
        _supplierRepository = supplierRepository;
    }

    public async Task Add(Supplier supplier)
    {
        bool supplierIsValid = ExecuteValidation(new SupplierValidation(), supplier);
        bool addressIsValid = ExecuteValidation(new AddressValidation(), supplier.Address);

        if (!supplierIsValid || !addressIsValid)
            return;

        if (_supplierRepository.Get(f => f.Document == supplier.Document).Result.Any())
        {
            Notify("Já existe um fornecedor com este documento informado.");
            return;
        }

        await _supplierRepository.Add(supplier);
    }

    public async Task Update(Supplier supplier)
    {
        if (!ExecuteValidation(new SupplierValidation(), supplier))
            return;

        if (_supplierRepository.Get(f => f.Document == supplier.Document && f.Id != supplier.Id).Result.Any())
        {
            Notify("Já existe um fornecedor com este documento informado.");
            return;
        }

        await _supplierRepository.Update(supplier);
    }
    public async Task Delete(Guid id)
    {
        var supplier = await _supplierRepository.GetSupplierProductsAddress(id);

        if (supplier == null)
        {
            Notify("Fornecedor não existe!");
            return;
        }

        if (supplier.Products.Any())
        {
            Notify("O Fornecedor possui produtos cadastrados!");
            return;
        }

        var address = await _supplierRepository.GetAddressBySupplier(id);

        if (address != null)
        {
            await _supplierRepository.DeleteAddressSupplier(address);
        }

        await _supplierRepository.Delete(id);
    }

    public void Dispose()
    {
        _supplierRepository?.Dispose();
    }
}
