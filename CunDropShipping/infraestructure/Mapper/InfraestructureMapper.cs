using CunDropShipping.domain.Entity;
using CUNDropShipping.infraestructure.Entity;

namespace CunDropShipping.domain.Mapper;

public class InfraestructureMapper: IInfraestructureMapper
{
    public Products ToInfraestructureProduct(DomainProductEntity domainProduct)
    {
        return new Products
        {
            Id = domainProduct.Id,
            Name = domainProduct.Name,
            Price = domainProduct.Price
        };
    }

    public List<Products> ToInfraestructureProducts(List<DomainProductEntity> domainProducts)
    {
        return domainProducts.Count == 0 ? new List<Products>() : domainProducts.Select(ToInfraestructureProduct).ToList();
    }

    public DomainProductEntity ToDomainProduct(Products infraProduct)
    {
        return new DomainProductEntity
        {
            Id = infraProduct.Id,
            Name = infraProduct.Name,
            Price = infraProduct.Price
        };
    }

    public List<DomainProductEntity> ToDomainProducts(List<Products> infraProducts)
    {
        return infraProducts.Count == 0 ? new List<DomainProductEntity>() : infraProducts.Select(ToDomainProduct).ToList();
    }
}