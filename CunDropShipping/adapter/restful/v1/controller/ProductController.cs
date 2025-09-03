using CUNDropShipping.adapter.restful.v1.controller.Mapper;
using CunDropShipping.application.Service;
using CunDropShipping.Controllers.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CunDropShipping.adapter.restful.v1.controller;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly IAdapterMapper _adapterMapper;

    public ProductController(ProductService service, IAdapterMapper adapterMapper)
    {
        _productService = service;
        _adapterMapper = adapterMapper;
    }

    // GET api/v1/products
        [HttpGet]
        public ActionResult<IEnumerable<AdapterProductEntity>> GetAll()
        {
            var domainList = _productService.GetAllProducts();
            var adapterList = _adapterMapper.ToAdapterProductList(domainList);
            return Ok(adapterList);
        }

        // GET api/v1/products/5
        [HttpGet("{id:int}")]
        public ActionResult<AdapterProductEntity> GetById(int id)
        {
            var domain = _productService.GetById(id);
            var adapter = _adapterMapper.ToAdapterProduct(domain);
            return Ok(adapter);
        }

        // POST api/v1/products
        [HttpPost]
        public ActionResult<AdapterProductEntity> Create([FromBody] AdapterProductEntity payload)
        {
            var domain = _adapterMapper.ToDomainProduct(payload);
            var created = _productService.SaveProduct(domain);
            var adapter = _adapterMapper.ToAdapterProduct(created);

            // Devuelve 201 con Location
            return CreatedAtAction(nameof(GetById), new { id = adapter.Id }, adapter);
        }

        // PUT api/v1/products/5
        [HttpPut("{id:int}")]
        public ActionResult<AdapterProductEntity> Update(int id, [FromBody] AdapterProductEntity payload)
        {
            var domain = _adapterMapper.ToDomainProduct(payload);
            var updated = _productService.UpdateProduct(domain);
            if (updated == null) return NotFound();

            var adapter = _adapterMapper.ToAdapterProduct(updated);
            return Ok(adapter);
        }

        // DELETE api/v1/products/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productService.DeleteProduct(id);
            return NoContent();
        }
    
}