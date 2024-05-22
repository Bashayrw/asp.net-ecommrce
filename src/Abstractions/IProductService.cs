using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;

namespace CodeCrafters_backend_teamwork.src.Abstractions;

public interface IProductService
{
    public IEnumerable<ProductReadDto> FindMany(string? searchBy);
    public ProductReadDto CreateOne(ProductCreateDto product);
    public Product? FindOne(Guid productId);
    public IEnumerable<Product>? DeleteProduct(Guid productId);
    public Product UpdateOne(Guid productId, Product updatedProduct);
}