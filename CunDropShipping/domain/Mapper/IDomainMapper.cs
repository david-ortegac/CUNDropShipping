using CunDropShipping.domain.Entity;
using CUNDropShipping.infraestructure.Entity;

namespace CunDropShipping.domain.Mapper;

public interface IDomainMapper
{
    // Convierte una entidad de Dominio a Infraestructura
    InfraestructureProductEntity ToInfraestructureProduct(DomainProductEntity domainProduct);
    List<InfraestructureProductEntity> ToInfraestructureProducts(List<DomainProductEntity> domainProducts);

    // Convierte una entidad de Infraestructura a Dominio
    DomainProductEntity ToDomainProduct(InfraestructureProductEntity infraProduct);
    List<DomainProductEntity> ToDomainProducts(List<InfraestructureProductEntity> infraProducts);
}