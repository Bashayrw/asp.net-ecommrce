using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CodeCrafters_backend_teamwork.src.Controllers;

public class ProductController : CustomizedController
{
    private IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductReadDto>> FindMany([FromQuery(Name ="searchBy")] string? searchBy)
    {
        return Ok (_productService.FindMany(searchBy));
    }
    [HttpGet("{productId}")]
    public Product? FindOne(Guid productId)
    {
        return _productService.FindOne(productId);
    }
    [HttpPost]
    public ActionResult<IEnumerable<ProductReadDto>> CreateOne([FromBody] ProductCreateDto product)
    {
        return CreatedAtAction(nameof(CreateOne), _productService.CreateOne(product));

    }
    
    [HttpDelete("{productId}")]
    public IEnumerable<Product>? DeleteProduct([FromRoute] Guid productId)
    {
        return _productService.DeleteProduct(productId);
    }
    [HttpPatch("{productId}")]
    public Product UpdateOne(Guid productId, Product updatedProduct)
    {
        return _productService.UpdateOne(productId, updatedProduct);
    }


}