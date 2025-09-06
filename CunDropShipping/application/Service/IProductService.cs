using CunDropShipping.domain.Entity;

namespace CunDropShipping.application.Service;

public interface IProductService
{
    List<DomainProductEntity> GetAllProducts();
    DomainProductEntity GetById(int id);
    DomainProductEntity SaveProduct(DomainProductEntity product);
    DomainProductEntity UpdateProduct(DomainProductEntity product);
    String DeleteProduct(int id);
    
}