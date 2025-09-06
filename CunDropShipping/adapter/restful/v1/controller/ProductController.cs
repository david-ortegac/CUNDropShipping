using CUNDropShipping.adapter.restful.v1.controller.Mapper;
using CunDropShipping.application.Service;
using CunDropShipping.Controllers.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CunDropShipping.adapter.restful.v1.controller;

[ApiController]
[Route("api/v1/products")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IAdapterMapper _adapterMapper;

    public ProductController(IProductService service, IAdapterMapper adapterMapper)
    {
        _productService = service;
        _adapterMapper = adapterMapper;
    }

    // GET api/v1/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdapterProductEntity>>> GetAll()
        {
            return Ok(_adapterMapper.ToAdapterProductList(_productService.GetAllProducts()));
        }

        // GET api/v1/products/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<AdapterProductEntity>> GetById(int id)
        {
            return Ok(_adapterMapper.ToAdapterProduct(_productService.GetById(id)));
        }

        // POST api/v1/products
        [HttpPost]
        public async Task<ActionResult<AdapterProductEntity>> Create([FromBody] AdapterProductEntity payload)
        {
            return Ok(_adapterMapper.ToAdapterProduct(_productService.SaveProduct(_adapterMapper.ToDomainProduct(payload))));
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