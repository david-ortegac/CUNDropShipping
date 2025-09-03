using CunDropShipping.Controllers.Mapper;
using CunDropShipping.domain.Entity;

namespace CunDropShipping.Controllers.Entity;

public class AdapterMapper : IAdapterMapper
{
    public AdapterProductEntity ToAdapterProduct(DomainProductEntity domainProduct)
    {
        return new AdapterProductEntity
        {
            Id = domainProduct.Id,
            Name = domainProduct.Name,
            Price = (double)domainProduct.Price
        };
    }

    public List<AdapterProductEntity> ToAdapterProductList(List<DomainProductEntity> domainProducts)
    {
        return domainProducts.Count == 0 ? new List<AdapterProductEntity>() : domainProducts.Select(ToAdapterProduct).ToList();
    }
    
    
    public DomainProductEntity ToDomainProduct(AdapterProductEntity adapterProduct)
    {
        return new DomainProductEntity
        {
            Id = adapterProduct.Id,
            Name = adapterProduct.Name,
            Price = adapterProduct.Price
        };
    }

    public List<DomainProductEntity> ToDomainProducts(List<AdapterProductEntity> adapterProducts)
    {
        return adapterProducts.Count == 0 ? new List<DomainProductEntity>() : adapterProducts.Select(ToDomainProduct).ToList();
    }
}