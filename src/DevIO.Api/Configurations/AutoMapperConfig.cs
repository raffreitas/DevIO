using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.Api.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Supplier, SupplierViewModel>().ReverseMap();
        CreateMap<Address, AddressViewModel>().ReverseMap();
        CreateMap<ProductViewModel, Product>();

        CreateMap<Product, ProductViewModel>()
            .ForMember(x => x.SupplierName, op => op.MapFrom(src => src.Supplier.Name));
    }
}
