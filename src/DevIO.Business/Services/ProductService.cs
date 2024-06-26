﻿using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;

namespace DevIO.Business.Services;
public class ProductService : BaseService, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository,
                          INotifier notifier) : base(notifier)
    {
        _productRepository = productRepository;
    }

    public async Task Add(Product product)
    {
        if (!ExecuteValidation(new ProductValidation(), product))
            return;

        var productExists = _productRepository.GetById(product.Id);

        if (productExists != null)
        {
            Notify("Já existe um produto com o ID informado");
            return;
        }

        await _productRepository.Add(product);
    }

    public async Task Update(Product product)
    {
        if (!ExecuteValidation(new ProductValidation(), product))
            return;

        await _productRepository.Update(product);
    }

    public async Task Delete(Guid id)
    {
        await _productRepository.Delete(id);
    }

    public void Dispose()
    {
        _productRepository?.Dispose();
    }
}
