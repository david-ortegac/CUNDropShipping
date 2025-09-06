using CunDropShipping.application.Service;
using CunDropShipping.domain.Entity;
using CunDropShipping.domain.Mapper;
using CUNDropShipping.infraestructure.DbContext;

namespace CUNDropShipping.domain;

public class ProductServiceImp : IProductService
{
    private readonly DBSet _dbSet;
    private readonly IInfraestructureMapper _mapper;

    public ProductServiceImp(DBSet set, IInfraestructureMapper mapper)
    {
        this._dbSet = set;
        this._mapper = mapper;
    }
    
    public List<DomainProductEntity> GetAllProducts()
    {
        var products = _dbSet.GetAllProducts();
        return _mapper.ToDomainProducts(_mapper.ToInfraestructureProducts(products));
    }

    public DomainProductEntity GetById(int id)
    {
        var product = _dbSet.GetById(id);
        return _mapper.ToDomainProduct(_mapper.ToInfraestructureProduct(product));
    }

    public DomainProductEntity SaveProduct(DomainProductEntity product)
    {
        return _dbSet.SaveProduct(_mapper.ToInfraestructureProduct(product));
    }

    public DomainProductEntity UpdateProduct(DomainProductEntity product)
    {
        return _dbSet.UpdateProduct(_mapper.ToInfraestructureProduct(product));
    }

    public string DeleteProduct(int id)
    {
        return _dbSet.DeleteProduct(id);
    }
}