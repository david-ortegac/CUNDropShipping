using CunDropShipping.application.Service;
using CunDropShipping.domain.Entity;
using CunDropShipping.domain.Mapper;
using CUNDropShipping.infraestructure.Entity;
using Microsoft.EntityFrameworkCore;

namespace CUNDropShipping.infraestructure.DbContext;

public class DBSet
{
    private readonly AppDbContext _db;
    private readonly IInfraestructureMapper _mapper;

    public DBSet(AppDbContext db, IInfraestructureMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }


    public List<DomainProductEntity> GetAllProducts()
    {
        return _mapper.ToDomainProducts(_db.Products
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToList());
    }

    public DomainProductEntity GetById(int id)
    {
        var entity = _db.Products.Find(id);
        if (entity is null)
            throw new KeyNotFoundException($"Product with id {id} was not found.");

        return _mapper.ToDomainProduct(entity);
    }

    public DomainProductEntity SaveProduct(Products product)
    {
        _db.Products.Add(product);
        _db.SaveChanges();
        return _mapper.ToDomainProduct(product);
    }

    public DomainProductEntity UpdateProduct(Products product)
    {
        _db.Products.Update(product);
        _db.SaveChanges();
        return _mapper.ToDomainProduct(product);
    }

    public string DeleteProduct(int id)
    {
        var entity = _db.Products.Find(id);
        if (entity is null)
            throw new KeyNotFoundException($"Product with id {id} was not found.");

        _db.Products.Remove(entity);
        _db.SaveChanges();
        return $"Product {entity} deleted successfully.";
    }
}