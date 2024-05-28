using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Databases;
using CodeCrafters_backend_teamwork.src.DTOs;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Repositories;

public class ProductRepository : IProductRepository
{
    private DbSet<Product> _products;
    private DbSet<Stock> _stocks;
    private DatabaseContext _databasecontext;

    public ProductRepository(DatabaseContext databaseContext)
    {
        _products = databaseContext.Products;
        _stocks = databaseContext.Stocks;
        _databasecontext = databaseContext;

    }
    public IEnumerable<ProductWithStockReadDto> FindMany()
    {
        var products = from product in _products
                       join stock in _stocks on product.Id equals stock.ProductId into ps
                       from s in ps.DefaultIfEmpty()
                       select new ProductWithStockReadDto
                       {
                           Id = product.Id,
                           CategoryId = product.CategoryId,
                           Name = product.Name,
                           Image = product.Image,
                           Price = product.Price,
                           StockId = s.Id != null ? s.Id : null,
                           Size = s.Size != null ? s.Size : null,
                           Quantity = s.Quantity != null ? s.Quantity : null
                       };

        return products;

    }
    public IEnumerable<Product> CreateOne(Product product)
    {
        _products.Add(product);
        _databasecontext.SaveChanges(); // add this and the above to the other entities repos
        return _products;

    }
    public Product? FindOne(Guid productId)
    {
        Product? product = _products.FirstOrDefault(product => product.Id == productId);
        return product;
    }
    public IEnumerable<Product>? DeleteProduct(Guid productId)
    {
        Product? productFound = FindOne(productId);
        if (productFound != null)
        {
            _products.Remove(productFound);
            _databasecontext.SaveChanges();
        }
        return _products;
    }
    public Product UpdateOne(Guid productId, Product updatedProduct)
    {

        Product? product = _products.FirstOrDefault(product => product.Id == productId);
        if (product != null)
        {
            product.Name = updatedProduct.Name;
            _databasecontext.SaveChanges();
            return product;
        }

        return updatedProduct;

    }
}