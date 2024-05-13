using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeCrafters_backend_teamwork.src.Abstractions;
using CodeCrafters_backend_teamwork.src.Databases;
using CodeCrafters_backend_teamwork.src.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeCrafters_backend_teamwork.src.Repositories;

public class ProductRepository : IProductRepository
{
    private DbSet<Product> _products;
    private DatabaseContext _databasecontext;

    public ProductRepository(DatabaseContext databaseContext)
    {
        _products = databaseContext.Products;
        _databasecontext = databaseContext;

    }
    public IEnumerable<Product> FindMany()
    {
        return _products;
        
    }
    public IEnumerable<Product> CreateOne(Product product) // POST DOES NOT WORK 
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