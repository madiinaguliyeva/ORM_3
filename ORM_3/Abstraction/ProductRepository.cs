using ORM_3.DataAcces;
using ORM_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ORM_3.Abstraction
{
    public class ProductRepository
    {
        private readonly ShopDbContext _context;

        public ProductRepository(ShopDbContext context)
        {
            _context = context;
        }

        public Product Add(Product obj)
        {
            _context.Products.Add(obj);
            SaveChanges();
            return obj;
        }

        public Product? Get(Expression<Func<Product, bool>> exp)
        {
            return _context.Products.FirstOrDefault(exp);
        }

        public Product? Get(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IEnumerable<Product> GetByFilter(Expression<Func<Product, bool>> exp)
        {
            return _context.Products.Where(exp).ToList();
        }

        public Product Update(Product obj)
        {
            _context.Products.Update(obj);
            SaveChanges();
            return obj;
        }

        public bool Delete(Product obj)
        {
            _context.Products.Remove(obj);
            return SaveChanges();
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}