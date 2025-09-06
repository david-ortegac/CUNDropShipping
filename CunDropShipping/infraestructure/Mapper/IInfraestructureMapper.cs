using CunDropShipping.domain.Entity;
using CUNDropShipping.infraestructure.Entity;

namespace CunDropShipping.domain.Mapper;

public interface IInfraestructureMapper
{
    // Convierte una entidad de Dominio a Infraestructura
    Products ToInfraestructureProduct(DomainProductEntity domainProduct);
    List<Products> ToInfraestructureProducts(List<DomainProductEntity> domainProducts);

    // Convierte una entidad de Infraestructura a Dominio
    DomainProductEntity ToDomainProduct(Products infraProduct);
    List<DomainProductEntity> ToDomainProducts(List<Products> infraProducts);
}