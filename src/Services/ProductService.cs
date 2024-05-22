using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.Entities;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Controllers;
using CodeCrafters_backend_teamwork.src.Databases;
using CodeCrafters_backend_teamwork.src.DTOs;
using AutoMapper;

namespace CodeCrafters_backend_teamwork.src.Services;

public class ProductService : IProductService
{
    private IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public IEnumerable<ProductReadDto> FindMany(string? searchBy)
    {
        var products = _productRepository.FindMany();
        if (searchBy is not null)
        {
            products = products.Where(product => product.Name.ToLower().Contains(searchBy.ToLower()));
        }

        var productRead = products.Select(_mapper.Map<ProductReadDto>);
        return productRead;
    }
    public ProductReadDto CreateOne(ProductCreateDto newProduct)
    {
        Product product = _mapper.Map<Product>(newProduct);
        _productRepository.CreateOne(product);

        return _mapper.Map<ProductReadDto>(product);
    }

    public Product? FindOne(Guid productId)
    {
        return _productRepository.FindOne(productId);
    }

    public IEnumerable<Product>? DeleteProduct(Guid productId)
    {
        return _productRepository.DeleteProduct(productId);
    }

    public Product UpdateOne(Guid productId, Product updatedProduct)
    {
        return _productRepository.UpdateOne(productId, updatedProduct);
    }
}