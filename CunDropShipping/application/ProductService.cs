using CUNDropShipping.domain;

namespace CUNDropShipping.application;

public interface ProductService
{
    public ProductDomain getAllProducts();
    public ProductDomain getProductById(int id);
    public ProductDomain getProductByName(string name);
    
    public ProductDomain getProductBySlug(string slug);
}