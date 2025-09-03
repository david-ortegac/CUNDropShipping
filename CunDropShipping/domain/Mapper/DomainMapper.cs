using CunDropShipping.domain.Entity;
using CUNDropShipping.infraestructure.Entity;

namespace CunDropShipping.domain.Mapper;

public class DomainMapper: IDomainMapper
{
    public InfraestructureProductEntity ToInfraestructureProduct(DomainProductEntity domainProduct)
    {
        return new InfraestructureProductEntity
        {
            Id = domainProduct.Id,
            Name = domainProduct.Name,
            Price = domainProduct.Price
        };
    }

    public List<InfraestructureProductEntity> ToInfraestructureProducts(List<DomainProductEntity> domainProducts)
    {
        return domainProducts.Count == 0 ? new List<InfraestructureProductEntity>() : domainProducts.Select(ToInfraestructureProduct).ToList();
    }

    public DomainProductEntity ToDomainProduct(InfraestructureProductEntity infraProduct)
    {
        return new DomainProductEntity
        {
            Id = infraProduct.Id,
            Name = infraProduct.Name,
            Price = infraProduct.Price
        };
    }

    public List<DomainProductEntity> ToDomainProducts(List<InfraestructureProductEntity> infraProducts)
    {
        return infraProducts.Count == 0 ? new List<DomainProductEntity>() : infraProducts.Select(ToDomainProduct).ToList();
    }
}