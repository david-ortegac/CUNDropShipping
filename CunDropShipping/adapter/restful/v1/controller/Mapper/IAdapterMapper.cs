using CunDropShipping.Controllers.Entity;
using CunDropShipping.domain.Entity;

namespace CUNDropShipping.adapter.restful.v1.controller.Mapper;

public interface IAdapterMapper
{
    //Recibe una entidad del Dominio y la convierte a una entidad del Adaptador 
    AdapterProductEntity ToAdapterProduct(DomainProductEntity domainProduct);
    List<AdapterProductEntity> ToAdapterProductList(List<DomainProductEntity> domainProducts);
    
    
    //Recibe una entidad del Adaptador y la convierte a una entidad del Dominio 
    public DomainProductEntity ToDomainProduct(AdapterProductEntity adapterProduct);
    public List<DomainProductEntity> ToDomainProducts(List<AdapterProductEntity> adapterProducts);


}