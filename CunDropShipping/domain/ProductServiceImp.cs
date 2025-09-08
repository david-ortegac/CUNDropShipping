using CunDropShipping.application.Service;
using CunDropShipping.domain.Entity;
using CunDropShipping.domain.Mapper;
using CUNDropShipping.infraestructure.DbContext;

namespace CUNDropShipping.domain;

public class ProductServiceImp : IProductService
{
    private readonly IRepository _repository;
    private readonly IInfraestructureMapper _mapper;

    public ProductServiceImp(IRepository set, IInfraestructureMapper mapper)
    {
        this._repository = set;
        this._mapper = mapper;
    }
    
    public List<DomainProductEntity> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        return _mapper.ToDomainProducts(_mapper.ToInfraestructureProducts(products));
    }

    public DomainProductEntity GetById(int id)
    {
        var product = _repository.GetById(id);
        return _mapper.ToDomainProduct(_mapper.ToInfraestructureProduct(product));
    }

    public DomainProductEntity SaveProduct(DomainProductEntity product)
    {
        return _repository.SaveProduct(_mapper.ToInfraestructureProduct(product));
    }

    public DomainProductEntity UpdateProduct(DomainProductEntity product)
    {
        return _repository.UpdateProduct(_mapper.ToInfraestructureProduct(product));
    }

    public string DeleteProduct(int id)
    {
        return _repository.DeleteProduct(id);
    }
}